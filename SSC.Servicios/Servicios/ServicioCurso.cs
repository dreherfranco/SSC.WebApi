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
    public class ServicioCurso: Servicio<Curso>
    {
        public ServicioCurso(Repositorio<Curso> repositorio): base(repositorio)
        {
            Repositorio = repositorio;
        }

        public Curso ObtenerUnCurso(string nombreCurso)
        {
            Expression<Func<Curso, bool>> filter = x => x.Nombre == nombreCurso;
            return this.Repositorio.Obtener(filter).FirstOrDefault();
;
        }
    }
}
