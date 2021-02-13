using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "ID'ye sahip aracın günlük kiralama bedeli " + car.DailyPrice + " TL'dir. Ve aracın model yılı şöyledir: " + car.ModelYear);
            }

            
        }
    }
}
