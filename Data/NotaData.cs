using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NotaData
    {

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #region Conexion
        private readonly Conexion oCon;

        public AlumnosxCursoData()
        {
            oCon = new Conexion(1);
        }
        #endregion

        private readonly List<NotaEntity> listaAlumno = new List<NotaEntity>();


        #region Alumnos
        public object DataAlumnosxCurso(GeneralEntity genEnt)
        {

            string msj = string.Empty;
            try
            {

                switch (genEnt.sOpcion)
                {

                    #region 01. Consultar Todo | 02. Consultar x Id
                    case "01":
                    case "02":

                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_AlumnosxCurso", genEnt.sOpcion, genEnt.pParametro))
                        {

                            while (dr.Read())
                            {
                                NotaEntity entity = new NotaEntity();


                                entity.IdNotas = Int32.Parse(Convert.ToString(dr["IdNotas"]));
                                entity.IdAlumno = Int32.Parse(Convert.ToString(dr["IdAlumno"]));
                                entity.IdCurso = Int32.Parse(Convert.ToString(dr["IdCurso"]));
                                entity.sNombreCurso = Convert.ToString(dr["sNombreCurso"]);
                                entity.nPractica1 = Decimal.Parse(Convert.ToString(dr["nPractica1"]));
                                entity.nPractica2 = Decimal.Parse(Convert.ToString(dr["nPractica2"]));
                                entity.nPractica3 = Decimal.Parse(Convert.ToString(dr["nPractica3"]));
                                entity.nParcial = Decimal.Parse(Convert.ToString(dr["nParcial"]));
                                entity.nFinal = Decimal.Parse(Convert.ToString(dr["nFinal"]));
                                entity.nPromedioFinal = Decimal.Parse(Convert.ToString(dr["nPromedioFinal"]));

                                //entity.bEstado = Boolean.Parse(Convert.ToString(dr["bEstado"]));


                                listaAlumno.Add(entity);

                            }

                            return listaAlumno;

                        }
                    #endregion

                    #region 03. Insertar | 04. Editar | 05. Eliminar
                    case "03":
                    case "04":
                    case "05":

                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_AlumnosxCurso", genEnt.sOpcion, genEnt.pParametro));
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
