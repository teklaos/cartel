using System.Text.Json;

namespace ConsoleApp.models;

public class Distributor : CartelMember {
    private static IList<Distributor> _distributors = new List<Distributor>();
    public static IList<Distributor> Distributors {
        get => new List<Distributor>(_distributors);
        private set => _distributors = value;
    }
    public int DealsMade { get; private set; }

    private IList<Warehouse> _associatedWarehouses = new List<Warehouse>();
    public IList<Warehouse> AssociatedWarehouses {
        get => new List<Warehouse>(_associatedWarehouses);
        private set => _associatedWarehouses = value;
    }

    private IDictionary<string, List<Deal>> _associatedDeals = new Dictionary<string, List<Deal>>();
    public IDictionary<string, List<Deal>> AssociatedDeals {
        get => new Dictionary<string, List<Deal>>(_associatedDeals);
        private set => _associatedDeals = value;
    }

    public Distributor(string name, int trustLevel, IList<string> rulesToFollow, int dealsMade) :
    base(name, trustLevel, rulesToFollow) {
        if (dealsMade < 0)
            throw new ArgumentException("Made deals cannot be negative.");

        DealsMade = dealsMade;
        _distributors.Add(this);
    }

    public void AddWarehouse(Warehouse warehouse) {
        _associatedWarehouses.Add(warehouse);
        warehouse.AddDistributorInternally(this);
    }

    public void RemoveWarehouse(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Distributor not found.");
        warehouse.RemoveDistributorInternally(this);
    }

    public void EditWarehouse(Warehouse oldWarehouse, Warehouse newWarehouse) {
        RemoveWarehouse(oldWarehouse);
        AddWarehouse(newWarehouse);
    }

    public void AddWarehouseInternally(Warehouse warehouse) => _associatedWarehouses.Add(warehouse);

    public void RemoveWarehouseInternally(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Warehouse not found.");
    }

    public void AddDeal(string CustomerId, Deal deal) {
        if (CustomerId == null)
            throw new ArgumentException("Customer ID cannot be null.");
        if (!_associatedDeals.TryAdd(CustomerId, [deal]))
            _associatedDeals[CustomerId].Add(deal);
        deal.AddDistributorInternally(this);
    }

    public void RemoveDeal(string CustomerId, Deal deal) {
        if (CustomerId == null)
            throw new ArgumentException("Customer ID cannot be null.");
        if (_associatedDeals[CustomerId].Count < 1)
            _associatedDeals.Remove(CustomerId);
        else
            _associatedDeals[CustomerId].Remove(deal);
        deal.RemoveDistributorInternally();
    }

    public new static void Serialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = JsonSerializer.Serialize(Distributors, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Distributors.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Distributors = JsonSerializer.Deserialize<List<Distributor>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}