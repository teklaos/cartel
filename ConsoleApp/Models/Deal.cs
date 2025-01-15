using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp.models
{
    public class Deal
    {
        private static IList<Deal> _deals = new List<Deal>();
        public static IList<Deal> Deals
        {
            get => new List<Deal>(_deals);
            private set => _deals = value;
        }

        public DateTime StartDate { get; private set; }
        public int PoundsOfProduct { get; private set; }
        public DateTime? EndDate { get; private set; }

        public Distributor? AssociatedDistributor { get; private set; }
        public Customer? AssociatedCustomer { get; private set; }

        public Deal(DateTime startDate, int poundsOfProduct, DateTime? endDate)
        {
            if (startDate < new DateTime(1890, 1, 1))
                throw new ArgumentException("Deal start date cannot be earlier than year 1890.");
            else if (startDate > DateTime.Now)
                throw new ArgumentException("Deal start date cannot be in the future.");

            if (poundsOfProduct < 0)
                throw new ArgumentException("Pounds of product cannot be negative.");

            if (endDate.HasValue)
            {
                if (endDate.Value < startDate)
                    throw new ArgumentException("Deal end date cannot be earlier than the start date.");
                else if (endDate.Value > DateTime.Now)
                    throw new ArgumentException("Deal end date cannot be in the future.");
            }

            StartDate = startDate;
            PoundsOfProduct = poundsOfProduct;
            EndDate = endDate;
            _deals.Add(this);
        }

        public static Deal StartDeal(DateTime startDate, int poundsOfProduct, Distributor distributor, Customer customer, string customerId)
        {
            if (startDate < new DateTime(1890, 1, 1))
                throw new ArgumentException("Deal start date cannot be earlier than year 1890.");
            else if (startDate > DateTime.Now)
                throw new ArgumentException("Deal start date cannot be in the future.");

            if (poundsOfProduct < 0)
                throw new ArgumentException("Pounds of product cannot be negative.");

            Deal deal = new(startDate, poundsOfProduct, null);
            deal.AddDistributor(distributor, customerId);
            deal.AddCustomer(customer);

            Console.WriteLine("Deal started.");
            return deal;
        }

        public void CloseDeal()
        {
            EndDate = DateTime.Now;
        }

        public static IList<Dictionary<string, string>> GetViewData()
        {
            return Deals.Select(deal => new Dictionary<string, string>
            {
                { "Start Date", deal.StartDate.ToString("dd/MM/yyyy") },
                { "Pounds of Product", deal.PoundsOfProduct.ToString() },
                { "End Date", deal.EndDate?.ToString("dd/MM/yyyy") ?? "-" }
            }).ToList(); // ToList() to convert from IEnumerable to List<Dictionary<string, string>>
        }

        public void AddDistributor(Distributor distributor, string customerId)
        {
            distributor.AddDealInternally(this, customerId);
            AssociatedDistributor = distributor;
        }

        public void RemoveDistributor(Distributor distributor, string customerId)
        {
            distributor.RemoveDealInternally(this, customerId);
            AssociatedDistributor = null;
        }

        public void EditDistributor(Distributor oldDistributor, Distributor newDistributor, string oldCustomerId, string newCustomerId)
        {
            RemoveDistributor(oldDistributor, oldCustomerId);
            AddDistributor(newDistributor, newCustomerId);
        }

        public void AddDistributorInternally(Distributor distributor) =>
            AssociatedDistributor = distributor;

        public void RemoveDistributorInternally() =>
            AssociatedDistributor = null;

        public void AddCustomer(Customer customer)
        {
            customer.AddDealInternally(this);
            AssociatedCustomer = customer;
        }

        public void RemoveCustomer(Customer customer)
        {
            customer.RemoveDealInternally(this);
            AssociatedCustomer = null;
        }

        public void EditCustomer(Customer oldCustomer, Customer newCustomer)
        {
            RemoveCustomer(oldCustomer);
            AddCustomer(newCustomer);
        }

        public void AddCustomerInternally(Customer customer) =>
            AssociatedCustomer = customer;

        public void RemoveCustomerInternally() =>
            AssociatedCustomer = null;

        public static void Serialize()
        {
            string fileName = "Deals.json";
            try
            {
                string jsonString = JsonSerializer.Serialize(Deals, AppConfig.JsonOptions);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Deserialize()
        {
            string fileName = "Deals.json";
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Deals = JsonSerializer.Deserialize<List<Deal>>(jsonString, AppConfig.JsonOptions) ?? new List<Deal>(); // Use new List<Deal>() instead of []
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
