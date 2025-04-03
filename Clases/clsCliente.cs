using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
	public class clsCliente
	{
		private DBExamenEntities dbExamen = new DBExamenEntities();
		public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                dbExamen.Clientes.Add(cliente);
                dbExamen.SaveChanges();
                return "El cliente se agregó correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente " + ex.Message;
            }
        }

        public Cliente Consultar(string Id_cliente)
        {
            Cliente client = dbExamen.Clientes.FirstOrDefault(c => c.Documento == Id_cliente);
            return client;

        }

        public List<Cliente> ConsultarTodos()
        {
            return dbExamen.Clientes.OrderBy(c => c.Nombre).ToList();

        }

        public string Actualizar()
        {
            try
            {
                Cliente client = Consultar(cliente.Documento);
                if (client != null)
                {
                    dbExamen.Clientes.AddOrUpdate(cliente);
                    dbExamen.SaveChanges();
                    return "El cliente se actualizó correctamente ";
                }
                else
                {
                    return "El cliente no existe ";
                }
            }
            catch (Exception ex)
            {
                return "Error al actualizar el cliente " + ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                Cliente client = Consultar(cliente.Documento);
                if (client == null)
                {
                    return "El cliente no existe ";
                }
                else
                {

                    dbExamen.Clientes.Remove(client);
                    dbExamen.SaveChanges();
                    return "El cliente se eliminó correctamente ";
                }
            }
            catch (Exception ex)
            {

                return "Error al eliminar el cliente " + ex.Message;
            }

        }
    }
}
