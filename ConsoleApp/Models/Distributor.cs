using System.Text.Json;

namespace ConsoleApp.models;

public class Distributor : CartelMember {
    public static IEnumerable<Distributor> Distributors { get; private set; } = new List<Distributor>();
    public int DealsMade { get; private set; }
    
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow, int dealsMade) :
    base(name, trustLevel, rulesToFollow) {
        if (dealsMade < 0)
            throw new ArgumentOutOfRangeException("Made deals cannot be negative.");

        DealsMade = dealsMade;
        Distributors = Distributors.Append(this);
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