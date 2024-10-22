namespace ConsoleApp;

public class Wholesaler : Customer {
    public int CommissionPercentage { get; set; }
    public int MonthlyCustomers { get; set; }

    public Wholesaler(int commissionPercentage, int monthlyCustomers):
    base() {
        this.CommissionPercentage = commissionPercentage;
        this.MonthlyCustomers = monthlyCustomers;
    }
}