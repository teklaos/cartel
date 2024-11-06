using System.Text.Json;

namespace ConsoleApp.models;

public class Warehouse {
    public static IEnumerable<Warehouse> _warehouses { get; private set; } = new List<Warehouse>();
    public string Location { get; private set; }
    public int MaxCapacity { get; private set; }

    public Warehouse(string location, int maxCapacity) {
        Location = location;
        MaxCapacity = maxCapacity;
        AddWarehouse();
    }

    private void AddWarehouse() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Location, "Location");
            ArgumentOutOfRangeException.ThrowIfNegative(MaxCapacity, "Maximum capacity");
            ArgumentNullException.ThrowIfNull(this);
            _warehouses = _warehouses.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = JsonSerializer.Serialize(_warehouses, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _warehouses = JsonSerializer.Deserialize<List<Warehouse>>(jsonString) ?? new List<Warehouse>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}