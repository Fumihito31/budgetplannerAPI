using Microsoft.AspNetCore.Mvc;
using BudgetPlannerAPI.Data;
using Microsoft.EntityFrameworkCore;
using BudgetPlannerAPI.Models;

namespace BudgetPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly BudgetPlannerContext _context;

        public DashboardController(BudgetPlannerContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDashboardData(int userId)
        {
            var totalIncome = await _context.Incomes.Where(i => i.UserId == userId).SumAsync(i => i.Amount);
            var totalExpenses = await _context.Expenses.Where(e => e.UserId == userId).SumAsync(e => e.Amount);
            var netIncome = totalIncome - totalExpenses;

            return Ok(new { TotalIncome = totalIncome, TotalExpenses = totalExpenses, NetIncome = netIncome });
        }
    }
}
