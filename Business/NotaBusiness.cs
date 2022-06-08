using Data;
using Entity;
using NLog;
using System;

namespace Business
{
    public class NotaBusiness
    {
        private readonly NotaData notaData = new NotaData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();


        public object BusinessNota(GeneralEntity genEnt)
        {
            try
            {

                return notaData.DataNota(genEnt);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
