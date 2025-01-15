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

public class Customer : IDealer, IWholesaler
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

    public CustomerRole Role { get; private set; } = CustomerRole.None;

    public string Territory { get; private set; } = string.Empty;
    public IList<string> CriminalRecord { get; private set; } = new List<string>();
    public double CommissionPercentage { get; private set; } = 0;
    public int MonthlyCustomers { get; private set; } = 0;

    public Customer(CustomerRole role = CustomerRole.None)
    {
        this.Role = role;
        _customers.Add(this);
    }

    public Customer(Customer other)
    {
        Role = other.Role;
        Territory = other.Territory;
        CriminalRecord = new List<string>(other.CriminalRecord);
        CommissionPercentage = other.CommissionPercentage;
        MonthlyCustomers = other.MonthlyCustomers;
        _associatedDeals = new List<Deal>(other._associatedDeals);
        _customers.Add(this);
    }

    public void SwitchRole(CustomerRole newRole, object roleSpecificData)
    {
        if (Role == newRole)
        {
            Console.WriteLine($"Customer already has the {newRole} role.");
            return;
        }

        Role = newRole;

        Territory = null;
        CriminalRecord = new List<string>();
        CommissionPercentage = 0;
        MonthlyCustomers = 0;

        switch (newRole)
        {
            case CustomerRole.Dealer:
                var dealerData = (Tuple<string, IList<string>>)roleSpecificData;
                Territory = dealerData.Item1;
                CriminalRecord = dealerData.Item2 ?? new List<string>();
                break;

            case CustomerRole.Wholesaler:
                var wholesalerData = (Tuple<double, int>)roleSpecificData;
                CommissionPercentage = wholesalerData.Item1;
                MonthlyCustomers = wholesalerData.Item2;
                break;

            case CustomerRole.None:
                break;
        }
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

    public void RemoveDeal(Deal deal)
    {
        if (!_associatedDeals.Remove(deal))
            throw new ArgumentException("Deal not found.");
        deal.RemoveCustomerInternally();
    }

    public void EditDeal(Deal oldDeal, Deal newDeal)
    {
        RemoveDeal(oldDeal);
        AddDeal(newDeal);
    }

    public void AddDealInternally(Deal deal) => _associatedDeals.Add(deal);

    public void RemoveDealInternally(Deal deal)
    {
        if (!_associatedDeals.Remove(deal))
            throw new ArgumentException("Deal not found.");
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

    public void SetDealerInfo(string territory, IList<string> criminalRecord)
    {
        if (Role != CustomerRole.Dealer)
            throw new InvalidOperationException("Invalid role for Dealer-specific actions.");

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
        if (Role != CustomerRole.Wholesaler)
            throw new InvalidOperationException("Invalid role for Wholesaler-specific actions.");

        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Amount of monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
    }
}