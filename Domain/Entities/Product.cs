using Shared.BaseEntities;
using Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Domain.Entities;

public class Product : IDeletedTrackable, ICreatedTrackable, ILastUpdatedTrackable
{
    [Key]
    public Guid ProductId { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Status Status { get; set; } = Status.Active;

    [StringLength(500)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, double.MaxValue)]
    public decimal? UnitPrice { get; set; }

    [StringLength(500)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string? Imgs { get; set; }


    public DateTimeOffset DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }


    public Guid? CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public ICollection<ProductDiscount> ProductDiscounts { get; set; } = [];

    public ICollection<CartItem> CartItems { get; set; } = [];
}
