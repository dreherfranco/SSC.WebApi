using Microsoft.AspNetCore.Mvc;
using SSC.Modelos;
using SSC.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSC.WebApi.Controllers
{
    [Route("api/capitulo")]
    [ApiController]
    public class CapituloController : ControllerBase
    {
        private readonly ServicioCapitulo Servicio;
        public CapituloController(ServicioCapitulo servicio)
        {
            this.Servicio = servicio;
        }


        [HttpGet]
        public ActionResult<List<Capitulo>> Get()
        {
            var capitulos = Servicio.ObtenerTodos();
            return Ok(new { respuesta = capitulos, mensaje = "capitulos de un curso OK" });
        }
        // GET: api/<CapituloController>
        [HttpGet("{nombreCurso}")]
        public ActionResult<List<Capitulo>> GetByName(string nombreCurso)
        {
            var capitulosCurso = Servicio.CapitulosDeUnCurso(nombreCurso);
            return Ok(new {respuesta= capitulosCurso , mensaje = "capitulos de un curso OK" });
        }

        // POST api/<CapituloController>
        [HttpPost]
        public ActionResult<Capitulo> Post([FromBody] Capitulo value)
        {
            var capitulo = Servicio.Agregar(value);
            return Ok(new { capitulo = capitulo, mensaje = "capitulo agregado correctamente" });
        }

    }
}
