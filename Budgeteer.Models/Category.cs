namespace Budgeteer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public Transaction[] Transactions { get; set; }
        public Spending[] Spending { get; set; }

    }
}