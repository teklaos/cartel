using System.Text.Json;

namespace ConsoleApp.models;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product
{
    private static IList<Product> _products = new List<Product>();
    private static IList<Warehouse> _connectedWarehouses = new List<Warehouse>();

    public static IList<Product> Products {
        get => new List<Product>(_products);
        private set => _products = value;
    }
    public static IList<Warehouse> ConnectedWarehouses {
        get => new List<Warehouse>(_connectedWarehouses);
        private set => _connectedWarehouses = value;
    }
    public string Name { get; private set; }
    public int PricePerPound { get; private set; }
    private readonly int _poundsCooked = 2000;
    public double PurityPercentage {
        get {
            double randomDouble = 0.8565;
            if (_poundsCooked > 2000)
                return 95 + Math.Round(randomDouble * 5, 2);
            else if (_poundsCooked > 1000)
                return 85 + Math.Round(randomDouble * 10, 2);
            else if (_poundsCooked > 0)
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
            throw new ArgumentException("Price per pound cannot be negative.");
        
        Name = name;
        PricePerPound = pricePerPound;
        AddictivenessLevel = addictivenessLevel;
        Products.Add(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    
    public void AddProductStoredIn(Warehouse warehouse)
    {
        _connectedWarehouses.Add(warehouse);
        Warehouse.AddProductToWarehouseInternally(this);
    }
    
    public void RemoveProductStoredIn(Warehouse warehouse)
    {
        _connectedWarehouses.Remove(warehouse);
        Warehouse.RemoveProductFromWarehouseInternally(this);
    }
    
    public static void AttachWarehouseInternally(Warehouse warehouse) => _connectedWarehouses.Add(warehouse);

    public static void RemoveWarehouseInternally(Warehouse warehouse)
    {
        if (!_connectedWarehouses.Remove(warehouse))
            throw new Exception("Warehouse not found.");
    }
    
    public static void Serialize() {
        string fileName = "Products.json";
        try {
            string jsonString = JsonSerializer.Serialize(Products, AppConfig.JsonSerializerOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Products.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Products = JsonSerializer.Deserialize<List<Product>>(jsonString) ?? new List<Product>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}