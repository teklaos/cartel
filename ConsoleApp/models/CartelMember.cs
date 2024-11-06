using System.Text.Json;

namespace ConsoleApp.models;

public abstract class CartelMember {
    public static IEnumerable<CartelMember> _cartelMembers { get; private set; } = new List<CartelMember>();
    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IEnumerable<string> RulesToFollow { get; private set; }

    public CartelMember(string name, int trustLevel, IEnumerable<string> rulesToFollow) {
        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow;
        AddCartelMember();
    }

    private void AddCartelMember() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Name, "Name");
            ArgumentOutOfRangeException.ThrowIfNegative(TrustLevel, "Trust level");
            ArgumentNullException.ThrowIfNull(RulesToFollow, "Rules to follow");
            foreach (string rule in RulesToFollow) {
                ArgumentException.ThrowIfNullOrWhiteSpace(rule, "Rule");
            }
            ArgumentNullException.ThrowIfNull(this);
            _cartelMembers = _cartelMembers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static void Serialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = JsonSerializer.Serialize(_cartelMembers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _cartelMembers = JsonSerializer.Deserialize<List<CartelMember>>(jsonString) ?? new List<CartelMember>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}