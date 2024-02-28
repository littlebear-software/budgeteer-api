using System.Text.Json.Serialization;

namespace Budgeteer.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }

}