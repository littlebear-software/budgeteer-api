using Microsoft.AspNetCore.Mvc;
using Budgeteer.Models;

namespace Budgeteer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions()
        {
            return new Transaction[] {
                new Transaction (
                    "Taco Bell",
                    24.99M,
                    new Category (
                        "Dining",
                        "#9DBC98"
                    )
                ),
                new Transaction (
                    "Prattville Country Club",
                    70.00M,
                    new Category (
                        "Entertainment",
                        "#BB6464"
                    )
                ),
                new Transaction (
                    "Citgo",
                    84.98M,
                    new Category (
                        "Automotive",
                        "#7BD3EA"
                    )
                ),
                new Transaction (
                    "Beef O'Brady's",
                    64.99M,
                    new Category (
                        "Dining",
                        "#9DBC98"
                    )
                ),
                new Transaction (
                    "Walmart",
                    245.88M,
                    new Category (
                        "Groceries",
                        "#FDFFAE"
                    )
                ),
            };
        }
    }
}