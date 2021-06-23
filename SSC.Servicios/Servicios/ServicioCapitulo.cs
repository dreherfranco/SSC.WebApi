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
    public class ServicioCapitulo: Servicio<Capitulo>
    {
        public ServicioCapitulo(Repositorio<Capitulo> repositorio):base(repositorio)
        {
            Repositorio = repositorio;
        }

        public List<Capitulo> CapitulosDeUnCurso(int idCurso)
        {
            Expression<Func<Capitulo, bool>> filtro = x => x.Curso.Id == idCurso;
            return this.Repositorio.Obtener(filtro).ToList();
        }
    }
}
