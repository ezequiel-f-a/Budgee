using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Cuenta.
    /// </summary>
    internal class CuentaAdapter : IGenericAdapter<Domain.Cuenta, Models.Cuenta>
    {
        #region Singleton
        private readonly static CuentaAdapter _instance;
        public static CuentaAdapter Current { get { return _instance; } }
        static CuentaAdapter() { _instance = new CuentaAdapter(); }
        private CuentaAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Cuenta Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Cuenta Adapt(Models.Cuenta Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            return new Domain.Cuenta(
                Entity.ID_Cuenta,
                Entity.Nombre_Cuenta,
                (Divisa)Entity.Divisa.ToEnum(new Divisa()),
                usuario,
                Entity.Admite_Fondos_Negativos,
                Entity.Habilitado,
                Entity.Estado
                );
        }
        public Models.Cuenta Adapt(Domain.Cuenta Obj)
        {
            return new Models.Cuenta()
            {
                ID_Cuenta = Obj.ID_Cuenta,
                Nombre_Cuenta = Obj.Nombre,
                Divisa = Obj.Divisa.ToString(),
                ID_Usuario = Obj.Usuario.ID_Usuario,
                Admite_Fondos_Negativos = Obj.AdmiteFondosNegativos,
                Habilitado = Obj.Habilitada,
                Estado = Obj.Estado
            };
        }
    }
}
