using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace BusinessLogics
{
    public static class FormulaUtility
    {
        private static VsaEngine _engine = VsaEngine.CreateEngine();

        public static double EvaluateFormula(Formula FormulaRec,double Diameter)
        {
            double result = 0;
            string formula = FormulaRec.formula1.Trim();

            if (formula.Length == 0)
            {
                return 0;
            }
            double Area = 2 * Math.PI * Diameter / 2;
            formula = formula.Replace("D", Diameter.ToString() );
            formula = formula.Replace("S", Area.ToString());
            formula = formula.Replace("a", FormulaRec.coef1.ToString());
            formula = formula.Replace("b", FormulaRec.coef2.ToString());
            formula = formula.Replace("c", FormulaRec.coef3.ToString());
            formula = formula.Replace("d", FormulaRec.coef4.ToString());
            
           

            try
            {
                result =  double.Parse(Eval.JScriptEvaluate(formula, _engine).ToString());
            }
            catch
            {
                result = 0;
            }
            return result;
        }
    }
}
