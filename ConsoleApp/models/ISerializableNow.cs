using System.Text.Json;

namespace ConsoleApp.models;

public interface ISerializable {
    public static JsonSerializerOptions jsonOptions { get; private set; } = new JsonSerializerOptions {WriteIndented = true};
    public static void Serialize() {}
    public static void Deserialize() {}
}