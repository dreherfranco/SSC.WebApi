using SSC.Modelos.Interface;
using SSC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Servicios
{
    public class Servicio<TEntidad> where TEntidad : class,IEntidad
    {
        protected Repositorio<TEntidad> Repositorio { get; set; }
        public Servicio(Repositorio<TEntidad> repositorio)
        {
            Repositorio = repositorio;
        }

        public TEntidad Agregar(TEntidad entidad)
        {
            return Repositorio.Agregar(entidad);
            
        }

        public List<TEntidad> ObtenerTodos()
        {
            return Repositorio.Obtener().ToList();
        }

        public void Actualizar(TEntidad entidad)
        {
            Repositorio.Actualizar(entidad);
        }

        public void Borrar(TEntidad entidad )
        {
            Repositorio.Eliminar(entidad);
        }

        public TEntidad ObtenerPorId(int id)
        {
            Expression<Func<TEntidad, bool>> filter = x => x.Id == id;
            return Repositorio.Obtener(filter).FirstOrDefault();
            
        }
    }
}
