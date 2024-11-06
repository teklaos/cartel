namespace ConsoleApp.models;

public class Dealer : Customer {
    public static IEnumerable<Dealer> _dealers { get; private set; } = new List<Dealer>();
    public string Territory { get; private set; }
    public IEnumerable<string> CriminalRecord { get; private set; }

    public Dealer(string territory, IEnumerable<string> criminalRecord):
    base() {
        Territory = territory;
        CriminalRecord = criminalRecord;
        AddDealer();
    }

    private void AddDealer() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Territory, "Territory");
            foreach (string record in CriminalRecord) {
                ArgumentException.ThrowIfNullOrWhiteSpace(record, "Record");
            }
            ArgumentNullException.ThrowIfNull(this);
            _dealers = _dealers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}