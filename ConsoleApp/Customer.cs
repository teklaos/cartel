namespace ConsoleApp;

public class Customer {
    private static IEnumerable<Customer> _customers = new List<Customer>();
    public Customer() {
        _customers = _customers.Append(this);
    }

    public static int GetCustomerCount() {
        return _customers.Count();
    }
}