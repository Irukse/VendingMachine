using Microsoft.EntityFrameworkCore;
using VendingMachine.Models.Entity;

namespace VendingMachine;

public class RepositoryContext : DbContext
{
    public RepositoryContext() { }

    /// <summary>
    ///     Delegate creating context to container 
    /// </summary>
    /// <param name="options"></param>
    public RepositoryContext(DbContextOptions<RepositoryContext> options, DbSet<Drink> drinks, DbSet<Coin> coins) 
        : base(options)
    {
        Drinks = drinks;
        Coins = coins;
    }

    /// <summary>
    ///     убедиться, что столбцы идентификатора увеличиваются 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;Port=5433;Database=vendingMachine;User Id=root;Password=root");
        }
    }
    public DbSet<Drink> Drinks { get; set; }

    public DbSet<Coin> Coins { get; set; }
}