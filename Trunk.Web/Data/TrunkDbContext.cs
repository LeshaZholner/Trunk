using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trunk.Web.Data.Configuration;
using Trunk.Web.Data.Entities;

namespace Trunk.Web.Data;

public class TrunkDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Badge> Badges { get; set; }
    public DbSet<UserBadge> UserBadges { get; set; }

    public TrunkDbContext(DbContextOptions<TrunkDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        new BadgeConfiguration().Configure(builder.Entity<Badge>());
        new UserBadgeConfiguration().Configure(builder.Entity<UserBadge>());
    }
}
