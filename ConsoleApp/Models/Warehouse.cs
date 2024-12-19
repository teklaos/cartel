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
    public IList<Distributor> AssociatedDistibutors {
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

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddWarehouseInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
        product.RemoveWarehouseInternally(this);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        if (_associatedProducts.Contains(oldProduct)) {
            RemoveProduct(oldProduct);  
        } else {
            throw new ArgumentException("Old product not found.");
        }
        AddProduct(newProduct);  
    }

    public void AddDistributor(Distributor distributor) {
        _associatedDistributors.Add(distributor);
        distributor.AddWarehouseInternally(this);
    }

    public void RemoveDistributor(Distributor distributor) {
        if(!_associatedDistributors.Remove(distributor))
            throw new ArgumentException("Distributor not found");
        distributor.RemoveWarehouseInternally(this);
    }
    public void AddDistributorInternally(Distributor distributor) => _associatedDistributors.Add(distributor);

    public void RemoveDistributorInternally(Distributor distributor) {
        if(!_associatedDistributors.Remove(distributor))
            throw new ArgumentException("Distributor not found");
    }

    public void EditDistributor(Distributor oldDistributor, Distributor newDistributor) {
        if(_associatedDistributors.Contains(oldDistributor)) {
            RemoveDistributor(oldDistributor);
        } else {
            throw new ArgumentException("Old distributor not found");
        }
        AddDistributor(newDistributor);
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
    
    public void AddDelivererInternally(Deliverer deliverer) => _associatedDeliverers.Add(deliverer);

    public void RemoveDelivererInternally(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
    }

    public void EditDeliverer(Deliverer oldDeliverer, Deliverer newDeliverer) {
        if (_associatedDeliverers.Contains(oldDeliverer)) {
            RemoveDeliverer(oldDeliverer);  
        } else {
            throw new ArgumentException("Old deliverer not found.");
        }
        AddDeliverer(newDeliverer);  
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