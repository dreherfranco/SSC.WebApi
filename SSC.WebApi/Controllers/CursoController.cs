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
    [Route("api/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ServicioCurso Servicio;
        public CursoController(ServicioCurso servicio)
        {
             this.Servicio = servicio;
        }

        [HttpGet]
        public ActionResult<List<Curso>> Get()
        {
            var cursos = Servicio.ObtenerTodos();
            return Ok(new { respuesta = cursos, mensaje = "curso OK" });
        }

        [HttpGet("{id}", Name ="GetCurso")]
        public ActionResult<Curso> GetById(int id)
        {
            var curso = Servicio.ObtenerUnCursoPorId(id);
            return Ok(new { respuesta = curso, mensaje = "curso OK" });
        }
       
        [HttpPost]
        public ActionResult<Curso> Post([FromBody] Curso value)
        {
            var curso = Servicio.Agregar(value);
            return new CreatedAtRouteResult("GetCurso", new { Id = curso.Id }, curso);
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
