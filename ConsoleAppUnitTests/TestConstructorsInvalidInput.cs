using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestConstructorsInvalidInput {
    [Test]
    public void ChemistConstructorValidInput() {
        string name = "Walter White";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        int poundsCooked = 100;

        var chemist = new Chemist(name, trustLevel, rules, poundsCooked);

        Assert.Multiple(() => {
            Assert.That(chemist.Name, Is.EqualTo(name));
            Assert.That(chemist.TrustLevel, Is.EqualTo(trustLevel));
            Assert.That(chemist.RulesToFollow, Is.EqualTo(rules));
            Assert.That(chemist.PoundsCooked, Is.EqualTo(poundsCooked));
        });
        Assert.That(Chemist.Chemists.ToList(), Does.Contain(chemist));
    }

    [Test]
    public void ChemistConstructorInvalidName() {
        string name = "   "; 
        int trustLevel = 8;
        var rules = new List<string> {"Maintain secrecy.", "Protect the lab."};
        int poundsCooked = 50;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void ChemistConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> {"Loyalty to the crew.", "Avoid police attention."};
        int poundsCooked = 150;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void ChemistConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string> rules = null; 
        int poundsCooked = 75;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for null rules to follow collection.");
    }
    
    [Test]
    public void ChemistConstructorInvalidPoundsCooked() {
        string name = "Krazy-8";
        int trustLevel = 2;
        var rules = new List<string> {"Do not die.", "Do not kill Walter White with a glass shard."};
        int poundsCooked = -1;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative cooked pounds.");
    }

    [Test]
    public void CitizenConstructorValidInput() {
        string name = "Walter White";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        string occupation = "test";
        int securityLevel = 5;


        var citizen = new Citizen(name, trustLevel, rules, occupation, securityLevel);

        Assert.Multiple(() => {
            Assert.That(citizen.Name, Is.EqualTo(name));
            Assert.That(citizen.TrustLevel, Is.EqualTo(trustLevel));
            Assert.That(citizen.RulesToFollow, Is.EqualTo(rules));
            Assert.That(citizen.Occupation, Is.EqualTo(occupation));
            Assert.That(citizen.SecurityLevel, Is.EqualTo(securityLevel));
        });
        Assert.That(Citizen.Citizens.ToList(), Does.Contain(citizen));
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
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        string occupation = "test";
        int securityLevel = 5;


        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void CitizenConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string> rules = null; 
        string occupation = "test";
        int securityLevel = 5;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void CitizenConstructorInvalidOccupation() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        string occupation = "   ";
        int securityLevel = 5;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for null occupation.");
    }

    [Test]
    public void CitizenConstructorInvalidSecurityLevel() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        string occupation = "test";
        int securityLevel = -1;
        Assert.Throws<ArgumentException>(() => new Citizen(name, trustLevel, rules, occupation, securityLevel),
            "Expected ArgumentException for negative securityLevel.");
    }

    [Test]
    public void DealerConstructorValidInput() {
        string territory = "Madelyn";
        var criminalRecord = new List<string> {"Convicted of murder.", "Convicted of robbery"};

        var dealer = new Dealer(territory, criminalRecord);

        Assert.Multiple(() => {
            Assert.That(dealer.Territory, Is.EqualTo(territory));
            Assert.That(dealer.CriminalRecord, Is.EqualTo(criminalRecord));
        });
        Assert.That(Dealer.Dealers.ToList(), Does.Contain(dealer));
    }

    [Test]
    public void DealerConstructorInvalidTerritory() {
        string territory = "    ";
        var criminalRecord = new List<string> {"Convicted of murder.", "Convicted of robbery"};

        Assert.Throws<ArgumentException>(() => new Dealer(territory, criminalRecord),
            "Expected ArgumentException for null territory.");
    }

    [Test]
    public void DealerConstructorInvalidCriminalRecord() {
        string territory = "Madelyn";
        IEnumerable<string> criminalRecord = null;

         Assert.Throws<ArgumentException>(() => new Dealer(territory, criminalRecord),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void DelivererConstructorValidInput() {
        string name = "Danny";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};

        var deliverer = new Deliverer(name, trustLevel, rules);

        Assert.Multiple(() => {
            Assert.That(deliverer.Name, Is.EqualTo(name));
            Assert.That(deliverer.TrustLevel, Is.EqualTo(trustLevel));
            Assert.That(deliverer.RulesToFollow, Is.EqualTo(rules));
        });
        Assert.That(Deliverer.Deliverers.ToList(), Does.Contain(deliverer));
    }

    [Test]
    public void DelivererConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for null name.");
    }

    [Test]
    public void DelivererConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void DelivererConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IEnumerable<string> rules = null;

        Assert.Throws<ArgumentException>(() => new Deliverer(name, trustLevel, rules),
            "Expected ArgumentException for null rules to follow collection.");
    }

    [Test]
    public void DistributorConstructorValidInput() {
        string name = "Danny";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        int dealsMade = 10;

        var distributor = new Distributor(name, trustLevel, rules, dealsMade);

        Assert.Multiple(() => {
            Assert.That(distributor.Name, Is.EqualTo(name));
            Assert.That(distributor.TrustLevel, Is.EqualTo(trustLevel));
            Assert.That(distributor.RulesToFollow, Is.EqualTo(rules));
            Assert.That(distributor.DealsMade, Is.EqualTo(dealsMade));            
        });
        Assert.That(Distributor.Distributors.ToList(), Does.Contain(distributor));
    }

    [Test]
    public void DistributorConstructorInvalidName() {
        string name = "   ";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for null name.");
    }

    [Test]
    public void DistributorConstructorInvalidTrustLevel() {
        string name = "Danny";
        int trustLevel = -1;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for negative invalid trust level.");
    }

    [Test]
    public void DistributorConstructorInvalidRules() {
        string name = "Danny";
        int trustLevel = 10;
        IEnumerable<string> rules = null;
        int dealsMade = 10;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for null rules to follow the collection");
    }

    public void DistributorConstructorInvalidDealsMade() {
        string name = "Danny";
        int trustLevel = 10;
        var rules = new List<string> {"No half-measures.", "Protect the formula."};
        int dealsMade = -1;
    
        Assert.Throws<ArgumentException>(() => new Distributor(name, trustLevel, rules, dealsMade),
            "Expected ArgumentException for negative deals made");
    }

    [Test]
    public void DistributorCustomerConstructorValidInput() {
        DateTime dealStartDate = new DateTime(2024, 5, 20);
        DateTime dealEndDate = new DateTime(2024, 5, 21);     

        int poundsOfProduct = 10;

        var distributorCustomer = new DistributorCustomer(dealStartDate, poundsOfProduct, dealEndDate);

        Assert.Multiple(() => {
            Assert.That(distributorCustomer.DealStartDate, Is.EqualTo(dealStartDate));
            Assert.That(distributorCustomer.PoundsOfProduct, Is.EqualTo(poundsOfProduct));
            Assert.That(distributorCustomer.DealEndDate, Is.EqualTo(dealEndDate));
        });
        Assert.That(DistributorCustomer.DistributorsCustomers.ToList(), Does.Contain(distributorCustomer));
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
            "Expected ArgumentException for negative amount of product.");
    }

    [Test]
    public void EquipmentConstructorValidInput() {
        string type = "Excavator";
        string name = "CAT320";
        string model = "2021";

        var equipment = new Equipment(type, name, model);

        Assert.Multiple(() => {
            Assert.That(equipment.Type, Is.EqualTo(type));
            Assert.That(equipment.Name, Is.EqualTo(name));
            Assert.That(equipment.Model, Is.EqualTo(model));
        });
        Assert.That(Equipment.EquipmentList.ToList(), Does.Contain(equipment));
    }

    [Test]
    public void EquipmentConstructorInvalidType() {
        string type = "";
        string name = "CAT320";
        string model = "2021";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for null type.");
    }

    [Test]
    public void EquipmentConstructorInvalidName() {
        string type = "Excavator";
        string name = "";
        string model = "2021";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for null name.");
    }

    [Test]
    public void EquipmentConstructorInvalidModel() {
        string type = "Excavator";
        string name = "CAT320";
        string model = "";

        Assert.Throws<ArgumentException>(() => new Equipment(type, name, model),
            "Expected ArgumentException for null model.");
    }

    [Test]
    public void IngredientConstructorValidInput() {
        string name = "Water";
        int price = 5;
        string chemicalFormula = "H2O";
        StateAttribute state = StateAttribute.Liquid;

        var ingredient = new Ingredient(name, price, chemicalFormula, state);

        Assert.Multiple(() => {
            Assert.That(ingredient.Name, Is.EqualTo(name));
            Assert.That(ingredient.Price, Is.EqualTo(price));
            Assert.That(ingredient.ChemicalFormula, Is.EqualTo(chemicalFormula));
            Assert.That(ingredient.State, Is.EqualTo(state));
        });
        Assert.That(Ingredient.Ingredients.ToList(), Does.Contain(ingredient));
    }

    [Test]
    public void IngredientConstructorInvalidName() {
        string name = "";
        int price = 5;
        string chemicalFormula = "H2O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, price, chemicalFormula, state),
            "Expected ArgumentException for null name.");
    }

    [Test]
    public void IngredientConstructorInvalidPrice() {
        string name = "Water";
        int price = -1;
        string chemicalFormula = "H2O";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, price, chemicalFormula, state),
            "Expected ArgumentException for negative price.");
    }

    [Test]
    public void IngredientConstructorInvalidChemicalFormula() {
        string name = "Water";
        int price = 5;
        string chemicalFormula = "";
        StateAttribute state = StateAttribute.Liquid;

        Assert.Throws<ArgumentException>(() => new Ingredient(name, price, chemicalFormula, state),
            "Expected ArgumentException for null chemical formula.");
    }

    [Test]
    public void InstructionConstructorValidInput() {
        ActionAttribute action = ActionAttribute.Add;

        var instruction = new Instruction(action);

        Assert.That(instruction.Action, Is.EqualTo(action));

        Assert.That(Instruction.Instructions.ToList(), Does.Contain(instruction));
    }

    [Test]
    public void LaboratoryConstructorValidInput() {
        string location = "Paris";

        var laboratory = new Laboratory(location);

        Assert.That(laboratory.Location, Is.EqualTo(location));
        Assert.That(Laboratory.Laboratories.ToList(), Does.Contain(laboratory));
    }

    [Test]
    public void LaboratoryConstructorInvalidLocation() {
        string location = "";

        Assert.Throws<ArgumentException>(() => new Laboratory(location),
            "Expected ArgumentException for null location.");
    }

    [Test]
    public void OfficialConstructorValidInput() {
        string name = "John Doe";
        int trustLevel = 8;
        var rulesToFollow = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "Operations";

        var official = new Official(name, trustLevel, rulesToFollow, position, department);

        Assert.Multiple(() => {
            Assert.That(official.Name, Is.EqualTo(name));
            Assert.That(official.TrustLevel, Is.EqualTo(trustLevel));
            Assert.That(official.RulesToFollow, Is.EqualTo(rulesToFollow));
            Assert.That(official.Position, Is.EqualTo(position));
            Assert.That(official.Department, Is.EqualTo(department));
        });
        Assert.That(Official.Officials.ToList(), Does.Contain(official));
    }

    [Test]
    public void OfficialConstructorInvalidName() {
        string name = "";
        int trustLevel = 8;
        var rulesToFollow = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rulesToFollow, position, department),
            "Expected ArgumentException for invalid name.");
    }

    [Test]
    public void OfficialConstructorInvalidTrustLevel() {
        string name = "John Doe";
        int trustLevel = -1;
        var rulesToFollow = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rulesToFollow, position, department),
            "Expected ArgumentException for invalid trust level.");
    }

    [Test]
    public void OfficialConstructorInvalidRulesToFollow() {
        string name = "John Doe";
        int trustLevel = 8;
        IEnumerable<string> rulesToFollow = null;
        string position = "Manager";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rulesToFollow, position, department),
            "Expected ArgumentException for null rules to follow.");
    }

    [Test]
    public void OfficialConstructorInvalidPosition() {
        string name = "John Doe";
        int trustLevel = 8;
        var rulesToFollow = new List<string> { "Follow the law", "Report to superiors" };
        string position = "";
        string department = "Operations";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rulesToFollow, position, department),
            "Expected ArgumentException for invalid position.");
    }

    [Test]
    public void OfficialConstructorInvalidDepartment() {
        string name = "John Doe";
        int trustLevel = 8;
        var rulesToFollow = new List<string> { "Follow the law", "Report to superiors" };
        string position = "Manager";
        string department = "";

        Assert.Throws<ArgumentException>(() => new Official(name, trustLevel, rulesToFollow, position, department),
            "Expected ArgumentException for invalid department.");
    }

    [Test]
    public void ProductConstructorValidInput() {
        string name = "Cocaine";
        int pricePerPound = 1000;
        var addictivenessLevel = AddLevelAttribute.Strong;

        var product = new Product(name, pricePerPound, addictivenessLevel);

        Assert.Multiple(() => {
            Assert.That(product.Name, Is.EqualTo(name));
            Assert.That(product.PricePerPound, Is.EqualTo(pricePerPound));
            Assert.That(product.AddictivenessLevel, Is.EqualTo(addictivenessLevel));
        });
        Assert.That(Product.Products.ToList(), Does.Contain(product));
    }

    [Test]
    public void ProductConstructorInvalidName() {
        string name = "";
        int pricePerPound = 1000;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentException>(() => new Product(name, pricePerPound, addictivenessLevel),
            "Expected ArgumentException for invalid name.");
    }

    [Test]
    public void ProductConstructorInvalidPricePerPound() {
        string name = "Cocaine";
        int pricePerPound = -100;
        var addictivenessLevel = AddLevelAttribute.Strong;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Product(name, pricePerPound, addictivenessLevel),
            "Expected ArgumentOutOfRangeException for negative price per pound.");
    }

    [Test]
    public void SupplyChainConstructorValidInput() {
        string name = "Global Supply Chain";
        int transitionTime = 10;

        var supplyChain = new SupplyChain(name, transitionTime);

        Assert.Multiple(() => {
            Assert.That(supplyChain.Name, Is.EqualTo(name));
            Assert.That(supplyChain.TransitionTime, Is.EqualTo(transitionTime));
        });
        Assert.That(SupplyChain.SupplyChains.ToList(), Does.Contain(supplyChain));
    }

    [Test]
    public void SupplyChainConstructorInvalidName() {
        string name = "";
        int transitionTime = 10;

        Assert.Throws<ArgumentException>(() => new SupplyChain(name, transitionTime),
            "Expected ArgumentException for empty name.");
    }

    [Test]
    public void SupplyChainConstructorInvalidTransitionTime() {
        string name = "Global Supply Chain";
        int transitionTime = -5;

        Assert.Throws<ArgumentOutOfRangeException>(() => new SupplyChain(name, transitionTime),
            "Expected ArgumentOutOfRangeException for negative transition time.");
    }

    [Test]
    public void WarehouseConstructorValidInput() {
        string location = "New York";
        int maxCapacity = 1000;

        var warehouse = new Warehouse(location, maxCapacity);

        Assert.Multiple(() => {
            Assert.That(warehouse.Location, Is.EqualTo(location));
            Assert.That(warehouse.MaxCapacity, Is.EqualTo(maxCapacity));
        });
        Assert.That(Warehouse.Warehouses.ToList(), Does.Contain(warehouse));
    }

    [Test]
    public void WarehouseConstructorInvalidLocation() {
        string location = "";
        int maxCapacity = 1000;

        Assert.Throws<ArgumentException>(() => new Warehouse(location, maxCapacity),
            "Expected ArgumentException for empty location.");
    }

    [Test]
    public void WarehouseConstructorInvalidMaxCapacity() {
        string location = "New York";
        int maxCapacity = -500;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Warehouse(location, maxCapacity),
            "Expected ArgumentOutOfRangeException for negative maximum capacity.");
    }

    [Test]
    public void WholesalerConstructorValidInput() {
        double commissionPercentage = 15.5;
        int monthlyCustomers = 100;

        var wholesaler = new Wholesaler(commissionPercentage, monthlyCustomers);

        Assert.Multiple(() => {
            Assert.That(wholesaler.CommissionPercentage, Is.EqualTo(commissionPercentage));
            Assert.That(wholesaler.MonthlyCustomers, Is.EqualTo(monthlyCustomers));
        });
        Assert.That(Wholesaler.Wholesalers.ToList(), Does.Contain(wholesaler));
    }

    [Test]
    public void WholesalerConstructorInvalidCommissionPercentage() {
        double commissionPercentage = -10;
        int monthlyCustomers = 100;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Wholesaler(commissionPercentage, monthlyCustomers),
            "Expected ArgumentOutOfRangeException for negative commission percentage.");
    }

    [Test]
    public void WholesalerConstructorInvalidMonthlyCustomers() {
        double commissionPercentage = 15.5;
        int monthlyCustomers = -5;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Wholesaler(commissionPercentage, monthlyCustomers),
            "Expected ArgumentOutOfRangeException for negative monthly customers.");
    }
}