using Enums;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.DAL.Factories;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace SL.BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Lapso.
    /// </summary>
    public class LapsoService : IGenericBusinessLogic<Domain.Lapso>
    {
        #region Singleton
        private readonly static LapsoService _instance;
        public static LapsoService Current { get { return _instance; } }
        static LapsoService() { _instance = new LapsoService(); }
        private LapsoService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Lapso> repository = Factory.Current.LapsoRepository;

        public Lapso GetOne(Guid ID)
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
        public IEnumerable<Lapso> GetAll()
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
        public IEnumerable<Lapso> GetAll(Func<Lapso, bool> filter)
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
        public void Add(Lapso obj)
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
        public void Update(Lapso obj)
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
        public void AddOrUpdate(Lapso obj)
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
        public void Remove(Lapso obj)
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
        public void RemoveAll(Func<Lapso, bool> filter)
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

        public bool FechaEntraEnLapso(Lapso lapso, DateTime fecha)
        {
            DateTime now = DateTime.Now;

            switch (lapso.TipoLapso)
            {
                case Tipo_Lapso.Historico:
                    return true;
                case Tipo_Lapso.Este_Año:
                    return (fecha >= now.StartOfYear() && fecha <= now.EndOfYear());
                case Tipo_Lapso.Este_Semestre:
                    return (fecha >= now.StartOfSemester() && fecha <= now.EndOfSemester());
                case Tipo_Lapso.Este_Cuatrimestre:
                    return (fecha >= now.StartOfQuarter() && fecha <= now.EndOfQuarter());
                case Tipo_Lapso.Este_Trimestre:
                    return (fecha >= now.StartOfTrimester() && fecha <= now.EndOfTrimester());
                case Tipo_Lapso.Este_Mes:
                    return (fecha >= now.StartOfMonth() && fecha <= now.EndOfMonth());
                case Tipo_Lapso.Esta_Semana:
                    return (fecha >= now.StartOfWeek(DayOfWeek.Monday) && fecha <= now.EndOfWeek(DayOfWeek.Sunday));
                case Tipo_Lapso.Este_Dia:
                    return (fecha >= now.StartOfDay() && fecha <= now.EndOfDay());
                case Tipo_Lapso.Intervalo:
                    return (fecha >= lapso.FechaDesde && fecha <= lapso.FechaHasta);
                default:
                    return false;
            }
        }
        public string GetDescription(Lapso obj, bool shorter = false)
        {
            if (obj.TipoLapso != Tipo_Lapso.Intervalo) return obj.TipoLapso.GetDescription().Translate();
            else if (!shorter) return $"{obj.TipoLapso.GetDescription().Translate()}: {obj.FechaDesde}~{obj.FechaHasta}";
            else
            {
                DateTime fechaDesde = (DateTime)obj.FechaDesde;
                DateTime fechaHasta = (DateTime)obj.FechaHasta;
                if (fechaDesde.ToString("dd/MM/yyyy") == fechaHasta.ToString("dd/MM/yyyy")) return $"{((DateTime)obj.FechaDesde).ToString("HH:mm:ss")}~{((DateTime)obj.FechaHasta).ToString("HH:mm:ss")} ({fechaDesde.ToString("dd/MM/yyyy")})";
                else return $"{((DateTime)obj.FechaDesde).ToString("dd/MM/yyyy")}~{((DateTime)obj.FechaHasta).ToString("dd/MM/yyyy")}";
            }
        }
    }
}
