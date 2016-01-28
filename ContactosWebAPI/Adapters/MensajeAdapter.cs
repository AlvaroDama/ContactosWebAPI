using ContactosModel.Model;
using ContactosWebAPI.Models;
using RepositorioAdapter.Adapter;

namespace ContactosWebAPI.Adapters
{
    public class MensajeAdapter:BaseAdapter<Mensaje, MensajeModel>
    {
        public override Mensaje FromModel(MensajeModel model)
        {
            return new Mensaje()
            {
                Id = model.Id,
                IdDestino = model.IdDestino,
                IdOrigen = model.IdOrigen,
                Asunto = model.Asunto,
                Fecha = model.Fecha,
                Leido = model.Leido,
                Contenido = model.Contenido
            };
        }

        public override MensajeModel FromEntity(Mensaje entity)
        {
            return new MensajeModel()
            {
                Id = entity.Id,
                IdDestino = entity.IdDestino,
                IdOrigen = entity.IdOrigen,
                Asunto = entity.Asunto,
                Fecha = entity.Fecha,
                Leido = entity.Leido,
                Contenido = entity.Contenido
            };
        }
    }
}