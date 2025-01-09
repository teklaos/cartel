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
    public Laboratory? AssociatedLaboratory { get; private set; }

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

    public void AddLaboratory(Laboratory laboratory) {
        laboratory.AddCompositionAssociationInternally(this);
        AssociatedLaboratory = laboratory;
    }

    public void RemoveLaboratory(Laboratory laboratory) {
        laboratory.RemoveCompositionAssociationInternally(this);
        AssociatedLaboratory = null;
    }

    public void EditLaboratory(Laboratory oldLaboratory, Laboratory newLaboratory) {
        RemoveLaboratory(oldLaboratory);
        AddLaboratory(newLaboratory);
    }

    public void AddLaboratoryInternally(Laboratory laboratory) {
        AssociatedLaboratory = laboratory;
    }

    public void RemoveLaboratoryInternally() {
        AssociatedLaboratory = null;
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

    ~Equipment() {
        try {
            _equipmentList?.Remove(this);
        } catch (ArgumentException ex) {
            Console.WriteLine($"Failed to remove equipment: {ex.Message}.");
        }
    }
}