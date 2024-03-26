using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public interface IDbContext
{
    DbSet<UserLogin> UserLogin { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}