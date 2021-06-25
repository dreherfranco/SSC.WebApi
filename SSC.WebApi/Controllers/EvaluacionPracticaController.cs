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

        [HttpGet("curso/{idCurso:int}")]
        public ActionResult<List<EvaluacionPractica>> GetByCourseId(int idCurso)
        {
            try
            {
                var evaluacion = Servicio.EvaluacionesPracticasDeUnCurso(idCurso);
                return Ok(new { respuesta = evaluacion, mensaje = "evaluaciones practicas de un curso OK" });
            }catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<EvaluacionPractica> GetOneById(int id)
        {
            try
            {
                var evaluacionPracticaCurso = Servicio.ObtenerPorId(id);
                return Ok(new { respuesta = evaluacionPracticaCurso, mensaje = "ev practica OK" });
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        public ActionResult<EvaluacionPractica> Post([FromBody] EvaluacionPractica value)
        {
            try
            {
                var evaluacion = Servicio.Agregar(value);
                return Ok(new { curso = evaluacion, mensaje = "evaluacion practica agregada correctamente" });
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] EvaluacionPractica value, int id)
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
                var evaluacionPractica = this.Servicio.ObtenerPorId(id);
                this.Servicio.Borrar(evaluacionPractica);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
