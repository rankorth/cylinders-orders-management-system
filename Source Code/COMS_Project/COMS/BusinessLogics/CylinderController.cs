using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class CylinderConst
    {
        public const String CORETYPE_NEW = "NEW";
        public const String CORETYPE_USED = "USED";
        public const String CORETYPE_BACKUP = "BACKUP";

        public const String STATUS_INPROD = "INPROD";
        public const String STATUS_STOPPED = "STOPPED";
        public const String STATUS_COMPLETED = "COMP";

        public const String LOG_STS_ERR_PREVIOUS = "ERR_PRV";
        public const String LOG_STS_ERR_DAMAGE = "ERR_DAMG";
        public const String LOG_STS_OK = "OK";
        public const String LANG_ENG = "EN";
        public const String LANG_VN = "VN";


        
    }
    public class CylinderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public void create(Guid orderId, Guid workflowId, Employee empl)
        {
            try
            {
                if (null != orderId && null != workflowId)
                {
                    Order order = (new SalesOrderController()).retrieveSalesOrder(orderId);
                    foreach (Order_Detail od in order.Order_Detail)
                    {
                        //new order started production, starts creating cylinders
                        if (od.Cylinders.Count() == 0)
                        {
                            generateCylinder(od, workflowId);
                        }
                        else if (od.Cylinders.Count() > 0) //order previously in production, resume production for cylinders
                        {
                            updateCylinderStatus(od.order_detailId, CylinderConst.STATUS_INPROD, empl);
                        }
                    }

                    dbContext.GetObjectByKey(order.EntityKey);
                    order.status = OrderConst.STATUS_INPROD;
                    (new SalesOrderController()).createOrderLog(order, empl);
                    dbContext.Orders.ApplyCurrentValues(order);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating the cylinder ", ex);
            }
        }

        private void generateCylinder(Order_Detail orderDetail, Guid workflowID)
        {
            try
            {
                if (null != orderDetail && null != dbContext && null!=workflowID)
                {
                    int colorNo = 1;
                    for (int cylNo = 1; cylNo <= (orderDetail.new_cyl_count + orderDetail.used_cyl_count); cylNo++)
                    {
                        Cylinder newCylinder = new Cylinder();
                        newCylinder.color_no = colorNo;
                        newCylinder.core_type = orderDetail.core_type;
                        newCylinder.cyl_no = cylNo;
                        newCylinder.barcode = getCylinderBarCode(orderDetail.Order.order_code, "" + cylNo, ""+colorNo, orderDetail.core_type);
                        newCylinder.created_by = orderDetail.created_by;
                        newCylinder.created_date = orderDetail.created_date;
                        newCylinder.cylinderId = Guid.NewGuid();
                        newCylinder.diameter = (decimal)orderDetail.cyl_diameter;
                        newCylinder.length = (decimal)orderDetail.cyl_length;
                        newCylinder.order_detailId = orderDetail.order_detailId;
                        newCylinder.status = CylinderConst.STATUS_INPROD;
                        newCylinder.updated_by = orderDetail.updated_by;
                        newCylinder.updated_date = orderDetail.updated_date;
                        newCylinder.workflowId = workflowID;
                        dbContext.Cylinders.AddObject(newCylinder);
                        colorNo++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while generating the cylinder ", ex);
            }
        }

        public IQueryable<Cylinder> retrieveCylinderList()
        {
            try
            {
                if (null != dbContext)
                {
                    if (null != dbContext.Cylinders)
                        return dbContext.Cylinders;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the cylinder list from the database. ", ex);
            }
            return null;
        }

        public Cylinder viewCylinderInfo(Guid cylinderID)
        {
            try
            {
                Cylinder cylinder = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinderID)).SingleOrDefault();
                return cylinder;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the cylinder information from the database. ", ex);
            }
        }

        public IQueryable<Cylinder> retrieveCylinderList(Guid orderDetailsID)
        {
            try
            {
                if (null != dbContext && null!=orderDetailsID)
                {
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.order_detailId.Equals(orderDetailsID));
                    return cylinders;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the cylinder list from the database. ", ex);
            }
            return null;
        }

        public void stopProduction(Guid orderId, Employee empl)
        {
            try
            {
                Order order = dbContext.Orders.Where(o => o.orderId.Equals(orderId)).SingleOrDefault();
                if(null!= order && null!=dbContext){

                    foreach (Order_Detail od in order.Order_Detail)
                    {
                        //Tin (7-Jan-2012) added parameter to update cylinder status
                        updateCylinderStatus(od.order_detailId,CylinderConst.STATUS_STOPPED, empl);
                    }
                }
                order.status = OrderConst.STATUS_STOPPED;
                (new SalesOrderController()).createOrderLog(order, empl);
                dbContext.Orders.ApplyCurrentValues(order);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while stopping the cylinder production", ex);
            }
        }

        //Tin(7-Jan-2012)
        public void changeCylinderStep(Cylinder cylinderinfo, Employee empl, Step thisStep, Error error, String remark,DateTime starttime,DateTime endtime,int performance_mark,string status,bool isDamage,bool isProductionCompleted=false)
        {
            //Tin updated
            Cylinder cyl = dbContext.Cylinders.Where(c => c.cylinderId == cylinderinfo.cylinderId).SingleOrDefault();
            cyl.workflowId = thisStep.workflowId;
            cyl.stepId = thisStep.stepId; 
            //Tin (8-Jan-2012- 6:30 pm)
            cyl.status = CylinderConst.STATUS_INPROD;
            if (isProductionCompleted)
            {
                cyl.status = CylinderConst.STATUS_COMPLETED;
            }

            //Tin (7-Jan-2012)
            Cylinder_Log cylLog = generateCylinderLog(cyl, empl, thisStep, error, remark,starttime,endtime,performance_mark,status,isDamage);
            dbContext.Cylinder_Log.AddObject(cylLog);

            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        //Tin (7-Jan-2012) added start/end times
        public Cylinder_Log generateCylinderLog(Cylinder cyl, Employee empl, Step thisStep, Error error, String remark,DateTime starttime,DateTime endtime,int performance_mark,string status,bool isDamage)
        {
            //Tin added
            Formula formula = dbContext.Formulae.Where(f => f.stepId.Equals(thisStep.stepId) & f.isactive == true).FirstOrDefault();
            if (formula == null)
            {
                formula = new Formula();
                formula.coef1 = 0;
                formula.coef2 = 0;
                formula.coef3 = 0;
                formula.coef4 = 0;
                formula.formula1 = "";
            }
            Cylinder_Log cylLog = new Cylinder_Log();
            if (empl != null)
            {
                cylLog.created_by = empl.surname + " " + empl.given_name;
                cylLog.employeeId = empl.employeeId;
                //Tin , no need to retrived
                //cylLog.dept_name = dbContext.Departments.Where(d => d.departmentId.Equals(empl.departmentId)).FirstOrDefault().name;
                cylLog.dept_name = empl.Department.name;
            }
            else
            {
                cylLog.created_by = "system";
                cylLog.dept_name = thisStep.Workflow.Department.name;
            }
            cylLog.cylinderId = cyl.cylinderId;
            cylLog.cylinderlogId = Guid.NewGuid();
            
            
            cylLog.end_time = endtime;
            cylLog.formula =formula.formula1.ToString()+ ",coef1=" + formula.coef1.ToString() + "," + "coef2=" + formula.coef2.ToString() + "," + "coef3=" + formula.coef3.ToString() + ","
                             + "coef4=" + formula.coef4.ToString();
            cylLog.mark = performance_mark;
            cylLog.remark = remark;
            cylLog.start_time = starttime;
            cylLog.status = status;
            cylLog.error_desc = "";//Tin added
            //Tin (7-jan-2012)
            if (error != null)
            {
                cylLog.error_desc = error.name;
                if (isDamage)
                {
                    cylLog.status = CylinderConst.LOG_STS_ERR_DAMAGE;
                }
                else
                {
                    cylLog.status = CylinderConst.LOG_STS_ERR_PREVIOUS;
                }
            }

            cylLog.stepId = thisStep.stepId;

            return cylLog;
        }
        //Tin updated
        public void changeCylinderWorkflow(Cylinder cylinderinfo, Employee empl, Step WorkflowStartingNode, Error error, String remark) 
        {
            //Tin updated
            Cylinder cyl = dbContext.Cylinders.Where(c => c.cylinderId == cylinderinfo.cylinderId).SingleOrDefault();
            cyl.workflowId = WorkflowStartingNode.workflowId;
            cyl.stepId  = WorkflowStartingNode.stepId;
            //Tin (8-Jan-20112 6:30 pm)
            cyl.status = CylinderConst.STATUS_INPROD;

            Cylinder_Log cylLog = generateCylinderLog(cyl, empl, WorkflowStartingNode, error, remark, DateTime.Now, DateTime.Now,0,CylinderConst.STATUS_COMPLETED,false);
            dbContext.Cylinder_Log.AddObject(cylLog);

            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public String getCylinderBarCode(String order_code, String colorNo, String cylNo, String coreType)
        {
            //cylinder barcode format: '[order_code]aa+bbc'
            //[order_code]: the barcode of the sales order
            //aa: the number of the cylinder, starts at 01
            //bb: the color number of the cylinder, starts at 01
            //c: the type of cylinder core: 0 for recycled core, 1 for new core, 2 for backup core
            colorNo = (colorNo.Length == 1) ? ("0" + colorNo) : colorNo;
            cylNo = (cylNo.Length == 1) ? ("0" + cylNo) : cylNo;
            
            return order_code + colorNo + "+" + cylNo + coreType;
        }

        //Tin (7-Jan-2012) added parameter to update cylinder status
        public void updateCylinderStatus(Guid orderDetailsID,string CylinderStatus, Employee empl)
        {
            IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.order_detailId.Equals(orderDetailsID));
            if (null != cylinders)
            {
                foreach (Cylinder cylinder in cylinders)
                {
                    if (null != cylinder)
                    {
                        //Tin(7-Jan-2012) changed with variable status
                        cylinder.status = CylinderStatus;
                        cylinder.updated_by = empl.username;
                        cylinder.updated_date = DateTime.Now;
                    }
                }
            }
            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        //tin (8-jan-2012) added
        public bool isValidCylinder(string Barcode)
        {
            bool isValid = true;

            Cylinder cylinder = dbContext.Cylinders.Where(c => c.barcode.Equals(Barcode)).SingleOrDefault();

            if (cylinder == null)
            {
                isValid = false;
            }

            return isValid;
        }

        public IQueryable<Cylinder_Log> getCylinderLogs(Guid cylinderId)
        {
            return dbContext.Cylinder_Log.Where(cl => cl.cylinderId.Equals(cylinderId)).OrderByDescending(cl => cl.start_time);
        }
    }
}
