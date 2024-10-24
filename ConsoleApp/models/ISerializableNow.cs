using System.Text.Json;

namespace ConsoleApp.models;

public interface ISerializable {
    public static JsonSerializerOptions jsonOptions { get; private set; } = new JsonSerializerOptions {WriteIndented = true};

    /*public static void TestSerialize<T>(IEnumerable<T> data, string fileName) {
        string jsonString = JsonSerializer.Serialize(data, jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static IEnumerable<T> TestDeserialize<T>(string fileName) where T : new() {
        if (File.Exists(fileName)) {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        }
        return new List<T>();
    }*/
}