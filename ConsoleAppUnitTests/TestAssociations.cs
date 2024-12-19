using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestAssociations {
    [Test]
    public void TestWarehouseAddProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        warehouse.AddProduct(product);

        Assert.That(warehouse.AssociatedProducts, Has.Count.EqualTo(product.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddWarehouse(warehouse);
        warehouse.RemoveProduct(product);

        Assert.That(warehouse.AssociatedProducts, Has.Count.EqualTo(product.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestProductAddWarehouse() {
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);
        Warehouse warehouse = new("Warsaw, Praga", 1000);

        product.AddWarehouse(warehouse);

        Assert.That(product.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveWarehouse() {
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);
        Warehouse warehouse = new("Warsaw, Praga", 1000);

        warehouse.AddProduct(product);
        product.RemoveWarehouse(warehouse);

        Assert.That(product.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedProducts.Count));
    }

    [Test]
    public void TestDelivererAddProduct() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        deliverer.AddProduct(product);

        Assert.That(deliverer.AssociatedProducts, Has.Count.EqualTo(product.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestDelivererRemoveProduct() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddDeliverer(deliverer);
        deliverer.RemoveProduct(product);

        Assert.That(deliverer.AssociatedProducts, Has.Count.EqualTo(product.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestProductAddDeliverer() {
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        product.AddDeliverer(deliverer);

        Assert.That(product.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveDeliverer() {
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddProduct(product);
        product.RemoveDeliverer(deliverer);

        Assert.That(product.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedProducts.Count));
    }

    [Test]
    public void TestChemistAddProduct() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth"], 90);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        chemist.AddProduct(product);

        Assert.That(chemist.AssociatedProducts, Has.Count.EqualTo(product.AssociatedChemists.Count));
    }

    [Test]
    public void TestChemistRemoveProduct() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth"], 90);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddChemist(chemist);
        chemist.RemoveProduct(product);

        Assert.That(chemist.AssociatedProducts, Has.Count.EqualTo(product.AssociatedChemists.Count));
    }

    [Test]
    public void TestProductAddChemist() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth"], 90);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddChemist(chemist);

        Assert.That(product.AssociatedChemists, Has.Count.EqualTo(chemist.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveChemist() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth"], 90);
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        chemist.AddProduct(product);
        product.RemoveChemist(chemist);

        Assert.That(product.AssociatedChemists, Has.Count.EqualTo(chemist.AssociatedProducts.Count));
    }

    [Test]
    public void TestRecipeAddProduct() {
        Recipe recipe = new(); 
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);
        
        recipe.AddProduct(product);

        Assert.That(recipe.AssociatedProducts, Has.Count.EqualTo(product.AssociatedRecipes.Count));
    }

    [Test]
    public void TestRecipeRemoveProduct() {
        Recipe recipe = new(); 
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddRecipe(recipe);
        recipe.RemoveProduct(product);

        Assert.That(recipe.AssociatedProducts, Has.Count.EqualTo(product.AssociatedRecipes.Count));
    }

    [Test]
    public void TestProductAddRecipe() {
        Recipe recipe = new(); 
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddRecipe(recipe);

        Assert.That(product.AssociatedRecipes, Has.Count.EqualTo(recipe.AssociatedProducts.Count));
    }

    [Test]
    public void TestProuctRemoveRecipe() {
        Recipe recipe = new(); 
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        recipe.AddProduct(product);
        product.RemoveRecipe(recipe);

        Assert.That(product.AssociatedRecipes, Has.Count.EqualTo(recipe.AssociatedProducts.Count));
    }
}