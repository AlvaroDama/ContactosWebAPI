using System.Collections;
using System.Collections.Generic;

namespace RepositorioAdapter.Adapter
{
    /// <summary>
    /// Interfaz que deberá implementar el adaptador/parseador.
    /// </summary>
    /// <typeparam name="TEntity">Objeto de entidad en la base da datos</typeparam>
    /// <typeparam name="TModel">Objeto de transferencia, es lo que mando al móvil</typeparam>
    public interface IAdapter <TEntity, TModel>
    {
        TEntity FromModel(TModel model);
        TModel FromEntity(TEntity entity);

        ICollection<TEntity> FromModel(ICollection<TModel> models);
        ICollection<TModel> FromEntity(ICollection<TEntity> entities);

    }
}