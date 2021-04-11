using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICarImageService _carImageService;

        public CarImagesController(IWebHostEnvironment hostEnvironment, ICarImageService carImageService)
        {
            _hostEnvironment = hostEnvironment;
            _carImageService = carImageService;
        }

        [HttpGet("getByCar/{carId}")]
        public IActionResult GetById(int carId)
        {
            var result = _carImageService.GetAllCarImages(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{carId}/upload")]
        public IActionResult LoadImage([FromForm]IFormFile file,int carId)
        {
            
            var carImageCount = _carImageService.GetAllCarImages(carId).Data.Count+1;
            var extension = Path.GetExtension(file.FileName);
            var filePath = $"{_hostEnvironment.WebRootPath}\\Pictures\\";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string picturePath = $"{_hostEnvironment.WebRootPath}\\Pictures\\{carId}.{carImageCount}{extension}";
            var carImage = new CarImage()
            {
                CarId = carId,
                ImagePath = picturePath
            };
            var result = _carImageService.Add(carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            using var fileStream = System.IO.File.Create(picturePath);
            file.CopyTo(fileStream);
            fileStream.Flush();
            return Ok(result);

        }
        [HttpPost("delete/{carImageId}")]
        public IActionResult DeleteImage(int carImageId)
        {
            var carImageResult = _carImageService.GetCarImageById(carImageId);
            if (!carImageResult.Success)
            {
                return BadRequest(carImageResult);
            }
            var result = _carImageService.Delete(carImageResult.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            if (System.IO.File.Exists(carImageResult.Data.ImagePath))
            {
                System.IO.File.Delete(carImageResult.Data.ImagePath);
            }
            return Ok(result);
        }
        [HttpPost("update/{carImageId}")]
        public IActionResult UpdateImage([FromForm]IFormFile file,int carImageId)
        {
            var carImageResult = _carImageService.GetCarImageById(carImageId);
            if (!carImageResult.Success)
            {
                return BadRequest(carImageResult);
            }

            var carImage = new CarImage()
            {
                Id = carImageId, Date = DateTime.Now, ImagePath = carImageResult.Data.ImagePath,
                CarId = carImageResult.Data.CarId
            };
            var result = _carImageService.Update(carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            using var fileStream = System.IO.File.Create(carImageResult.Data.ImagePath);
            file.CopyTo(fileStream);
            fileStream.Flush();
            return Ok(result);
        }
    }
}
