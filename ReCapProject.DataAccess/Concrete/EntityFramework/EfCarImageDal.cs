using Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework.Contexts;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,ECarContext>,ICarImageDal
    {
    }
}
