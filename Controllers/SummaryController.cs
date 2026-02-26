using BudgetFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SummaryController : ControllerBase
{
    private readonly IMonthlySummaryService _service;

    public SummaryController(IMonthlySummaryService service)
    {
        _service = service;
    }

    [HttpGet("{year}/{month}")]
    public async Task<IActionResult> GetSummary(int year, int month)
    {
        var summary = await _service.GetMonthlySummaryAsync(year, month);
        return Ok(summary);
    }
}