using Core.Entities.Abstract;

namespace ReCapProject.Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public string UserFullname { get; set; }
        public string CompanyName { get; set; }
    }
}
