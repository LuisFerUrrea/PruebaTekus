using AplicativoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AplicativoWeb.Context
{
    public interface IContextDB
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Servicio> Servicios { get; set; }
        DbSet<Pais> Pais { get; set; }
        DbSet<ClienteXServicio> ClienteXServicios { get; set; }
        DbSet<ClienteSevicioXPais> ClienteSevicioXPais { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
