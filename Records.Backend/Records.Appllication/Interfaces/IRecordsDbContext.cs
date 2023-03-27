using Records.Domain;
using Microsoft.EntityFrameworkCore;

namespace Records.Appllication.Interfaces
{
    public interface IRecordsDbContext
    {
        DbSet<Record> Records { get; set; }  
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
