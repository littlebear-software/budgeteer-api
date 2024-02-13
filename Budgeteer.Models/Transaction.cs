namespace Budgeteer.Models;

public class Transaction
{
    public string Vendor { get; set; }
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Transaction(string vendor, decimal amount, Category category)
    {
        this.Vendor = vendor;
        this.Amount = amount;
        this.Category = category;
    }
}
