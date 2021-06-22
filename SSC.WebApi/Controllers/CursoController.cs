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
    [Route("api/[controller]")]
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
            return Ok(new { respuesta = cursos, mensaje = "cursos de un curso OK" });
        }

        [HttpGet("{nombreCurso}")]
        public ActionResult<Curso> GetByCourseName(string nombreCurso)
        {
            var curso = Servicio.ObtenerUnCurso(nombreCurso);
            return Ok(new { respuesta = curso, mensaje = "curso de un curso OK" });
        }

        [HttpPost]
        public ActionResult<Curso> Post([FromBody] Curso value)
        {
            var curso = Servicio.Agregar(value);
            return Ok(new { curso = curso, mensaje = "curso agregado correctamente" });
        }
    }
}
