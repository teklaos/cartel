using System.Text.Json;

namespace ConsoleApp.models;

public class Equipment {
    private static IList<Equipment> _equipmentList = new List<Equipment>();
    public static IList<Equipment> EquipmentList {
        get => new List<Equipment>(_equipmentList);
        private set => _equipmentList = value;
    }
    public string Type { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public Laboratory? AssignedLab { get; private set; }

    public Equipment(string type, string name, string model) {
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("Type cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model cannot be null or whitespace.");

        Type = type;
        Name = name;
        Model = model;
        _equipmentList.Add(this);
    }

    public void AttachLab(Laboratory laboratory)
    {
        AssignedLab = laboratory;
    }
    
    public void RemoveLab()
    {
        AssignedLab = null;
    }
    
    public static void Serialize() {
        string fileName = "Equipment.json";
        try {
            string jsonString = JsonSerializer.Serialize(EquipmentList, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Equipment.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            EquipmentList = JsonSerializer.Deserialize<List<Equipment>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}