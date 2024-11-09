using System.Security.Cryptography;
using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestSerialization {
    [Test]
    public void SerializationWriteChemistToFile() {
        _ = new Chemist("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, 50000);
        
        Chemist.Serialize();
        Assert.That(File.Exists("Chemists.json"), Is.True);

        var jsonContent = File.ReadAllText("Chemists.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
            Assert.That(jsonContent, Does.Contain("50000"));
        });

        CartelMember.Serialize();
        Assert.That(File.Exists("CartelMembers.json"), Is.True);

        jsonContent = File.ReadAllText("CartelMembers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });
    }

    [Test]
    public void DeserializationLoadChemistFromFile() {
        _ = new Chemist("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, 0);

        Chemist.Serialize();
        Chemist.Deserialize();
        Assert.That(Chemist.Chemists, Is.Not.Null);
        
        var deserializedChemist = Chemist.Chemists.LastOrDefault();
        Assert.That(deserializedChemist, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedChemist.Name, Is.EqualTo("Gus Fring"));
            Assert.That(deserializedChemist.TrustLevel, Is.EqualTo(9));
            Assert.That(deserializedChemist.RulesToFollow, Does.Contain("Don’t get high on your own supply."));
            Assert.That(deserializedChemist.PoundsCooked, Is.EqualTo(0));
        });
    }

    [Test]
    public void SerializeAndDeserializeChemistIntegrity() {
        var originalChemist = new Chemist("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul."}, 0);
        Chemist.Serialize();
        Chemist.Deserialize();
        var deserializedChemist = Chemist.Chemists.LastOrDefault();

        Assert.That(deserializedChemist, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedChemist.Name, Is.EqualTo(originalChemist.Name));
            Assert.That(deserializedChemist.TrustLevel, Is.EqualTo(originalChemist.TrustLevel));
            Assert.That(deserializedChemist.PoundsCooked, Is.EqualTo(originalChemist.PoundsCooked));
        });
        CollectionAssert.AreEqual(originalChemist.RulesToFollow, deserializedChemist.RulesToFollow);
    }

    [Test]
    public void SerializationWriteCitizenToFile() {
        _ = new Citizen("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, "Cook", 2);
        
        Citizen.Serialize();
        Assert.That(File.Exists("Citizens.json"), Is.True);

        var jsonContent = File.ReadAllText("Citizens.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
            Assert.That(jsonContent, Does.Contain("Cook"));
            Assert.That(jsonContent, Does.Contain("2"));
        });

        CartelMember.Serialize();
        Assert.That(File.Exists("CartelMembers.json"), Is.True);

        jsonContent = File.ReadAllText("CartelMembers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });
    }

    [Test]
    public void DeserializationLoadCitizenFromFile() {
        _ = new Citizen("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, "Manager", 10);

        Citizen.Serialize();
        Citizen.Deserialize();
        Assert.That(Citizen.Citizens, Is.Not.Null);
        
        var deserializedCitizen = Citizen.Citizens.LastOrDefault();
        Assert.That(deserializedCitizen, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedCitizen.Name, Is.EqualTo("Gus Fring"));
            Assert.That(deserializedCitizen.TrustLevel, Is.EqualTo(9));
            Assert.That(deserializedCitizen.RulesToFollow, Does.Contain("Don’t get high on your own supply."));
            Assert.That(deserializedCitizen.Occupation , Is.EqualTo("Manager"));
            Assert.That(deserializedCitizen.SecurityLevel , Is.EqualTo(10));
        });
    }

    [Test]
    public void SerializeAndDeserializeCitizenIntegrity() {
        var originalCitizen = new Citizen("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul."}, "Lawyer", 8);
        Citizen.Serialize();
        Citizen.Deserialize();
        var deserializedCitizen = Citizen.Citizens.LastOrDefault();

        Assert.That(deserializedCitizen, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedCitizen.Name, Is.EqualTo(originalCitizen.Name));
            Assert.That(deserializedCitizen.TrustLevel, Is.EqualTo(originalCitizen.TrustLevel));
            Assert.That(deserializedCitizen.Occupation, Is.EqualTo(originalCitizen.Occupation));
            Assert.That(deserializedCitizen.SecurityLevel, Is.EqualTo(originalCitizen.SecurityLevel));
        });
        CollectionAssert.AreEqual(originalCitizen.RulesToFollow, deserializedCitizen.RulesToFollow);
    }

    [Test]
    public void SerializationWriteDealerToFile() {
        _ = new Dealer("South Valley", new List<string> {"Possession of Controlled Substance (Cocaine)."});
        
        Dealer.Serialize();
        Assert.That(File.Exists("Dealers.json"), Is.True);

        var jsonContent = File.ReadAllText("Dealers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("South Valley"));
            Assert.That(jsonContent, Does.Contain("Possession of Controlled Substance (Cocaine)."));
        });
    }

    [Test]
    public void DeserializationLoadDealerFromFile() {
        _ = new Dealer("North Valley", new List<string> {"Possession of Controlled Substance (Crystal Methamphetamine)."});

        Dealer.Serialize();
        Dealer.Deserialize();
        Assert.That(Dealer.Dealers, Is.Not.Null);
        
        var deserializedDealer = Dealer.Dealers.LastOrDefault();
        Assert.That(deserializedDealer, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDealer.Territory, Is.EqualTo("North Valley"));
            Assert.That(deserializedDealer.CriminalRecord, Does.Contain("Possession of Controlled Substance (Crystal Methamphetamine)."));
        });
    }

    [Test]
    public void SerializeAndDeserializeDealerIntegrity() {
        var originalDealer = new Dealer("Rio Rancho", new List<string> {"Possession of Controlled Substance (Cannabis)."});

        Dealer.Serialize();
        Dealer.Deserialize();
        var deserializedDealer = Dealer.Dealers.LastOrDefault();

        Assert.That(deserializedDealer, Is.Not.Null);
        Assert.That(deserializedDealer.Territory, Is.EqualTo(originalDealer.Territory));
        CollectionAssert.AreEqual(originalDealer.CriminalRecord, deserializedDealer.CriminalRecord);
    }

    [Test]
    public void SerializationWriteDelivererToFile() {
        _ = new Deliverer("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."});
        
        Deliverer.Serialize();
        Assert.That(File.Exists("Deliverers.json"), Is.True);

        var jsonContent = File.ReadAllText("Deliverers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });

        CartelMember.Serialize();
        Assert.That(File.Exists("CartelMembers.json"), Is.True);

        jsonContent = File.ReadAllText("CartelMembers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });
    }

    [Test]
    public void DeserializationLoadDelivererFromFile() {
        _ = new Deliverer("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."});

        Deliverer.Serialize();
        Deliverer.Deserialize();
        Assert.That(Deliverer.Deliverers, Is.Not.Null);
        
        var deserializedDeliverer = Deliverer.Deliverers.LastOrDefault();
        Assert.That(deserializedDeliverer, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDeliverer.Name, Is.EqualTo("Gus Fring"));
            Assert.That(deserializedDeliverer.TrustLevel, Is.EqualTo(9));
            Assert.That(deserializedDeliverer.RulesToFollow, Does.Contain("Don’t get high on your own supply."));
        });
    }

    [Test]
    public void SerializeAndDeserializeDelivererIntegrity() {
        var originalDeliverer = new Deliverer("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul."});
        Deliverer.Serialize();
        Deliverer.Deserialize();
        var deserializedDeliverer = Deliverer.Deliverers.LastOrDefault();

        Assert.That(deserializedDeliverer, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDeliverer.Name, Is.EqualTo(originalDeliverer.Name));
            Assert.That(deserializedDeliverer.TrustLevel, Is.EqualTo(originalDeliverer.TrustLevel));
        });
        CollectionAssert.AreEqual(originalDeliverer.RulesToFollow, deserializedDeliverer.RulesToFollow);
    }

    [Test]
    public void SerializationWriteDistributorToFile() {
        _ = new Distributor("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, 20);
        
        Distributor.Serialize();
        Assert.That(File.Exists("Distributors.json"), Is.True);

        var jsonContent = File.ReadAllText("Distributors.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
            Assert.That(jsonContent, Does.Contain("20"));
        });

        CartelMember.Serialize();
        Assert.That(File.Exists("CartelMembers.json"), Is.True);

        jsonContent = File.ReadAllText("CartelMembers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });
    }

    [Test]
    public void DeserializationLoadDistributorFromFile() {
        _ = new Distributor("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, 70000);

        Distributor.Serialize();
        Distributor.Deserialize();
        Assert.That(Distributor.Distributors, Is.Not.Null);
        
        var deserializedDistributor = Distributor.Distributors.LastOrDefault();
        Assert.That(deserializedDistributor, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDistributor.Name, Is.EqualTo("Gus Fring"));
            Assert.That(deserializedDistributor.TrustLevel, Is.EqualTo(9));
            Assert.That(deserializedDistributor.RulesToFollow, Does.Contain("Don’t get high on your own supply."));
            Assert.That(deserializedDistributor.DealsMade, Is.EqualTo(70000));
        });
    }

    [Test]
    public void SerializeAndDeserializeDistributorIntegrity() {
        var originalDistributor = new Distributor("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul."}, 0);
        Distributor.Serialize();
        Distributor.Deserialize();
        var deserializedDistributor = Distributor.Distributors.LastOrDefault();

        Assert.That(deserializedDistributor, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDistributor.Name, Is.EqualTo(originalDistributor.Name));
            Assert.That(deserializedDistributor.TrustLevel, Is.EqualTo(originalDistributor.TrustLevel));
            Assert.That(deserializedDistributor.DealsMade, Is.EqualTo(originalDistributor.DealsMade));
        });
        CollectionAssert.AreEqual(originalDistributor.RulesToFollow, deserializedDistributor.RulesToFollow);
    }

    [Test]
    public void SerializationWriteDistributorCustomerToFile() {
        _ = new DistributorCustomer(new DateTime(2024, 5, 20), 15, new DateTime(2024, 5, 21));
        
        DistributorCustomer.Serialize();
        Assert.That(File.Exists("DistributorsCustomers.json"), Is.True);

        var jsonContent = File.ReadAllText("DistributorsCustomers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("2024-05-20"));
            Assert.That(jsonContent, Does.Contain("15"));
            Assert.That(jsonContent, Does.Contain("2024-05-21"));
        });
    }

    [Test]
    public void DeserializationLoadDistributorCustomerFromFile() {
        _ = new DistributorCustomer(new DateTime(2020, 4, 19), 10, new DateTime(2020, 4, 20));

        DistributorCustomer.Serialize();
        DistributorCustomer.Deserialize();
        Assert.That(DistributorCustomer.DistributorsCustomers, Is.Not.Null);
        
        var deserializedDistributorCustomer = DistributorCustomer.DistributorsCustomers.LastOrDefault();
        Assert.That(deserializedDistributorCustomer, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDistributorCustomer.DealStartDate, Is.EqualTo(new DateTime(2020, 4, 19)));
            Assert.That(deserializedDistributorCustomer.PoundsOfProduct, Is.EqualTo(10));
            Assert.That(deserializedDistributorCustomer.DealEndDate, Is.EqualTo(new DateTime(2020, 4, 20)));
        });
    }

    [Test]
    public void SerializeAndDeserializeDistributorCustomerIntegrity() {
        var originalDistributorCustomer = new DistributorCustomer(new DateTime(2005, 03, 07), 150, new DateTime(2005, 03, 08));
        DistributorCustomer.Serialize();
        DistributorCustomer.Deserialize();
        var deserializedDistributorCustomer = DistributorCustomer.DistributorsCustomers.LastOrDefault();

        Assert.That(deserializedDistributorCustomer, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedDistributorCustomer.DealStartDate, Is.EqualTo(originalDistributorCustomer.DealStartDate));
            Assert.That(deserializedDistributorCustomer.PoundsOfProduct, Is.EqualTo(originalDistributorCustomer.PoundsOfProduct));
            Assert.That(deserializedDistributorCustomer.DealEndDate, Is.EqualTo(originalDistributorCustomer.DealEndDate));
        });
    }

    [Test]
    public void SerializationWriteEquipmentToFile() {
        _ = new Equipment("Bottle", "Boiling Flask", "CA-1");
        
        Equipment.Serialize();
        Assert.That(File.Exists("Equipment.json"), Is.True);

        var jsonContent = File.ReadAllText("Equipment.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Bottle"));
            Assert.That(jsonContent, Does.Contain("Boiling Flask"));
            Assert.That(jsonContent, Does.Contain("CA-1"));
        });
    }

    [Test]
    public void DeserializationLoadEquipmentFromFile() {
        _ = new Equipment("Bottle", "Boiling Flask", "CA-2");

        Equipment.Serialize();
        Equipment.Deserialize();
        Assert.That(Equipment.EquipmentList, Is.Not.Null);
        
        var deserializedEquipment = Equipment.EquipmentList.LastOrDefault();
        Assert.That(deserializedEquipment, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedEquipment.Type, Is.EqualTo("Bottle"));
            Assert.That(deserializedEquipment.Name, Is.EqualTo("Boiling Flask"));
            Assert.That(deserializedEquipment.Model, Is.EqualTo("CA-2"));
        });
    }

    [Test]
    public void SerializeAndDeserializeEquipmentIntegrity() {
        var originalEquipment = new Equipment("Bottle", "Boiling Flask", "CA-3");
        Equipment.Serialize();
        Equipment.Deserialize();
        var deserializedEquipment = Equipment.EquipmentList.LastOrDefault();

        Assert.That(deserializedEquipment, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedEquipment.Type, Is.EqualTo(originalEquipment.Type));
            Assert.That(deserializedEquipment.Name, Is.EqualTo(originalEquipment.Name));
            Assert.That(deserializedEquipment.Model, Is.EqualTo(originalEquipment.Model));
        });
    }

    [Test]
    public void SerializationWriteIngredientToFile() {
        _ = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        
        Ingredient.Serialize();
        Assert.That(File.Exists("Ingredients.json"), Is.True);

        var jsonContent = File.ReadAllText("Ingredients.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Crystal"));
            Assert.That(jsonContent, Does.Contain("200"));
            Assert.That(jsonContent, Does.Contain("2"));
        });
    }

    [Test]
    public void DeserializationLoadIngredientFromFile() {
        _ = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);

        Ingredient.Serialize();
        Ingredient.Deserialize();
        Assert.That(Ingredient.Ingredients, Is.Not.Null);
        
        var deserializedIngredient = Ingredient.Ingredients.LastOrDefault();
        Assert.That(deserializedIngredient, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedIngredient.Name, Is.EqualTo("Crystal"));
            Assert.That(deserializedIngredient.Price, Is.EqualTo(200));
            Assert.That(deserializedIngredient.ChemicalFormula, Is.EqualTo("C₁₀H₁₅N"));
            Assert.That(deserializedIngredient.State, Is.EqualTo(StateAttribute.Solid));
        });
    }

    [Test]
    public void SerializeAndDeserializeIngredientIntegrity() {
        var originalIngredient = new Ingredient("Crystal", 200, "C₁₀H₁₅N", StateAttribute.Solid);
        Ingredient.Serialize();
        Ingredient.Deserialize();
        var deserializedIngredient = Ingredient.Ingredients.LastOrDefault();

        Assert.That(deserializedIngredient, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedIngredient.Name, Is.EqualTo(originalIngredient.Name));
            Assert.That(deserializedIngredient.Price, Is.EqualTo(originalIngredient.Price));
            Assert.That(deserializedIngredient.ChemicalFormula, Is.EqualTo(originalIngredient.ChemicalFormula));
            Assert.That(deserializedIngredient.State, Is.EqualTo(originalIngredient.State));
        });
    }

    [Test]
    public void SerializationWriteInstructionToFile() {
        _ = new Instruction(ActionAttribute.Stir);
        
        Instruction.Serialize();
        Assert.That(File.Exists("Instructions.json"), Is.True);

        var jsonContent = File.ReadAllText("Instructions.json");
        Assert.That(jsonContent, Does.Contain("1"));
    }

    [Test]
    public void DeserializationLoadInstructionFromFile() {
        _ = new Instruction(ActionAttribute.Stir);

        Instruction.Serialize();
        Instruction.Deserialize();
        Assert.That(Instruction.Instructions, Is.Not.Null);
        
        var deserializedInstruction = Instruction.Instructions.LastOrDefault();
        Assert.That(deserializedInstruction, Is.Not.Null);
        Assert.That(deserializedInstruction.Action, Is.EqualTo(ActionAttribute.Stir));
    }

    [Test]
    public void SerializeAndDeserializeInstructionIntegrity() {
        var originalInstruction = new Instruction(ActionAttribute.Stir);
        Instruction.Serialize();
        Instruction.Deserialize();
        var deserializedInstruction = Instruction.Instructions.LastOrDefault();

        Assert.That(deserializedInstruction, Is.Not.Null);
        Assert.That(deserializedInstruction.Action, Is.EqualTo(originalInstruction.Action));
    }

    [Test]
    public void SerializationWriteLaboratoryToFile() {
        _ = new Laboratory("Madelyn");
        
        Laboratory.Serialize();
        Assert.That(File.Exists("Laboratories.json"), Is.True);

        var jsonContent = File.ReadAllText("Laboratories.json");
        Assert.That(jsonContent, Does.Contain("Madelyn"));
    }

    [Test]
    public void DeserializationLoadLaboratoryFromFile() {
        _ = new Laboratory("Madelyn");

        Laboratory.Serialize();
        Laboratory.Deserialize();
        Assert.That(Laboratory.Laboratories, Is.Not.Null);
        
        var deserializedLaboratory = Laboratory.Laboratories.LastOrDefault();
        Assert.That(deserializedLaboratory, Is.Not.Null);
        Assert.That(deserializedLaboratory.Location, Is.EqualTo("Madelyn"));
    }

    [Test]
    public void SerializeAndDeserializeLaboratoryIntegrity() {
        var originalLaboratory = new Laboratory("Madelyn");
        Laboratory.Serialize();
        Laboratory.Deserialize();
        var deserializedLaboratory = Laboratory.Laboratories.LastOrDefault();

        Assert.That(deserializedLaboratory, Is.Not.Null);
        Assert.That(deserializedLaboratory.Location, Is.EqualTo(originalLaboratory.Location));
    }

    [Test]
    public void SerializationWriteOfficialToFile() {
        _ = new Official("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, "Cook", "Meth Lab");
        
        Official.Serialize();
        Assert.That(File.Exists("Officials.json"), Is.True);

        var jsonContent = File.ReadAllText("Officials.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("Cook"));
            Assert.That(jsonContent, Does.Contain("Meth Lab"));
        });

        CartelMember.Serialize();
        Assert.That(File.Exists("CartelMembers.json"), Is.True);

        jsonContent = File.ReadAllText("CartelMembers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("10"));
            Assert.That(jsonContent, Does.Contain("No half measures."));
        });
    }

    [Test]
    public void DeserializationLoadOfficialFromFile() {
        _ = new Official("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, "Manager", "Los Pollos Hermanos");

        Official.Serialize();
        Official.Deserialize();
        Assert.That(Official.Officials, Is.Not.Null);
        
        var deserializedOfficial = Official.Officials.LastOrDefault();
        Assert.That(deserializedOfficial, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedOfficial.Name, Is.EqualTo("Gus Fring"));
            Assert.That(deserializedOfficial.Position, Is.EqualTo("Manager"));
            Assert.That(deserializedOfficial.Department, Is.EqualTo("Los Pollos Hermanos"));
            Assert.That(deserializedOfficial.TrustLevel, Is.EqualTo(9));
            Assert.That(deserializedOfficial.RulesToFollow, Does.Contain("Don’t get high on your own supply."));
        });
    }

    [Test]
    public void SerializeAndDeserializeOfficialIntegrity() {
        var originalOfficial = new Official("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul."}, "Lawyer", "Criminal Law");
        Official.Serialize();
        Official.Deserialize();
        var deserializedOfficial = Official.Officials.LastOrDefault();

        Assert.That(deserializedOfficial, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedOfficial.Name, Is.EqualTo(originalOfficial.Name));
            Assert.That(deserializedOfficial.Position, Is.EqualTo(originalOfficial.Position));
            Assert.That(deserializedOfficial.Department, Is.EqualTo(originalOfficial.Department));
            Assert.That(deserializedOfficial.TrustLevel, Is.EqualTo(originalOfficial.TrustLevel));
        });
        CollectionAssert.AreEqual(originalOfficial.RulesToFollow, deserializedOfficial.RulesToFollow);
    }

    [Test]
    public void SerializationWriteProductToFile() {
        _ = new Product("Meth", 15, AddLevelAttribute.Strong);
        
        Product.Serialize();
        Assert.That(File.Exists("Products.json"), Is.True);

        var jsonContent = File.ReadAllText("Products.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Meth"));
            Assert.That(jsonContent, Does.Contain("15"));
            Assert.That(jsonContent, Does.Contain("2"));
        });
    }

    [Test]
    public void DeserializationLoadProductFromFile() {
        _ = new Product("Meth", 15, AddLevelAttribute.Strong);

        Product.Serialize();
        Product.Deserialize();
        Assert.That(Product.Products, Is.Not.Null);
        
        var deserializedProduct = Product.Products.LastOrDefault();
        Assert.That(deserializedProduct, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedProduct.Name, Is.EqualTo("Meth"));
            Assert.That(deserializedProduct.PricePerPound, Is.EqualTo(15));
            Assert.That(deserializedProduct.AddictivenessLevel, Is.EqualTo(AddLevelAttribute.Strong));
        });
    }

    [Test]
    public void SerializeAndDeserializeProductIntegrity() {
        var originalProduct = new Product("Meth", 15, AddLevelAttribute.Strong);
        Product.Serialize();
        Product.Deserialize();
        var deserializedProduct = Product.Products.LastOrDefault();

        Assert.That(deserializedProduct, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedProduct.Name, Is.EqualTo(originalProduct.Name));
            Assert.That(deserializedProduct.PricePerPound, Is.EqualTo(originalProduct.PricePerPound));
            Assert.That(deserializedProduct.PurityPercentage, Is.EqualTo(originalProduct.PurityPercentage));
            Assert.That(deserializedProduct.AddictivenessLevel, Is.EqualTo(originalProduct.AddictivenessLevel));
        });
    }

    [Test]
    public void SerializationWriteRecipeToFile() {
        _ = new Recipe();
        
        Recipe.Serialize();
        Assert.That(File.Exists("Recipes.json"), Is.True);
    }

    [Test]
    public void DeserializationLoadRecipeFromFile() {
        _ = new Recipe();

        Recipe.Serialize();
        Recipe.Deserialize();
        Assert.That(Recipe.Recipes, Is.Not.Null);
        
        var deserializedRecipe = Recipe.Recipes.LastOrDefault();
        Assert.That(deserializedRecipe, Is.Not.Null);
    }

    [Test]
    public void SerializeAndDeserializeRecipeIntegrity() {
        var originalRecipe = new Recipe();
        Recipe.Serialize();
        Recipe.Deserialize();
        var deserializedRecipe = Recipe.Recipes.LastOrDefault();

        Assert.That(deserializedRecipe, Is.Not.Null);
        Assert.That(deserializedRecipe.Complexity, Is.EqualTo(originalRecipe.Complexity));
    }

    [Test]
    public void SerializationWriteSupplyChainToFile() {
        _ = new SupplyChain("DPD", 48);
        
        SupplyChain.Serialize();
        Assert.That(File.Exists("SupplyChains.json"), Is.True);

        var jsonContent = File.ReadAllText("SupplyChains.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("DPD"));
            Assert.That(jsonContent, Does.Contain("48"));
        });
    }

    [Test]
    public void DeserializationLoadSupplyChainFromFile() {
        _ = new SupplyChain("DPD", 48);

        SupplyChain.Serialize();
        SupplyChain.Deserialize();
        Assert.That(SupplyChain.SupplyChains, Is.Not.Null);
        
        var deserializedSupplyChain = SupplyChain.SupplyChains.LastOrDefault();
        Assert.That(deserializedSupplyChain, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedSupplyChain.Name, Is.EqualTo("DPD"));
            Assert.That(deserializedSupplyChain.TransitionTime, Is.EqualTo(48));
        });
    }

    [Test]
    public void SerializeAndDeserializeSupplyChainIntegrity() {
        var originalSupplyChain = new SupplyChain("DPD", 48);
        SupplyChain.Serialize();
        SupplyChain.Deserialize();
        var deserializedSupplyChain = SupplyChain.SupplyChains.LastOrDefault();

        Assert.That(deserializedSupplyChain, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedSupplyChain.Name, Is.EqualTo(originalSupplyChain.Name));
            Assert.That(deserializedSupplyChain.TransitionTime, Is.EqualTo(originalSupplyChain.TransitionTime));
        });
    }

    [Test]
    public void SerializationWriteWarehouseToFile() {
        _ = new Warehouse("Madelyn", 500);
        
        Warehouse.Serialize();
        Assert.That(File.Exists("Warehouses.json"), Is.True);

        var jsonContent = File.ReadAllText("Warehouses.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Madelyn"));
            Assert.That(jsonContent, Does.Contain("500"));
        });
    }

    [Test]
    public void DeserializationLoadWarehouseFromFile() {
        _ = new Warehouse("Madelyn", 500);

        Warehouse.Serialize();
        Warehouse.Deserialize();
        Assert.That(Warehouse.Warehouses, Is.Not.Null);
        
        var deserializedWarehouse = Warehouse.Warehouses.LastOrDefault();
        Assert.That(deserializedWarehouse, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedWarehouse.Location, Is.EqualTo("Madelyn"));
            Assert.That(deserializedWarehouse.MaxCapacity, Is.EqualTo(500));
        });
    }

    [Test]
    public void SerializeAndDeserializeWarehouseIntegrity() {
        var originalWarehouse = new Warehouse("Madelyn", 500);
        Warehouse.Serialize();
        Warehouse.Deserialize();
        var deserializedWarehouse = Warehouse.Warehouses.LastOrDefault();

        Assert.That(deserializedWarehouse, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedWarehouse.Location, Is.EqualTo(originalWarehouse.Location));
            Assert.That(deserializedWarehouse.MaxCapacity, Is.EqualTo(originalWarehouse.MaxCapacity));
        });
    }

    [Test]
    public void SerializationWriteWholesalerToFile() {
        _ = new Wholesaler(15.47, 55);
        
        Wholesaler.Serialize();
        Assert.That(File.Exists("Wholesalers.json"), Is.True);

        var jsonContent = File.ReadAllText("Wholesalers.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("15.47"));
            Assert.That(jsonContent, Does.Contain("55"));
        });
    }

    [Test]
    public void DeserializationLoadWholesalerFromFile() {
        _ = new Wholesaler(15.47, 55);

        Wholesaler.Serialize();
        Wholesaler.Deserialize();
        Assert.That(Wholesaler.Wholesalers, Is.Not.Null);
        
        var deserializedWholesaler = Wholesaler.Wholesalers.LastOrDefault();
        Assert.That(deserializedWholesaler, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedWholesaler.CommissionPercentage, Is.EqualTo(15.47));
            Assert.That(deserializedWholesaler.MonthlyCustomers, Is.EqualTo(55));
        });
    }

    [Test]
    public void SerializeAndDeserializeWholesalerIntegrity() {
        var originalWholesaler = new Wholesaler(15.47, 55);

        Wholesaler.Serialize();
        Wholesaler.Deserialize();
        var deserializedWholesaler = Wholesaler.Wholesalers.LastOrDefault();

        Assert.That(deserializedWholesaler, Is.Not.Null);
        Assert.That(deserializedWholesaler.CommissionPercentage, Is.EqualTo(originalWholesaler.CommissionPercentage));
        Assert.That(deserializedWholesaler.MonthlyCustomers, Is.EqualTo(originalWholesaler.MonthlyCustomers));
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