namespace Project_Test_BankAccount;

public class Operation
{
    public int Balance { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public WayOperation WayOperation { get; set; }

    public Operation(int balnce, int amount, DateTime date, WayOperation wayOperation)
    {
        Balance = balnce;
        Amount = amount;
        Date = date;
        WayOperation = wayOperation;
    }
}
