//Creator İçerisindeki Nesne Bağımlılığını Ortadan Kaldırma


using System.Reflection;

BankCreator bankCreator = new();
GarantiBank? garantiBank = bankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank = bankCreator.Create(BankType.VakifBank) as VakifBank;

#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    public GarantiBank(string userCode, string password)
    {
        _userCode = userCode;
        _password = password;
        Console.WriteLine($"{nameof(GarantiBank)} is created.");
    }

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    public HalkBank(string userCode)
    {
        _userCode = userCode;
        Console.WriteLine($"{nameof(HalkBank)} is created.");
    }
    public string Password { set => _password = value; }
    public void Send(int amount, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}

class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Mail { get; set; }
}

class VakifBank : IBank
{
    string _userCode, _email, _password;
    public VakifBank(CredentialVakifBank credential, string password)
    {
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
        Console.WriteLine($"{nameof(VakifBank)} is created.");
    }

    public bool ValidateCredential()
    {
        return true;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}
#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion

#region Concrete Factories
class GarantiBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        GarantiBank garantiBank = new("code", "password");
        garantiBank.ConnectGaranti();
        return garantiBank;
    }
}

class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("code");
        halkBank.Password = "password";
        return halkBank;
    }
}

class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakifBank vakifBank = new(new() { Mail = "mail", UserCode = "code" }, "password");
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
#endregion

#region Creator
enum BankType
{
    GarantiBank, HalkBank, VakifBank
}
class BankCreator
{
    public IBank Create(BankType bankType)
    {
        string factory = $"{bankType.ToString()}Factory";
        Type? type = Assembly.GetExecutingAssembly().GetType(factory);
        IBankFactory? bankFactory = Activator.CreateInstance(type) as IBankFactory;
        return bankFactory.CreateInstance();
    }
}
#endregion
