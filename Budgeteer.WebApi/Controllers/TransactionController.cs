using Microsoft.AspNetCore.Mvc;
using Budgeteer.Models;
using Budgeteer.Data.Contexts;

namespace Budgeteer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {

        private readonly BudgeteerContext _transactionContext;

        public TransactionController(BudgeteerContext context)
        {
            this._transactionContext = context;
        }

        [HttpGet]
        public IEnumerable<Transaction> GetTransactions(int pageNumber = 0, int pageSize = 10)
        {

            var returns = new List<Transaction>() { };
            var transactions = this._transactionContext.Transactions
                .OrderBy(t => t.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var transaction in transactions)
            {
                var category = this._transactionContext.Categories.FirstOrDefault(category => category.Id == transaction.CategoryId);
                returns.Add(new Transaction
                {
                    Id = transaction.Id,
                    Vendor = transaction.Vendor,
                    Amount = transaction.Amount,
                    CategoryId = transaction.CategoryId,
                    Category = new Category
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Color = category.Color,
                    },
                });
            }

            return returns;
        }
    }
}