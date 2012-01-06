using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;

namespace WebUI.Admin 
{
    public partial class DisplayOrder : Common.BasePage
    {
        MainController mainCtrl = new MainController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_new_data();
            }
            else
            {
                load_data();
            }
            ltrModule_name.Text = "Add New Order";
        }

        private void load_new_data()
        {
            txtCreateDate.Text = DateTime.Now.ToShortDateString();
            //load customer list into drop down list
            IQueryable<Customer> customerList = mainCtrl.getAllCustomers();
            foreach (Customer cust in customerList) {
                ddlCustomer.Items.Add(new ListItem(cust.fullname, cust.customerid.ToString()));
            }

            Order order = new Order();
            order.order_code = mainCtrl.getNextOrderBarCode();

            //save order object with the order_code into Session
            Session["order"] = order;

            //generate order barcode image
            imgBarCode.ImageUrl = "BarCode.aspx?code=" + order.order_code;
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            //try
            //{
                Order order = (Order)Session["order"];
                populate_order(order);
                populate_orderDetail(order);

                mainCtrl.createSalesOrder(order);

                //go back to Main Order Page
                Response.Redirect("ManageOrders.aspx");
            //}
            //catch (Exception ex)
            //{
            //    lblMsg.Text = ex.StackTrace;
            //}
        }

        private void populate_order(Order order)
        {
            order.orderId = Guid.NewGuid(); //generate new guid as primary key.
            order.customer_id = new Guid(ddlCustomer.SelectedItem.Value);
            order.customer_rep = txtCustomerRep.Text;
            order.product_name = txtProdName.Text;
            order.price_type = txtPriceType.Text;
            order.redo_pct = (txtRedoPct.Text != "") ? Convert.ToInt32(txtRedoPct.Text) : 0;
            order.old_core = chkBxOldCore.Checked;
            order.delivery_date = calDeliveryDate.SelectedDate;

            order.order_type = (rBtnOrderTypeNew.Checked) ? OrderConst.ORDERTYPE_NEW : OrderConst.ORDERTYPE_REDO;

            order.set_code = txtSetCode.Text;
            order.cylinder_type = txtCylType.Text;
            //order.old_order_code = ???
            order.priority = ddlPriority.SelectedItem.Value;
            order.belong_to_set = txtBelongsToSet.Text;
            order.created_by = txtCreatedBy.Text;
            order.created_date = Convert.ToDateTime(txtCreateDate.Text);
        }

        private void populate_orderDetail(Order order)
        {
            Order_Detail orderDetail = new Order_Detail();
            orderDetail.order_detailId = Guid.NewGuid();
            orderDetail.orderId = order.orderId;
            orderDetail.created_by = order.created_by;
            orderDetail.created_date = order.created_date;
            
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
                orderDetail.used_cyl_count = Convert.ToInt32(txtCylCount.Text);
            else
                orderDetail.new_cyl_count = Convert.ToInt32(txtCylCount.Text);

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

            //add orderDetail to order
            order.Order_Detail.Add(orderDetail);
        }

        private void load_data()
        {
            Guid orderId = new Guid(Request["orderId"]);
            Order order = mainCtrl.getSalesOrder(orderId);
            display_order(order);
        }


        private void display_order(Order order)
        {
            //load customer list into drop down list, the current customer will be auto-selected
            IQueryable<Customer> customerList = mainCtrl.getAllCustomers();
            foreach (Customer cust in customerList)
            {
                ListItem item = new ListItem(cust.fullname, cust.customerid.ToString()); 
                if (item.Value.Equals(order.customer_id.ToString()))
                    item.Selected = true;
                ddlCustomer.Items.Add(item);
            }
            txtCustomerRep.Text = order.customer_rep;
            txtProdName.Text = order.product_name;
            txtPriceType.Text = order.price_type;
            txtRedoPct.Text = ""+order.redo_pct;
            chkBxOldCore.Checked = (bool)order.old_core;
            calDeliveryDate.SelectedDate = (DateTime)order.delivery_date;
            rBtnOrderTypeNew.Checked = (order.order_type == OrderConst.ORDERTYPE_NEW);
            txtSetCode.Text = order.set_code;
            txtCylType.Text = order.cylinder_type;
            //order.old_order_code = ???
            foreach (ListItem item in ddlPriority.Items) {
                if (item.Value.Equals(order.priority)) {
                    item.Selected = true;
                    break;
                }
            }
            txtBelongsToSet.Text = order.belong_to_set;
            txtCreatedBy.Text = order.created_by;
            txtCreateDate.Text = order.created_date.ToString();

            //orderDetail.core_type = (chkBxOldCore.Checked) ? OrderConst.CORETYPE_OLD : OrderConst.CORETYPE_NEW;
            //orderDetail.prod_print_width = Convert.ToDecimal(txtProdWidth.Text);
            //orderDetail.prod_width_stretch = (txtWidthStretch.Text != "") ? Convert.ToDecimal(txtWidthStretch.Text) : 0;
            //orderDetail.prod_print_height = Convert.ToDecimal(txtProdHeight.Text);
            //orderDetail.prod_height_stretch = (txtHeightStretch.Text != "") ? Convert.ToDecimal(txtHeightStretch.Text) : 0;
            //orderDetail.length_dir_repeat = Convert.ToInt32(txtLengthRepeats.Text);
            //orderDetail.circum_dir_repeat = Convert.ToInt32(txtCircumRepeats.Text);
            //orderDetail.web_print_width = Convert.ToInt32(txtWebPrintWidth.Text);
            //orderDetail.web_total_width = Convert.ToInt32(txtWebTotalWidth.Text);
            //orderDetail.cyl_length = Convert.ToDecimal(txtCylLength.Text);
            //orderDetail.cyl_diameter = Convert.ToDecimal(txtCylCircum.Text) / Convert.ToDecimal(3.1416);
            //if (chkBxEyeMark.Checked)
            //{
            //    orderDetail.eyemark_height = Convert.ToInt32(txtEMHeight.Text);
            //    orderDetail.eyemark_width = Convert.ToInt32(txtEMWidth.Text);
            //    orderDetail.eyemark_color = txtEMColor.Text;
            //    orderDetail.eyemark_sign = txtEMSign.Text;
            //}
            //if (rBtnEMLoc1Side.Checked)
            //    orderDetail.eyemark_location = OrderConst.EM_LOC_1SIDE;
            //else if (rBtnEMLoc2Side.Checked)
            //    orderDetail.eyemark_location = OrderConst.EM_LOC_2SIDE;
            //else if (rBtnEMLocTopDown.Checked)
            //    orderDetail.eyemark_location = OrderConst.EM_LOC_TOPDOWN;
            //else if (rBtnEMLocBottom.Checked)
            //    orderDetail.eyemark_location = OrderConst.EM_LOC_BOTTOM;

            //if (rBtnKeyHoleStd.Checked)
            //    orderDetail.keyhole_type = OrderConst.KEYHOLE_STANDARD;
            //else if (rBtnKeyHoleOther.Checked)
            //{
            //    if (txtKeyHoleOther.Text != "")
            //    {
            //        orderDetail.keyhole_type = txtKeyHoleOther.Text;
            //    }
            //    else
            //    {
            //        orderDetail.keyhole_type = OrderConst.KEYHOLE_OTHER;
            //        orderDetail.keyhole_inner_dia = Convert.ToInt32(txtKHInnerDia.Text);
            //        orderDetail.keyhole_outer_dia = Convert.ToInt32(txtKHOuterDia.Text);
            //        orderDetail.keyhole_angle = Convert.ToInt32(txtKHAngle.Text);
            //        orderDetail.keyhole_keyway = txtKHKeyway.Text;
            //    }
            //}
            //orderDetail.color_count = Convert.ToInt32(txtColorCount.Text);
            //orderDetail.color_list = txtColorList.Text;

            ////the number of cylinders depends on whether old cores are being reused
            //if (chkBxOldCore.Checked)
            //    orderDetail.used_cyl_count = Convert.ToInt32(txtCylCount.Text);
            //else
            //    orderDetail.new_cyl_count = Convert.ToInt32(txtCylCount.Text);

            //orderDetail.print_method = (rBtnMethodSurface.Checked) ? OrderConst.PRINTMETHOD_SURFACE : OrderConst.PRINTMETHOD_REVERSE;

            //orderDetail.reg_mark_type = (rBtnRegMarkStd.Checked) ? OrderConst.REGMARK_STANDARD : txtRegMarkOther.Text;

            //if (chkBxSplitLine.Checked)
            //{
            //    orderDetail.splitline_size = Convert.ToInt32(txtSplitLineSize.Text);
            //    orderDetail.splitline_type = (chkBxSplitLine2Side.Checked) ? OrderConst.SPLITLINE_2SIDE : OrderConst.SPLITLINE_1SIDE;
            //    orderDetail.splitline_color = txtSplitLineColor.Text;
            //}
            //orderDetail.print_material = ddlPrintMaterial.SelectedItem.Value;

            ////result can be compared with either graphic proof, printing sample or fingerprint
            //orderDetail.result_based_on = (rBtnResultSample.Checked) ? OrderConst.RESULT_FROM_SAMPLE
            //    : ((rBtnResultFp.Checked) ? OrderConst.RESULT_FROM_FINGERPRINT : OrderConst.RESULT_FROM_GRAPHIC);

            //if (rBtnOrientUp.Checked)
            //    orderDetail.img_orientation = rBtnOrientUp.Text;
            //else if (rBtnOrientDown.Checked)
            //    orderDetail.img_orientation = rBtnOrientDown.Text;
            //else if (rBtnOrientLeft.Checked)
            //    orderDetail.img_orientation = rBtnOrientLeft.Text;
            //else if (rBtnOrientRight.Checked)
            //    orderDetail.img_orientation = rBtnOrientRight.Text;
            //else if (rBtnOrientOther.Checked)
            //    orderDetail.img_orientation = txtOrientOther.Text;

            //orderDetail.changes = (chkBxChangeFile.Checked) ? OrderConst.CHANGEFILE_YES : OrderConst.CHANGEFILE_NO;
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}