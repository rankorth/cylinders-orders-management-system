using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    /// <author>Tin Kyaw Oo</author>
    /// <datetime>11-Nov-2011</datetime>
    /// <summary>Workflow Management Controller</summary>
    /// 

    public class WorkflowController
    {
        private COMSEntities dbContext = new COMSEntities();
        public void SaveWorkflow(Workflow workflow)
        {
            try
            {
                workflow.workflowId = Guid.NewGuid(); //generate new guid as primary key.
                dbContext.Workflows.AddObject(workflow);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while saving workflow", ex);
            }
        }

        public IQueryable<Step> GetSteps(Guid WorkflowID)
        {
            return dbContext.Steps.Where(s => s.workflowId == WorkflowID && s.isActive==true && s.isStep==true);
        }

        public IQueryable<Step> getAllSteps()
        {
            return dbContext.Steps.Where(s => s.isActive == true && s.isStep == true) ;
        }

        public IQueryable<Workflow> GetAllWorkflow()
        {
            return dbContext.Workflows.Where(w=>w.isactive==true);
        }

        public IQueryable<Step> GetNextSteps(Guid WorkflowID, Guid CurrentStepID)
        {
            //return value may be more than one as there may be branching of steps
            // do join
            //(e.g) Select * from step_ref as sf  left join step as s in sf.to_stepId = s.stepId
            return dbContext.Step_ref.Where(sf => sf.from_stepId==CurrentStepID && sf.workflowId==WorkflowID)
                .Join(dbContext.Steps, sf => sf.to_stepId, s => s.stepId, (sf, s) => s);
        }

        //Tin (8-Jan-2012)
        public IQueryable<Step> GetNextSteps(string CylinderBarCode)
        {
            if (string.IsNullOrEmpty(CylinderBarCode))
            {
                return null;
            }
            Cylinder Cyl =  dbContext.Cylinders.Where(c => c.barcode.Equals(CylinderBarCode)).SingleOrDefault();
            return GetNextSteps(Cyl.workflowId, (Guid) Cyl.stepId);
        }

        public void UpdateWorkflow(Workflow workflow)
        {
            try
            {
                remove_steps(workflow.workflowId);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while saving workflow", ex);
            }
        }

        private void remove_step_ref(Guid stepID)
        {
            List<Step_ref> delStepsRef = new List<Step_ref>();
            IQueryable<Step_ref> steprefs = dbContext.Step_ref.Where(sr => sr.from_stepId.Equals(stepID) || sr.to_stepId.Equals(stepID));

            foreach (Step_ref stepRef in steprefs)
            {
                delStepsRef.Add(stepRef);
            }
            foreach (Step_ref sr in delStepsRef) { dbContext.DeleteObject(sr); }
        }
        private void remove_steps(Guid WorkflowID)
        {
            List<Step> delSteps = new List<Step>();
            IQueryable<Step> steps = dbContext.Steps.Where(s => s.workflowId.Equals(WorkflowID));
            foreach (Step s in steps)
            {
                delSteps.Add(s);
            }
            foreach (Step s in delSteps)
            {
                remove_step_ref(s.stepId);
                dbContext.DeleteObject(s); 
            }
        }

        public List<Order> viewCurrentQueue(Guid workflowId)
        {
            List<Order> orderList = new List<Order>();
            IQueryable<Cylinder> cylList = dbContext.Cylinders.Where(c => c.workflowId.Equals(workflowId));
            foreach (Cylinder cyl in cylList) {
                orderList.Add(cyl.Order_Detail.Order);
            }
            return orderList;
        }

        public Step getStep(Guid StepId)
        {
            return dbContext.Steps.Where(s => s.stepId==StepId).SingleOrDefault();
        }

        public Workflow GetWorkflow(Guid WorkflowId)
        {
            return dbContext.Workflows.Where(w => w.workflowId == WorkflowId && w.isactive == true).SingleOrDefault();
        }

        public Workflow GetWorkflow(String wfName1, String wfName2)
        {
            return dbContext.Workflows.Where(w => w.name.IndexOf(wfName1) > -1 && w.name.IndexOf(wfName2) > -1 && w.isactive == true).SingleOrDefault();
        }
    }
}
