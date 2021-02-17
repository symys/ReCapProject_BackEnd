using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new EfCarDal());

            //eklenecek: tabloları joinleyip, isme göre de listeleme yapabilme
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " model arabanın günlük kiralama bedeli, " + car.DailyPrice + " TL'dir.");
                
            }


            //ekleme sırasında hata verecek şekilde giriş yapıyorum...
            carManager.Add(new Car {CarId= 11, BrandId=3, ColorId=4, DailyPrice=300, Description="x", ModelYear=2016 });
            //eklemeyi kurallara uygun yapıyorum...
            carManager.Add(new Car {CarId=12, BrandId=1, ColorId=3,DailyPrice=250, Description="xyz", ModelYear=2018 });


        }

        
    }
   
}
