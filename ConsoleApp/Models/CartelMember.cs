using System.Text.Json;

namespace ConsoleApp.models;

public abstract class CartelMember {
    private static IList<CartelMember> _cartelMembers = new List<CartelMember>();
    public static IList<CartelMember> CartelMembers {
        get => new List<CartelMember>(_cartelMembers);
        private set => _cartelMembers = value;
    }
    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IList<string> RulesToFollow { get; private set; }

    public CartelMember(string name, int trustLevel, IList<string> rulesToFollow) {
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
        _cartelMembers.Add(this);
    }

    public void Edit(string name, int trustLevel, params string[] rulesToFollow) {
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
        RulesToFollow = rulesToFollow.ToList();
    }

    public void Remove() {
        _cartelMembers.Remove(this);
    }

    public static void Serialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = JsonSerializer.Serialize(CartelMembers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "CartelMembers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            CartelMembers = JsonSerializer.Deserialize<List<CartelMember>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}