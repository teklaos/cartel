namespace ConsoleApp;

public class Dealer : Customer {
    public string Territory { get; set; } = null!;
    public bool CriminalRecord { get; set; }

    public Dealer(string territory, bool criminalRecord):
    base() {
        this.Territory = territory;
        this.CriminalRecord = criminalRecord;
    }
}