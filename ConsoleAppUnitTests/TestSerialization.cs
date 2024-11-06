using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestSerialization {
    [Test]
    public void SerializationWriteToFile() {
        new Official("Heisenberg", 10, new List<string> {"No half measures.", "Respect the lab.", "Say my name."}, "Cook", "Meth Lab");
        
        Official.Serialize();
        Assert.That(File.Exists("Officials.json"), Is.True);

        var jsonContent = File.ReadAllText("Officials.json");
        Assert.Multiple(() => {
            Assert.That(jsonContent, Does.Contain("Heisenberg"));
            Assert.That(jsonContent, Does.Contain("Cook"));
            Assert.That(jsonContent, Does.Contain("Meth Lab"));
        });
    }

    [Test]
    public void DeserializationLoadFromFile() {
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
    public void SerializeAndDeserializeIntegrity() {
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