using Microsoft.AspNetCore.Mvc;

namespace ARMSGUARD.Controllers;

public class LicensingController : Controller
{
    public IActionResult Apply() => View();

    public IActionResult Tracking() => View();
}
