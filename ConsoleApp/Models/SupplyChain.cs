using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    private static IList<SupplyChain> _supplyChains = new List<SupplyChain>();
    public static IList<SupplyChain> SupplyChains {
        get => new List<SupplyChain>(_supplyChains);
        private set => _supplyChains = value;
    }
    public string Name { get; private set; }
    public int TransitionTime { get; private set; }

    public SupplyChain(string name, int transitionTime) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (transitionTime < 0)
            throw new ArgumentException("Transition time cannot be negative.");

        Name = name;
        TransitionTime = transitionTime;

        _supplyChains.Add(this);
    }
    
    public static void Serialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = JsonSerializer.Serialize(SupplyChains, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            SupplyChains = JsonSerializer.Deserialize<List<SupplyChain>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}