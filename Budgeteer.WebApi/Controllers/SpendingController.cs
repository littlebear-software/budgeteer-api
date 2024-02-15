using System;
using Microsoft.AspNetCore.Mvc;
using Budgeteer.Models;
using Budgeteer.Data.Contexts;

namespace Budgeteer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingController : ControllerBase
    {
        private readonly BudgeteerContext _transactionContext;

        public SpendingController(BudgeteerContext context)
        {
            this._transactionContext = context;
        }

        [HttpGet]
        public IEnumerable<Spending> GetSpending(int pageSize = 10, int pageNumber = 0)
        {
            var today = DateTime.Now;
            var startMonth = new DateTime(today.Year, today.Month, 1, 0, 0, 0);
            var spending = new List<Spending>() { };

            var t = this._transactionContext.Transactions
                .OrderByDescending(t => t.Date);

            for (var offset = 0; offset < 6; offset++)
            {

                var sum = t
                    .Where(t => t.Date >= startMonth.AddDays(-1).ToUniversalTime() && t.Date < startMonth.AddMonths(1).AddDays(-1).ToUniversalTime())
                    .Sum(t => t.Amount);


                spending.Add(new Spending { Date = startMonth, Amount = sum });
                startMonth = startMonth.AddMonths(-1);
            }

            return spending;
        }

    }

}