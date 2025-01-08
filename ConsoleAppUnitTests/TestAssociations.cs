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

    [Test]
    public void TestWarehouseEditProduct() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        warehouse.AddProduct(oldProduct);

        Assert.That(warehouse.AssociatedProducts.Contains(oldProduct), Is.True);

        warehouse.EditProduct(oldProduct, newProduct);

        Assert.Multiple(() => {
            Assert.That(warehouse.AssociatedProducts.Contains(oldProduct), Is.False);
            Assert.That(warehouse.AssociatedProducts.Contains(newProduct), Is.True);
        });
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

        Assert.That(product.AssociatedWarehouses.Contains(oldWarehouse), Is.True);

        product.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.Multiple(() => {
            Assert.That(product.AssociatedWarehouses.Contains(oldWarehouse), Is.False);
            Assert.That(product.AssociatedWarehouses.Contains(newWarehouse), Is.True);
        });
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

    [Test]
    public void TestDelivererEditProduct() {
        Deliverer deliverer = new("Mike", 10, ["Do not kill customers."]);
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        deliverer.AddProduct(oldProduct);

        Assert.That(deliverer.AssociatedProducts.Contains(oldProduct), Is.True);

        deliverer.EditProduct(oldProduct, newProduct);

        Assert.Multiple(() => {
            Assert.That(deliverer.AssociatedProducts.Contains(oldProduct), Is.False);
            Assert.That(deliverer.AssociatedProducts.Contains(newProduct), Is.True);
        });
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

        Assert.That(product.AssociatedDeliverers.Contains(oldDeliverer), Is.True);

        product.EditDeliverer(oldDeliverer, newDeliverer);

        Assert.Multiple(() => {
            Assert.That(product.AssociatedDeliverers.Contains(oldDeliverer), Is.False);
            Assert.That(product.AssociatedDeliverers.Contains(newDeliverer), Is.True);
        });
    }

    [Test]
    public void TestChemistAddProduct() {
        Chemist ch1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist ch2 = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemists(ch1, ch2);
        chemist.AddProduct(product);

        Assert.That(product.AssociatedChemists.Contains(chemist), Is.True);
    }

    [Test]
    public void TestChemistRemoveProduct() {
        Chemist ch1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist ch2 = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemists(ch1, ch2, chemist);
        chemist.RemoveProduct(product);

        Assert.That(product.AssociatedChemists.Contains(chemist), Is.False);
    }

    [Test]
    public void TestChemistEditProduct() {
        Chemist ch1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist ch2 = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product oldProduct = new("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new("Meth", 101, 1000, AddLevelAttribute.Strong);

        oldProduct.AddChemists(ch1, ch2);
        chemist.AddProduct(oldProduct);

        Assert.That(chemist.AssociatedProducts.Contains(oldProduct), Is.True);

        newProduct.AddChemists(ch1, ch2);
        chemist.EditProduct(oldProduct, newProduct);

        Assert.Multiple(() => {
            Assert.That(chemist.AssociatedProducts.Contains(oldProduct), Is.False);
            Assert.That(chemist.AssociatedProducts.Contains(newProduct), Is.True);
        });
    }

    [Test]
    public void TestProductAddChemist() {
        Chemist chemist1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist chemist2 = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemists(chemist1, chemist2);

        Assert.Multiple(() => {
            Assert.That(chemist1.AssociatedProducts.Contains(product), Is.True);
            Assert.That(chemist2.AssociatedProducts.Contains(product), Is.True);
        });
    }

    [Test]
    public void TestProductRemoveChemist() {
        Chemist ch1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist ch2 = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist chemist = new("Danny", 10, ["Do not steal meth."], 90);
        Product product = new("Meth", 100, 1000, AddLevelAttribute.Strong);

        product.AddChemists(ch1, ch2);
        chemist.AddProduct(product);
        product.RemoveChemist(chemist);

        Assert.That(chemist.AssociatedProducts.Contains(product), Is.False);
    }

    [Test]
    public void TestProductEditChemist() {
        Product product = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Chemist ch1 = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist ch2 = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist newChemist = new("Danny", 10, ["Do not steal meth."], 90);
        Chemist oldChemist = new("Danny", 11, ["Do not steal meth."], 90);

        product.AddChemists(ch1, ch2);
        product.AddChemists(oldChemist);

        Assert.That(product.AssociatedChemists.Contains(oldChemist), Is.True);

        product.EditChemist(oldChemist, newChemist);

        Assert.Multiple(() => {
            Assert.That(product.AssociatedChemists.Contains(oldChemist), Is.False);
            Assert.That(product.AssociatedChemists.Contains(newChemist), Is.True);
        });
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
    public void TestRecipeEditProduct() {
        Recipe recipe = new Recipe();
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        recipe.AddProduct(oldProduct);

        Assert.That(recipe.AssociatedProducts.Contains(oldProduct), Is.True);

        recipe.EditProduct(oldProduct, newProduct);

        Assert.Multiple(() => {
            Assert.That(recipe.AssociatedProducts.Contains(oldProduct), Is.False);
            Assert.That(recipe.AssociatedProducts.Contains(newProduct), Is.True);
        });
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

        Assert.That(product.AssociatedRecipes.Contains(oldRecipe), Is.True);

        product.EditRecipe(oldRecipe, newRecipe);

        Assert.Multiple(() => {
            Assert.That(product.AssociatedRecipes.Contains(oldRecipe), Is.False);
            Assert.That(product.AssociatedRecipes.Contains(newRecipe), Is.True);
        });
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
    public void TestLaboratoryEditProduct() {
        Laboratory laboratory = new("Madelyn");
        Product oldProduct = new Product("Meth", 100, 1000, AddLevelAttribute.Strong);
        Product newProduct = new Product("Meth", 101, 1000, AddLevelAttribute.Strong);

        laboratory.AddProduct(oldProduct);

        Assert.That(laboratory.AssociatedProducts.Contains(oldProduct), Is.True);

        laboratory.EditProduct(oldProduct, newProduct);

        Assert.Multiple(() => {
            Assert.That(laboratory.AssociatedProducts.Contains(oldProduct), Is.False);
            Assert.That(laboratory.AssociatedProducts.Contains(newProduct), Is.True);
        });
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

        Assert.That(product.AssociatedLaboratories.Contains(oldLaboratory), Is.True);

        product.EditLaboratory(oldLaboratory, newLaboratory);

        Assert.Multiple(() => {
            Assert.That(product.AssociatedLaboratories.Contains(oldLaboratory), Is.False);
            Assert.That(product.AssociatedLaboratories.Contains(newLaboratory), Is.True);
        });
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
    public void TestDistributorEditWarehouse() {
        Distributor distributor = new("Danny", 10, ["Don't steal"], 15);
        Warehouse newWarehouse = new("Madelyn", 500);
        Warehouse oldWarehouse = new("Madelyn", 501);

        distributor.AddWarehouse(oldWarehouse);

        Assert.That(distributor.AssociatedWarehouses.Contains(oldWarehouse), Is.True);

        distributor.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.Multiple(() => {
            Assert.That(distributor.AssociatedWarehouses.Contains(oldWarehouse), Is.False);
            Assert.That(distributor.AssociatedWarehouses.Contains(newWarehouse), Is.True);
        });
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
    public void TestWarehouseEditDistributor() {
        Warehouse warehouse = new("Madelyn", 500);
        Distributor oldDistributor = new("Danny", 10, ["Don't steal"], 15);
        Distributor newDistributor = new("Danny", 11, ["Don't steal"], 15);

        warehouse.AddDistributor(oldDistributor);

        Assert.That(warehouse.AssociatedDistributors.Contains(oldDistributor), Is.True);

        warehouse.EditDistributor(oldDistributor, newDistributor);

        Assert.Multiple(() => {
            Assert.That(warehouse.AssociatedDistributors.Contains(oldDistributor), Is.False);
            Assert.That(warehouse.AssociatedDistributors.Contains(newDistributor), Is.True);
        });
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
    public void TestIngredientEditLaboratory() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Laboratory newLaboratory = new("Madelyn");
        Laboratory oldLaboratory = new("Drained");

        ingredient.AddLaboratory(oldLaboratory);

        Assert.That(ingredient.AssociatedLaboratories.Contains(oldLaboratory), Is.True);

        ingredient.EditLaboratory(oldLaboratory, newLaboratory);

        Assert.Multiple(() => {
            Assert.That(ingredient.AssociatedLaboratories.Contains(oldLaboratory), Is.False);
            Assert.That(ingredient.AssociatedLaboratories.Contains(newLaboratory), Is.True);
        });
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
    public void TestLaboratoryEditIngredient() {
        Laboratory laboratory = new("Madelyn");
        Ingredient newIngredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient oldIngredient = new Ingredient("Crystal", 201, "C₁₀H₁₅N", StateAttribute.Solid);

        laboratory.AddIngredient(oldIngredient);

        Assert.That(laboratory.AssociatedIngredients.Contains(oldIngredient), Is.True);

        laboratory.EditIngredient(oldIngredient, newIngredient);

        Assert.Multiple(() => {
            Assert.That(laboratory.AssociatedIngredients.Contains(oldIngredient), Is.False);
            Assert.That(laboratory.AssociatedIngredients.Contains(newIngredient), Is.True);
        });
    }

    [Test]
    public void TestIngredientAddSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        ingredient.AddSupplyChain(supplyChain);

        Assert.That(ingredient.AssociatedSupplyChain, Is.EqualTo(supplyChain));
    }

    [Test]
    public void TestIngredientRemoveSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        supplyChain.AddIngredient(ingredient);
        ingredient.RemoveSupplyChain();

        Assert.That(ingredient.AssociatedSupplyChain, Is.Null);
    }

    [Test]
    public void TestIngredientEditSupplyChain() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain newSupplyChain = new("Madelyn", 6);
        SupplyChain oldSupplyChain = new("Madelyn", 7);

        ingredient.AddSupplyChain(oldSupplyChain);

        Assert.That(ingredient.AssociatedSupplyChain, Is.EqualTo(oldSupplyChain));

        ingredient.EditSupplyChain(newSupplyChain);

        Assert.That(ingredient.AssociatedSupplyChain, Is.EqualTo(newSupplyChain));
    }

    [Test]
    public void TestSupplyChainAddIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        supplyChain.AddIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngredients.Contains(ingredient), Is.True);
    }

    [Test]
    public void TestSupplyChainRemoveIngredient() {
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        SupplyChain supplyChain = new("Madelyn", 6);

        ingredient.AddSupplyChain(supplyChain);
        supplyChain.RemoveIngredient(ingredient);

        Assert.That(supplyChain.AssociatedIngredients.Contains(ingredient), Is.False);
    }

    [Test]
    public void TestSupplyChainEditIngredient() {
        SupplyChain supplyChain = new("Madelyn", 6);
        Ingredient newIngredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient oldIngredient = new Ingredient("Crystal", 201, "C₁₀H₁₅N", StateAttribute.Solid);

        supplyChain.AddIngredient(oldIngredient);

        Assert.That(supplyChain.AssociatedIngredients.Contains(oldIngredient), Is.True);

        supplyChain.EditIngredient(oldIngredient, newIngredient);

        Assert.Multiple(() => {
            Assert.That(supplyChain.AssociatedIngredients.Contains(oldIngredient), Is.False);
            Assert.That(supplyChain.AssociatedIngredients.Contains(newIngredient), Is.True);
        });
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

    [Test]
    public void TestWarehouseEditDeliverer() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Deliverer newDeliverer = new("Mike", 10, ["Do not kill customers."]);
        Deliverer oldDeliverer = new("Mike", 11, ["Do not kill customers."]);

        warehouse.AddDeliverer(oldDeliverer);

        Assert.That(warehouse.AssociatedDeliverers.Contains(oldDeliverer), Is.True);

        warehouse.EditDeliverer(oldDeliverer, newDeliverer);

        Assert.Multiple(() => {
            Assert.That(warehouse.AssociatedDeliverers.Contains(oldDeliverer), Is.False);
            Assert.That(warehouse.AssociatedDeliverers.Contains(newDeliverer), Is.True);
        });
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

        Assert.That(deliverer.AssociatedWarehouses.Contains(oldWarehouse), Is.True);

        deliverer.EditWarehouse(oldWarehouse, newWarehouse);

        Assert.Multiple(() => {
            Assert.That(deliverer.AssociatedWarehouses.Contains(oldWarehouse), Is.False);
            Assert.That(deliverer.AssociatedWarehouses.Contains(newWarehouse), Is.True);
        });
    }

    [Test]
    public void TestLaboratoryAddEquipment() {
        Laboratory laboratory = new("Madelyn");
        Equipment equipment = new("Bottle", "Danny", "3000");

        laboratory.AddCompositionAssociation(equipment);

        Assert.Multiple(() => {
            Assert.That(laboratory.AssociatedEquipment.Contains(equipment), Is.True);
            Assert.That(equipment.AssociatedLaboratory, Is.EqualTo(laboratory));
        });
    }

    [Test]
    public void TestLaboratoryRemoveEquipment() {
        Laboratory laboratory = new("Madelyn");
        Equipment equipment = new("Bottle", "Danny", "3000");

        laboratory.AddCompositionAssociation(equipment);
        laboratory.RemoveCompositionAssociation(equipment);

        Assert.Multiple(() => {
            Assert.That(laboratory.AssociatedEquipment.Contains(equipment), Is.False);
            Assert.That(equipment.AssociatedLaboratory, Is.Null);
        });
    }

    [Test]
    public void TestLaboratoryEditEquipment() {
        Laboratory laboratory = new("Madelyn");
        Equipment oldEquipment = new("Bottle", "Danny", "3000");
        Equipment newEquipment = new("Bottle", "Danny", "3001");

        laboratory.AddCompositionAssociation(oldEquipment);

        Assert.That(laboratory.AssociatedEquipment.Contains(oldEquipment), Is.True);

        laboratory.EditCompositionAssociation(oldEquipment, newEquipment);

        Assert.Multiple(() => {
            Assert.That(laboratory.AssociatedEquipment.Contains(oldEquipment), Is.False);
            Assert.That(laboratory.AssociatedEquipment.Contains(newEquipment), Is.True);
        });
    }

    [Test]
    public void TestEquipmentAddLaboratory() {
        Equipment equipment = new("Bottle", "Danny", "3000");
        Laboratory laboratory = new("Madelyn");

        equipment.AddLaboratory(laboratory);

        Assert.Multiple(() => {
            Assert.That(equipment.AssociatedLaboratory, Is.EqualTo(laboratory));
            Assert.That(laboratory.AssociatedEquipment.Contains(equipment), Is.True);
        });
    }

    [Test]
    public void TestEquipmentRemoveLaboratory() {
        Equipment equipment = new("Bottle", "Danny", "3000");
        Laboratory laboratory = new("Madelyn");

        equipment.AddLaboratory(laboratory);
        equipment.RemoveLaboratory(laboratory);

        Assert.Multiple(() => {
            Assert.That(equipment.AssociatedLaboratory, Is.Null);
            Assert.That(laboratory.AssociatedEquipment.Contains(equipment), Is.False);
        });
    }

    [Test]
    public void TestEquipmentEditLaboratory() {
        Equipment equipment = new("Bottle", "Danny", "3000");
        Laboratory newLaboratory = new("Madelyn");
        Laboratory oldLaboratory = new("Drained");

        equipment.AddLaboratory(oldLaboratory);

        Assert.That(equipment.AssociatedLaboratory, Is.EqualTo(oldLaboratory));

        equipment.EditLaboratory(oldLaboratory, newLaboratory);

        Assert.Multiple(() => {
            Assert.That(equipment.AssociatedLaboratory, Is.EqualTo(newLaboratory));
            Assert.That(equipment.AssociatedLaboratory, Is.Not.EqualTo(oldLaboratory));
        });
    }

    [Test]
    public void TestIngredientAddInstructions() {
        Ingredient ingredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Instruction instruction = new("Stir");

        ingredient.AddInstruction(instruction);

        Assert.That(ingredient.AssociatedInstructions, Has.Count.EqualTo(instruction.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientRemoveInstructions() {
        Ingredient ingredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Instruction instruction = new("Stir");

        instruction.AddIngredient(ingredient);
        ingredient.RemoveInstruction(instruction);

        Assert.That(ingredient.AssociatedInstructions, Has.Count.EqualTo(instruction.AssociatedIngredients.Count));
    }

    [Test]
    public void TestIngredientEditInstructions() {
        Ingredient ingredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Instruction oldInstruction = new("Stir");
        Instruction newInstruction = new("Combine");

        ingredient.AddInstruction(oldInstruction);

        Assert.That(ingredient.AssociatedInstructions.Contains(oldInstruction), Is.True);

        ingredient.EditInstruction(oldInstruction, newInstruction);

        Assert.Multiple(() => {
            Assert.That(ingredient.AssociatedInstructions.Contains(oldInstruction), Is.False);
            Assert.That(ingredient.AssociatedInstructions.Contains(newInstruction), Is.True);
        });
    }

    [Test]
    public void TestInstructionAddIngredient() {
        Instruction instruction = new("Stir");
        Ingredient ingredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);

        instruction.AddIngredient(ingredient);

        Assert.That(instruction.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedInstructions.Count));
    }

    [Test]
    public void TestInstructionRemoveIngredient() {
        Instruction instruction = new("Stir");
        Ingredient ingredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);

        ingredient.AddInstruction(instruction);
        instruction.RemoveIngredient(ingredient);

        Assert.That(instruction.AssociatedIngredients, Has.Count.EqualTo(ingredient.AssociatedInstructions.Count));
    }

    [Test]
    public void TestInstructionEditIngredient() {
        Instruction instruction = new("Stir");
        Ingredient newIngredient = new("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient oldIngredient = new("Crystal", 201, "C₁₀H₁₅N", StateAttribute.Solid);

        instruction.AddIngredient(oldIngredient);

        Assert.That(instruction.AssociatedIngredients.Contains(oldIngredient), Is.True);

        instruction.EditIngredient(oldIngredient, newIngredient);

        Assert.Multiple(() => {
            Assert.That(instruction.AssociatedIngredients.Contains(oldIngredient), Is.False);
            Assert.That(instruction.AssociatedIngredients.Contains(newIngredient), Is.True);
        });
    }

    [Test]
    public void TestChemistAddSupervisedChemist() {
        Chemist chemist = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist supervisedChemist = new("Jesse", 10, ["Do not steal meth."], 120);

        chemist.AddSelfAssociation(supervisedChemist);

        Assert.Multiple(() => {
            Assert.That(chemist.SupervisedChemists.Contains(supervisedChemist), Is.True);
            Assert.That(supervisedChemist.Supervisor, Is.EqualTo(chemist));
        });
    }

    [Test]
    public void TestChemistRemoveSupervisedChemist() {
        Chemist chemist = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist supervisedChemist = new("Jesse", 10, ["Do not steal meth."], 120);

        chemist.AddSelfAssociation(supervisedChemist);
        chemist.RemoveSelfAssociation(supervisedChemist);

        Assert.Multiple(() => {
            Assert.That(chemist.SupervisedChemists.Contains(supervisedChemist), Is.False);
            Assert.That(supervisedChemist.Supervisor, Is.Null);
        });
    }

    [Test]
    public void TestChemistEditSupervisedChemist() {
        Chemist chemist = new("Walter", 10, ["Do not steal meth."], 1000);
        Chemist oldSupervisedChemist = new("Jesse", 10, ["Do not steal meth."], 120);
        Chemist newSupervisedChemist = new("Jesse", 9, ["Do not steal meth."], 120);

        chemist.AddSelfAssociation(oldSupervisedChemist);

        Assert.Multiple(() => {
            Assert.That(chemist.SupervisedChemists.Contains(oldSupervisedChemist), Is.True);
            Assert.That(oldSupervisedChemist.Supervisor, Is.EqualTo(chemist));
        });

        chemist.EditSelfAssociation(oldSupervisedChemist, newSupervisedChemist);

        Assert.Multiple(() => {
            Assert.That(chemist.SupervisedChemists.Contains(oldSupervisedChemist), Is.False);
            Assert.That(chemist.SupervisedChemists.Contains(newSupervisedChemist), Is.True);
            Assert.That(newSupervisedChemist.Supervisor, Is.EqualTo(chemist));
        });
    }

    [Test]
    public void TestRecipeAddInstruction() {
        Recipe recipe = new();
        Instruction instruction = new("Stir");

        recipe.AddCompositionAssociation(instruction);

        Assert.That(recipe.AssociatedInstructions.Contains(instruction), Is.True);
        Assert.That(instruction.AssociatedRecipe, Is.EqualTo(recipe));
    }

    [Test]
    public void TestRecipeRemoveInstruction() {
        Recipe recipe = new();
        Instruction instruction = new("Stir");

        recipe.AddCompositionAssociation(instruction);
        recipe.RemoveCompositionAssociation(instruction);

        Assert.Multiple(() => {
            Assert.That(recipe.AssociatedInstructions.Contains(instruction), Is.False);
            Assert.That(instruction.AssociatedRecipe, Is.Null);
        });
    }

    [Test]
    public void TestRecipeEditInstruction() {
        Recipe recipe = new();
        Instruction oldInstruction = new("Stir");
        Instruction newInstruction = new("Combine");

        recipe.AddCompositionAssociation(oldInstruction);

        Assert.That(recipe.AssociatedInstructions.Contains(oldInstruction), Is.True);

        recipe.EditCompositionAssociation(oldInstruction, newInstruction);

        Assert.Multiple(() => {
            Assert.That(recipe.AssociatedInstructions.Contains(oldInstruction), Is.False);
            Assert.That(recipe.AssociatedInstructions.Contains(newInstruction), Is.True);
        });
    }

    [Test]
    public void TestInstructionAddRecipe() {
        Instruction instruction = new("Stir");
        Recipe recipe = new();

        instruction.AddRecipe(recipe);

        Assert.Multiple(() => {
            Assert.That(instruction.AssociatedRecipe, Is.EqualTo(recipe));
            Assert.That(recipe.AssociatedInstructions.Contains(instruction), Is.True);
        });
    }

    [Test]
    public void TestInstructionRemoveRecipe() {
        Instruction instruction = new("Stir");
        Recipe recipe = new();

        instruction.AddRecipe(recipe);
        instruction.RemoveRecipe(recipe);

        Assert.Multiple(() => {
            Assert.That(instruction.AssociatedRecipe, Is.Null);
            Assert.That(recipe.AssociatedInstructions.Contains(instruction), Is.False);
        });
    }

    [Test]
    public void TestInstructionEditRecipe() {
        Instruction instruction = new("Stir");
        Recipe newRecipe = new();
        Recipe oldRecipe = new();

        instruction.AddRecipe(oldRecipe);

        Assert.That(instruction.AssociatedRecipe, Is.EqualTo(oldRecipe));

        instruction.EditRecipe(oldRecipe, newRecipe);

        Assert.Multiple(() => {
            Assert.That(instruction.AssociatedRecipe, Is.EqualTo(newRecipe));
            Assert.That(instruction.AssociatedRecipe, Is.Not.EqualTo(oldRecipe));
        });
    }

    [Test]
    public void TestDistributorAddDeal() {
        Distributor distributor = new("Mike", 10, ["Be polite."], 15);
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        string customerId = "001";

        distributor.AddDeal(deal, customerId);

        Assert.That(distributor.AssociatedDeals[customerId], Does.Contain(deal));
    }

    [Test]
    public void TestDistributorRemoveCustomer() {
        Distributor distributor = new("Mike", 10, ["Be polite."], 15);
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        string customerId = "001";

        distributor.AddDeal(deal, customerId);
        distributor.RemoveDeal(deal, customerId);

        Assert.That(distributor.AssociatedDeals.ContainsKey(customerId), Is.False);
    }

    [Test]
    public void TestDistributorEditCustomer() {
        Distributor distributor = new("Mike", 10, ["Be polite."], 15);
        Deal oldDeal = new(new DateTime(2024, 12, 11), 500, null);
        Deal newDeal = new(new DateTime(2024, 12, 11), 501, null);
        string customerId = "001";

        distributor.AddDeal(oldDeal, customerId);

        Assert.That(distributor.AssociatedDeals[customerId], Does.Contain(oldDeal));

        distributor.EditDeal(oldDeal, newDeal, customerId, customerId);

        Assert.Multiple(() => {
            Assert.That(distributor.AssociatedDeals[customerId], Does.Not.Contain(oldDeal));
            Assert.That(distributor.AssociatedDeals[customerId], Does.Contain(newDeal));
        });
    }

    [Test]
    public void TestDealAddDistributor() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Distributor distributor = new("Mike", 10, ["Be polite."], 15);
        string customerId = "001";

        deal.AddDistributor(distributor, customerId);

        Assert.That(deal.AssociatedDistributor, Is.EqualTo(distributor));
    }

    [Test]
    public void TestDealRemoveDistributor() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Distributor distributor = new("Mike", 10, ["Be polite."], 15);
        string customerId = "001";

        deal.AddDistributor(distributor, customerId);
        deal.RemoveDistributor(distributor, customerId);

        Assert.That(deal.AssociatedDistributor, Is.Null);
    }

    [Test]
    public void TestDealEditDistributor() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Distributor newDistributor = new("Mike", 9, ["Be polite."], 15);
        Distributor oldDistributor = new("Mike", 10, ["Be polite."], 15);
        string customerId = "001";

        deal.AddDistributor(oldDistributor, customerId);

        Assert.That(deal.AssociatedDistributor, Is.EqualTo(oldDistributor));

        deal.EditDistributor(oldDistributor, newDistributor, customerId, customerId);

        Assert.Multiple(() => {
            Assert.That(deal.AssociatedDistributor, Is.Not.EqualTo(oldDistributor));
            Assert.That(deal.AssociatedDistributor, Is.EqualTo(newDistributor));
        });
    }

    [Test]
    public void TestCustomerAddDeal() {
        Customer customer = new();
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);

        customer.AddDeal(deal);

        Assert.That(customer.AssociatedDeals.Contains(deal), Is.True);
    }

    [Test]
    public void TestCustomerRemoveDeal() {
        Customer customer = new();
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);

        customer.AddDeal(deal);
        customer.RemoveDeal(deal);

        Assert.That(customer.AssociatedDeals.Contains(deal), Is.False);
    }

    [Test]
    public void TestCustomerEditDeal() {
        Customer customer = new();
        Deal oldDeal = new(new DateTime(2024, 12, 11), 500, null);
        Deal newDeal = new(new DateTime(2024, 12, 11), 501, null);

        customer.AddDeal(oldDeal);

        Assert.That(customer.AssociatedDeals.Contains(oldDeal), Is.True);

        customer.EditDeal(oldDeal, newDeal);

        Assert.Multiple(() => {
            Assert.That(customer.AssociatedDeals.Contains(oldDeal), Is.False);
            Assert.That(customer.AssociatedDeals.Contains(newDeal), Is.True);
        });
    }

    [Test]
    public void TestDealAddCustomer() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Customer customer = new();

        deal.AddCustomer(customer);

        Assert.That(deal.AssociatedCustomer, Is.EqualTo(customer));
    }

    [Test]
    public void TestDealRemoveCustomer() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Customer customer = new();

        deal.AddCustomer(customer);
        deal.RemoveCustomer(customer);

        Assert.That(deal.AssociatedCustomer, Is.Null);
    }

    [Test]
    public void TestDealEditCustomer() {
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);
        Customer newCustomer = new();
        Customer oldCustomer = new();

        deal.AddCustomer(oldCustomer);

        Assert.That(deal.AssociatedCustomer, Is.EqualTo(oldCustomer));

        deal.EditCustomer(oldCustomer, newCustomer);

        Assert.Multiple(() => {
            Assert.That(deal.AssociatedCustomer, Is.Not.EqualTo(oldCustomer));
            Assert.That(deal.AssociatedCustomer, Is.EqualTo(newCustomer));
        });
    }

    [TearDown]
    public void TearDown() {
        Product.Clear();
    }
}