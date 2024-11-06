using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestsBusinessLogic
{
        [Test]
        public void Constructor_ValidInput()
        {
            string name = "Walter White";
            int trustLevel = 10;
            var rules = new List<string> { "No half-measures", "Protect the formula" };
            int poundsCooked = 100;

            var chemist = new Chemist(name, trustLevel, rules, poundsCooked);

            Assert.AreEqual(name, chemist.Name);
            Assert.AreEqual(trustLevel, chemist.TrustLevel);
            Assert.AreEqual(rules, chemist.RulesToFollow);
            Assert.AreEqual(poundsCooked, chemist.PoundsCooked);
            Assert.Contains(chemist, Chemist._chemists.ToList());
        }

        [Test]
        public void Constructor_InvalidPoundsCookedValue()
        {
            string name = "Jesse Pinkman";
            int trustLevel = 7;
            var rules = new List<string> { "Loyalty to the crew", "Avoid police attention" };
            int poundsCooked = -10; 

            Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
                "Expected Exceotion for poundsCooked < 0");
        }

        [Test]
        public void Constructor_InvalidName()
        {
            string name = "   "; 
            int trustLevel = 8;
            var rules = new List<string> { "Maintain secrecy", "Protect the lab" };
            int poundsCooked = 50;

            Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
                "Expected ArgumentException for empty name");
        }

        [Test]
        public void Constructor_InvalidRules()
        {
            string name = "Gale Boetticher";
            int trustLevel = 9;
            IEnumerable<string> rules = null; 
            int poundsCooked = 75;

            Assert.Throws<ArgumentException>(() => new Chemist(name, trustLevel, rules, poundsCooked),
                "Expected ArgumentException for null rules collection.");
        }
}