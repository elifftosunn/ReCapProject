using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        [ValidationAspect(typeof(CarValidator))] 
        public IResult Add(Car car)
        {   
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }
        public IDataResult<List<CarDetailDto>> CarDetailDto()
        {
            var result = _carDal.CarDetailDto();
            if (result != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result,Messages.CarDetailListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.isNotId);
        }

        public IResult Delete(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Car> Get(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(Messages.isNotId);  
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
