using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class ProducersController : Controller
{
    private readonly IProducersService _service;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()   
    {
        var allProducers = await _service.GetAllAsync();
        return View(allProducers);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        var producerDetail = await _service.GetByIdAsync(id);
        if (producerDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(producerDetail);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var producerDetail = await _service.GetByIdAsync(id); 
        {
            return View("_NotFound");
        }

        return View(producerDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        await _service.UpdateAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var producerDetail = await _service.GetByIdAsync(id);
        if (producerDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(producerDetail);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        await _service.DeleteAsync(Id);
        return RedirectToAction(nameof(Index));
    }
}