using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace SL.Services
{
    /// <summary>
    /// Permite la resolución y validación de expresiones algebraicas, incluyendo el uso de variables.
    /// </summary>
    public static class CalculatorService
    {
        static Dictionary<string, object> variables_internas = new Dictionary<string, object>()
        {
            { "Pi", Math.PI },
            { "e", Math.E }
        };
        public static object SolveExpression(string expresion)
        {
            try
            {
                NCalc.Expression expression = new NCalc.Expression(expresion);

                return expression.Evaluate();
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(CalculatorService));
                throw;
            }
        }
        public static object SolveExpression(string expresion, Dictionary<string, object> variables)
        {
            try
            {
                NCalc.Expression expression = new NCalc.Expression(expresion);

                foreach (var variable in variables)
                    expression.Parameters[variable.Key] = variable.Value;

                foreach (var var_interna in variables_internas)
                    if (!variables.ContainsKey(var_interna.Key))
                        expression.Parameters[var_interna.Key] = var_interna.Value;

                return expression.Evaluate();
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(CalculatorService));
                throw;
            }
        }
        public static bool ValidateExpression(string expresion)
        {
            try
            {
                var result = SolveExpression(expresion);
                if (result.ToString() == "∞") throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ValidateExpression(string expresion, Dictionary<string, object> variables)
        {
            try
            {
                var result = SolveExpression(expresion, variables);
                if (result.ToString() == "∞") throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                return false;
            }
        }
    }
}
