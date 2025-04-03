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
    [RoutePrefix("api/Prendas")]
    public class PrendasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Prenda> ConsultarTodas()
        {
            clsPrenda prend = new clsPrenda();
            return prend.ConsultarTodas();
        }

        [HttpGet]
        [Route("Consultar")]
        public Prenda Consultar(int Id_prenda)
        {
            clsPrenda prend = new clsPrenda();
            return prend.Consultar(Id_prenda);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Prenda prenda)
        {
            clsPrenda prend = new clsPrenda();
            prend.prenda = prenda;
            return prend.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Prenda prenda)
        {
            clsPrenda prend = new clsPrenda();
            prend.prenda = prenda;
            return prend.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Prenda prenda)
        {
            clsPrenda prend = new clsPrenda();
            prend.prenda = prenda;
            return prend.Eliminar();
        }
    }
}
