using DAL.Contracts;
using DAL.Factories;
using Domain;
using SL.BLL.Services;
using SL.Domain;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// Brinda servicio de respaldo de datos para determinado usuario, exportando la información serializada
    /// en formato binario.
    /// También permite la restauración de los datos de un usuario a partir de un respaldo dado (eliminando
    /// en el proceso todos los datos anteriores del usuario restaurado).
    /// </summary>
    public static class BackupService
    {
        static IGeneralRepository general_repository = Factory.Current.GeneralRepository;

        internal static void GenerateScheduledBackup(Usuario usuario)
        {
            string path = AppData.Config.BackupPath;

            string new_filename = $"{Path.GetFileNameWithoutExtension(path)} {DateTime.Now.ToString("yyyy-MM-dd")}{Path.GetExtension(path)}";

            string new_path = Path.Combine(GetBackupDirectory(usuario.Username), new_filename);

            //Ahora debo chequear que no haya un backup con mismo nombre
            if (File.Exists(new_path))
            {
                string temp_path = null;
                int count = 0;
                do
                {
                    count++;
                    temp_path = Path.Combine(Path.GetDirectoryName(new_path), $"{Path.GetFileNameWithoutExtension(new_path)} ({count}){Path.GetExtension(new_path)}");
                } while (File.Exists(temp_path));
                new_path = temp_path;
            }

            GenerateBackup(usuario, new_path);
        }
        public static void GenerateBackup(Usuario usuario, string path)
        {
            try
            {
                LogService.Log($"Creación de respaldo (comienzo de proceso)", LogService.LogSeverity.Info);

                var backup = new Backup
                    (
                        CuentaService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        TransaccionService.Current.GetAll(x => x.Cuenta.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        PlanificacionService.Current.GetAll(x => x.Cuenta.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        PlantillaTransaccionService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        CaracteristicaService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        RecordatorioService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        PresupuestoService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        NotificacionService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        ExpresionService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        VariableService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        LapsoService.Current.GetAll(x => x.Usuario.ID_Usuario == usuario.ID_Usuario).ToList(),
                        FrecuenciaInicioService.Current.GetAll(x => x.ID_Usuario == usuario.ID_Usuario).ToList()
                    );

                SerializationService.Binary.Store(backup, path);

                LogService.Log($"Creación de respaldo (fin de proceso)", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(BackupService));
                throw;
            }
        }
        public static void RestoreFromBackup(Usuario usuario, string path)
        {
            try
            {
                LogService.Log($"Restauración desde respaldo (comienzo de proceso)", LogService.LogSeverity.Info);

                //Me traigo el backup desde el path correspondiente
                var backup = SerializationService.Binary.Retrieve<Backup>(path);

                //Reemplazo las entidades relacionadas a cada entidad por las que se encuentran en las listas
                ReemplazarFKs(backup, usuario);

                //Reemplazo PKs de todas las entidades por nuevas
                ReemplazarPKs(backup);

                //Ahora debo eliminar todo lo que pertenezca al usuario correspondiente antes de ingresar lo nuevo
                VaciarUsuario(usuario);

                //Finalmente, cargo todo lo que se encuentra en el backup, al usuario correspondiente
                CargarUsuario(backup);

                LogService.Log($"Restauración desde respaldo (fin de proceso)", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(BackupService));
                throw;
            }
        }
        private static void ReemplazarFKs(Backup bkp, Usuario usuario)
        {
            bkp.Cuentas.ForEach(x => x.Usuario = usuario);

            bkp.Transacciones.ForEach(x => {
                x.Cuenta = bkp.Cuentas.Where(y => y.ID_Cuenta == x.Cuenta.ID_Cuenta).First();
                x.Categoria = bkp.Caracteristicas.Where(y => y.ID_Caracteristica == x.Categoria?.ID_Caracteristica).FirstOrDefault();
                x.Etiquetas = bkp.Caracteristicas.Where(y => x.Etiquetas.Select(z => z.ID_Caracteristica).Contains(y.ID_Caracteristica)).ToList();
                x.MontoExpresion = bkp.Expresiones.Where(y => y.ID_Expresion == x.MontoExpresion.ID_Expresion).FirstOrDefault();
            });

            bkp.Planificaciones.ForEach(x => {
                x.Cuenta = bkp.Cuentas.Where(y => y.ID_Cuenta == x.Cuenta.ID_Cuenta).First();
                x.Categoria = bkp.Caracteristicas.Where(y => y.ID_Caracteristica == x.Categoria?.ID_Caracteristica).FirstOrDefault();
                x.Etiquetas = bkp.Caracteristicas.Where(y => x.Etiquetas.Select(z => z.ID_Caracteristica).Contains(y.ID_Caracteristica)).ToList();
                x.MontoExpresion = bkp.Expresiones.Where(y => y.ID_Expresion == x.MontoExpresion.ID_Expresion).FirstOrDefault();
                x.FrecuenciaInicio = bkp.FrecuenciasInicios.Where(y => y.ID_FrecuenciaInicio == x.FrecuenciaInicio.ID_FrecuenciaInicio).First();
                x.RecordatorioLigado = bkp.Recordatorios.Where(y => y.ID_Recordatorio == x.RecordatorioLigado?.ID_Recordatorio).FirstOrDefault();
            });

            bkp.Plantillas.ForEach(x => {
                x.Usuario = usuario;
                x.Categoria = bkp.Caracteristicas.Where(y => y.ID_Caracteristica == x.Categoria?.ID_Caracteristica).FirstOrDefault();
                x.Etiquetas = bkp.Caracteristicas.Where(y => x.Etiquetas.Select(z => z.ID_Caracteristica).Contains(y.ID_Caracteristica)).ToList();
                x.MontoExpresion = bkp.Expresiones.Where(y => y.ID_Expresion == x.MontoExpresion?.ID_Expresion).FirstOrDefault();
            });

            bkp.Caracteristicas.ForEach(x => x.Usuario = usuario);

            bkp.Recordatorios.ForEach(x => {
                x.Usuario = usuario;
                x.FrecuenciaInicio = bkp.FrecuenciasInicios.Where(y => y.ID_FrecuenciaInicio == x.FrecuenciaInicio.ID_FrecuenciaInicio).First();
            });

            bkp.Presupuestos.ForEach(x => {
                x.Usuario = usuario;
                x.LapsoPresupuesto = bkp.FrecuenciasInicios.Where(y => y.ID_FrecuenciaInicio == x.LapsoPresupuesto?.ID_FrecuenciaInicio).FirstOrDefault();
                x.VariableSupervisada = bkp.Variables.Where(y => y.ID_Variable == x.VariableSupervisada.ID_Variable).First();
                x.CondicionExpresion = bkp.Expresiones.Where(y => y.ID_Expresion == x.CondicionExpresion.ID_Expresion).First();
            });

            bkp.Notificaciones.ForEach(x => {
                x.Usuario = usuario;
                x.Presupuesto = bkp.Presupuestos.Where(y => y.ID_Presupuesto == x.Presupuesto?.ID_Presupuesto).FirstOrDefault();
                x.Recordatorio = bkp.Recordatorios.Where(y => y.ID_Recordatorio == x.Recordatorio?.ID_Recordatorio).FirstOrDefault();
            });

            bkp.Expresiones.ForEach(x => {
                x.Usuario = usuario;
                x.Variables = bkp.Variables.Where(y => x.Variables.Select(z => z.ID_Variable).Contains(y.ID_Variable)).ToList();
            });

            bkp.Variables.ForEach(x => {
                x.Usuario = usuario;
                x.Cuenta = bkp.Cuentas.Where(y => y.ID_Cuenta == x.Cuenta?.ID_Cuenta).FirstOrDefault();
                x.Categoria = bkp.Caracteristicas.Where(y => y.ID_Caracteristica == x.Categoria?.ID_Caracteristica).FirstOrDefault();
                x.Etiqueta = bkp.Caracteristicas.Where(y => y.ID_Caracteristica == x.Etiqueta?.ID_Caracteristica).FirstOrDefault();
                x.Transaccion = bkp.Transacciones.Where(y => y.ID_Transaccion == x.Transaccion?.ID_Transaccion).FirstOrDefault();
                x.Planificacion = bkp.Planificaciones.Where(y => y.ID_Planificacion == x.Planificacion?.ID_Planificacion).FirstOrDefault();
                x.PlantillaTransaccion = bkp.Plantillas.Where(y => y.ID_PlantillaTransaccion == x.PlantillaTransaccion?.ID_PlantillaTransaccion).FirstOrDefault();
                x.Lapso = bkp.Lapsos.Where(y => y.ID_Lapso == x.Lapso?.ID_Lapso).FirstOrDefault();
            });

            bkp.FrecuenciasInicios.ForEach(x => x.ID_Usuario = usuario.ID_Usuario);

            bkp.Lapsos.ForEach(x => x.Usuario = usuario);
        }
        private static void ReemplazarPKs(Backup bkp)
        {
            bkp.Cuentas.ForEach(x => x.ID_Cuenta = Guid.NewGuid());
            bkp.Transacciones.ForEach(x => x.ID_Transaccion = Guid.NewGuid());
            bkp.Planificaciones.ForEach(x => x.ID_Planificacion = Guid.NewGuid());
            bkp.Plantillas.ForEach(x => x.ID_PlantillaTransaccion = Guid.NewGuid());
            bkp.Caracteristicas.ForEach(x => x.ID_Caracteristica = Guid.NewGuid());
            bkp.Recordatorios.ForEach(x => x.ID_Recordatorio = Guid.NewGuid());
            bkp.Presupuestos.ForEach(x => x.ID_Presupuesto = Guid.NewGuid());
            bkp.Notificaciones.ForEach(x => x.ID_Notificacion = Guid.NewGuid());
            bkp.Expresiones.ForEach(x => x.ID_Expresion = Guid.NewGuid());
            bkp.Variables.ForEach(x => x.ID_Variable = Guid.NewGuid());
            bkp.FrecuenciasInicios.ForEach(x => x.ID_FrecuenciaInicio = Guid.NewGuid());
            bkp.Lapsos.ForEach(x => x.ID_Lapso = Guid.NewGuid());
        }
        private static void VaciarUsuario(Usuario usuario)
        {
            LogService.Log($"Restauración desde respaldo - vaciar usuario (comienzo de proceso)", LogService.LogSeverity.Info);
            general_repository.RemoveAll(usuario);
            LogService.Log($"Restauración desde respaldo - vaciar usuario (fin de proceso)", LogService.LogSeverity.Info);
        }
        private static void CargarUsuario(Backup bkp)
        {
            LogService.Log($"Restauración desde respaldo - cargar usuario (comienzo de proceso)", LogService.LogSeverity.Info);
            
            bkp.Cuentas.ForEach(x => Factory.Current.CuentaRepository.AddOrUpdate(x));
            bkp.Transacciones.ForEach(x => Factory.Current.TransaccionRepository.AddOrUpdate(x));
            bkp.Planificaciones.ForEach(x => Factory.Current.PlanificacionRepository.AddOrUpdate(x));
            bkp.Plantillas.ForEach(x => Factory.Current.PlantillaTransaccionRepository.AddOrUpdate(x));
            bkp.Caracteristicas.ForEach(x => Factory.Current.CaracteristicaRepository.AddOrUpdate(x));
            bkp.Recordatorios.ForEach(x => Factory.Current.RecordatorioRepository.AddOrUpdate(x));
            bkp.Presupuestos.ForEach(x => Factory.Current.PresupuestoRepository.AddOrUpdate(x));
            bkp.Notificaciones.ForEach(x => Factory.Current.NotificacionRepository.AddOrUpdate(x));
            bkp.Expresiones.ForEach(x => Factory.Current.ExpresionRepository.AddOrUpdate(x));
            bkp.Variables.ForEach(x => Factory.Current.VariableRepository.AddOrUpdate(x));
            bkp.FrecuenciasInicios.ForEach(x => SL.DAL.Factories.Factory.Current.FrecuenciaInicioRepository.AddOrUpdate(x));
            bkp.Lapsos.ForEach(x => SL.DAL.Factories.Factory.Current.LapsoRepository.AddOrUpdate(x));
            
            LogService.Log($"Restauración desde respaldo - cargar usuario (fin de proceso)", LogService.LogSeverity.Info);
        }
        internal static bool BackupEstaAlLimite(Usuario usuario)
        {
            bool hay_limite = AppData.CurrentUser.Configuracion.LimiteRespaldos;
            int? respaldar_limite = AppData.CurrentUser.Configuracion.CantidadMaximaRespaldosValor;

            if (!hay_limite || respaldar_limite == null) return false;

            var files = Directory.GetFiles(GetBackupDirectory(usuario.Username), "*.bin", SearchOption.TopDirectoryOnly);

            if (files.Count() < respaldar_limite) return false;
            else return true;
        }
        internal static void DeleteOldestBackup(Usuario usuario)
        {
            var info = new DirectoryInfo(GetBackupDirectory(usuario.Username));
            var files = info.GetFiles("*.bin");
            var oldest = files.OrderBy(x => x.LastWriteTime).FirstOrDefault();

            if (oldest != null) File.Delete(oldest.FullName);
        }
        private static string GetBackupDirectory(string username, bool create_directory = true)
        {
            string path = AppData.Config.BackupPath;
            string directory = Path.GetDirectoryName(path);

            string sub_directory = Path.Combine(directory, username);

            if (create_directory) Directory.CreateDirectory(sub_directory);

            return sub_directory;
        }
        public static void UpdateBackupDirectoryName(Usuario usuario, string old_username)
        {
            string old_directory = GetBackupDirectory(old_username);
            string new_directory = GetBackupDirectory(usuario.Username, create_directory: false);
            Directory.Move(old_directory, new_directory);
        }

        /// <summary>
        /// Bloque de datos para la generación o restauración de un respaldo.
        /// </summary>
        [Serializable]
        private class Backup
        {
            public List<Cuenta> Cuentas;
            public List<Transaccion> Transacciones;
            public List<Planificacion> Planificaciones;
            public List<PlantillaTransaccion> Plantillas;
            public List<Caracteristica> Caracteristicas;
            public List<Recordatorio> Recordatorios;
            public List<Presupuesto> Presupuestos;
            public List<Notificacion> Notificaciones;
            public List<Expresion> Expresiones;
            public List<Variable> Variables;
            public List<Lapso> Lapsos;
            public List<FrecuenciaInicio> FrecuenciasInicios;

            public Backup(List<Cuenta> cuentas, List<Transaccion> transacciones, List<Planificacion> planificaciones, List<PlantillaTransaccion> plantillas, List<Caracteristica> caracteristicas, List<Recordatorio> recordatorios, List<Presupuesto> presupuestos, List<Notificacion> notificaciones, List<Expresion> expresiones, List<Variable> variables, List<Lapso> lapsos, List<FrecuenciaInicio> frecuenciasInicios)
            {
                Cuentas = cuentas;
                Transacciones = transacciones;
                Planificaciones = planificaciones;
                Plantillas = plantillas;
                Caracteristicas = caracteristicas;
                Recordatorios = recordatorios;
                Presupuestos = presupuestos;
                Notificaciones = notificaciones;
                Expresiones = expresiones;
                Variables = variables;
                Lapsos = lapsos;
                FrecuenciasInicios = frecuenciasInicios;
            }
        }
    }

}
