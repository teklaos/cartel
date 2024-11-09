using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    public static IEnumerable<Deliverer> Deliverers { get; private set; } = new List<Deliverer>();
    
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow) : 
    base(name, trustLevel, rulesToFollow) => Deliverers = Deliverers.Append(this);

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Deliverers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Deliverers = JsonSerializer.Deserialize<List<Deliverer>>(jsonString) ?? new List<Deliverer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}