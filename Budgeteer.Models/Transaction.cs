namespace Budgeteer.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Vendor { get; set; }
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
