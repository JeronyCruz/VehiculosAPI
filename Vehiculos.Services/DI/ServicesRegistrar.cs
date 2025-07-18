using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehiculos.Abstractions;
using Vehiculos.Data.DI;

namespace Vehiculos.Services.DI;

public static class ServicesRegistrar
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.RegisterDbContextFactory();
        services.AddScoped<IVehiculosService, VehiculosServices>();
        services.AddScoped<IUsuariosService, UsuariosService>();
        return services;
    }
}
