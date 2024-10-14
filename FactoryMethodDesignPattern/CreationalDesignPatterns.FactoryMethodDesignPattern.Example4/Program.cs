//Factory Method Design Pettern - Product'ları ve Factory'leri Singleton Pattern ile tekilleştirme


BankCreator bankCreator = new();
GarantiBank? garantiBank = bankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank = bankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garantiBank2 = bankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank2 = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank2 = bankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garantiBank3 = bankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank3 = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank3 = bankCreator.Create(BankType.VakifBank) as VakifBank;

#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    GarantiBank(string userCode, string password)
    {
        _userCode = userCode;
        _password = password;
        Console.WriteLine($"{nameof(GarantiBank)} is created.");
    }

    static GarantiBank _garantiBank;
    static GarantiBank()
        => _garantiBank = new("code", "password");
    static public GarantiBank GetInstance
        => _garantiBank;

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    HalkBank(string userCode)
    {
        _userCode = userCode;
        Console.WriteLine($"{nameof(HalkBank)} is created.");
    }
    static HalkBank _halkBank;
    static HalkBank()
        => _halkBank = new("code");
    static public HalkBank GetInstance
        => _halkBank;
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
    VakifBank(CredentialVakifBank credential, string password)
    {
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
        Console.WriteLine($"{nameof(VakifBank)} is created.");
    }

    static VakifBank _vakifBank;
    static VakifBank()
        => _vakifBank = new(new() { Mail = "mail", UserCode = "code" }, "password");
    static public VakifBank GetInstance
        => _vakifBank;

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
    GarantiBankFactory() { }

    static GarantiBankFactory _garantiBankFactory;
    static GarantiBankFactory() 
        => _garantiBankFactory = new();
    static public GarantiBankFactory GetInstance
        => _garantiBankFactory;

    public IBank CreateInstance()
    {
        GarantiBank garantiBank = GarantiBank.GetInstance;
        garantiBank.ConnectGaranti();
        return garantiBank;
    }
}

class HalkBankFactory : IBankFactory
{
    HalkBankFactory() { }

    static HalkBankFactory _halkBankFactory;
    static HalkBankFactory()
        => _halkBankFactory = new();
    static public HalkBankFactory GetInstance
        => _halkBankFactory;

    public IBank CreateInstance()
    {
        HalkBank halkBank = HalkBank.GetInstance;
        halkBank.Password = "password";
        return halkBank;
    }
}

class VakifBankFactory : IBankFactory
{
    VakifBankFactory() { }

    static VakifBankFactory _vakifBankFactory;
    static VakifBankFactory()
        => _vakifBankFactory = new();
    static public VakifBankFactory GetInstance
        => _vakifBankFactory;

    public IBank CreateInstance()
    {
        VakifBank vakifBank = VakifBank.GetInstance;
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
        IBankFactory _bankFactory = bankType switch
        {
            BankType.GarantiBank => GarantiBankFactory.GetInstance,
            BankType.HalkBank => HalkBankFactory.GetInstance,
            BankType.VakifBank => VakifBankFactory.GetInstance
        };
        return _bankFactory.CreateInstance();
    }
}
#endregion