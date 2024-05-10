using Bimeh.Domain.Coverages.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bimeh.Persistance.Coverages.Configurations
{
    public class CoverageTypeConfiguration : IEntityTypeConfiguration<Coverage>
    {
        private const string TableName = "Coverages";
        public void Configure(EntityTypeBuilder<Coverage> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(x => x.Rate)
                .HasColumnType("decimal(18,5)")
                .IsRequired();

            builder.Property(x => x.MaxCapital)
                .IsRequired();

            builder.Property(x => x.MinCapital)
                .IsRequired();

        }
    }
}
