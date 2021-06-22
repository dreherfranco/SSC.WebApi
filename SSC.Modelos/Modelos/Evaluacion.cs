using SSC.Modelos.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Modelos.Abstractas
{
    public class Evaluacion:IEntidad
    {
        
        public int Id { get; set; }
        public int NumeroEvaluacion { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
