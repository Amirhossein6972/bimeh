using Bimeh.Domain.Coverages.Entities;
using Bimeh.Domain.Requests.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bimeh.Persistance
{
    public class BimehCommandDbContext : DbContext
    {
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestCoverage> RequestCoverages { get; set; }
        public DbSet<InsuranceCalculation> InsuranceCalculations { get; set; }

        public BimehCommandDbContext(DbContextOptions<BimehCommandDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
