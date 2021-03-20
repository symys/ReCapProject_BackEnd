using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join r in context.Rentals
                             on cu.CustomerId equals r.CustomerId
                             select new RentalDetailDto
                             {
                                 RentId = r.RentId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 //RentDate = r.RentDate,
                                 //ReturnDate = r.ReturnDate
                             };
                return result.ToList(); 
                

                


            }
        }
    }
}
