using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AlumnoData
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #region Conexion
        private readonly Conexion oCon;

        public AlumnoData()
        {
            oCon = new Conexion(1);
        }
        #endregion

        private readonly List<AlumnoEntity> listaAlumno = new List<AlumnoEntity>();


        #region Alumnos
        public object DataAlumno(GeneralEntity genEnt)
        {

            string msj = string.Empty;
            try
            {

                switch (genEnt.sOpcion)
                {

                    #region 01. Consultar Todo | 02. Consultar x Id
                    case "01":
                    case "02":

                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Alumnos", genEnt.sOpcion, genEnt.pParametro))
                        {

                            while (dr.Read())
                            {
                                AlumnoEntity entity = new AlumnoEntity();


                                entity.IdAlumno = Int32.Parse(Convert.ToString(dr["IdAlumno"]));
                                
                                entity.sCodAlu = Convert.ToString(dr["sCodAlu"]);
                                entity.sNombrePri = Convert.ToString(dr["sNombrePri"]);
                                entity.sNombreSec = Convert.ToString(dr["sNombreSec"]);
                                entity.sApellidoPaterno = Convert.ToString(dr["sApellidoPaterno"]);
                                entity.sApellidoMaterno = Convert.ToString(dr["sApellidoMaterno"]);
                                entity.dFechaNacimiento = Convert.ToDateTime(Convert.ToString(dr["dFechaNacimiento"]));                               
                                entity.sSexo = Convert.ToString(dr["sSexo"]);
                                entity.bEstado = Boolean.Parse(Convert.ToString(dr["bEstado"]));

                                if(genEnt.sOpcion=="02")
                                {
                                    entity.dFechaNac = Convert.ToString(dr["dFechaNac"]);
                                }

                                listaAlumno.Add(entity);

                            }

                            return listaAlumno;

                        }
                    #endregion

                    #region 03. Insertar | 04. Editar | 05. Eliminar
                    case "03":
                    case "04":
                    case "05":

                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_Alumnos", genEnt.sOpcion, genEnt.pParametro));
                        msj = sResultado;

                        return msj;
                    #endregion

                    default:
                        return null;
                }
            }
            catch (Exception exc4)
            {
                logger.Error(exc4);
                throw;
            }

        }
        #endregion

    }
}
