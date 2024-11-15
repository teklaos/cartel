using ConsoleApp.models;

namespace ConsoleApp;

public class Program {
    public static void Main(string[] args) {
        Chemist.Deserialize();
        foreach (var chem in Chemist.Chemists) {
            Console.WriteLine(chem.Name);
        }
    }
}