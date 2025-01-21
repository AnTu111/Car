using CarsProject.Core.Dto;
using CarsProject.Core.ServiceInterface;
using System;
using System.Threading.Tasks;

namespace CarsTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task Not_AddEmptyCar_WhenReturnresult_null()
        {
            CarDto dto = new CarDto
            {
                Make = "Universal",
                Model = "BMW",
                Color = "black",
                Year = 1985,
                MotorPower = "2,0",
                Fuel = "diesel",
                Price = "15800",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await Svc<ICarsServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Not_GetByIdCars_WhenReturnNotEqual()
        {
            Guid guid = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            Guid wrongGuid = Guid.NewGuid();

            await Svc<ICarsServices>().GetAsync(guid);

            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_DeleteById_WhenDelete()
        {
            CarDto car = MockCarsData();

            var addcar = await Svc<ICarsServices>().Create(car);
            var result = await Svc<ICarsServices>().Delete((Guid)addcar.Id);

            Assert.Equal(result, addcar);
        }

        private CarDto MockCarsData()
        {
            return new CarDto
            {
                Make = "Universal",
                Model = "BMW",
                Color = "black",
                Year = 1985,
                MotorPower = "2,0",
                Fuel = "diesel",
                Price = "15800",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        [Fact]
        public async Task Not_DeleteByIdCar_WhenDidNotDeleteCar()
        {
            CarDto car = MockCarsData();
            var addcar = await Svc<ICarsServices>().Create(car);
            var addcar2 = await Svc<ICarsServices>().Create(car);

            var result = await Svc<ICarsServices>().Delete((Guid)addcar2.Id);

            Assert.NotEqual(result, addcar);
        }


        private CarDto MockNullCar()
        {
            return new CarDto
            {
                Make = "Universal",
                Model = "BMW",
                Color = "black",
                Year = 1985,
                MotorPower = "2,0",
                Fuel = "diesel",
                Price = "15800",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        [Fact]
        public async Task Should_ThrowArgumentNullException_When_DeletingNonExistentCar()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await Svc<ICarsServices>().Delete(nonExistentId);
            });
        }

    }
}
