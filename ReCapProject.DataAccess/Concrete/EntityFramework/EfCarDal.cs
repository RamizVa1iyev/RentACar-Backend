using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework.Contexts;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ECarContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using var context = new ECarContext();
            var result = from car in context.Cars
                         join color in context.Colors on car.ColorId equals color.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         select new CarDetailDto()
                         { Id = car.Id, CarName = car.Name, ColorName = color.Name, BrandName = brand.Name, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };
            return result.ToList();
        }
        public CarDetailDto GetAllCarDetailsById(int carId)
        {
            using var context = new ECarContext();
            var result = from car in context.Cars
                         join color in context.Colors on car.ColorId equals color.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         where car.Id == carId
                         select new CarDetailDto()
                         { Id = car.Id, CarName = car.Name, ColorName = color.Name, BrandName = brand.Name, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };
            return result.ToList()[0];
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using var context = new ECarContext();
            var result = from car in context.Cars
                         join color in context.Colors on car.ColorId equals color.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         where brand.Id == brandId
                         select new CarDetailDto()
                         { Id = car.Id, CarName = car.Name, ColorName = color.Name, BrandName = brand.Name, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };
            return result.ToList();
        }

        public List<CarDetailDto> GetCarDetailByColorAndBrandId(int colourId, int brandId)
        {
            using var context = new ECarContext();
            var result = from car in context.Cars
                         join color in context.Colors on car.ColorId equals color.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         where brand.Id == brandId && color.Id == colourId
                         select new CarDetailDto()
                         { Id = car.Id, CarName = car.Name, ColorName = color.Name, BrandName = brand.Name, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear };
            return result.ToList();
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            using var context = new ECarContext();
            var result = from car in context.Cars
                         join color in context.Colors on car.ColorId equals color.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         where color.Id == colorId
                         select new CarDetailDto()
                         { Id = car.Id, CarName = car.Name, ColorName = color.Name, BrandName = brand.Name, DailyPrice = car.DailyPrice };
            return result.ToList();
        }


    }
}
