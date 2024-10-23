using ConsoleApp;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

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
        public void TestDistributorConstructor() {
            string[] rulesToFollow = ["Don't kill anyone (Optional)."];
            Distributor distributor = new Distributor("Danny", 9, rulesToFollow);

            Assert.Multiple(() => {
                Assert.That(distributor.Name, Is.EqualTo("Danny"));
                Assert.That(distributor.TrustLevel, Is.EqualTo(9));
                Assert.That(distributor.RulesToFollow, Is.EqualTo(rulesToFollow));
            });
        }

        [Test]
        public void TestCitizenConstructor() {
            string[] rulesToFollow = ["Don't kill anyone (Optional)."];
            Citizen citizen = new Citizen("Danny", 9, rulesToFollow);

            Assert.Multiple(() => {
                Assert.That(citizen.Name, Is.EqualTo("Danny"));
                Assert.That(citizen.TrustLevel, Is.EqualTo(9));
                Assert.That(citizen.RulesToFollow, Is.EqualTo(rulesToFollow));
            });
        }

        [Test]
        public void TestOfficialConstructor() {
            string[] rulesToFollow = ["Don't kill anyone (Optional)."];
            Official official = new Official("Danny", 9, rulesToFollow, 1);

            Assert.Multiple(() => {
                Assert.That(official.Name, Is.EqualTo("Danny"));
                Assert.That(official.TrustLevel, Is.EqualTo(9));
                Assert.That(official.RulesToFollow, Is.EqualTo(rulesToFollow));
                Assert.That(official.Rank, Is.EqualTo(1));
            });
        }

        [Test]
        public void TestCustomerConstructor() {
            Customer customer = new Customer();

            //int customerCount = Customer.GetCustomerCount();
            //Assert.That(customerCount, Is.EqualTo(1));
        }
        
        [Test]
        public void TestDealerConstructor() {
            Dealer dealer = new Dealer("Madelin", false);

            Assert.Multiple(() => {
                Assert.That(dealer.Territory, Is.EqualTo("Madelin"));
                Assert.That(dealer.CriminalRecord, Is.EqualTo(false));
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

        [Test]
        public void TestDistributor_CustomerConstructor() {
            DateTime dealStartDate = new DateTime(2024, 5, 20);
            DateTime dealEndDate = new DateTime(2024, 5, 21);

            Distributor_Customer distributor_Customer = new Distributor_Customer(dealStartDate, 15, dealEndDate);

            Assert.Multiple(() => {
                Assert.That(distributor_Customer.DealStartDate, Is.EqualTo(dealStartDate));
                Assert.That(distributor_Customer.AmountOfProduct, Is.EqualTo(15));
                Assert.That(distributor_Customer.DealEndDate, Is.EqualTo(dealEndDate));
            });
        }

        [Test]
        public void TestProductConstructor() {
            AddLevelAttribute addictivenessLevel = AddLevelAttribute.Strong;
            Product product = new Product("Meth", 15, 99, addictivenessLevel);

            Assert.Multiple(() => {
                Assert.That(product.Name, Is.EqualTo("Meth"));
                Assert.That(product.PricePerPound, Is.EqualTo(15));
                Assert.That(product.PurityPercentage, Is.EqualTo(99));
                Assert.That(product.AddictivenessLevel, Is.EqualTo(addictivenessLevel));
            });
        }

        [Test]
        public void TestLaboratoryConstructor() {
            Laboratory laboratory = new Laboratory("Madelin");

            Assert.That(laboratory.Location, Is.EqualTo("Madelin"));
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
        public void TestWarehouseConstructor() {
            Warehouse warehouse = new Warehouse("Madelin", 500);

            Assert.Multiple(() => {
                Assert.That(warehouse.Location, Is.EqualTo("Madelin"));
                Assert.That(warehouse.MaxCapacity, Is.EqualTo(500));
            });
        }

        [Test]
        public void TestRecipeConstructor() {
            Recipe recipe = new Recipe(8);

            Assert.That(recipe.Complexity, Is.EqualTo(8));
        }

        [Test]
        public void TestInstructionConstructor() {
            ActionAttribute actionAttribute = ActionAttribute.Stir;
            Instruction instruction = new Instruction(actionAttribute);

            Assert.That(instruction.Action, Is.EqualTo(actionAttribute));
        }

        [Test]
        public void TestIngredientConstructor() {
            StateAttribute stateAttribute = StateAttribute.Solid;
            Ingredient ingredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", stateAttribute);

            Assert.Multiple(() => {
                Assert.That(ingredient.Name, Is.EqualTo("Crystal"));
                Assert.That(ingredient.Price, Is.EqualTo(200));
                Assert.That(ingredient.ChemicalFormula, Is.EqualTo("C₁₀H₁₅N"));
                Assert.That(ingredient.State, Is.EqualTo(stateAttribute));
            });
        }

        [Test]
        public void TestSupplyChainConstructor() {
            SupplyChain supplyChain = new SupplyChain("Madelin", 6);

            Assert.Multiple(() => {
                Assert.That(supplyChain.Name, Is.EqualTo("Madelin"));
                Assert.That(supplyChain.TransitionTime, Is.EqualTo(6));
            });
        }
    }
}