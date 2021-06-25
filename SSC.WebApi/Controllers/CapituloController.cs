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
            try
            {
                var capitulos = Servicio.ObtenerTodos();
                return Ok(new { respuesta = capitulos, mensaje = "capitulos totales OK" });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("curso/{idCurso:int}")]
        public ActionResult<List<Capitulo>> GetAllByCourseId(int idCurso)
        {
            try
            {
                var capitulosCurso = Servicio.CapitulosDeUnCurso(idCurso);
                return Ok(new { respuesta = capitulosCurso, mensaje = "capitulos de un curso OK" });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Capitulo> GetOneById(int id)
        {
            try
            {
                var capituloCurso = Servicio.ObtenerPorId(id);
                return Ok(new { respuesta = capituloCurso, mensaje = "capitulo OK" });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<Capitulo> Post([FromBody] Capitulo value)
        {
            try
            {
                var capitulo = Servicio.Agregar(value);
                return Ok(new { capitulo = capitulo, mensaje = "capitulo agregado correctamente" });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Capitulo value, int id)
        {
            try
            {
                value.Id = id;
                this.Servicio.Actualizar(value);
                return NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var capitulo = this.Servicio.ObtenerPorId(id);
                this.Servicio.Borrar(capitulo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
