using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car { Id=1,BrandId=1,ColorId=1,ModelYear=new DateTime(1990,8,5),DailyPrice=8000,Description="Ford Model"},
                new Car { Id=2,BrandId=1,ColorId=1,ModelYear=new DateTime(2000,7,6),DailyPrice=7000,Description="Audi Model"},
                new Car { Id=3,BrandId=2,ColorId=2,ModelYear=new DateTime(2010,6,7),DailyPrice=6000,Description="BMW Model"},
                new Car { Id=4,BrandId=2,ColorId=3,ModelYear=new DateTime(2020,5,8),DailyPrice=5000,Description="Bugatti Model"},
                new Car { Id=5,BrandId=3,ColorId=2,ModelYear=new DateTime(2019,4,9),DailyPrice=4000,Description="Alfa Model"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete= _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
