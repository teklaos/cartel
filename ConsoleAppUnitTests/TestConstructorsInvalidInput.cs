using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestConstructorsInvalidInput {
    [Test]
    public void ChemistConstructorInvalidName() {
        string name = "   "; 
        int trustLevel = 8;
        var rules = new List<string> { "Maintain secrecy.", "Protect the lab." };
        int poundsCooked = 50;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void ChemistConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> { "Loyalty to the crew.", "Avoid police attention." };
        int poundsCooked = 150;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void ChemistConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string>? rules = null; 
        int poundsCooked = 75;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for null rules to follow collection.");
    }
    
    [Test]
    public void ChemistConstructorInvalidPoundsCooked() {
        string name = "Krazy-8";
        int trustLevel = 2;
        var rules = new List<string> { "Do not die.", "Do not kill Walter White with a glass shard." };
        int poundsCooked = -1;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative cooked pounds.");
    }

    [Test]
    public void CitizenConstructorInvalidName() {
        string name = "   "; 
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        string occupation = "test";
        int securityLevel = 5;

        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void CitizenConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "test";
        int securityLevel = 5;


        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void CitizenConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string>? rules = null;
        string occupation = "test";
        int securityLevel = 5;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void CitizenConstructorInvalidOccupation() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "   ";
        int securityLevel = 5;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for an empty occupation.");
    }

    [Test]
    public void CitizenConstructorInvalidSecurityLevel() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        string occupation = "test";
        int securityLevel = -1;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for negative security level.");
    }

    [Test]
    public void DealerConstructorInvalidTerritory() {
        string territory = "   ";
        var criminalRecord = new List<string> { "Convicted of murder.", "Convicted of robbery" };

        Assert.Throws<ArgumentException>(() => new Dealer(territory, criminalRecord),
            "Expected ArgumentException for an empty territory.");
    }

    [Test]
    public void DelivererConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void DelivererConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void DelivererConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IEnumerable<string>? rules = null;

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void DistributorConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void DistributorConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void DistributorConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IEnumerable<string>? rules = null;
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void DistributorConstructorInvalidDealsMade() {
        string name = "Danny";
        int trustLevel = 10;
        var rules = new List<string> { "No half-measures.", "Protect the formula." };
        int dealsMade = -1;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for negative deals made.");
    }

    [Test]
    public void DistributorCustomerConstructorInvalidDealStartDate() {
        DateTime invalidDealStartDate = new DateTime(1800, 5, 20); 
        DateTime dealEndDate = new DateTime(2024, 5, 21);  

        int poundsOfProduct = 10;

        Assert.Throws<ArgumentException>(() => new DistributorCustomer(invalidDealStartDate, poundsOfProduct, dealEndDate),
            "Expected ArgumentException for deal start date earlier than year 1890.");
    }

    [Test]
    public void DistributorCustomerConstructorInvalidDealEndDate() {
        DateTime dealStartDate = new DateTime(2024, 5, 20);
        DateTime invalidDealEndDate = new DateTime(2025, 5, 21); 
    
        int poundsOfProduct = 10;

        Assert.Throws<ArgumentException>(() => new DistributorCustomer(dealStartDate, poundsOfProduct, invalidDealEndDate),
            "Expected ArgumentException for deal end date in the future.");
    }

    [Test]
    public void DistributorCustomerConstructorInvalidPoundsOfProduct() {
        DateTime dealStartDate = new DateTime(2024, 5, 20);
        DateTime dealEndDate = new DateTime(2024, 5, 21);     

        int invalidPoundsOfProduct = -10; 

        Assert.Throws<ArgumentException>(() => new DistributorCustomer(dealStartDate, invalidPoundsOfProduct, dealEndDate),
            "Expected ArgumentException for negative pounds of product.");
    }

    [Test]
    public void EquipmentConstructorInvalidType() {
        string type = "   ";
        string name = "CAT320";
        string model = "2021";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for an empty type.");
    }

    [Test]
    public void EquipmentConstructorInvalidName() {
        string type = "Excavator";
        string name = "   ";
        string model = "2021";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void EquipmentConstructorInvalidModel() {
        string type = "Excavator";
        string name = "CAT320";
        string model = "   ";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for an empty model.");
    }

    [Test]
    public void IngredientConstructorInvalidName() {
        string name = "   ";
        int pricePerPound = 5;
        string chemicalFormula = "H₂O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, pricePerPound, chemicalFormula, state),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void IngredientConstructorInvalidPrice() {
        string name = "Water";
        int pricePerPound = -1;
        string chemicalFormula = "H₂O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, pricePerPound, chemicalFormula, state),
            "Expected ArgumentException for negative price per pound.");
    }

    [Test]
    public void IngredientConstructorInvalidChemicalFormula() {
        string name = "Water";
        int pricePerPound = 5;
        string chemicalFormula = "   ";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, pricePerPound, chemicalFormula, state),
            "Expected ArgumentException for an empty chemical formula.");
    }

    [Test]
    public void LaboratoryConstructorInvalidLocation() {
        string location = "   ";

        Assert.Throws<ArgumentException>(() => new Laboratory(location),
            "Expected ArgumentException for an empty location.");
    }

    [Test]
    public void OfficialConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law.", "Report to superiors." };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rules, position, department),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void OfficialConstructorInvalidTrustLevel() {
        string name = "John Doe";
        int trustLevel = -1;
        var rules = new List<string> { "Follow the law.", "Report to superiors." };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rules, position, department),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void OfficialConstructorInvalidRulesToFollow() {
        string name = "John Doe";
        int trustLevel = 8;
        IEnumerable<string>? rules = null;
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rules, position, department),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void OfficialConstructorInvalidPosition() {
        string name = "John Doe";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law", "Report to superiors" };
        string position = "   ";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rules, position, department),
            "Expected ArgumentException for an empty position.");
    }

    [Test]
    public void OfficialConstructorInvalidDepartment() {
        string name = "John Doe";
        int trustLevel = 8;
        var rules = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "   ";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rules, position, department),
            "Expected ArgumentException for an empty department.");
    }

    [Test]
    public void ProductConstructorInvalidName() {
        string name = "   ";
        int pricePerPound = 1000;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() => new Product(name, pricePerPound, addictivenessLevel),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void ProductConstructorInvalidPricePerPound() {
        string name = "Cocaine";
        int pricePerPound = -100;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() => new Product(name, pricePerPound, addictivenessLevel),
            "Expected ArgumentException for negative price per pound.");
    }

    [Test]
    public void SupplyChainConstructorInvalidName() {
        string name = "   ";
        int transitionTime = 10;

        Assert.Throws<ArgumentException>(() => new SupplyChain(name, transitionTime),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void SupplyChainConstructorInvalidTransitionTime() {
        string name = "Global Supply Chain";
        int transitionTime = -5;

        Assert.Throws<ArgumentException>(() => new SupplyChain(name, transitionTime),
            "Expected ArgumentException for negative transition time.");
    }

    [Test]
    public void WarehouseConstructorInvalidLocation() {
        string location = "   ";
        int maxCapacity = 1000;

        Assert.Throws<ArgumentException>(() => new Warehouse(location, maxCapacity),
            "Expected ArgumentException for an empty location.");
    }

    [Test]
    public void WarehouseConstructorInvalidMaxCapacity() {
        string location = "New York";
        int maxCapacity = -500;

        Assert.Throws<ArgumentException>(() => new Warehouse(location, maxCapacity),
            "Expected ArgumentException for negative maximum capacity.");
    }

    [Test]
    public void WholesalerConstructorInvalidCommissionPercentage() {
        double commissionPercentage = -10;
        int monthlyCustomers = 100;

        Assert.Throws<ArgumentException>(() => new Wholesaler(commissionPercentage, monthlyCustomers),
            "Expected ArgumentException for negative commission percentage.");
    }

    [Test]
    public void WholesalerConstructorInvalidMonthlyCustomers() {
        double commissionPercentage = 15.5;
        int monthlyCustomers = -5;

        Assert.Throws<ArgumentException>(() => new Wholesaler(commissionPercentage, monthlyCustomers),
            "Expected ArgumentException for negative monthly customers.");
    }
}