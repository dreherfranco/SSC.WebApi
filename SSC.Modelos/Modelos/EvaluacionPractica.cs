using SSC.Modelos.Abstractas;
using SSC.Modelos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSC.Modelos
{
    public class EvaluacionPractica: IEntidad
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public bool Aprobado { get; set; }
        [JsonIgnore]
        public virtual Curso Curso { get; set; }

        public EvaluacionPractica() { }

    }
}
