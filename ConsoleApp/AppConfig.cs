using System.Text.Json;

namespace ConsoleApp;

public static class AppConfig
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true
    };
}