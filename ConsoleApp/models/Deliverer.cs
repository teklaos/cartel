using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    public static IEnumerable<Deliverer> _deliverers { get; private set; } = new List<Deliverer>();
    
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        AddDeliverer();
    }

    private void AddDeliverer() {
        try {
            ArgumentNullException.ThrowIfNull(this);
            _deliverers = _deliverers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Deliverers.json";
            string jsonString = JsonSerializer.Serialize(_deliverers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Deliverers.json";
        string jsonString = File.ReadAllText(fileName);
        _deliverers = JsonSerializer.Deserialize<List<Deliverer>>(jsonString) ?? new List<Deliverer>();
    }
}