namespace Project_Test_BankAccount;

public class BankAccount
{
    public IList<Operation> Operations { get; set; }

    public BankAccount(int bankAccount, DateTime operationDate)
    {
        Operations = new List<Operation>();
        var initOperation = new Operation(bankAccount, bankAccount, operationDate, WayOperation.Add);
        Operations.Add(initOperation);
    }

    public void Desposit(int amount, DateTime operationDate)
    {
        var balance = Operations.Last().Balance;
        var operation = new Operation(balance + amount, amount, operationDate, WayOperation.Add);
        Operations.Add(operation);
    }

    public void Withdraw(int amount, DateTime operationDate)
    {
        var balance = Operations.Last().Balance;
        var operation = new Operation(balance - amount, amount, operationDate, WayOperation.Withdraw);
        Operations.Add(operation);
    }

    public IEnumerable<string> PrintStatement()
    {
        return Operations.Select(op =>
        {
            var way = op.WayOperation == WayOperation.Add ? "+" : "-";
            return $"{op.Date:dd/MM/yyyy} - {way}{op.Amount} - {op.Balance}";
        });
     }
}