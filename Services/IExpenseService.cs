using BudgetFlow.API.DTOs;

namespace BudgetFlow.API.Services;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseResponseDto>> GetAllAsync();
    Task<ExpenseResponseDto?> GetByIdAsync(int id);
    Task<ExpenseResponseDto> CreateAsync(CreateExpenseDto dto);
    Task<bool> UpdateAsync(int id, UpdateExpenseDto dto);
    Task<bool> DeleteAsync(int id);
}
