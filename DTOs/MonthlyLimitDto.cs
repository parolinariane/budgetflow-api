namespace BudgetFlow.API.DTOs;

public class MonthlyLimitDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal LimitAmount { get; set; }
}
