namespace ConsoleApp;

public class Wholesaler : Customer {
    public IEnumerable<Wholesaler> _wholesalers { get; private set; } = new List<Wholesaler>();
    public int CommissionPercentage { get; set; }
    public int MonthlyCustomers { get; set; }

    public Wholesaler(int commissionPercentage, int monthlyCustomers):
    base() {
        this.CommissionPercentage = commissionPercentage;
        this.MonthlyCustomers = monthlyCustomers;
        _wholesalers = _wholesalers.Append(this);
    }
}