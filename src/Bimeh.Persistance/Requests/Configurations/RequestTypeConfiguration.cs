using Bimeh.Domain.Requests.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bimeh.Persistance.Requests.Configurations
{
    public class RequestTypeConfiguration : IEntityTypeConfiguration<Request>
    {
        private const string TableName = "Requests";
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(c => c.Coverages)
                .WithOne(c => c.Request)
                .HasForeignKey(c => c.RequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
