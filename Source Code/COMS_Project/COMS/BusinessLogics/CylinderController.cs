using System;
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
        private static int ISACTIVE = 1;
        private static int NOTACTIVE = 0;

        public void changeCylinderPriority(Cylinder cylinder)
        {
            try
            {
                if (null != cylinder && null != dbContext)
                {
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinder.cylinderId));
                    if (null != cylinders)
                    {
                        foreach (Cylinder s in cylinders)
                        {
                            if (null != s)
                                s.priority = cylinder.priority;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while updating the cylinder " + cylinder.cylinderId + "'s priority "+ex.Message);
            }
        }
        private void create(String ordercode)
        {
            try
            {
                SalesOrderController soc = new SalesOrderController();
                if (null != soc)
                {
                    Order newOrder = soc.retrieveSalesOrder(ordercode);
                    if (null != newOrder)
                    {
                        foreach (Order_Detail od in newOrder.Order_Detail)
                        {
                            generateCylinder(od);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating the cylinder " + ex.Message);
            }
        }

        private void generateCylinder(Order_Detail orderDetail)
        {
            try
            {
                if (null != orderDetail && null != dbContext)
                {
                    for (int i = 0; i < orderDetail.quantity; i++)
                    {

                        Guid generatedId = new Guid();
                        Cylinder newCylinder = new Cylinder();
                        newCylinder.area = (decimal)orderDetail.area;
                        newCylinder.barcode = generatedId.ToString();
                        newCylinder.created_by = orderDetail.created_by;
                        newCylinder.created_date = orderDetail.created_date;
                        newCylinder.cylinderId = generatedId;
                        newCylinder.diameter = (decimal)orderDetail.diameter;
                        newCylinder.length = (decimal)orderDetail.length;
                        newCylinder.priority = 0;
                        newCylinder.status = NOTACTIVE;
                        newCylinder.updated_by = orderDetail.updated_by;
                        newCylinder.updated_date = orderDetail.updated_date;
                        newCylinder.order_detailId = orderDetail.order_detailId;
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while generating the cylinder " + ex.Message);
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
                throw new Exception("Sorry, there is an error occured while retrieving the cylinder list from the database. " + ex.Message);
            }
            return null;
        }

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
                                s.status = ISACTIVE;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while starting production for the cylinder: " + cylinderID +" "+ex.Message);
            }
        }

        public void stopProduction(String cylinderID)
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
                throw new Exception("Sorry, there is an error occured while stopping production for the cylinder: " + cylinderID + " " + ex.Message);
            }
        }
		
    }
}
