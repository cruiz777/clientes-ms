using clientes_ms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Infrastructure.Persistence.Context;

public partial class ApplicationDbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gln>(entity =>
        {   //MAPEAR el esquema y nombre de la tabla
            entity.ToTable("gln", "sic", t => t.HasTrigger("trg_gln_auditoria")); //Por norma de ef core es necesario mapear el trigger
           
        });
    }
}