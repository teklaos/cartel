using System.Text.Json;

namespace ConsoleApp.models;

public class Official : CartelMember {
    private static IList<Official> _officials = new List<Official>();
    public static IList<Official> Officials {
        get => new List<Official>(_officials);
        private set => _officials = value;
    }
    public string Position { get; private set; }
    public string Department { get; private set; }

    public Official(string name, int trustLevel, IList<string> rulesToFollow, string position, string department) :
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be null or whitespace.");

        Position = position;
        Department = department;
        _officials.Add(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Officials.json";
        try {
            string jsonString = JsonSerializer.Serialize(Officials, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Officials.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Officials = JsonSerializer.Deserialize<List<Official>>(jsonString) ?? new List<Official>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}