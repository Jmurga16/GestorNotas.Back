using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NotaEntity
    {
        public int IdNotas { get; set; }
        public int IdAlumno { get; set; }
        public string sNombreAlumno { get; set; }
        public int IdCurso { get; set; }
        public string sNombreCurso { get; set; }
        public decimal nPractica1 { get; set; }
        public decimal nPractica2 { get; set; }
        public decimal nPractica3 { get; set; }
        public decimal nParcial { get; set; }
        public decimal nFinal { get; set; }
        public decimal nPromedioFinal { get; set; }
        public bool bEstado { get; set; }
    }
}
