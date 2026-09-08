using Enums;
using SL.DAL.Contracts;
using SL.Domain.Security;
using SL.Services;
using System;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de FrecuenciaInicio.
    /// </summary>
    internal class FrecuenciaInicioAdapter : IGenericAdapter<Domain.FrecuenciaInicio, Models.FrecuenciaInicio>
    {
        #region Singleton
        private readonly static FrecuenciaInicioAdapter _instance;
        public static FrecuenciaInicioAdapter Current { get { return _instance; } }
        static FrecuenciaInicioAdapter() { _instance = new FrecuenciaInicioAdapter(); }
        private FrecuenciaInicioAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.FrecuenciaInicio Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.FrecuenciaInicio Adapt(Models.FrecuenciaInicio Entity)
        {
            return new Domain.FrecuenciaInicio(
                Entity.ID_FrecuenciaInicio,
                Entity.FrecuenciaMagnitud.ToEnum(new Frecuencia()),
                Entity.FrecuenciaValor,
                Entity.Año,
                Entity.Mes,
                Entity.Dia_del_Mes.ToEnum(new Dia_del_Mes()),
                Entity.Dia_de_la_Semana.ToEnum(new Dia_de_la_Semana()),
                Entity.Horario,
                Entity.Fecha_Ultimo_Proceso,
                Entity.ID_Usuario);
        }
        public Models.FrecuenciaInicio Adapt(Domain.FrecuenciaInicio Obj)
        {
            return new Models.FrecuenciaInicio()
            {
                ID_FrecuenciaInicio = Obj.ID_FrecuenciaInicio,
                FrecuenciaMagnitud = Obj.FrecuenciaMagnitud?.ToString(),
                FrecuenciaValor = Obj.FrecuenciaValor,
                Año = Obj.Año,
                Mes = Obj.Mes,
                Dia_del_Mes = Obj.DiaDelMes?.ToString(),
                Dia_de_la_Semana = Obj.DiaDeLaSemana?.ToString(),
                Horario = Obj.Horario,
                Fecha_Ultimo_Proceso = Obj.FechaUltimoProceso,
                ID_Usuario = Obj.ID_Usuario
            };
        }
    }
}
