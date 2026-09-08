using DAL.Factories;
using Domain;
using Enums;
using SL.BLL.Contracts;
using SL.BLL.Services;
using SL.DAL.Contracts;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Variable.
    /// </summary>
    public class VariableService : IGenericBusinessLogic<Domain.Variable>
    {
        #region Singleton
        private readonly static VariableService _instance;
        public static VariableService Current { get { return _instance; } }
        static VariableService() { _instance = new VariableService(); }
        private VariableService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Variable> repository = Factory.Current.VariableRepository;

        public Variable GetOne(Guid ID)
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
        public IEnumerable<Variable> GetAll()
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
        public IEnumerable<Variable> GetAll(Func<Variable, bool> filter)
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
        public void Add(Variable obj)
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
        public void Remove(Variable obj)
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
        public void RemoveAll(Func<Variable, bool> filter)
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
        public void Update(Variable obj)
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
        public void AddOrUpdate(Variable obj)
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

        public decimal GetValue(Variable obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                decimal value = 0;

                if (!CheckSiTodosEstadosEnTrue(obj)) return 0;

                if (obj.Tipo_Variable == Tipo_Variable.Monto)
                {
                    if (obj.Transaccion != null)
                        value = ExpresionService.Current.GetResult(obj.Transaccion.MontoExpresion, transacciones);
                    else if (obj.Planificacion != null)
                        value = ExpresionService.Current.GetResult(obj.Planificacion.MontoExpresion, transacciones);
                    else if (obj.PlantillaTransaccion != null)
                    {
                        if (obj.PlantillaTransaccion.MontoExpresion == null) value = 0;
                        else value = ExpresionService.Current.GetResult(obj.PlantillaTransaccion.MontoExpresion, transacciones);
                    }
                }
                else
                {
                    if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                    //Si no es potencial solo quiero concretadas
                    if (obj.Tipo_Variable == Tipo_Variable.Balance || obj.Tipo_Variable == Tipo_Variable.Ingreso || obj.Tipo_Variable == Tipo_Variable.Egreso || obj.Tipo_Variable == Tipo_Variable.Ganancia_Neta)
                        transacciones = transacciones.Where(x => x.Concretada == true);

                    if (obj.Cuenta != null) transacciones = transacciones.Where(x => x.Cuenta.ID_Cuenta == obj.Cuenta.ID_Cuenta);
                    if (obj.Categoria != null) transacciones = transacciones.Where(x => x.Categoria.ID_Caracteristica == obj.Categoria.ID_Caracteristica);
                    if (obj.Etiqueta != null) transacciones = transacciones.Where(x => x.Etiquetas.Select(y => y.ID_Caracteristica).Contains(obj.Etiqueta.ID_Caracteristica));

                    //La fecha solo se usa para balance, por lo que filtro inferior o igual a fecha
                    if (obj.Fecha != null) transacciones = transacciones.Where(x => x.Fecha == null || x.Fecha <= obj.Fecha);

                    //El lapso se usa para ingreso, ergreso o ganancia neta
                    if (obj.Lapso != null) transacciones = FiltrarPorLapso(transacciones, obj.Lapso);

                    if (obj.Tipo_Variable == Tipo_Variable.Balance || obj.Tipo_Variable == Tipo_Variable.Balance_Potencial || obj.Tipo_Variable == Tipo_Variable.Ganancia_Neta || obj.Tipo_Variable == Tipo_Variable.Ganancia_Neta_Potencial)
                        value = GetBalanceOGananciaNeta(transacciones);
                    else if (obj.Tipo_Variable == Tipo_Variable.Ingreso || obj.Tipo_Variable == Tipo_Variable.Ingreso_Potencial)
                        value = GetIngreso(transacciones);
                    else if (obj.Tipo_Variable == Tipo_Variable.Egreso || obj.Tipo_Variable == Tipo_Variable.Egreso_Potencial)
                        value = GetEgreso(transacciones);
                }

                return value;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private decimal GetBalanceOGananciaNeta(IEnumerable<Transaccion> transacciones_activas)
        {
            try
            {
                IEnumerable<decimal> montosPositivos =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Ingreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                IEnumerable<decimal> montosNegativos =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Egreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                IEnumerable<decimal> montosCalculados =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Variable)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                decimal sumPositivo = (montosPositivos.Count() > 0) ? montosPositivos.Sum() : 0m;
                decimal sumNegativo = (montosNegativos.Count() > 0) ? montosNegativos.Sum() : 0m;
                decimal sumCalculado = (montosCalculados.Count() > 0) ? montosCalculados.Sum() : 0m;

                decimal resultado = sumPositivo - sumNegativo + sumCalculado;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private decimal GetIngreso(IEnumerable<Transaccion> transacciones_activas)
        {
            try
            {
                IEnumerable<decimal> montosPositivos =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Ingreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                IEnumerable<decimal> montosCalculados =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Variable && ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas) > 0)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                decimal sumPositivo = (montosPositivos.Count() > 0) ? montosPositivos.Sum() : 0m;
                decimal sumCalculado = (montosCalculados.Count() > 0) ? montosCalculados.Sum() : 0m;

                decimal resultado = sumPositivo + sumCalculado;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private decimal GetEgreso(IEnumerable<Transaccion> transacciones_activas)
        {
            try
            {
                IEnumerable<decimal> montosNegativos =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Egreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                IEnumerable<decimal> montosCalculados =
                    transacciones_activas
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Variable && ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas) < 0)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones_activas)));

                decimal sumNegativo = (montosNegativos.Count() > 0) ? montosNegativos.Sum() : 0m;
                decimal sumCalculado = (montosCalculados.Count() > 0) ? montosCalculados.Sum() : 0m;

                decimal resultado = Math.Abs(sumCalculado) + Math.Abs(sumNegativo);
                return resultado;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private IEnumerable<Transaccion> FiltrarPorLapso(IEnumerable<Transaccion> transacciones_activas, Lapso lapso)
        {
            try
            {
                dynamic transacciones_filtradas = null;

                transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || LapsoService.Current.FechaEntraEnLapso(lapso, (DateTime)x.Fecha));

                return transacciones_filtradas;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        [Obsolete("Suplantado",true)]
        private IEnumerable<Transaccion> FiltrarPorLapso_OLD(IEnumerable<Transaccion> transacciones_activas, Lapso lapso)
        {
            dynamic transacciones_filtradas = null;
            DateTime now = DateTime.Now;

            switch (lapso.TipoLapso)
            {
                case Tipo_Lapso.Historico:
                    transacciones_filtradas = transacciones_activas;
                    break;
                case Tipo_Lapso.Este_Año:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfYear() && x.Fecha <= now.EndOfYear()));
                    break;
                case Tipo_Lapso.Este_Semestre:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfSemester() && x.Fecha <= now.EndOfSemester()));
                    break;
                case Tipo_Lapso.Este_Cuatrimestre:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfQuarter() && x.Fecha <= now.EndOfQuarter()));
                    break;
                case Tipo_Lapso.Este_Trimestre:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfTrimester() && x.Fecha <= now.EndOfTrimester()));
                    break;
                case Tipo_Lapso.Este_Mes:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfMonth() && x.Fecha <= now.EndOfMonth()));
                    break;
                case Tipo_Lapso.Esta_Semana:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfWeek(DayOfWeek.Monday) && x.Fecha <= now.EndOfWeek(DayOfWeek.Sunday)));
                    break;
                case Tipo_Lapso.Este_Dia:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= now.StartOfDay() && x.Fecha <= now.EndOfDay()));
                    break;
                case Tipo_Lapso.Intervalo:
                    transacciones_filtradas = transacciones_activas.Where(x => x.Fecha == null || (x.Fecha >= lapso.FechaDesde && x.Fecha <= lapso.FechaHasta));
                    break;
                default:
                    transacciones_filtradas = transacciones_activas;
                    break;
            }

            return transacciones_filtradas;
        }
        private bool CheckSiTodosEstadosEnTrue(Variable obj)
        {
            if (obj.Transaccion != null && !obj.Transaccion.Estado) return false;
            if (obj.Planificacion != null && !obj.Planificacion.Estado) return false;
            if (obj.PlantillaTransaccion != null && !obj.PlantillaTransaccion.Estado) return false;
            if (obj.Cuenta != null && !obj.Cuenta.Estado) return false;
            if (obj.Categoria != null && !obj.Categoria.Estado) return false;
            if (obj.Etiqueta != null && !obj.Etiqueta.Estado) return false;

            return true;
        }

        public string GetDescription(Variable obj)
        {
            string targets = null;

            if (obj.Transaccion != null) 
                targets += $"{"Transacción".Translate()} \"{obj.Transaccion}\"";

            if (obj.Planificacion != null) { targets = SumarComaSiNecesita(targets); 
                targets += $"{"Planificación".Translate()} \"{obj.Planificacion}\""; }

            if (obj.PlantillaTransaccion != null) { targets = SumarComaSiNecesita(targets);
                targets += $"{"Plantilla".Translate()} \"{obj.PlantillaTransaccion}\""; }

            if (obj.Cuenta != null) { targets = SumarComaSiNecesita(targets);
                targets += $"{"Cuenta".Translate()} \"{obj.Cuenta}\""; }

            if (obj.Categoria != null) { targets = SumarComaSiNecesita(targets);
                targets += $"{"Categoría".Translate()} \"{obj.Categoria}\""; }

            if (obj.Etiqueta != null) { targets = SumarComaSiNecesita(targets);
                targets += $"{"Etiqueta".Translate()} \"{obj.Etiqueta}\""; }

            if (targets == null) targets += "global".Translate();

            string tiempo = "";

            if (obj.Fecha != null) tiempo = $" ({obj.Fecha})";
            else if (obj.Lapso != null) tiempo = $" ({SL.BLL.Services.LapsoService.Current.GetDescription(obj.Lapso)})";

            return $"{obj.Tipo_Variable.GetDescription().Translate()} {"sobre".Translate()} {targets}{tiempo}";
        }
        private string SumarComaSiNecesita(string text)
        { 
            if (text == null || text.Length == 0) return text;
            else if (text.Length == 1) return text + ", ";
            else if (text.Length > 1 && text.Substring(text.Length - 2) != ", ") return text + ", ";
            else return text;
        }
    }
}
