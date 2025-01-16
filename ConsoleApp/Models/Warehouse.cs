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

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    public IList<Distributor> _associatedDistributors = new List<Distributor>();
    public IList<Distributor> AssociatedDistributors {
        get => new List<Distributor>(_associatedDistributors);
        private set => _associatedDistributors = value;
    }

    private IList<Deliverer> _associatedDeliverers = new List<Deliverer>();
    public IList<Deliverer> AssociatedDeliverers {
        get => new List<Deliverer>(_associatedDeliverers);
        private set => _associatedDeliverers = value;
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

    public static Warehouse Add(string location, int maxCapacity) =>
        new(location, maxCapacity);

    public void Edit(string location, int maxCapacity) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.");
        if (maxCapacity < 0)
            throw new ArgumentException("Maximum capacity cannot be negative.");

        Location = location;
        MaxCapacity = maxCapacity;
    }

    public void Remove() {
        foreach (var product in _associatedProducts)
            product.RemoveWarehouseInternally(this);
        foreach (var distributor in _associatedDistributors)
            distributor.RemoveWarehouseInternally(this);
        foreach (var deliverer in _associatedDeliverers)
            deliverer.RemoveWarehouseInternally(this);
        _warehouses.Remove(this);
    }

    public void AssignDeliverer(Deliverer deliverer) =>
        AddDeliverer(deliverer);

    public string GetLocation() => Location;

    public static IList<Dictionary<string, string>> GetViewData() {
        return (List<Dictionary<string, string>>)Warehouses.Select(warehouse => new Dictionary<string, string> {
            { "Location", warehouse.Location },
            { "MaxCapacity", warehouse.MaxCapacity.ToString() }
        });
    }

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddWarehouseInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
        product.RemoveWarehouseInternally(this);
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

    public void AddDistributor(Distributor distributor) {
        _associatedDistributors.Add(distributor);
        distributor.AddWarehouseInternally(this);
    }

    public void RemoveDistributor(Distributor distributor) {
        if (!_associatedDistributors.Remove(distributor))
            throw new ArgumentException("Distributor not found");
        distributor.RemoveWarehouseInternally(this);
    }

    public void EditDistributor(Distributor oldDistributor, Distributor newDistributor) {
        RemoveDistributor(oldDistributor);
        AddDistributor(newDistributor);
    }

    public void AddDistributorInternally(Distributor distributor) =>
        _associatedDistributors.Add(distributor);

    public void RemoveDistributorInternally(Distributor distributor) {
        if (!_associatedDistributors.Remove(distributor))
            throw new ArgumentException("Distributor not found");
    }

    public void AddDeliverer(Deliverer deliverer) {
        _associatedDeliverers.Add(deliverer);
        deliverer.AddWarehouseInternally(this);
    }

    public void RemoveDeliverer(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
        deliverer.RemoveWarehouseInternally(this);
    }

    public void EditDeliverer(Deliverer oldDeliverer, Deliverer newDeliverer) {
        RemoveDeliverer(oldDeliverer);
        AddDeliverer(newDeliverer);
    }

    public void AddDelivererInternally(Deliverer deliverer) =>
        _associatedDeliverers.Add(deliverer);

    public void RemoveDelivererInternally(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
    }

    public static void Serialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = JsonSerializer.Serialize(Warehouses, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Warehouses.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Warehouses = JsonSerializer.Deserialize<List<Warehouse>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}