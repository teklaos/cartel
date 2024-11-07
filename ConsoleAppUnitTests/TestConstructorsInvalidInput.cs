using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestConstructorsInvalidInput {
    [Test]
    public void ConstructorValidInput() {
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
    public void ConstructorInvalidName() {
        string name = "   "; 
        int trustLevel = 8;
        var rules = new List<string> {"Maintain secrecy.", "Protect the lab."};
        int poundsCooked = 50;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for an empty name.");
    }

    [Test]
    public void ConstructorInvalidTrustLevel() {
        string name = "Jesse Pinkman";
        int trustLevel = -1;
        var rules = new List<string> {"Loyalty to the crew.", "Avoid police attention."};
        int poundsCooked = 150;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative trust level.");
    }

    [Test]
    public void ConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string> rules = null; 
        int poundsCooked = 75;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for null rules to follow collection.");
    }
    
    [Test]
    public void ConstructorInvalidPoundsCooked() {
        string name = "Krazy-8";
        int trustLevel = 2;
        var rules = new List<string> {"Do not die.", "Do not kill Walter White with a glass shard."};
        int poundsCooked = -1;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative cooked pounds.");
    }
    
    [TearDown]
    public void TearDown() {
        var directory = Directory.GetCurrentDirectory();
        var files = Directory.GetFiles(directory, "*.json");
        var whitelistedFilenames = new List<string>() {
            "CartelMembers.json", "Chemists.json", "Citizens.json", "Dealers.json", "Deliverers.json", "Distributors.json",
            "DistributorsCustomers.json", "Equipment.json", "Ingredients.json", "Instructions.json", "Laboratories.json",
            "Officials.json", "Products.json", "Recipes.json", "SupplyChains.json", "Warehouses.json", "Wholesalers.json"
        };
        foreach (var file in files) {
            if (whitelistedFilenames.Contains(Path.GetFileName(file))) {
                File.Delete(file);
            }
        }
    }
}