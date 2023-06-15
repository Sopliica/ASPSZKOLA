using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Controllers;

public class RentalController : Controller
{
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;


    public RentalController(IRepository<Rental> rentalRepository, IMapper mapper)
    {
        _rentalRepository = rentalRepository;
        _mapper = mapper;
    }
    //[Authorize]
    public async Task<IActionResult> Index()
    {
        List<Rental> result = new List<Rental>();
        result = (await _rentalRepository.GetAll()).ToList();
        return View(result);

    }
    public async Task<IActionResult> GetSingleRentalById(int id)
    {
        Rental result;
        result = await (_rentalRepository.GetSingle(id));
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Rental rental)
    {
        Rental result;
        result = await _rentalRepository.Create(rental);
        return View(result);
    }
    public async Task<IActionResult> Delete(Rental rental)
    {
        await _rentalRepository.Delete(rental);
    
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(Rental rental)
    {
        var result = await _rentalRepository.Update(rental);
        return View(result);
    }

}
