using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestAssociations {
    [Test]
    public void TestInternalAssociationsAddFromWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        warehouse.AddProductToWarehouse(product);

        Assert.Multiple(() => {
            Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.Products.Count));
            Assert.That(Warehouse.Warehouses, Has.Count.EqualTo(Product.ConnectedWarehouses.Count));
        });
    }

    [Test]
    public void TestInternalAssociationsAttachWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddProductStoredIn(warehouse);

        Assert.Multiple(() => {
            Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.Products.Count));
            Assert.That(Warehouse.Warehouses, Has.Count.EqualTo(Product.ConnectedWarehouses.Count));
        });
        // Console.WriteLine($"Warehouses connected = {Warehouse.AssociatedProducts.Count}");
        // Console.WriteLine($"Products connected = {Warehouse.AssociatedProducts.Count}");
    }

    [Test]
    public void TestInternalAssociationsRemoveProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddProductStoredIn(warehouse);
        product.RemoveProductStoredIn(warehouse);

        Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.ConnectedWarehouses.Count));
    }

    [Test]
    public void TestInternalAssociationsRemoveWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddProductStoredIn(warehouse);
        warehouse.RemoveProductFromWarehouse(product);

        Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.ConnectedWarehouses.Count));
    }
}