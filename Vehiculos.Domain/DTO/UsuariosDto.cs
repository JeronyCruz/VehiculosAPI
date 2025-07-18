using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos.Domain.DTO;

public class UsuariosDto
{
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public double Balance { get; set; }
}
