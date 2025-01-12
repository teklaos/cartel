using System.Text.Json;

namespace ConsoleApp.models;

public class Customer {
    private static IList<Customer> _customers = new List<Customer>();
    public static IList<Customer> Customers {
        get => new List<Customer>(_customers);
        private set => _customers = value;
    }

    private IList<Deal> _associatedDeals = new List<Deal>();
    public IList<Deal> AssociatedDeals {
        get => new List<Deal>(_associatedDeals);
        private set => _associatedDeals = value;
    }

    public Customer() =>
        _customers.Add(this);

    public static Customer Add() =>
        _ = new Customer();

    public void Remove() {
        foreach (var deal in _associatedDeals)
            deal.RemoveCustomerInternally();
        _customers.Remove(this);
    }

    public void AddDeal(Deal deal) {
        _associatedDeals.Add(deal);
        deal.AddCustomerInternally(this);
    }

    public void RemoveDeal(Deal deal) {
        if (!_associatedDeals.Remove(deal))
            throw new ArgumentException("Deal not found.");
        deal.RemoveCustomerInternally();
    }

    public void EditDeal(Deal oldDeal, Deal newDeal) {
        RemoveDeal(oldDeal);
        AddDeal(newDeal);
    }

    public void AddDealInternally(Deal deal) =>
        _associatedDeals.Add(deal);

    public void RemoveDealInternally(Deal deal) {
        if (!_associatedDeals.Remove(deal))
            throw new ArgumentException("Deal not found.");
    }

    public static void Serialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Customers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}