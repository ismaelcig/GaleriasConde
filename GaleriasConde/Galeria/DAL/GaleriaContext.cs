//using Galeria.Migrations;
using Galeria.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class GaleriaContext : DbContext
    {
        public GaleriaContext() : base("GaleriaArteEntities")
        {
            if (!Database.Exists())
            {
                Database.SetInitializer(new CrearDB());
            }
            else
            {
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GaleriaContext, Configuration>());
            }
        }


        class CrearDB : CreateDatabaseIfNotExists<GaleriaContext>
        {
            protected override void Seed(GaleriaContext context)
            {
                
            }
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        //public DbSet<Conversacion> Conversaciones { get; set; }
        //public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
