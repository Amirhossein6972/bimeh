using Bimeh.Domain.Requests.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bimeh.Persistance.Requests.Configurations
{
    public class RequestCoverageTypeConfiguration : IEntityTypeConfiguration<RequestCoverage>
    {
        private const string TableName = "RequestCoverages";
        public void Configure(EntityTypeBuilder<RequestCoverage> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestId)
                .IsRequired();

            builder.Property(x => x.CoverageId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();
        }
    }
}
