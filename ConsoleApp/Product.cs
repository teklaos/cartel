namespace ConsoleApp;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    public static IEnumerable<Product> Products { get; private set; } = []; // Class extent
    public string Name { get; set; } = null!;
    public int PricePerPound { get; set; }
    public double PurityPercentage { get; set; }
    public AddLevelAttribute AddictivenessLevel { get; set; }

    public Product(string name, int pricePerPound, double purityPercentage, AddLevelAttribute addictivenessLevel) {
        this.Name = name;
        this.PricePerPound = pricePerPound;
        this.PurityPercentage = purityPercentage;
        this.AddictivenessLevel = addictivenessLevel;
        Products = Products.Append(this);
    }
}