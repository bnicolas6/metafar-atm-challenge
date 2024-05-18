using Metafar.ATM.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Metafar.ATM.Challenge.Persistence
{
    public class ATMDbContext : DbContext
    {
        public ATMDbContext(DbContextOptions options)
            : base(options)
        {   
        }

        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<EstadoTarjeta> EstadosTarjetas { get; set; }
        public virtual DbSet<Operacion> Operaciones { get; set; }
        public virtual DbSet<TipoOperacion> TiposOperaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
