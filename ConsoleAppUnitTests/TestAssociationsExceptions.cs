using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestExceptionCases {
    [Test]
    public void TestRemoveProductThrowsExceptionWhenProductNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        var ex = Assert.Throws<Exception>(() => warehouse.RemoveProduct(product));
        Assert.That(ex.Message, Is.EqualTo("Product not found exception."));
    }

    [Test]
    public void TestRemoveWarehouseThrowsExceptionWhenWarehouseNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        var ex = Assert.Throws<Exception>(() => product.RemoveWarehouse(warehouse));
        Assert.That(ex.Message, Is.EqualTo("Warehouse not found."));
    }

    [Test]
    public void TestRemoveProductInternallyThrowsExceptionWhenProductNotFound() {
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        var ex = Assert.Throws<Exception>(() => Warehouse.RemoveProductInternally(product));
        Assert.That(ex.Message, Is.EqualTo("Product not found exception."));
    }

    [Test]
    public void TestRemoveWarehouseInternallyThrowsExceptionWhenWarehouseNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);

        var ex = Assert.Throws<Exception>(() => Product.RemoveWarehouseInternally(warehouse));
        Assert.That(ex.Message, Is.EqualTo("Warehouse not found."));
    }
    
}
