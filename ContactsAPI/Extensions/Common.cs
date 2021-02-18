using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Extensions
{
    public static class Common
    {
        // Çağrıldığı an içerisinde mevcut olan kullanıcı oturumundan kullanıcının Id bilgisini döndürür. 
        // Kullanıcı oturumu yoksa boş string döndürür.
        public static string GetCurrentUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
                return string.Empty;

            return httpContext.User.Claims.Single(x => x.Type == "userId").Value;
        }
    }
}
