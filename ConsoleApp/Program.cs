using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Test();
    }

    public static void Test() {
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
}
