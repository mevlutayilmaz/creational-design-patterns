//Singleton Desing Pattern uygulamalarında 1. yöntemin uygulandığı seneryolarda asenkron işlemlerde birden fazla nesnenin oluşması söz konusu olabilir. Bu durumu çözmek için;

List<Task> tasks = new();

for (int i = 0; i < 100; i++)
{
    tasks.Add(Task.Run(() =>
    {
        Example1 ex1 = Example1.GetInstance;
        Example2 ex2 = Example2.GetInstance;
    }));
}

await Task.WhenAll(tasks);

#region 1. Yöntem lock ile kilitleyerek
class Example1
{
    private Example1()
    {
        Console.WriteLine($"{nameof(Example1)} is created.");
    }

    static Example1 _example1;
    static object _obj = new();
    public static Example1 GetInstance
    {
        get
        {
            lock (_obj)
            {
                if (_example1 == null)
                    _example1 = new Example1();
            }
            
            return _example1;
        }
    }
}
#endregion

#region 2. Yöntem static constructor kullanarak
class Example2
{
    private Example2()
    {
        Console.WriteLine($"{nameof(Example2)} is created.");
    }

    static Example2 _example2;
    static Example2()
        => _example2 = new Example2();
    public static Example2 GetInstance { get => _example2; }
}
#endregion
