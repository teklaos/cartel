using System.Text.Json;

namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public static IEnumerable<Citizen> _citizens { get; private set; } = new List<Citizen>();
    public string Occupation { get; private set; }
    public int SecurityLevel { get; private set; }
    
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow, string occupation, int securityLevel):
    base(name, trustLevel, rulesToFollow) {
        Occupation = occupation;
        SecurityLevel = securityLevel;
        AddCitizen();
    }

    private void AddCitizen() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Occupation, "Occupation");
            ArgumentOutOfRangeException.ThrowIfNegative(SecurityLevel, "Security level");
            ArgumentNullException.ThrowIfNull(this);
            _citizens = _citizens.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Citizens.json";
            string jsonString = JsonSerializer.Serialize(_citizens, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Citizens.json";
        string jsonString = File.ReadAllText(fileName);
        _citizens = JsonSerializer.Deserialize<List<Citizen>>(jsonString) ?? new List<Citizen>();
    }
}