using System.Text.Json;

namespace ConsoleApp.models;

public class Laboratory {
    public static IEnumerable<Laboratory> _laboratories { get; private set; } = new List<Laboratory>();
    public string Location { get; private set; }
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        Location = location;
        AddLaboratory();
    }

    private void AddLaboratory() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Location, "Location");
            ArgumentNullException.ThrowIfNull(this);
            _laboratories = _laboratories.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Laboratories.json";
        string jsonString = JsonSerializer.Serialize(_laboratories, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Laboratories.json";
        string jsonString = File.ReadAllText(fileName);
        _laboratories = JsonSerializer.Deserialize<List<Laboratory>>(jsonString) ?? new List<Laboratory>();
    }
}