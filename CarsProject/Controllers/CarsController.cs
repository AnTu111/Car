using CarsProject.Core.Dto;
using CarsProject.Core.ServiceInterface;
using CarsProject.Data;
using CarsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsProjectContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController
        (
                CarsProjectContext context,
                ICarsServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
        }


        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsViewModel
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    Color = x.Color,
                    Year = x.Year,
                    MotorPower = x.MotorPower,
                    Fuel = x.Fuel,
                    Price = x.Price,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateViewModel result = new CarsCreateUpdateViewModel();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Year = vm.Year,
                MotorPower = vm.MotorPower,
                Fuel = vm.Fuel,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;

            vm.MotorPower = car.MotorPower;
            vm.Fuel = car.Fuel;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Year = vm.Year,
                Color = vm.Color,
                MotorPower = vm.MotorPower,
                Fuel = vm.Fuel,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsDetailsViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Color = car.Color;
            vm.MotorPower = car.MotorPower;
            vm.Fuel = car.Fuel;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;


            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsDeleteViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Color = car.Color;
            vm.MotorPower = car.MotorPower;
            vm.Fuel = car.Fuel;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

