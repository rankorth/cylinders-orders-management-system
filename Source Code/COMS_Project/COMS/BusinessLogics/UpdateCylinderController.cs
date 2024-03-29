﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

namespace BusinessLogics
{
    public enum step
    {
        scan_cylinder_start = 0,
        select_actions = 1,
        select_step = 2,
        scan_cylinder_toend = 3,
        scan_employee_code = 4,
        error_reason = 5,
    }
    public class UpdateCylinderController
    {
        COMSEntities context = new COMSEntities();

        public Cylinder getCylinder(string Barcode)
        {
            Cylinder cyl = context.Cylinders.Where(c => c.barcode.Equals(Barcode)).SingleOrDefault();
            return cyl;
        }

        public void StartCylinderWork(string Barcode, Guid StepId, DateTime StartTime)
        {
            CylinderController CylCtrl = new CylinderController();
            EmployeeController EmpCtrl =new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
          
            Step     step= context.Steps.Where(s=>s.stepId==(StepId)).SingleOrDefault();

            CylCtrl.changeCylinderStep(cyl,null, step,null, string.Empty, StartTime,DateTime.Now, 0, CylinderConst.STATUS_INPROD,false);

        }

        public void FinishCylinderWork(string Barcode, string EmployeeBarCode, Guid StepId, DateTime FinishTime)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            Step step = context.Steps.Where(s => s.stepId==(StepId)).SingleOrDefault();

            Cylinder_Log Cyl_Log = context.Cylinder_Log.Where(cl => cl.cylinderId==cyl.cylinderId && cl.stepId==StepId 
                                        && cl.status.Equals(CylinderConst.STATUS_INPROD) && cl.employeeId==null ).SingleOrDefault();
            Cyl_Log.end_time    = FinishTime;
            Cyl_Log.employeeId  = emp.employeeId;
            Cyl_Log.mark        = step.isStep ? (int)CalculateMark(Cyl_Log.start_time, FinishTime, step.Formulae.First(),(double)cyl.diameter) : 0 ;
            Cyl_Log.remark = step.isStep ? "" : "Sent from previous workflow";
            Cyl_Log.status      = CylinderConst.STATUS_COMPLETED;
            
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

            if (step.isStep)
            {
                MoveToNextWorkflow(cyl, emp, step);// move to next workflow if this is the last step done.
            }
            else
            {
                MoveToNextWorkflowFromEndStep(cyl, emp, step);
            }
            
        }

        private void MoveToNextWorkflow(Cylinder cylinder, Employee employee, Step CurrentStep)
        {
            WorkflowController WorkflowCtrl = new WorkflowController();
            IQueryable<Step> NextSteps = WorkflowCtrl.GetNextSteps(CurrentStep.workflowId, CurrentStep.stepId);
            if (NextSteps.Count() == 1 && !NextSteps.First().isStep)
            {
                //next step is not a workflow step, it is the End Node.
                if (!NextSteps.First().isStep && !NextSteps.First().isBegin)
                {
                    Step EndStep = NextSteps.First();
                    //there is next workflow setted up / not production end
                    if (EndStep.Workflow.nextWorkflowID != null && EndStep.Workflow.nextWorkflowID != Guid.Empty)
                    {
                        Step NextWorkflowStartNode = context.Steps.Where(s => s.workflowId == (EndStep.Workflow.nextWorkflowID)
                                                        && s.isStep.Equals(false)
                                                        && s.isBegin.Equals(true)).SingleOrDefault();


                        CylinderController CylCtrl = new CylinderController();
                        CylCtrl.changeCylinderStep(cylinder, employee, NextWorkflowStartNode, null, "Sent from previous workflow", DateTime.Now, DateTime.Now, 0, CylinderConst.STATUS_COMPLETED, false);
                        MoveToNextWorkflow(cylinder, employee, NextWorkflowStartNode);
                    }
                    //this is end of production detected.
                    else if (EndStep.Workflow.nextWorkflowID != null && EndStep.Workflow.nextWorkflowID == Guid.Empty)
                    {
                        CylinderController CylCtrl = new CylinderController();
                        CylCtrl.changeCylinderStep(cylinder, employee,EndStep, null, "PRODUCTION COMPLETED", DateTime.Now, DateTime.Now, 0, CylinderConst.STATUS_COMPLETED, false,true);
                        
                    }
                }
            }
        }

        private void MoveToNextWorkflowFromEndStep(Cylinder cylinder, Employee employee, Step CurrentEndStep)
        {
            WorkflowController WorkflowCtrl = new WorkflowController();
            Step NextSteps = WorkflowCtrl.getStep(CurrentEndStep.stepId);
            if (NextSteps !=null && !NextSteps.isStep)
            {
                //next step is not a workflow step, it is the End Node.
                if (!NextSteps.isStep && !NextSteps.isBegin)
                {
                    Step EndStep = NextSteps;
                    //there is next workflow setted up / not production end
                    if (EndStep.Workflow.nextWorkflowID != null && EndStep.Workflow.nextWorkflowID != Guid.Empty)
                    {
                        Step NextWorkflowStartNode = context.Steps.Where(s => s.workflowId == (EndStep.Workflow.nextWorkflowID)
                                                        && s.isStep.Equals(false)
                                                        && s.isBegin.Equals(true)).SingleOrDefault();


                        CylinderController CylCtrl = new CylinderController();
                        CylCtrl.changeCylinderStep(cylinder, employee, NextWorkflowStartNode, null, "Sent from previous workflow", DateTime.Now, DateTime.Now, 0, CylinderConst.STATUS_COMPLETED, false);
                        MoveToNextWorkflow(cylinder, employee, NextWorkflowStartNode);
                    }
                    //this is end of production detected.
                    else if (EndStep.Workflow.nextWorkflowID != null && EndStep.Workflow.nextWorkflowID == Guid.Empty)
                    {
                        CylinderController CylCtrl = new CylinderController();
                        CylCtrl.changeCylinderStep(cylinder, employee, EndStep, null, "PRODUCTION COMPLETED", DateTime.Now, DateTime.Now, 0, CylinderConst.STATUS_COMPLETED, false, true);

                    }
                }
            }
        }

        private void ProductionCompleted(Cylinder cylinder, Employee employee, Step step)
        {
        }
        public void FinishCylinderWorkWithError(string Barcode, string EmployeeBarCode, Guid StepId, DateTime FinishTime,Error ErrorReason)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            

            Cylinder_Log Cyl_Log = context.Cylinder_Log.Where(cl => cl.cylinderId==cyl.cylinderId && cl.stepId==StepId
                                    && cl.status.Equals(CylinderConst.STATUS_INPROD)).SingleOrDefault();
            Cyl_Log.end_time = FinishTime;
            Cyl_Log.employeeId = emp.employeeId;
            Cyl_Log.mark = 0; //no mark due to error
            Cyl_Log.status = CylinderConst.LOG_STS_ERR_DAMAGE;
            Cyl_Log.error_desc = ErrorReason.name;
            Cyl_Log.dept_name = emp.Department.name;
            Cyl_Log.created_by = emp.username;
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public void RepoartCylinderWithError(string Barcode, string EmployeeBarCode,Error ErrorReason,String Remark)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            Step step = context.Steps.Where(s => s.stepId==cyl.stepId).SingleOrDefault();

            if (step == null)
            {
                return;
            }
            CylinderController CylCtrl = new CylinderController();


            CylCtrl.changeCylinderStep(cyl, emp, step, ErrorReason, Remark, DateTime.Now, DateTime.Now, 0, CylinderConst.LOG_STS_ERR_PREVIOUS, false);
        }

        private double CalculateMark(DateTime Start, DateTime End, Formula formula,double Diameter)
        {
            return FormulaUtility.EvaluateFormula(formula, Diameter);
        }

        public void SendToWorkflowOrStep(Guid cylinderId, Employee employee, Guid StepToSendId,string Remark)
        {               
            CylinderController CylCtrl = new CylinderController();
            Cylinder cylinder = CylCtrl.viewCylinderInfo(cylinderId);
            Guid fromStepId = context.Step_ref.Where(sf => sf.to_stepId == StepToSendId).First().from_stepId;
            Step PreviousStep = context.Steps.Where(s => s.stepId == fromStepId).SingleOrDefault();
            Step SendToStep = context.Steps.Where(s => s.stepId == StepToSendId).SingleOrDefault();
            CylCtrl.changeCylinderStep(cylinder, employee, PreviousStep, null, Remark, DateTime.Now, DateTime.Now, 0, "Rejected (or) Damaged, sent to [Step:" + SendToStep.name + "] [Workflow:" + SendToStep.Workflow.name + "]", false);
                        
        }

        public IQueryable<Cylinder_Log> GetAllDamageOrRejectedCylinders(Employee Supervisor)
        {
            IQueryable<Cylinder_Log> ErrorCylLogs =  context.Cylinder_Log.Where(cl => (cl.status.Equals(CylinderConst.LOG_STS_ERR_DAMAGE) ||
                                        cl.status.Equals(CylinderConst.LOG_STS_ERR_PREVIOUS)) &&
                                        (cl.Cylinder.status.Equals(CylinderConst.STATUS_INPROD)));

            return ErrorCylLogs;
        }

    }
}
