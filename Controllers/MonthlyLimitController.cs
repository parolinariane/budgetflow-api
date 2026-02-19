using BudgetFlow.API.DTOs;
using BudgetFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonthlyLimitController : ControllerBase
{
    private readonly IMonthlyLimitService _service;

    public MonthlyLimitController(IMonthlyLimitService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SetLimit([FromBody] MonthlyLimitDto dto)
    {
        await _service.SetMonthlyLimitAsync(dto.Year, dto.Month, dto.LimitAmount);
        return Ok();
    }

    [HttpGet("{year}/{month}")]
    public async Task<IActionResult> GetLimit(int year, int month)
    {
        var limit = await _service.GetMonthlyLimitAsync(year, month);
        return Ok(limit);
    }
}
