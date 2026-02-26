using BudgetFlow.API.Data;
using BudgetFlow.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BudgetFlow.API.Services;

public class MonthlySummaryService : IMonthlySummaryService
{
    private readonly AppDbContext _context;

    public MonthlySummaryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MonthlySummaryDto> GetMonthlySummaryAsync(int year, int month)
    {
        // Total de despesas do mês
        var totalExpenses = await _context.Expenses
            .Where(e => e.Date.Year == year && e.Date.Month == month)
            .SumAsync(e => (decimal?)e.Amount) ?? 0;

        // Limite do mês
        var limit = await _context.MonthlyLimits
            .Where(l => l.Year == year && l.Month == month)
            .Select(l => l.LimitAmount)
            .FirstOrDefaultAsync();

        var remaining = limit - totalExpenses;

        return new MonthlySummaryDto
        {
            TotalExpenses = totalExpenses,
            Limit = limit,
            Remaining = remaining
        };
    }
}