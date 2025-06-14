using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehiculos.Abstractions;
using Vehiculos.Data.Context;
using Vehiculos.Data.Models;
using Vehiculos.Domain.DTO;

namespace Vehiculos.Services;

public class VehiculosServices(IDbContextFactory<VehiculosContext> DbFactory) : IVehiculosService
{
    public async Task<VehiculosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var vehiculo = await contexto.Vehiculos
            .Where(e => e.VehiculoId == id)
            .Select(p => new VehiculosDto()
            {
                VehiculoId = p.VehiculoId,
                Descripcion = p.Descripcion,
                Precio = p.Precio
            }).FirstOrDefaultAsync();

        return vehiculo ?? new VehiculosDto();
    }

    public async Task<bool> Eliminar(int vehiculoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .Where(e => e.VehiculoId == vehiculoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteCliente(int id, string descripcion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .AnyAsync(e => e.VehiculoId != id && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }

    private async Task<bool> Insertar(VehiculosDto vehiculoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var vehiculo = new Vehiculo()
        {
            Descripcion = vehiculoDto.Descripcion,
            Precio = vehiculoDto.Precio
        };
        contexto.Vehiculos.Add(vehiculo);
        var guardo = await contexto.SaveChangesAsync() > 0;
        vehiculoDto.VehiculoId = vehiculo.VehiculoId;
        return guardo;
    }

    private async Task<bool> Modificar(VehiculosDto vehiculoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var vehiculo = new Vehiculo()
        {
            VehiculoId = vehiculoDto.VehiculoId,
            Descripcion = vehiculoDto.Descripcion,
            Precio = vehiculoDto.Precio
        };
        contexto.Update(vehiculo);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .AnyAsync(e => e.VehiculoId == id);
    }

    public async Task<bool> Guardar(VehiculosDto vehiculo)
    {
        if (!await Existe(vehiculo.VehiculoId))
            return await Insertar(vehiculo);
        else
            return await Modificar(vehiculo);
    }

    public async Task<List<VehiculosDto>> Listar(Expression<Func<VehiculosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Vehiculos.Select(p => new VehiculosDto()
        {
            VehiculoId = p.VehiculoId,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
        })
            .Where(criterio)
            .ToListAsync();
    }

}
