using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestAssociations {
    [Test]
    public void TestInternalAssociationsAddFromWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        warehouse.AddProduct(product);

        Assert.Multiple(() => {
            Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.Products.Count));
            Assert.That(Warehouse.Warehouses, Has.Count.EqualTo(Product.AssociatedWarehouses.Count));
        });
    }

    [Test]
    public void TestInternalAssociationsAttachWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddWarehouse(warehouse);

        Assert.Multiple(() => {
            Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.Products.Count));
            Assert.That(Warehouse.Warehouses, Has.Count.EqualTo(Product.AssociatedWarehouses.Count));
        });
        // Console.WriteLine($"Warehouses connected = {Warehouse.AssociatedProducts.Count}");
        // Console.WriteLine($"Products connected = {Warehouse.AssociatedProducts.Count}");
    }

    [Test]
    public void TestInternalAssociationsRemoveProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddWarehouse(warehouse);
        product.RemoveWarehouse(warehouse);

        Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.AssociatedWarehouses.Count));
    }
    
    [Test]
    public void TestInternalAssociationsRemoveWarehouse() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddWarehouse(warehouse);
        warehouse.RemoveProduct(product);

        Assert.That(Warehouse.AssociatedProducts, Has.Count.EqualTo(Product.AssociatedWarehouses.Count));
    }
    
}