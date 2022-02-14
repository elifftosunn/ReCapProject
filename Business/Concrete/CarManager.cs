using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            if (car.Description.Length < 3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<CarDetailDto>> CarDetailDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetailDto());
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get((c => c.Id == id)));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId==ColorId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
