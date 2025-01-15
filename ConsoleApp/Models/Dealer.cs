public class Dealer : Customer
{
    public Dealer(string territory, IList<string> criminalRecord) : base(CustomerRole.Dealer)
    {
        SetDealerInfo(territory, criminalRecord);
    }
    public Dealer(Wholesaler wholesaler) : base(wholesaler) { }

}