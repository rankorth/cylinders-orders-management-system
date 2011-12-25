using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    enum OrderConst
    {
        STATUS_NEW = 1,
        STATUS_INPROD = 2,
        STATUS_CANCELLED = 3;
    }

    class SalesOrderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public static Boolean ISACTIVE_YES = true;
        public static Boolean ISACTIVE_NO = false;

        public void createSalesOrder(Order order)
        {
            try
            {
                order.orderId = Guid.NewGuid(); //generate new guid as primary key.
                order.status = (int)OrderConst.STATUS_NEW;
                dbContext.Orders.AddObject(order);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while saving sales order", ex);
            }
        }

        public Order retrieveSalesOrder(String order_code)
        {
            return dbContext.Orders.Where(o => o.order_code.Equals(order_code)).FirstOrDefault();
        }

        public Order retrieveSalesOrder(Guid orderId)
        {
            return dbContext.Orders.Where(o => o.orderId.Equals(orderId)).FirstOrDefault();
        }

        public void updateSalesOrder(Order order)
        {
            try
            {
                Order dbOrder = retrieveSalesOrder(order.orderId);

                //TODO: compare order with dbOrder
                //if cylinders already started production then cannot update, has to cancel order and create a new one


                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while updating sales order", ex);
            }
        }

        public void deleteSpecificOrder(Guid orderId)
        {
            try
            {
                Order dbOrder = retrieveSalesOrder(orderId);
                dbOrder.isactive = Convert.ToBoolean(OrderConst.ISACTIVE_NO);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while deleting sales order", ex);
            }
        }
    }
}
