using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace ReCapProject.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> Getall();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
