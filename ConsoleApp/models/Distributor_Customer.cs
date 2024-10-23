namespace ConsoleApp.models;

public class DistributorCustomer {
    public IEnumerable<DistributorCustomer> _distributorsCustomers { get; private set; } = new List<DistributorCustomer>();
    public DateTime DealStartDate { get; set; }
    public int AmountOfProduct { get; set; }
    public DateTime? DealEndDate { get; set; }

    public DistributorCustomer(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        this.DealStartDate = dealStartDate;
        this.AmountOfProduct = amountOfProduct;
        this.DealEndDate = dealEndDate;
        _distributorsCustomers = _distributorsCustomers.Append(this);
    }
}