using DAL.Contracts;
using DAL.Repositories.SqlServer.Models;
using SL.DAL.Repositories.SqlServer.Models;
using SL.Domain.Security;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SqlServer
{
    /// <summary>
    /// Repositorio SQL Server para acceso general de repositorio.
    /// Tiene el propósito de realizar operaicones globales, como eliminar todos los elementos pertenecientes a un usuario.
    /// </summary>
    internal class GeneralRepository : IGeneralRepository
    {
        #region Singleton
        private readonly static GeneralRepository _instance;
        public static GeneralRepository Current { get { return _instance; } }
        static GeneralRepository() { _instance = new GeneralRepository(); }
        private GeneralRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void RemoveAll(SL.Domain.Security.Usuario usuario)
        {
            try
            {
                using (var db = new BudgeeEntities())
                {
                    #region Debo empezar por aquellos que no sean FK de otras
                    db.Notificacion.RemoveRange(db.Notificacion.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    db.Presupuesto.RemoveRange(db.Presupuesto.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    #endregion

                    #region Ahora vienen las que tienen tablas intermedias
                    //Primero vacio tablas intermedias
                    var id_cuentas = db.Cuenta.Where(x => x.ID_Usuario == usuario.ID_Usuario).Select(x => x.ID_Cuenta).ToList();

                    var id_transac = db.Transaccion.Where(x => id_cuentas.Contains(x.Cuenta.ID_Cuenta)).Select(x => x.ID_Transaccion).ToList();
                    var id_planif = db.Planificacion_Transaccion.Where(x => id_cuentas.Contains(x.Cuenta.ID_Cuenta)).Select(x => x.ID_Planificacion_Transaccion).ToList();
                    var id_plantillas = db.Plantilla_Transaccion.Where(x => x.ID_Usuario == usuario.ID_Usuario).Select(x => x.ID_Plantilla_Transaccion).ToList();

                    db.Transaccion_Etiqueta.RemoveRange(db.Transaccion_Etiqueta.Where(x => id_transac.Contains(x.ID_Transaccion)));
                    db.PlanificacionTransaccion_Etiqueta.RemoveRange(db.PlanificacionTransaccion_Etiqueta.Where(x => id_planif.Contains(x.ID_Planificacion_Transaccion)));
                    db.PlantillaTransaccion_Etiqueta.RemoveRange(db.PlantillaTransaccion_Etiqueta.Where(x => id_plantillas.Contains(x.ID_Plantilla_Transaccion)));

                    var id_expr = db.Expresion.Where(x => x.ID_Usuario == usuario.ID_Usuario).Select(x => x.ID_Expresion).ToList();

                    db.Expresion_Variable.RemoveRange(db.Expresion_Variable.Where(x => id_expr.Contains(x.ID_Expresion)));

                    //Ahora que no hay intermedias, elimino las variables, que pueden apuntar a transac, planif o plantillas
                    db.Variable.RemoveRange(db.Variable.Where(x => x.ID_Usuario == usuario.ID_Usuario));

                    //Elimino transac, planif y plantillas, que pueden apuntar a expresiones
                    db.Transaccion.RemoveRange(db.Transaccion.Where(x => id_cuentas.Contains(x.Cuenta.ID_Cuenta)));
                    db.Planificacion_Transaccion.RemoveRange(db.Planificacion_Transaccion.Where(x => id_cuentas.Contains(x.Cuenta.ID_Cuenta)));
                    db.Plantilla_Transaccion.RemoveRange(db.Plantilla_Transaccion.Where(x => x.ID_Usuario == usuario.ID_Usuario));

                    //Finalmente elimino expresiones
                    db.Expresion.RemoveRange(db.Expresion.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    #endregion

                    #region Debo finalizar con aquellas que no posean FKs de otras
                    db.Recordatorio.RemoveRange(db.Recordatorio.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    db.Caracteristica.RemoveRange(db.Caracteristica.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    db.Cuenta.RemoveRange(db.Cuenta.Where(x => x.ID_Usuario == usuario.ID_Usuario));
                    #endregion

                    //GUARDO CAMBIOS
                    db.SaveChanges();
                }
                using (var db = new BudgeeSLEntities())
                {
                    //Lapso no le pega a ninguna FK
                    db.Lapso.RemoveRange(db.Lapso.Where(x => x.ID_Usuario == usuario.ID_Usuario));

                    //FrecuenciaInicio hay que evitar las que posean las configuraciones de usuario
                    var id_frecuencia_evitar = db.Configuracion_Usuario.Where(x => x.ID_FrecuenciaInicio_Respaldos != null).Select(x => x.ID_FrecuenciaInicio_Respaldos).ToList();

                    db.FrecuenciaInicio.RemoveRange(db.FrecuenciaInicio.Where(x => x.ID_Usuario == usuario.ID_Usuario && !id_frecuencia_evitar.Contains(x.ID_FrecuenciaInicio)));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
