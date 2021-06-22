using SSC.Modelos.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Modelos
{
    public class EvaluacionPractica: Evaluacion
    {
        public EvaluacionPractica():base()
        {
            
        }
        public bool Aprobado { get; set; }
        
    }
}
