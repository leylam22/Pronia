using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pronia.Core.Utilites;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;
[Area("ProniaAdmin")]
[Authorize(Roles =UserRole.Admin)]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
