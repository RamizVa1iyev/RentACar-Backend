using Core.Entities.Abstract;
using System;

namespace ReCapProject.Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CarName { get; set; }
        public string CustomerFullname { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
