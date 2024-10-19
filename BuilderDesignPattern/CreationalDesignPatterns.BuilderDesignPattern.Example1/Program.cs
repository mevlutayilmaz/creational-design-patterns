//interface ile Builder Design Pattern

ArabaDirector director = new();
Araba opel = director.Build(new OpelBuilder());
Araba mercedes = director.Build(new MercedesBuilder());
Araba toyota = director.Build(new ToyotaBuilder());

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

#region Abstract Builder
interface IArabaBuilder
{
    Araba Araba { get; }
    IArabaBuilder SetMarka();
    IArabaBuilder SetModel();
    IArabaBuilder SetKm();
    IArabaBuilder SetVites();
}
#endregion

#region Concrete Builders
class OpelBuilder : IArabaBuilder
{
    public Araba Araba { get; }
    public OpelBuilder()
        => Araba = new Araba();

    public IArabaBuilder SetKm()
    {
        Araba.KM = 0;
        return this;
    }

    public IArabaBuilder SetMarka()
    {
        Araba.Marka = "Opel";
        return this;
    }

    public IArabaBuilder SetModel()
    {
        Araba.Model = "Astra";
        return this;
    }

    public IArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}

class MercedesBuilder : IArabaBuilder
{
    public Araba Araba { get; }
    public MercedesBuilder()
        => Araba = new Araba();

    public IArabaBuilder SetKm()
    {
        Araba.KM = 0;
        return this;
    }

    public IArabaBuilder SetMarka()
    {
        Araba.Marka = "Mercedes";
        return this;
    }

    public IArabaBuilder SetModel()
    {
        Araba.Model = "Mybach";
        return this;
    }

    public IArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}

class ToyotaBuilder : IArabaBuilder
{
    public Araba Araba { get; }
    public ToyotaBuilder()
        => Araba = new Araba();

    public IArabaBuilder SetKm()
    {
        Araba.KM = 0;
        return this;
    }

    public IArabaBuilder SetMarka()
    {
        Araba.Marka = "Toyota";
        return this;
    }

    public IArabaBuilder SetModel()
    {
        Araba.Model = "Corolla";
        return this;
    }

    public IArabaBuilder SetVites()
    {
        Araba.Vites = false;
        return this;
    }
}
#endregion

#region Director
class ArabaDirector
{
    public Araba Build(IArabaBuilder arabaBuilder)
    {
        arabaBuilder.SetMarka()
            .SetModel()
            .SetKm()
            .SetVites();
        return arabaBuilder.Araba;
    }
}
#endregion