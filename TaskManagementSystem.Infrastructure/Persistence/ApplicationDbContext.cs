
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Duty> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
           return base.SaveChangesAsync();
        }
    }
}
