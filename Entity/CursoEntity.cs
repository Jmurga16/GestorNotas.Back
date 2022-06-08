using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CursoEntity
    {
        public int IdCurso { get; set; }
        public string sNombre { get; set; }
        public string sDescripcion { get; set; }
        public bool bObligatorio { get; set; }
        public bool bEstado { get; set; }

    }
}
