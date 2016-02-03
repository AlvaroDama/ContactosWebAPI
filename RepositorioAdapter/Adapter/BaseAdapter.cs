using System.Collections.Generic;
using System.Linq;

namespace RepositorioAdapter.Adapter
{
    public abstract class BaseAdapter<TEntity, TModel> : IAdapter<TEntity, TModel>
    {
        public ICollection<TModel> FromEntity(ICollection<TEntity> entities)
        {
            return entities.Select(FromEntity).ToList();
        }

        public abstract TModel FromEntity(TEntity entity);

        public ICollection<TEntity> FromModel(ICollection<TModel> models)
        {
            return models.Select(FromModel).ToList();
        }

        public abstract TEntity FromModel(TModel model);
    }
}