using System.Text.Json;

namespace ConsoleApp.models;

public class Distributor : CartelMember {
    public static IEnumerable<Distributor> _distributors { get; private set; } = new List<Distributor>();
    public int DealsMade { get; private set; }
    
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow, int dealsMade):
    base(name, trustLevel, rulesToFollow) {
        if (dealsMade < 0)
            throw new ArgumentOutOfRangeException(nameof(DealsMade), "DealsMade cannot be < 0");
        DealsMade = dealsMade;
        _distributors = _distributors.Append(this);
    }

    private void AddDistributor() {
        try {
            if (DealsMade < 0)
                throw new ArgumentOutOfRangeException(nameof(DealsMade), "DealsMade cannot be < 0");
            _distributors = _distributors.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = JsonSerializer.Serialize(_distributors, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _distributors = JsonSerializer.Deserialize<List<Distributor>>(jsonString) ?? new List<Distributor>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}