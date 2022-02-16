using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleeUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // BrandGet();
            //UserTest();
            //UserActions();
            //ColorGet();
            //CarDetailDto();
            //CarList();
            //listingByColor(2);
            //listingByBrand(1);


            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Id = 9, BrandId = 2, ColorId = 2, DailyPrice = 9000, Description = "a", ModelYear = new DateTime(2020,10,5) });      
            //carManager.Add(new Car { Id = 8, BrandId = 2, ColorId = 1, DailyPrice = 8000, Description = "ABC", ModelYear = new DateTime(2020,10,5) });      +
            //CarList();



            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new Users { Id = 11, FirstName = "Deniz", LastName = "Ay", Email = "deniz@gmail.com", Password = "12345" });  
            //userManager.Update(new Users { Id = 7, FirstName = "Deniz", LastName = "Ay", Email = "deniz@gmail.com", Password = "12345" });  
            userManager.Delete(new User {UserId = 8, FirstName = "A", LastName = "", Email = "info@gmail.com", Password = "134" });    
            //userManager.Update(new Users { Id = 10, FirstName = "Selen", LastName = "Ay", Email = "selen@gmail.com", Password = "12345678" });

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.UserId + "  " + user.FirstName + " " + user.LastName + " " + user.Email + "  " + user.Password);
            }


        }

        private static void UserActions()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new Users { Id = 6, FirstName = "Deniz", LastName = "Ay", Email = "deniz@gmail.com", Password = "12345" });  +
            //userManager.Add(new Users { Id = 7, FirstName = "Deniz", LastName = "Ay", Email = "deniz@gmail.com", Password = "12345" });  +
            //userManager.Delete(new Users { Id = 7, FirstName = "Deniz", LastName = "Ay", Email = "deniz@gmail.com", Password = "12345" });  +  
            userManager.Update(new User { UserId = 6, FirstName = "Selen", LastName = "Ay", Email = "selen@gmail.com", Password = "12345678" });

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.UserId + "  " + user.FirstName + " " + user.LastName + " " + user.Email + "  " + user.Password);
            }
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserDetails();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.CompanyName + " " + user.Email);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
                    Console.WriteLine(car.CarId.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
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
            var result = carManager.GetCarsByColorId(colorId);
            if (result.Success)
            {
                Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
                Console.WriteLine("".PadRight(85, '-'));
                foreach (var car in carManager.GetCarsByColorId(colorId).Data)
                {
                    Console.WriteLine(car.CarId.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                        car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.WriteLine();
        }
        static void listingByBrand(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine();
            var result = carManager.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                Console.WriteLine("Car Id".PadRight(15) + "Brand Id".PadRight(15) + "Color Id".PadRight(15) + "Model Year".PadRight(15) +
                "Daily Price".PadRight(15) + "Description");
                Console.WriteLine("".PadRight(85, '-'));
                foreach (var car in carManager.GetCarsByBrandId(brandId).Data)
                {
                    Console.WriteLine(car.CarId.ToString().PadRight(15) + car.BrandId.ToString().PadRight(15) +
                        car.ColorId.ToString().PadRight(15) + car.ModelYear.ToString("yyyy").PadRight(15) + car.DailyPrice.ToString().PadRight(15) + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine();
        }
    }
}
