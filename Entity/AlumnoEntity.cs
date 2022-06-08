using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlumnoEntity
    {
        public int IdAlumno { get; set; }
        public string sCodAlu { get; set; }
        public string sNombrePri { get; set; }
        public string sNombreSec { get; set; }
        public string sApellidoPaterno { get; set; }
        public string sApellidoMaterno { get; set; }
        public DateTime dFechaNacimiento { get; set; }
        public string dFechaNac { get; set; }
        public string sSexo { get; set; }
        public bool bEstado { get; set; }

    }
}
