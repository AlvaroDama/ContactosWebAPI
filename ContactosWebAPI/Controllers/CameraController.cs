using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using ContactosModel.Model;
using ContactosWebAPI.Utils;

namespace ContactosWebAPI.Controllers
{
    public class CameraController : ApiController
    {
        [ResponseType(typeof (string))]
        public IHttpActionResult Post(FotosModel model)
        {
            var cuenta = ConfigurationManager.AppSettings["cuenta"];
            var clave = ConfigurationManager.AppSettings["clave"];
            var contenedor = ConfigurationManager.AppSettings["contenedor"];

            var sto = new AzureStorageUtils(cuenta, clave, contenedor);

            var nom = Guid.NewGuid() + ".jpg";

            sto.SubirFichero(Convert.FromBase64String(model.Data), nom, contenedor);

            return Ok(nom);
        }
    }
}
