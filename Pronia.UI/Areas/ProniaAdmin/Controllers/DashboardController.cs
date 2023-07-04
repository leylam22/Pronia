using Microsoft.AspNetCore.Mvc;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;
[Area("ProniaAdmin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
