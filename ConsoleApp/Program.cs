using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product crystalMethamphetamine = new Product("Crystal Methamphetamine", 2500, 98.71, AddLevelAttribute.Strong);
        Product cocaine = new Product("Cocaine", 3000, 95.62, AddLevelAttribute.Medium);
        foreach (Product prod in Product._products) {
            Console.WriteLine(prod.Name);
        }

        Chemist chemist = new Chemist("Danny", 10, ["Be a good boy.", "Do not steal methamphetamine."], 15);
        Distributor distributor = new Distributor("Ben", 9, ["Be nice to people.", "Do not kill anyone (optional)."]);
        Deliverer deliverer = new Deliverer("Frank", 8, ["Be a cutie pie."]);
        foreach (CartelMember member in CartelMember._cartelMembers) {
            Console.WriteLine(member.Name);
        }
    }   
}