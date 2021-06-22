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
    public class EvaluacionTeoricaController : ControllerBase
    {
        private readonly ServicioEvaluacionTeorica Servicio;
        public EvaluacionTeoricaController(ServicioEvaluacionTeorica servicio) 
        {
            this.Servicio = servicio;
        }

        [HttpGet]
        public ActionResult<List<EvaluacionTeorica>> Get()
        {
            var evaluaciones = Servicio.ObtenerTodos();
            return Ok(new { respuesta = evaluaciones, mensaje = "evaluaciones teoricas OK" });
        }

        [HttpGet("{nombreCurso}")]
        public ActionResult<List<EvaluacionTeorica>> GetByCourseName(string nombreCurso)
        {
            var evaluacion = Servicio.EvaluacionesTeoricasDeUnCurso(nombreCurso);
            return Ok(new { respuesta = evaluacion, mensaje = "evaluaciones teoricas de un curso OK" });
        }

        [HttpPost]
        public ActionResult<EvaluacionTeorica> Post([FromBody] EvaluacionTeorica value)
        {
            var evaluacion = Servicio.Agregar(value);
            return Ok(new { curso = evaluacion, mensaje = "evaluacion teorica agregada correctamente" });
        }
    }
}
