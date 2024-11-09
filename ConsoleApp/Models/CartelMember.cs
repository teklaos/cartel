using System.Text.Json;

namespace ConsoleApp.models;

public abstract class CartelMember {
    public static IEnumerable<CartelMember> CartelMembers { get; private set; } = new List<CartelMember>();
    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IEnumerable<string> RulesToFollow { get; private set; }

    public CartelMember(string name, int trustLevel, IEnumerable<string> rulesToFollow) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (trustLevel < 0)
            throw new ArgumentException("Trust level cannot be negative.");
        if (rulesToFollow == null)
            throw new ArgumentException("Rules to follow cannot be null.");

        foreach (string rule in rulesToFollow) {
            if (string.IsNullOrWhiteSpace(rule)) {
                throw new ArgumentException("Each rule cannot be null or whitespace.");
            }
        }

        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow;
        CartelMembers = CartelMembers.Append(this);
    }
    
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    
    public static void Serialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = JsonSerializer.Serialize(CartelMembers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            CartelMembers = JsonSerializer.Deserialize<List<CartelMember>>(jsonString) ?? new List<CartelMember>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}