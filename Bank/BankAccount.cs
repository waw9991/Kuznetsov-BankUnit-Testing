namespace BankAccountNS;

/// <summary>Учебная модель банковского счёта.</summary>
public class BankAccount
{
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

    private readonly string m_customerName = string.Empty;
    private double m_balance;

    private BankAccount() { }

    public BankAccount(string customerName, double balance)
    {
        m_customerName = customerName;
        m_balance = balance;
    }

    public string CustomerName => m_customerName;
    public double Balance => m_balance;

    public void Debit(double amount)
    {
        if (amount > m_balance)
            throw new ArgumentOutOfRangeException(nameof(amount), amount,
                DebitAmountExceedsBalanceMessage);
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), amount,
                DebitAmountLessThanZeroMessage);

        m_balance -= amount;
    }

    public void Credit(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        m_balance += amount;
    }

    public static void Main()
    {
        BankAccount account = new("Andrey Kuznetsov", 1800.00);
        account.Credit(250.00);
        account.Debit(425.50);
        Console.WriteLine($"Customer: {account.CustomerName}");
        Console.WriteLine($"Current balance: {account.Balance:F2}");
    }
}
