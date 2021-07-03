using SSC.Modelos.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Modelos
{
    public class Curso: IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Instructor { get; set; }
        public float Costo { get; set; }
        public virtual List<Capitulo> Capitulos { get; set; }
        public virtual List<EvaluacionPractica> EvaluacionesPracticas { get; set; }
        public virtual List<EvaluacionTeorica> EvaluacionesTeoricas { get; set; }
    }
}
