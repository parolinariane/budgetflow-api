using AutoMapper;
using BudgetFlow.API.Models;
using BudgetFlow.API.DTOs;

namespace BudgetFlow.API.Mappings;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        // Entidade → Response DTO
        CreateMap<Expense, ExpenseResponseDto>();

        // Create DTO → Entidade
        CreateMap<CreateExpenseDto, Expense>();

        // Update DTO → Entidade
        CreateMap<UpdateExpenseDto, Expense>();
    }
}
