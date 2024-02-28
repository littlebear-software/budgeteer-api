using Microsoft.AspNetCore.Mvc;
using Budgeteer.Models;
using Budgeteer.Data.Contexts;

namespace Budgeteer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BudgeteerContext _transactionContext;

        public CategoryController(BudgeteerContext context)
        {
            this._transactionContext = context;
        }

        [HttpGet]
        [Route("spending")]
        public IEnumerable<Category> GetCategorySpending(int months = 6)
        {
            var today = DateTime.Today;
            var startOfRange = new DateTime(today.Year, today.Month, 1, 0, 0, 0).AddMonths(-5);
            var categories = new Dictionary<string, Category>();
            var spending = new List<Category>() { };

            for (var offset = 0; offset <= months - 1; offset++)
            {
                var endOfRange = startOfRange.AddMonths(1);
                var results = from category in this._transactionContext.Categories
                            .Where(c => c.ParentCategoryId == null)
                              join transaction in this._transactionContext.Transactions
                                 .Where(t => t.Date >= DateTime.SpecifyKind(startOfRange, DateTimeKind.Utc) && t.Date < DateTime.SpecifyKind(endOfRange, DateTimeKind.Utc))
                                   on category.Id equals transaction.CategoryId into g
                              from sub in g.DefaultIfEmpty()
                              group new { category, sub } by new { category.Id } into grp
                              select new Category
                              {
                                  Id = grp.FirstOrDefault().category.Id,
                                  Name = grp.FirstOrDefault().category.Name,
                                  Color = grp.FirstOrDefault().category.Color,
                                  Spending = new List<Spending>(){new Spending {
                                    Month = startOfRange,
                                    Total = grp.Sum(g => g.sub.Amount),
                                  }}
                              };

                spending.AddRange(results);
                startOfRange = endOfRange;
            }

            foreach (Category category in spending)
            {
                if (categories.ContainsKey(category.Name))
                {
                    categories[category.Name].Spending.AddRange(category.Spending);
                }
                else
                {
                    categories[category.Name] = category;
                }
            }

            return categories.Select(kvp => kvp.Value).ToList<Category>();
        }
    }
}