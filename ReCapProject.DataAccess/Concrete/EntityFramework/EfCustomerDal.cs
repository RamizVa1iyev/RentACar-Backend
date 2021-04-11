using Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework.Contexts;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ECarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using var context = new ECarContext();
            var result = from customer in context.Customers
                         join user in context.Users
                         on customer.UserId equals user.Id
                         select new CustomerDetailDto
                         {
                             CompanyName = customer.CompanyName,
                             UserFullname = $"{user.FirstName} {user.LastName}"
                         };
            return result.ToList();
        }
    }
}
