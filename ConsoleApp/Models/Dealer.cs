public class Dealer : Customer
{
    public Dealer(string territory, IList<string> criminalRecord) : base(CustomerRole.Dealer)
    {
        SetDealerInfo(territory, criminalRecord);
    }
}