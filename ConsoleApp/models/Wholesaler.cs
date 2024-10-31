namespace ConsoleApp.models;

public class Wholesaler : Customer {
    public IEnumerable<Wholesaler> _wholesalers { get; private set; } = new List<Wholesaler>();
    public double CommissionPercentage { get; private set; }
    public int MonthlyCustomers { get; private set; }

    public Wholesaler(double commissionPercentage, int monthlyCustomers):
    base() {
        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        AddWholesaler();
    }

    private void AddWholesaler() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(CommissionPercentage, "Commission percentage");
            ArgumentOutOfRangeException.ThrowIfNegative(MonthlyCustomers, "Monthly customers");
            ArgumentNullException.ThrowIfNull(this);
            _wholesalers = _wholesalers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}