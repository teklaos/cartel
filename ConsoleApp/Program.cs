using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product.Deserialize();
        foreach (Product product in Product._products) {
            Console.WriteLine(product.Name);
        }

        Chemist.Deserialize();
        foreach (var chem in Chemist._chemists) {
            Console.WriteLine(chem.Name + " " + chem.TrustLevel + " " + chem.PoundsCooked);
        }
    }
}