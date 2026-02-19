using Microsoft.EntityFrameworkCore;
using BudgetFlow.API.Data;
using BudgetFlow.API.DTOs;
using BudgetFlow.API.Models;

namespace BudgetFlow.API.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExpenseResponseDto>> GetAllAsync()
    {
        var expenses = await _context.Expenses.ToListAsync();

        return expenses.Select(e => new ExpenseResponseDto
        {
            Id = e.Id,
            Title = e.Title,
            Category = e.Category,
            Amount = e.Amount,
            Date = e.Date
        });
    }

    public async Task<ExpenseResponseDto?> GetByIdAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return null;

        return new ExpenseResponseDto
        {
            Id = expense.Id,
            Title = expense.Title,
            Category = expense.Category,
            Amount = expense.Amount,
            Date = expense.Date
        };
    }

    public async Task<ExpenseResponseDto> CreateAsync(CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Title = dto.Title,
            Category = dto.Category,
            Amount = dto.Amount,
            Date = dto.Date
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return new ExpenseResponseDto
        {
            Id = expense.Id,
            Title = expense.Title,
            Category = expense.Category,
            Amount = expense.Amount,
            Date = expense.Date
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateExpenseDto dto)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return false;

        expense.Title = dto.Title;
        expense.Category = dto.Category;
        expense.Amount = dto.Amount;
        expense.Date = dto.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return false;

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return true;
    }
}
