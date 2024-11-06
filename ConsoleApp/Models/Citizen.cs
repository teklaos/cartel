using System.Text.Json;

namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public static IEnumerable<Citizen> _citizens { get; private set; } = new List<Citizen>();
    public string Occupation { get; private set; }
    public int SecurityLevel { get; private set; }
    
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow, string occupation, int securityLevel):
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(occupation))
            throw new ArgumentException("Occupation cannot be null or whitespace.");
        if (securityLevel < 0)
            throw new ArgumentException("Security level cannot be negative.");
        
        Occupation = occupation;
        SecurityLevel = securityLevel;
        _citizens = _citizens.Append(this);
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Citizens.json";
        try {
            string jsonString = JsonSerializer.Serialize(_citizens, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Citizens.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _citizens = JsonSerializer.Deserialize<List<Citizen>>(jsonString) ?? new List<Citizen>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}