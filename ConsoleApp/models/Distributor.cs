namespace ConsoleApp.models;

public class Distributor : CartelMember {
    public static IEnumerable<Distributor> _distributors { get; private set; } = new List<Distributor>();
    public int DealsMade { get; private set; }
    
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow, int dealsMade):
    base(name, trustLevel, rulesToFollow) {
        DealsMade = dealsMade;
        AddDistributor();
    }

    private void AddDistributor() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(DealsMade, "Deals made");
            ArgumentNullException.ThrowIfNull(this);
            _distributors = _distributors.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}