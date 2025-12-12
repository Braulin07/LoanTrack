using LoanTrack.Application.Interfaces.Services;
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
    public static class ServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPrestamoService, PrestamoService>();
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(typeof(ClienteProfile));
            services.AddAutoMapper(typeof(PrestamoProfile));
            services.AddAutoMapper(typeof(PagoProfile));
            services.AddAutoMapper(typeof(UsuarioProfile));
            services.AddAutoMapper(typeof(AuthProfile));

        }
    }
}
