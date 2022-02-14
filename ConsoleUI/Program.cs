using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarList();
            //listingByColor(1);
            //listingByBrand(1);
            //CarDetailDto();


            CarManager carManager = new CarManager(new EfCarDal());
            //Console.WriteLine(carManager.Get(1).BrandId+" "+carManager.Get(1).Description+" "+carManager.Get(1).DailyPrice); +
            //carManager.Add(new Car { ColorId = 4, BrandId = 4, DailyPrice = 8000, Description = "Audi", ModelYear = new DateTime(2022, 3, 25) });
            //CarList(); 

            //carManager.Delete(car); +
            //carManager.Update(car); +
            Car car = new Car
            {
                Id = 1,
                BrandId = 2,
                ColorId = 3,
                ModelYear = new DateTime(2019, 5, 10),
                DailyPrice = 8000,
                Description = "Alfa"
            };
            //carManager.Update(car);
            //carManager.CarDetailDto();
            //CarList();
            //BrandGet();
            //ColorGet();
            //listingByBrand(2);
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result=customerManager.GetAll();
            UserManager userManager = new UserManager(new EfUserDal());
            //var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.CompanyName+" "+user.UserId);
            }
        }

        private static void BrandGet()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand { BrandId = 1, BrandName = "Audi" };
            //brandManager.Delete(brand1); +
            //brandManager.Update(new Brand { BrandId = 2, BrandName = "Audi" }); +
            //brandManager.Add(new Brand { BrandId = 10, BrandName = "Ford" }); +

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Console.WriteLine();
        }

        private static void ColorGet()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorId = 7, ColorName = "Black" }); +
            //colorManager.Update(new Color { ColorId=7,ColorName="Brown"}); +
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Car Name".PadRight(15) + "Brand Name".PadRight(15) + "Color Name".PadRight(15) + "Daily Price");
            Console.WriteLine("".PadRight(40, '-'));
            foreach (var car in carManager.CarDetailDto().Data)
            {
                Console.WriteLine(car.CarName.PadRight(15) + car.BrandName + car.ColorName + car.DailyPrice.ToString());
            }
        }
        static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            Console.WriteLine();
            if (result.Success)
            {
                Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
                Console.WriteLine("".PadRight(85, '-'));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                        car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.WriteLine();
        }
        static void listingByColor(int colorId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine();
            Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
            Console.WriteLine("".PadRight(85, '-'));
            foreach (var car in carManager.GetCarsByColorId(colorId).Data)
            {
                Console.WriteLine(car.Id.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                    car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
            }
            Console.WriteLine();
        }
        static void listingByBrand(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine();
            Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
            Console.WriteLine("".PadRight(85, '-'));
            foreach (var car in carManager.GetCarsByBrandId(brandId).Data)
            {
                Console.WriteLine(car.Id.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                    car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
            }
            Console.WriteLine();
        }
    }
}
