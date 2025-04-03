using Examen2.Models;
using Examen2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen2.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            clsCliente client = new clsCliente();
            return client.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Cliente Consultar(string Id_cliente)
        {
            clsCliente client = new clsCliente();
            return client.Consultar(Id_cliente);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            clsCliente client = new clsCliente();
            client.cliente = cliente;
            return client.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente cliente)
        {
            clsCliente client = new clsCliente();
            client.cliente = cliente;
            return client.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cliente cliente)
        {
            clsCliente client = new clsCliente();
            client.cliente = cliente;
            return client.Eliminar();
        }
    }
}
