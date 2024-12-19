using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public class Laboratory : ICompositionConnection<Equipment>
{
    private IList<Equipment> _equipments = new List<Equipment>();
    public IList<Equipment> AssociatedEquipment {
        get => new List<Equipment>(_equipments);
        private set => _equipments = value;
    }
    
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

    private IList<Ingredient> _associatedIngredients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngredients {
        get => new List<Ingredient>(_associatedIngredients);
        private set => _associatedIngredients = value;
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

    public void EditProduct(Product oldProduct, Product newProduct) {
        if (_associatedProducts.Contains(oldProduct)) {
            RemoveProduct(oldProduct);  
        } else {
            throw new ArgumentException("Old product not found.");
        }
        AddProduct(newProduct);  
    }

    public void AddIngredient(Ingredient ingredient) {
        _associatedIngredients.Add(ingredient);
        ingredient.AddLaboratoryInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if(!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
        ingredient.RemoveLaboratoryInternally(this);
    }
    
    public void AddIngredientInternally(Ingredient ingredient) => _associatedIngredients.Add(ingredient);

    public void RemoveIngredientInternally(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
    }

    public void EditIngredient(Ingredient oldIngredient, Ingredient newIngredient) {
        if(_associatedIngredients.Contains(oldIngredient)) {
            RemoveIngredient(oldIngredient);
        } else {
            throw new ArgumentException("Old ingredient not found.");
        }
        AddIngredient(newIngredient);
    }
    
    public void CreateCompositionConnection(Equipment entity)
    {
        if (entity.AssignedLab != null)
            throw new Exception("Equipment already attached to the lab.");
        entity.AttachLab(this);
        _equipments.Add(entity);
    }

    public void RemoveCompositionConnection(Equipment entity)
    {
        if (entity.AssignedLab == null)
            throw new Exception("Equipment has not been attached to the lab yet.");
        _equipments.Remove(entity);
        entity.RemoveLab();
    }

    public void EditCompositionConnection(Equipment oldEntity, Equipment newEntity)
    {
        RemoveCompositionConnection(oldEntity);
        CreateCompositionConnection(newEntity);
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