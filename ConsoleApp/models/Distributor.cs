namespace ConsoleApp.models;

public class Distributor : CartelMember {
    public static IEnumerable<Distributor> _distributors { get; private set; } = new List<Distributor>();
    
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        AddDistributor();
    }

    private void AddDistributor() {
        try {
            ArgumentNullException.ThrowIfNull(this);
            _distributors = _distributors.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}