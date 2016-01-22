using System.Data.Entity;
using System.Linq;
using ContactoModel.Model;
using ContactosWebAPI.Adapters;
using ContactosWebAPI.Models;
using RepositorioAdapter.Repository;

namespace ContactosWebAPI.Repositorios
{
    public class UsuarioRepositorio : BaseRepositoryEntity<Usuario, UsuarioModel, UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        {
        }

        public override UsuarioModel Add(UsuarioModel model)
        {
            return IsUnico(model.Login) ? base.Add(model) : null;
        }

        public UsuarioModel Validar(string login, string password)
        {
            var data = Get(o => o.Login == login &&
                                o.Password == password);

            return data.Any() ? data.FirstOrDefault() : null;
        }

        public bool IsUnico(string login)
        {
            return !Get(o => o.Login == login).Any();
        }
    }
}