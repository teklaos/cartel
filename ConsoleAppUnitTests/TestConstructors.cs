using ConsoleApp;

namespace ConsoleAppUnitTests {
    public class TestConstructors {
        [Test]
        public void TestChemistConstructor() {
            string[] rulesToFollow = ["Do not talk about the cartel."];
            Chemist chemist = new Chemist("Gale", 10, rulesToFollow, 72);

            Assert.Multiple(() => {
                Assert.That(chemist.Name, Is.EqualTo("Gale"));
                Assert.That(chemist.TrustLevel, Is.EqualTo(10));
                Assert.That(chemist.RulesToFollow, Is.EqualTo(rulesToFollow));
                Assert.That(chemist.TimesCooked, Is.EqualTo(72));
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
        public void TestDistributorConstructor() {}

        [Test]
        public void TestCitizenConstructor() {}

        [Test]
        public void TestOfficialConstructor() {}

        [Test]
        public void TestCustomerConstructor() {}
        
        [Test]
        public void TestDealerConstructor() {}

        [Test]
        public void TestWholesalerConstructor() {}

        [Test]
        public void TestDistributor_CustomerConstructor() {}

        [Test]
        public void TestProductConstructor() {}

        [Test]
        public void TestLaboratoryConstructor() {}

        [Test]
        public void TestEquipmentConstructor() {}

        [Test]
        public void TestWarehouseConstructor() {}

        [Test]
        public void TestRecipeConstructor() {}

        [Test]
        public void TestInstructionConstructor() {}

        [Test]
        public void TestIngredientConstructor() {}

        [Test]
        public void TestSupplyChainConstructor() {}
    }
}