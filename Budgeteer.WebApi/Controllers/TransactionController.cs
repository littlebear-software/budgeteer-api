using Microsoft.AspNetCore.Mvc;
using Budgeteer.Models;
using Budgeteer.Data.Contexts;
using DataTransaction = Budgeteer.Data.Models.Transaction;

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
        public IEnumerable<Transaction> GetTransactions(int pageNumber = 0, int pageSize = 30)
        {

            var results = from transaction in this._transactionContext.Transactions
                .OrderByDescending(t => t.Date)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                          join category in this._transactionContext.Categories on transaction.CategoryId equals category.Id
                          select new Transaction
                          {
                              Id = transaction.Id,
                              Vendor = transaction.Vendor,
                              Amount = transaction.Amount,
                              Date = transaction.Date,
                              Category = new Category
                              {
                                  Id = category.Id,
                                  Name = category.Name,
                                  Color = category.Color,
                              }
                          };


            return results;
        }

        [HttpPost]
        public void PostTransaction(Transaction transaction)
        {
            Console.WriteLine(transaction);
            this._transactionContext.Add<DataTransaction>(new DataTransaction
            {
                Id = transaction.Id,
                Vendor = transaction.Vendor,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId,
                Date = transaction.Date,
            });
            this._transactionContext.SaveChanges();
        }
    }
}