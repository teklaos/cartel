using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestAssociationsImplementation
{
    [Test]
    public void TestInternalAssociationsAddFromWarehouse()
    {
        Warehouse warehouse = new Warehouse(
            "Warsaw, Praga-Pld",
            1000
        );

        Product product = new Product(
            "Meth",
            100,
            AddLevelAttribute.Strong
        ); 
        
        warehouse.AddProductToWarehouse(product);
        
        Assert.That(Warehouse.AssociatedProducts.Count, Is.EqualTo(Product.Products.Count()));
        Assert.That(Warehouse.Warehouses.Count, Is.EqualTo(Product.ConnectedWarehouses.Count));

    }
    
    [Test]
    public void TestInternalAssociationsAttachWarehouse()
    {
        Warehouse warehouse = new Warehouse(
            "Warsaw, Praga-Pld",
            1000
        );

        Product product = new Product(
            "Meth",
            100,
            AddLevelAttribute.Strong
        ); 
        
        product.AddProductStoredIn(warehouse);
        
        Assert.That(Warehouse.AssociatedProducts.Count, Is.EqualTo(Product.Products.Count()));
        Assert.That(Warehouse.Warehouses.Count, Is.EqualTo(Product.ConnectedWarehouses.Count));
        Console.WriteLine($"wc = {Warehouse.AssociatedProducts.Count}");
        Console.WriteLine($"pc = {Warehouse.AssociatedProducts.Count}");

    }
    
    [Test]
    public void TestInternalAssociationsRemoveProduct()
    {
        Warehouse warehouse = new Warehouse(
            "Warsaw, Praga-Pld",
            1000
        );

        Product product = new Product(
            "Meth",
            100,
            AddLevelAttribute.Strong
        ); 
        
        product.AddProductStoredIn(warehouse);
        product.RemoveProductStoredIn(warehouse);
        
        
        Assert.That(Warehouse.AssociatedProducts.Count, Is.EqualTo(Product.ConnectedWarehouses.Count()));
    }
    
    [Test]
    public void TestInternalAssociationsRemoveWarehouse()
    {
        Warehouse warehouse = new Warehouse(
            "Warsaw, Praga-Pld",
            1000
        );

        Product product = new Product(
            "Meth",
            100,
            AddLevelAttribute.Strong
        ); 
        
        product.AddProductStoredIn(warehouse);
        warehouse.RemoveProductFromWarehouse(product);
        
        
        Assert.That(Warehouse.AssociatedProducts.Count, Is.EqualTo(Product.ConnectedWarehouses.Count()));
    }
}