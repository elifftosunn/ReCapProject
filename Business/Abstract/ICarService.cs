using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int BrandId);
        List<Car> GetCarsByBrandId(int ColorId);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        Car Get(int id);
        List<CarDetailDto> CarDetailDto();
    }
}
