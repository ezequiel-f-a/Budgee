using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Expresión.
    /// </summary>
    internal class ExpresionAdapter : IGenericAdapter<Domain.Expresion, Models.Expresion>
    {
        #region Singleton
        private readonly static ExpresionAdapter _instance;
        public static ExpresionAdapter Current { get { return _instance; } }
        static ExpresionAdapter() { _instance = new ExpresionAdapter(); }
        private ExpresionAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Expresion Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Expresion Adapt(Models.Expresion Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            var variables = new List<Domain.Variable>();

            using (var db = new Models.BudgeeEntities())
            {
                db.Expresion_Variable.AsNoTracking();
                var ID_Variables = db.Expresion_Variable.Where(x => x.ID_Expresion == Entity.ID_Expresion).ToList()
                    .Select(x => x.ID_Variable);

                variables = ID_Variables.Select(x => VariableRepository.Current.GetOne(x)).ToList();
            }

            return new Domain.Expresion(
                Entity.ID_Expresion,
                Entity.Definicion,
                variables,
                (Tipo_Expresion)Entity.Tipo_Expresion.ToEnum(new Tipo_Expresion()),
                usuario
                );
        }
        public Models.Expresion Adapt(Domain.Expresion Obj)
        {
            return new Models.Expresion()
            {
                ID_Expresion = Obj.ID_Expresion,
                Definicion = Obj.Definicion,
                Tipo_Expresion = Obj.Tipo_Expresion.ToString(),
                ID_Usuario = Obj.Usuario.ID_Usuario
            };
        }
    }
}
