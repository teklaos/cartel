using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public abstract class CartelMember : ICitizen, IOfficial {
    private static IList<CartelMember> _cartelMembers = new List<CartelMember>();
    public static IList<CartelMember> CartelMembers {
        get => _cartelMembers.ToList();
        private set => _cartelMembers = value;
    }

    private static IList<CartelMember> _citizens = new List<CartelMember>();
    public static IList<CartelMember> Citizens {
        get => _citizens.ToList();
        private set => _citizens = value;
    }

    private static IList<CartelMember> _officials = new List<CartelMember>();
    public static IList<CartelMember> Officials {
        get => _officials.ToList();
        private set => _officials = value;
    }

    public string Name { get; private set; }
    public int TrustLevel { get; private set; }
    public IList<string> RulesToFollow { get; private set; }
    public string? Occupation { get; private set; } = null!;
    public int? SecurityLevel { get; private set; } = null!;
    public string? Position { get; private set; } = null!;
    public string? Department { get; private set; } = null!;

    public CartelMember(
        string name, int trustLevel, IList<string> rulesToFollow,
        string occupation, int securityLevel
    ) {
        ValidateCartelMemberProperties(name, trustLevel, rulesToFollow);
        ValidateCitizenProperties(occupation, securityLevel);

        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow;
        Occupation = occupation;
        SecurityLevel = securityLevel;
        _cartelMembers.Add(this);
        _citizens.Add(this);
    }

    public CartelMember(
            string name, int trustLevel, IList<string> rulesToFollow,
            string position, string department
        ) {
        ValidateCartelMemberProperties(name, trustLevel, rulesToFollow);
        ValidateOfficialProperties(position, department);

        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow;
        Position = position;
        Department = department;
        _cartelMembers.Add(this);
        _officials.Add(this);
    }

    public void Edit(string name, int trustLevel, params string[] rulesToFollow) {
        ValidateCartelMemberProperties(name, trustLevel, rulesToFollow);
        Name = name;
        TrustLevel = trustLevel;
        RulesToFollow = rulesToFollow.ToList();
    }

    public void Edit(string occupation, int securityLevel) {
        ValidateCitizenProperties(occupation, securityLevel);
        Occupation = occupation;
        SecurityLevel = securityLevel;
    }

    public void Edit(string position, string department) {
        ValidateOfficialProperties(position, department);
        Position = position;
        Department = department;
    }

    public void Remove() {
        _cartelMembers.Remove(this);
        _citizens.Remove(this);
        _officials.Remove(this);
    }

    protected void SetCitizenProperties(string occupation, int securityLevel) {
        ValidateCitizenProperties(occupation, securityLevel);
        Occupation = occupation;
        SecurityLevel = securityLevel;
        _citizens.Add(this);
    }

    protected void SetOfficialProperties(string position, string department) {
        ValidateOfficialProperties(position, department);
        Position = position;
        Department = department;
        _officials.Add(this);
    }

    private static void ValidateCartelMemberProperties(string name, int trustLevel, IList<string> rulesToFollow) {
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
    }

    private static void ValidateCitizenProperties(string occupation, int securityLevel) {
        if (string.IsNullOrWhiteSpace(occupation))
            throw new ArgumentException("Occupation cannot be null or whitespace.");
        if (securityLevel < 0)
            throw new ArgumentException("Security level cannot be negative.");
    }

    private static void ValidateOfficialProperties(string position, string department) {
        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be null or whitespace.");
    }

    public static void Serialize() {
        IList<string> fileNames = ["CartelMembers.json", "Citizens.json", "Officials.json"];
        IList<object> lists = [CartelMembers, Citizens, Officials];
        for (int i = 0; i < fileNames.Count; i++) {
            try {
                string jsonString = JsonSerializer.Serialize(lists[i], AppConfig.JsonOptions);
                File.WriteAllText(fileNames[i], jsonString);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void Deserialize() {
        IList<string> fileNames = ["CartelMembers.json", "Citizens.json", "Officials.json"];
        IList<object> lists = [CartelMembers, Citizens, Officials];
        for (int i = 0; i < fileNames.Count; i++) {
            try {
                string jsonString = File.ReadAllText(fileNames[i]);
                lists[i] = JsonSerializer.Deserialize<List<CartelMember>>(jsonString, AppConfig.JsonOptions) ?? [];
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}