using System.Text.Json;

namespace ConsoleApp.models;

public class Citizen : CartelMember {
    private static IList<Citizen> _citizens = new List<Citizen>();
    public static IList<Citizen> Citizens {
        get => new List<Citizen>(_citizens);
        private set => _citizens = value;
    }
    public string Occupation { get; private set; }
    public int SecurityLevel { get; private set; }

    public Citizen(string name, int trustLevel, IList<string> rulesToFollow, string occupation, int securityLevel) :
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(occupation))
            throw new ArgumentException("Occupation cannot be null or whitespace.");
        if (securityLevel < 0)
            throw new ArgumentException("Security level cannot be negative.");

        Occupation = occupation;
        SecurityLevel = securityLevel;
        _citizens.Add(this);
    }


    public static new void Serialize() {
        string fileName = "Citizens.json";
        try {
            string jsonString = JsonSerializer.Serialize(Citizens, AppConfig.JsonSerializerOptions);
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