using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public class Laboratory : ICompositionAssociation<Equipment> {
    private static IList<Laboratory> _laboratories = new List<Laboratory>();
    public static IList<Laboratory> Laboratories {
        get => _laboratories.ToList();
        private set => _laboratories = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => _associatedProducts.ToList();
        private set => _associatedProducts = value;
    }

    private IList<Ingredient> _associatedIngredients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngredients {
        get => _associatedIngredients.ToList();
        private set => _associatedIngredients = value;
    }

    private IList<Equipment> _associatedEquipment = new List<Equipment>();
    public IList<Equipment> AssociatedEquipment {
        get => _associatedEquipment.ToList();
        private set => _associatedEquipment = value;
    }

    public string Location { get; private set; }
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be null or whitespace.");

        Location = location;
        _laboratories.Add(this);
    }

    public static IList<string> GetLocations() =>
        Laboratories.Select(l => l.Location).ToList();

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddLaboratoryInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found.");
        product.RemoveLaboratoryInternally(this);
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        RemoveProduct(oldProduct);
        AddProduct(newProduct);
    }

    public void AddProductInternally(Product product) =>
        _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
    }

    public void AddIngredient(Ingredient ingredient) {
        _associatedIngredients.Add(ingredient);
        ingredient.AddLaboratoryInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
        ingredient.RemoveLaboratoryInternally(this);
    }

    public void EditIngredient(Ingredient oldIngredient, Ingredient newIngredient) {
        RemoveIngredient(oldIngredient);
        AddIngredient(newIngredient);
    }

    public void AddIngredientInternally(Ingredient ingredient) =>
        _associatedIngredients.Add(ingredient);

    public void RemoveIngredientInternally(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
    }

    public void AddCompositionAssociation(Equipment equipment) {
        if (equipment.AssociatedLaboratory != null)
            throw new ArgumentException("Equipment is already attached to the lab.");
        _associatedEquipment.Add(equipment);
        equipment.AddLaboratoryInternally(this);
    }

    public void RemoveCompositionAssociation(Equipment equipment) {
        if (equipment.AssociatedLaboratory == null)
            throw new ArgumentException("Equipment has not been attached to the lab yet.");
        _associatedEquipment.Remove(equipment);
        equipment.RemoveLaboratoryInternally();
    }

    public void EditCompositionAssociation(Equipment oldEquipment, Equipment newEquipment) {
        RemoveCompositionAssociation(oldEquipment);
        AddCompositionAssociation(newEquipment);
    }

    public void AddCompositionAssociationInternally(Equipment equipment) {
        if (equipment.AssociatedLaboratory != null)
            throw new Exception("Equipment is already attached to the lab.");
        _associatedEquipment.Add(equipment);
    }

    public void RemoveCompositionAssociationInternally(Equipment equipment) {
        if (equipment.AssociatedLaboratory == null)
            throw new Exception("Equipment has not been attached to the lab yet.");
        _associatedEquipment.Remove(equipment);
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