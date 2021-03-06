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
    public class ServicioEvaluacionTeorica : Servicio<EvaluacionTeorica>
    {

        public ServicioEvaluacionTeorica(Repositorio<EvaluacionTeorica> repositorio) : base(repositorio)
        {
            Repositorio = repositorio;
        }

        public List<EvaluacionTeorica> EvaluacionesTeoricasDeUnCurso(int idCurso)
        {
            Expression<Func<EvaluacionTeorica, bool>> filtro = x => x.Curso.Id == idCurso;
            return Repositorio.Obtener(filtro).ToList();
        }
    }
}
