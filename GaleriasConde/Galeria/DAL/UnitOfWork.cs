using Galeria.DAL.Repositories;
using Galeria.DAL.Repositories.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class UnitOfWork
    {
        private GaleriaContext context = new GaleriaContext();
        private bool disposed = false;

        private ArtworksRep artworksRep;
        private ArtworkTranslationsRep artworkTranslationsRep;
        private AuthorsRep authorsRep;
        private AuthorTranslationsRep authorTranslationsRep;
        private LangsRep langsRep;
        private NationalitiesRep nationalitiesRep;
        private NationalityTranslationsRep nationalityTranslationsRep;
        private ProfilesRep profilesRep;
        private TransactionsRep transactionsRep;
        private TypesRep typesRep;
        private TypeTranslationsRep typeTranslationsRep;
        private UsersRep usersRep;

        //private MensajesRepository mensajesRepository;

        public ArtworksRep ArtworksRep
        {
            get
            {
                if (this.artworksRep == null)
                {
                    this.artworksRep = new ArtworksRep(context);
                }
                return artworksRep;
            }
        }
        public ArtworkTranslationsRep ArtworkTranslationsRep
        {
            get
            {
                if (this.artworkTranslationsRep == null)
                {
                    this.artworkTranslationsRep = new ArtworkTranslationsRep(context);
                }
                return artworkTranslationsRep;
            }
        }
        public AuthorsRep AuthorsRep
        {
            get
            {
                if (this.authorsRep == null)
                {
                    this.authorsRep = new AuthorsRep(context);
                }
                return authorsRep;
            }
        }
        public AuthorTranslationsRep AuthorTranslationsRep
        {
            get
            {
                if (this.authorTranslationsRep == null)
                {
                    this.authorTranslationsRep = new AuthorTranslationsRep(context);
                }
                return authorTranslationsRep;
            }
        }
        public LangsRep LangsRep
        {
            get
            {
                if (this.langsRep == null)
                {
                    this.langsRep = new LangsRep(context);
                }
                return langsRep;
            }
        }
        public NationalitiesRep NationalitiesRep
        {
            get
            {
                if (this.nationalitiesRep == null)
                {
                    this.nationalitiesRep = new NationalitiesRep(context);
                }
                return nationalitiesRep;
            }
        }
        public NationalityTranslationsRep NationalityTranslationsRep
        {
            get
            {
                if (this.nationalityTranslationsRep == null)
                {
                    this.nationalityTranslationsRep = new NationalityTranslationsRep(context);
                }
                return nationalityTranslationsRep;
            }
        }
        public ProfilesRep ProfilesRep
        {
            get
            {
                if (this.profilesRep == null)
                {
                    this.profilesRep = new ProfilesRep(context);
                }
                return profilesRep;
            }
        }
        public TransactionsRep TransactionsRep
        {
            get
            {
                if (this.transactionsRep == null)
                {
                    this.transactionsRep = new TransactionsRep(context);
                }
                return transactionsRep;
            }
        }
        public TypesRep TypesRep
        {
            get
            {
                if (this.typesRep == null)
                {
                    this.typesRep = new TypesRep(context);
                }
                return typesRep;
            }
        }
        public TypeTranslationsRep TypeTranslationsRep
        {
            get
            {
                if (this.typeTranslationsRep == null)
                {
                    this.typeTranslationsRep = new TypeTranslationsRep(context);
                }
                return typeTranslationsRep;
            }
        }
        public UsersRep UsersRep
        {
            get
            {
                if (this.usersRep == null)
                {
                    this.usersRep = new UsersRep(context);
                }
                return usersRep;
            }
        }



        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
