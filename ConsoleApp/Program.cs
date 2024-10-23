using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product crystalMethamphetamine = new Product("Crystal Methamphetamine", 2500, 98.71, AddLevelAttribute.Strong);
        Product cocaine = new Product("Cocaine", 3000, 95.62, AddLevelAttribute.Medium);

        Product.Serialize();
        Product.Deserialize();
        foreach (Product product in Product._products) {
            Console.WriteLine(product.Name);
        }
    }
}