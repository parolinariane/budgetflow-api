using BudgetFlow.API.DTOs;

namespace BudgetFlow.API.Services;

public interface IMonthlySummaryService
{
    Task<MonthlySummaryDto> GetMonthlySummaryAsync(int year, int month);
}