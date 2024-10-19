//Factory Method Desgin Pattern İle Conrete Builder'ları Üretme

//Abstract class ile Builder Design Pattern

ArabaDirector director = new();
Araba opel = director.Build(BuilderCreator.Create(BuilderType.Opel));
Araba mercedes = director.Build(BuilderCreator.Create(BuilderType.Mercedes));
Araba toyota = director.Build(BuilderCreator.Create(BuilderType.Toyota));

opel.ToString();
mercedes.ToString();
toyota.ToString();

#region Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double KM { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {KM} kilometrede {Vites} vites olarak üretilmiştir.");
        return base.ToString();
    }
}
#endregion

#region Abstract Builder & Products(Factory Method Design Pattern için)
abstract class ArabaBuilder
{
    protected Araba araba;
    public Araba Araba { get => araba; }
    public ArabaBuilder()
        => araba = new();
    public abstract ArabaBuilder SetMarka();
    public abstract ArabaBuilder SetModel();
    public abstract ArabaBuilder SetKM();
    public abstract ArabaBuilder SetVites();
}
#endregion

#region Concrete Builders & Products(Factory Method Design Pattern için)
class OpelBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Opel";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "Astra";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}

class MercedesBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Mercedes";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "Maybach";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}

class ToyotaBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Toyota";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "Corolla";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = false;
        return this;
    }
}
#endregion

#region Director
class ArabaDirector
{
    public Araba Build(ArabaBuilder arabaBuilder)
    {
        arabaBuilder.SetMarka()
            .SetModel()
            .SetKM()
            .SetVites();
        return arabaBuilder.Araba;
    }
}
#endregion

#region Creator(Factory Method Design Pattern için)
enum BuilderType
{
    Opel, Mercedes, Toyota
}
class BuilderCreator
{
    static public ArabaBuilder Create(BuilderType builderType)
    {
        return builderType switch
        {
            BuilderType.Opel => new OpelBuilder(),
            BuilderType.Mercedes => new MercedesBuilder(),
            BuilderType.Toyota => new ToyotaBuilder()
        };
    }
}
#endregion