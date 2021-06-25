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
    [Route("api/evaluacion-teorica")]
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
            try
            {
                var evaluaciones = Servicio.ObtenerTodos();
                return Ok(new { respuesta = evaluaciones, mensaje = "evaluaciones teoricas OK" });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("curso/{idCurso:int}")]
        public ActionResult<List<EvaluacionTeorica>> GetAllByCourseId(int idCurso)
        {
            try
            {
                var evaluacion = Servicio.EvaluacionesTeoricasDeUnCurso(idCurso);
                return Ok(new { respuesta = evaluacion, mensaje = "evaluaciones teoricas de un curso OK" });
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<EvaluacionTeorica> GetOneById(int id)
        {
            try
            {
                var evaluacionTeoricaCurso = Servicio.ObtenerPorId(id);
                return Ok(new { respuesta = evaluacionTeoricaCurso, mensaje = "ev teorica OK" });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<EvaluacionTeorica> Post([FromBody] EvaluacionTeorica value)
        {
            try
            {
                var evaluacion = Servicio.Agregar(value);
                return Ok(new { curso = evaluacion, mensaje = "evaluacion teorica agregada correctamente" });
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] EvaluacionTeorica value, int id)
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
                var evaluacionTeorica = this.Servicio.ObtenerPorId(id);
                this.Servicio.Borrar(evaluacionTeorica);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
