using System.Text.Json;

namespace ConsoleApp.models;

public class Equipment {
    public static IEnumerable<Equipment> _equipment { get; private set; } = new List<Equipment>();
    public string Type { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }

    public Equipment(string type, string name, string model) {
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("Type cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model cannot be null or whitespace.");

        Type = type;
        Name = name;
        Model = model;
        _equipment = _equipment.Append(this);
    }
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static void Serialize() {
        string fileName = "Equipment.json";
        try {
            string jsonString = JsonSerializer.Serialize(_equipment, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Equipment.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _equipment = JsonSerializer.Deserialize<List<Equipment>>(jsonString) ?? new List<Equipment>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}