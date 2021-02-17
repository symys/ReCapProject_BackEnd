using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ModelYear=2015, DailyPrice=100, Description="İstanbul'dan alıp 20 şehirden istediğinde teslim etme imkanı!"},
                new Car{CarId=2, BrandId=2, ModelYear=2018, DailyPrice=175, Description="İstanbul veya İzmir'den alıp 20 şehirden istediğinde teslim etme imkanı!"},
                new Car{CarId=3, BrandId=1, ModelYear=2019, DailyPrice=200, Description="İstanbul'dan alıp 15 şehirden istediğinde teslim etme imkanı!"},
                new Car{CarId=4, BrandId=3, ModelYear=2020, DailyPrice=300, Description="İstanbul'dan veya Ankara'dan alıp 5 şehirden istediğinde teslim etme imkanı!"},
                new Car{CarId=5, BrandId=2, ModelYear=2016, DailyPrice=150, Description="25 şehirden istediğinden kiralayıp, istediğinde teslim etme imkanı!"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
