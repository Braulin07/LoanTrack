using FluentValidation;
using LoanTrack.Application.Interfaces;
﻿using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Application.Mapping;
using LoanTrack.Application.Services;
using LoanTrack.Application.Validator.Cliente;
using LoanTrack.Application.Validator.Pago;
using LoanTrack.Application.Validator.Prestamo;
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
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddAutoMapper(typeof(ClienteProfile));
            services.AddAutoMapper(typeof(PrestamoProfile));
            services.AddAutoMapper(typeof(PagoProfile));
            services.AddAutoMapper(typeof(UsuarioProfile));
            services.AddValidatorsFromAssembly(typeof(ClienteCreateDtoValidator).Assembly);
        }
    }
}
