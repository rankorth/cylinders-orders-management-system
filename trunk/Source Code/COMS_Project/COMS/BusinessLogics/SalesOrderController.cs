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

        public const String SEARCHTYPE_ORDERCODE = "order_code";
        public const String SEARCHTYPE_CYL_CODE = "cyl_code";
        public const String SEARCHTYPE_SETCODE = "set_code";
        public const String SEARCHTYPE_PROD_NAME = "product_name";

        public const String CORETYPE_NEW = "NEW";
        public const String CORETYPE_OLD = "OLD";

        public const String EM_LOC_1SIDE = "1SIDE";
        public const String EM_LOC_2SIDE = "2SIDE";
        public const String EM_LOC_TOPDOWN = "TOPDOWN";
        public const String EM_LOC_BOTTOM = "BOTTOM";

        public const String KEYHOLE_STANDARD = "STD";
        public const String KEYHOLE_OTHER = "OTHER";

        public const String PRINTMETHOD_SURFACE = "SRF";
        public const String PRINTMETHOD_REVERSE = "RVS";

        public const String REGMARK_STANDARD = "STD";

        public const String SPLITLINE_2SIDE = "2SIDE";
        public const String SPLITLINE_1SIDE = "1SIDE";

        public const String RESULT_FROM_GRAPHIC = "GRAPHIC";
        public const String RESULT_FROM_SAMPLE = "SAMPLE";
        public const String RESULT_FROM_FINGERPRINT = "FP";

        public const String CHANGEFILE_YES = "CHANGE FILE";
        public const String CHANGEFILE_NO = "NEW FILE";
    }

    class SalesOrderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public void createSalesOrder(Order order)
        {
            try
            {
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

        public IQueryable<Order> getSalesOrders(String searchKey, String searchType)
        {
            if (String.IsNullOrEmpty(searchKey) || String.IsNullOrEmpty(searchType))
            {
                return dbContext.Orders;
            }
            else if (OrderConst.SEARCHTYPE_ORDERCODE.Equals(searchType))
            {
                return dbContext.Orders.Where(o => o.order_code.IndexOf(searchKey) > -1);
            }
            else if (OrderConst.SEARCHTYPE_CYL_CODE.Equals(searchType))
            {
                Cylinder cyl = dbContext.Cylinders.Where(c => c.barcode.IndexOf(searchKey) > -1).FirstOrDefault();
                if (cyl != null)
                {
                    List<Order> orderList = new List<Order>();
                    orderList.Add(cyl.Order_Detail.Order);
                    return orderList.AsQueryable<Order>();
                }
            }
            else if (OrderConst.SEARCHTYPE_SETCODE.Equals(searchType))
            {
                return dbContext.Orders.Where(o => o.set_code.IndexOf(searchKey) > -1);
            }
            else if (OrderConst.SEARCHTYPE_PROD_NAME.Equals(searchType))
            {
                return dbContext.Orders.Where(o => o.product_name.IndexOf(searchKey) > -1);
            }
            return null;
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
            String nextOrderBarCode = "0001-112";

            return nextOrderBarCode;
        }

        public List<Cylinder> getAllCylinders(String order_code) 
        {
            return null;
        }
    }
}
