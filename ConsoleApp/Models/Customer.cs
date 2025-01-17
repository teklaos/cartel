using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public enum CustomerRoleAttribute {
    Dealer,
    Wholesaler
}

public static class CustomerRoleExtensions {
    public static string ToString(this CustomerRoleAttribute role) {
        return role switch {
            CustomerRoleAttribute.Dealer => "Dealers",
            CustomerRoleAttribute.Wholesaler => "Wholesalers",
            _ => throw new InvalidOperationException("Invalid role.")
        };
    }
}

public class Customer : IWholesaler, IDealer {
    private static IList<Customer> _customers = new List<Customer>();
    public static IList<Customer> Customers {
        get => _customers.ToList();
        private set => _customers = value;
    }

    private static IList<Customer> _dealers = new List<Customer>();
    public static IList<Customer> Dealers {
        get => _dealers.ToList();
        private set => _dealers = value;
    }

    private static IList<Customer> _wholesalers = new List<Customer>();
    public static IList<Customer> Wholesalers {
        get => _wholesalers.ToList();
        private set => _wholesalers = value;
    }

    private IList<CustomerRoleAttribute> _roles = new List<CustomerRoleAttribute>();
    public IList<CustomerRoleAttribute> Roles {
        get => _roles.ToList();
        private set => _roles = value;
    }

    private IList<Deal> _associatedDeals = new List<Deal>();

    public IList<Deal> AssociatedDeals {
        get => _associatedDeals.ToList();
        private set => _associatedDeals = value;
    }

    public string? Territory { get; private set; } = null!;
    private IList<string>? _criminalRecord = null!;
    public IList<string>? CriminalRecord {
        get => _criminalRecord == null ? null : new List<string>(_criminalRecord);
        private set => _criminalRecord = value;
    }
    public double? CommissionPercentage { get; private set; } = null!;
    public int? MonthlyCustomers { get; private set; } = null!;

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
        if (!Roles.Contains(CustomerRoleAttribute.Dealer))
            throw new InvalidOperationException("Customer is not a dealer.");

        ValidateDealerProperties(territory, criminalRecord);
        Territory = territory;
        CriminalRecord = criminalRecord;
    }

    public void Edit(double commissionPercentage, int monthlyCustomers) {
        if (!Roles.Contains(CustomerRoleAttribute.Wholesaler))
            throw new InvalidOperationException("Customer is not a wholesaler.");

        ValidateWholesalerProperties(commissionPercentage, monthlyCustomers);
        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
    }

    public void Edit(
        string territory, IList<string>? criminalRecord,
        double commissionPercentage, int monthlyCustomers
    ) {
        if (!Roles.Contains(CustomerRoleAttribute.Dealer))
            throw new InvalidOperationException("Customer is not a dealer.");
        else if (!Roles.Contains(CustomerRoleAttribute.Wholesaler))
            throw new InvalidOperationException("Customer is not a wholesaler.");

        Edit(territory, criminalRecord);
        Edit(commissionPercentage, monthlyCustomers);
    }

    public void Remove() {
        foreach (Deal deal in AssociatedDeals)
            deal.RemoveCustomerInternally();
        _customers.Remove(this);
        _dealers.Remove(this);
        _wholesalers.Remove(this);
    }

    public void AddRole(CustomerRoleAttribute role, string territory, params string[]? criminalRecord) {
        if (Roles.Contains(role))
            throw new ArgumentException($"Customer already has the {role} role.");

        SetDealerProperties(territory, criminalRecord);
        _roles.Add(role);
    }

    public void AddRole(CustomerRoleAttribute role, double commissionPercentage, int monthlyCustomers) {
        if (Roles.Contains(role))
            throw new ArgumentException($"Customer already has the {role} role.");

        SetWholesalerProperties(commissionPercentage, monthlyCustomers);
        _roles.Add(role);
    }

    public void RemoveRole(CustomerRoleAttribute role) {
        if (!Roles.Contains(role))
            throw new ArgumentException($"Customer does not have the {role} role to remove.");

        ClearRoleProperties(role);
        _roles.Remove(role);

        switch (role) {
            case CustomerRoleAttribute.Dealer:
                _dealers.Remove(this);
                break;

            case CustomerRoleAttribute.Wholesaler:
                _wholesalers.Remove(this);
                break;

            default:
                throw new ArgumentException("Invalid role.");
        }
    }

    protected void SetDealerProperties(string territory, IList<string>? criminalRecord) {
        ValidateDealerProperties(territory, criminalRecord);
        Territory = territory;
        CriminalRecord = criminalRecord;
        _dealers.Add(this);
    }

    protected void SetWholesalerProperties(double commissionPercentage, int monthlyCustomers) {
        ValidateWholesalerProperties(commissionPercentage, monthlyCustomers);
        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        _wholesalers.Add(this);
    }

    protected void ClearRoleProperties(CustomerRoleAttribute role) {
        switch (role) {
            case CustomerRoleAttribute.Dealer:
                Territory = null;
                CriminalRecord = null;
                break;

            case CustomerRoleAttribute.Wholesaler:
                CommissionPercentage = null;
                MonthlyCustomers = null;
                break;

            default:
                throw new ArgumentException("Invalid role.");
        }
    }

    private static void ValidateDealerProperties(string territory, IList<string>? criminalRecord) {
        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or empty.");
        foreach (string record in criminalRecord ?? []) {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentException("Criminal record cannot be null or empty.");
        }
    }

    private static void ValidateWholesalerProperties(double commissionPercentage, int monthlyCustomers) {
        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Monthly customers cannot be negative.");
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
        IList<string> fileNames = ["Customers.json", "Dealers.json", "Wholesalers.json"];
        IList<IList<Customer>> lists = [Customers, Dealers, Wholesalers];
        for (int i = 0; i < fileNames.Count; i++) {
            try {
                string jsonString = JsonSerializer.Serialize(lists[i], AppConfig.JsonOptions);
                File.WriteAllText(fileNames[i], jsonString);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void Deserialize() {
        IList<string> fileNames = ["Customers.json", "Dealers.json", "Wholesalers.json"];
        IList<IList<Customer>> lists = [Customers, Dealers, Wholesalers];
        for (int i = 0; i < fileNames.Count; i++) {
            try {
                string jsonString = File.ReadAllText(fileNames[i]);
                lists[i] = JsonSerializer.Deserialize<List<Customer>>(jsonString, AppConfig.JsonOptions) ?? [];
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}