using Core.Entities.Abstract;
using System.Collections.Generic;

namespace ReCapProject.Entities.DTOs
{
    public class UserInfoDto:IDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<string> OperationClaims { get; set; }
    }
}
