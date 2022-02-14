using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> CarDetailDto()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join C in context.Color
                             on c.ColorId equals C.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 ColorName = C.ColorName,
                                 BrandName=b.BrandName,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
