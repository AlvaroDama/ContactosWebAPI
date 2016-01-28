using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using ContactosWebAPI.Models;
using ContactosWebAPI.Repositorios;
using RepositorioAdapter.Repository;
using Unity.WebApi;

namespace ContactosWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, RedContactosEntities>();
            container.RegisterType<UsuarioRepositorio>();
            container.RegisterType<ContactoRepositorio>();
            container.RegisterType<MensajeRepositorio>();
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}