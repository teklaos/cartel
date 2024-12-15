using System.Text.Json;

namespace ConsoleApp.models;

public class Warehouse {
    private static IList<Warehouse> _warehouses = new List<Warehouse>();
    private static IList<Product> _associatedProducts = new List<Product>();
    
    
    public static IList<Warehouse> Warehouses {
        get => new List<Warehouse>(_warehouses);
        private set => _warehouses = value;
    }
    
    public static IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }
    public string Location { get; private set; }
    public int MaxCapacity { get; private set; }

    public Warehouse(string location, int maxCapacity) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.");
        if (maxCapacity < 0)
            throw new ArgumentException("Maximum capacity cannot be negative.");

        Location = location;
        MaxCapacity = maxCapacity;
        _warehouses.Add(this);
    }
    

    public void AddProductToWarehouse(Product product)
    {
        _associatedProducts.Add(product);
        Product.AttachWarehouseInternally(this);
    }
    
    public void RemoveProductFromWarehouse(Product product)
    {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found exception.");
        Product.RemoveWarehouseInternally(this);
    }
    
    public static void AddProductToWarehouseInternally(Product product) => _associatedProducts.Add(product);
    public static void RemoveProductFromWarehouseInternally(Product product)
    {
        if (!_associatedProducts.Remove(product))
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