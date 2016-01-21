using ContactoModel.Model;
using ContactosWebAPI.Models;
using RepositorioAdapter.Adapter;

namespace ContactosWebAPI.Adapters
{
    public class UsuarioAdapter : BaseAdapter<Usuario, UsuarioModel>
    {
        public override Usuario FromModel(UsuarioModel model)
        {
            return new Usuario()
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Foto = model.Foto
            };
        }

        public override UsuarioModel FromEntity(Usuario entity)
        {
            return new UsuarioModel()
            {
                Id = entity.Id,
                Login = entity.Login,
                Password = entity.Password,
                Nombre = entity.Nombre,
                Apellidos = entity.Apellidos,
                Foto = entity.Foto
            };
        }
    }
}