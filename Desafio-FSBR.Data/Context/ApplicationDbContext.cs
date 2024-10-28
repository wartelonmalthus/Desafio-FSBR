using Desafio_FSBR.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Desafio_FSBR.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Processo> Processos { get; set; }
}
