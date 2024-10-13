
Example1 ex1 = Example1.GetInstance;
Example1 ex2 = Example1.GetInstance;
Example1 ex3 = Example1.GetInstance;
Example1 ex4 = Example1.GetInstance;

Example2 e1 = Example2.GetInstance;
Example2 e2 = Example2.GetInstance;
Example2 e3 = Example2.GetInstance;
Example2 e4 = Example2.GetInstance;

#region 1. Yöntem
class Example1
{
    private Example1()
    {
        Console.WriteLine($"{nameof(Example1)} nesnesi oluşturuldu.");
    }

    static Example1 _example1;
    public static Example1 GetInstance
    {
        get
        {
            if (_example1 == null)
                _example1 = new Example1();

            return _example1;
        }
    }
}
#endregion

#region 2. Yöntem
class Example2
{
    private Example2()
    {
        Console.WriteLine($"{nameof(Example2)} nesnesi oluşturuldu.");
    }

    static Example2 _example2;
    static Example2()
    {
        _example2 = new Example2();
    }

    public static Example2 GetInstance { get => _example2; }
}
#endregion

