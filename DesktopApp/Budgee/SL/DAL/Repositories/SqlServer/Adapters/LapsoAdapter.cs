using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Lapso.
    /// </summary>
    internal class LapsoAdapter : IGenericAdapter<Domain.Lapso, Models.Lapso>
    {
        #region Singleton
        private readonly static LapsoAdapter _instance;
        public static LapsoAdapter Current { get { return _instance; } }
        static LapsoAdapter() { _instance = new LapsoAdapter(); }
        private LapsoAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Lapso Adapt(object[] values)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetAll(x => x.ID_Usuario == (Guid)values[4]).FirstOrDefault();

            dynamic[] v = values;
            return new Domain.Lapso(
                v[0],
                (Tipo_Lapso)(v[1] as string).ToEnum(new Tipo_Lapso()),
                (v[2] is DBNull) ? null : v[2],
                (v[3] is DBNull) ? null : v[3],
                usuario);
        }
        public Domain.Lapso Adapt(Models.Lapso Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetAll(x => x.ID_Usuario == Entity.ID_Usuario).FirstOrDefault();

            return new Domain.Lapso(
                Entity.ID_Lapso,
                (Tipo_Lapso)Entity.Tipo_Lapso.ToEnum(new Tipo_Lapso()),
                Entity.Fecha_Desde,
                Entity.Fecha_Hasta,
                usuario);
        }

        public Models.Lapso Adapt(Domain.Lapso Obj)
        {
            return new Models.Lapso()
            {
                ID_Lapso = Obj.ID_Lapso,
                Tipo_Lapso = Obj.TipoLapso.ToString(),
                Fecha_Desde = Obj.FechaDesde,
                Fecha_Hasta = Obj.FechaHasta,
                ID_Usuario = Obj.Usuario.ID_Usuario
            };
        }
    }
}
