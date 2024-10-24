using System.Text.Json;

namespace ConsoleApp.models;

public abstract class CartelMember {
    public static IEnumerable<CartelMember> _cartelMembers { get; private set; } = new List<CartelMember>();
    public string Name { get; set; } = null!;
    public int TrustLevel { get; set; }
    public IEnumerable<string> RulesToFollow { get; set; } = null!;

    public CartelMember(string name, int trustLevel, IEnumerable<string> rulesToFollow) {
        this.Name = name;
        this.TrustLevel = trustLevel;
        this.RulesToFollow = rulesToFollow;

        ArgumentNullException.ThrowIfNull(this);
        _cartelMembers = _cartelMembers.Append(this);
    }
    
    public static void Serialize() {
        string fileName = "CartelMembers.json";
        string jsonString = JsonSerializer.Serialize(_cartelMembers, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "CartelMembers.json";
        string jsonString = File.ReadAllText(fileName);
        _cartelMembers = JsonSerializer.Deserialize<List<CartelMember>>(jsonString) ?? new List<CartelMember>();
    }
}