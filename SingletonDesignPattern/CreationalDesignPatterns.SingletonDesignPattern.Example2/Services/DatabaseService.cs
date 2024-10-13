namespace CreationalDesignPatterns.SingletonDesignPattern.Example2.Services
{
    public class DatabaseService
    {
        private DatabaseService()
        {
            Console.WriteLine($"{nameof(DatabaseService)} is created.");
        }

        static DatabaseService _databaseService;
        static DatabaseService()
        {
            _databaseService = new DatabaseService();
        }
        public static DatabaseService GetInstance { get => _databaseService; }

        public int Count { get; set; }
        public void Connection()
        {
            Count++;
            Console.WriteLine("Connected");
        }
        public void Disconnect()
        {
            Console.WriteLine("Disconnected");
        }
    }
}
