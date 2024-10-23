namespace ConsoleApp.models;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    public static IEnumerable<Product> _products { get; private set; } = new List<Product>(); 
    public string Name { get; set; } = null!;
    public int PricePerPound { get; set; }
    public double PurityPercentage { get; set; }
    public AddLevelAttribute AddictivenessLevel { get; set; }

    public Product(string name, int pricePerPound, double purityPercentage, AddLevelAttribute addictivenessLevel) {
        this.Name = name;
        this.PricePerPound = pricePerPound;
        this.PurityPercentage = purityPercentage;
        this.AddictivenessLevel = addictivenessLevel;
        _products = _products.Append(this);
    }
}