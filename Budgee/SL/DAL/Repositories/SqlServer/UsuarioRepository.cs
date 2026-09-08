using SL.DAL.Contracts;
using SL.DAL.Repositories.SqlServer.Adapters;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer
{
    /// <summary>
    /// Repositorio SQL Server de Usuario.
    /// </summary>
    internal class UsuarioRepository : IGenericRepository<Domain.Security.Usuario>
    {
        #region Singleton
        private readonly static UsuarioRepository _instance;
        public static UsuarioRepository Current { get { return _instance; } }
        static UsuarioRepository() { _instance = new UsuarioRepository(); }
        private UsuarioRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Usuario GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Usuario.AsNoTracking();
                    return UsuarioAdapter.Current.Adapt(
                        db.Usuario.Where(x => x.ID_Usuario == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Usuario> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Usuario.AsNoTracking();
                    return db.Usuario.ToList().Select(x => UsuarioAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Usuario> GetAll(Func<Domain.Security.Usuario, bool> filter)
        {
            try
            {
                return GetAll().Where(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Add(Domain.Security.Usuario obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Usuario.Add(UsuarioAdapter.Current.Adapt(obj));

                    if (obj.Configuracion.RespaldarFrecuencia != null)
                        db.FrecuenciaInicio.AddOrUpdate(FrecuenciaInicioAdapter.Current.Adapt(obj.Configuracion.RespaldarFrecuencia));

                    db.Configuracion_Usuario.Add(UsuarioAdapter.Current.AdaptConfiguracionUsuario(obj.Configuracion));

                    //Agrego relaciones de Patentes y Familias
                    AgregarRelacionesPrivilegiosNuevos(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Security.Usuario obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    if (obj.Configuracion.RespaldarFrecuencia != null)
                        FrecuenciaInicioRepository.Current.AddOrUpdate(obj.Configuracion.RespaldarFrecuencia);

                    //Actualizo Config de usuario
                    db.Configuracion_Usuario.AddOrUpdate(UsuarioAdapter.Current.AdaptConfiguracionUsuario(obj.Configuracion));

                    var obj_from_db = db.Usuario.Single(x => x.ID_Usuario == obj.ID_Usuario);
                    db.Entry(obj_from_db).CurrentValues.SetValues(UsuarioAdapter.Current.Adapt(obj));

                    //Actualizo Patentes y Familias
                    ActualizarRelacionesPrivilegios(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Security.Usuario obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    if (obj.Configuracion.RespaldarFrecuencia != null)
                        FrecuenciaInicioRepository.Current.AddOrUpdate(obj.Configuracion.RespaldarFrecuencia);

                    db.Configuracion_Usuario.AddOrUpdate(UsuarioAdapter.Current.AdaptConfiguracionUsuario(obj.Configuracion));

                    db.Usuario.AddOrUpdate(UsuarioAdapter.Current.Adapt(obj));

                    ActualizarRelacionesPrivilegios(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Security.Usuario obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    //Borro relaciones intermedias
                    //Patentes, Familias
                    EliminarRelacionesPrivilegiosViejos(obj, db);

                    //Borro composiciones
                    //Config de Usuario, SesionTracks, Cuentas, Caracteristicas, Plantillas, Presupuestos, Recordatorios, Notificaciones, Expresiones, Variables

                    var config = db.Configuracion_Usuario.Where(x => x.ID_Configuracion_Usuario == obj.Configuracion.ID_ConfiguracionUsuario).ToList();
                    db.Configuracion_Usuario.RemoveRange(config);

                    SesionTrackRepository.Current.RemoveAll(x => x.Usuario.ID_Usuario == obj.ID_Usuario);

                    //FALTA -> no puedo referenciar BLL correspondiente

                    //Finalmente puedo borrar el usuario
                    var obj_from_db = db.Usuario.Single(x => x.ID_Usuario == obj.ID_Usuario);
                    db.Usuario.Remove(obj_from_db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Security.Usuario, bool> filter)
        {
            try
            {
                foreach (var item in GetAll(filter))
                    Remove(item);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void SetPrivilegios(Domain.Security.Usuario obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Usuario_Familia.AsNoTracking();
                    db.Usuario_Patente.AsNoTracking();
                    var ID_Familias = db.Usuario_Familia.Where(x => x.ID_Usuario == obj.ID_Usuario).ToList().Select(x => x.ID_Familia);
                    var ID_Patentes = db.Usuario_Patente.Where(x => x.ID_Usuario == obj.ID_Usuario).ToList().Select(x => x.ID_Patente);

                    var Familias = ID_Familias.Select(x => FamiliaRepository.Current.GetOne(x));
                    var Patentes = PatenteRepository.Current.GetAll(x => ID_Patentes.Contains(x.ID_Patente)).ToList();

                    obj.Privilegios.Clear();
                    obj.Privilegios.AddRange(Familias);
                    obj.Privilegios.AddRange(Patentes);
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        private void AgregarRelacionesPrivilegiosNuevos(Domain.Security.Usuario obj, Models.BudgeeSLEntities db)
        {
            try
            {
                var NEW_FamiliasHijas = obj.Privilegios.Where(x => x is Domain.Security.Familia).Cast<Domain.Security.Familia>();
                var NEW_Patentes = obj.Privilegios.Where(x => x is Domain.Security.Patente).Cast<Domain.Security.Patente>();

                foreach (var familia_new in NEW_FamiliasHijas)
                {
                    FamiliaRepository.Current.AddOrUpdate(familia_new);

                    db.Usuario_Familia.Add(new Models.Usuario_Familia()
                    {
                        ID_Usuario = obj.ID_Usuario,
                        ID_Familia = familia_new.ID_Familia
                    });
                }
                foreach (var patente_new in NEW_Patentes)
                {
                    PatenteRepository.Current.AddOrUpdate(patente_new);

                    db.Usuario_Patente.Add(new Models.Usuario_Patente()
                    {
                        ID_Usuario = obj.ID_Usuario,
                        ID_Patente = patente_new.ID_Patente
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void EliminarRelacionesPrivilegiosViejos(Domain.Security.Usuario obj, Models.BudgeeSLEntities db)
        {
            try
            {
                var OLD_FamiliasHijas = db.Usuario_Familia.Where(x => x.ID_Usuario == obj.ID_Usuario);
                var OLD_Patentes = db.Usuario_Patente.Where(x => x.ID_Usuario == obj.ID_Usuario);

                foreach (var familia_old in OLD_FamiliasHijas)
                    db.Usuario_Familia.Remove(familia_old);

                foreach (var patente_old in OLD_Patentes)
                    db.Usuario_Patente.Remove(patente_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesPrivilegios(Domain.Security.Usuario obj, Models.BudgeeSLEntities db)
        {
            EliminarRelacionesPrivilegiosViejos(obj, db);
            AgregarRelacionesPrivilegiosNuevos(obj, db);
        }
    }
}
