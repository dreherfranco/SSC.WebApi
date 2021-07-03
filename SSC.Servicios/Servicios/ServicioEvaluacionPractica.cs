using SSC.Modelos;
using SSC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Servicios
{
    public class ServicioEvaluacionPractica: Servicio<EvaluacionPractica>
    {

        public ServicioEvaluacionPractica(Repositorio<EvaluacionPractica> repositorio): base(repositorio)
        {
            Repositorio = repositorio;
        }

        public  List<EvaluacionPractica> EvaluacionesPracticasDeUnCurso(int idCurso)
        {
            Expression<Func<EvaluacionPractica, bool>> filtro = x => x.Curso.Id == idCurso;
            return Repositorio.Obtener(filtro).ToList();
        }

        
    }
}
