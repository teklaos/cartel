namespace ConsoleApp;

public class Customer {
    public static IEnumerable<Customer> _customers { get; private set; } = new List<Customer>();
    public Customer() {
        _customers = _customers.Append(this);
    }

    public static int GetCustomersCount() {
        return _customers.Count();
    }
}