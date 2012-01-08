using System;
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
          
            Step     step= context.Steps.Where(s=>s.stepId.Equals(StepId)).SingleOrDefault();

            CylCtrl.changeCylinderStep(cyl,null, step,null, string.Empty, StartTime,DateTime.Now, 0, CylinderConst.STATUS_INPROD,false);
        }

        public void FinishCylinderWork(string Barcode, string EmployeeBarCode, Guid StepId, DateTime FinishTime)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            Step step = context.Steps.Where(s => s.stepId.Equals(StepId)).SingleOrDefault();

            Cylinder_Log Cyl_Log = context.Cylinder_Log.Where(cl => cl.cylinderId.Equals(cyl.cylinderId) && cl.stepId.Equals(StepId) 
                                        && cl.status.Equals(CylinderConst.STATUS_INPROD)).SingleOrDefault();
            Cyl_Log.end_time    = FinishTime;
            Cyl_Log.employeeId  = emp.employeeId;
            Cyl_Log.mark        = CalculateMark(Cyl_Log.start_time, FinishTime, Cyl_Log.formula);
            Cyl_Log.status      = CylinderConst.STATUS_COMPLETED;
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

        }

        public void FinishCylinderWorkWithError(string Barcode, string EmployeeBarCode, Guid StepId, DateTime FinishTime,Error ErrorReason)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            

            Cylinder_Log Cyl_Log = context.Cylinder_Log.Where(cl => cl.cylinderId.Equals(cyl.cylinderId) && cl.stepId.Equals(StepId)
                                    && cl.status.Equals(CylinderConst.STATUS_INPROD)).SingleOrDefault();
            Cyl_Log.end_time = FinishTime;
            Cyl_Log.employeeId = emp.employeeId;
            Cyl_Log.mark = 0; //no mark due to error
            Cyl_Log.status = CylinderConst.LOG_STS_ERR_DAMAGE;
            Cyl_Log.error_desc = ErrorReason.name;
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public void RepoartCylinderWithError(string Barcode, string EmployeeBarCode,Error ErrorReason,String Remark)
        {
            EmployeeController EmpCtrl = new EmployeeController();

            Cylinder cyl = getCylinder(Barcode);
            Employee emp = context.Employees.Where(e => e.barcode.Equals(EmployeeBarCode)).SingleOrDefault();
            Step step = context.Steps.Where(s => s.stepId.Equals(cyl.stepId)).SingleOrDefault();

            CylinderController CylCtrl = new CylinderController();


            CylCtrl.changeCylinderStep(cyl, emp, step, ErrorReason, Remark, DateTime.Now, DateTime.Now, 0, CylinderConst.LOG_STS_ERR_PREVIOUS, false);
        }

        private int CalculateMark(DateTime Start, DateTime End, string Formula)
        {
            return 1;
        }
    }
}
