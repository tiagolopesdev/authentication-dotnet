using fiap_jwt_api.Enums;
using fiap_jwt_api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace fiap_jwt_api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UsersMemoryMiddleware
    {
        private readonly RequestDelegate _next;

        public UsersMemoryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            ListUsers.Users = new List<Users>() { new Users
            {
                Name = "Tiago Lopes",
                Password = "tiago.costa12#",
                Permissions = new List<Permissions> { Permissions.Get, Permissions.Create }
            },
            new Users
            {
                Name = "Chico Alves",
                Password = "chico.alves12#",
                Permissions = new List<Permissions> { Permissions.Get }
            },
            new Users
            {
                Name = "Bia Rodrigues",
                Password = "bia.rodrigues12#",
                Permissions = new List<Permissions> { Permissions.Get }
            },
            new Users
            {
                Name = "Ana Vasconcelos",
                Password = "ana.vasconcelos12#",
                Permissions = new List<Permissions> { Permissions.Get }
            }
            };

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UsersMemoryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UsersMemoryMiddleware>();
        }
    }
}
