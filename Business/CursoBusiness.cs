﻿using Data;
using Entity;
using NLog;
using System;

namespace Business
{
    public class CursoBusiness
    {
        private readonly CursoData CursoData = new CursoData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();


        public object BusinessCurso(GeneralEntity genEnt)
        {
            try
            {

                return CursoData.DataCurso(genEnt);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
