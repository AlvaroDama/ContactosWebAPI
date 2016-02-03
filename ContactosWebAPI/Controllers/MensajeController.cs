using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ContactosModel.Model;
using ContactosWebAPI.Repositorios;
using Microsoft.Practices.Unity;

namespace ContactosWebAPI.Controllers
{
    public class MensajeController : ApiController
    {
        [Dependency]
        public MensajeRepositorio MensajeRepositorio { get; set; }

        public ICollection<MensajeModel> Get(int id)
        {
            return MensajeRepositorio.GetByDestino(id);
        }

        public ICollection<MensajeModel> Get(int id, bool enviados)
        {
            return MensajeRepositorio.GetByOrigen(id);
        }

        [ResponseType(typeof (MensajeModel))]
        public IHttpActionResult Post(MensajeModel model)
        {
            var data = MensajeRepositorio.Add(model);
            if (data != null)
                return Ok(model) ;

            return BadRequest();
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult Put(MensajeModel model)
        {
            var data = MensajeRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
