using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess.Contexts;
using Pronia.UI.ViewModel;

namespace Pronia.UI.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM homeVM = new()
        {
            Silders =await _context.Sliders.ToListAsync()
        };
        return View(homeVM);
    }
}
