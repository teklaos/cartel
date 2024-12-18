using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product product = new("Methamphetamine", 2500, AddLevelAttribute.Strong);
        Warehouse warehouse = new("Warsaw, Praga", 10000);

        product.AddWarehouse(warehouse);
        Product.Serialize();

        Product.Deserialize();
        foreach (var prod in Product.Products) {
            Console.WriteLine($"{prod.Name} costs ${prod.PricePerPound} per pound.");
        }
    }
}
