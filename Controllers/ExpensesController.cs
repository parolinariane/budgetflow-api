using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetFlow.API.Data;
using BudgetFlow.API.Models;
using BudgetFlow.API.DTOs;
using BudgetFlow.API.Services;


namespace BudgetFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpensesController(IExpenseService service)
    {
        _service = service;
    }


    // GET: api/expenses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseResponseDto>>> GetExpenses()
    {
        var expenses = await _service.GetAllAsync();
        return Ok(expenses);
    }

    // GET: api/expenses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> GetExpense(int id)
    {
        var expense = await _service.GetByIdAsync(id);

        if (expense == null)
            return NotFound();

        return Ok(expense);
    }


    // POST: api/expenses
    [HttpPost]
    public async Task<ActionResult<ExpenseResponseDto>> CreateExpense(CreateExpenseDto dto)
    {
        var expense = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
    }


    // DELETE: api/expenses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }


    // PUT: api/expenses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(int id, UpdateExpenseDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }


}
