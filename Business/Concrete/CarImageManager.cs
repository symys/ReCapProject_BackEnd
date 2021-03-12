using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager( ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( CarImage image, IFormFile file)
        {
            IResult result =  BusinessRules.Run(CheckIfCarImageCount(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult(Messages.AddedOperation);


        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage image)
        {
            IResult result = BusinessRules.Run(
               FileHelper.Delete(_carImageDal.Get(p => p.CarId == image.CarId).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ListOperation);
        }

        public IDataResult<CarImage> GetById(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId).Message); //?? emin değilim
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update( CarImage image, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarId == image.CarId).ImagePath, file);
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();

        }


        //business rules
        private IResult CheckIfCarImageCount(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (imageCount > 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }
            return new SuccessResult();

        }


        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\ReCapProject_images\arac1.jpg"; 
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList());
        }
    }
}
