using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    public static IEnumerable<SupplyChain> _supplyChains { get; private set; } = new List<SupplyChain>();
    public string Name { get; private set; }
    public int TransitionTime { get; private set; }

    public SupplyChain(string name, int transitionTime) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));

        if (transitionTime < 0)
            throw new ArgumentOutOfRangeException(nameof(TransitionTime), "Transition time cannot be negative.");
        
        Name = name;
        TransitionTime = transitionTime;
        
        _supplyChains = _supplyChains.Append(this);
    }
    

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = JsonSerializer.Serialize(_supplyChains, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _supplyChains = JsonSerializer.Deserialize<List<SupplyChain>>(jsonString) ?? new List<SupplyChain>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}