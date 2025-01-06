using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyApp.Models.Common
{
    public static class SessionManager
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private static ISession session => _httpContextAccessor?.HttpContext?.Session;
        public static string UserId
        {
            get
            {
                var session = _httpContextAccessor?.HttpContext?.Session;
                if (session == null || string.IsNullOrEmpty(session.GetString("UserId")))
                {
                    return "";
                }
                return session.GetString("UserId");
            }
            set
            {
               // var session = _httpContextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString("UserId", value);
                }
            }
        }
        public static void SetMenuList(List<MenuDto> menuList)
        {
            if (session != null)
            {
                var serializedMenu = JsonConvert.SerializeObject(menuList);
                session.SetString("MenuList", serializedMenu);
            }
        }
        public static List<MenuDto> GetMenuList()
        {
            if (session == null)
                return new List<MenuDto>();

            var serializedMenu = session.GetString("MenuList");
            return string.IsNullOrEmpty(serializedMenu)
                ? new List<MenuDto>()
                : JsonConvert.DeserializeObject<List<MenuDto>>(serializedMenu);
        }
        public static string UserName
        {
            get
            {
                var session = _httpContextAccessor?.HttpContext?.Session;
                if (session == null || string.IsNullOrEmpty(session.GetString("UserName")))
                {
                    return "";
                }
                return session.GetString("UserName");
            }
            set
            {
                // var session = _httpContextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString("UserName", value);
                }
            }
        }

        public static string UserGuid
        {
            get
            {
                var session = _httpContextAccessor?.HttpContext?.Session;
                if (session == null || string.IsNullOrEmpty(session.GetString("UserGuid")))
                {
                    return "";
                }
                return session.GetString("UserGuid");
            }
            set
            {
                // var session = _httpContextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString("UserGuid", value);
                }
            }
        }
    }
}
