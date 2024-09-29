namespace TestProject1;

using System;
using Xunit;

public class EncapsulationTests
{
    [Fact]
    public void Deposit_IncreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount(12345, 1000, 0.05);

        // Act
        account.Deposit(500);

        // Assert
        Assert.Equal(1500, account.GetBalance());
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount(12345, 1000, 0.05);

        // Act
        account.Withdraw(200);

        // Assert
        Assert.Equal(800, account.GetBalance());
    }

    [Fact]
    public void CalculateInterest_IncreasesBalance()
    {
        // Arrange
        var accountNumber = 12345;
        BankAccount account = new BankAccount(accountNumber, 1000, 0.05);

        // Act
        account.CalculateInterest();

        // Assert
        Assert.Equal(1050, account.GetBalance());
    }

    [Theory]
    [InlineData(1000, true)]
    [InlineData(1000, false)]
    [InlineData(9000, false)]
    public void Withdraw_OtherBanksShouldHaveChargeOfTwentyPesos(int amount, bool isOtherBank)
    {
        // Arrange
        var initialBalance = 9000;
        var accountNumber = 12345;
        var penalty = isOtherBank ? 20 : 0;
        BankAccount account = new BankAccount(accountNumber, initialBalance);

        // Act
        account.Withdraw(amount, isOtherBank);

        // Assert
        Assert.Equal(1000 - amount - penalty, account.GetBalance());
    }
}
