using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
