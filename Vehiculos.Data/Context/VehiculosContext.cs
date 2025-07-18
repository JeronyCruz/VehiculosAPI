using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehiculos.Data.Models;

namespace Vehiculos.Data.Context;

public class VehiculosContext : DbContext
{
    public VehiculosContext(DbContextOptions<VehiculosContext> options) : base(options) { }

    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
