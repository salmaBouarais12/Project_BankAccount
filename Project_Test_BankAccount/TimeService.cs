namespace Project_Test_BankAccount;

public class TimeService : ITimeService
{
    public DateTime GetToday() => DateTime.Today;
}