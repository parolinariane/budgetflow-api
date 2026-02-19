using BudgetFlow.API.Data;
using BudgetFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetFlow.API.Services;

public class MonthlyLimitService : IMonthlyLimitService
{
    private readonly AppDbContext _context;

    public MonthlyLimitService(AppDbContext context)
    {
        _context = context;
    }

    public async Task SetMonthlyLimitAsync(int year, int month, decimal amount)
    {
        var existing = await _context.MonthlyLimits
            .FirstOrDefaultAsync(x => x.Year == year && x.Month == month);

        if (existing != null)
        {
            existing.LimitAmount = amount;
        }
        else
        {
            var newLimit = new MonthlyLimit
            {
                Year = year,
                Month = month,
                LimitAmount = amount
            };

            await _context.MonthlyLimits.AddAsync(newLimit);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetMonthlyLimitAsync(int year, int month)
    {
        var limit = await _context.MonthlyLimits
            .Where(x => x.Year == year && x.Month == month)
            .Select(x => x.LimitAmount)
            .FirstOrDefaultAsync();

        return limit;
    }
}
