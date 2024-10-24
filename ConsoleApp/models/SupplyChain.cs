using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    public static IEnumerable<SupplyChain> _supplyChains { get; private set; } = new List<SupplyChain>();
    public string Name { get; set; } = null!;
    public int TransitionTime { get; set; } // In hours

    public SupplyChain(string name, int transitionTime) {
        this.Name = name;
        this.TransitionTime = transitionTime;

        ArgumentNullException.ThrowIfNull(this);
        _supplyChains = _supplyChains.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "SupplyChains.json";
        string jsonString = JsonSerializer.Serialize(_supplyChains, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "SupplyChains.json";
        string jsonString = File.ReadAllText(fileName);
        _supplyChains = JsonSerializer.Deserialize<List<SupplyChain>>(jsonString) ?? new List<SupplyChain>();
    }
}