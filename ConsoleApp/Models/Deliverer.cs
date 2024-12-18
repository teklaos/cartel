using System.Text.Json;

namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    private static IList<Deliverer> _deliverers = new List<Deliverer>();
    public static IList<Deliverer> Deliverers {
        get => new List<Deliverer>(_deliverers);
        private set => _deliverers = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    public Deliverer(string name, int trustLevel, IList<string> rulesToFollow) :
    base(name, trustLevel, rulesToFollow) => _deliverers.Add(this);

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddDelivererInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
        product.RemoveDelivererInternally(this);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
    }

    public new static void Serialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Deliverers, AppConfig.JsonSerializerOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Deliverers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Deliverers = JsonSerializer.Deserialize<List<Deliverer>>(jsonString) ?? new List<Deliverer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}