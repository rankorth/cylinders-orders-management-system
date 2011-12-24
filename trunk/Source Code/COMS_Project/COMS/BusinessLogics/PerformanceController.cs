using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    class PerformanceController
    {
        private COMSEntities context = new COMSEntities();
        public bool insertFormula(Formula formula)
        {
            try
            {
                if (context != null && formula != null)
                {
                    //add formula record into databse
                    context.Formulae.AddObject(formula);

                    //make changes perminent 
                    context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception has been thrown at insertFormula method of PerformanceController class: " + ex.Message.ToString());
                return false;                
            }
            return true;
        }

        public bool updateFormula(Formula formula)
        {
            try
            {
                if (null != formula && null != context)
                {
                    IQueryable<Formula> formulas = context.Formulae.Where(s => s.formulaId.Equals(formula.formulaId));
                    if (null != formulas)
                    {
                        foreach (Formula s in formulas)
                        {
                            if (null != s)
                            {
                                s.coef1 = formula.coef1;
                                s.coef2 = formula.coef2;
                                s.coef3 = formula.coef3;
                                s.coef4 = formula.coef4;
                                s.formula1 = formula.formula1;
                                s.isactive = formula.isactive;
                                s.Step = formula.Step;
                                s.stepId = formula.stepId;
                                s.StepReference = formula.StepReference;                               
                            }
                        }
                    }
                    context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception has been thrown at updateFormula method of PerformanceController class: " + ex.Message.ToString());
                return false;
            }
            return true;
        }

        public Formula retrieveFormula(string formulaId)
        {
            try
            {
                Formula formula = new Formula();
                if (context != null && formulaId != null)
                {
                    IQueryable<Formula> formulas = context.Formulae.Where(s => s.formulaId.Equals(new Guid(formulaId)));
                    if(formulas != null)
                        foreach (Formula s in formulas)
                        {
                            if (null != s)
                            {
                                formula = s;
                            }
                        }

                    return formula;
                }
                else throw new Exception("context or formula id is null");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception has been thrown at retrieveFormula method of PerformanceController class: " + ex.Message.ToString());
            }
        }

        public IQueryable<Formula> retrieveActiveFormulaList() 
        {
            try
            {
                if (context != null)
                {
                    return context.Formulae.Where(s => s.isactive.Equals(true));
                }
                else throw new Exception("context is null");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception has been thrown at retrieveActiveFormulaList method of PerformanceController class: " + ex.Message.ToString());                
            }
        }

        public IQueryable<Formula> retrieveAllFormulaList()
        {
            try
            {
                if (context != null)
                {
                    return context.Formulae;
                }
                else throw new Exception("context is null");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception has been thrown at retrieveAllFormulaList method of PerformanceController class: " + ex.Message.ToString());
            }
        }
    }
}