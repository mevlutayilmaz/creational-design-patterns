namespace CreationalDesignPatterns.ObjectPoolDesignPattern.Example5.Classes
{
    public class X
    {
        public int Count { get; set; }
        public void Write()
            => Console.WriteLine(Count);
        public X()
            => Console.WriteLine("X is created.");
        ~X()
            => Console.WriteLine("X is destroyed.");
    }
}
