using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehiculos.Data.Context;

namespace Vehiculos.Data.DI;

public static class DbContextRegistrar
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<VehiculosContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}

