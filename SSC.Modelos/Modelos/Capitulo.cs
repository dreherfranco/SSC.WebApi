using SSC.Modelos.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Modelos
{
    public class Capitulo: IEntidad
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
