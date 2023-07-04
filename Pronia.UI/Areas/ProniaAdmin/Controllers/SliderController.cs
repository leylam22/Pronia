using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;
using Pronia.DataAccess.Contexts;
using Pronia.UI.Areas.ProniaAdmin.ViewModels.SliderViewModel;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;
[Area("ProniaAdmin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;

    public SliderController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Sliders.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(SliderPostVM sliderPostVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Slider slider = new()
        {
            Title = sliderPostVM.Title,
            Description = sliderPostVM.Description,
            Offer = sliderPostVM.Offer,
            ImagePath = sliderPostVM.ImagePath,
        };
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        return View(sliderdb);
    }

    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        _context.Sliders.Remove(sliderdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
