using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactosModel.Model;
using ContactosWebAPI.Models;
using ContactosWebAPI.Repositorios;
using Microsoft.Practices.Unity;

namespace ContactosWebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        [Dependency]
        public UsuarioRepositorio UserRepo { get; set; }

        [ResponseType(typeof (UsuarioModel))]
        public IHttpActionResult GetValido(string login, string password)
        {
            var res = UserRepo.Validar(login, password);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult GetUnico(string login)
        {
            return Ok(UserRepo.IsUnico(login));
        }

        [ResponseType(typeof (UsuarioModel))]
        public IHttpActionResult Post(UsuarioModel model)
        {
            var data = UserRepo.Add(model);

            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult Put(int id, UsuarioModel model)
        {
            var d = UserRepo.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();

            var data = UserRepo.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult Delete(int id)
        {
            var data = UserRepo.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}