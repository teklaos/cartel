using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public abstract class CartelMember : ICitizen, IOfficial {
    private static IList<CartelMember> _cartelMembers = new List<CartelMember>();
    public static IList<CartelMember> CartelMembers {
        get => new List<CartelMember>(_cartelMembers);
        private set => _cartelMembers = value;
    }

    protected static IList<CartelMember> _citizens = new List<CartelMember>();
    public static IList<CartelMember> Citizens {
        get => new List<CartelMember>(_citizens);
        private set => _citizens = value;
    }

    protected static IList<CartelMember> _officials = new List<CartelMember>();
    public static IList<CartelMember> Officials {
        get => new List<CartelMember>(_officials);
        private set => _officials = value;
    }

    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IList<string> RulesToFollow { get; private set; }
    public string? Occupation { get; private set; } = null!;
    public int? SecurityLevel { get; private set; } = null!;
    public string? Position { get; private set; } = null!;
    public string? Department { get; private set; } = null!;

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
        _citizens.Remove(this);
        _officials.Remove(this);
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