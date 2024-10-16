
ComputerCreator creator = new();
Computer asus = creator.CreateComputer(ComputerType.Asus);
Computer lenovo = creator.CreateComputer(ComputerType.Lenovo);
Computer toshiba = creator.CreateComputer(ComputerType.Toshiba);

class Computer
{
    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }
}

#region Abstract Products
interface ICPU { }
interface IRAM { }
interface IVideoCard { }
#endregion

#region Concrete Products
class CPU : ICPU 
{ 
    public CPU(string text)
        => Console.WriteLine(text);
}
class RAM : IRAM
{
    public RAM(string text)
        => Console.WriteLine(text);
}
class VideoCard : IVideoCard
{
    public VideoCard(string text)
        => Console.WriteLine(text);
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factories
class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("Asus CPU is created.");

    public IRAM CreateRAM()
        => new RAM("Asus RAM is created.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Asus VideoCard is created.");
}
class LenovoFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("Lenovo CPU is created.");

    public IRAM CreateRAM()
        => new RAM("Lenovo RAM is created.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Lenovo VideoCard is created.");
}
class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("Toshiba CPU is created.");

    public IRAM CreateRAM()
        => new RAM("Toshiba RAM is created.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Toshiba VideoCard is created.");
}
#endregion

#region Creator
enum ComputerType
{
    Asus, Lenovo, Toshiba
}
class ComputerCreator
{
    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory factory = computerType switch
        {
            ComputerType.Asus => new AsusFactory(),
            ComputerType.Lenovo => new LenovoFactory(),
            ComputerType.Toshiba => new ToshibaFactory()
        };
        
        return new()
        {
            CPU = factory.CreateCPU(),
            RAM = factory.CreateRAM(),
            VideoCard = factory.CreateVideoCard()
        };
    }
}
#endregion