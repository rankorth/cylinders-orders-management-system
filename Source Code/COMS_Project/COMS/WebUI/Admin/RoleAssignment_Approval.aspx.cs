using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Admin
{
    public partial class RoleAssignment_Approval : Common.BasePage
    {
        private RoleController RoleCtrl = new RoleController();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                Authorize();
                load_data();
            }
        }

        private void Authorize()
        {
          lnkReject.Visible=  lnkApprove.Visible = base.CheckPermission(Common.Permission.ModuleName_RoleApproval, Common.Permission.Action_Edit);
        }

        private void load_data()
        {
           List<PendingRoleAssignment> pending_assigned_roles= RoleCtrl.GetAllPendingAssignedRoles();

           gvResults.DataSource = pending_assigned_roles;
           gvResults.AutoGenerateColumns = false;
           gvResults.DataBind();
        }

        protected void lnkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                RoleCtrl.Approve_Assign_Roles(GetSelectedIDs());
                load_data();
                Common.Utility.ShowMessage("Assigned Role has been approved", Page);
            }
            catch (Exception ex)
            {
                Common.Utility.ShowMessage("Production has been started now.", Page);
            }
        }

        protected void lnkReject_Click(object sender, EventArgs e)
        {
           
            RoleCtrl.Reject_Assign_Roles(GetSelectedIDs());
            load_data();
            Common.Utility.ShowMessage("Selected Role has been rejected", Page);
        }

        private List<Guid> GetSelectedIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();

            foreach (GridViewRow gRow in gvResults.Rows)
            {
                if (gRow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkID = (CheckBox)gRow.FindControl("chkID");
                   
                    if (chkID.Checked)
                    {

                        Guid id = new Guid(gvResults.DataKeys[gRow.RowIndex].Value.ToString());
                        selectedIDs.Add(id);
                    }
                }
            }
            return selectedIDs;
        }
    }
}