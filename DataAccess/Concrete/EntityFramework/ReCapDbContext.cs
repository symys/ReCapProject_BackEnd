using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    //Db tablolarıyla proje classlarını bağlayacağız
    public class ReCapDbContext : DbContext
    {
        

        //aşağısı projenin hangi db ile ilişkilİ olduğunun belirtildiği yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapDb;Trusted_Connection=true");
        }

        //hangi tablo hangi nesneye karşılık gelecek aşağıda gösteriyoruz
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }



        


    }



    
}
