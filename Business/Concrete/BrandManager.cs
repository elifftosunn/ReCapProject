using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            this._brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName == "" || brand.BrandName.Length<2)
            {
                new ErrorResult(Messages.NameInvalid);   
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.brandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandName == "" && brand.BrandName.Length<3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.brandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.brandListed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.brandUpdated);
        }
    }
}
