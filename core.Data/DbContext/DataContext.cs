using core.Domain.People.Entities;
using Microsoft.EntityFrameworkCore;

namespace core.Data.DbContext
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Person> Contatos { get; set; }

        public DataContext(DbContextOptions<DataContext> opts)
        : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}