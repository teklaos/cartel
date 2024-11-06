using System.Text.Json;

namespace ConsoleApp.models;

public class Dealer : Customer {
    public static IEnumerable<Dealer> _dealers { get; private set; } = new List<Dealer>();
    public string Territory { get; private set; }
    public IEnumerable<string>? CriminalRecord { get; private set; }

    public Dealer(string territory, IEnumerable<string> criminalRecord):
    base() {
        Territory = territory;
        CriminalRecord = criminalRecord;
        AddDealer();
    }

    private void AddDealer() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Territory, "Territory");
            if (CriminalRecord != null) {
                foreach (string record in CriminalRecord) {
                    ArgumentException.ThrowIfNullOrWhiteSpace(record, "Record");
                }
            }
            ArgumentNullException.ThrowIfNull(this);
            _dealers = _dealers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static new void Serialize() {
        string fileName = "Dealers.json";
        string jsonString = JsonSerializer.Serialize(_dealers, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Dealers.json";
        string jsonString = File.ReadAllText(fileName);
        _dealers = JsonSerializer.Deserialize<List<Dealer>>(jsonString) ?? new List<Dealer>();
    }
}