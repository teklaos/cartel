using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    public static IEnumerable<SupplyChain> _supplyChains { get; private set; } = new List<SupplyChain>();
    public string Name { get; private set; }
    public int TransitionTime { get; private set; }

    public SupplyChain(string name, int transitionTime) {
        Name = name;
        TransitionTime = transitionTime;
        AddSupplyChain();
    }

    private void AddSupplyChain() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Name, "Name");
            ArgumentOutOfRangeException.ThrowIfNegative(TransitionTime, "Transition time");
            ArgumentNullException.ThrowIfNull(this);
            _supplyChains = _supplyChains.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
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