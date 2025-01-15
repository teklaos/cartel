namespace ConsoleApp.models;

public class Wholesaler : Customer {
    public Wholesaler(double commissionPercentage, int monthlyCustomers) : base() {
        SetWholesalerProperties(commissionPercentage, monthlyCustomers);
    }

    public Wholesaler(Dealer dealer) : base(dealer) { }
}