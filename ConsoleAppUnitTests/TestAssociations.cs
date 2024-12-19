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

    [Test]
    public void TestLaboratoryAddProduct() {
        Laboratory laboratory = new("Madelin");
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(product);

        Assert.That(laboratory.AssociatedProducts, Has.Count.EqualTo(product.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryRemoveProduct() {
        Laboratory laboratory = new("Madelin");
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddLaboratory(laboratory);
        laboratory.RemoveProduct(product);

        Assert.That(laboratory.AssociatedProducts, Has.Count.EqualTo(product.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestProductAddLaboratory() {
        Laboratory laboratory = new("Madelin");
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        product.AddLaboratory(laboratory);

        Assert.That(product.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveLaboratory() {
        Laboratory laboratory = new("Madelin");
        Product product = new("Meth", 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(product);
        product.RemoveLaboratory(laboratory);
        
        Assert.That(product.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedProducts.Count));
    }

    [Test]
    public void TestDistributorAddWarehouse() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelin", 500);

        distributor.AddWarehouse(warehouse);

        Assert.That(distributor.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDistibutors.Count));
    }

    [Test]
    public void TestDistributorRemoveWarehouse() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelin", 500);

        warehouse.AddDistributor(distributor);
        distributor.RemoveWarehouse(warehouse);

        Assert.That(distributor.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDistibutors.Count));
    }

    [Test]
    public void TestWarehouseAddDistributor() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelin", 500);

        warehouse.AddDistributor(distributor);

        Assert.That(warehouse.AssociatedDistibutors, Has.Count.EqualTo(distributor.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveDistributor() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelin", 500);

        distributor.AddWarehouse(warehouse);
        warehouse.RemoveDistributor(distributor);

        Assert.That(warehouse.AssociatedDistibutors, Has.Count.EqualTo(distributor.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestIngredientAddLaboratory() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelin");

        ingredient.AddLaboratory(laboratory);

        Assert.That(ingredient.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedIngridients.Count));
    }

    [Test]
    public void TestIngredientRemoveLaboratory() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelin");

        laboratory.AddIngredient(ingredient);
        ingredient.RemoveLaboratory(laboratory);

        Assert.That(ingredient.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedIngridients.Count));
    }

    [Test]
    public void TestLaboratoryAddIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelin");

        laboratory.AddIngredient(ingredient);

        Assert.That(laboratory.AssociatedIngridients, Has.Count.EqualTo(ingredient.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryRemoveIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelin");

        ingredient.AddLaboratory(laboratory);
        laboratory.RemoveIngredient(ingredient);

        Assert.That(laboratory.AssociatedIngridients, Has.Count.EqualTo(ingredient.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestIngredientAddSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelin", 6);

        ingredient.AddSupplyChain(supplyChain);

        Assert.That(ingredient.AssociatedSupplyChains, Has.Count.EqualTo(supplyChain.AssociatedIngridients.Count));
    }

    [Test]
    public void TestIngredientRemoveSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelin", 6);

        supplyChain.AddIngredient(ingredient);
        ingredient.RemoveSupplyChain(supplyChain);

        Assert.That(ingredient.AssociatedSupplyChains, Has.Count.EqualTo(supplyChain.AssociatedIngridients.Count));
    }

    [Test]
    public void TestSupplyChainAddIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelin", 6);

        supplyChain.AddIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngridients, Has.Count.EqualTo(ingredient.AssociatedSupplyChains.Count));
    }

    [Test]
    public void TestSupplyChainRemoveIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelin", 6);

        ingredient.AddSupplyChain(supplyChain);
        supplyChain.RemoveIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngridients, Has.Count.EqualTo(ingredient.AssociatedSupplyChains.Count));
    }

    [Test]
    public void TestWarehouseAddDeliverer() {
        Warehouse warehouse = new("Madelin", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        warehouse.AddDeliverer(deliverer);

        Assert.That(warehouse.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveDeliverer() {
        Warehouse warehouse = new("Madelin", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddWarehouse(warehouse);
        warehouse.RemoveDeliverer(deliverer);

        Assert.That(warehouse.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestDelivererAddWarehouse() {
        Warehouse warehouse = new("Madelin", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddWarehouse(warehouse);

        Assert.That(deliverer.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestDelivererRemoveWarehouse() {
        Warehouse warehouse = new("Madelin", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        warehouse.AddDeliverer(deliverer);
        deliverer.RemoveWarehouse(warehouse);

        Assert.That(deliverer.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDeliverers.Count));
    }
}