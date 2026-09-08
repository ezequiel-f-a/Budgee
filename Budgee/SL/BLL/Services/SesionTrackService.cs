using Enums;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.DAL.Factories;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.BLL.Services
{
    /// <summary>
    /// Servicio del negocio de SesionTrack.
    /// </summary>
    public class SesionTrackService : IGenericBusinessLogic<Domain.Security.SesionTrack>
    {
        #region Singleton
        private readonly static SesionTrackService _instance;
        public static SesionTrackService Current { get { return _instance; } }
        static SesionTrackService() { _instance = new SesionTrackService(); }
        private SesionTrackService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Security.SesionTrack> repository = Factory.Current.SesionTrackRepository;

        public SesionTrack GetOne(Guid ID)
        {
            try
            {
                return repository.GetOne(ID);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<SesionTrack> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<SesionTrack> GetAll(Func<SesionTrack, bool> filter)
        {
            try
            {
                return repository.GetAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Add(SesionTrack obj)
        {
            try
            {
                repository.Add(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(SesionTrack obj)
        {
            try
            {
                repository.Update(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(SesionTrack obj)
        {
            try
            {
                repository.AddOrUpdate(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(SesionTrack obj)
        {
            try
            {
                repository.Remove(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<SesionTrack, bool> filter)
        {
            try
            {
                repository.RemoveAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void TrackSesion(Usuario usuario, Tipo_Track tipoTrack)
        {
            try
            {
                Add(new SesionTrack(Guid.NewGuid(), tipoTrack, DateTime.Now, usuario));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void TrackSesion(Usuario usuario, Tipo_Track tipoTrack, DateTime date)
        {
            try
            {
                Add(new SesionTrack(Guid.NewGuid(), tipoTrack, date, usuario));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public SesionTrack GetUltimoTrackSesion(Usuario usuario)
        {
            try
            {
                var tracks = GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario);

                return tracks.OrderByDescending(x => x.FechaProceso).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public SesionTrack GetUltimoTrackSesion(Usuario usuario, Tipo_Track tipoTrack)
        {
            try
            {
                var tracks = GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario
                && x.TipoTrack == tipoTrack);

                return tracks.OrderByDescending(x => x.FechaProceso).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public SesionTrack GetUltimoTrackSesionAnterior(Usuario usuario)
        {
            try
            {
                var tracks = GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario);
                
                //Si el usuario ya inicio sesion, podemos saber que cualquier track anterior an ultimo inicio de sesion es válido
                if(AppData.CurrentUser != null && AppData.CurrentUser.ID_Usuario == usuario.ID_Usuario)
                {
                    SesionTrack ultimo_inicio_sesion = tracks.Where(x => x.TipoTrack == Tipo_Track.Inicio_Sesion)
                        .OrderByDescending(x => x.FechaProceso)
                        .FirstOrDefault();

                    tracks = tracks.Where(x=>
                        x.FechaProceso < ultimo_inicio_sesion?.FechaProceso);
                }
                else //Caso contrario, deberemos considerar la fecha y hora actual como el punto de filtro (en teoría, todos los registros)
                {
                    tracks = tracks.Where(x =>
                        x.FechaProceso < DateTime.Now);
                }

                return tracks.OrderByDescending(x => x.FechaProceso).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public SesionTrack GetUltimoTrackSesionAnterior(Usuario usuario, Tipo_Track tipoTrack)
        {
            try
            {
                var tracks = GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario);

                //Si el usuario ya inicio sesion, podemos saber que cualquier track anterior an ultimo inicio de sesion es válido
                if (AppData.CurrentUser != null && AppData.CurrentUser.ID_Usuario == usuario.ID_Usuario)
                {
                    tracks = tracks.Where(x =>
                        x.FechaProceso < GetUltimoTrackSesion(usuario, Tipo_Track.Inicio_Sesion)?.FechaProceso);
                }
                else //Caso contrario, deberemos considerar la fecha y hora actual como el punto de filtro (en teoría, todos los registros)
                {
                    tracks = tracks.Where(x =>
                        x.FechaProceso < DateTime.Now);
                }

                //Ahora filtramos por el tipo de track
                tracks = tracks.Where(x => x.TipoTrack == tipoTrack);

                return tracks.OrderByDescending(x => x.FechaProceso).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void CleanOldSesionTrack(Usuario usuario)
        {
            try
            {
                var tracks = repository.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).OrderByDescending(x => x.FechaProceso);

                var tracks_to_clean = new List<SesionTrack>();

                int inicio_sesion_count = 0;
                int cierre_sesion_count = 0;
                int bg_track_count = 0;

                foreach (var track in tracks)
                {
                    if (track.TipoTrack == Tipo_Track.Inicio_Sesion)
                    {
                        inicio_sesion_count++;
                        if (inicio_sesion_count > 2) tracks_to_clean.Add(track);
                    }
                    else if (track.TipoTrack == Tipo_Track.Cierre_Sesion)
                    {
                        cierre_sesion_count++;
                        if (cierre_sesion_count > 1) tracks_to_clean.Add(track);
                    }
                    else if (track.TipoTrack == Tipo_Track.Background_Track_Sesion)
                    {
                        bg_track_count++;
                        if (bg_track_count > 1) tracks_to_clean.Add(track);
                    }
                }

                repository.RemoveAll(x => tracks_to_clean.Select(y => y.ID_SesionTrack).Contains(x.ID_SesionTrack));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
