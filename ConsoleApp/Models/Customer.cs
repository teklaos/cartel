using System.Text.Json;
using ConsoleApp;
using ConsoleApp.Abstractions.Interfaces;
using ConsoleApp.models;

public enum CustomerRole
{
    None,
    Dealer,
    Wholesaler
}

public static class CustomerRoleExtensions
{
    public static string ToRoleString(this CustomerRole role)
    {
        switch (role)
        {
            case CustomerRole.Dealer:
                return "Dealers";
            case CustomerRole.Wholesaler:
                return "Wholesalers";
            default:
                return "None";
        }
    }
}

public class Customer : IWholesaler, IDealer
{
    private static IList<Customer> _customers = new List<Customer>();

    public static IList<Customer> Customers
    {
        get => new List<Customer>(_customers);
        private set => _customers = value;
    }

    private IList<Deal> _associatedDeals = new List<Deal>();

    public IList<Deal> AssociatedDeals
    {
        get => new List<Deal>(_associatedDeals);
        private set => _associatedDeals = value;
    }

    public List<CustomerRole> Roles { get; private set; } = new List<CustomerRole>();

    public string Territory { get; private set; } = string.Empty;
    public IList<string> CriminalRecord { get; private set; } = new List<string>();
    public double CommissionPercentage { get; private set; } = 0;
    public int MonthlyCustomers { get; private set; } = 0;

    public Customer()
    {
        _customers.Add(this);
    }

    public Customer(Customer other)
    {
        Roles = new List<CustomerRole>(other.Roles);
        Territory = other.Territory;
        CriminalRecord = new List<string>(other.CriminalRecord);
        CommissionPercentage = other.CommissionPercentage;
        MonthlyCustomers = other.MonthlyCustomers;
        _associatedDeals = new List<Deal>(other._associatedDeals);
        _customers.Add(this);
    }

    public void SwitchRole(CustomerRole newRole)
    {
        if (!Roles.Contains(newRole))
        {
            Roles.Add(newRole);
            UpdateRoleSpecificAttributes(newRole);
        }
        else
        {
            Console.WriteLine($"Customer already has the {newRole} role.");
        }
    }

    public void RemoveRole(CustomerRole role)
    {
        if (Roles.Contains(role))
        {
            Roles.Remove(role);
            ClearRoleSpecificAttributes(role);
        }
        else
        {
            Console.WriteLine($"Customer does not have the {role} role to remove.");
        }
    }

    private void UpdateRoleSpecificAttributes(CustomerRole role)
    {
        switch (role)
        {
            case CustomerRole.Dealer:
                Territory = "Default Territory"; // Example default value
                CriminalRecord = new List<string>(); // Example default value
                break;

            case CustomerRole.Wholesaler:
                CommissionPercentage = 5.0;
                MonthlyCustomers = 100;
                break;

            default:
                throw new InvalidOperationException("Invalid role.");
        }
    }

    private void ClearRoleSpecificAttributes(CustomerRole role)
    {
        switch (role)
        {
            case CustomerRole.Dealer:
                Territory = string.Empty;
                CriminalRecord = new List<string>();
                break;

            case CustomerRole.Wholesaler:
                CommissionPercentage = 0;
                MonthlyCustomers = 0;
                break;

            default:
                throw new InvalidOperationException("Invalid role.");
        }
    }

    public void SetDealerInfo(string territory, IList<string> criminalRecord)
    {
        if (!Roles.Contains(CustomerRole.Dealer))
            throw new InvalidOperationException("Customer must have the Dealer role to set dealer information.");

        if (string.IsNullOrWhiteSpace(territory))
            throw new ArgumentException("Territory cannot be null or whitespace.");
        if (criminalRecord != null)
        {
            foreach (string record in criminalRecord)
            {
                if (string.IsNullOrWhiteSpace(record))
                    throw new ArgumentException("Each record cannot be null or whitespace.");
            }
        }

        Territory = territory;
        CriminalRecord = criminalRecord;
    }

    public void SetWholesalerInfo(double commissionPercentage, int monthlyCustomers)
    {
        if (!Roles.Contains(CustomerRole.Wholesaler))
            throw new InvalidOperationException(
                "Customer must have the Wholesaler role to set wholesaler information.");

        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Amount of monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
    }

    public static Customer Add() => new Customer();

    public void Remove()
    {
        foreach (var deal in _associatedDeals)
            deal.RemoveCustomerInternally();
        _customers.Remove(this);
    }

    public void AddDeal(Deal deal)
    {
        _associatedDeals.Add(deal);
        deal.AddCustomerInternally(this);
    }

    public void AddDealInternally(Deal deal)
    {
        _associatedDeals.Add(deal);
    }
    public void RemoveDealInternally(Deal deal)
    {
        _associatedDeals.Remove(deal);
    }

    public void RemoveDeal(Deal deal)
    {
        if (!_associatedDeals.Remove(deal))
            throw new ArgumentException("Deal not found.");
        deal.RemoveCustomerInternally();
    }

    public static void Serialize()
    {
        string fileName = "Customers.json";
        try
        {
            string jsonString = JsonSerializer.Serialize(Customers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize()
    {
        string fileName = "Customers.json";
        try
        {
            string jsonString = File.ReadAllText(fileName);
            Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString, AppConfig.JsonOptions) ??
                        new List<Customer>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}