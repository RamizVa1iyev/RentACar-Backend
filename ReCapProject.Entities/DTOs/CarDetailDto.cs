using Core.Entities.Abstract;

namespace ReCapProject.Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
