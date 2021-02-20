using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
 
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
                    {
                Console.WriteLine("Araba veritabanına eklendi!");
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Kaydetmek istenilen arabanın markası 2 harfli veya daha fazla olmalıdır.");
                Console.WriteLine(" Ayrıca günlük kiralama bedeli de 0'dan farklı olmalıdır.");
            }


        
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByCarId(int carId)
        {
            return _carDal.GetAll(p => p.CarId == carId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
