namespace ConsoleApp.models;

public class Dealer : Customer {
    public Dealer(string territory, IList<string> criminalRecord) : base() {
        SetDealerProperties(territory, criminalRecord);
    }
    
    public Dealer(Wholesaler wholesaler) : base(wholesaler) { }
}