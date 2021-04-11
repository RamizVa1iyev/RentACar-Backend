using System;
using System.Collections.Generic;
using Core.Utilities.Busniness;
using Core.Utilities.Results;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAllCarImages(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
        public IDataResult<CarImage> GetCarImageById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }
        public IResult Add(CarImage carImage)
        {
            var logic = new List<IResult> {CheckIfImageCountCorrect(carImage.CarId)};

            var result = BusinessRules.Run(logic);
            if (result!=null) return result;
            carImage.Date=DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult CheckIfImageCountCorrect(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount>=5)
            {
                return new ErrorResult(Messages.CarImagesCountIncorrect);
            }

            return new SuccessResult();
        }
    }
}
