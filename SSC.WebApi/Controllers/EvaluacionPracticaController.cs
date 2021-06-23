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
    [Route("api/evaluacion-practica")]
    [ApiController]
    public class EvaluacionPracticaController : ControllerBase
    {
        private readonly ServicioEvaluacionPractica Servicio;
        public EvaluacionPracticaController(ServicioEvaluacionPractica servicio)
        {
            this.Servicio = servicio;
        }

        [HttpGet]
        public ActionResult<List<EvaluacionPractica>> Get()
        {
            var evaluaciones = Servicio.ObtenerTodos();
            return Ok(new { respuesta = evaluaciones, mensaje = "evaluaciones practicas OK" });
        }

        [HttpGet("{idCurso:int}")]
        public ActionResult<List<EvaluacionPractica>> GetByCourseId(int idCurso)
        {
            var evaluacion = Servicio.EvaluacionesPracticasDeUnCurso(idCurso);
            return Ok(new { respuesta = evaluacion, mensaje = "evaluaciones practicas de un curso OK" });
        }

        [HttpPost]
        public ActionResult<EvaluacionPractica> Post([FromBody] EvaluacionPractica value)
        {
            var evaluacion = Servicio.Agregar(value);
            return Ok(new { curso = evaluacion, mensaje = "evaluacion practica agregada correctamente" });
        }
    }
}
