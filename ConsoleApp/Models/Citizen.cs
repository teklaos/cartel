using System.Text.Json;

namespace ConsoleApp.models;

public class Citizen : CartelMember {
    private static IEnumerable<Citizen> _citizens = new List<Citizen>();
    public static IEnumerable<Citizen> Citizens {
        get => new List<Citizen>(_citizens);
        private set => _citizens = value;
    }
    public string Occupation { get; private set; }
    public int SecurityLevel { get; private set; }

    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow, string occupation, int securityLevel) :
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(occupation))
            throw new ArgumentException("Occupation cannot be null or whitespace.");
        if (securityLevel < 0)
            throw new ArgumentException("Security level cannot be negative.");

        Occupation = occupation;
        SecurityLevel = securityLevel;
        Citizens = Citizens.Append(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Citizens.json";
        try {
            string jsonString = JsonSerializer.Serialize(Citizens, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Citizens.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Citizens = JsonSerializer.Deserialize<List<Citizen>>(jsonString) ?? new List<Citizen>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}