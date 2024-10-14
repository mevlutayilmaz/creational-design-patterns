//Factory Method yöntemi

A? a = ProductCreator.GetInstance(ProductType.A) as A;
B? b = ProductCreator.GetInstance(ProductType.B) as B;
C? c = ProductCreator.GetInstance(ProductType.C) as C;
a?.Run();
b?.Run();
c?.Run();

#region Abstract Products
interface IProduct
{
    void Run();
}
#endregion

#region Concrete Products
class A : IProduct
{
    public void Run()
    {
        Console.WriteLine($"{nameof(A)} is running");
    }
}

class B : IProduct
{
    public void Run()
    {
        Console.WriteLine($"{nameof(B)} is running");
    }
}

class C : IProduct
{
    public void Run()
    {
        Console.WriteLine($"{nameof(C)} is running");
    }
}
#endregion

#region Abstract Factory
interface IFactory
{
    IProduct CreateProduct();
}
#endregion

#region Concrete Factories
class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        //...
        return new A();
    }
}

class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        //...
        return new B();
    }
}

class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        //...
        return new C();
    }
}
#endregion

#region Creator
enum ProductType
{
    A,
    B,
    C
}
class ProductCreator
{
    public static IProduct GetInstance(ProductType productType)
    {
        IFactory factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory()
        };
        return factory.CreateProduct();
    }
}
#endregion