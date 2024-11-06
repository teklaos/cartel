using System.Text.Json;

namespace ConsoleApp.models;

public class Official : CartelMember {
    public static IEnumerable<Official> _officials { get; private set; } = new List<Official>();
    public string Position { get; private set; }
    public string Department { get; private set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, string position, string department):
    base(name, trustLevel, rulesToFollow) {
        Position = position;
        Department = department;
        AddOfficial();
    }

    private void AddOfficial() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Position, "Position");
            ArgumentException.ThrowIfNullOrWhiteSpace(Department, "Department");
            ArgumentNullException.ThrowIfNull(this);
            _officials = _officials.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Officials.json";
            string jsonString = JsonSerializer.Serialize(_officials, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Officials.json";
        string jsonString = File.ReadAllText(fileName);
        _officials = JsonSerializer.Deserialize<List<Official>>(jsonString) ?? new List<Official>();
    }
}   