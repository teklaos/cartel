using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Product.Deserialize();
        foreach (var prod in Product.Products) {
            Console.WriteLine(prod.Name + " is " + prod.PurityPercentage + "% pure.");
        }
    }
}