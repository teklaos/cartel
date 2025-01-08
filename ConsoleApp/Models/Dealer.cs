using System.Text.Json;

namespace ConsoleApp.models;

public class Dealer : Customer {
    private static IList<Dealer> _dealers = new List<Dealer>();
    public static IList<Dealer> Dealers {
        get => new List<Dealer>(_dealers);
        private set => _dealers = value;
    }
    public string Territory { get; private set; }
    public IList<string>? CriminalRecord { get; private set; }

    public Dealer(string territory, IList<string> criminalRecord) :
    base() {
        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or whitespace.");

        if (criminalRecord != null) {
            foreach (string record in criminalRecord) {
                if (string.IsNullOrWhiteSpace(record)) {
                    throw new ArgumentException("Each record cannot be null or whitespace.");
                }
            }
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
        _dealers.Add(this);
    }
    
    public new static void Serialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Dealers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Dealers = JsonSerializer.Deserialize<List<Dealer>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}