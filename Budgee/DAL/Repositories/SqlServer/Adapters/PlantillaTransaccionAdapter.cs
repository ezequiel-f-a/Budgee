using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Plantilla de Transacción.
    /// </summary>
    internal class PlantillaTransaccionAdapter : IGenericAdapter<Domain.PlantillaTransaccion, Models.Plantilla_Transaccion>
    {
        #region Singleton
        private readonly static PlantillaTransaccionAdapter _instance;
        public static PlantillaTransaccionAdapter Current { get { return _instance; } }
        static PlantillaTransaccionAdapter() { _instance = new PlantillaTransaccionAdapter(); }
        private PlantillaTransaccionAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.PlantillaTransaccion Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.PlantillaTransaccion Adapt(Models.Plantilla_Transaccion Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            Domain.Caracteristica categoria = null;
            if (Entity.ID_Categoria != null)
                categoria = CaracteristicaRepository.Current.GetOne((Guid)Entity.ID_Categoria);

            Domain.Expresion expresion = null;
            if (Entity.ID_Monto_Expresion != null)
                expresion = ExpresionRepository.Current.GetOne((Guid)Entity.ID_Monto_Expresion);

            Tipo_Operacion? tipo_Operacion = null;
            if (Entity.Tipo_Operacion != null) tipo_Operacion = (Tipo_Operacion)Entity.Tipo_Operacion.ToEnum(new Tipo_Operacion());

            var etiquetas = new List<Domain.Caracteristica>();

            using (var db = new Models.BudgeeEntities())
            {
                db.PlantillaTransaccion_Etiqueta.AsNoTracking();
                var ID_Etiquetas = db.PlantillaTransaccion_Etiqueta.Where(x => x.ID_Plantilla_Transaccion == Entity.ID_Plantilla_Transaccion).ToList()
                    .Select(x => x.ID_Etiqueta);

                etiquetas = ID_Etiquetas.Select(x => CaracteristicaRepository.Current.GetOne(x)).ToList();
            }

            return new Domain.PlantillaTransaccion(
                Entity.ID_Plantilla_Transaccion,
                Entity.Descripcion_Plantilla,
                Entity.Descripcion_Transaccion,
                categoria,
                etiquetas,
                expresion,
                tipo_Operacion,
                usuario,
                Entity.Estado
                );
        }
        public Models.Plantilla_Transaccion Adapt(Domain.PlantillaTransaccion Obj)
        {
            return new Models.Plantilla_Transaccion()
            {
                ID_Plantilla_Transaccion = Obj.ID_PlantillaTransaccion,
                Descripcion_Plantilla = Obj.Descripcion,
                Descripcion_Transaccion = Obj.Descripcion_Transaccion,
                ID_Usuario = Obj.Usuario.ID_Usuario,
                ID_Categoria = Obj.Categoria?.ID_Caracteristica,
                ID_Monto_Expresion = Obj.MontoExpresion?.ID_Expresion,
                Tipo_Operacion = Obj.TipoOperacion?.ToString(),
                Estado = Obj.Estado
            };
        }
    }
}
