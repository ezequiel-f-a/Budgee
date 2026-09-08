using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Transacción.
    /// </summary>
    internal class TransaccionAdapter : IGenericAdapter<Domain.Transaccion, Models.Transaccion>
    {
        #region Singleton
        private readonly static TransaccionAdapter _instance;
        public static TransaccionAdapter Current { get { return _instance; } }
        static TransaccionAdapter() { _instance = new TransaccionAdapter(); }
        private TransaccionAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Transaccion Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Transaccion Adapt(Models.Transaccion Entity)
        {
            Domain.Cuenta cuenta = CuentaRepository.Current.GetOne(Entity.ID_Cuenta);

            Domain.Caracteristica categoria = null;
            if (Entity.ID_Categoria != null)
                categoria = CaracteristicaRepository.Current.GetOne((Guid)Entity.ID_Categoria);

            Domain.Expresion expresion = null;
            if (Entity.ID_Monto_Expresion != null)
                expresion = ExpresionRepository.Current.GetOne((Guid)Entity.ID_Monto_Expresion);

            var etiquetas = new List<Domain.Caracteristica>();

            using (var db = new Models.BudgeeEntities())
            {
                db.Transaccion_Etiqueta.AsNoTracking();
                var ID_Etiquetas = db.Transaccion_Etiqueta.Where(x => x.ID_Transaccion == Entity.ID_Transaccion).ToList()
                    .Select(x => x.ID_Etiqueta);

                etiquetas = ID_Etiquetas.Select(x => CaracteristicaRepository.Current.GetOne(x)).ToList();
            }

            return new Domain.Transaccion(
                Entity.ID_Transaccion,
                Entity.Fecha,
                cuenta,
                Entity.Concretada,
                Entity.Descripcion,
                categoria,
                etiquetas,
                expresion,
                (Tipo_Operacion)Entity.Tipo_Operacion.ToEnum(new Tipo_Operacion()),
                Entity.Estado
                );
        }
        public Models.Transaccion Adapt(Domain.Transaccion Obj)
        {
            return new Models.Transaccion()
            {
                ID_Transaccion = Obj.ID_Transaccion,
                Fecha = Obj.Fecha,
                ID_Cuenta = Obj.Cuenta.ID_Cuenta,
                Concretada = Obj.Concretada,
                Descripcion = Obj.Descripcion,
                ID_Categoria = Obj.Categoria?.ID_Caracteristica,
                ID_Monto_Expresion = Obj.MontoExpresion.ID_Expresion,
                Tipo_Operacion = Obj.TipoOperacion?.ToString(),
                Estado = Obj.Estado
            };
        }
    }
}
