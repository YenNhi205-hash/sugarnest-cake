using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SugarNestDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductDiscount> ProductDiscounts { get; set; }

    public SugarNestDbContext(DbContextOptions<SugarNestDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(c =>
        {
            c.HasIndex(c => c.Name).IsUnique();
            c.Property(c => c.Name).UseCollation("SQL_Latin1_General_CP1_CI_AI");
            c.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Product>(p =>
        {
            p.HasIndex(p => p.Name).IsUnique();
            p.Property(p => p.Name).UseCollation("SQL_Latin1_General_CP1_CI_AI");
            p.HasMany(p => p.ProductDiscounts)
                .WithOne(p => p.Product)
                .HasForeignKey(pD => pD.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProductDiscount>(pD =>
        {
            pD.HasIndex(pD => new { pD.IsActive, pD.StartTime, pD.EndTime });
        });
    }
}
