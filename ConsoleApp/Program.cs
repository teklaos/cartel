namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product crystalMethamphetamine = new Product("Crystal Methamphetamine", 2500, 98.71, AddLevelAttribute.Strong);
        Product cocaine = new Product("Cocaine", 3000, 95.62, AddLevelAttribute.Medium);
        foreach (Product prod in Product._products) {
            Console.WriteLine(prod.Name);
        }

        Chemist chemist = new Chemist("Danny", 1, ["Be a good boy", "Don't steal methamphetamine"], 15);
        Distributor distributor = new Distributor("Ben", 2, ["Be nice to people", "Don't kill anyone (Optional)"]);
        Deliverer deliverer = new Deliverer("Frank", 3, ["Be a cute pie"]);
        foreach (CartelMember member in CartelMember._cartelMembers) {
            Console.WriteLine(member.Name);
        }
    }   
}