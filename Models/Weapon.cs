using System.ComponentModel.DataAnnotations;

namespace ARMSGUARD.Models;

public sealed class Weapon
{
    public int WeaponId { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Category { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Manufacturer { get; set; } = string.Empty;

    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [StringLength(500)]
    public string ImagePath { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}
