using System.Text.Json;

namespace ConsoleApp.models;

public class Laboratory {
    public static IEnumerable<Laboratory> _laboratories { get; private set; } = new List<Laboratory>();
    public string Location { get; private set; }
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.", nameof(Location));
        Location = location;

        _laboratories = _laboratories.Append(this);
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Laboratories.json";
        try {
            string jsonString = JsonSerializer.Serialize(_laboratories, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Laboratories.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _laboratories = JsonSerializer.Deserialize<List<Laboratory>>(jsonString) ?? new List<Laboratory>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}