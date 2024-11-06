using ConsoleApp.models;

namespace ConsoleAppUnitTests;

public class TestSerialization {
    
        [Test]
        public void Serialization_WriteToFile()
        {
            var official = new Official("Heisenberg", 10, new List<string> { "No half measures", "Respect the lab", "Say my name" }, "Cook", "Meth Lab");
            Official.Serialize();
            Assert.IsTrue(File.Exists("Officials.json"));
            var jsonContent = File.ReadAllText("Officials.json");
            Assert.IsTrue(jsonContent.Contains("Heisenberg"));
            Assert.IsTrue(jsonContent.Contains("Cook"));
            Assert.IsTrue(jsonContent.Contains("Meth Lab"));
        }

        [Test]
        public void Deserialization_LoadFromFile()
        {
            var official = new Official("Gus Fring", 9, new List<string> { "Don’t get high on your own supply", "Always be professional" }, "Manager", "Los Pollos Hermanos");
            Official.Serialize();
            Official.Deserialize();

            Assert.IsNotNull(Official._officials);
            var deserializedOfficial = Official._officials.LastOrDefault();
            Assert.IsNotNull(deserializedOfficial);
            Assert.AreEqual("Gus Fring", deserializedOfficial.Name);
            Assert.AreEqual("Manager", deserializedOfficial.Position);
            Assert.AreEqual("Los Pollos Hermanos", deserializedOfficial.Department);
            Assert.AreEqual(9, deserializedOfficial.TrustLevel);
            Assert.IsTrue(deserializedOfficial.RulesToFollow.Contains("Don’t get high on your own supply"));
        }

        [Test]
        public void SerializeAndDeserialize_Integrity()
        {
            var originalOfficial = new Official("Saul Goodman", 6, new List<string> { "Don’t go to jail", "Always lawyer up", "Better call Saul" }, "Lawyer", "Criminal Law");
            Official.Serialize();

            Official.Deserialize();
            var deserializedOfficial = Official._officials.LastOrDefault();

            Assert.IsNotNull(deserializedOfficial);
            Assert.AreEqual(originalOfficial.Name, deserializedOfficial.Name);
            Assert.AreEqual(originalOfficial.Position, deserializedOfficial.Position);
            Assert.AreEqual(originalOfficial.Department, deserializedOfficial.Department);
            Assert.AreEqual(originalOfficial.TrustLevel, deserializedOfficial.TrustLevel);
            CollectionAssert.AreEqual(originalOfficial.RulesToFollow, deserializedOfficial.RulesToFollow);
        }
}