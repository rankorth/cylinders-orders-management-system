using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;
using System.Data.Objects;

namespace BusinessLogics
{
    public class OrderConst
    {
        public const String STATUS_NEW = "NEW";
        public const String STATUS_INPROD = "PROD";
        public const String STATUS_CANCELLED = "CNL";
        
        public const String PRIORITY_LOW = "LOW";
        public const String PRIORITY_MEDIUM = "MED";
        public const String PRIORITY_HIGH = "HIGH";

        public const String ORDERTYPE_NEW = "NEW";
        public const String ORDERTYPE_REDO = "REDO";
    }

    class SalesOrderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public void createSalesOrder(Order order)
        {
            try
            {
                order.orderId = Guid.NewGuid(); //generate new guid as primary key.
                order.status = OrderConst.STATUS_NEW;
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
            //TODO: compare order with dbOrder
            //if cylinders already started production then cannot update, has to cancel order and create a new one
            if (order.status.Equals(OrderConst.STATUS_INPROD))
            {
                dbContext.Refresh(RefreshMode.StoreWins, order);
                throw new Exception("Order already in production, cannot update");
            }
            else if (order.status.Equals(OrderConst.STATUS_CANCELLED))
            {
                dbContext.Refresh(RefreshMode.StoreWins, order);
                throw new Exception("Order already cancelled, cannot update");
            }
            {
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
        }

        public void deleteSpecificOrder(Order order)
        {
            try
            {
                order.status = OrderConst.STATUS_CANCELLED;
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while deleting sales order", ex);
            }
        }

        public String getNextOrderBarCode()
        {
            //order barcode format: 'nnnn-Myy'
            //nnnn: the th order of the month, starts at 0001
            //M: the current month, starts at 1(Jan), 2(Feb),...,0(Oct), A(Nov), B(Dec)
            //yy: the current year, '11' for 2011.
            String nextOrderBarCode = "";

            return nextOrderBarCode;
        }
    }
}
