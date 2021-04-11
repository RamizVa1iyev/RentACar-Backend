using Core.Entities.Abstract;

namespace ReCapProject.Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
