using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestExceptionCases {
    [Test]
    public void TestRemoveProductThrowsExceptionWhenProductNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, 500, AddLevelAttribute.Strong);

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveProduct(product));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Product not found."));
    }


    [Test]
    public void TestRemoveWarehouseThrowsExceptionWhenWarehouseNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, 500, AddLevelAttribute.Strong);

        var ex = Assert.Throws<ArgumentException>(() => product.RemoveWarehouse(warehouse));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Warehouse not found."));
    }


    [Test]
    public void TestRemoveProductInternallyThrowsExceptionWhenProductNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, 500, AddLevelAttribute.Strong);
        Product nonExistentProduct = new("NonExistent", 1000, 500, AddLevelAttribute.Strong);

        warehouse.AddProduct(product);

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveProductInternally(nonExistentProduct));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Product not found."));
    }


    [Test]
    public void TestRemoveWarehouseInternallyThrowsExceptionWhenWarehouseNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Product product = new("Meth", 1000, 500, AddLevelAttribute.Strong);
        Warehouse nonExistentWarehouse = new("NonExistent Location", 1000);

        product.AddWarehouseInternally(warehouse);

        var ex = Assert.Throws<ArgumentException>(() => product.RemoveWarehouseInternally(nonExistentWarehouse));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Warehouse not found."));
    }

    [Test]
    public void TestRemoveDistributorInternallyThrowsExceptionWhenDistributorNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Distributor distributor = new("John", 1000, new List<string> { "Rule1" }, 10);

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveDistributorInternally(distributor));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Distributor not found"));
    }

    [Test]
    public void TestRemoveDelivererInternallyThrowsExceptionWhenDelivererNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Deliverer deliverer = new("Alice", 1000, new List<string> { "Rule1" });

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveDelivererInternally(deliverer));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Deliverer not found."));
    }

    [Test]
    public void TestRemoveDelivererThrowsExceptionWhenDelivererNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Deliverer deliverer = new("Alice", 1000, new List<string> { "Rule1" });

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveDeliverer(deliverer));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Deliverer not found."));
    }
    [Test]
    public void TestRemoveDistributorThrowsExceptionWhenDistributorNotFound() {
        Warehouse warehouse = new("Warsaw, Praga", 1000);
        Distributor distributor = new("John", 1000, new List<string> { "Rule1" }, 10);

        var ex = Assert.Throws<ArgumentException>(() => warehouse.RemoveDistributor(distributor));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Distributor not found"));
    }

    [Test]
    public void TestRemoveIngredientInternallyThrowsExceptionWhenIngredientNotFound() {
        SupplyChain supplyChain = new("Supply Chain 1", 10);
        Ingredient ingredient = new("Ingredient 1", 5, "H2O", StateAttribute.Liquid);

        var ex = Assert.Throws<ArgumentException>(() => supplyChain.RemoveIngredientInternally(ingredient));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Ingredient not found."));
    }

    [Test]
    public void TestRemoveIngredientThrowsExceptionWhenIngredientNotFound() {
        SupplyChain supplyChain = new("Supply Chain 1", 10);
        Ingredient ingredient = new("Ingredient 1", 5, "H2O", StateAttribute.Liquid);

        var ex = Assert.Throws<ArgumentException>(() => supplyChain.RemoveIngredient(ingredient));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Ingredient not found."));
    }

    [Test]
    public void TestRemoveProductInternallyThrowsExceptionWhenProductNotFoundRecipe() {
        Recipe recipe = new("Blue Methamphetamine");
        Product product = new("Meth", 1000, 500, AddLevelAttribute.Strong);

        var ex = Assert.Throws<ArgumentException>(() => recipe.RemoveProductInternally(product));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Product not found exception."));
    }


    [Test]
    public void TestAddCompositionAssociationThrowsExceptionWhenInstructionAlreadyHasRecipe() {
        Recipe recipe = new("Blue Methamphetamine");
        Instruction instruction = new("Instruction 1");
        instruction.AddRecipe(new Recipe("Crystal Methamphetamine"));

        var ex = Assert.Throws<ArgumentException>(() => recipe.AddCompositionAssociation(instruction));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Instruction is already associated with a recipe."));
    }


    [Test]
    public void TestRemoveCompositionAssociationThrowsExceptionWhenInstructionNotAssociatedWithRecipe() {
        Recipe recipe = new("Blue Methamphetamine");
        Instruction instruction = new("Instruction 1");

        var ex = Assert.Throws<ArgumentException>(() => recipe.RemoveCompositionAssociation(instruction));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Instruction is not associated with a recipe."));
    }

    [Test]
    public void TestRemoveDelivererInternallyThrowsExceptionWhenDelivererNotFoundProduct() {
        Product product = new("Product 1", 10.0, 100, AddLevelAttribute.Strong);
        Deliverer deliverer = new("Alice", 1000, new List<string> { "Rule1" });

        var ex = Assert.Throws<ArgumentException>(() => product.RemoveDelivererInternally(deliverer));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Deliverer not found."));
    }

    [Test]
    public void TestRemoveProductInternallyThrowsExceptionWhenProductNotFoundLab() {
        Laboratory lab = new("Lab 1");
        Product product = new("Product 1", 10.0, 100, AddLevelAttribute.Strong);

        var ex = Assert.Throws<ArgumentException>(() => lab.RemoveProductInternally(product));
        Assert.That(ex!.Message, Is.EqualTo("Product not found."));
    }

    [Test]
    public void TestRemoveIngredientInternallyThrowsExceptionWhenIngredientNotFoundLab() {
        Laboratory lab = new("Lab 1");
        Ingredient ingredient = new("Ingredient 1", 10, "H2O", StateAttribute.Liquid);

        var ex = Assert.Throws<ArgumentException>(() => lab.RemoveIngredientInternally(ingredient));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Ingredient not found."));
    }

    [Test]
    public void TestAddCompositionAssociationThrowsExceptionWhenEquipmentAlreadyAttached() {
        Laboratory lab = new("Lab 1");
        string type = "Type1";
        string name = "Equipment1";
        string model = "Model1";

        Equipment equipment = new Equipment(type, name, model);

        lab.AddCompositionAssociation(equipment);

        var ex = Assert.Throws<ArgumentException>(() => lab.AddCompositionAssociation(equipment));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Equipment is already attached to the lab."));
    }

    [Test]
    public void TestRemoveCompositionAssociationThrowsExceptionWhenEquipmentNotAttached() {
        Laboratory lab = new("Lab 1");
        string type = "Type1";
        string name = "Equipment1";
        string model = "Model1";

        Equipment equipment = new Equipment(type, name, model);

        var ex = Assert.Throws<ArgumentException>(() => lab.RemoveCompositionAssociation(equipment));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Equipment has not been attached to the lab yet."));
    }

    [Test]
    public void TestRemoveIngredientInternallyThrowsExceptionWhenIngredientNotFoundInstruction() {
        var instruction = new Instruction("Stir the mixture");
        var ingredient = new Ingredient("Salt", 5, "NaCl", StateAttribute.Liquid);

        var ex = Assert.Throws<ArgumentException>(() => instruction.RemoveIngredientInternally(ingredient));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo("Ingredient not found."));
    }


}