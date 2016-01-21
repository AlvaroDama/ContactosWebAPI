using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositorioAdapter.Repository
{
    public interface IRepository<TEntity, TModel, TAdapter>
    {
        TModel Add(TModel model);
        int Delete(params object[] keys);
        int Delete(TModel model);
        int Delete(Expression<Func<TModel, bool>> consulta);
        int Update(TModel model);
        TModel Get(params object[] keys);
        ICollection<TModel> Get(Expression<Func<TModel, bool>> consulta);
        ICollection<TModel> Get();
    }
}