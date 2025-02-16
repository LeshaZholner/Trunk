namespace Trunk.Web.Data.Entities;

public class UserBadge
{
    public Guid Id {  get; set; }
    public Guid BadgeId { get; set; }
    public required string RecieverId { get; set; }
    public Badge? Badge { get; set; }
    public ApplicationUser? Reciever { get; set; }
}
