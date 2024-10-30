using System.Text.Json;

namespace ConsoleApp.models;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    public static IEnumerable<Product> _products { get; private set; } = new List<Product>(); 
    public string Name { get; set; } = null!;
    public int PricePerPound { get; set; }
    public double PurityPercentage { get; set; }
    public AddLevelAttribute AddictivenessLevel { get; set; }

    public Product(string name, int pricePerPound, double purityPercentage, AddLevelAttribute addictivenessLevel) {
        this.Name = name;
        this.PricePerPound = pricePerPound;
        this.PurityPercentage = purityPercentage;
        this.AddictivenessLevel = addictivenessLevel;

        ArgumentNullException.ThrowIfNull(this);
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