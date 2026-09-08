using Enums;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SL.Services
{
    /// <summary>
    /// Brinda un servicio de traducción entre los lenguajes disponibles para un conjunto de palabras/oraciones específicas.
    /// </summary>
    public static class LanguageService
    {
        static Dictionary<Idioma, Language> Languages = new Dictionary<Idioma, Language>();
        public static IEnumerable<string> Translate(this IEnumerable<string> Texts, bool intelligent_translation = true)
        {
            return Texts.Select(x => x.Translate(intelligent_translation));
        }
        public static string[] Translate(this string[] Texts, bool intelligent_translation = true)
        {
            return Texts.Select(x => x.Translate(intelligent_translation)).ToArray();
        }
        public static string Translate(this string Text, bool intelligent_translation = true)
        {
            try
            {
                string Translation = null;

                if (Languages.Count == 0) RetrieveLanguages();

                Func<Translation, bool> translation_format = (intelligent_translation) ? GetIntelligentTranslationFormat(Text) : x => x.Key == Text;
                Translation = Languages[AppData.CurrentLanguage]?.translations.Where(translation_format).FirstOrDefault()?.Translated;

                if (intelligent_translation) Translation = GetIntelligentTranslationResult(Text, Translation);

                return Translation ?? Text;
            }
            catch (Exception ex)
            {
                if(!(ex is IndexOutOfRangeException))
                    LogService.Log(ex.GetFullMessage(), LogService.LogSeverity.Error);
                return Text;
            }
        }
        public static string Untranslate(this string Translated)
        {
            try
            {
                string Original = null;

                if (Languages.Count == 0) RetrieveLanguages();

                Original = Languages[AppData.CurrentLanguage].translations.Where(x => x.Translated == Translated).FirstOrDefault()?.Key;

                return Original ?? Translated;
            }
            catch
            {
                return Translated;
            }
        }
        private static Func<Translation, bool> GetIntelligentTranslationFormat(string Text)
        {
            return
                x => x.Key == Text
            || (Text[Text.Length - 1] == ':' && x.Key == Text.Substring(0, Text.Length - 1))
            || (Text.Length >= 3 && Text.Substring(Text.Length - 3) == "..." && x.Key == Text.Substring(0, Text.Length - 3));
        }
        private static string GetIntelligentTranslationResult(string Text, string Translation)
        {
            if (Translation == null) return null;

            try
            {
                if (Text[Text.Length - 1] == ':' && Translation[Translation.Length - 1] != ':')
                    return Translation + ":";
                else if (Text.Length >= 3 && Translation.Length >= 3 && Text.Substring(Text.Length - 3) == "..." && Translation.Substring(Translation.Length - 3) != "...")
                    return Translation + "...";
                else return Translation;
            }
            catch
            {
                return Translation;
            }
        }
        public static void RetrieveLanguages()
        {
            foreach (Idioma idioma in Enum.GetValues(typeof(Idioma)))
            {
                string path = AppData.Config.Languages[idioma];

                if (!File.Exists(path)) 
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    RestoreLanguages();
                } 

                Language language = SerializationService.Json.Retrieve<Language>(path);
                Languages.Add(idioma, language);
            }
        }
        public static void RestoreLanguages()
        {
            Restore_Español();
            Restore_English();
        }
        public static void Restore_Español()
        {
            Language español = new Language();

            español.translations = new List<Translation>()
            {
                new Translation("Login","Inicio de Sesión"),
                new Translation("TipoOperacion","Tipo Operación"),
                new Translation("MontoExpresion","Monto"),
                new Translation("Informacion","Información"),
                new Translation("Fecha_Emision","Fecha Emisión"),
                new Translation("Descripcion","Descripción"),
                new Translation("Categoria","Categoría"),
                new Translation("FrecuenciaInicio","Frecuencia e Inicio"),
                new Translation("QuitarAlConcluir","Quitar Al Concluir"),
                new Translation("VariableSupervisada","Variable Supervisada"),
                new Translation("OperadorRelacional","..."),
                new Translation("CondicionExpresion","Condición"),
                new Translation("LapsoPresupuesto","Lapso Presupuesto"),
                new Translation("CuandoChequear","Cuando Chequear"),
                new Translation("Balance_Potencial","Balance Potencial"),
                new Translation("Preview Resultado","Previsualizar Resultado"),
            };

            SerializationService.Json.Store(español, AppData.Config.Languages[Idioma.Español]);
        }
        public static void Restore_English()
        {
            Language english = new Language();
            
            english.translations = new List<Translation>()
            {
                #region Entidades comunes
                new Translation("Transacción","Transaction"),
                new Translation("Transacciones","Transactions"),
                new Translation("Planificación","Planification"),
                new Translation("Plantilla","Template"),
                new Translation("Plantillas","Templates"),
                new Translation("Presupuesto","Budget"),
                new Translation("Presupuestos","Budgets"),
                new Translation("Recordatorio","Reminder"),
                new Translation("Recordatorios","Reminders"),
                new Translation("Cuenta","Account"),
                new Translation("Cuentas","Accounts"),
                new Translation("Categoria","Category"),
                new Translation("Categoría","Category"),
                new Translation("Categorías","Categories"),
                new Translation("Etiqueta","Tag"),
                new Translation("Etiquetas","Tags"),
                new Translation("Usuario","User"),
                new Translation("Usuarios","Users"),
                new Translation("Perfiles","Profiles"),
                new Translation("Permisos","Permissions"),
                new Translation("Estadística","Statistic"),
                new Translation("Estadísticas","Statistics"),
                new Translation("Notificaciones","Notifications"),
                new Translation("Configuración","Configuration"),
                #endregion
                #region Login
                new Translation("Contraseña","Password"),
                new Translation("Mantener Sesión Iniciada","Keep Logged In"),
                new Translation("Mostrar Contraseña","Show Password"),
                new Translation("Crear Usuario","Create User"),
                new Translation("Iniciar Sesión","Log In"),
                new Translation("Nuevo Nombre","New Name"),
                new Translation("Confirmar Contraseña Actual","Confirm Current Password"),
                new Translation("Nueva Contraseña","New Password"),
                #endregion
                #region Menú de ayuda
                new Translation("Ayuda","Help"),
                new Translation("Manual de Ayuda [F1]","Help Manual [F1]"),
                new Translation("Acerca de Budgee","About Budgee"),
                #endregion
                #region Menú de administrador
                new Translation("Administrador","Administrator"),
                new Translation("Administrar Usuarios","Administrate Users"),
                new Translation("Administrar Perfiles","Administrate Profiles"),
                new Translation("Restablecer Idiomas","Restore Languages"),
                new Translation("Perfiles o Permisos Relacionados","Related Profiles or Permissions"),
                #endregion
                #region Menú de idiomas
                new Translation("Idioma","Language"),
                new Translation("Datos","Data"),
                #endregion
                #region Menú de respaldo
                new Translation("Exportar Respaldo","Export Backup"),
                new Translation("Restaurar Desde Respaldo","Restore From Backup"),
                #endregion
                #region Menú de sesion
                new Translation("Sesión","Session"),
                new Translation("Configuración","Configuration"),
                new Translation("Cerrar Sesión","Log Out"),
                new Translation("Salir de la Aplicación","Quit Application"),
                #endregion
                #region Títulos de forms
                new Translation("Seleccionar Categoría","Select Category"),
                new Translation("Seleccionar Cuenta","Select Account"),
                new Translation("Seleccionar Etiqueta","Select Tag"),
                new Translation("Seleccionar Perfil","Select Profile"),
                new Translation("Seleccionar Permiso","Select Permission"),
                new Translation("Seleccionar Planificación","Select Planification"),
                new Translation("Seleccionar Plantilla","Select Template"),
                new Translation("Seleccionar Presupuesto","Select Budget"),
                new Translation("Seleccionar Transacción","Select Transaction"),
                new Translation("Talonario de Categoría","Category Form"),
                new Translation("Talonario de Cuenta","Account Form"),
                new Translation("Talonario de Etiqueta","Tag Form"),
                new Translation("Talonario de Perfil","Profile Form"),
                new Translation("Talonario de Planificación","Planification Form"),
                new Translation("Talonario de Plantilla","Template Form"),
                new Translation("Talonario de Presupuesto","Budget Form"),
                new Translation("Talonario de Recordatorio","Reminder Form"),
                new Translation("Talonario de Transacción","Transaction Form"),
                new Translation("Talonario de Usuario","User Form"),
                new Translation("Establecer Expresión","Set Expression"),
                new Translation("Establecer Variable","Set Variable"),
                new Translation("Establecer Lapso","Set Span"),
                new Translation("Establecer Frecuencia e Inicio","Set Frequency & Start"),
                new Translation("Cambiar Nombre de Usuario","Change Username"),
                #endregion
                #region Títulos de TabPages
                new Translation("    Pendientes    ","    Pending    "),
                new Translation("    Concretadas    ","    Done    "),
                new Translation("    Nuevas    ","    New    "),
                new Translation("    Vistas    ","    Viewed    "),
                new Translation("    Ingresos / Egresos    ","    Income / Expenses    "),
                new Translation("    Patrimonio Neto    ","    Net Worth    "),
                new Translation("    Distribución    ","    Distribution    "),
                new Translation("    Holgura de Presupuesto    ","    Budget Looseness    "),
                #endregion
                #region Botones
                new Translation("Aceptar","Ok"),
                new Translation("Cancelar","Cancel"),
                new Translation("Confirmar","Confirm"),
                new Translation("Confirmar Contraseña","Confirm Password"),
                new Translation("Establecer","Set"),
                new Translation("Agregar","Add"),
                new Translation("Crear","Create"),
                new Translation("Eliminar","Delete"),
                new Translation("Remover","Remove"),
                new Translation("Modificar","Modify"),
                new Translation("Habilitar","Enable"),
                new Translation("Deshabilitar","Disable"),
                new Translation("Seleccionar","Select"),
                new Translation("Buscar","Search"),
                new Translation("Exportar","Export"),
                new Translation("Concretar","Done"),
                new Translation("Ver Detalles","View Details"),
                new Translation("Visto","Viewed"),
                new Translation("Visto (Todos)","Viewed (All)"),
                new Translation("Ir","Go"),
                new Translation("Aplicar Filtros","Apply Filters"),
                new Translation("Resetear Filtros","Reset Filters"),
                new Translation("Cambiar Nombre","Change Name"),
                new Translation("Cambiar Contraseña","Change Password"),
                new Translation("Borrar Usuario","Delete User"),
                new Translation("Establecer Frecuencia","Set Frequency"),
                new Translation("Agregar Perfil","Add Profile"),
                new Translation("Agregar Permiso","Add Permission"),
                new Translation("Cargar desde Plantilla","Load from Template"),
                new Translation("Guardar como Plantilla","Save as Template"),
                new Translation("Insertar en Expresión","Insert into Expression"),
                #endregion
                #region Atributos comunes
                new Translation("Descripcion","Description"),
                new Translation("Descripción","Description"),
                new Translation("Descripción Planificación","Planification Description"),
                new Translation("Descripción Plantilla","Template Description"),
                new Translation("Descripción de Transacción","Transaction Description"),
                new Translation("Descripción de Transacción Planificada","Planned Transaction Description"),
                new Translation("Nombre","Name"),
                new Translation("TipoOperacion","Operation Type"),
                new Translation("Tipo Operación","Operation Type"),
                new Translation("CondicionExpresion","Condition"),
                new Translation("Valor de Condición","Condition Value"),
                new Translation("LapsoPresupuesto","Budget Span"),
                new Translation("Lapso de Presupuesto","Budget Span"),
                new Translation("Lapso","Span"),
                new Translation("Frecuencia","Frequency"),
                new Translation("Horario","Time"),
                new Translation("Año","Year"),
                new Translation("Mes","Month"),
                new Translation("Día","Day"),
                new Translation("Fecha","Date"),
                new Translation("Fecha Desde","Date From"),
                new Translation("Fecha Hasta","Date To"),
                new Translation("Fecha Transacción","Transaction Date"),
                new Translation("Fecha Balance","Balance Date"),
                new Translation("Fecha_Emision","Date Sent"),
                new Translation("Informacion","Information"),
                new Translation("Información","Information"),
                new Translation("Procedencia","Origin"),
                new Translation("FrecuenciaInicio","Frequency and Start"),
                new Translation("Frecuencia e Inicio","Frequency and Start"),
                new Translation("Generar Recordatorio Respectivo","Generate Respective Reminder"),
                new Translation("QuitarAlConcluir","Remove Upon Completion"),
                new Translation("Quitar al Concluir","Remove Upon Completion"),
                new Translation("Ligado a Planificación","Bound to Planification"),
                new Translation("VariableSupervisada","Supervised Variable"),
                new Translation("OperadorRelacional","..."),
                new Translation("CuandoChequear","When to Check"),
                new Translation("Cuando Chequear","When to Check"),
                new Translation("Cuando Cheq.","Check When"),
                new Translation("MontoExpresion","Amount"),
                new Translation("Monto","Amount"),
                new Translation("Ingreso","Income"),
                new Translation("Egreso","Expenses"),
                new Translation("Variable","Variable"),
                new Translation("Ganancia Neta","Net Gain"),
                new Translation("Ingreso Potencial","Potential Income"),
                new Translation("Egreso Potencial","Potential Expenses"),
                new Translation("Ganancia Neta Potencial","Potential Net Gain"),
                new Translation("Balance Potencial","Potential Balance"),
                new Translation("Balance_Potencial","Potential Balance"),
                new Translation("Balance Global","Global Balance"),
                new Translation("Balance Global Potencial","Potential Global Balance"),
                new Translation("Balance Actual","Current Balance"),
                new Translation("Estado","Status"),
                new Translation("Habilitado","Enabled"),
                new Translation("Deshabilitado","Disabled"),
                new Translation("Habilitada","Enabled"),
                new Translation("Deshabilitada","Disabled"),
                new Translation("Divisa","Currency"),
                new Translation("Divisa Default","Default Currency"),
                new Translation("Admite Fondos Negativos","Accepts Negative Funds"),
                new Translation("Concretada","Done"),
                new Translation("Transacción Concretada","Done Transaction"),
                new Translation("Expresión","Expression"),
                new Translation("Preview Resultado","Result Preview"),
                new Translation("Estilo Gráfico","Graph Style"),
                new Translation("Detalle","Details"),
                new Translation("Detalles","Details"),
                new Translation("Presupuesto Seleccionado","Selected Budget"),
                new Translation("Presupuestado","Budgeted"),
                new Translation("Actual","Current"),
                new Translation("Nombre de Variable","Variable Name"),
                new Translation("Tipo de Variable","Variable Type"),
                new Translation("Mostrar","Show"),
                new Translation("En Función de","In Function of"),
                new Translation("Definicion","Definition"),
                new Translation("Definición","Definition"),
                new Translation("Valor","Value"),
                new Translation("Magnitud","Magnitude"),
                new Translation("Inicio","Start"),
                #endregion
                #region Alarmas y notificaciones
                new Translation("Establecer Notificación de Windows","Set Windows Notification"),
                new Translation("Establecer Alarma de Windows","Set Windows Alarm"),
                new Translation("Notificaciones Windows","Windows Notifications"),
                new Translation("Alarmas Windows","Windows Alarms"),
                new Translation("Notificaciones Estadísticas","Statistics Notifications"),
                new Translation("Notificaciones Presupuestos","Budget Notifications"),
                new Translation("Notificaciones Recordatorios","Reminder Notifications"),
                new Translation("Eliminar Notificaciones luego de","Delete Notifications after"),
                new Translation("Respaldar datos cada","Backup data every"),
                new Translation("Cantidad Máxima Respaldos","Maximum Backup Quantity"),
                #endregion
                #region Enums
                #region Frecuencia
                new Translation("Año(s)","Year(s)"),
                new Translation("Mes(es)","Month(s)"),
                new Translation("Semana(s)","Week(s)"),
                new Translation("Día(s)","Day(s)"),
                #endregion
                #region Tipo Lapso
                new Translation("Histórico","Historical"),
                new Translation("Este Año","This Year"),
                new Translation("Este Semestre","This Semester"),
                new Translation("Este Cuatrimestre","This Quarter"),
                new Translation("Este Trimestre","This Trimester"),
                new Translation("Este Mes","This Month"),
                new Translation("Esta Semana","This Week"),
                new Translation("Este Día","This Day"),
                new Translation("Intervalo","Interval"),
                #endregion
                #region Meses del año
                new Translation("Enero","January"),
                new Translation("Febrero","February"),
                new Translation("Marzo","March"),
                new Translation("Abril","April"),
                new Translation("Mayo","May"),
                new Translation("Junio","June"),
                new Translation("Julio","July"),
                new Translation("Agosto","August"),
                new Translation("Septiembre","September"),
                new Translation("Octubre","October"),
                new Translation("Noviembre","November"),
                new Translation("Diciembre","December"),
                #endregion
                #region Dias del mes
                new Translation("Antepenúltimo","Third to last"),
                new Translation("Penúltimo","Second to last"),
                new Translation("Último","Last"),
                #endregion
                #region Dias de la semana
                new Translation("Lunes","Monday"),
                new Translation("Martes","Tuesday"),
                new Translation("Miércoles","Wednesday"),
                new Translation("Jueves","Thursday"),
                new Translation("Viernes","Friday"),
                new Translation("Sábado","Saturday"),
                new Translation("Domingo","Sunday"),
                #endregion
                #region Colores
                new Translation("Rojo","Red"),
                new Translation("Naranja","Orange"),
                new Translation("Amarillo","Yellow"),
                new Translation("Verde","Green"),
                new Translation("Celeste","Light Blue"),
                new Translation("Azul","Blue"),
                new Translation("Violeta","Purple"),
                new Translation("Rosa","Pink"),
                new Translation("Marrón","Brown"),
                new Translation("Negro","Black"),
                new Translation("Gris Oscuro","Dark Gray"),
                new Translation("Gris Medio","Medium Gray"),
                new Translation("Gris Claro","Light Gray"),
                new Translation("Blanco","White"),
                #endregion
                #region Cuando Chequear
                new Translation("Constantemente","Constantly"),
                new Translation("Al Inicio","At the Beginning"),
                new Translation("Al Final","At the End"),
                #endregion
                #region Operadores Relacionales
                new Translation("Mayor a","Greater than"),
                new Translation("Menor a","Less than"),
                new Translation("Mayor o Igual a","Greater than or Equal to"),
                new Translation("Menor o Igual a","Less than or Equal to"),
                new Translation("Igual a","Equal to"),
                new Translation("Diferente de","Different from"),
                #endregion
                #region Tipo Estadística
                new Translation("Ingreso/Egreso","Income/Expenses"),
                new Translation("Patrimonio Neto","Net Worth"),
                new Translation("Distribución","Distribution"),
                new Translation("Holgura de Presupuesto","Budget Looseness"),
                #endregion 
                #region Estilo Gráfico
                new Translation("Lineal","Linear"),
                new Translation("Columnas","Columns"),
                #endregion
                #region Gráfico En Funcion De
                new Translation("Ingresos y Egresos","Income and Expenses"),
                new Translation("Ingresos","Income"),
                new Translation("Egresos","Expenses"),
                #endregion
                #region Otros labels de estadística
                new Translation("Sin etiqueta","No Tag"),
                new Translation("Sin categoría","No Category"),
                #endregion
                #endregion
                #region Partes de oraciones
                new Translation("Cada","Every"),
                new Translation("Supervisa","Supervises"),
                new Translation("De","Of"),
                new Translation("sobre","over"),
                new Translation("Página","Page"),
                new Translation("de","of"),
                #endregion
                #region FileDialogs
                new Translation("Guardar como","Save as"),
                new Translation("Abrir","Open"),
                #endregion
                #region Notificaciones
                new Translation("Presupuesto excedido","Budget exceeded"),
                #endregion
                #region MessageBoxes
                new Translation("Advertencia","Warning"),
                new Translation("No se seleccionó ningún elemento.","No item was selected."),
                new Translation("El elemento ya se encuentra deshabilitado.","The item is already disabled."),
                new Translation("El elemento ya se encuentra habilitado.","The item is already enabled."),
                new Translation("¿Está seguro que desea deshabilitar el elemento seleccionado?","Are you sure you want to disable the selected item?"),
                new Translation("¿Está seguro que desea habilitar el elemento seleccionado?","Are you sure you want to enable the selected item?"),
                new Translation("¿Está seguro que desea habilitar la cuenta seleccionada?\nEsto habilitará todas las planificaciones ligadas a esta.","Are you sure you want to enable the selected account?\nThis will enable all planifications bounded to it."),
                new Translation("¿Está seguro que desea concretar la transacción?","Are you sure you want to mark the transaction as done?"),
                new Translation("La transacción no posee una fecha. ¿Desea establecer la fecha y hora actual para concretarla?","The transaction does not have a date. Do you want to set the current date and time to specify it?"),
                new Translation("Si desea concretar la transacción, deberá establecer su fecha desde el talonario de modificación respectivo.","If you wish to mark the transaction as done, you must establish its date from the respective modification form."),
                new Translation("La transacción posee una fecha y hora superior a la actual. ¿Desea establecer la fecha y hora actual para concretarla?","The transaction has a date and time greater than the current one. Do you want to set the current date and time to specify it?"),
                new Translation("¿Está seguro que desea eliminar el elemento seleccionado?","Are you sure you want to delete the selected item?"),
                new Translation("El presupuesto que desea ver ya no existe.","The budget you want to view no longer exists."),
                new Translation("El recordatorio que desea ver ya no existe.","The reminder you want to view no longer exists."),
                new Translation("¿Está seguro que desea marcar la notificación seleccionada como vista?\nEste proceso no es reversible.","Are you sure you want to mark the selected notification as a view?\nThis process is not reversible."),
                new Translation("¿Está seguro que desea marcar todas las notificaciones como vistas?\nEste proceso no es reversible.","Are you sure you want to mark all notifications as viewed?\nThis process is not reversible."),
                new Translation("Está seguro que desea borrar el perfil?\nEsta acción no se puede revertir.","Are you sure you want to delete the profile?\nThis action cannot be reversed."),
                new Translation("¿Está seguro que desea borrar el usuario?\nEsta acción no se puede revertir.","Are you sure you want to delete the user?\nThis action cannot be reversed."),
                new Translation("¿Está seguro que desea remover el perfil/permiso del perfil?","Are you sure you want to remove the profile's permission/profile?"),
                new Translation("¿Está seguro que desea remover el perfil/permiso del usuario?","Are you sure you want to remove the user's permission/profile?"),
                new Translation("Los cambios surtirán efecto al reiniciar la aplicación","Changes will take effect when you restart the application"),
                new Translation("El nuevo nombre es idéntico al que ya posee.","The new name is identical to the one you already have."),
                new Translation("El nombre de usuario ya existe.","The username already exists."),
                new Translation("La nueva contraseña es idéntica a la original.","The new password is identical to the original."),
                new Translation("La contraseña actual ingresada no coincide con la real.","The current password entered does not match the real one."),
                new Translation("La contraseña no coincide.","The password does not match."),
                new Translation("Falta ingresar la expresión.","The expression remains to be entered."),
                new Translation("La expresión es inválida.","The expression is invalid."),
                new Translation("Hay campos que no fueron completados.","There are fields that were not completed."),
                new Translation("La fecha ingresada es demasiado antigua.","The date entered is too old."),
                new Translation("Debe seleccionar un lapso.","You must select a span."),
                new Translation("La Fecha Desde es superior o igual a la Fecha Hasta.","Date From is greater than or equal to Date To."),
                new Translation("Debe seleccionar un elemento.","You must select an item."),
                new Translation("Falta ingresar usuario o contraseña.","User or password is missing."),
                new Translation("Usuario o contraseña inválidos.","Invalid user or password."),
                new Translation("El nombre de usuario y la contraseña no pueden coincidir.","Username and password cannot match."),
                new Translation("Creación de usuario exitosa.","Successful user creation."),
                new Translation("¿Está seguro que desea cerrar sesión?","Are you sure you want to log out?"),
                new Translation("¿Está seguro que desea restaurar?\nLos datos actuales del usuario serán reemplazados por los importados. Este proceso no es reversible y durará varios segundos.","Are you sure you want to restore?\nThe current data of the user will be replaced by the imported data. This process is not reversible and will take several seconds."),
                new Translation("Idiomas restablecidos. Reinicie la aplicación para que los cambios surtan efecto.","Languages restored. Restart the application for the changes to take effect."),
                new Translation("¿Está seguro que desea salir de la aplicación?","Are you sure you want to exit the application?"),
                new Translation("El nombre ya existe.","The name already exists."),
                new Translation("Para que la cuenta deje de admitir fondos negativos, su balance actual no puede ser negativo.","To stop the account from accepting negative funds, your current balance cannot be negative."),
                new Translation("Falta ingresar el nombre del perfil.","The name of the profile remains to be entered."),
                new Translation("El nombre de perfil ya existe.","The profile name already exists."),
                new Translation("¿Está seguro que desea eliminar el recordatorio ligado?","Are you sure you want to delete the bounded reminder?"),
                new Translation("Falta establecer el monto.","The amount remains to be established."),
                new Translation("Falta establecer la frecuencia e inicio.","The frequency and start remains to be established."),
                new Translation("Falta establecer la variable supervisada.","The supervised variable remains to be established."),
                new Translation("Falta establecer la condición.","The condition remains to be established."),
                new Translation("Falta establecer el lapso del presupuesto.","The budget span remains to be established."),
                new Translation("La fecha y hora de una transacción concretada no puede ser futura.","The date and time of a done transaction cannot be in the future."),
                new Translation("Exportación de respaldo exitosa.","Backup export successful."),
                new Translation("Restauración desde respaldo exitosa.\nLa aplicación se cerrará para aplicar los cambios.","Restore from backup successful.\nThe app will close to apply the changes."),
                #endregion
                #region Exceptions
                new Translation("El recurso no coincide con la tarea","The resource does not match the task"),
                new Translation("El tipo de tarea no es reconocido","Task type is not recognized"),
                new Translation("Realizar esta operación derivaría en un balance negativo para la cuenta correspondiente.\nEl balance considerado es aquel de la fecha de la transacción","Carrying out this operation would result in a negative balance for the corresponding account.\nThe balance considered is that of the transaction date"),
                new Translation("Error inesperado relacionado con la base de datos","Unexpected database related error"),
                new Translation("Error relacionado con la base de datos","Database related error"),
                new Translation("Ha ocurrido un error inesperado","An unexpected error has occurred"),
                new Translation("No se reconoce el ensamblado","Assembly not recognized"),
                #endregion
                #region Extensiones de Archivo
                new Translation("Libro de Excel","Excel Workbook"),
                new Translation("Archivo Binario","Binary File"),
                #endregion
                #region Acerca de Budgee
                new Translation("Copyright Ⓒ 2021 Ezequiel Francisco Amorosino - Todos los derechos reservados.","Copyright Ⓒ 2021 Ezequiel Francisco Amorosino - All rights reserved."),
                new Translation(
                    "El software tiene como propósito principal la gestión y administración contable, para facilitar la toma de decisiones a la hora de realizar gastos y prevenir una situación financiera desfavorable.\r\n\r\nEl nombre del software proviene de una alteración fonética de la palabra “Budget”, que en inglés significa “presupuesto”.",
                    "The main purpose of the software is accounting management and administration, to facilitate decision-making when making expenses and prevent an unfavorable financial situation.\r\n\r\nThe name of the software comes from a phonetic alteration of the word “Budget”."),
                #endregion
            };

            SerializationService.Json.Store(english, AppData.Config.Languages[Idioma.English]);
        }

        /// <summary>
        /// Bloque de datos que permite almacenar traducciones.
        /// </summary>
        private class Language
        {
            public List<Translation> translations = new List<Translation>();
        }
        /// <summary>
        /// Bloque de datos que permite almacenar una traducción para determinada palabra/oración.
        /// </summary>
        private class Translation
        {
            public string Key;
            public string Translated;

            public Translation(string key, string translated)
            {
                Key = key;
                Translated = translated;
            }

            public override string ToString()
            {
                return $"{Key} => {Translated}";
            }
        }
    }
}
