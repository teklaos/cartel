using System.Text.Json;

namespace ConsoleApp.models;

public class Recipe {
    private static IList<Recipe> _recipes = new List<Recipe>();
    public static IList<Recipe> Recipes {
        get => new List<Recipe>(_recipes);
        private set => _recipes = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    private readonly int _amountOfInstructions = 55;
    public int Complexity { get => _amountOfInstructions / 10; }

    public Recipe() => _recipes.Add(this);

    
    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddRecipeInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found exception.");
        product.RemoveRecipeInternally(this);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);
    
    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found exception.");
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        if (_associatedProducts.Contains(oldProduct)) {
            RemoveProduct(oldProduct);  
        } else {
            throw new ArgumentException("Old product not found.");
        }
        AddProduct(newProduct);  
    }

    
    public static void Serialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = JsonSerializer.Serialize(Recipes, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}