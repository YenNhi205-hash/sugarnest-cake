using Shared.BaseEntities;
using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category : IDeletedTrackable, ICreatedTrackable, ILastUpdatedTrackable
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Status Status { get; set; } = Status.Active;

    [StringLength(500)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string? Description { get; set; }


    public DateTimeOffset DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}
