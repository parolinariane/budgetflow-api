using Microsoft.EntityFrameworkCore;
using BudgetFlow.API.Models;

namespace BudgetFlow.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Expense> Expenses => Set<Expense>();
}