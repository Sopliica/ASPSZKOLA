using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using WebApplication4.Models;
using WebApplication4.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication4.Controllers
{
    public class VehicleController : Controller
    {

        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;


        public VehicleController(IRepository<Vehicle> vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            List<Vehicle> resoult = new List<Vehicle>();
            resoult = (await _vehicleRepository.GetAll()).ToList();
            return View(resoult);

        }
        public async Task<IActionResult> GetSingleVehicleById(int id)
        {
            Vehicle result;
            result = await (_vehicleRepository.GetSingle(id));
            return View(result);
        }

        // GET: VehicleController/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            Vehicle result;
            result = await _vehicleRepository.Create(vehicle);
            return View(result);
        }

  
        public async Task<IActionResult> Delete(Vehicle vehicle)
        {
            _vehicleRepository.Delete(vehicle);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Vehicle vehicle)
        {
            var result = await _vehicleRepository.Update(vehicle);
            return View(result);
        }
    }


}