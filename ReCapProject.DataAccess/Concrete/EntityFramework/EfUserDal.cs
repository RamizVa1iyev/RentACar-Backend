using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ECarContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new ECarContext();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim() { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
