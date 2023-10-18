using NFluent;

namespace Project_Test_BankAccount;

public class BankAccountTest
{
    [Fact]
    public void Should_Have_1000_inBankAcount_When_Deposit_500()
    {
        //arrange
        var amount = 500;
        var operationDateDeposit = new DateTime(2023, 08, 03);
        var bankAccount = new BankAccount(amount, new DateTime(2023, 08, 02));

        // Act
        bankAccount.Desposit(amount, operationDateDeposit);

        //Assert
        Check.That(bankAccount.Operations.Last().Balance).Is(1000);
        Check.That(bankAccount.Operations.Last().Amount).Is(amount);
        Check.That(bankAccount.Operations.Last().Date).Is(operationDateDeposit);
    }

    [Fact]
    public void Should_Have_300_When_BankAccount_Is_100_And_Deposit_200()
    {
        // Arrange
        var bankAccount = new BankAccount(100, new DateTime(2023, 08, 02));

        // Act
        bankAccount.Desposit(200, new DateTime(2023, 08, 03));

        // Assert
        Check.That(bankAccount.Operations.Last().Balance).Is(300);
        Check.That(bankAccount.Operations.Last().Amount).Is(200);
        Check.That(bankAccount.Operations.Last().Date).Is(new DateTime(2023, 08, 03));
    }

    [Fact]
    public void Should_Create_BankAccount()
    {
        // Arrange
        var amount = 500;

        // Act
        var bankAccount = new BankAccount(amount, new DateTime(2023, 08, 02));

        // Assert
        Check.That(bankAccount.Operations.Last().Balance).Is(amount);
        Check.That(bankAccount.Operations.Last().Amount).Is(amount);
        Check.That(bankAccount.Operations.Last().Date).Is(new DateTime(2023, 08, 02));
    }

    [Fact]
    public void Should_Have_0_When_BankAccount_Is_0_And_Deposit_0()
    {
        // Arrange
        var amount = 0;
        var bankAccount = new BankAccount(amount, new DateTime(2023, 08, 02));

        // Act
        bankAccount.Desposit(amount, new DateTime(2023, 08, 05));

        //Assert
        Check.That(bankAccount.Operations.Last().Balance).Is(amount);
        Check.That(bankAccount.Operations.Last().Amount).Is(amount);
        Check.That(bankAccount.Operations.Last().Date).Is(new DateTime(2023, 08, 05));
    }

    [Fact]
    public void Should_Have_300_From_BankAccount_When_Withdraw_200()
    {
        // Arrange
        var account = 500;
        var amount = 200;
        var bankAccount = new BankAccount(account, new DateTime(2023, 08, 05));

        // Act
        bankAccount.Withdraw(amount, new DateTime(2023, 08, 06));

        //Assert
        Check.That(bankAccount.Operations.Last().Balance).Is(300);
        Check.That(bankAccount.Operations.Last().Amount).Is(amount);
        Check.That(bankAccount.Operations.Last().Date).Is(new DateTime(2023, 08, 06));
    }

    [Fact]
    public void Should_Print_Statement_When_One_Operation()
    {
        // Arrange
        var bankAccount = new BankAccount(100, new DateTime(2023, 08, 02));

        // Act
        var result = bankAccount.PrintStatement();

        // Assert
        Check.That(result).ContainsExactly("02/08/2023 - +100 - 100");
    }

    [Fact]
    public void Should_Print_Statement_When_Two_Operations()
    {
        // Arrange
        var bankAccount = new BankAccount(100, new DateTime(2023, 08, 02));
        bankAccount.Desposit(200, new DateTime(2023, 08, 03));

        // Act
        var result = bankAccount.PrintStatement();

        // Assert
        Check.That(result).ContainsExactly("02/08/2023 - +100 - 100", "03/08/2023 - +200 - 300");
    }

    [Fact]
    public void Should_PrintStatement_When_WeWithdraw()
    {
        // Arrange
        var bankAccount = new BankAccount(300, new DateTime(2023, 08, 02));
        bankAccount.Withdraw(100, new DateTime(2023, 08, 03));

        // Act
        var result = bankAccount.PrintStatement();

        // Assert
        Check.That(result).ContainsExactly("02/08/2023 - +300 - 300","03/08/2023 - -100 - 200");
    }
}