using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Reports
{
    public partial class EmployeePerformance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void load_report()
        {
            if (txtEmpBarcode.Text.Trim().Length <= 0 || txtStartDate.Text.Trim().Length <= 0 || txtEndDate.Text.Trim().Length <= 0)
            {
                return;
            }
            Employee employee = (new EmployeeController()).retrieveEmployeeByBarcode(txtEmpBarcode.Text.Trim());

            IEnumerable<Cylinder_Log> cylinder_logs = employee.Cylinder_Log.Where(cl => cl.start_time >= Convert.ToDateTime(txtStartDate.Text) &&
                                             cl.end_time <= Convert.ToDateTime(txtEndDate.Text));

            CylinderLogDAO.CylinderLogInfoDataTable CylinderLogsInfoTable = new CylinderLogDAO.CylinderLogInfoDataTable();

            foreach (Cylinder_Log cyl in cylinder_logs)
            {
                CylinderLogDAO.CylinderLogInfoRow row = CylinderLogsInfoTable.NewCylinderLogInfoRow();
                row.CylinderBarcode = cyl.Cylinder.barcode;
                row.Department = cyl.dept_name;
                row.Remark = cyl.remark;
                row.Status = cyl.status;
                row.StartTime = cyl.start_time.ToString();
                row.EndTime = cyl.end_time.ToString();
                row.Formula = cyl.formula;
                row.Mark = cyl.mark.ToString();
                row.ErrorDescription = cyl.error_desc;
                row.StepName = cyl.Step.name;

                CylinderLogsInfoTable.AddCylinderLogInfoRow(row);
            }

            ReportParameter GivenName = new ReportParameter("GivenName", employee.given_name);
            ReportParameter StaffCode = new ReportParameter("StaffCode", employee.staff_code);
            ReportParameter Position = new ReportParameter("Position", employee.position);
            ReportParameter UserName = new ReportParameter("UserName", employee.username);

            ReportDataSource CylinderInfoTable = new ReportDataSource("CylinderInfo", (System.Data.DataTable)CylinderLogsInfoTable);

            rvPerformance.LocalReport.DataSources.Clear();
            rvPerformance.LocalReport.DataSources.Add(CylinderInfoTable);
            rvPerformance.LocalReport.SetParameters(GivenName);
            rvPerformance.LocalReport.SetParameters(StaffCode);
            rvPerformance.LocalReport.SetParameters(Position);
            rvPerformance.LocalReport.SetParameters(UserName);

            rvPerformance.LocalReport.Refresh();

        }



        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            load_report();
        }
    }
}