using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using ContactosModel.Model;
using ContactosWebAPI.Adapters;
using ContactosWebAPI.Models;
using RepositorioAdapter.Repository;

namespace ContactosWebAPI.Repositorios
{
    public class ContactoRepositorio:BaseRepositoryEntity<Usuario, ContactoModel, ContactoAdapter>
    {
        public ContactoRepositorio(DbContext context) : base(context)
        {
        }

        public ICollection<ContactoModel> GetByOrigen(int id)
        {
            var data = DbSet.Find(id).Amigos;
            var ret = new List<ContactoModel>();
            foreach (var us in data)
            {
                ret.Add(new ContactoModel()
                {
                    IdOrigen = id,
                    IdDestino = us.Id,
                    NombreCompleto = $"{us.Nombre} {us.Apellidos}"
                });
            }

            return ret;
        }

        public ICollection<ContactoModel> GetNoContactosByOrigen(int id)
        {
            var data = DbSet.Find(id).Amigos.Select(o=>o.Id);
            var nocont = DbSet.Where(o => !data.Contains(o.Id));
            var ret = new List<ContactoModel>();
            foreach (var us in nocont)
            {
                ret.Add(new ContactoModel()
                {
                    IdOrigen = id,
                    IdDestino = us.Id,
                    NombreCompleto = $"{us.Nombre} {us.Apellidos}"
                });
            }

            return ret;
        }

        public override ContactoModel Add(ContactoModel model)
        {
            var yo = DbSet.Find(model.IdOrigen);
            var tu = DbSet.Find(model.IdDestino);
            yo.Amigos.Add(tu);
            try
            {
                Context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public override int Delete(ContactoModel model)
        {
            var yo = DbSet.Find(model.IdOrigen);
            var tu = DbSet.Find(model.IdDestino);
            yo.Amigos.Remove(tu);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public override int Update(ContactoModel model)
        {
            throw new NotImplementedException();
        }
    }
}