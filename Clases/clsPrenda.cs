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
        public string GrabarImagenPrenda(int idPrenda, List<string> Fotos)
        {
            try
            {
                foreach (string foto in Fotos)
                {
                    FotoPrenda fotoPrenda = new FotoPrenda();
                    fotoPrenda.idPrenda = idPrenda;
                    fotoPrenda.FotoPrenda1 = foto;
                    dbExamen.FotoPrendas.Add(fotoPrenda);
                    dbExamen.SaveChanges();
                }
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public IQueryable ListarFotoPrenda(int idPrenda)
        {
            return from C in dbExamen.Set<Cliente>()
                   join P in dbExamen.Set<Prenda>()
                   on C.Documento equals P.Cliente
                   join FP in dbExamen.Set<FotoPrenda>()
                   on P.IdPrenda equals FP.idPrenda
                   where FP.idPrenda == idPrenda
                   orderby FP.idPrenda
                   select new
                   {
                       Documento = C.Documento,
                       Nombre = C.Nombre,
                       Celular = C.Celular,
                       Email = C.Email,
                       TipoPrenda = P.TipoPrenda,
                       Descripcion = P.Descripcion,
                       Valor = P.Valor,
                       FotoPrenda = FP.FotoPrenda1
                   };
        }
    }
}