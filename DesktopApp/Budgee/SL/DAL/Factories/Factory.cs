using SL.DAL.Contracts;
using SL.Services;
using System;

namespace SL.DAL.Factories
{
    /// <summary>
    /// Factory que centraliza el acceso a datos, abstrayendo de que forma se realiza el acceso a datos.
    /// </summary>
    public class Factory
    {
        #region Singleton
        private readonly static Factory _instance;
        public static Factory Current { get { return _instance; } }
        static Factory() { _instance = new Factory(); }
        private Factory()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public IGenericRepository<Domain.Lapso> LapsoRepository { get { return GetRepository(nameof(LapsoRepository)); } }
        public IGenericRepository<Domain.FrecuenciaInicio> FrecuenciaInicioRepository { get { return GetRepository(nameof(FrecuenciaInicioRepository)); } }
        public IGenericRepository<Domain.Security.Usuario> UsuarioRepository { get { return GetRepository(nameof(UsuarioRepository)); } }
        public IGenericRepository<Domain.Security.Familia> FamiliaRepository { get { return GetRepository(nameof(FamiliaRepository)); } }
        public IGenericRepository<Domain.Security.Patente> PatenteRepository { get { return GetRepository(nameof(PatenteRepository)); } }
        public IGenericRepository<Domain.Security.SesionTrack> SesionTrackRepository { get { return GetRepository(nameof(SesionTrackRepository)); } }

        private dynamic GetRepository(string repository)
        {
            string basepath = AppData.Config.RepositoriesSL;

            var repo =
                Type.GetType($"{basepath}.{repository}").
                GetProperty("Current").
                GetValue(null);

            return repo;
        }
    }
}
