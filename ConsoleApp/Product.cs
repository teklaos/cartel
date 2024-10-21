namespace ConsoleApp;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    public string Name { get; set; } = null!;
    public int PricePerPound { get; set; }
    public double PurityPercentage { get; set; }
    public AddLevelAttribute AddictivenessLevel { get; set; }
}