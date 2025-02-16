using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trunk.Web.Data.Entities;

namespace Trunk.Web.Data.Configuration;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Issuer)
            .WithMany()
            .HasForeignKey(x => x.IssuerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(2000);
    }
}
