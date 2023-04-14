using Sat.Recruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sat.Recruitment.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> User { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
