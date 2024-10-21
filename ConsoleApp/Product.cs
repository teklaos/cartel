namespace ConsoleApp;

public enum AddLevel {
    Weak,
    Medium,
    Strong
}

public class Product {
    private string Name { get; set; } = null!;
    private int PricePerPound { get; set; }
    private int PurityPercentage { get; set; }
    private AddLevel AddictivenessLevel { get; set; }
}