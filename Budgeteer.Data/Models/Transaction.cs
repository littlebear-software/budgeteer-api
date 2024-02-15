using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budgeteer.Data.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }

        public Category Category { get; set; }

    }
}