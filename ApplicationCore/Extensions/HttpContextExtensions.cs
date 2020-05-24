using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetAuthToken(this HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            string token = null;

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                token = authHeader.Substring("Bearer ".Length);
            }

            return token;
        }
    }
}
