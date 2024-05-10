using Bimeh.Domain.Requests.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bimeh.Persistance.Requests.Configurations
{
    public class InsuranceCalculationTypeConfiguration : IEntityTypeConfiguration<InsuranceCalculation>
    {
        private const string TableName = "InsuranceCalculations";
        public void Configure(EntityTypeBuilder<InsuranceCalculation> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestCoverageId)
                .IsRequired();

            builder.Property(x => x.Rate)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.Property(x => x.Result)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.HasOne(c => c.RequestCoverage)
                .WithOne(c => c.InsuranceCalculation)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
