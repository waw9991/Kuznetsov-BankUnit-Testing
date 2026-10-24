using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        // Arrange: подготовка счёта и ожидаемого остатка.
        double beginningBalance = 1800.00;
        double debitAmount = 425.50;
        double expected = 1374.50;
        BankAccount account = new("Andrey Kuznetsov", beginningBalance);

        // Act: выполнение списания.
        account.Debit(debitAmount);

        // Assert: сравнение фактического и ожидаемого баланса.
        Assert.AreEqual(expected, account.Balance, 0.001,
            "Account not debited correctly");
    }

    [TestMethod]
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        BankAccount account = new("Andrey Kuznetsov", 1800.00);
        double debitAmount = -25.00;

        try
        {
            account.Debit(debitAmount);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            StringAssert.Contains(exception.Message,
                BankAccount.DebitAmountLessThanZeroMessage);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");
    }

    [TestMethod]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        BankAccount account = new("Andrey Kuznetsov", 1800.00);
        double debitAmount = 2000.00;

        try
        {
            account.Debit(debitAmount);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            StringAssert.Contains(exception.Message,
                BankAccount.DebitAmountExceedsBalanceMessage);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");
    }
}
