using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SugarNestDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public SugarNestDbContext(DbContextOptions<SugarNestDbContext> options) : base(options)
    {

    }
}
