﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.AddedCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(I => I.CarImageId == carImage.CarImageId).ImagePath;

            //var result = BusinessRules.Run(FileHelper.Delete(oldpath));

            //if (result != null)
            //{
            //    return result;
            //}

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(GetDefaultIfNull(carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.CarImageId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath;
            carImage.ImagePath = FileHelper.Update(file , oldpath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckCarImageLimit(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.FailedCarImageAdd);
            }

            return new SuccessResult();
        }

        private List<CarImage> GetDefaultIfNull(int carId)
        {
            string path = @"default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }
        

    }
}
