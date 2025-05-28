using Shared.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ProductDiscount : ICreatedTrackable, ILastUpdatedTrackable
{
    [Key]
    public Guid ProductDiscountId { get; set; }

    [Required]
    public DateTimeOffset? StartTime { get; set; }

    [Required]
    public DateTimeOffset? EndTime { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, double.MaxValue)]
    public decimal HardValue { get; set; } = 0;

    [Required]
    [Range(0, 100)]
    public int PercentValue { get; set; } = 0;

    [Column(TypeName = "bit")]
    public bool IsActive { get; set; } = true;


    public DateTimeOffset CreatedAt {  get; set; } = DateTimeOffset.UtcNow;
    public string? CreatedBy {  get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }


    public Guid? ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }
}
