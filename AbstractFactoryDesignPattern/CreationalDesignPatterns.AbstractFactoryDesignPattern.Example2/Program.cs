
DatababeCreator creator = new();
Database oracle = creator.CreateDatabase(DatabaseType.Oracle);
Database mySQL = creator.CreateDatabase(DatabaseType.MySQL);
Database msSQL = creator.CreateDatabase(DatabaseType.MsSQL);
Database postgreSQL = creator.CreateDatabase(DatabaseType.PostgreSQL);

enum DatabaseType
{
    Oracle, MsSQL, MySQL, PostgreSQL
}

enum ConnectionState
{
    Open, Close
}

class Database
{
    public DatabaseType DatabaseType { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }
}

#region Abstract Products
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState ConnectionState { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();
}

abstract class AbstractCommand
{
    public abstract void Execute(string query);
}
#endregion

#region Concrete Products
class Connection : AbstractConnection
{
    string _connectionString;
    public Connection() { }
    public Connection(string connectionString)
        => _connectionString = connectionString;

    public override string ConnectionString { get => _connectionString; set => _connectionString = value; }
    public override ConnectionState ConnectionState { get; set; }

    public override bool Connect()
    {
        //...
        ConnectionState = ConnectionState.Open;
        return true;
    }

    public override bool Disconnect()
    {
        //...
        ConnectionState = ConnectionState.Close;
        return true;
    }
}

class Command : AbstractCommand
{
    public override void Execute(string query)
    {
        //....
    }
}
#endregion

#region Abstract Factory
abstract class DatabaseFactory
{
    public abstract AbstractConnection CreateConnection();
    public abstract AbstractCommand CreateCommand();
}
#endregion

#region Concrete Factories
class OracleFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
        => new Command();

    public override AbstractConnection CreateConnection()
        => new Connection("Oracle connection string");
}

class MsSQLFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
        => new Command();

    public override AbstractConnection CreateConnection()
        => new Connection("MsSQL connection string");
}

class MySQLFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
        => new Command();

    public override AbstractConnection CreateConnection()
        => new Connection("MySQL connection string");
}

class PostgreSQLFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
        => new Command();

    public override AbstractConnection CreateConnection()
        => new Connection("PostgreSQL connection string");
}
#endregion

#region Creator
class DatababeCreator
{
    public Database CreateDatabase(DatabaseType databaseType)
    {
        DatabaseFactory factory = databaseType switch
        {
            DatabaseType.Oracle => new OracleFactory(),
            DatabaseType.MySQL => new MySQLFactory(),
            DatabaseType.MsSQL => new MsSQLFactory(),
            DatabaseType.PostgreSQL => new PostgreSQLFactory()
        };
        return new()
        {
            DatabaseType = databaseType,
            Connection = factory.CreateConnection(),
            Command = factory.CreateCommand(),
        };
    }
}
#endregion