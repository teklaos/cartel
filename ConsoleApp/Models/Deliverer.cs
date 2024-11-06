using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    public static IEnumerable<Deliverer> _deliverers { get; private set; } = new List<Deliverer>();
    
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow) : 
    base(name, trustLevel, rulesToFollow) => _deliverers = _deliverers.Append(this);

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = JsonSerializer.Serialize(_deliverers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _deliverers = JsonSerializer.Deserialize<List<Deliverer>>(jsonString) ?? new List<Deliverer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}