using System.Text.Json;

namespace ConsoleApp.models;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    public static IEnumerable<Product> _products { get; private set; } = new List<Product>(); 
    public string Name { get; private set; }
    public int PricePerPound { get; private set; }
    private readonly int ChemistPoundsCooked = 2000;
    public double PurityPercentage {
        get {
            double randomDouble = 0.8565;
            if (ChemistPoundsCooked > 2000)
                return 95 + Math.Round(randomDouble * 5, 2);
            else if (ChemistPoundsCooked > 1000)
                return 85 + Math.Round(randomDouble * 10, 2);
            else if (ChemistPoundsCooked > 0)
                return 70 + Math.Round(randomDouble * 15, 2);
            else
                return 50 + Math.Round(randomDouble * 20, 2);
        }
    }
    public AddLevelAttribute AddictivenessLevel { get; private set; }

    public Product(string name, int pricePerPound, AddLevelAttribute addictivenessLevel) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (pricePerPound < 0)
            throw new ArgumentOutOfRangeException("Price per pound cannot be negative.");
        
        Name = name;
        PricePerPound = pricePerPound;
        AddictivenessLevel = addictivenessLevel;
        _products = _products.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Products.json";
        try {
            string jsonString = JsonSerializer.Serialize(_products, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Products.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _products = JsonSerializer.Deserialize<List<Product>>(jsonString) ?? new List<Product>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}