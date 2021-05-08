using System.Threading;
using System.Threading.Tasks;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using ApplicationProcess.Domain.SeedWork;
using ApplicationProcess.Infrastructure.Repositories.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProcess.Infrastructure.Repositories.EF
{
    public class ApplicantContext : DbContext, IUnitOfWork
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicantEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
