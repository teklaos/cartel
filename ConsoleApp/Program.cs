using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        foreach (var chem in Chemist.Chemists) {
            Console.WriteLine(chem.Name);
        }
    }
}