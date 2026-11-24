using Microsoft.AspNetCore.Mvc;

namespace ARMSGUARD.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard() => View();
}
