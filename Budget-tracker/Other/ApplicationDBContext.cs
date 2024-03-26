using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext, IDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserLogin> UserLogin { get; set; }

    // Implement IDbContext interface's SaveChangesAsync if not already covered by DbContext
    Task<int> IDbContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    // You can override the OnModelCreating method if you need to configure entities' models further:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // For example, configure the UserLogin entity
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id); // Define primary key
            // Define other properties configurations if needed
        });
    }
}