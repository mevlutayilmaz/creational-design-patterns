
var mssql = Database.GetInstance("MSSQL", "localhost:mssql");
var mongodb = Database.GetInstance("MongoDB", "localhost:mongodb");
var redis = Database.GetInstance("Redis", "localhost:redis");

var mssql2 = Database.GetInstance("MSSQL");
var mongodb2 = Database.GetInstance("MongoDB");
var redis2 = Database.GetInstance("Redis");

Console.WriteLine(mssql2.ConnString);
Console.WriteLine(mongodb2.ConnString);
Console.WriteLine(redis2.ConnString);

class Database
{
    public string ConnString { get; set; }
    private Database()
    {
        Console.WriteLine($"{nameof(Database)} is created.");
    }

    static Dictionary<string, Database> _databases = new();
    public static Database GetInstance(string key)
    {
        if(!_databases.ContainsKey(key))
            _databases[key] = new Database();

        return _databases[key];
    }

    public static Database GetInstance(string key, string connectionString)
    {
        Database _database = Database.GetInstance(key);
        _database.ConnectionString(connectionString);
        return _database;
    }

    public void ConnectionString(string connectionString)
    {
        ConnString = connectionString;
    }
}