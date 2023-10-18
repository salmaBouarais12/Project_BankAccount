using NFluent;

namespace Project_Test_BankAccount;

public class OperationTest
{
    [Fact]
    public void Should_Instanciate_Operation()
    {
        //arrange
        var balance = 200;
        var amount = 100;
        var dateOperation = new DateTime(2023, 08, 02);
        var wayOperation = WayOperation.Add;

        // Act
        var operation = new Operation(balance, amount, dateOperation, wayOperation);

        //Assert
        Check.That(operation.Balance).Is(balance);
        Check.That(operation.Amount).Is(amount);
        Check.That(operation.Date).Is(dateOperation);
        Check.That(operation.WayOperation).Is(wayOperation);
    }
}
