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

        private AutoresRepository autoresRepository;
        private TransaccionesRepository transaccionesRepository;
        private UsuariosRepository usuariosRepository;
        private ObrasRepository obrasRepository;
        private TiposRepository tiposRepository;
        private NacionalidadesRepository nacionalidadesRepository;
        private MensajesRepository mensajesRepository;
        //private ConversacionesRepository conversacionesRepository;
        //private PermisosRepository permisosRepository;
        private PerfilesRepository perfilesRepository;

        public AutoresRepository AutoresRepository
        {
            get
            {
                if (this.autoresRepository == null)
                {
                    this.autoresRepository = new AutoresRepository(context);
                }
                return autoresRepository;
            }
        }
        public TransaccionesRepository TransaccionesRepository
        {
            get
            {
                if (this.transaccionesRepository == null)
                {
                    this.transaccionesRepository = new TransaccionesRepository(context);
                }
                return transaccionesRepository;
            }
        }
        public UsuariosRepository UsuariosRepository
        {
            get
            {
                if (this.usuariosRepository == null)
                {
                    this.usuariosRepository = new UsuariosRepository(context);
                }
                return usuariosRepository;
            }
        }
        public ObrasRepository ObrasRepository
        {
            get
            {
                if (this.obrasRepository == null)
                {
                    this.obrasRepository = new ObrasRepository(context);
                }
                return obrasRepository;
            }
        }
        public TiposRepository TiposRepository
        {
            get
            {
                if (this.tiposRepository == null)
                {
                    this.tiposRepository = new TiposRepository(context);
                }
                return tiposRepository;
            }
        }
        public NacionalidadesRepository NacionalidadesRepository
        {
            get
            {
                if (this.nacionalidadesRepository == null)
                {
                    this.nacionalidadesRepository = new NacionalidadesRepository(context);
                }
                return nacionalidadesRepository;
            }
        }
        public MensajesRepository MensajesRepository
        {
            get
            {
                if (this.mensajesRepository == null)
                {
                    this.mensajesRepository = new MensajesRepository(context);
                }
                return mensajesRepository;
            }
        }/*
        public ConversacionesRepository ConversacionesRepository
        {
            get
            {
                if (this.conversacionesRepository == null)
                {
                    this.conversacionesRepository = new ConversacionesRepository(context);
                }
                return conversacionesRepository;
            }
        }*/
        //public PermisosRepository PermisosRepository
        //{
        //    get
        //    {
        //        if (this.permisosRepository == null)
        //        {
        //            this.permisosRepository = new PermisosRepository(context);
        //        }
        //        return permisosRepository;
        //    }
        //}
        public PerfilesRepository PerfilesRepository
        {
            get
            {
                if (this.perfilesRepository == null)
                {
                    this.perfilesRepository = new PerfilesRepository(context);
                }
                return perfilesRepository;
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
