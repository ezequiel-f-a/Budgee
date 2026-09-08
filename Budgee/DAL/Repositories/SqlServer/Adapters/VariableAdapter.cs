using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Variable.
    /// </summary>
    internal class VariableAdapter : IGenericAdapter<Domain.Variable, Models.Variable>
    {
        #region Singleton
        private readonly static VariableAdapter _instance;
        public static VariableAdapter Current { get { return _instance; } }
        static VariableAdapter() { _instance = new VariableAdapter(); }
        private VariableAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Variable Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Variable Adapt(Models.Variable Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            Domain.Transaccion transaccion = null;
            if (Entity.ID_Transaccion != null)
                transaccion = TransaccionRepository.Current.GetOne((Guid)Entity.ID_Transaccion);

            Domain.Planificacion planificacion = null;
            if (Entity.ID_Planificacion_Transaccion != null)
                planificacion = PlanificacionRepository.Current.GetOne((Guid)Entity.ID_Planificacion_Transaccion);

            Domain.PlantillaTransaccion plantillaTransaccion = null;
            if (Entity.ID_Plantilla_Transaccion != null)
                plantillaTransaccion = PlantillaTransaccionRepository.Current.GetOne((Guid)Entity.ID_Plantilla_Transaccion);

            Domain.Cuenta cuenta = null;
            if (Entity.ID_Cuenta != null)
                cuenta = CuentaRepository.Current.GetOne((Guid)Entity.ID_Cuenta);

            Domain.Caracteristica categoria = null;
            if (Entity.ID_Categoria != null)
                categoria = CaracteristicaRepository.Current.GetOne((Guid)Entity.ID_Categoria);

            Domain.Caracteristica etiqueta = null;
            if (Entity.ID_Etiqueta != null)
                etiqueta = CaracteristicaRepository.Current.GetOne((Guid)Entity.ID_Etiqueta);

            SL.Domain.Lapso lapso = null;
            if (Entity.ID_Lapso != null)
                lapso = SL.BLL.Services.LapsoService.Current.GetOne((Guid)Entity.ID_Lapso);

            return new Domain.Variable(
                Entity.ID_Variable,
                Entity.Nombre_Variable,
                (Tipo_Variable)Entity.Tipo_Variable.ToEnum(new Tipo_Variable()),
                transaccion,
                planificacion,
                plantillaTransaccion,
                cuenta,
                categoria,
                etiqueta,
                lapso,
                Entity.Fecha,
                usuario
                );
        }
        public Models.Variable Adapt(Domain.Variable Obj)
        {
            return new Models.Variable()
            {
                ID_Variable = Obj.ID_Variable,
                Nombre_Variable = Obj.Nombre_Variable,
                Tipo_Variable = Obj.Tipo_Variable.ToString(),
                ID_Transaccion = Obj.Transaccion?.ID_Transaccion,
                ID_Planificacion_Transaccion = Obj.Planificacion?.ID_Planificacion,
                ID_Plantilla_Transaccion = Obj.PlantillaTransaccion?.ID_PlantillaTransaccion,
                ID_Cuenta = Obj.Cuenta?.ID_Cuenta,
                ID_Categoria = Obj.Categoria?.ID_Caracteristica,
                ID_Etiqueta = Obj.Etiqueta?.ID_Caracteristica,
                ID_Lapso = Obj.Lapso?.ID_Lapso,
                Fecha = Obj.Fecha,
                ID_Usuario = Obj.Usuario.ID_Usuario
            };
        }
    }
}
