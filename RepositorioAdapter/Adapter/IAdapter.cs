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
        TEntity FromViewModel(TModel model);
        TModel FromModel(TEntity model);

        ICollection<TEntity> FromViewModel(ICollection<TModel> model);
        ICollection<TModel> FromModel(ICollection<TEntity> model);

    }
}