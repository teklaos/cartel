using System.Text.Json;

namespace ConsoleApp.models;

public class Equipment {
    public static IEnumerable<Equipment> _equipment { get; private set; } = new List<Equipment>();
    public string Type { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }

    public Equipment(string type, string name, string model) {
        Type = type;
        Name = name;
        Model = model;
        AddEquipment();
    }

    private void AddEquipment() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Type, "Type");
            ArgumentException.ThrowIfNullOrWhiteSpace(Name, "Name");
            ArgumentException.ThrowIfNullOrWhiteSpace(Model, "Model");
            ArgumentNullException.ThrowIfNull(this);
            _equipment = _equipment.Append(this);
        } catch (Exception ex) {
            throw new ArgumentException(ex.Message);
        }
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static void Serialize() {
        string fileName = "Equipment.json";
        string jsonString = JsonSerializer.Serialize(_equipment, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Equipment.json";
        string jsonString = File.ReadAllText(fileName);
        _equipment = JsonSerializer.Deserialize<List<Equipment>>(jsonString) ?? new List<Equipment>();
    }
}