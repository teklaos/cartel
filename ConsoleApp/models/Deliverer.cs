namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    public static IEnumerable<Deliverer> _deliverers { get; private set; } = new List<Deliverer>();
    
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        AddDeliverer();
    }

    private void AddDeliverer() {
        try {
            ArgumentNullException.ThrowIfNull(this);
            _deliverers = _deliverers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}