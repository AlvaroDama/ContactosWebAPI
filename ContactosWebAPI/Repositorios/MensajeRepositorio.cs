using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ContactosModel.Model;
using ContactosWebAPI.Adapters;
using ContactosWebAPI.Models;
using RepositorioAdapter.Repository;

namespace ContactosWebAPI.Repositorios
{
    public class MensajeRepositorio:BaseRepositoryEntity<Mensaje, MensajeModel, MensajeAdapter>
    {
        public MensajeRepositorio(DbContext context) : base(context)
        {
        }

        public ICollection<MensajeModel> GetByDestino(int idDestino)
        {
            var data = Get(o => o.IdDestino == idDestino).OrderByDescending(o=>o.Fecha);
            return data.ToList();
        }

        public ICollection<MensajeModel> GetByOrigen(int idOrigen)
        {
            var data = Get(o => o.IdOrigen == idOrigen).OrderByDescending(o => o.Fecha);
            return data.ToList();
        }
    }
}