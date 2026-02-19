using Microsoft.EntityFrameworkCore;
using BudgetFlow.API.Data;
using BudgetFlow.API.DTOs;
using BudgetFlow.API.Models;
using AutoMapper;


namespace BudgetFlow.API.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ExpenseService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<IEnumerable<ExpenseResponseDto>> GetAllAsync()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);
    }


    public async Task<ExpenseResponseDto?> GetByIdAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return null;

        return _mapper.Map<ExpenseResponseDto>(expense);
    }


    public async Task<ExpenseResponseDto> CreateAsync(CreateExpenseDto dto)
    {
        var expense = _mapper.Map<Expense>(dto);

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return _mapper.Map<ExpenseResponseDto>(expense);
    }


    public async Task<bool> UpdateAsync(int id, UpdateExpenseDto dto)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return false;

        _mapper.Map(dto, expense);

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
