using System.ComponentModel.DataAnnotations;

namespace BudgetFlow.API.DTOs;

public class CreateExpenseDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "A data é obrigatória.")]
    public DateTime Date { get; set; }
}

