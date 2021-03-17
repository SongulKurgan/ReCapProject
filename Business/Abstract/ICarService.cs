using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetCarsByColor(int colorId);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetCarsByBrand(int brandId);  
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByModelYear(string year);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult TransactionalOperation(Car car);
    }     
}
