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
    public partial class ErrorManagement : System.Web.UI.Page
    {
        MainController mainctrl = new MainController();
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

            if (string.IsNullOrEmpty(txtErrorCode.Text.Trim()))
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
                Error newError = new Error();
                newError.name = txtErrorCode.Text.Trim();
                mainctrl.createError(newError);
            }
            if (hPageState.Value.Equals(Common.PageState.Update))
            {
                Guid updateId = new Guid(hUpdateID.Value);
                mainctrl.updateError(updateId, txtErrorCode.Text.Trim());
            }


            load_data();
            CleanPageState();

        }

        private void CleanPageState()
        {
            txtErrorCode.Text = "";
            hPageState.Value = Common.PageState.New;
            hUpdateID.Value = "";
        }
        private void load_data()
        {
            IQueryable<Error> errmessages = mainctrl.retrieveAllErrors();
            gvErrorMsgs.DataSource = errmessages;
            gvErrorMsgs.AutoGenerateColumns = false;
            gvErrorMsgs.DataBind();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            foreach (Guid ID in GetSelectedIDs())
            {
                mainctrl.deleteError(ID);
            }

            load_data();
            CleanPageState();
        }

        protected void gvErrorMsgs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid errId;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                errId = ((Error)(e.Row.DataItem)).errorId;

                ((CheckBox)e.Row.Cells[0].FindControl("chkID")).InputAttributes.Add("ErrID", errId.ToString());
                LinkButton lnkEdit = ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit"));
                lnkEdit.CommandName = "SelectRow";
                lnkEdit.CommandArgument = errId.ToString();
            }


        }



        private List<Guid> GetSelectedIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();
            foreach (GridViewRow grow in gvErrorMsgs.Rows)
            {
                if (grow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)grow.Cells[0].FindControl("chkID");
                    if (chkId.Checked)
                    {
                        Guid ID = new Guid(chkId.InputAttributes["ErrID"].ToString());
                        selectedIDs.Add(ID);
                    }
                }
            }

            return selectedIDs;
        }



        protected void gvErrorMsgs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hPageState.Value = Common.PageState.Update;
            if (e.CommandName.Equals("SelectRow"))
            {
                hUpdateID.Value = e.CommandArgument.ToString();
                ErrorController ErrControl = new ErrorController();
                txtErrorCode.Text = ErrControl.retrieveError(new Guid(e.CommandArgument.ToString())).name;
            }
        }
    }
}