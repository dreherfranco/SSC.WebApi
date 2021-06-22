using Microsoft.EntityFrameworkCore;
using SSC.DbConfiguration;
using SSC.Modelos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Repositorio
{
    public class Repositorio<T> where T : class,IEntidad
    {
        private ApplicationDbContext Contexto { get; set; }
        public Repositorio(ApplicationDbContext contexto)
        {
            Contexto = contexto;
        }

        public T Agregar(T entity)
        {
            Contexto.Set<T>().Add(entity);
            Contexto.SaveChangesAsync();
            return entity;
        }

        public List<T> Obtener(Expression<Func<T, bool>> filtro = null)
        {
            if (filtro == null)
            {
                return this.Contexto.Set<T>().ToList();
            }
            else
            {
                return this.Contexto.Set<T>().Where(filtro).ToList();
            }
           

        }

    }
}
