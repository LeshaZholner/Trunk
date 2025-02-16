namespace Trunk.Web.Data.Entities;

public class Badge
{
    public Guid Id { get; set; }
    public string? IssuerId { get; set; } 
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string IssuerName { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public ApplicationUser? Issuer { get; set; }
}
