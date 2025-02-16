using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trunk.Web.Data.Entities;

namespace Trunk.Web.Data.Configuration;

public class UserBadgeConfiguration : IEntityTypeConfiguration<UserBadge>
{
    public void Configure(EntityTypeBuilder<UserBadge> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Badge)
            .WithMany()
            .HasForeignKey(x => x.BadgeId)
            .IsRequired();

        builder
            .HasOne(x => x.Reciever)
            .WithMany()
            .HasForeignKey(x => x.RecieverId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
