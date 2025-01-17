using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestConstructorsInvalidInput {
    [Test]
    public void ChemistConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 8;
        var rules = new List<string> { "Maintain secrecy.", "Protect the lab." };
        int poundsCooked = 50;
        string occupation = "Teacher";
        int securityLevel = 2;

        Assert.Throws<ArgumentException>(() =>
            new Chemist(name, trustLevel, rules, poundsCooked, occupation, securityLevel)
        );
    }

    [Test]
    public void ChemistConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> { "Loyalty to the crew.", "Avoid police attention." };
        int poundsCooked = 150;
        string occupation = "N/A";
        int securityLevel = 0;

        Assert.Throws<ArgumentException>(() =>
            new Chemist(name, trustLevel, rules, poundsCooked, occupation, securityLevel)
        );
    }

    [Test]
    public void ChemistConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IList<string>? rules = null;
        int poundsCooked = 75;
        string occupation = "Laboratory Assistant";
        int securityLevel = 5;

        Assert.Throws<ArgumentException>(() =>
            new Chemist(name, trustLevel, rules!, poundsCooked, occupation, securityLevel)
        );
    }

    [Test]
    public void ChemistConstructorInvalidPoundsCooked() {
        string name = "Krazy-8";
        int trustLevel = 2;
        var rules = new List<string> { "Do not die.", "Do not kill Walter White with a glass shard." };
        int poundsCooked = -1;
        string occupation = "Distributor";
        int securityLevel = 3;

        Assert.Throws<ArgumentException>(() =>
            new Chemist(name, trustLevel, rules, poundsCooked, occupation, securityLevel)
        );
    }

    [Test]
    public void CitizenConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "Cashier";
        int securityLevel = 0;

        Assert.Throws<ArgumentException>(() =>
            new Citizen(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void CitizenConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "test";
        int securityLevel = 5;

        Assert.Throws<ArgumentException>(() =>
            new Citizen(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void CitizenConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IList<string>? rules = null;
        string occupation = "test";
        int securityLevel = 5;

        Assert.Throws<ArgumentException>(() =>
            new Citizen(name, trustLevel, rules!, occupation, securityLevel)
        );
    }

    [Test]
    public void CitizenConstructorInvalidOccupation() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "   ";
        int securityLevel = 5;

        Assert.Throws<ArgumentException>(() =>
            new Citizen(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void CitizenConstructorInvalidSecurityLevel() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "test";
        int securityLevel = -1;

        Assert.Throws<ArgumentException>(() =>
            new Citizen(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void DealerConstructorInvalidTerritory() {
        string territory = "   ";
        var criminalRecord = new List<string> { "Convicted of murder.", "Convicted of robbery" };

        Assert.Throws<ArgumentException>(() =>
            new Dealer(territory, criminalRecord)
        );
    }

    [Test]
    public void DelivererConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "Deliverer";
        int securityLevel = 0;

        Assert.Throws<ArgumentException>(() =>
            new Deliverer(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void DelivererConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "Deliverer";
        int securityLevel = 0;

        Assert.Throws<ArgumentException>(() =>
            new Deliverer(name, trustLevel, rules, occupation, securityLevel)
        );
    }

    [Test]
    public void DelivererConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IList<string>? rules = null;
        string occupation = "Deliverer";
        int securityLevel = 0;

        Assert.Throws<ArgumentException>(() =>
            new Deliverer(name, trustLevel, rules!, occupation, securityLevel)
        );
    }

    [Test]
    public void DistributorConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = 10;
        string occupation = "Distributor";
        int securityLevel = 10;

        Assert.Throws<ArgumentException>(() =>
            new Distributor(name, trustLevel, rules, dealsMade, occupation, securityLevel)
        );
    }

    [Test]
    public void DistributorConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = 10;
        string occupation = "Distributor";
        int securityLevel = 10;

        Assert.Throws<ArgumentException>(() =>
            new Distributor(name, trustLevel, rules, dealsMade, occupation, securityLevel)
        );
    }

    [Test]
    public void DistributorConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IList<string>? rules = null;
        int dealsMade = 10;
        string occupation = "Distributor";
        int securityLevel = 10;

        Assert.Throws<ArgumentException>(() =>
            new Distributor(name, trustLevel, rules!, dealsMade, occupation, securityLevel)
        );
    }

    [Test]
    public void DistributorConstructorInvalidDealsMade() {
        string name = "Danny";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = -1;
        string occupation = "Distributor";
        int securityLevel = 10;

        Assert.Throws<ArgumentException>(() =>
            new Distributor(name, trustLevel, rules, dealsMade, occupation, securityLevel)
        );
    }

    [Test]
    public void DealConstructorInvalidDealStartDate() {
        DateTime invalidStartDate = new DateTime(1800, 5, 20);
        DateTime endDate = new DateTime(2024, 5, 21);

        int poundsOfProduct = 10;

        Assert.Throws<ArgumentException>(() =>
            new Deal(invalidStartDate, poundsOfProduct, endDate)
        );
    }

    [Test]
    public void DealConstructorInvalidDealEndDate() {
        DateTime startDate = new DateTime(2024, 5, 20);
        DateTime invalidEndDate = new DateTime(2025, 5, 21);

        int poundsOfProduct = 10;

        Assert.Throws<ArgumentException>(() =>
            new Deal(startDate, poundsOfProduct, invalidEndDate)
        );
    }

    [Test]
    public void DealConstructorInvalidPoundsOfProduct() {
        DateTime startDate = new DateTime(2024, 5, 20);
        DateTime endDate = new DateTime(2024, 5, 21);

        int invalidPoundsOfProduct = -10;

        Assert.Throws<ArgumentException>(() =>
            new Deal(startDate, invalidPoundsOfProduct, endDate)
        );
    }

    [Test]
    public void EquipmentConstructorInvalidType() {
        string type = "   ";
        string name = "CAT320";
        string model = "2021";

        Assert.Throws<ArgumentException>(() =>
            new Equipment(type, name, model)
        );
    }

    [Test]
    public void EquipmentConstructorInvalidName() {
        string type = "Excavator";
        string name = "   ";
        string model = "2021";

        Assert.Throws<ArgumentException>(() =>
            new Equipment(type, name, model)
        );
    }

    [Test]
    public void EquipmentConstructorInvalidModel() {
        string type = "Excavator";
        string name = "CAT320";
        string model = "   ";

        Assert.Throws<ArgumentException>(() =>
            new Equipment(type, name, model)
        );
    }

    [Test]
    public void IngredientConstructorInvalidName() {
        string name = "   ";
        int pricePerPound = 5;
        string chemicalFormula = "H₂O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() =>
            new Ingredient(name, pricePerPound, chemicalFormula, state)
        );
    }

    [Test]
    public void IngredientConstructorInvalidPrice() {
        string name = "Water";
        int pricePerPound = -1;
        string chemicalFormula = "H₂O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() =>
            new Ingredient(name, pricePerPound, chemicalFormula, state)
        );
    }

    [Test]
    public void IngredientConstructorInvalidChemicalFormula() {
        string name = "Water";
        int pricePerPound = 5;
        string chemicalFormula = "   ";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() =>
            new Ingredient(name, pricePerPound, chemicalFormula, state)
        );
    }

    [Test]
    public void LaboratoryConstructorInvalidLocation() {
        string location = "   ";

        Assert.Throws<ArgumentException>(() =>
            new Laboratory(location)
        );
    }

    [Test]
    public void OfficialConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law.", "Report to superiors." };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() =>
            new Official(name, trustLevel, rules, position, department)
        );
    }

    [Test]
    public void OfficialConstructorInvalidTrustLevel() {
        string name = "John Doe";
        int trustLevel = -1;
        var rules = new List<string> { "Follow the law.", "Report to superiors." };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() =>
            new Official(name, trustLevel, rules, position, department)
        );
    }

    [Test]
    public void OfficialConstructorInvalidRulesToFollow() {
        string name = "John Doe";
        int trustLevel = 8;
        IList<string>? rules = null;
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() =>
            new Official(name, trustLevel, rules!, position, department)
        );
    }

    [Test]
    public void OfficialConstructorInvalidPosition() {
        string name = "John Doe";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law", "Report to superiors" };
        string position = "   ";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() =>
            new Official(name, trustLevel, rules, position, department)
        );
    }

    [Test]
    public void OfficialConstructorInvalidDepartment() {
        string name = "John Doe";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "   ";

        Assert.Throws<ArgumentException>(() =>
            new Official(name, trustLevel, rules, position, department)
        );
    }

    [Test]
    public void ProductConstructorInvalidName() {
        string name = "   ";
        double weight = 100;
        int pricePerPound = 1000;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() =>
            new Product(name, weight, pricePerPound, addictivenessLevel)
        );
    }

    [Test]
    public void ProductConstructorInvalidWeight() {
        string name = "Cocaine";
        double weight = -10;
        int pricePerPound = 1000;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() =>
            new Product(name, weight, pricePerPound, addictivenessLevel)
        );
    }

    [Test]
    public void ProductConstructorInvalidPricePerPound() {
        string name = "Cocaine";
        double weight = 100;
        int pricePerPound = -100;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() =>
            new Product(name, weight, pricePerPound, addictivenessLevel)
        );
    }

    [Test]
    public void SupplyChainConstructorInvalidName() {
        string name = "   ";
        int transitionTime = 10;

        Assert.Throws<ArgumentException>(() =>
            new SupplyChain(name, transitionTime)
        );
    }

    [Test]
    public void SupplyChainConstructorInvalidTransitionTime() {
        string name = "Global Supply Chain";
        int transitionTime = -5;

        Assert.Throws<ArgumentException>(() =>
            new SupplyChain(name, transitionTime)
        );
    }

    [Test]
    public void WarehouseConstructorInvalidLocation() {
        string location = "   ";
        int maxCapacity = 1000;

        Assert.Throws<ArgumentException>(() =>
            new Warehouse(location, maxCapacity)
        );
    }

    [Test]
    public void WarehouseConstructorInvalidMaxCapacity() {
        string location = "New York";
        int maxCapacity = -500;

        Assert.Throws<ArgumentException>(() =>
            new Warehouse(location, maxCapacity)
        );
    }

    [Test]
    public void WholesalerConstructorInvalidCommissionPercentage() {
        double commissionPercentage = -10;
        int monthlyCustomers = 100;

        Assert.Throws<ArgumentException>(() =>
            new Wholesaler(commissionPercentage, monthlyCustomers)
        );
    }

    [Test]
    public void WholesalerConstructorInvalidMonthlyCustomers() {
        double commissionPercentage = 15.5;
        int monthlyCustomers = -5;

        Assert.Throws<ArgumentException>(() =>
            new Wholesaler(commissionPercentage, monthlyCustomers)
        );
    }
}