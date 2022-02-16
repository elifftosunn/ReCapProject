using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("CarDetailDto")]
        public IActionResult CarDetailDto()
        {
            var result = _carService.CarDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]  
        public IActionResult Added(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")] //--------------
        public IActionResult Deleted(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]  //-------------
        public IActionResult Updated(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarsByColorId")]  
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }











        /*
        [HttpGet]
        public List<Car> GetAll()
        {
            ICarService _carService = new CarManager(new EfCarDal());
            var result=_carService.GetAll();
            return result.Data;   
        }*/

        /*
        [HttpGet]
        public new List<Car> Get()
        {
            return new List<Car>
            {
                new Car { BrandId=1,ColorId=1,DailyPrice=8000,Description="Audi",ModelYear=new DateTime(2020,10,5)},
                new Car { BrandId=1,ColorId=2,DailyPrice=9000,Description="Audi",ModelYear=new DateTime(2021,5,30)},
                new Car { BrandId=2,ColorId=2,DailyPrice=10000,Description="Audi",ModelYear=new DateTime(2022,4,8)},
                new Car { BrandId=2,ColorId=1,DailyPrice=11000,Description="Audi",ModelYear=new DateTime(2021,5,6)}
            };
        }*/
    }
}
