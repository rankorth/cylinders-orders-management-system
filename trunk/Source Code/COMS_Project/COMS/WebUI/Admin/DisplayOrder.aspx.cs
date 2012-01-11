using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;
using WebUI.Common;

namespace WebUI.Admin 
{
    public partial class DisplayOrder : Common.BasePage
    {
        MainController mainCtrl = new MainController();
        const String NAME_NEW = "Add New Order";
        const String NAME_UPDATE = "Display Order";
        public const String MSG_UPDATE_OK = "updateOk";
        public const String MSG_UPDATE_OK_DESC = "Order updated successfully.";
        public const String MSG_CANCEL_OK = "cancelOk";
        public const String MSG_CANCEL_OK_DESC = "Order cancelled successfully.";
        public const String MSG_STARTPROD_OK = "startProdOk";
        public const String MSG_STARTPROD_OK_DESC = "Cylinder production has been started for order ";
        public const String MSG_STOPPROD_OK = "startProdOk";
        public const String MSG_STOPPROD_OK_DESC = "Cylinder production has been stopped for order ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_customers();
                load_priorities();
                if (Request["orderId"] == null)
                {
                    load_new_data();
                    ltrModule_name.Text = NAME_NEW;
                    lnkPrintBarcode.Visible = false; //only allow user to print once order has been saved
                    lnkCancel.Visible = false; //only allow user to cancel order during update
                    lnkStartProd.Visible = false; //only allow user to start production during update
                    lnkStopProd.Visible = false; //only allow user to stop production during update
                }
                else
                {
                    load_data();
                    ltrModule_name.Text = NAME_UPDATE;
                    lnkSave.Text = "Update";
                    lnkPrintBarcode.Visible = true;
                    lnkCancel.Visible = true; //allow user to cancel order during update
                }
            }
        }

        //load customer list into drop down list
        private void load_customers() {
            IQueryable<Customer> customerList = mainCtrl.getAllCustomers();
            foreach (Customer cust in customerList)
            {
                ddlCustomer.Items.Add(new ListItem(cust.fullname, cust.customerid.ToString()));
                ddlCustomerCode.Items.Add(new ListItem(cust.code, cust.customerid.ToString()));
            }
        }

        private void load_priorities()
        {
            ddlPriority.Items.Add(new ListItem("MEDIUM", OrderConst.PRIORITY_MEDIUM));
            ddlPriority.Items.Add(new ListItem("HIGH", OrderConst.PRIORITY_HIGH));
            ddlPriority.Items.Add(new ListItem("LOW", OrderConst.PRIORITY_LOW));
        }

        //load new data into web form
        private void load_new_data()
        {
            txtCreateDate.Text = DateTime.Now.ToShortDateString();
            load_status(NAME_NEW, null);
        }

        //load existing order data into web form
        private void load_data()
        {
            Guid orderId = new Guid((String)Request["orderId"]);
            Order order = mainCtrl.getSalesOrder(orderId);
            display_order(order);
            hdOrderId.Value = orderId.ToString();
            hdOrderCode.Value = order.order_code;
            load_status(NAME_UPDATE, order.status);

            if (OrderConst.statusesToStartProd.ContainsKey(order.status))
            {
                lnkStartProd.Visible = true; //user can start production
                lnkStopProd.Visible = false;
            } 
            else if (OrderConst.statusesToStopProd.ContainsKey(order.status))
            {
                lnkStartProd.Visible = false;
                lnkStopProd.Visible = true; //user can stop production
            }
        }

        //load available statuses to drop down list
        private void load_status(String moduleName, String status)
        {
            //status should be one of the constant string from OrderConst (STATUS_ABC)
            if (NAME_NEW.Equals(moduleName))
            {
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_NEW), OrderConst.STATUS_NEW));
            }
            else if (NAME_UPDATE.Equals(moduleName))
            {
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_UPDATED), OrderConst.STATUS_UPDATED));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_SENT_TO_GRPH), OrderConst.STATUS_SENT_TO_GRPH));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_GRPH_EDITED), OrderConst.STATUS_GRPH_EDITED));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_GRPH_VERIFIED), OrderConst.STATUS_GRPH_VERIFIED));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.getStatusDisp(OrderConst.STATUS_SENT_TO_MECH), OrderConst.STATUS_SENT_TO_MECH));

                ddlOrderStatus.SelectedValue = status;
            }
        }

        //display order data in web form
        private void display_order(Order order)
        {
            ddlCustomer.SelectedValue = order.customer_id.ToString();
            ddlCustomerCode.SelectedValue = ddlCustomer.SelectedValue;
            ddlPriority.SelectedValue = order.priority;
            txtCustomerCode.Text = ddlCustomerCode.SelectedItem.Text;

            txtCustomerRep.Text = order.customer_rep;
            txtProdName.Text = order.product_name;
            txtPriceType.Text = order.price_type;
            txtRedoPct.Text = "" + order.redo_pct;
            chkBxOldCore.Checked = (bool)order.old_core;
            txtDeliveryDate_CalendarExtender.SelectedDate = order.delivery_date;
            txtDeliveryDate.Text = order.delivery_date.ToString();
            rBtnOrderTypeNew.Checked = (order.order_type == OrderConst.ORDERTYPE_NEW);
            txtSetCode.Text = order.set_code;
            txtCylType.Text = order.cylinder_type;
            //order.old_order_code = ???
            ddlPriority.SelectedValue = order.priority;
            txtBelongsToSet.Text = order.belong_to_set;
            txtCreatedBy.Text = order.created_by;
            txtCreateDate.Text = order.created_date.ToString();

            Order_Detail orderDetail = order.Order_Detail.SingleOrDefault();
            chkBxOldCore.Checked = OrderConst.CORETYPE_OLD.Equals(orderDetail.core_type) ? true : false;
            txtProdWidth.Text = "" + orderDetail.prod_print_width;
            txtWidthStretch.Text = "" + orderDetail.prod_width_stretch;
            txtProdHeight.Text = "" + orderDetail.prod_print_height;
            txtHeightStretch.Text = "" + orderDetail.prod_height_stretch;
            txtLengthRepeats.Text = "" + orderDetail.length_dir_repeat;
            txtCircumRepeats.Text = "" + orderDetail.circum_dir_repeat;
            txtWebPrintWidth.Text = "" + orderDetail.web_print_width;
            txtWebTotalWidth.Text = "" + orderDetail.web_total_width;
            txtCylLength.Text = "" + orderDetail.cyl_length;
            txtCylCircum.Text = "" + (orderDetail.cyl_diameter * (decimal)3.1416);

            chkBxEyeMark.Checked = !String.IsNullOrEmpty(orderDetail.eyemark_color);
            txtEMHeight.Text = "" + orderDetail.eyemark_height;
            txtEMWidth.Text = "" + orderDetail.eyemark_width;
            txtEMColor.Text = orderDetail.eyemark_color;
            txtEMSign.Text = orderDetail.eyemark_sign;

            rBtnEMLoc1Side.Checked = OrderConst.EM_LOC_1SIDE.Equals(orderDetail.eyemark_location);
            rBtnEMLoc2Side.Checked = OrderConst.EM_LOC_2SIDE.Equals(orderDetail.eyemark_location);
            rBtnEMLocTopDown.Checked = OrderConst.EM_LOC_TOPDOWN.Equals(orderDetail.eyemark_location);
            rBtnEMLocBottom.Checked = OrderConst.EM_LOC_BOTTOM.Equals(orderDetail.eyemark_location);

            rBtnKeyHoleStd.Checked = OrderConst.KEYHOLE_STANDARD.Equals(orderDetail.keyhole_type);
            rBtnKeyHoleOther.Checked = !rBtnKeyHoleStd.Checked;
            txtKeyHoleOther.Text = orderDetail.keyhole_type;
            txtKHInnerDia.Text = "" + orderDetail.keyhole_inner_dia;
            txtKHOuterDia.Text = "" + orderDetail.keyhole_outer_dia;
            txtKHAngle.Text = "" + orderDetail.keyhole_angle;
            txtKHKeyway.Text = orderDetail.keyhole_keyway;
            txtColorCount.Text = "" + orderDetail.color_count;
            txtColorList.Text = orderDetail.color_list;

            //the number of cylinders depends on whether old cores are being reused
            txtCylCount.Text = "" + (orderDetail.used_cyl_count + orderDetail.new_cyl_count);

            rBtnMethodSurface.Checked = OrderConst.PRINTMETHOD_SURFACE.Equals(orderDetail.print_method) ? true : false;

            if (OrderConst.REGMARK_STANDARD.Equals(orderDetail.reg_mark_type))
            {
                rBtnRegMarkStd.Checked = true;
                txtRegMarkOther.Text = "";
            }
            else
            {
                rBtnRegMarkStd.Checked = false;
                txtRegMarkOther.Text = orderDetail.reg_mark_type;
            }
            rBtnRegMarkOther.Checked = !rBtnRegMarkStd.Checked;

            chkBxSplitLine.Checked = !String.IsNullOrEmpty(orderDetail.splitline_color);
            txtSplitLineSize.Text = "" + orderDetail.splitline_size;
            chkBxSplitLine2Side.Checked = OrderConst.SPLITLINE_2SIDE.Equals(orderDetail.splitline_type);
            txtSplitLineColor.Text = orderDetail.splitline_color;

            foreach (ListItem item in ddlPrintMaterial.Items)
            {
                if (item.Value.Equals(orderDetail.print_material))
                {
                    item.Selected = true;
                    break;
                }
            }

            //result can be compared with either graphic proof, printing sample or fingerprint
            rBtnResultSample.Checked = OrderConst.RESULT_FROM_SAMPLE.Equals(orderDetail.result_based_on);
            rBtnResultFp.Checked = OrderConst.RESULT_FROM_FINGERPRINT.Equals(orderDetail.result_based_on);
            rBtnResultGraphic.Checked = OrderConst.RESULT_FROM_GRAPHIC.Equals(orderDetail.result_based_on);

            if (rBtnOrientUp.Text.Equals(orderDetail.img_orientation))
            {
                rBtnOrientUp.Checked = true;
            }
            else if (rBtnOrientDown.Text.Equals(orderDetail.img_orientation))
            {
                rBtnOrientDown.Checked = true;
            }
            else if (rBtnOrientLeft.Text.Equals(orderDetail.img_orientation))
            {
                rBtnOrientLeft.Checked = true;
            }
            else if (rBtnOrientRight.Text.Equals(orderDetail.img_orientation))
            {
                rBtnOrientRight.Checked = true;
            }
            else
            {
                txtOrientOther.Text = orderDetail.img_orientation;
            }

            chkBxChangeFile.Checked = OrderConst.CHANGEFILE_YES.Equals(orderDetail.changes);
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Order order = null;
            //Tin 
            //Employee user = (Employee)Session[BasePage.userobj];
            Employee user = base.GetCurentUser();
            if (NAME_NEW.Equals(ltrModule_name.Text)) {
                order = new Order();
                order.orderId = Guid.NewGuid(); //generate new guid as primary key.
                order.order_code = mainCtrl.getNextOrderBarCode();
                order.created_by = txtCreatedBy.Text;
                //order.created_date = Convert.ToDateTime(txtCreateDate_CalendarExtender.SelectedDate);
                order.created_date = Convert.ToDateTime(txtCreateDate.Text);
                populate_order(order, user);

                Order_Detail orderDetail = new Order_Detail();
                orderDetail.order_detailId = Guid.NewGuid();
                orderDetail.orderId = order.orderId;
                orderDetail.created_by = order.created_by;
                orderDetail.created_date = order.created_date;
                populate_orderDetail(order, orderDetail);

                //add orderDetail to order
                order.Order_Detail.Add(orderDetail);

                mainCtrl.createSalesOrder(order, user);
                lblMsg.Text = "Order created successfully. Please click Print Barcode to print out the barcode on the paper order.";
                lblMsg.CssClass = "okMsg";
            }
            else if (NAME_UPDATE.Equals(ltrModule_name.Text))
            {
                order = mainCtrl.getSalesOrder(new Guid(hdOrderId.Value));
                populate_order(order, user);

                Order_Detail orderDetail = order.Order_Detail.SingleOrDefault();
                populate_orderDetail(order, orderDetail);

                mainCtrl.updateSalesOrder(order, user);
                //lblMsg.Text = "Order updated successfully.";
                //lblMsg.CssClass = "okMsg";

                //in update case, need to redirect to ManageOrders.aspx
                Response.Redirect(Common.PageUrls.ManageOrdersPage + "?msg=" + MSG_UPDATE_OK);
            }

            //enable Print Barcode button
            lnkSave.Enabled = false;
            lnkPrintBarcode.Enabled = true;
            lnkPrintBarcode.Attributes.Add("href", "PrintOrderBarcode.aspx?code=" + order.order_code);
            lnkPrintBarcode.Attributes.Add("target", "_blank");
        }

        //convert web form data into order object
        private void populate_order(Order order, Employee user)
        {
            //populate form values into order object
            order.status = ddlOrderStatus.SelectedValue;
            order.customer_id = new Guid(ddlCustomer.SelectedItem.Value);
            order.customer_rep = txtCustomerRep.Text;
            order.product_name = txtProdName.Text;
            order.price_type = txtPriceType.Text;
            order.redo_pct = (txtRedoPct.Text != "") ? Convert.ToInt32(txtRedoPct.Text) : 0;
            order.old_core = chkBxOldCore.Checked;
            //order.delivery_date = Convert.ToDateTime(txtDeliveryDate_CalendarExtender.SelectedDate);
            order.delivery_date = Convert.ToDateTime(txtDeliveryDate.Text);
            order.order_type = (rBtnOrderTypeNew.Checked) ? OrderConst.ORDERTYPE_NEW : OrderConst.ORDERTYPE_REDO;
            order.set_code = txtSetCode.Text;
            order.cylinder_type = txtCylType.Text;
            //order.old_order_code = 
            order.priority = ddlPriority.SelectedItem.Value;
            order.belong_to_set = txtBelongsToSet.Text;
            order.updated_date = DateTime.Now;
            order.updated_by = user.username;
        }

        //convert web form data into order_detail object
        private void populate_orderDetail(Order order, Order_Detail orderDetail)
        {
            //populate form values into orderDetail object
            orderDetail.updated_by = order.updated_by;
            orderDetail.updated_date = order.updated_date;
            
            orderDetail.core_type = (chkBxOldCore.Checked) ? OrderConst.CORETYPE_OLD : OrderConst.CORETYPE_NEW;

            orderDetail.prod_print_width = Convert.ToDecimal(txtProdWidth.Text);
            orderDetail.prod_width_stretch = (txtWidthStretch.Text != "") ? Convert.ToDecimal(txtWidthStretch.Text) : 0;
            orderDetail.prod_print_height = Convert.ToDecimal(txtProdHeight.Text);
            orderDetail.prod_height_stretch = (txtHeightStretch.Text != "") ? Convert.ToDecimal(txtHeightStretch.Text) : 0;
            orderDetail.length_dir_repeat = Convert.ToInt32(txtLengthRepeats.Text);
            orderDetail.circum_dir_repeat = Convert.ToInt32(txtCircumRepeats.Text);
            orderDetail.web_print_width = Convert.ToInt32(txtWebPrintWidth.Text);
            orderDetail.web_total_width = Convert.ToInt32(txtWebTotalWidth.Text);
            orderDetail.cyl_length = Convert.ToDecimal(txtCylLength.Text);
            orderDetail.cyl_diameter = Convert.ToDecimal(txtCylCircum.Text) / Convert.ToDecimal(3.1416);
            if (chkBxEyeMark.Checked)
            {
                orderDetail.eyemark_height = Convert.ToInt32(txtEMHeight.Text);
                orderDetail.eyemark_width = Convert.ToInt32(txtEMWidth.Text);
                orderDetail.eyemark_color = txtEMColor.Text;
                orderDetail.eyemark_sign = txtEMSign.Text;
            }
            if (rBtnEMLoc1Side.Checked)
                orderDetail.eyemark_location = OrderConst.EM_LOC_1SIDE;
            else if (rBtnEMLoc2Side.Checked)
                orderDetail.eyemark_location = OrderConst.EM_LOC_2SIDE;
            else if (rBtnEMLocTopDown.Checked)
                orderDetail.eyemark_location = OrderConst.EM_LOC_TOPDOWN;
            else if (rBtnEMLocBottom.Checked)
                orderDetail.eyemark_location = OrderConst.EM_LOC_BOTTOM;

            if (rBtnKeyHoleStd.Checked)
                orderDetail.keyhole_type = OrderConst.KEYHOLE_STANDARD;
            else if (rBtnKeyHoleOther.Checked)
            {
                if (txtKeyHoleOther.Text != "")
                {
                    orderDetail.keyhole_type = txtKeyHoleOther.Text;
                }
                else
                {
                    orderDetail.keyhole_type = OrderConst.KEYHOLE_OTHER;
                    orderDetail.keyhole_inner_dia = Convert.ToInt32(txtKHInnerDia.Text);
                    orderDetail.keyhole_outer_dia = Convert.ToInt32(txtKHOuterDia.Text);
                    orderDetail.keyhole_angle = Convert.ToInt32(txtKHAngle.Text);
                    orderDetail.keyhole_keyway = txtKHKeyway.Text;
                }
            }
            orderDetail.color_count = Convert.ToInt32(txtColorCount.Text);
            orderDetail.color_list = txtColorList.Text;

            //the number of cylinders depends on whether old cores are being reused
            if (chkBxOldCore.Checked)
            {
                orderDetail.new_cyl_count = 0;
                orderDetail.used_cyl_count = Convert.ToInt32(txtCylCount.Text);
            }
            else
            {
                orderDetail.new_cyl_count = Convert.ToInt32(txtCylCount.Text);
                orderDetail.used_cyl_count = 0;
            }

            orderDetail.print_method = (rBtnMethodSurface.Checked) ? OrderConst.PRINTMETHOD_SURFACE : OrderConst.PRINTMETHOD_REVERSE;

            orderDetail.reg_mark_type = (rBtnRegMarkStd.Checked) ? OrderConst.REGMARK_STANDARD : txtRegMarkOther.Text;

            if (chkBxSplitLine.Checked)
            {
                orderDetail.splitline_size = Convert.ToInt32(txtSplitLineSize.Text);
                orderDetail.splitline_type = (chkBxSplitLine2Side.Checked) ? OrderConst.SPLITLINE_2SIDE : OrderConst.SPLITLINE_1SIDE;
                orderDetail.splitline_color = txtSplitLineColor.Text;
            }
            orderDetail.print_material = ddlPrintMaterial.SelectedItem.Value;

            //result can be compared with either graphic proof, printing sample or fingerprint
            orderDetail.result_based_on = (rBtnResultSample.Checked) ? OrderConst.RESULT_FROM_SAMPLE
                : ((rBtnResultFp.Checked) ? OrderConst.RESULT_FROM_FINGERPRINT : OrderConst.RESULT_FROM_GRAPHIC);

            if (rBtnOrientUp.Checked)
                orderDetail.img_orientation = rBtnOrientUp.Text;
            else if (rBtnOrientDown.Checked)
                orderDetail.img_orientation = rBtnOrientDown.Text;
            else if (rBtnOrientLeft.Checked)
                orderDetail.img_orientation = rBtnOrientLeft.Text;
            else if (rBtnOrientRight.Checked)
                orderDetail.img_orientation = rBtnOrientRight.Text;
            else if (rBtnOrientOther.Checked)
                orderDetail.img_orientation = txtOrientOther.Text;

            orderDetail.changes = (chkBxChangeFile.Checked) ? OrderConst.CHANGEFILE_YES : OrderConst.CHANGEFILE_NO;
        }

        protected void lnkPrintBarcode_Click(object sender, EventArgs e)
        {
        }

        protected void lnkStartProd_Click(object sender, EventArgs e)
        {
            mainCtrl.startCylinderProd(hdOrderCode.Value);

            //in start production case, need to redirect to ManageOrders.aspx
            Response.Redirect(Common.PageUrls.ManageOrdersPage + "?msg=" + MSG_STARTPROD_OK + hdOrderCode.Value);
        }

        protected void lnkStopProd_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            mainCtrl.stopCylinderProd(order);

            //in start production case, need to redirect to ManageOrders.aspx
            Response.Redirect(Common.PageUrls.ManageOrdersPage + "?msg=" + MSG_CANCEL_OK);
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.orderId = new Guid(hdOrderId.Value);
            mainCtrl.deleteSpecificOrder(order);

            //in cancel case, need to redirect to ManageOrders.aspx
            Response.Redirect(Common.PageUrls.ManageOrdersPage + "?msg=" + MSG_CANCEL_OK);
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Common.PageUrls.ManageOrdersPage);
        }
    }
}