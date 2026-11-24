using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ARMSGUARD.Models;

public sealed class ApplicationUser : IdentityUser
{
    [Required, StringLength(120)]
    public string FullName { get; set; } = string.Empty;
}
