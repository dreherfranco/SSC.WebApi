using Microsoft.EntityFrameworkCore;
using SSC.DbConfiguration;
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
    public class ServicioCurso : Servicio<Curso>
    {
        public ServicioCurso(Repositorio<Curso> repositorio): base(repositorio)
        {
            Repositorio = repositorio;
        }

   
        public Curso ObtenerUnCursoPorId(int id)
        {
            Expression<Func<Curso, bool>> filter = x => x.Id == id;
            var curso = Repositorio.Obtener(filter)
                .AsQueryable()
                .Include(x=>x.Capitulos)
                .Include(x=>x.EvaluacionesPracticas)
                .Include(x=>x.EvaluacionesTeoricas)
                .FirstOrDefault();
            return curso;
        }
    }
}
