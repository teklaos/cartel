using System.Text.Json;

namespace ConsoleApp.models;

public class Dealer : Customer {
    public static IEnumerable<Dealer> Dealers { get; private set; } = new List<Dealer>();
    public string Territory { get; private set; }
    public IEnumerable<string>? CriminalRecord { get; private set; }

    public Dealer(string territory, IEnumerable<string> criminalRecord) : 
    base() {
        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or whitespace.");

        foreach (string record in criminalRecord) {
            if (string.IsNullOrWhiteSpace(record)) {
                throw new ArgumentException("Each record cannot be null or whitespace.");
            }
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
        Dealers = Dealers.Append(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    
    public static new void Serialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Dealers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Dealers = JsonSerializer.Deserialize<List<Dealer>>(jsonString) ?? new List<Dealer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}