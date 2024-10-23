namespace ConsoleApp;

public class Distributor_Customer {
    private IEnumerable<Distributor_Customer> _distributorCustomers = new List<Distributor_Customer>();
    public DateTime DealStartDate { get; set; }
    public int AmountOfProduct { get; set; }
    public DateTime? DealEndDate { get; set; }

    public Distributor_Customer(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        this.DealStartDate = dealStartDate;
        this.AmountOfProduct = amountOfProduct;
        this.DealEndDate = dealEndDate;
        _distributorCustomers = _distributorCustomers.Append(this);
    }
}