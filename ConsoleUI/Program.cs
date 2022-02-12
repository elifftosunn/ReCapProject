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
            
            CarManager carManager = new CarManager(new EfCarDal());
            CarList(carManager);
            listingByColor(carManager,1);
            listingByBrand(carManager, 1);

        }
        static void CarList(CarManager carManager)
        {
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
        static void listingByColor(CarManager carManager,int colorId)
        {
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
        static void listingByBrand(CarManager carManager,int brandId)
        {
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
