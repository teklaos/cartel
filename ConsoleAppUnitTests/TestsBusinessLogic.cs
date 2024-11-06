using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestsBusinessLogic {
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
        Assert.Contains(chemist, Chemist._chemists.ToList());
    }

    [Test]
    public void ConstructorInvalidPoundsCookedValue() {
        string name = "Jesse Pinkman";
        int trustLevel = 7;
        var rules = new List<string> {"Loyalty to the crew.", "Avoid police attention."};
        int poundsCooked = -10;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for negative cooked pounds.");
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
    public void ConstructorInvalidRules() {
        string name = "Gale Boetticher";
        int trustLevel = 9;
        IEnumerable<string> rules = null; 
        int poundsCooked = 75;

        Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
            "Expected ArgumentException for null rules to follow collection.");
    }
}