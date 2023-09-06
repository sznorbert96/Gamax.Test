using Gamax.Application.Contracts.Persistence;
using Gamax.Persistence.Repositories;
using Gamax.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamax.Identity.Contracts.Identity;
using Gamax.Identity.Services.Identity;

namespace Gamax.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

            return services;
        }
    }
}
