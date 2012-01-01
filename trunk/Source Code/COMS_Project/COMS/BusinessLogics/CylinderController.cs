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
        public const String CORETYPE_NEW = "1";
        public const String CORETYPE_USED = "0";
        public const String CORETYPE_BACKUP = "2";

        public const String STATUS_INPROD = "INPROD";
        public const String STATUS_STOPPED = "STOPPED";
        public const String STATUS_COMPLETED = "COMP";
    }
    public class CylinderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public void create(String ordercode, Guid workflowID)
        {
            try
            {
                if (null != ordercode && null != workflowID && !ordercode.Equals(""))
                {
                    SalesOrderController soc = new SalesOrderController();
                    if (null != soc)
                    {
                        Order order = soc.retrieveSalesOrder(ordercode);
                        if (null != order)
                        {
                            foreach (Order_Detail od in order.Order_Detail)
                            {
                                generateCylinder(od, workflowID);
                            }

                            dbContext.GetObjectByKey(order.EntityKey);
                            order.status = OrderConst.STATUS_INPROD;
                            dbContext.Orders.ApplyCurrentValues(order);
                            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                        }
                    }
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
                    for (int i = 0; i < (orderDetail.new_cyl_count + orderDetail.used_cyl_count); i++)
                    {

                        Guid generatedId = Guid.NewGuid(); ;
                        Cylinder newCylinder = new Cylinder();
                        newCylinder.barcode = generatedId.ToString();
                        newCylinder.created_by = orderDetail.created_by;
                        newCylinder.created_date = orderDetail.created_date;
                        newCylinder.cylinderId = generatedId;
                        newCylinder.length = (decimal)orderDetail.cyl_length;
                        newCylinder.diameter = (decimal)orderDetail.cyl_diameter;
                        newCylinder.status = CylinderConst.STATUS_INPROD;
                        newCylinder.updated_by = orderDetail.updated_by;
                        newCylinder.updated_date = orderDetail.updated_date;
                        newCylinder.order_detailId = orderDetail.order_detailId;
                        newCylinder.workflowId = workflowID;
                        dbContext.Cylinders.AddObject(newCylinder);
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

        public void stopProduction(Order order)
        {
            try
            {
                if(null!= order && null!=dbContext){

                    foreach (Order_Detail od in order.Order_Detail)
                    {
                        updateCylinderStatus(od.order_detailId);
                    }
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while stopping the cylinder production", ex);
            }
        }

        public void changeCylinderStep(Guid cylinderId, Guid nextStepId, Error error)
        {

        }

        public void changeCylinderWorkflow(Guid cylinderId, Guid nextWorkflowId, Error error) 
        {

        }

        public String getNextCylinderBarCode(Order order, Cylinder cylinder)
        {
            //cylinder barcode format: '[order_code]aa+bbc'
            //[order_code]: the barcode of the sales order
            //aa: the number of the cylinder, starts at 01
            //bb: the color number of the cylinder, starts at 01
            //c: the type of cylinder core: 0 for recycled core, 1 for new core, 2 for backup core
            String nextCylBc = "";

            return nextCylBc;
        }

        public void updateCylinderStatus(Guid orderDetailsID)
        {
            IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.order_detailId.Equals(orderDetailsID));
            if (null != cylinders)
            {
                foreach (Cylinder cylinder in cylinders)
                {
                    if (null != cylinder)
                        cylinder.status = CylinderConst.STATUS_STOPPED;
                }
            }
            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }
    }
}
