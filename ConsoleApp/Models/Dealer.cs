public class Dealer : Customer
{
    public Dealer(string territory, IList<string> criminalRecord) : base()
    {
        SetDealerInfo(territory, criminalRecord);
    }
    public Dealer(Wholesaler wholesaler) : base(wholesaler) { }

}