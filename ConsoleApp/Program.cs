using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        // TestChemistProduct();
        TestDealDistributor();
    }

    public static void TestChemistProduct() {
        // Initialization:
        Product Meth = new("Meth", 15, 10000, AddLevelAttribute.Strong);
        Product Cocaine = new("Cocaine", 15, 5000, AddLevelAttribute.Weak);

        Chemist Walter = new("Walter", 5, ["Follow the leader."], 10000);
        Chemist Jesse = new("Jesse", 7, ["Follow the leader."], 5000);
        Chemist Gale = new("Gale", 9, ["Follow the leader"], 2500);



        // Testing Product methods:

        try {
            Console.Write("Add Walter: ");
            Meth.AddChemists(Walter);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        try {
            Console.Write("Add Walter and Walter: ");
            Meth.AddChemists(Walter, Walter);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Add Walter and Jesse: ");
        Meth.AddChemists(Walter, Jesse);
        Console.Write(string.Join(", ", Meth.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");

        try {
            Console.Write("Remove Jesse: ");
            Meth.RemoveChemist(Jesse);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Add Gale: ");
        Meth.AddChemists(Gale);
        Console.Write(string.Join(", ", Meth.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");

        Console.Write("Remove Jesse: ");
        Meth.RemoveChemist(Jesse);
        Console.Write(string.Join(", ", Meth.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");



        // Testing Chemist methods:

        try {
            Console.Write("Add product (Walter): ");
            Walter.AddProduct(Cocaine);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Add Walter and Jesse: ");
        Cocaine.AddChemists(Walter, Jesse);
        Console.Write(string.Join(", ", Cocaine.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");

        try {
            Console.Write("Remove product (Jesse): ");
            Jesse.RemoveProduct(Cocaine);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Add product (Gale): ");
        Gale.AddProduct(Cocaine);
        Console.Write(string.Join(", ", Cocaine.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");

        Console.Write("Remove product (Jesse): ");
        Jesse.RemoveProduct(Cocaine);
        Console.Write(string.Join(", ", Cocaine.AssociatedChemists.Select(chem => chem.Name)));
        Console.WriteLine(".");
    }

    public static void TestDealDistributor() {
        Distributor distributor = new("Mike", 10, ["Follow the rules."], 250);
        Deal deal1 = new(new DateTime(2024, 12, 01, 04, 20, 31), 150, null);
        Deal deal2 = new(new DateTime(2024, 12, 11, 16, 45, 24), 250, null);
        string customerId = "Black-Eagle";

        try {
            Console.Write("Adding deal to customer with ID \"null\": ");
            distributor.AddDeal(deal1, null);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Adding deal to customer with ID \"" + customerId + "\": ");
        distributor.AddDeal(deal1, customerId);
        Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));

        Console.Write("Adding another deal to customer with ID \"" + customerId + "\": ");
        distributor.AddDeal(deal2, customerId);
        Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));

        Console.Write("Removing first deal from customer with ID \"" + customerId + "\": ");
        distributor.RemoveDeal(deal1, customerId);
        Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));

        try {
            Console.Write("Removing first deal from customer with ID \"" + customerId + "\": ");
            distributor.RemoveDeal(deal1, customerId);
            Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Associated customer IDs: ");
        Console.WriteLine(string.Join(", ", distributor.AssociatedDeals.Keys));

        try {
            Console.Write("Removing last deal from customer with ID \"" + customerId + "\": ");
            distributor.RemoveDeal(deal2, customerId);
            Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));
        } catch (KeyNotFoundException ex) {
            Console.WriteLine(ex.Message.Replace("'", "\""));
        }

        Console.Write("Associated customer IDs: ");
        Console.WriteLine(string.Join(", ", distributor.AssociatedDeals.Keys));

        Console.Write("Adding distributor to a customer with ID \"" + customerId + "\": ");
        deal1.AddDistributor(distributor, customerId);
        Console.WriteLine(CustomerDealDates(distributor.AssociatedDeals, customerId));
    }

    public static string CustomerDealDates(IDictionary<string, List<Deal>> dictionary, string key) {
        return string.Join(", ", dictionary[key].Select(deal => deal.StartDate.ToString("dd/MM/yyyy")));
    }
}
