using System.Text.Json;

namespace ConsoleApp.models;

public class Dealer : Customer {
    public static IEnumerable<Dealer> _dealers { get; private set; } = new List<Dealer>();
    public string Territory { get; private set; }
    public IEnumerable<string>? CriminalRecord { get; private set; }

    public Dealer(string territory, IEnumerable<string> criminalRecord) :
        base()
    {
        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be empty");
        Territory = territory;
        CriminalRecord = criminalRecord;

        foreach (string record in CriminalRecord)
        {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Record cannot be empty");
        }

        _dealers = _dealers.Append(this);
    }


    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static new void Serialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = JsonSerializer.Serialize(_dealers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Dealers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _dealers = JsonSerializer.Deserialize<List<Dealer>>(jsonString) ?? new List<Dealer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}