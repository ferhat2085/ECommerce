using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class CinemasController : Controller
{
    private readonly ICinemasService _service;

    public CinemasController(ICinemasService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allCinemas = await _service.GetAllAsync();
        return View(allCinemas);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await _service.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        var allCinemas = await _service.GetByIdAsync(id);

        if (allCinemas.Id == 0)
        {
            return View("_NotFound");
        }

        return View(allCinemas);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var allCinemas = await _service.GetByIdAsync(id);
        {
            return View("_NotFound");
        }

        return View(allCinemas);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await _service.UpdateAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var allCinemas = await _service.GetByIdAsync(id);
        if (allCinemas.Id == 0)
        {
            return View("_NotFound");
        }

        return View(allCinemas);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        await _service.DeleteAsync(Id);
        return RedirectToAction(nameof(Index));
    }
}