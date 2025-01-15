public class Wholesaler : Customer
{
    public Wholesaler(double commissionPercentage, int monthlyCustomers) : base(CustomerRole.Wholesaler)
    {
        SetWholesalerInfo(commissionPercentage, monthlyCustomers);
    }

    public Wholesaler(Dealer dealer) : base(dealer) { }
}