using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class UserMenuAuthorizationDto: BaseDto
    {
        public Guid UserMenuGuid { get; set; }
        public long UserMenuId { get; set; }
        public long MenuId { get; set; }
        public string? MenuCode { get; set; }
        public string? MenuName { get; set; }
        public long? UserId { get; set; }
        public string? UserName { get; set; }
        public bool? ForAdd { get; set; }
        public bool? ForEdit { get; set; }
        public List<UserMenuAuthorizationDto> userMenuAuthorizationDtos { get; set; }

    }
}
