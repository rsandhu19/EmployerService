using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerServiceDemo
{
    /// <summary>
    /// This class verifies if the incoming call is from authenticated resourse
    /// </summary>
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                

                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = decodedUsernamePassword.IndexOf(':');

                var username = decodedUsernamePassword.Substring(0, seperatorIndex);
                var password = decodedUsernamePassword.Substring(seperatorIndex + 1);

                if (IsAuthorized(username,password))
                {
                    await next.Invoke(context);
                    return;
                }
                else
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }

        public bool IsAuthorized(string username, string password)
        {
            // Check that username and password are correct
            return username.Equals("empService", StringComparison.InvariantCultureIgnoreCase)
                   && password.Equals("DevEmpService");
        }
    }

}
