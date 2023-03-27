using Microsoft.EntityFrameworkCore;

using Records.Appllication.Interfaces;
using Records.Domain;
using Records.Persistence.EntityTypeConfigurations;


namespace Records.Persistence
{
    public sealed class RecordsDbContext: DbContext, IRecordsDbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RecordsDbContext(DbContextOptions<RecordsDbContext> options):base(options) {

            this.EnsureSeedData();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
