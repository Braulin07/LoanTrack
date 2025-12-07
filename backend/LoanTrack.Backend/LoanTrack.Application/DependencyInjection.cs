using LoanTrack.Application.Interfaces;
using LoanTrack.Application.Mapping;
using LoanTrack.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPrestamoService, PrestamoService>();
            services.AddAutoMapper(typeof(ClienteProfile));
            services.AddAutoMapper(typeof(PrestamoProfile));
        }
    }
}
