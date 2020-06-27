using Microsoft.EntityFrameworkCore;
using SegundoRegistroConDetalle.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SegundoRegistroConDetalle.Models;

namespace SegundoRegistroConDetalle.BLL
{
    public class OrdenesBLL
    {

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Ordenes.Any(x => x.OrdenId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Ordenes.Add(ordenes);
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        public static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle where OrdenId = {ordenes.OrdenId}");

                foreach (var item in ordenes.OrdenesDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(ordenes).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                var ordenes = db.Ordenes.Find(id);

                if (ordenes != null)
                {
                    db.Ordenes.Remove(ordenes);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto db = new Contexto();
            Ordenes ordenes = new Ordenes();

            try
            {
                ordenes = db.Ordenes
                    .Where(e => e.OrdenId == id)
                    .Include(e => e.OrdenesDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
