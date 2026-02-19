namespace BudgetFlow.API.Services;

public interface IMonthlyLimitService
{
    Task SetMonthlyLimitAsync(int year, int month, decimal amount);
    Task<decimal> GetMonthlyLimitAsync(int year, int month);
}
