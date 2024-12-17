using System.Text.Json;

namespace ConsoleApp.models;

public class Warehouse {
    private static IList<Warehouse> _warehouses = new List<Warehouse>();
    public static IList<Warehouse> Warehouses {
        get => new List<Warehouse>(_warehouses);
        private set => _warehouses = value;
    }
    public string Location { get; private set; }
    public int MaxCapacity { get; private set; }

    private static IDictionary<Type, List<Product>> _associatedProducts 
        = new Dictionary<Type, List<Product>>();
    
    public static IDictionary<Type, List<Product>> AssociatedProducts {
        get => new Dictionary<Type, List<Product>>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    public Warehouse(string location, int maxCapacity) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.");
        if (maxCapacity < 0)
            throw new ArgumentException("Maximum capacity cannot be negative.");

        Location = location;
        MaxCapacity = maxCapacity;
        _warehouses.Add(this);
    }

    public void AddProduct(Product product) {
        _associatedProducts[GetType()].Add(product);
        Product.AddWarehouseInternally(this, GetType());
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts[GetType()].Remove(product))
            throw new Exception("Product not found exception.");
        Product.RemoveWarehouseInternally(this, GetType());
    }

    public static void AddProductInternally(Product product, Type type) => _associatedProducts[type].Add(product);
    public static void RemoveProductInternally(Product product, Type type) {
        if (!_associatedProducts[type].Remove(product))
            throw new Exception("Product not found exception.");
    }

    public static void Serialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = JsonSerializer.Serialize(Warehouses, AppConfig.JsonSerializerOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Warehouses = JsonSerializer.Deserialize<List<Warehouse>>(jsonString) ?? new List<Warehouse>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}