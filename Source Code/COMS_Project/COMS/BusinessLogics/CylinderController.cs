﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class CylinderController
    {
        private COMSEntities dbContext = new COMSEntities();
        private static int ACTIVE = 1;
        private static int NOTACTIVE = 0;
        private static int STATUS_INPROD = 2;

        public void changeCylinderPriority(Guid cylinder_id, int priority)
        {
            try
            {
                if (null != cylinder_id && null != dbContext && priority >=0)
                {
                    Cylinder cylinder = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinder_id)).SingleOrDefault();
                    if (null != cylinder)
                    {
                        cylinder.priority = priority;
                        dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while updating the cylinder " + cylinder_id + "'s priority ", ex);
            }
        }
        public void create(String ordercode, Guid workflowID)
        {
            try
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
                        order.status = STATUS_INPROD;
                        dbContext.Orders.ApplyCurrentValues(order);
                        dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
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
                if (null != orderDetail && null != dbContext)
                {
                    for (int i = 0; i < orderDetail.no_of_cylinders; i++)
                    {

                        Guid generatedId = Guid.NewGuid(); ;
                        Cylinder newCylinder = new Cylinder();
                        newCylinder.area = (decimal)orderDetail.cylinder_area;
                        newCylinder.barcode = generatedId.ToString();
                        newCylinder.created_by = orderDetail.created_by;
                        newCylinder.created_date = orderDetail.created_date;
                        newCylinder.cylinderId = generatedId;
                        newCylinder.circumference = (decimal)orderDetail.cylinder_circumference;
                        newCylinder.length = (decimal)orderDetail.cylinder_length;
                        newCylinder.priority = 0;
                        newCylinder.status = ACTIVE;
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
/*
 * //To be confirmed-Do not delete
        public void startProduction(String cylinderID)
        {
            try
            {
                if(null!= cylinderID && null!=dbContext){
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinderID));
                    if(null!=cylinders){
                        foreach (Cylinder s in cylinders)
                        {
                            if (null != s)
                                s.status = ACTIVE;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while starting production for the cylinder: " + cylinderID, ex);
            }
        }
*/
        public void stopProduction(Guid cylinderID)
        {
            try
            {
                if(null!= cylinderID && null!=dbContext){
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinderID));
                    if(null!=cylinders){
                        foreach (Cylinder s in cylinders)
                        {
                            if(null!=s)
                                s.status = NOTACTIVE;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while stopping production for the cylinder: " + cylinderID, ex);
            }
        }

        public void changeCylinderStep(Guid cylinderId, Guid nextStepId, Error error)
        {

        }
    }
}
