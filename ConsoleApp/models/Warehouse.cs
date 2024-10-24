using System.Text.Json;

namespace ConsoleApp.models;

public class Warehouse {
    public static IEnumerable<Warehouse> _warehouses { get; private set; } = new List<Warehouse>();
    public string Location { get; set; } = null!;
    public int MaxCapacity { get; set; }

    public Warehouse(string location, int maxCapacity) {
        this.Location = location;
        this.MaxCapacity = maxCapacity;

        ArgumentNullException.ThrowIfNull(this);
        _warehouses = _warehouses.Append(this);
    }
    
    
    public static void Serialize() {
        string fileName = "Warehouses.json";
        string jsonString = JsonSerializer.Serialize(_warehouses, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Warehouses.json";
        string jsonString = File.ReadAllText(fileName);
        _warehouses = JsonSerializer.Deserialize<List<Warehouse>>(jsonString) ?? new List<Warehouse>();
    }
}