using System.Collections.Concurrent;

ObjectPool<X> pool = new();
X x1 = pool.Get(() => new X());
x1.Count++;
x1.Write();
pool.Return(x1);

X x2 = pool.Get(() => new X());
x1.Count++;
x2.Write();
pool.Return(x2);

X x3 = pool.Get(() => new X());
x3.Count++;
x3.Write();
pool.Return(x3);

class ObjectPool<T> where T : class
{
    readonly ConcurrentBag<T> _instances; //Pool
    public ObjectPool()
        => _instances = new();

    public T Get(Func<T>? objectGenerator = null)
        => _instances.TryTake(out T instance) ? instance : objectGenerator();

    public void Return(T instance)
        => _instances.Add(instance);
}


class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);
    public X()
        => Console.WriteLine("X is created.");
    ~X()
        => Console.WriteLine("X is destroyed.");
}