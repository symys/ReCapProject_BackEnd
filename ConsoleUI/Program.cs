using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.Constants;
using Core.Utilities.Results;
using Business.Abstract;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rent in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("Araç kiralayanlar: " + rent.FirstName + " " + rent.LastName);
            }

            Rental rental1 = new Rental { RentId = 2, CarId = 2, CustomerId = 1, RentDate =DateTime.Now, ReturnDate = DateTime.Now.AddDays(2)};
            Console.WriteLine(rentalManager.Add(rental1).Message);
            



            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer { CustomerId = 6, UserId = 2, CompanyName = "B ŞİRKETİ" };
            var result = customerManager.Add(customer1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }




            //Console.WriteLine("-------------------- CAR OPERASYONLARI--------------------");

            //CarManager carManager = new CarManager(new EfCarDal());
            ////ekleme 1- hata verecek şekilde  2- belirlediğim kurallara uygun
            //carManager.Add(new Car { CarId = 19, BrandId = 3, ColorId = 4, DailyPrice = 300, Description = "x", ModelYear = 2016 });
            //carManager.Add(new Car { CarId = 17, BrandId = 1, ColorId = 3, DailyPrice = 250, Description = "xyz", ModelYear = 2018 });
            ////silme
            //Car car1 = new Car { CarId = 17, BrandId = 1, ColorId = 3, DailyPrice = 250, Description = "xyz", ModelYear = 2018 };
            //carManager.Delete(car1);
            ////güncelleme
            //Car car2 = new Car { CarId = 2, BrandId = 4, ColorId = 3, DailyPrice = 550, Description = "sıfır", ModelYear = 2021 };
            //carManager.Update(car2);
            ////tek bir araç çağırma
            //carManager.GetCarsByCarId(3);
            ////arabaları dto ile listeleme
            //var result = carManager.GetCarDetails();
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarId + " koda sahip " + car.BrandName + " marka araba "
            //            + car.ColorName.ToLower() + " renktedir ve günlük kira bedeli " + car.DailyPrice + " TL'dir.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


            //Console.WriteLine("-------------------- BRAND OPERASYONLARI--------------------");
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////markaları listeleme
            //var result1 = brandManager.GetAll();
            //if (result.Success)
            //{
            //    foreach (var brand in result.Data)
            //    {
            //        Console.WriteLine(brand.BrandName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result1.Message);
            //}

            ////ekleme-silme-güncelleme
            //Brand brand1 = new Brand { BrandName = "Tesla", BrandId = 10 };
            //brandManager.Add(brand1);
            //Console.WriteLine(brand1.BrandName + Messages.AddedOperation);
            //brandManager.Delete(brand1);
            //Console.WriteLine(brand1.BrandName + Messages.DeletedOperation);
            //brandManager.Update(new Brand { BrandName = "TESLA", BrandId = 4 });
            //Console.WriteLine(brand1.BrandName + Messages.UpdatedOperation);

            //Console.WriteLine("seçilen aracın markası: ");
            //brandManager.GetById(2);
            //Console.WriteLine(brandManager.GetById(2).Data.BrandName);



            //Console.WriteLine("-------------------- COLOR OPERASYONLARI--------------------");
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            ////listeleme
            //var result2 = colorManager.GetAll();
            //if (result2.Success)
            //{
            //    foreach (var color in result2.Data)
            //    {
            //        Console.WriteLine(color.ColorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result2.Message);
            //}

            ////ekleme
            //Color color1 = new Color { ColorId = 6, ColorName = "Lacivert" };
            //colorManager.Add(color1);
            //Console.WriteLine(Messages.AddedOperation);
            ////silme
            //colorManager.Delete(color1);
            //Console.WriteLine(Messages.DeletedOperation);
            ////güncelleme
            //Color color2 = new Color { ColorId = 1, ColorName = "LACİ" };
            //colorManager.Update(color2);
            //Console.WriteLine("seçilen aracın rengi " + color2.ColorName + "olacak şekilde güncellendi");
            ////değişikiliği görmek için bir kez daha listeledim
            //Console.WriteLine("Güncel renkler şöyle: ");

            //foreach (var color in colorManager.GetAll().Data)
            //{
            //    Console.WriteLine(color.ColorName);
            //}



        }
    }
}





       
