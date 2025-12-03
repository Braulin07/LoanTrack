using LoanTrack.Domain.Interfaces;
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
    public static class DependencyInjection
    {
        public static void AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("LoanTrackDBConnection")));

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IPagoRepository, PagoRepository>();

            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        }
    }
}
