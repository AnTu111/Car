using CarsProject.Core.Domain;
using CarsProject.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsProject.Core.Domain;
using CarsProject.Core.Dto;
using System;

namespace CarsProject.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> GetAsync(Guid id);
        Task<Car> Delete(Guid id);
        Task<Car> Update(CarDto dto);
    }
}
