using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private readonly List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id = 1,ColorId = 2,BrandId = 2,Name = "Toyota",DailyPrice = 20000,ModelYear = 2016,Description = "A very comfortable car"},
                new Car(){Id = 1,ColorId = 1,BrandId = 1,Name = "Mercedes",DailyPrice = 20000,ModelYear = 2016,Description = "A very fast car"}
            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _cars : _cars.Where(filter.Compile()).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.FirstOrDefault(filter.Compile());
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Update(Car entity)
        {
            var updatedCar = _cars.FirstOrDefault(c => c.Id == entity.Id);
            var index = _cars.IndexOf(updatedCar);
            _cars.Remove(updatedCar);
            _cars.Insert(index,updatedCar);
        }

        public void Delete(Car entity)
        {
            var deleted = _cars.FirstOrDefault(c => c.Id == entity.Id);
            _cars.Remove(deleted);
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByColorAndBrandId(int colourId, int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetAllCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
