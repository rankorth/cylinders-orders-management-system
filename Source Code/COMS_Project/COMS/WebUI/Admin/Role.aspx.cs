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
    public partial class Role : Common.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hPageState.Value = Common.PageState.New;
                load_data();
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtRoleName.Text.Trim()))
            {
                isValid = false;
            }
            return isValid;
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            if (hPageState.Value.Equals(Common.PageState.New))
            {
                COMSdbEntity.Role newRole = new COMSdbEntity.Role();
                newRole.name = txtRoleName.Text.Trim();
                newRole.created_by = base.GetCurentUser().username;
                newRole.isactive = chkIsActive.Checked;
                newRole.isapproved = false;
                RoleController RoleCtrl = new RoleController();
                RoleCtrl.SaveRole(newRole);
                foreach (Guid ID in GetSelectedAccessIDs())
                {
                    RoleCtrl.AddRightToRole(newRole, ID, newRole.created_by);
                }

                
            }
            if (hPageState.Value.Equals(Common.PageState.Update))
            {
                Guid updateId = new Guid(hUpdateID.Value);
                RoleController RoleCtrl = new RoleController();
                COMSdbEntity.Role role = RoleCtrl.GetRoles(updateId);
                role.name = txtRoleName.Text.Trim();
                role.isactive = chkIsActive.Checked;
                role.updated_by = base.GetCurentUser().username;
                role.updated_date = DateTime.Now;
                role.isapproved = false;

                List<Guid> selected_updateAccess = GetSelectedAccessIDs();
                RoleCtrl.RemoveAllRights(role);

                foreach (Guid id in selected_updateAccess)
                {
                    RoleCtrl.AddRightToRole(role, id, base.GetCurentUser().username);
                }

            }


            load_data();
            CleanPageState();

        }

        private void load_data()
        {
            load_access_rights();
            load_roles_data();
        }
        private void CleanPageState()
        {
            txtRoleName.Text = "";
            chkIsActive.Checked = false;

            hPageState.Value = Common.PageState.New;
            hUpdateID.Value = "";
        }
        private void load_access_rights()
        {
            RoleController RoleCtrl = new RoleController();
            gvAccess.DataSource = RoleCtrl.GetAllAccessRights();
            gvAccess.AutoGenerateColumns = false;
            gvAccess.DataBind();
        }
        private void load_roles_data()
        {
            RoleController rolectrl =new  RoleController();

            gvResult.DataSource = rolectrl.GetRoles();
            gvResult.AutoGenerateColumns = false;
            gvResult.DataBind();
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            foreach (Guid ID in GetSelectedAccessIDs())
            {
                //mainctrl.deleteError(ID);
            }

            //load_data();
            CleanPageState();
        }

        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid ID;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ID = ((COMSdbEntity.Role)(e.Row.DataItem)).roleId;
                LinkButton lnkEdit = ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit"));
                lnkEdit.CommandName = "SelectRow";
                lnkEdit.CommandArgument = ID.ToString();
            }
        }



        private List<Guid> GetSelectedAccessIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();
            foreach (GridViewRow grow in gvAccess.Rows)
            {
                if (grow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)grow.Cells[0].FindControl("chkSelected");
                    if (chkId.Checked)
                    {
                        Guid ID = new Guid(chkId.InputAttributes["ID"].ToString());
                        selectedIDs.Add(ID);
                    }
                }
            }

            return selectedIDs;
        }



        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hPageState.Value = Common.PageState.Update;
            if (e.CommandName.Equals("SelectRow"))
            {
                hUpdateID.Value = e.CommandArgument.ToString();
                RoleController roleCtrl = new RoleController();
                COMSdbEntity.Role role =roleCtrl.GetRoles(new Guid(e.CommandArgument.ToString()));
                txtRoleName.Text = role.name;
                chkIsActive.Checked = role.isactive;

                SelectAccessRightsAccordingToRole(role);
            }
        }

        private void SelectAccessRightsAccordingToRole(COMSdbEntity.Role role)
        {
            foreach (GridViewRow gRow in gvAccess.Rows)
            {
                if (gRow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSelected = (CheckBox)gRow.FindControl("chkSelected");
                    Guid accessID =new Guid( chkSelected.InputAttributes["ID"].ToString());
                    chkSelected.Checked = false;

                    foreach (Role_Right_ref rf in role.Role_Right_ref)
                    {
                        if (rf.rightId.Equals(accessID))
                        {
                            chkSelected.Checked = true;
                        }
                    }
                }
            }
        }
        protected void gvAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid ID ;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ID = ((Access_Right)e.Row.DataItem).rightsId;
                CheckBox chkSelected = (CheckBox)e.Row.FindControl("chkSelected");
                chkSelected.InputAttributes.Add("ID", ID.ToString());
            }
        }
    }
}