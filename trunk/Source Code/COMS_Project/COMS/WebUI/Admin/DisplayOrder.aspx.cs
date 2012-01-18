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
        public const String MSG_DELETE_OK = "deleteOk";
        public const String MSG_CANCEL_OK_DESC = "Order deleted successfully.";
        public const String MSG_STARTPROD_OK = "startProdOk";
        public const String MSG_STARTPROD_OK_DESC = "Cylinder production has been started for order ";
        public const String MSG_STOPPROD_OK = "stopProdOk";
        public const String MSG_STOPPROD_OK_DESC = "Cylinder production has been stopped for order ";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                Authorize();
                txtCreateDate.Attributes.Add("readonly", "readonly");
                txtDeliveryDate.Attributes.Add("readonly", "readonly");
                load_customers();
                load_priorities();
                load_coreType();
                if (Request["orderId"] == null)
                {
                    load_new_data();
                    ltrModule_name.Text = NAME_NEW;
                    lnkPrintBarcode.Visible = false; //only allow user to print once order has been saved
                    lnkStartProd.Visible = false; //only allow user to start production during update
                    lnkStopProd.Visible = false; //only allow user to stop production during update
                    lnkDelete.Visible = false; //only allow user to stop production during update
                }
                else
                {
                    load_data();
                    ltrModule_name.Text = NAME_UPDATE;
                    lnkSave.Text = "Update";
                    lnkPrintBarcode.Visible = true;
                }
            }
        }

        //Tin 14-01-2012
        private void Authorize()
        {
            lnkSave.Visible = lnkStartProd.Visible = lnkStopProd.Visible = base.CheckPermission(Common.Permission.ModuleName_Order, Common.Permission.Action_Edit);
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

        private void load_coreType()
        {
            ddlCoreType.Items.Add(new ListItem("NEW", OrderConst.CORETYPE_NEW));
            ddlCoreType.Items.Add(new ListItem("USED", OrderConst.CORETYPE_USED));
            ddlCoreType.Items.Add(new ListItem("BACKUP", OrderConst.CORETYPE_BACKUP));
        }

        //load new data into web form
        private void load_new_data()
        {
            txtCreateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

            //check whether this order can start/stop production for this order
            if (OrderConst.StatusesToStartProd.ContainsKey(order.status))
            {
                lnkStartProd.Visible = true; //user can start production
                lnkStopProd.Visible = false;
            } 
            else if (OrderConst.StatusesToStopProd.ContainsKey(order.status))
            {
                lnkStartProd.Visible = false;
                lnkStopProd.Visible = true; //user can stop production
            }
            //create Print Barcode button
            lnkPrintBarcode.Attributes.Add("href", "/Admin/PrintOrderBarcode.aspx?code=" + order.order_code);
            lnkPrintBarcode.Attributes.Add("target", "_blank");
        }

        //load available statuses to drop down list
        private void load_status(String moduleName, String status)
        {
            //status should be one of the constant string from OrderConst (STATUS_ABC)
            if (NAME_NEW.Equals(moduleName))
            {
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_NEW], OrderConst.STATUS_NEW));
            }
            else if (NAME_UPDATE.Equals(moduleName))
            {
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_UPDATED], OrderConst.STATUS_UPDATED));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_SENT_TO_GRPH], OrderConst.STATUS_SENT_TO_GRPH));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_GRPH_EDITED], OrderConst.STATUS_GRPH_EDITED));
                ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_GRPH_VERIFIED], OrderConst.STATUS_GRPH_VERIFIED));

                //only show INPROD and DELETED status if order is already INPROD or DELETED
                if (OrderConst.StatusesToStartProd.ContainsKey(status) == false)
                {
                    ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_INPROD], OrderConst.STATUS_INPROD));
                    ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_STOPPED], OrderConst.STATUS_STOPPED));
                    ddlOrderStatus.Items.Add(new ListItem(OrderConst.DispStatusDict[OrderConst.STATUS_DELETED], OrderConst.STATUS_DELETED));
                }

                //don't allow update for certain statuses (INPROD, CANCELLED)
                if (OrderConst.StatusesToUpdate.ContainsKey(status) == false)
                {
                    lnkSave.Visible = false;
                }
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
            txtDeliveryDate_CalendarExtender.SelectedDate = order.delivery_date;
            txtDeliveryDate.Text = order.delivery_date.ToString();
            rBtnOrderTypeNew.Checked = (order.order_type == OrderConst.ORDERTYPE_NEW);
            txtSetCode.Text = order.set_code;
            txtCylType.Text = order.cylinder_type;
            //order.old_order_code = 
            ddlPriority.SelectedValue = order.priority;
            txtBelongsToSet.Text = order.belong_to_set;
            txtCreatedBy.Text = order.created_by;
            txtCreateDate.Text = order.created_date.ToString();

            Order_Detail orderDetail = order.Order_Detail.SingleOrDefault();
            ddlCoreType.SelectedValue = orderDetail.core_type;
            txtProdWidth.Text = "" + orderDetail.prod_print_width;
            txtWidthStretch.Text = "" + orderDetail.prod_width_stretch;
            txtProdHeight.Text = "" + orderDetail.prod_print_height;
            txtHeightStretch.Text = "" + orderDetail.prod_height_stretch;
            txtLengthRepeats.Text = "" + orderDetail.length_dir_repeat;
            txtCircumRepeats.Text = "" + orderDetail.circum_dir_repeat;
            txtWebPrintWidth.Text = "" + orderDetail.web_print_width;
            txtWebTotalWidth.Text = "" + orderDetail.web_total_width;
            txtCylLength.Text = "" + orderDetail.cyl_length;
            txtCylCircum.Text = Math.Round((double)orderDetail.cyl_diameter * Math.PI, 2).ToString();

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

            ddlPrintMaterial.SelectedValue = orderDetail.print_material;

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
            try
            {
                Order order = null;
                //Tin 
                Employee user = base.GetCurentUser();
                if (NAME_NEW.Equals(ltrModule_name.Text))
                {
                    order = new Order();
                    order.orderId = Guid.NewGuid(); //generate new guid as primary key.
                    order.order_code = mainCtrl.getNextOrderBarCode();
                    order.created_by = txtCreatedBy.Text;
                    //order.created_date = Convert.ToDateTime(txtCreateDate_CalendarExtender.SelectedDate);
                    //order.created_date = Convert.ToDateTime(txtCreateDate.Text);
                    order.created_date = DateTime.ParseExact(txtCreateDate.Text, "dd/MM/yyyy", null);
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
                    //create Print Barcode button
                    lnkPrintBarcode.Visible = true;
                    lnkPrintBarcode.Attributes.Add("href", "/Admin/PrintOrderBarcode.aspx?code=" + order.order_code);
                    lnkPrintBarcode.Attributes.Add("target", "_blank");
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
                    Response.Redirect(Common.PageUrls.ManageOrdersPage + "?" + ManageOrders.REQ_MSG + "=" + MSG_UPDATE_OK);
                }

                lnkSave.Enabled = false;
                Common.Utility.ShowMessage("Order has been placed successfully", Page);
            }
            catch (Exception ex)
            {
                Common.Utility.ShowMessage("System error occured, please contact system administrator", Page);
            }
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
            order.redo_pct = (txtRedoPct.Text != "") ? Convert.ToDecimal(txtRedoPct.Text) : 0;
            //order.delivery_date = Convert.ToDateTime(txtDeliveryDate_CalendarExtender.SelectedDate);
            //order.delivery_date = Convert.ToDateTime(txtDeliveryDate.Text);
            order.delivery_date = DateTime.ParseExact(txtDeliveryDate.Text, "dd/MM/yyyy", null);
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

            orderDetail.core_type = ddlCoreType.SelectedValue;

            orderDetail.prod_print_width = Convert.ToDecimal(txtProdWidth.Text);
            orderDetail.prod_width_stretch = (txtWidthStretch.Text != "") ? Convert.ToDecimal(txtWidthStretch.Text) : 0;
            orderDetail.prod_print_height = Convert.ToDecimal(txtProdHeight.Text);
            orderDetail.prod_height_stretch = (txtHeightStretch.Text != "") ? Convert.ToDecimal(txtHeightStretch.Text) : 0;
            orderDetail.length_dir_repeat = Convert.ToDecimal(txtLengthRepeats.Text);
            orderDetail.circum_dir_repeat = Convert.ToDecimal(txtCircumRepeats.Text);
            orderDetail.web_print_width = Convert.ToDecimal(txtWebPrintWidth.Text);
            orderDetail.web_total_width = Convert.ToDecimal(txtWebTotalWidth.Text);
            orderDetail.cyl_length = Convert.ToDecimal(txtCylLength.Text);
            orderDetail.cyl_diameter = Convert.ToDecimal(txtCylCircum.Text) / Convert.ToDecimal(3.1416);
            if (chkBxEyeMark.Checked)
            {
                orderDetail.eyemark_height = Convert.ToDecimal(txtEMHeight.Text);
                orderDetail.eyemark_width = Convert.ToDecimal(txtEMWidth.Text);
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
                    orderDetail.keyhole_inner_dia = Convert.ToDecimal(txtKHInnerDia.Text);
                    orderDetail.keyhole_outer_dia = Convert.ToDecimal(txtKHOuterDia.Text);
                    orderDetail.keyhole_angle = Convert.ToDecimal(txtKHAngle.Text);
                    orderDetail.keyhole_keyway = txtKHKeyway.Text;
                }
            }
            orderDetail.color_count = Convert.ToDecimal(txtColorCount.Text);
            orderDetail.color_list = txtColorList.Text;

            //the number of cylinders depends on whether old cores are being reused
            if (OrderConst.CORETYPE_USED.Equals(ddlCoreType.SelectedValue))
            {
                orderDetail.new_cyl_count = 0;
                orderDetail.used_cyl_count = Convert.ToDecimal(txtCylCount.Text);
            }
            else
            {
                orderDetail.new_cyl_count = Convert.ToDecimal(txtCylCount.Text);
                orderDetail.used_cyl_count = 0;
            }

            orderDetail.print_method = (rBtnMethodSurface.Checked) ? OrderConst.PRINTMETHOD_SURFACE : OrderConst.PRINTMETHOD_REVERSE;

            orderDetail.reg_mark_type = (rBtnRegMarkStd.Checked) ? OrderConst.REGMARK_STANDARD : txtRegMarkOther.Text;

            if (chkBxSplitLine.Checked)
            {
                orderDetail.splitline_size = Convert.ToDecimal(txtSplitLineSize.Text);
                orderDetail.splitline_type = (chkBxSplitLine2Side.Checked) ? OrderConst.SPLITLINE_2SIDE : OrderConst.SPLITLINE_1SIDE;
                orderDetail.splitline_color = txtSplitLineColor.Text;
            }
            if (ddlPrintMaterial.SelectedIndex != -1)
                orderDetail.print_material = ddlPrintMaterial.SelectedItem.Value;
            else
                orderDetail.print_material = txtPrintMaterialOther.Text;

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
            try
            {
                mainCtrl.startCylinderProd(new Guid(hdOrderId.Value), base.GetCurentUser());
                Common.Utility.ShowMessage("Production has been started now.", Page);
                //in start production case, need to redirect to ManageOrders.aspx
                Response.Redirect(Common.PageUrls.ManageOrdersPage + "?" + ManageOrders.REQ_MSG + "=" + MSG_STARTPROD_OK
                                    + "&" + ManageOrders.REQ_ORDERCODE + "=" + hdOrderCode.Value);
                
            }
            catch (Exception ex)
            {
                Common.Utility.ShowMessage("System error occured, Please contact Administrator", Page);
            }
        }

        protected void lnkStopProd_Click(object sender, EventArgs e)
        {
            try
            {
                mainCtrl.stopCylinderProd(new Guid(hdOrderId.Value), base.GetCurentUser());
                Common.Utility.ShowMessage("Production has been Stopped now.", Page);
                //in start production case, need to redirect to ManageOrders.aspx
                Response.Redirect(Common.PageUrls.ManageOrdersPage + "?" + ManageOrders.REQ_MSG + "=" + MSG_STOPPROD_OK);
            }
            catch (Exception ex)
            {
                Common.Utility.ShowMessage("System error occured, Please contact Administrator", Page);
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                mainCtrl.deleteSpecificOrder(new Guid(hdOrderId.Value), base.GetCurentUser());
                Common.Utility.ShowMessage("Order has Cancelled now.", Page);
                //in cancel case, need to redirect to ManageOrders.aspx
                Response.Redirect(Common.PageUrls.ManageOrdersPage + "?" + ManageOrders.REQ_MSG + "=" + MSG_DELETE_OK
                                + "&" + ManageOrders.REQ_ORDERCODE + "=" + hdOrderCode.Value);
            }
            catch (Exception ex)
            {
                Common.Utility.ShowMessage("Production has been started now.", Page);
            }

        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Common.PageUrls.ManageOrdersPage);
        }

        protected void txtColorCount_TextChanged(object sender, EventArgs e)
        {
            txtCylCount.Text = txtColorCount.Text;
        }

        protected void txtCylCount_TextChanged(object sender, EventArgs e)
        {
            txtColorCount.Text = txtCylCount.Text;
        }
    }
}