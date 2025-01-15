namespace ConsoleApp.Abstractions.Interfaces;

public interface IWholesaler {
    public double? CommissionPercentage { get; }
    public int? MonthlyCustomers { get; }
}