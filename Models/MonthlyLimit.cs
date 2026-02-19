using System.ComponentModel.DataAnnotations;

namespace BudgetFlow.API.Models;

public class MonthlyLimit
{
    public int Id { get; set; }

    [Range(2000, 2100, ErrorMessage = "Ano inválido.")]
    public int Year { get; set; }

    [Range(1, 12, ErrorMessage = "Mês inválido.")]
    public int Month { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O limite deve ser maior que zero.")]
    public decimal LimitAmount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
