using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class CartItem
{
    [Key]
    public Guid CartItemId { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; } = 0;

    [Required]
    [Range(1, 1000)]
    public int Quantity { get; set; } = 1;

    [StringLength(500)]
    [RegularExpression(@"^[\p{L}\p{N}\p{P}\p{S}\p{Zs}]$")]
    public string? Note { get; set; }


    public Guid CartId { get; set; }

    [ForeignKey(nameof(CartId))]
    public Cart? Cart { get; set; }

    public Guid? ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }
}
