using DAL.Factories;
using Domain;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Expresión.
    /// </summary>
    public class ExpresionService : IGenericBusinessLogic<Domain.Expresion>
    {
        #region Singleton
        private readonly static ExpresionService _instance;
        public static ExpresionService Current { get { return _instance; } }
        static ExpresionService() { _instance = new ExpresionService(); }
        private ExpresionService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Expresion> repository = Factory.Current.ExpresionRepository;

        public Expresion GetOne(Guid ID)
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
        public IEnumerable<Expresion> GetAll()
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
        public IEnumerable<Expresion> GetAll(Func<Expresion, bool> filter)
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
        public void Add(Expresion obj)
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
        public void Remove(Expresion obj)
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
        public void RemoveAll(Func<Expresion, bool> filter)
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
        public void Update(Expresion obj)
        {
            try
            {
                var obj_from_db = repository.GetAll(x => x.ID_Expresion == obj.ID_Expresion).FirstOrDefault();

                repository.Update(obj);

                if (obj_from_db != null)
                {
                    foreach (var variable in obj_from_db.Variables)
                    {
                        if (!obj.Variables.Select(x => x.ID_Variable).Contains(variable.ID_Variable))
                            VariableService.Current.Remove(variable);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Expresion obj)
        {
            try
            {
                var obj_from_db = repository.GetAll(x => x.ID_Expresion == obj.ID_Expresion).FirstOrDefault();

                repository.AddOrUpdate(obj);

                if (obj_from_db != null)
                {
                    foreach (var variable in obj_from_db.Variables)
                    {
                        if (!obj.Variables.Select(x => x.ID_Variable).Contains(variable.ID_Variable))
                            VariableService.Current.Remove(variable);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public decimal GetResult(Expresion obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                var variables = new Dictionary<string, object>();

                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                obj.Variables.ForEach(x =>
                    variables.Add(x.Nombre_Variable, VariableService.Current.GetValue(x, transacciones)));

                return Convert.ToDecimal(
                    SL.Services.CalculatorService.SolveExpression(obj.Definicion, variables));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void FijarValor(Expresion obj)
        {
            try
            {
                obj.Definicion = GetResult(obj).ToString();
                obj.Variables.Clear();
                obj.Tipo_Expresion = Enums.Tipo_Expresion.Fija;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public string GetDescription(Expresion obj)
        {
            if (ContainsOneVariableOnly(obj.Definicion)) return VariableService.Current.GetDescription(obj.Variables[0]);
            else return obj.Definicion;
        }
        private bool ContainsOneVariableOnly(string definicion)
        {
            bool startsWithBracket = (definicion[0] == '[');
            bool endsWithBracket = (definicion[definicion.Length - 1] == ']');
            bool hasOnePairOfBrackets = (definicion.Count(x => x == '[') == 1 && definicion.Count(x => x == ']') == 1);

            if (startsWithBracket && endsWithBracket && hasOnePairOfBrackets) return true;
            else return false;
        }
    }
}
