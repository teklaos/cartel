using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestSerialization {
    [Test]
    public void SerializationWriteChemistToFile() {
        new Chemist("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, 50000);
        
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
        new Chemist("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, 0);

        Chemist.Serialize();
        Chemist.Deserialize();
        Assert.That(Chemist._chemists, Is.Not.Null);
        
        var deserializedChemist = Chemist._chemists.LastOrDefault();
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
        var originalChemist = new Chemist("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul." }, 0);
        Chemist.Serialize();
        Chemist.Deserialize();
        var deserializedChemist = Chemist._chemists.LastOrDefault();

        Assert.That(deserializedChemist, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedChemist.Name, Is.EqualTo(originalChemist.Name));
            Assert.That(deserializedChemist.TrustLevel, Is.EqualTo(originalChemist.TrustLevel));
        });
        CollectionAssert.AreEqual(originalChemist.RulesToFollow, deserializedChemist.RulesToFollow);
    }

    [Test]
    public void SerializationWriteCitizenToFile() {
        new Citizen("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, "Cook", 2);
        
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
        new Citizen("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, "Manager", 10);

        Citizen.Serialize();
        Citizen.Deserialize();
        Assert.That(Citizen._citizens, Is.Not.Null);
        
        var deserializedCitizen = Citizen._citizens.LastOrDefault();
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
        var originalCitizen = new Citizen("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul." }, "Lawyer", 8);
        Citizen.Serialize();
        Citizen.Deserialize();
        var deserializedCitizen = Citizen._citizens.LastOrDefault();

        Assert.That(deserializedCitizen, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedCitizen.Name, Is.EqualTo(originalCitizen.Name));
            Assert.That(deserializedCitizen.TrustLevel, Is.EqualTo(originalCitizen.TrustLevel));
        });
        CollectionAssert.AreEqual(originalCitizen.RulesToFollow, deserializedCitizen.RulesToFollow);
    }

    [Test]
    public void SerializationWriteDealerToFile() {
        new Dealer("South Valley", new List<string> {"Possession of Controlled Substance (Cocaine)."});
        
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
        new Dealer("North Valley", new List<string> {"Possession of Controlled Substance (Crystal Methamphetamine)."});

        Dealer.Serialize();
        Dealer.Deserialize();
        Assert.That(Dealer._dealers, Is.Not.Null);
        
        var deserializedDealer = Dealer._dealers.LastOrDefault();
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
        var deserializedDealer = Dealer._dealers.LastOrDefault();

        Assert.That(deserializedDealer, Is.Not.Null);
        Assert.That(deserializedDealer.Territory, Is.EqualTo(originalDealer.Territory));
        CollectionAssert.AreEqual(originalDealer.CriminalRecord, deserializedDealer.CriminalRecord);
    }

    [Test]
    public void SerializationWriteOfficialToFile() {
        new Official("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, "Cook", "Meth Lab");
        
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
        new Official("Gus Fring", 9, new List<string> {"Don’t get high on your own supply.", "Always be professional."}, "Manager", "Los Pollos Hermanos");

        Official.Serialize();
        Official.Deserialize();
        Assert.That(Official._officials, Is.Not.Null);
        
        var deserializedOfficial = Official._officials.LastOrDefault();
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
        var originalOfficial = new Official("Saul Goodman", 6, new List<string> {"Don’t go to jail.", "Always lawyer up.", "Better call Saul." }, "Lawyer", "Criminal Law");
        Official.Serialize();
        Official.Deserialize();
        var deserializedOfficial = Official._officials.LastOrDefault();

        Assert.That(deserializedOfficial, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(deserializedOfficial.Name, Is.EqualTo(originalOfficial.Name));
            Assert.That(deserializedOfficial.Position, Is.EqualTo(originalOfficial.Position));
            Assert.That(deserializedOfficial.Department, Is.EqualTo(originalOfficial.Department));
            Assert.That(deserializedOfficial.TrustLevel, Is.EqualTo(originalOfficial.TrustLevel));
        });
        CollectionAssert.AreEqual(originalOfficial.RulesToFollow, deserializedOfficial.RulesToFollow);
    }
}