namespace BudgetFlow.API.DTOs;

public class MonthlyTotalResponseDto
{
    public int Mes { get; set; }
    public int Ano { get; set; }
    public decimal Total { get; set; }
}
