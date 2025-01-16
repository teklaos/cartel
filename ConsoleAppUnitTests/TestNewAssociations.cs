using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class AdditionalCustomerTests {
    [Test]
    public void TestCustomerAddMultipleRoles() {
        Customer customer = new();
        string dealerTerritory = "West";
        double wholesalerCommission = 12.0;
        int wholesalerMonthlyCustomers = 15;

        customer.AddRole(CustomerRoleAttribute.Dealer, dealerTerritory);
        customer.AddRole(CustomerRoleAttribute.Wholesaler, wholesalerCommission, wholesalerMonthlyCustomers);

        Assert.Multiple(() => {
            Assert.That(customer.Roles, Does.Contain(CustomerRoleAttribute.Dealer));
            Assert.That(customer.Roles, Does.Contain(CustomerRoleAttribute.Wholesaler));
            Assert.That(customer.Territory, Is.EqualTo(dealerTerritory));
            Assert.That(customer.CommissionPercentage, Is.EqualTo(wholesalerCommission));
            Assert.That(customer.MonthlyCustomers, Is.EqualTo(wholesalerMonthlyCustomers));
        });
    }

    [Test]
    public void TestCustomerAddDealToNonExistentCustomer() {
        Customer customer = null;
        Deal deal = new(new DateTime(2024, 12, 11), 500, null);

        Assert.Throws<NullReferenceException>(() => customer.AddDeal(deal));
    }

    [Test]
    public void TestCustomerSerializationWithoutData() {
        Customer.Serialize();

        Assert.Multiple(() => {
            Assert.That(Customer.Customers, Is.Empty);
            Assert.That(Customer.Dealers, Is.Empty);
            Assert.That(Customer.Wholesalers, Is.Empty);
        });
    }

    [Test]
public void TestCustomerDynamicRoleAssignment() {
    Customer customer = new();

    Assert.That(customer.Roles, Is.Empty);

    customer.AddRole(CustomerRoleAttribute.Dealer, "North Territory", "Clean Record");
    Assert.That(customer.Roles, Contains.Item(CustomerRoleAttribute.Dealer));
    Assert.That(customer.Territory, Is.EqualTo("North Territory"));
    Assert.That(customer.CriminalRecord, Is.EqualTo(new List<string> { "Clean Record" }));

    Assert.DoesNotThrow(() => customer.Edit("Updated Territory", new List<string> { "Updated Record" }));
    Assert.That(customer.Territory, Is.EqualTo("Updated Territory"));
    Assert.That(customer.CriminalRecord, Is.EqualTo(new List<string> { "Updated Record" }));

    customer.AddRole(CustomerRoleAttribute.Wholesaler, 10.5, 50);
    Assert.That(customer.Roles, Contains.Item(CustomerRoleAttribute.Wholesaler));
    Assert.That(customer.CommissionPercentage, Is.EqualTo(10.5));
    Assert.That(customer.MonthlyCustomers, Is.EqualTo(50));

    Assert.DoesNotThrow(() => customer.Edit(12.5, 60));
    Assert.That(customer.CommissionPercentage, Is.EqualTo(12.5));
    Assert.That(customer.MonthlyCustomers, Is.EqualTo(60));

    customer.RemoveRole(CustomerRoleAttribute.Dealer);
    Assert.That(customer.Roles, Does.Not.Contain(CustomerRoleAttribute.Dealer));
    Assert.That(customer.Territory, Is.Null);
    Assert.That(customer.CriminalRecord, Is.Null);

    Assert.Throws<InvalidOperationException>(() => customer.Edit("Another Territory", null));

    Assert.DoesNotThrow(() => customer.Edit(15.0, 70));
    Assert.That(customer.CommissionPercentage, Is.EqualTo(15.0));
    Assert.That(customer.MonthlyCustomers, Is.EqualTo(70));
}


    [Test]
    public void TestCustomerDeserializeWithInvalidData() {

        Customer.Customers.Clear();
        Customer.Dealers.Clear();
        Customer.Wholesalers.Clear();

        Assert.DoesNotThrow(() => Customer.Deserialize());

        Assert.Multiple(() => {
            Assert.That(Customer.Customers, Is.Empty);
            Assert.That(Customer.Dealers, Is.Empty);
            Assert.That(Customer.Wholesalers, Is.Empty);
        });
    }

    [Test]
        public void TestDealerConstructor_ShouldSetProperties()
        {
            string territory = "North";
            IList<string> criminalRecord = new List<string> { "Theft", "Fraud" };
            var dealer = new Dealer(territory, criminalRecord);
            Assert.Multiple(() => {
                Assert.That(dealer.Territory, Is.EqualTo(territory));
                Assert.That(dealer.CriminalRecord, Is.EquivalentTo(criminalRecord));
            });
        }

        [Test]
        public void TestWholesalerConstructor_ShouldSetProperties()
        {
            double commissionPercentage = 15.5;
            int monthlyCustomers = 20;
            var wholesaler = new Wholesaler(commissionPercentage, monthlyCustomers);
            Assert.Multiple(() => {
                Assert.That(wholesaler.CommissionPercentage, Is.EqualTo(commissionPercentage));
                Assert.That(wholesaler.MonthlyCustomers, Is.EqualTo(monthlyCustomers));
            });
        }

        [Test]
        public void TestDealerConstructor_FromWholesaler_ShouldCopyProperties()
        {
            var wholesaler = new Wholesaler(10.0, 30);
            var dealer = new Dealer(wholesaler);
            Assert.Multiple(() => {
                Assert.That(dealer.CommissionPercentage, Is.EqualTo(wholesaler.CommissionPercentage));
                Assert.That(dealer.MonthlyCustomers, Is.EqualTo(wholesaler.MonthlyCustomers));
            });
        }

        [Test]
        public void TestWholesalerConstructor_FromDealer_ShouldCopyProperties()
        {
            var dealer = new Dealer("East", new List<string> { "Arson" });
            var wholesaler = new Wholesaler(dealer);
            Assert.Multiple(() => {
                Assert.That(wholesaler.Territory, Is.EqualTo(dealer.Territory));
                Assert.That(wholesaler.CriminalRecord, Is.EquivalentTo(dealer.CriminalRecord));
            });
        }


    
}

