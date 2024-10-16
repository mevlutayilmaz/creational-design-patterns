
DatababeCreator creator = new();
Database mySQL = creator.CreateDatabase(DatabaseType.MySQL);
Database msSQL = creator.CreateDatabase(DatabaseType.MsSQL);


enum DatabaseType
{
    MsSQL, MySQL
}

enum ConnectionState
{
    Open, Close
}

class Database
{
    public DatabaseType DatabaseType { get; set; }
    public Connection Connection { get; set; }
    public Command Command { get; set; }
}

#region Abstract Products
abstract class Connection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState ConnectionState { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();
}

abstract class Command
{
    public abstract void Execute(string query);
}
#endregion

#region Concrete Products
class MsSQLConnection : Connection
{
    public override string ConnectionString { get; set; }
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

class MySQLConnection : Connection
{
    public override string ConnectionString { get; set; }
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

class MsSQLCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

class MySQLCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}
#endregion

#region Abstract Factory
abstract class DatabaseFactory
{
    public abstract Connection CreateConnection();
    public abstract Command CreateCommand();
}
#endregion

#region Concrete Factories
class MsSQLFactory : DatabaseFactory
{
    public override Command CreateCommand()
        => new MsSQLCommand();

    public override Connection CreateConnection()
    {
        MsSQLConnection connection = new MsSQLConnection();
        connection.ConnectionString = "MsSQL connection string";
        return connection;
    }
}

class MySQLFactory : DatabaseFactory
{
    public override Command CreateCommand()
        => new MySQLCommand();

    public override Connection CreateConnection()
    {
        MySQLConnection connection = new MySQLConnection();
        connection.ConnectionString = "MySQL connection string";
        return connection;
    }
}
#endregion

#region Creator
class DatababeCreator
{
    public Database CreateDatabase(DatabaseType databaseType)
    {
        DatabaseFactory factory = databaseType switch
        {
            DatabaseType.MySQL => new MySQLFactory(),
            DatabaseType.MsSQL => new MsSQLFactory()
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