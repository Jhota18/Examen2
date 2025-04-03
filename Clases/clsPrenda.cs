using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
	public class clsPrenda
	{
        private DBExamenEntities dbExamen = new DBExamenEntities();
        public Prenda prenda { get; set; }

        public string Insertar()
        {
            try
            {
                dbExamen.Prendas.Add(prenda);
                dbExamen.SaveChanges();
                return "La prenda se agregó correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la prenda " + ex.Message;
            }
        }

        public Prenda Consultar(int Id_prenda)
        {
            Prenda prend = dbExamen.Prendas.FirstOrDefault(p => p.IdPrenda == Id_prenda);
            return prend;

        }

        public List<Prenda> ConsultarTodas()
        {
            return dbExamen.Prendas.OrderBy(p => p.IdPrenda).ToList();

        }

        public string Actualizar()
        {
            try
            {
                Prenda prend = Consultar(prenda.IdPrenda);
                if (prend != null)
                {
                    dbExamen.Prendas.AddOrUpdate(prenda);
                    dbExamen.SaveChanges();
                    return "La prenda se actualizó correctamente ";
                }
                else
                {
                    return "La prenda no existe ";
                }
            }
            catch (Exception ex)
            {
                return "Error al actualizar la prenda " + ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                Prenda prend = Consultar(prenda.IdPrenda);
                if (prend == null)
                {
                    return "La prenda no existe ";
                }
                else
                {

                    dbExamen.Prendas.Remove(prend);
                    dbExamen.SaveChanges();
                    return "La prenda se eliminó correctamente ";
                }
            }
            catch (Exception ex)
            {

                return "Error al eliminar la prenda " + ex.Message;
            }

        }
    }
}