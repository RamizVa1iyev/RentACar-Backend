using System;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorTest();
            //BrandTest();
            //AddingCars();
            //CarTest();
        }

        private static void AddingCars()
        {
            var carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                BrandId = 1, ColorId = 2, DailyPrice = 20000, ModelYear = 2016, Name = "Toyota Camry",
                Description =
                    "Is an automobile sold internationally by the Japanese manufacturer Toyota since 1982, spanning multiple generations"
            });
            carManager.Add(new Car()
            {
                BrandId = 3, Name = "Honda Accord", DailyPrice = 30000, ModelYear = 2019, ColorId = 1,
                Description = "Use the U.S. News Best Price Program to find the best local prices on the Accord."
            });
            carManager.Add(new Car()
            {
                BrandId = 5, ColorId = 3, DailyPrice = 15000, Name = "Hyundai Sonata", ModelYear = 2013,
                Description = "Is a mid-size car produced by the South Korean manufacturer Hyundai since 1985"
            });
        }

        private static void BrandTest()
        {
            var brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand() {Name = "Toyota"});
            brandManager.Add(new Brand() {Name = "Nissan"});
            brandManager.Add(new Brand() {Name = "Honda"});
            brandManager.Add(new Brand() {Name = "Mazda"});
            brandManager.Add(new Brand() {Name = "Hyundai"});
            var brands = brandManager.GetAll();
            foreach (var brand in brands.Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest()
        {
            var colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color() {Name = "White"});
            colorManager.Add(new Color() {Name = "Black"});
            colorManager.Add(new Color() {Name = "Red"});
            colorManager.Add(new Color() {Name = "Yellow"});
            colorManager.Add(new Color() {Name = "Green"});
            var colors = colorManager.GetAll();
            foreach (var color in colors.Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetAll();
            foreach (var car in cars.Data)
            {
                Console.WriteLine(
                    $"{car.Id} {car.BrandId} {car.ColorId} {car.Name} {car.ModelYear} {car.DailyPrice} {car.Description}");
            }

            var carDetails = carManager.GetAllCarDetails();
            foreach (var carDetail in carDetails.Data)
            {
                Console.WriteLine(
                    $"{carDetail.CarName} {carDetail.ColorName} {carDetail.BrandName} {carDetail.DailyPrice}");
            }
        }
    }
}
