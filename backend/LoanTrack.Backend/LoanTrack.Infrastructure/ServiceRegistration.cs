using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Infrastructure.Context;
using LoanTrack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("LoanTrackDBConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IPagoRepository, PagoRepository>();

            services.AddScoped<IPrestamoRepository, PrestamoRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IAuthRepository, AuthRepository>();

        }
    }
}
