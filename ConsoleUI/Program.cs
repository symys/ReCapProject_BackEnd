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

            Console.WriteLine("-------------------- CAR OPERASYONLARI--------------------");

            CarManager carManager = new CarManager(new EfCarDal());
            //ekleme 1- hata verecek şekilde  2- belirlediğim kurallara uygun
            carManager.Add(new Car { CarId = 14, BrandId = 3, ColorId = 4, DailyPrice = 300, Description = "x", ModelYear = 2016 });
            carManager.Add(new Car { CarId = 14, BrandId = 1, ColorId = 3, DailyPrice = 250, Description = "xyz", ModelYear = 2018 });
            //silme
            Car car1 = new Car { CarId =14, BrandId = 1, ColorId = 3, DailyPrice = 250, Description = "xyz", ModelYear = 2018 };
            carManager.Delete(car1);
            //güncelleme
            Car car2 = new Car { CarId = 2, BrandId = 4, ColorId = 3, DailyPrice = 950, Description = "sıfır", ModelYear = 2021 };
            carManager.Update(car2);
            //tek bir araç çağırma
            carManager.GetCarsByCarId(3);
            //arabaları dto ile listeleme
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " koda sahip " + car.BrandName + " marka araba " 
                    + car.ColorName.ToLower() + " renktedir ve günlük kira bedeli " + car.DailyPrice + " TL'dir.");
            }

            Console.WriteLine("-------------------- BRAND OPERASYONLARI--------------------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //markaları listeleme
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            //ekleme-silme-güncelleme
            Brand brand1 = new Brand { BrandName = "Tesla", BrandId = 10 };
            brandManager.Add(brand1);
            Console.WriteLine(brand1.BrandName + " marka araç eklendi");
            brandManager.Delete(brand1);
            Console.WriteLine(brand1.BrandName + " marka araç silindi");
            brandManager.Update(new Brand { BrandName = "TESLA", BrandId = 4 });
            Console.WriteLine(brand1.BrandName + " isimli araç bilgisi güncellendi");

            Console.WriteLine( "seçilen aracın markası: ");
            brandManager.GetById(2);
            Console.WriteLine(brandManager.GetById(2).BrandName);
            


            Console.WriteLine("-------------------- COLOR OPERASYONLARI--------------------");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //listeleme
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            //ekleme
            Color color1 = new Color { ColorId= 6, ColorName= "Lacivert"};
            colorManager.Add(color1);
            Console.WriteLine("yeni renk veritabanına eklendi!");
            //silme
            colorManager.Delete(color1);
            Console.WriteLine("seçtiğiniz renk silindi...");
            //güncelleme
            Color color2 = new Color {ColorId=1, ColorName="GÜMÜŞ GRİ" };
            colorManager.Update(color2);
            Console.WriteLine("seçilen aracın rengi " + color2.ColorName + "olacak şekilde güncellendi");
            //değişikiliği görmek için bir kez daha listeledim
            Console.WriteLine("Güncel renkler şöyle: ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }





        }

       

        


    }
   
}
