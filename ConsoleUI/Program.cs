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
            CarDetailDto();

        }

        static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Car Name".PadRight(15) + "Brand Name".PadRight(15) + "Color Name".PadRight(15) + "Daily Price");
            Console.WriteLine("".PadRight(40, '-'));
            foreach (var car in carManager.CarDetailDto())
            {
                Console.WriteLine(car.CarName.PadRight(15) + car.BrandName + car.ColorName + car.DailyPrice.ToString());
            }
        }

        static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine();
            Console.WriteLine("Car Id".PadRight(15)+"Brand Id".PadRight(15)+"Color Id".PadRight(15)+"Model Year".PadRight(15)+
                "Daily Price".PadRight(15)+ "Description");
            Console.WriteLine("".PadRight(85,'-'));
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id.ToString().PadRight(15)+car.BrandId.ToString().PadRight(15)+
                    car.ColorId.ToString().PadRight(15)+car.ModelYear.ToString("yyyy").PadRight(15)+car.DailyPrice.ToString().PadRight(15)+car.Description);
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
            foreach (var car in carManager.GetCarsByColorId(colorId))
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
            foreach (var car in carManager.GetCarsByBrandId(brandId))
            {
                Console.WriteLine(car.Id.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                    car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
            }
            Console.WriteLine();
        }
    }
}
