using Microsoft.AspNetCore.Mvc;

namespace ARMSGUARD.Controllers;

public class MarketplaceController : Controller
{
    public IActionResult Index() => View();
}
