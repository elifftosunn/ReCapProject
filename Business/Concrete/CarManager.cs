using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal CarDal;
        public CarManager(ICarDal carDal)
        {
            this.CarDal = carDal;
        }

        public List<Car> GetAll()
        {
            return CarDal.GetAll();
        }

        public List<Car> GetById(int BrandId)
        {
            return CarDal.GetById(BrandId);
        }
    }
}
