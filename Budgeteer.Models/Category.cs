namespace Budgeteer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Spending>? Spending { get; set; }
    }

    public class Spending
    {
        public DateTime Month { get; set; }
        public decimal Total { get; set; }
    }
}