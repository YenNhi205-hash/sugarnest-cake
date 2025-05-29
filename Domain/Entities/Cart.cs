using Shared.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Cart : ICreatedTrackable
{
    [Key]
    public Guid CartId { get; set; }

    public DateTimeOffset? DeliveryTime { get; set; }

    [StringLength(500)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string? Note {  get; set; }

    [Required]
    [Column(TypeName = "bit")]
    public bool IsActive { set; get; } = true;


    public DateTimeOffset CreatedAt {  get; set; } = DateTimeOffset.UtcNow;
    public string? CreatedBy { get; set; }


    public Guid? UserId { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = [];
}
