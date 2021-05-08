using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationProcess.Infrastructure.Repositories.EF.EntityConfigurations
{
    public class ApplicantEntityTypeConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsOne(s => s.Address, a =>
            {
                a.WithOwner();
            });
            builder.Ignore(b => b.DomainEvents);
        }
    }
}