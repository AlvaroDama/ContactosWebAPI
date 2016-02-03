using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ContactosModel.Model;
using ContactosWebAPI.Repositorios;
using Microsoft.Practices.Unity;

namespace ContactosWebAPI.Controllers
{
    public class ContactosController : ApiController
    {
        [Dependency]
        public ContactoRepositorio ContactoRepositorio { get; set; }

        public ICollection<ContactoModel> GetAmigos(int id, bool amigos)
        {
            return amigos
                ? ContactoRepositorio.GetByOrigen(id)
                : ContactoRepositorio.GetNoContactosByOrigen(id);
        }

        [ResponseType(typeof(ContactoModel))]
        public IHttpActionResult Post(ContactoModel model)
        {
            var data = ContactoRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(ContactoModel model)
        {
            var data = ContactoRepositorio.Delete(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
