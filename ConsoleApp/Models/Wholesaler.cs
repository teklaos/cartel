public class Wholesaler : Customer
{
    public Wholesaler(double commissionPercentage, int monthlyCustomers) : base()
    {
        SetWholesalerInfo(commissionPercentage, monthlyCustomers);
    }

    public Wholesaler(Dealer dealer) : base(dealer) { }
}