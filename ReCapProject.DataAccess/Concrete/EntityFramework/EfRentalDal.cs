using Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework.Contexts;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ECarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using var context = new ECarContext();
            var result = from rental in context.Rentals
                         join car in context.Cars
                         on rental.CarId equals car.Id
                         join customer in context.Customers
                         on rental.CustomerId equals customer.Id
                         join user in context.Users
                         on customer.UserId equals user.Id
                         select new RentalDetailDto
                         {
                             CarName = car.Name,
                             CustomerFullname = $"{user.FirstName} {user.LastName}",
                             RentDate = rental.RentDate,
                             ReturnDate = rental.ReturnDate
                         };
            return result.ToList();
        }
    }
}
