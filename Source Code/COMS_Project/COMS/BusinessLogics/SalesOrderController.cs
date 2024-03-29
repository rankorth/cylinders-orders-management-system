﻿using System;
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
        public const String STATUS_UPDATED = "UPD";
        public const String STATUS_SENT_TO_GRPH = "STG";
        public const String STATUS_GRPH_EDITED = "GE";
        public const String STATUS_GRPH_VERIFIED = "GV";
        //public const String STATUS_SENT_TO_MECH = "STM"; //switch to using STATUS_INPROD
        public const String STATUS_INPROD = "PROD";
        public const String STATUS_STOPPED = "STOP";
        public const String STATUS_DELETED = "DL";

        public static Dictionary<String, String> StatusesToStartProd = new Dictionary<String, String>()
        {
            {STATUS_NEW,""}, {STATUS_UPDATED,""}, {STATUS_SENT_TO_GRPH,""}, 
            {STATUS_GRPH_EDITED,""}, {STATUS_GRPH_VERIFIED,""}, {STATUS_STOPPED,""}
        };
        public static Dictionary<String, String> StatusesToStopProd = new Dictionary<String, String>()
        {
            {STATUS_INPROD,""}
        };
        public static Dictionary<String, String> StatusesToUpdate = new Dictionary<String, String>()
        {
            {STATUS_NEW,""}, {STATUS_UPDATED,""}, {STATUS_SENT_TO_GRPH,""}, 
            {STATUS_GRPH_EDITED,""}, {STATUS_GRPH_VERIFIED,""}
        };
        public static Dictionary<String, String> DispStatusDict = new Dictionary<String, String>()
        {
            {STATUS_NEW,"New"}, {STATUS_UPDATED,"Updated"}, {STATUS_SENT_TO_GRPH,"Sent To Graphic"}, 
            {STATUS_GRPH_EDITED,"Graphics Edited"}, {STATUS_GRPH_VERIFIED,"Graphics Verified"},
            {STATUS_INPROD,"In Production"}, {STATUS_STOPPED,"Stopped Production"}, {STATUS_DELETED,"Deleted"}
        };

        public const String PRIORITY_LOW = "LOW";
        public const String PRIORITY_MEDIUM = "MED";
        public const String PRIORITY_HIGH = "HIGH";

        public const String ORDERTYPE_NEW = "NEW";
        public const String ORDERTYPE_REDO = "REDO";

        public const String SEARCHTYPE_ORDERCODE = "order_code";
        public const String SEARCHTYPE_CYL_CODE = "cyl_code";
        public const String SEARCHTYPE_SETCODE = "set_code";
        public const String SEARCHTYPE_PROD_NAME = "product_name";

        public const String CORETYPE_NEW = "1";
        public const String CORETYPE_USED = "0";
        public const String CORETYPE_BACKUP = "2";

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

    public class SalesOrderController
    {
        private COMSEntities dbContext = new COMSEntities();

        public void createSalesOrder(Order order, Employee empl)
        {
            try
            {
                order.status = OrderConst.STATUS_SENT_TO_GRPH; 
                dbContext.Orders.AddObject(order);

                //save an Order_Log entry
                createOrderLog(order, empl);

                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while saving sales order", ex);
            }
        }

        //method to return the workflow for an order status
        private Workflow getWfForOrderStatus(String status)
        {
            if (status == null || dbContext == null) return null;

            if (OrderConst.STATUS_SENT_TO_GRPH.Equals(status))
            {
                return dbContext.Workflows.Where(w => w.name.IndexOf(DeptConst.DEPT_SALES) != -1 && w.name.IndexOf(DeptConst.DEPT_GRAPHIC) != -1).SingleOrDefault();
            }
            else if (OrderConst.STATUS_INPROD.Equals(status) || OrderConst.STATUS_STOPPED.Equals(status) || OrderConst.STATUS_DELETED.Equals(status))
            {
                return dbContext.Workflows.Where(w => w.name.IndexOf(DeptConst.DEPT_SALES) != -1 && w.name.IndexOf(DeptConst.DEPT_MECHANICAL) != -1).SingleOrDefault();
            }
            else if (OrderConst.STATUS_GRPH_EDITED.Equals(status) || OrderConst.STATUS_GRPH_VERIFIED.Equals(status))
            {
                return dbContext.Workflows.Where(w => w.name.IndexOf(DeptConst.DEPT_GRAPHIC) != -1 && w.name.IndexOf(DeptConst.DEPT_ENGRAVING) != -1).SingleOrDefault();
            }

            return null;
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

        public void updateSalesOrder(Order order, Employee empl)
        {
            Order dbOrder = retrieveSalesOrder(order.orderId);

            //if cylinders already started production then cannot update, has to cancel order and create a new one
            if (dbOrder.status.Equals(OrderConst.STATUS_INPROD))
            {
                dbContext.Refresh(RefreshMode.StoreWins, order);
                throw new Exception("Order already in production, cannot update");
            }
            else if (dbOrder.status.Equals(OrderConst.STATUS_DELETED))
            {
                dbContext.Refresh(RefreshMode.StoreWins, order);
                throw new Exception("Order already cancelled, cannot update");
            }
            else
            {
                //save an Order_Log entry
                createOrderLog(order, empl);

                //copy order to dbOrder and update
                copyOrder(order, dbOrder);
                Order_Detail dbOrderDetail = dbOrder.Order_Detail.SingleOrDefault();
                Order_Detail orderDetail = order.Order_Detail.SingleOrDefault();
                copyOrderDetail(orderDetail, dbOrderDetail);

                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
        }

        //for update method, copy data in one order object to another
        private void copyOrder(Order src, Order dest)
        {
            //if DB values are not stored in web form, they will be overwritten with null
            //so don't update those fields to DB
            dest.belong_to_set = src.belong_to_set;
            dest.created_by = src.created_by;
            dest.created_date = src.created_date;
            dest.customer_id = src.customer_id;
            dest.customer_rep = src.customer_rep;
            dest.cylinder_type = src.cylinder_type;
            dest.delivery_date = src.delivery_date;
            dest.old_core = src.old_core;
            dest.old_order_code = src.old_order_code;
            dest.order_code = src.order_code;
            dest.order_type = src.order_type;
            dest.orderId = src.orderId;
            dest.price_type = src.price_type;
            dest.priority = src.priority;
            dest.product_name = src.product_name;
            dest.redo_pct = src.redo_pct;
            dest.set_code = src.set_code;
            dest.updated_by = src.updated_by;
            dest.updated_date = src.updated_date;

            dest.status = src.status;
        }

        //for update method, copy one order_detail object to another
        private void copyOrderDetail(Order_Detail src, Order_Detail dest)
        {
            //if DB values are not stored in web form, they will be overwritten with null
            //so don't update those fields to DB
            dest.changes = src.changes;
            dest.circum_dir_repeat = src.circum_dir_repeat;
            dest.color_count = src.color_count;
            dest.color_list = src.color_list;
            dest.core_type = src.core_type;
            dest.created_by = src.created_by;
            dest.created_date = src.created_date;
            //dest.cut_core_result = src.cut_core_result;
            dest.cyl_diameter = src.cyl_diameter;
            dest.cyl_length = src.cyl_length;
            dest.eyemark_color = src.eyemark_color;
            dest.eyemark_height = src.eyemark_height;
            dest.eyemark_location = src.eyemark_location;
            dest.eyemark_sign = src.eyemark_sign;
            dest.eyemark_width = src.eyemark_width;
            //dest.graphic_done_date = src.graphic_done_date;
            dest.img_orientation = src.img_orientation;
            dest.keyhole_angle = src.keyhole_angle;
            dest.keyhole_inner_dia = src.keyhole_inner_dia;
            dest.keyhole_keyway = src.keyhole_keyway;
            dest.keyhole_outer_dia = src.keyhole_outer_dia;
            dest.keyhole_type = src.keyhole_type;
            dest.length_dir_repeat = src.length_dir_repeat;
            dest.new_cyl_count = src.new_cyl_count;
            dest.order_detailId = src.order_detailId;
            dest.orderId = src.orderId;
            dest.print_material = src.print_material;
            dest.print_method = src.print_method;
            dest.prod_height_stretch = src.prod_height_stretch;
            dest.prod_print_height = src.prod_print_height;
            dest.prod_print_width = src.prod_print_width;
            dest.prod_width_stretch = src.prod_width_stretch;
            dest.reg_mark_type = src.reg_mark_type;
            dest.result_based_on = src.result_based_on;
            //dest.sent_to_mech_date = src.sent_to_mech_date;
            dest.splitline_color = src.splitline_color;
            dest.splitline_size = src.splitline_size;
            dest.splitline_type = src.splitline_type;
            dest.updated_by = src.updated_by;
            dest.updated_date = src.updated_date;
            dest.used_cyl_count = src.used_cyl_count;
            dest.web_print_width = src.web_print_width;
            dest.web_total_width = src.web_total_width;
        }

        public void createOrderLog(Order order, Employee empl)
        {
            //save an Order_Log entry
            Order_Log log = new Order_Log();
            log.id = Guid.NewGuid();
            log.order_status = order.status;
            log.orderId = order.orderId;
            log.related_cyl = null;
            log.remarks = null;
            log.updated_by = empl.username;
            log.updated_date = DateTime.Now;
            Workflow workflow = getWfForOrderStatus(order.status);
            log.workflowId = workflow.workflowId;
            log.dept_name = workflow.Department.name;
            dbContext.Order_Log.AddObject(log);
            dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public void deleteSpecificOrder(Guid orderId, Employee empl)
        {
            try
            {
                Order dbOrder = dbContext.Orders.Where(o => o.orderId.Equals(orderId)).SingleOrDefault();
                dbOrder.status = OrderConst.STATUS_DELETED;
                createOrderLog(dbOrder, empl);
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
            int sequence = GenerateNextSequenceID();
            if (sequence / 10 == 0) //1-digit
                nextOrderBarCode = "000" + sequence;
            else if (sequence / 100 == 0) //2-digit
                nextOrderBarCode = "00" + sequence;
            else if (sequence / 1000 == 0) //3-digit
                nextOrderBarCode = "0" + sequence;
            else
                nextOrderBarCode = "" + (sequence % 10000);

            nextOrderBarCode += "-";
            switch (DateTime.Today.Month)
            {
                case 10: nextOrderBarCode += "0";
                    break;
                case 11: nextOrderBarCode += "A";
                    break;
                case 12: nextOrderBarCode += "B";
                    break;
                default: nextOrderBarCode += "" + DateTime.Today.Month;
                    break;
            }
            
            //add the last 2 digits of current year to order_code
            nextOrderBarCode += "" + (DateTime.Today.Year % 100);

            return nextOrderBarCode;
        }

        public List<Cylinder> getAllCylinders(String order_code)
        {
            List<Cylinder> listOfCylinders = new List<Cylinder>();
            try
            {
                Order order = retrieveSalesOrder(order_code);
                if (null != order)
                {
                    foreach (Order_Detail od in order.Order_Detail)
                    {
                        IQueryable<Cylinder> cylinders = (new CylinderController()).retrieveCylinderList(od.order_detailId);
                        if (null != cylinders)
                        {
                            foreach (Cylinder cylinder in cylinders)
                            {
                                listOfCylinders.Add(cylinder);
                            }
                        }
                    }
                }
                return listOfCylinders;
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving cylinder information for the order code", ex);
            }
        }

        public int GenerateNextSequenceID()
        {
            return Convert.ToInt32( dbContext.GenerateNewID().First().SequenceCode);
        }

        public IQueryable<Order_Log> getOrderLogs(Guid orderId)
        {
            return dbContext.Order_Log.Where(ol => ol.orderId.Equals(orderId)).OrderByDescending(ol => ol.updated_date);
        }
    }
}
