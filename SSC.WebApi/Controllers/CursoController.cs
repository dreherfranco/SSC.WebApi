using Microsoft.AspNetCore.Mvc;
using SSC.Modelos;
using SSC.Repositorio;
using SSC.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ServicioCurso Servicio;
        public CursoController(ServicioCurso servicio)
        {
             this.Servicio = servicio;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult<List<Curso>> Get()
        {
            var cursos = Servicio.ObtenerTodos();
            return Ok(new { respuesta = cursos, mensaje = "curso OK" });
        }

        [Route("api/[controller]/{id:int}")]
        [HttpGet]
        public ActionResult<Curso> GetById(int id)
        {
            var curso = Servicio.ObtenerUnCursoPorId(id);
            return Ok(new { respuesta = curso, mensaje = "curso OK" });
        }

        [HttpGet("{nombreCurso}")]
        public ActionResult<Curso> GetByCourseName(string nombreCurso)
        {
            var curso = Servicio.ObtenerUnCursoPorNombre(nombreCurso);
            return Ok(new { respuesta = curso, mensaje = "curso OK" });
        }

        [HttpPost]
        public ActionResult<Curso> Post([FromBody] Curso value)
        {
            var curso = Servicio.Agregar(value);
            return Ok(new { curso = curso, mensaje = "curso agregado correctamente" });
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody]Curso value, int id)
        {
            try
            {
                value.Id = id;
                this.Servicio.Actualizar(value);
                return NoContent();
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var curso = this.Servicio.ObtenerUnCursoPorId(id);
                this.Servicio.Borrar(curso);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
