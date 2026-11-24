using ARMSGUARD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARMSGUARD.Controllers;

public class WeaponController : Controller
{
    public IActionResult Catalog() => View(WeaponCatalog.Items);

    public IActionResult Details(string? id)
    {
        var weapon = WeaponCatalog.Items.FirstOrDefault(item => item.Id == id);
        return weapon is null ? NotFound() : View(weapon);
    }
}
