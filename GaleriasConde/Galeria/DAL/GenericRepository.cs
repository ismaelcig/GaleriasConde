using Galeria.Other_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        //Repositorio generico que permite el acceso generico a cualquier tabla
        protected GaleriaContext context;
        DbSet<TEntity> dbSet;
        public GenericRepository(GaleriaContext context)
        {
            try
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep1", ex);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep2", ex);
            }
        }
        public void Delete(TEntity entityToDelete)
        {
            try
            {
                dbSet = context.Set<TEntity>();
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);

                context.Entry(entityToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep3", ex);
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                dbSet = context.Set<TEntity>();
                var entities = dbSet.Where(predicate).ToList();
                entities.ForEach(x => context.Entry(x).State = EntityState.Deleted);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep4", ex);
            }
        }

        public void Create(TEntity entity)
        {
            try
            {
                dbSet = context.Set<TEntity>();
                dbSet.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep5", ex);
            }



        }

        public List<TEntity> GetAll()
        {
            try
            {
                return (List<TEntity>)context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep6", ex);
                return null;
            }
        }
        public List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                dbSet = context.Set<TEntity>();
                IQueryable<TEntity> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep7", ex);
                return null;
            }

        }
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                dbSet = context.Set<TEntity>();
                return dbSet.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("GenericRep8", ex);
                return null;
            }
        }
    }
}
