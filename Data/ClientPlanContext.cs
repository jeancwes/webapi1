using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Data
{
    public class ClientPlanContext : DbContext
    {
        public ClientPlanContext(DbContextOptions<ClientPlanContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientPlan>()
                .HasKey(cp => new { cp.ClientId, cp.PlanId });
            modelBuilder.Entity<ClientPlan>()
                .HasOne(cp => cp.Client)
                .WithMany(c => c.Plans)
                .HasForeignKey(cp => cp.ClientId);
            modelBuilder.Entity<ClientPlan>()
                .HasOne(cp => cp.Plan)
                .WithMany(p => p.Clients)
                .HasForeignKey(cp => cp.PlanId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Plans)
                .WithOne(e => e.Client);

            modelBuilder.Entity<Plan>()
                .HasMany(p => p.Clients)
                .WithOne(e => e.Plan);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ClientPlan> ClientPlans { get; set; }
    }
}
