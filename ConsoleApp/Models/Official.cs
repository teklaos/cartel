using System.Text.Json;

namespace ConsoleApp.models;

public class Official : CartelMember {
    public static IEnumerable<Official> _officials { get; private set; } = new List<Official>();
    public string Position { get; private set; }
    public string Department { get; private set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, string position, string department) : 
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be null or whitespace.");

        Position = position;
        Department = department;
        _officials = _officials.Append(this);
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Officials.json";
        try {
            string jsonString = JsonSerializer.Serialize(_officials, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Officials.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _officials = JsonSerializer.Deserialize<List<Official>>(jsonString) ?? new List<Official>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}   