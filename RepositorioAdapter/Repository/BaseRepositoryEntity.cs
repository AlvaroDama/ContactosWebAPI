using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositorioAdapter.Adapter;

namespace RepositorioAdapter.Repository
{
    public class BaseRepositoryEntity<TEntity, TModel, TAdapter> :
        IRepository<TEntity, TModel, TAdapter>
        where TAdapter : IAdapter<TEntity, TModel>, new()
        where TEntity : class
        where TModel : class
    {

        protected DbContext Context;
        protected DbSet<TEntity> DbSet {get { return Context.Set<TEntity>(); } }

        private TAdapter _adapter;
        public TAdapter Adapter
        {
            get
            {
                if(_adapter == null)
                    _adapter = new TAdapter();
                return _adapter;
            }
        }
        
        public TModel Add(TModel model)
        {
            var guardado = Adapter.FromModel(model);
            DbSet.Add(guardado);
            try
            {
                Context.SaveChanges();
                return Adapter.FromEntity(guardado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public int Delete(params object[] keys)
        {
            var eliminar = DbSet.Find(keys);
            DbSet.Remove(eliminar);
            try
            {
                return Context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Delete(TModel model)
        {
            var eliminar = Adapter.FromModel(model);
            Context.Entry(eliminar).State = EntityState.Deleted;

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Delete(Expression<Func<TEntity, bool>> consulta)
        {
            var eliminar = DbSet.Where(consulta);
            DbSet.RemoveRange(eliminar);

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Update(TModel model)
        {
            var modificar = Adapter.FromModel(model);
            Context.Entry(modificar).State = EntityState.Modified;

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public TModel Get(params object[] keys)
        {
            var data = DbSet.Find(keys);
            return Adapter.FromEntity(data);
        }

        public ICollection<TModel> Get(Expression<Func<TEntity, bool>> consulta)
        {
            var data = DbSet.Where(consulta);
            return Adapter.FromEntity(data.ToList());
        }

        public ICollection<TModel> Get()
        {
            return Adapter.FromEntity(DbSet.ToList());
        }
    }
}