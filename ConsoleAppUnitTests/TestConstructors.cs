using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestConstructors {
    [Test]
    public void TestChemistConstructor() {
        string[] rulesToFollow = ["Do not talk about the cartel."];
        Chemist chemist = new Chemist("Gale", 10, rulesToFollow, 72);

        Assert.Multiple(() => {
            Assert.That(chemist.Name, Is.EqualTo("Gale"));
            Assert.That(chemist.TrustLevel, Is.EqualTo(10));
            Assert.That(chemist.RulesToFollow, Is.EqualTo(rulesToFollow));
            Assert.That(chemist.PoundsCooked, Is.EqualTo(72));
        });
    }

    [Test]
    public void TestCitizenConstructor() {
        string[] rulesToFollow = ["Do not kill anyone (optional)."];
        Citizen citizen = new Citizen("Danny", 9, rulesToFollow, "Cashier", 3);

        Assert.Multiple(() => {
            Assert.That(citizen.Name, Is.EqualTo("Danny"));
            Assert.That(citizen.TrustLevel, Is.EqualTo(9));
            Assert.That(citizen.RulesToFollow, Is.EqualTo(rulesToFollow));
            Assert.That(citizen.Occupation, Is.EqualTo("Cashier"));
            Assert.That(citizen.SecurityLevel, Is.EqualTo(3));
        });
    }

    [Test]
    public void TestCustomerConstructor() {
        Customer customer = new Customer();

        Assert.That(customer, Is.Not.Null);
    }

    [Test]
    public void TestDealerConstructor() {
        string[] criminalRecord = ["Possession of Controlled Substance (Cocaine)."];
        Dealer dealer = new Dealer("Madelyn", criminalRecord);

        Assert.Multiple(() => {
            Assert.That(dealer.Territory, Is.EqualTo("Madelyn"));
            Assert.That(dealer.CriminalRecord, Is.EqualTo(criminalRecord));
        });
    }

    [Test]
    public void TestDelivererConstructor() {
        string[] rulesToFollow = ["Do not talk about the cartel."];
        Deliverer deliverer = new Deliverer("Mike", 9, rulesToFollow);

        Assert.Multiple(() => {
            Assert.That(deliverer.Name, Is.EqualTo("Mike"));
            Assert.That(deliverer.TrustLevel, Is.EqualTo(9));
            Assert.That(deliverer.RulesToFollow, Is.EqualTo(rulesToFollow));
        });
    }

    [Test]
    public void TestDistributorConstructor() {
        string[] rulesToFollow = ["Do not kill anyone (optional)."];
        Distributor distributor = new Distributor("Danny", 9, rulesToFollow, 100);

        Assert.Multiple(() => {
            Assert.That(distributor.Name, Is.EqualTo("Danny"));
            Assert.That(distributor.TrustLevel, Is.EqualTo(9));
            Assert.That(distributor.RulesToFollow, Is.EqualTo(rulesToFollow));
            Assert.That(distributor.DealsMade, Is.EqualTo(100));
        });
    }

    [Test]
    public void TestDistributorCustomerConstructor() {
        DateTime dealStartDate = new DateTime(2024, 5, 20);
        DateTime dealEndDate = new DateTime(2024, 5, 21);

        DistributorCustomer distributorCustomer = new DistributorCustomer(dealStartDate, 15, dealEndDate);

        Assert.Multiple(() => {
            Assert.That(distributorCustomer.DealStartDate, Is.EqualTo(dealStartDate));
            Assert.That(distributorCustomer.PoundsOfProduct, Is.EqualTo(15));
            Assert.That(distributorCustomer.DealEndDate, Is.EqualTo(dealEndDate));
        });
    }

    [Test]
    public void TestEquipmentConstructor() {
        Equipment equipment = new Equipment("Bottle", "Danny", "3000");

        Assert.Multiple(() => {
            Assert.That(equipment.Type, Is.EqualTo("Bottle"));
            Assert.That(equipment.Name, Is.EqualTo("Danny"));
            Assert.That(equipment.Model, Is.EqualTo("3000"));
        });
    }

    [Test]
    public void TestIngredientConstructor() {
        StateAttribute stateAttribute = StateAttribute.Solid;
        Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", stateAttribute);

        Assert.Multiple(() => {
            Assert.That(ingredient.Name, Is.EqualTo("Crystal"));
            Assert.That(ingredient.PricePerPound, Is.EqualTo(200));
            Assert.That(ingredient.ChemicalFormula, Is.EqualTo("C₁₀H₁₅N"));
            Assert.That(ingredient.State, Is.EqualTo(stateAttribute));
        });
    }

    [Test]
    public void TestInstructionConstructor() {
        Instruction instruction = new Instruction("Stir");

        Assert.That(instruction.Action, Is.EqualTo("Stir"));
    }

    [Test]
    public void TestLaboratoryConstructor() {
        Laboratory laboratory = new Laboratory("Madelyn");

        Assert.That(laboratory.Location, Is.EqualTo("Madelyn"));
    }

    [Test]
    public void TestOfficialConstructor() {
        string[] rulesToFollow = ["Do not kill anyone (optional)."];
        Official official = new Official("Danny", 9, rulesToFollow, "Vice President", "Ministry of Foreign Affairs");

        Assert.Multiple(() => {
            Assert.That(official.Name, Is.EqualTo("Danny"));
            Assert.That(official.TrustLevel, Is.EqualTo(9));
            Assert.That(official.RulesToFollow, Is.EqualTo(rulesToFollow));
            Assert.That(official.Position, Is.EqualTo("Vice President"));
            Assert.That(official.Department, Is.EqualTo("Ministry of Foreign Affairs"));
        });
    }

    [Test]
    public void TestProductConstructor() {
        AddLevelAttribute addictivenessLevel = AddLevelAttribute.Strong;
        Product product = new Product("Meth", 15, 15000, addictivenessLevel);

        Assert.Multiple(() => {
            Assert.That(product.Name, Is.EqualTo("Meth"));
            Assert.That(product.Weight, Is.EqualTo(15));
            Assert.That(product.PricePerPound, Is.EqualTo(15000));
            // Assuming that ChemistPoundsCooked = 2000
            Assert.That(product.PurityPercentage, Is.EqualTo(90).Within(5));
            Assert.That(product.AddictivenessLevel, Is.EqualTo(addictivenessLevel));
        });
    }

    [Test]
    public void TestRecipeConstructor() {
        Recipe recipe = new Recipe();

        // Assuming that AmountOfInstructions = 55
        Assert.That(recipe.Complexity, Is.EqualTo(5));
    }

    [Test]
    public void TestSupplyChainConstructor() {
        SupplyChain supplyChain = new SupplyChain("Madelyn", 6);

        Assert.Multiple(() => {
            Assert.That(supplyChain.Name, Is.EqualTo("Madelyn"));
            Assert.That(supplyChain.TransitionTime, Is.EqualTo(6));
        });
    }

    [Test]
    public void TestWarehouseConstructor() {
        Warehouse warehouse = new Warehouse("Madelyn", 500);

        Assert.Multiple(() => {
            Assert.That(warehouse.Location, Is.EqualTo("Madelyn"));
            Assert.That(warehouse.MaxCapacity, Is.EqualTo(500));
        });
    }

    [Test]
    public void TestWholesalerConstructor() {
        Wholesaler wholesaler = new Wholesaler(15, 55);

        Assert.Multiple(() => {
            Assert.That(wholesaler.CommissionPercentage, Is.EqualTo(15));
            Assert.That(wholesaler.MonthlyCustomers, Is.EqualTo(55));
        });
    }
}