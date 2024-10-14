//Simple Factory yöntemi

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
        IProduct _product = null;
        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                //...
                break;
            case ProductType.B:
                _product = new B();
                //...
                break;
            case ProductType.C:
                _product = new C();
                //...
                break;
        }

        return _product;
    }
}
#endregion