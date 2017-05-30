using Galeria.Model;
using Galeria.Model.Translation;
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
        public GaleriaContext() : base("GaleriasCondeEntities")
        {
            if (!Database.Exists())
            {
                Database.SetInitializer(new CrearDB());
            }
            //else
            //{
            //    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GaleriaContext, Configuration>());
            //}
        }


        class CrearDB : CreateDatabaseIfNotExists<GaleriaContext>
        {
            protected override void Seed(GaleriaContext context)
            {

            }
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorTranslations> AuthorTranslations { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<NationalityTranslations> NationalityTranslations { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtworkTranslations> ArtworkTranslations { get; set; }
        public DbSet<Model.Type> Types { get; set; }
        public DbSet<TypeTranslations> TypeTranslations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
