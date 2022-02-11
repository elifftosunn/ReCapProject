using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            CarList(carManager);

            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            Car car = new Car { Id=6,BrandId=3,ColorId=3,ModelYear=new DateTime(2022,1,1),DailyPrice=7500,Description="BMW Model"};
            inMemoryCarDal.Add(car);
            CarList(new CarManager(inMemoryCarDal));


            inMemoryCarDal.Delete(car);
            CarList(new CarManager(inMemoryCarDal));


            listingByBrand(new CarManager(inMemoryCarDal),2);


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
        static void listingByBrand(CarManager carManager,int brandId)
        {
            Console.WriteLine();
            Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
            Console.WriteLine("".PadRight(85, '-'));
            foreach (var car in carManager.GetById(brandId))
            {
                Console.WriteLine(car.Id.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                    car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
            }
            Console.WriteLine();
        }
    }
}
