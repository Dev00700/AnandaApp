using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class UserDto:BaseDto
    {
        public Guid UserGuid { get; set; }
        public long UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        
    }
}
