namespace ConsoleApp.Abstractions.Interfaces;

public interface IWholesaler
{
    double CommissionPercentage { get; }
    int MonthlyCustomers { get; }
}