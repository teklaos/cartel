using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    private static IList<Deliverer> _deliverers = new List<Deliverer>();
    public static IList<Deliverer> Deliverers {
        get => new List<Deliverer>(_deliverers);
        private set => _deliverers = value;
    }

    public Deliverer(string name, int trustLevel, IList<string> rulesToFollow) :
    base(name, trustLevel, rulesToFollow) => _deliverers.Add(this);


    public static new void Serialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Deliverers, AppConfig.JsonSerializerOptions);
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