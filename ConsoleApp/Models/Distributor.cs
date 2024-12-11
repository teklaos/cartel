using System.Text.Json;

namespace ConsoleApp.models;

public class Distributor : CartelMember {
    private static IList<Distributor> _distributors = new List<Distributor>();
    public static IList<Distributor> Distributors {
        get => new List<Distributor>(_distributors);
        private set => _distributors = value;
    }
    public int DealsMade { get; private set; }

    public Distributor(string name, int trustLevel, IList<string> rulesToFollow, int dealsMade) :
    base(name, trustLevel, rulesToFollow) {
        if (dealsMade < 0)
            throw new ArgumentException("Made deals cannot be negative.");

        DealsMade = dealsMade;
        _distributors.Add(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = JsonSerializer.Serialize(Distributors, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Distributors = JsonSerializer.Deserialize<List<Distributor>>(jsonString) ?? new List<Distributor>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}