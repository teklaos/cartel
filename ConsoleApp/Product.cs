namespace ConsoleApp;

public enum AddLevel {
    Weak,
    Medium,
    Strong
}

public class Product {
    public string Name { get; set; } = null!;
    public int PricePerPound { get; set; }
    public double PurityPercentage { get; set; }
    public AddLevel AddictivenessLevel { get; set; }
}