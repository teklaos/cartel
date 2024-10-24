using System.Text.Json;

namespace ConsoleApp.models;

public class Equipment {
    public static IEnumerable<Equipment> _equipment { get; private set; } = new List<Equipment>();
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;

    public Equipment(string type, string name, string model) {
        this.Type = type;
        this.Name = name;
        this.Model = model;

        ArgumentNullException.ThrowIfNull(this);
        _equipment = _equipment.Append(this);
    }
    
    public static void Serialize() {
        string fileName = "Equipment.json";
        string jsonString = JsonSerializer.Serialize(_equipment, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Equipment.json";
        string jsonString = File.ReadAllText(fileName);
        _equipment = JsonSerializer.Deserialize<List<Equipment>>(jsonString) ?? new List<Equipment>();
    }
}