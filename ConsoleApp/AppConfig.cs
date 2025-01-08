using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp;

public static class AppConfig {
    public static readonly JsonSerializerOptions JsonOptions = new() {
        ReferenceHandler = ReferenceHandler.Preserve,
        WriteIndented = true
    };
}