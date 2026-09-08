using SL.DAL.Contracts;
using SL.DAL.Repositories.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Familia.
    /// </summary>
    internal class FamiliaAdapter : IGenericAdapter<Domain.Security.Familia, Models.Familia>
    {
        #region Singleton
        private readonly static FamiliaAdapter _instance;
        public static FamiliaAdapter Current { get { return _instance; } }
        static FamiliaAdapter() { _instance = new FamiliaAdapter(); }
        private FamiliaAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Familia Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Security.Familia Adapt(Models.Familia Entity)
        {
            //Tengo que obtener los privilegios de mi familia (familias hijas o patentes)
            var privilegios = new List<Domain.Security.Privilegio>();

            using (var db = new BudgeeSLEntities())
            {
                //Primero me traigo los IDs de las familias hijas o patentes pertenecientes a mi familia
                db.Familia_Familia.AsNoTracking();
                db.Familia_Patente.AsNoTracking();
                var ID_FamiliasHijas = db.Familia_Familia.Where(x => x.ID_Familia_Padre == Entity.ID_Familia).ToList().Select(x => x.ID_Familia_Hija);
                var ID_Patentes = db.Familia_Patente.Where(x => x.ID_Familia == Entity.ID_Familia).ToList().Select(x => x.ID_Patente);

                //Ahora le pego al repositorio de familia para que me genere una lista con todas las familias hijas
                //En el caso de familias hago GetOne por Guid para que no termine en loop infinito de hidratación
                var FamiliasHijas = ID_FamiliasHijas.Select(x => FamiliaRepository.Current.GetOne(x));

                //Lo mismo hago con las patentes, pegandole al repositorio de patentes
                var Patentes = PatenteRepository.Current.GetAll(x => ID_Patentes.Contains(x.ID_Patente));

                //Teniendo esto, ya puedo rellenar mi lista de privilegios de la familia
                privilegios.AddRange(FamiliasHijas);
                privilegios.AddRange(Patentes);
            }

            return new Domain.Security.Familia(Entity.Nombre, Entity.ID_Familia, privilegios);
        }
        public Models.Familia Adapt(Domain.Security.Familia Obj)
        {
            return new Models.Familia()
            {
                ID_Familia = Obj.ID_Familia,
                Nombre = Obj.Nombre
            };
        }
    }
}
