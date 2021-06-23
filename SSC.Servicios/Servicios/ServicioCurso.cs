using SSC.Modelos;
using SSC.Repositorio;
using SSC.Repositorio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Servicios
{
    public class ServicioCurso: Servicio<Curso>
    {
        public ServicioCurso(Repositorio<Curso> repositorio): base(repositorio)
        {
            Repositorio = repositorio;
        }

        public Curso ObtenerUnCursoPorNombre(string nombreCurso)
        {
            Expression<Func<Curso, bool>> filter = x => x.Nombre == nombreCurso;
            var curso = this.Repositorio
                .Where(filter)
                .Include(x => x.Capitulos)
                .Include(x => x.EvaluacionesPracticas)
                .Include(x => x.EvaluacionesTeoricas)
                .FirstOrDefault();

            return curso;

        }
        public Curso ObtenerUnCursoPorId(int id)
        {
            Expression<Func<Curso, bool>> filter = x => x.Id == id;
            return this.Repositorio.Obtener(filter).FirstOrDefault();
        }
    }
}
