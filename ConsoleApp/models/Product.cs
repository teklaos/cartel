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
        Name = name;
        PricePerPound = pricePerPound;
        PurityPercentage = purityPercentage;
        AddictivenessLevel = addictivenessLevel;
        AddProduct();
    }

    private void AddProduct() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Name, "Name");
            ArgumentOutOfRangeException.ThrowIfNegative(PricePerPound, "Price per pound");
            ArgumentOutOfRangeException.ThrowIfNegative(PurityPercentage, "Purity percentage");
            ArgumentNullException.ThrowIfNull(AddictivenessLevel, "Addictiveness level");
            ArgumentNullException.ThrowIfNull(this);
            _products = _products.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
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