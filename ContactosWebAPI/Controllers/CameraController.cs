using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactosModel.Model;

namespace ContactosWebAPI.Controllers
{
    public class CameraController : ApiController
    {
        [ResponseType(typeof (string))]
        public IHttpActionResult Post(FotosModel model)
        {
            
        }
    }
}
