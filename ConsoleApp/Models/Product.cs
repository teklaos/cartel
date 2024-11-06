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
    public double PurityPercentage { get; private set; }
    public AddLevelAttribute AddictivenessLevel { get; private set; }

    public Product(string name, int pricePerPound, double purityPercentage, AddLevelAttribute addictivenessLevel) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (pricePerPound < 0)
            throw new ArgumentOutOfRangeException("Price per pound cannot be negative.");
        if (purityPercentage < 0)
            throw new ArgumentOutOfRangeException("Purity percentage cannot be negative.");
        
        Name = name;
        PricePerPound = pricePerPound;
        PurityPercentage = purityPercentage;
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