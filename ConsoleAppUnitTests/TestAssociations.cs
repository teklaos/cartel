using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestAssociations {
    [Test]
    public void TestWarehouseAddProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        warehouse.AddProduct(product);

        Assert.That(warehouse.AssociatedProducts, Has.Count.EqualTo(product.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddWarehouse(warehouse);
        warehouse.RemoveProduct(product);

        Assert.That(warehouse.AssociatedProducts, Has.Count.EqualTo(product.AssociatedWarehouses.Count));
    }

    public void TestWarehouseEditProduct()
    {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        warehouse.AddProduct(oldProduct);

        Assert.Contains(oldProduct, warehouse.AssociatedProducts.ToList());

        warehouse.EditProduct(oldProduct, newProduct);

        Assert.False(warehouse.AssociatedProducts.Contains(oldProduct));
        Assert.Contains(newProduct, warehouse.AssociatedProducts.ToList());
    }

    [Test]
    public void TestProductAddWarehouse() {
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        Warehouse warehouse = new("Warsaw, Praga", 1000);

        product.AddWarehouse(warehouse);

        Assert.That(product.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveWarehouse() {
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        Warehouse warehouse = new("Warsaw, Praga", 1000);

        warehouse.AddProduct(product);
        product.RemoveWarehouse(warehouse);

        Assert.That(product.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductEditWarehouse() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Warehouse newWarehouse = new("Warsaw, Praga", 1000);
        Warehouse oldWarehouse = new("Warsaw, Praga", 1001);

        product.AddWarehouse(oldWarehouse);

        Assert.Contains(oldWarehouse, product.AssociatedWarehouses.ToList());

        product.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.False(product.AssociatedWarehouses.Contains(oldWarehouse));
        Assert.Contains(newWarehouse, product.AssociatedWarehouses.ToList());
    }

    [Test]
    public void TestDelivererAddProduct() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        deliverer.AddProduct(product);

        Assert.That(deliverer.AssociatedProducts, Has.Count.EqualTo(product.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestDelivererRemoveProduct() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddDeliverer(deliverer);
        deliverer.RemoveProduct(product);

        Assert.That(deliverer.AssociatedProducts, Has.Count.EqualTo(product.AssociatedDeliverers.Count));
    }

    public void TestDelivererEditProduct()
    {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        deliverer.AddProduct(oldProduct);

        Assert.Contains(oldProduct, deliverer.AssociatedProducts.ToList());

        deliverer.EditProduct(oldProduct, newProduct);

        Assert.False(deliverer.AssociatedProducts.Contains(oldProduct));
        Assert.Contains(newProduct, deliverer.AssociatedProducts.ToList());
    }

    [Test]
    public void TestProductAddDeliverer() {
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        product.AddDeliverer(deliverer);

        Assert.That(product.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveDeliverer() {
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddProduct(product);
        product.RemoveDeliverer(deliverer);

        Assert.That(product.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductEditDeliverer() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Deliverer newDeliverer = new("Mike", 10, ["Do not kill customers."]);
        Deliverer oldDeliverer = new("Mike", 11, ["Do not kill customers."]);

        product.AddDeliverer(oldDeliverer);

        Assert.Contains(oldDeliverer, product.AssociatedDeliverers.ToList());

        product.EditDeliverer(oldDeliverer, newDeliverer);

        Assert.False(product.AssociatedDeliverers.Contains(oldDeliverer));
        Assert.Contains(newDeliverer, product.AssociatedDeliverers.ToList());
    }

    [Test]
    public void TestChemistAddProduct() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        chemist.AddProduct(product);

        Assert.That(chemist.AssociatedProducts, Has.Count.EqualTo(product.AssociatedChemists.Count));
    }

    [Test]
    public void TestChemistRemoveProduct() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemist(chemist);
        chemist.RemoveProduct(product);

        Assert.That(chemist.AssociatedProducts, Has.Count.EqualTo(product.AssociatedChemists.Count));
    }

    public void TestChemistEditProduct()
    {
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        chemist.AddProduct(oldProduct);

        Assert.Contains(oldProduct, chemist.AssociatedProducts.ToList());

        chemist.EditProduct(oldProduct, newProduct);

        Assert.False(chemist.AssociatedProducts.Contains(oldProduct));
        Assert.Contains(newProduct, chemist.AssociatedProducts.ToList());
    }

    [Test]
    public void TestProductAddChemist() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemist(chemist);

        Assert.That(product.AssociatedChemists, Has.Count.EqualTo(chemist.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveChemist() {
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        chemist.AddProduct(product);
        product.RemoveChemist(chemist);

        Assert.That(product.AssociatedChemists, Has.Count.EqualTo(chemist.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductEditChemist() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Chemist newChemist = new("Danny", 10, ["Do not steal meth."], 90);
        Chemist oldChemist = new("Danny", 11, ["Do not steal meth."], 90);

        product.AddChemist(oldChemist);

        Assert.Contains(oldChemist, product.AssociatedChemists.ToList());

        product.EditChemist(oldChemist, newChemist);

        Assert.False(product.AssociatedChemists.Contains(oldChemist));
        Assert.Contains(newChemist, product.AssociatedChemists.ToList());
    }

    [Test]
    public void TestRecipeAddProduct() {
        Recipe recipe = new(); 
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        
        recipe.AddProduct(product);

        Assert.That(recipe.AssociatedProducts, Has.Count.EqualTo(product.AssociatedRecipes.Count));
    }

    [Test]
    public void TestRecipeRemoveProduct() {
        Recipe recipe = new(); 
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddRecipe(recipe);
        recipe.RemoveProduct(product);

        Assert.That(recipe.AssociatedProducts, Has.Count.EqualTo(product.AssociatedRecipes.Count));
    }

    [Test]
    public void TestRecipeEditProduct()
    {
        Recipe recipe = new Recipe();
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        recipe.AddProduct(oldProduct);

        Assert.Contains(oldProduct, recipe.AssociatedProducts.ToList());

        recipe.EditProduct(oldProduct, newProduct);

        Assert.False(recipe.AssociatedProducts.Contains(oldProduct));
        Assert.Contains(newProduct, recipe.AssociatedProducts.ToList());
    }

    [Test]
    public void TestProductAddRecipe() {
        Recipe recipe = new(); 
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddRecipe(recipe);

        Assert.That(product.AssociatedRecipes, Has.Count.EqualTo(recipe.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveRecipe() {
        Recipe recipe = new(); 
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        recipe.AddProduct(product);
        product.RemoveRecipe(recipe);

        Assert.That(product.AssociatedRecipes, Has.Count.EqualTo(recipe.AssociatedProducts.Count));
    }


    [Test]
    public void TestProductEditRecipe() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Recipe newRecipe = new Recipe();
        Recipe oldRecipe = new Recipe();

        product.AddRecipe(oldRecipe);

        Assert.Contains(oldRecipe, product.AssociatedRecipes.ToList());

        product.EditRecipe(oldRecipe, newRecipe);

        Assert.False(product.AssociatedRecipes.Contains(oldRecipe));
        Assert.Contains(newRecipe, product.AssociatedRecipes.ToList());
    }
    

    [Test]
    public void TestLaboratoryAddProduct() {
        Laboratory laboratory = new("Madelyn");
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(product);

        Assert.That(laboratory.AssociatedProducts, Has.Count.EqualTo(product.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryRemoveProduct() {
        Laboratory laboratory = new("Madelyn");
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddLaboratory(laboratory);
        laboratory.RemoveProduct(product);

        Assert.That(laboratory.AssociatedProducts, Has.Count.EqualTo(product.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryEditProduct()
    {
        Laboratory laboratory = new("Madelyn");
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(oldProduct);

        Assert.Contains(oldProduct, laboratory.AssociatedProducts.ToList());

        laboratory.EditProduct(oldProduct, newProduct);

        Assert.False(laboratory.AssociatedProducts.Contains(oldProduct));
        Assert.Contains(newProduct, laboratory.AssociatedProducts.ToList());
    }

    [Test]
    public void TestProductAddLaboratory() {
        Laboratory laboratory = new("Madelyn");
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddLaboratory(laboratory);

        Assert.That(product.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductRemoveLaboratory() {
        Laboratory laboratory = new("Madelyn");
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(product);
        product.RemoveLaboratory(laboratory);
        
        Assert.That(product.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedProducts.Count));
    }

    [Test]
    public void TestProductEditLaboratory() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Laboratory newLaboratory = new("Madelyn");
        Laboratory oldLaboratory = new("Drained");

        product.AddLaboratory(oldLaboratory);

        Assert.Contains(oldLaboratory, product.AssociatedLaboratories.ToList());

        product.EditLaboratory(oldLaboratory, newLaboratory);

        Assert.False(product.AssociatedLaboratories.Contains(oldLaboratory));
        Assert.Contains(newLaboratory, product.AssociatedLaboratories.ToList());
    }

    [Test]
    public void TestDistributorAddWarehouse() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelyn", 500);

        distributor.AddWarehouse(warehouse);

        Assert.That(distributor.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDistributors.Count));
    }

    [Test]
    public void TestDistributorRemoveWarehouse() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelyn", 500);

        warehouse.AddDistributor(distributor);
        distributor.RemoveWarehouse(warehouse);

        Assert.That(distributor.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDistributors.Count));
    }

    [Test]
    public void TestDistributorEditWarehouse()
    {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse newWarehouse = new("Madelyn", 500);
        Warehouse oldWarehouse = new("Madelyn", 501);

        distributor.AddWarehouse(oldWarehouse);

        Assert.Contains(oldWarehouse, distributor.AssociatedWarehouses.ToList());

        distributor.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.False(distributor.AssociatedWarehouses.Contains(oldWarehouse));
        Assert.Contains(newWarehouse, distributor.AssociatedWarehouses.ToList());
    }

    [Test]
    public void TestWarehouseAddDistributor() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelyn", 500);

        warehouse.AddDistributor(distributor);

        Assert.That(warehouse.AssociatedDistributors, Has.Count.EqualTo(distributor.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveDistributor() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse warehouse = new("Madelyn", 500);

        distributor.AddWarehouse(warehouse);
        warehouse.RemoveDistributor(distributor);

        Assert.That(warehouse.AssociatedDistributors, Has.Count.EqualTo(distributor.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseEditDistributor()
    {
        Warehouse warehouse = new("Madelyn", 500);
        Distributor oldDistributor = new("Danny", 10, ["Don't steal"], 15);
        Distributor newDistributor = new("Danny", 11, ["Don't steal"], 15);

        warehouse.AddDistributor(oldDistributor);

        Assert.Contains(oldDistributor, warehouse.AssociatedDistributors.ToList());

        warehouse.EditDistributor(oldDistributor, newDistributor);

        Assert.False(warehouse.AssociatedDistributors.Contains(oldDistributor));
        Assert.Contains(newDistributor, warehouse.AssociatedDistributors.ToList());
    }

    [Test]
    public void TestIngredientAddLaboratory() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelyn");

        ingredient.AddLaboratory(laboratory);

        Assert.That(ingredient.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientRemoveLaboratory() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelyn");

        laboratory.AddIngredient(ingredient);
        ingredient.RemoveLaboratory(laboratory);

        Assert.That(ingredient.AssociatedLaboratories, Has.Count.EqualTo(laboratory.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientEditLaboratory()
    {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory newLaboratory = new("Madelyn");
        Laboratory oldLaboratory = new("Drained");

        ingredient.AddLaboratory(oldLaboratory);

        Assert.Contains(oldLaboratory, ingredient.AssociatedLaboratories.ToList());

        ingredient.EditLaboratory(oldLaboratory, newLaboratory);

        Assert.False(ingredient.AssociatedLaboratories.Contains(oldLaboratory));
        Assert.Contains(newLaboratory, ingredient.AssociatedLaboratories.ToList());
    }

    [Test]
    public void TestLaboratoryAddIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelyn");

        laboratory.AddIngredient(ingredient);

        Assert.That(laboratory.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryRemoveIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory laboratory = new("Madelyn");

        ingredient.AddLaboratory(laboratory);
        laboratory.RemoveIngredient(ingredient);

        Assert.That(laboratory.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedLaboratories.Count));
    }

    [Test]
    public void TestLaboratoryEditIngredient()
    {
        Laboratory laboratory = new("Madelyn");
        Ingredient newIngredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient oldIngredient = new Ingredient("Crystal", 201, "C₁₀H₁₅N", StateAttribute.Solid);

        laboratory.AddIngredient(oldIngredient);

        Assert.Contains(oldIngredient, laboratory.AssociatedIngredients.ToList());

        laboratory.EditIngredient(oldIngredient, newIngredient);

        Assert.False(laboratory.AssociatedIngredients.Contains(oldIngredient));
        Assert.Contains(newIngredient, laboratory.AssociatedIngredients.ToList());
    }

    [Test]
    public void TestIngredientAddSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        ingredient.AddSupplyChain(supplyChain);

        Assert.That(ingredient.AssociatedSupplyChains, Has.Count.EqualTo(supplyChain.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientRemoveSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        supplyChain.AddIngredient(ingredient);
        ingredient.RemoveSupplyChain(supplyChain);

        Assert.That(ingredient.AssociatedSupplyChains, Has.Count.EqualTo(supplyChain.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientEditSupplyChain()
    {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain newSupplyChain = new("Madelyn", 6);
        SupplyChain oldSupplyChain = new("Madelyn", 7);

        ingredient.AddSupplyChain(oldSupplyChain);

        Assert.Contains(oldSupplyChain, ingredient.AssociatedSupplyChains.ToList());

        ingredient.EditSupplyChain(oldSupplyChain, newSupplyChain);

        Assert.False(ingredient.AssociatedSupplyChains.Contains(oldSupplyChain));
        Assert.Contains(newSupplyChain, ingredient.AssociatedSupplyChains.ToList());
    }

    [Test]
    public void TestSupplyChainAddIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        supplyChain.AddIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedSupplyChains.Count));
    }

    [Test]
    public void TestSupplyChainRemoveIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        ingredient.AddSupplyChain(supplyChain);
        supplyChain.RemoveIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedSupplyChains.Count));
    }

    [Test]
    public void TestSupplyChainEditIngredient()
    {
        SupplyChain supplyChain = new("Madelyn", 6);
        Ingredient newIngredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient oldIngredient = new Ingredient("Crystal", 201, "C₁₀H₁₅N", StateAttribute.Solid);

        supplyChain.AddIngredient(oldIngredient);

        Assert.Contains(oldIngredient, supplyChain.AssociatedIngredients.ToList());

        supplyChain.EditIngredient(oldIngredient, newIngredient);

        Assert.False(supplyChain.AssociatedIngredients.Contains(oldIngredient));
        Assert.Contains(newIngredient, supplyChain.AssociatedIngredients.ToList());
    }


    [Test]
    public void TestWarehouseAddDeliverer() {
        Warehouse warehouse = new("Madelyn", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        warehouse.AddDeliverer(deliverer);

        Assert.That(warehouse.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedWarehouses.Count));
    }

    [Test]
    public void TestWarehouseRemoveDeliverer() {
        Warehouse warehouse = new("Madelyn", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddWarehouse(warehouse);
        warehouse.RemoveDeliverer(deliverer);

        Assert.That(warehouse.AssociatedDeliverers, Has.Count.EqualTo(deliverer.AssociatedWarehouses.Count));
    }

    public void TestWarehouseEditDeliverer()
    {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Deliverer newDeliverer = new("Mike", 10, ["Do not kill customers."]);
        Deliverer oldDeliverer = new("Mike", 11, ["Do not kill customers."]);

        warehouse.AddDeliverer(oldDeliverer);

        Assert.Contains(oldDeliverer, warehouse.AssociatedDeliverers.ToList());

        warehouse.EditDeliverer(oldDeliverer, newDeliverer);

        Assert.False(warehouse.AssociatedDeliverers.Contains(oldDeliverer));
        Assert.Contains(newDeliverer, warehouse.AssociatedDeliverers.ToList());
    }

    [Test]
    public void TestDelivererAddWarehouse() {
        Warehouse warehouse = new("Madelyn", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        deliverer.AddWarehouse(warehouse);

        Assert.That(deliverer.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestDelivererRemoveWarehouse() {
        Warehouse warehouse = new("Madelyn", 500);
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);

        warehouse.AddDeliverer(deliverer);
        deliverer.RemoveWarehouse(warehouse);

        Assert.That(deliverer.AssociatedWarehouses, Has.Count.EqualTo(warehouse.AssociatedDeliverers.Count));
    }

    [Test]
    public void TestDelivererEditWarehouse() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Warehouse newWarehouse = new("Warsaw, Praga", 1000);
        Warehouse oldWarehouse = new("Warsaw, Praga", 1001);

        deliverer.AddWarehouse(oldWarehouse);

        Assert.Contains(oldWarehouse, deliverer.AssociatedWarehouses.ToList());

        deliverer.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.False(deliverer.AssociatedWarehouses.Contains(oldWarehouse));
        Assert.Contains(newWarehouse, deliverer.AssociatedWarehouses.ToList());
    }
}