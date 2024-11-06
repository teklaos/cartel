using System.Text.Json;

namespace ConsoleApp.models;

public abstract class CartelMember {
    public static IEnumerable<CartelMember> CartelMembers { get; private set; } = new List<CartelMember>();
    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IEnumerable<string> RulesToFollow { get; private set; }

    protected CartelMember(string name, int trustLevel, IEnumerable<string> rulesToFollow) {
        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow;
        AddCartelMember();
    }
    
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };
    
    private void AddCartelMember() {
        try {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Name cannot be null or whitespace");

            if (TrustLevel < 0)
                throw new ArgumentException("Trust level cannot be negative");

            if (RulesToFollow == null)
                throw new ArgumentException( "Rules to follow cannot be null");

            foreach (string rule in RulesToFollow) {
                if (string.IsNullOrWhiteSpace(rule))
                    throw new ArgumentException("Each rule must be a non-empty string", nameof(rule));
            }
            
            CartelMembers = CartelMembers.Append(this);

        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    

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