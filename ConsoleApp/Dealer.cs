namespace ConsoleApp;

public class Dealer : Customer {
    public static IEnumerable<Dealer> _dealers { get; private set; } = new List<Dealer>();
    public string Territory { get; set; } = null!;
    public bool CriminalRecord { get; set; }

    public Dealer(string territory, bool criminalRecord):
    base() {
        this.Territory = territory;
        this.CriminalRecord = criminalRecord;
        _dealers = _dealers.Append(this);
    }
}