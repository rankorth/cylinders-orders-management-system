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
    public partial class CylinderPrintPage : Common.BasePage
    {
        MainController mainctrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            Guid cylinderID = new Guid(Request["cylinderId"]);
            String ordercode = Request["orderCode"];
            if (null != cylinderID && null!=ordercode && !ordercode.Trim().Equals(""))
            {
                Cylinder cylinder = mainctrl.viewCylinderInfo(cylinderID);
                if (null != cylinder)
                {
                    // pending for answers
                    txtArea.Text = calculateSurfaceArea((double)cylinder.diameter.GetValueOrDefault(), (double)cylinder.length.GetValueOrDefault());
                    txtCircumference.Text = calculateCircumference((double)cylinder.diameter.GetValueOrDefault(), (double)cylinder.length.GetValueOrDefault()); ;
                    txtDiameter.Text = Math.Round(cylinder.diameter.GetValueOrDefault(), 2).ToString();
                    txtLength.Text = Math.Round(cylinder.length.GetValueOrDefault(), 2).ToString();
                }

                Order order = mainctrl.getSalesOrderByCode(ordercode);

                if (null != order)
                {
                    txtOrderCode.Text = ordercode;
                    txtCustomer.Text = order.Customer.name;
                    txtProductionName.Text = order.product_name;
                    txtType.Text = order.cylinder_type;
                    imgBarCode.ImageUrl = "BarCode.aspx?code=" + order.order_code;
                    txtKeyhole.Text = findKeyhole(order, cylinderID);
                    txtKeyway.Text = findKeyway(order, cylinderID);
                }
            }

        }

        private String findKeyhole(Order order, Guid cylinderID)
        {
            String keyhole =null;
            foreach (Order_Detail od in order.Order_Detail)
            {
                foreach (Cylinder cy in od.Cylinders)
                {
                    if (cy.cylinderId.ToString().Equals(cylinderID.ToString()))
                    {
                        keyhole = od.keyhole_type;
                        break;
                    }
                }
            }
            return keyhole;
        }

        private String findKeyway(Order order, Guid cylinderID)
        {
            String keyway = null;
            foreach (Order_Detail od in order.Order_Detail)
            {
                foreach (Cylinder cy in od.Cylinders)
                {
                    if (cy.cylinderId.ToString().Equals(cylinderID.ToString()))
                    {
                        keyway = od.keyhole_keyway;
                        break;
                    }
                }
            }
            return keyway;
        }

        private String calculateSurfaceArea(double radius, double height)
        {
            double pi = 3.1415926536;
            double surfaceArea = 2 * pi * radius * (radius + height);
            return Math.Round(surfaceArea, 2).ToString();
        }

        private String calculateCircumference(double radius, double height)
        {
            double pi = 3.1415926536;
            double circumference = 2 * pi * radius;
            return Math.Round(circumference, 2).ToString();
        }
    }
}