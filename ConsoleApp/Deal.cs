namespace ConsoleApp;

public class Deal {
    public DateTime DealStartDate { get; set; }
    public int AmountOfProduct { get; set; }
    public DateTime? DealEndDate { get; set; }

    public Deal(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        this.DealStartDate = dealStartDate;
        this.AmountOfProduct = amountOfProduct;
        this.DealEndDate = dealEndDate;
    }
}