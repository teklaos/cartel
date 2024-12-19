using System.Text.Json;

namespace ConsoleApp.models;

public class Laboratory {
    private static IList<Laboratory> _laboratories = new List<Laboratory>();
    public static IList<Laboratory> Laboratories {
        get => new List<Laboratory>(_laboratories);
        private set => _laboratories = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    private IList<Ingredient> _associatedIngridients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngridients {
        get => new List<Ingredient>(_associatedIngridients);
        private set => _associatedIngridients = value;
    }

    public string Location { get; private set; }
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.");

        Location = location;
        _laboratories.Add(this);
    }

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddLaboratoryInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found.");
        product.RemoveLaboratoryInternally(this);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);
    
    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found.");
    }

    public void AddIngredient(Ingredient ingredient) {
        _associatedIngridients.Add(ingredient);
        ingredient.AddLaboratoryInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if(!_associatedIngridients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
        ingredient.RemoveLaboratoryInternally(this);
    }
    
    public void AddIngredientInternally(Ingredient ingredient) => _associatedIngridients.Add(ingredient);

    public void RemoveIngredientInternally(Ingredient ingredient) {
        if (!_associatedIngridients.Remove(ingredient))
            throw new ArgumentException("Ingridient not found.");
    }
    
    public static void Serialize() {
        string fileName = "Laboratories.json";
        try {
            string jsonString = JsonSerializer.Serialize(Laboratories, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Laboratories.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Laboratories = JsonSerializer.Deserialize<List<Laboratory>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}