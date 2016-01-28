using ContactosModel.Model;
using ContactosWebAPI.Models;
using RepositorioAdapter.Adapter;

namespace ContactosWebAPI.Adapters
{
    public class ContactoAdapter:BaseAdapter<Usuario, ContactoModel>
    {
        public override Usuario FromModel(ContactoModel model)
        {
            return null;
        }

        public override ContactoModel FromEntity(Usuario entity)
        {
            return null;
        }
    }
}