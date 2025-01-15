using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public enum CustomerRole {
    Dealer,
    Wholesaler
}

public static class CustomerRoleExtensions {
    public static string ToString(this CustomerRole role) {
        return role switch {
            CustomerRole.Dealer => "Dealers",
            CustomerRole.Wholesaler => "Wholesalers",
            _ => throw new InvalidOperationException("Invalid role.")
        };
    }
}

public class Customer : IWholesaler, IDealer {
    private static IList<Customer> _customers = new List<Customer>();
    public static IList<Customer> Customers {
        get => new List<Customer>(_customers);
        private set => _customers = value;
    }

    private IList<CustomerRole> _roles = new List<CustomerRole>();
    public IList<CustomerRole> Roles {
        get => new List<CustomerRole>(_roles);
        private set => _roles = value;
    }

    public string? Territory { get; private set; } = null!;
    private IList<string>? _criminalRecord { get; set; } = null!;
    public IList<string>? CriminalRecord {
        get => _criminalRecord == null ? null : new List<string>(_criminalRecord);
        private set => _criminalRecord = value;
    }
    public double? CommissionPercentage { get; private set; } = null!;
    public int? MonthlyCustomers { get; private set; } = null!;

    private IList<Deal> _associatedDeals = new List<Deal>();

    public IList<Deal> AssociatedDeals {
        get => new List<Deal>(_associatedDeals);
        private set => _associatedDeals = value;
    }

    public Customer() =>
        _customers.Add(this);

    public Customer(Customer customer) {
        Roles = customer.Roles;
        Territory = customer.Territory;
        CriminalRecord = customer.CriminalRecord;
        CommissionPercentage = customer.CommissionPercentage;
        MonthlyCustomers = customer.MonthlyCustomers;
        AssociatedDeals = customer.AssociatedDeals;
        _customers.Add(this);
    }

    public static Customer Add() =>
        new();

    public void Edit(string territory, IList<string>? criminalRecord) {
        if (!Roles.Contains(CustomerRole.Dealer))
            throw new InvalidOperationException("Customer is not a dealer.");

        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or whitespace.");
        foreach (string record in criminalRecord ?? []) {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Each record cannot be null or whitespace.");
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
    }

    public void Edit(double commissionPercentage, int monthlyCustomers) {
        if (!Roles.Contains(CustomerRole.Wholesaler))
            throw new InvalidOperationException("Customer is not a wholesaler.");

        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Amount of monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
    }

    public void Edit(
        string territory, IList<string>? criminalRecord,
        double commissionPercentage, int monthlyCustomers
    ) {
        if (!Roles.Contains(CustomerRole.Dealer))
            throw new InvalidOperationException("Customer is not a dealer.");
        else if (!Roles.Contains(CustomerRole.Wholesaler))
            throw new InvalidOperationException("Customer is not a wholesaler.");

        Edit(territory, criminalRecord);
        Edit(commissionPercentage, monthlyCustomers);
    }

    public void Remove() {
        foreach (Deal deal in AssociatedDeals)
            deal.RemoveCustomerInternally();
        _customers.Remove(this);
    }

    public void AddRole(CustomerRole role, string territory, params string[]? criminalRecord) {
        if (Roles.Contains(role))
            throw new ArgumentException($"Customer already has the {role} role.");

        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or empty.");
        foreach (string record in criminalRecord ?? []) {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Criminal record cannot be null or empty.");
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
        Roles.Add(role);
    }

    public void AddRole(CustomerRole role, double commissionPercentage, int monthlyCustomers) {
        if (Roles.Contains(role))
            throw new ArgumentException($"Customer already has the {role} role.");

        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        Roles.Add(role);
    }

    public void RemoveRole(CustomerRole role) {
        if (!Roles.Contains(role))
            throw new ArgumentException($"Customer does not have the {role} role to remove.");

        ClearRoleProperties(role);
        Roles.Remove(role);
    }

    protected void SetDealerProperties(string territory, IList<string>? criminalRecord) {
        Console.WriteLine($"{territory} -- string.");
        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or empty.");
        foreach (string record in criminalRecord ?? []) {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Criminal record cannot be null or empty.");
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
    }

    protected void SetWholesalerProperties(double commissionPercentage, int monthlyCustomers) {
        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
    }

    private void ClearRoleProperties(CustomerRole role) {
        switch (role) {
            case CustomerRole.Dealer:
                Territory = null;
                CriminalRecord = null;
                break;

            case CustomerRole.Wholesaler:
                CommissionPercentage = null;
                MonthlyCustomers = null;
                break;

            default:
                throw new ArgumentException("Invalid role.");
        }
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

    public void AddDealInternally(Deal deal) {
        _associatedDeals.Add(deal);
    }
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
            Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString, AppConfig.JsonOptions) ??
                        new List<Customer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}