using System.Text.Json;

namespace ConsoleApp.models;

public class Laboratory {
    public static IEnumerable<Laboratory> _laboratories { get; private set; } = new List<Laboratory>();
    public string Location { get; set; } = null!;
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        this.Location = location;

        ArgumentNullException.ThrowIfNull(this);
        _laboratories = _laboratories.Append(this);
    }
    
    public static void Serialize() {
        string fileName = "Laboratories.json";
        string jsonString = JsonSerializer.Serialize(_laboratories, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Laboratories.json";
        string jsonString = File.ReadAllText(fileName);
        _laboratories = JsonSerializer.Deserialize<List<Laboratory>>(jsonString) ?? new List<Laboratory>();
    }
}