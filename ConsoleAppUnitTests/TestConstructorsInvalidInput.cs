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
        Assert.That(Chemist._chemists.ToList(), Does.Contain(chemist));
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
        Assert.That(Citizen._citizens.ToList(), Does.Contain(citizen));
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
        Assert.That(Dealer._dealers.ToList(), Does.Contain(dealer));
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
        Assert.That(Deliverer._deliverers.ToList(), Does.Contain(deliverer));
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
        Assert.That(Distributor._distributors.ToList(), Does.Contain(distributor));
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
        
        int amountOfProduct = 10;
        
        var distributorCustomer = new DistributorCustomer(dealStartDate, amountOfProduct, dealEndDate);

        Assert.Multiple(() => {
            Assert.That(distributorCustomer.DealStartDate, Is.EqualTo(dealStartDate));
            Assert.That(distributorCustomer.AmountOfProduct, Is.EqualTo(amountOfProduct));
            Assert.That(distributorCustomer.DealEndDate, Is.EqualTo(dealEndDate));
        });
        Assert.That(DistributorCustomer._distributorsCustomers.ToList(), Does.Contain(distributorCustomer));
    }
}