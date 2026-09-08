using SL.DAL.Contracts;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Patente.
    /// </summary>
    internal class PatenteAdapter : IGenericAdapter<Domain.Security.Patente, Models.Patente>
    {
        #region Singleton
        private readonly static PatenteAdapter _instance;
        public static PatenteAdapter Current { get { return _instance; } }
        static PatenteAdapter() { _instance = new PatenteAdapter(); }
        private PatenteAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Patente Adapt(object[] values)
        {
            dynamic[] v = values;

            return new Domain.Security.Patente(
                v[0],
                v[1],
                v[2]);
        }
        public Domain.Security.Patente Adapt(Models.Patente Entity)
        {
            return new Domain.Security.Patente(
                Entity.ID_Patente,
                Entity.Nombre,
                Entity.Definicion);
        }
        public Models.Patente Adapt(Domain.Security.Patente Obj)
        {
            return new Models.Patente()
            {
                ID_Patente = Obj.ID_Patente,
                Nombre = Obj.Nombre,
                Definicion = Obj.Definicion
            };
        }
    }
}
