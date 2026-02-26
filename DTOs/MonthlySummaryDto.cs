namespace BudgetFlow.API.DTOs;

public class MonthlySummaryDto
{
    public decimal TotalExpenses { get; set; }
    public decimal Limit { get; set; }
    public decimal Remaining { get; set; }
}