namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public static IEnumerable<Citizen> _citizens { get; private set; } = new List<Citizen>();
    
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        AddCitizen();
    }

    private void AddCitizen() {
        try {
            ArgumentNullException.ThrowIfNull(this);
            _citizens = _citizens.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}