using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    private static IList<Deliverer> _deliverers = new List<Deliverer>();
    public static IList<Deliverer> Deliverers {
        get => _deliverers.ToList();
        private set => _deliverers = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => _associatedProducts.ToList();
        private set => _associatedProducts = value;
    }

    private IList<Warehouse> _associatedWarehouses = new List<Warehouse>();
    public IList<Warehouse> AssociatedWarehouses {
        get => _associatedWarehouses.ToList();
        private set => _associatedWarehouses = value;
    }

    public Deliverer(string name, int trustLevel, IList<string> rulesToFollow, string occupation, int securityLevel) :
    base(name, trustLevel, rulesToFollow, occupation, securityLevel) =>
        _deliverers.Add(this);

    public Deliverer(string name, int trustLevel, IList<string> rulesToFollow, string position, string department) :
    base(name, trustLevel, rulesToFollow, position, department) =>
        _deliverers.Add(this);

    public static IList<string> GetNames() =>
        Deliverers.Select(deliverer => deliverer.Name).ToList();

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddDelivererInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
        product.RemoveDelivererInternally(this);
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        RemoveProduct(oldProduct);
        AddProduct(newProduct);
    }

    public void AddProductInternally(Product product) =>
        _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
    }

    public void AddWarehouse(Warehouse warehouse) {
        _associatedWarehouses.Add(warehouse);
        warehouse.AddDelivererInternally(this);
    }

    public void RemoveWarehouse(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Warehouse not found.");
        warehouse.RemoveDelivererInternally(this);
    }

    public void EditWarehouse(Warehouse oldWarehouse, Warehouse newWarehouse) {
        RemoveWarehouse(oldWarehouse);
        AddWarehouse(newWarehouse);
    }

    public void AddWarehouseInternally(Warehouse warehouse) =>
        _associatedWarehouses.Add(warehouse);

    public void RemoveWarehouseInternally(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Warehouse not found.");
    }

    public new static void Serialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Deliverers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Deliverers = JsonSerializer.Deserialize<List<Deliverer>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}