namespace Budgeteer.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Transaction[] Transactions { get; set; }
        public Spending[] Spending { get; set; }

        public Category(string name, string color)
        {
            this.Name = name;
            this.Color = color;
            this.Transactions = new Transaction[] { };
            this.Spending = new Spending[] { };
        }
    }
}