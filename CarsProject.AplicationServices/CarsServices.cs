using CarsProject.Core.Domain;
using CarsProject.Core.Dto;
using CarsProject.Core.ServiceInterface;
using CarsProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CarsProject.AplicationServices
{
    public class CarsServices : ICarsServices
    {
        private readonly CarsProjectContext _context;

        public CarsServices
            (
                CarsProjectContext context
            )
        {
            _context = context;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.MotorPower = dto.MotorPower;
            car.Fuel = dto.Fuel;
            car.Price = dto.Price;


            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
               .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return (result);
        }

        public async Task<Car> Update(CarDto dto)
        {

            var domain = new Car();

            domain.Id = dto.Id;
            domain.Make = dto.Make;
            domain.Model = dto.Make;
            domain.Year = dto.Year;
            domain.Color = dto.Color;
            domain.MotorPower = dto.MotorPower;
            domain.Fuel = dto.Fuel;
            domain.Price = dto.Price;

            domain.CreatedAt = DateTime.Now;
            domain.UpdatedAt = DateTime.Now;

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
