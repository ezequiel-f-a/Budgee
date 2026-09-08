using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Drawing;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Característica.
    /// </summary>
    internal class CaracteristicaAdapter : IGenericAdapter<Domain.Caracteristica, Models.Caracteristica>
    {
        #region Singleton
        private readonly static CaracteristicaAdapter _instance;
        public static CaracteristicaAdapter Current { get { return _instance; } }
        static CaracteristicaAdapter() { _instance = new CaracteristicaAdapter(); }
        private CaracteristicaAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Caracteristica Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Caracteristica Adapt(Models.Caracteristica Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            Color? color = null;
            if (Entity.Color != null) color = ConversionService.ColorFromHexColor(Entity.Color);

            return new Domain.Caracteristica(
                Entity.ID_Caracteristica,
                Entity.Nombre,
                (Tipo_Caracteristica)Entity.Tipo_Caracteristica.ToEnum(new Tipo_Caracteristica()),
                color,
                usuario,
                Entity.Estado
                );
        }
        public Models.Caracteristica Adapt(Domain.Caracteristica Obj)
        {
            string color = null;
            if (Obj.Color != null) color = ((Color)Obj.Color).ToHexColor();

            return new Models.Caracteristica()
            {
                ID_Caracteristica = Obj.ID_Caracteristica,
                Nombre = Obj.Nombre,
                Tipo_Caracteristica = Obj.Tipo_Caracteristica.ToString(),
                Color = color,
                ID_Usuario = Obj.Usuario.ID_Usuario,
                Estado = Obj.Estado
            };
        }
    }
}
