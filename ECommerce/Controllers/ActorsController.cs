using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();
        return View(allActors);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        var actorDetail = await _service.GetByIdAsync(id);
        if (actorDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(actorDetail);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var actorDetail = await _service.GetByIdAsync(id);
        if (actorDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(actorDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.UpdateAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var actorDetail = await _service.GetByIdAsync(id);
        if (actorDetail.Id ==0)
        {
            return View("_NotFound");
        }

        return View(actorDetail);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        await _service.DeleteAsync(Id);
        return RedirectToAction(nameof(Index));
    }
}