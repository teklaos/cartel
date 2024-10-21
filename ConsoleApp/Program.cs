namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product crystalMethamphetamine = new Product("Crystal Methamphetamine", 2500, 98.71, AddLevelAttribute.Strong);
        Product cocaine = new Product("Cocaine", 3000, 95.62, AddLevelAttribute.Medium);
        foreach (Product prod in Product.Products) {
            Console.WriteLine(prod.Name);
        }
    }
}