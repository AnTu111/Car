using CarsProject.Core.Dto;
using CarsProject.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnresult()
        {
            CarDto dto = new CarDto();

            dto.Make = "Name";
            dto.Model = "Model";
            dto.Color = "red";
            dto.Year = 123;
            dto.MotorPower = "1,8";
            dto.Fuel = "petrol";
            dto.Price = "1234";

            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            var result = await Svc<ICarsServices>().Create(dto);

            Assert.NotNull(result);

        }
        [Fact]
        //chack a path for elements
        public async Task ShouldNot_GetByIdCars_WhenReturnNotEqual()

        {
            Guid guid = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
           
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            //act
            await Svc<ICarsServices>().GetAsync(guid);
            //assert
            Assert.NotEqual(guid, wrongGuid);
        }
        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            CarDto car = MockCarsData();

            var addcar = await Svc<ICarsServices>().Create(car);
            var result = await Svc<ICarsServices>().Delete((Guid)addcar.Id);

            Assert.Equal(result, addcar);
        }
        private CarDto MockCarsData()
        {
            CarDto car = new()
            {
                Make = "Name",
                Model = "Model",
                Color = "red",
                Year = 123,
                MotorPower = "1,8",
                Fuel = "petrol",
                Price = "1234",

                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return car;

        }
        [Fact]
        public async Task SouldNot_DeleteByIdCar_WhenDidNotDeleteCar()
        {
            CarDto car = MockCarsData();
            var addcar = await Svc<ICarsServices>().Create(car);
            var addcar2 = await Svc<ICarsServices>().Create(car);

            var result = await Svc<ICarsServices>().Delete((Guid)addcar2.Id);

            Assert.NotEqual(result, addcar);

        }
        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUdateData()
        {
            CarDto dto = MockCarsData();
            await Svc<ICarsServices>().Create(dto);


            CarDto nullUpdate = MockNullCar();
            await Svc<ICarsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);

        }
        private CarDto MockNullCar()
        {
            CarDto nullDto = new()
            {
                Make = "Name",
                Model = "Model",
                Color = "red",
                Year = 123,
                MotorPower = "1,8",
                Fuel = "petrol",
                Price = "1234",

                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return nullDto;
        }

    }
}
