using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.Repositories.EF.EntityConfigurations
{
    public class ApplicantEntityTypeConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            //builder.ToTable("Applicant")
            //    .HasKey(s => s.Id);

            builder.OwnsOne(s => s.Address, a =>
            {
                a.WithOwner();
            });
                //a.Property<int>("ApplicantId");
            //builder.Ignore(b => b.DomainEvents);
        }
    }
}