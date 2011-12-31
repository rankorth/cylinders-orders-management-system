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
                load_data();
            }   
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            bool update = false;

            for (int i = 0; i < gvErrorMsgs.Rows.Count; i++)
            {
                string strValue = ((HiddenField)gvErrorMsgs.Rows[i].Cells[0].FindControl("checkedList")).Value;
                if (strValue != "")
                {
                    Guid id = new Guid(strValue);
                    mainctrl.updateError(id, txtErrorCode.Text);
                    update = true;
                    break;
                }
            }
            if (!update)
            {
                Error newError = new Error();
                newError.name = txtErrorCode.Text;
                mainctrl.createError(newError);
            }
            load_data();
            txtErrorCode.Text = "";
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
            for(int i=0; i<gvErrorMsgs.Rows.Count; i++){
                string strValue = ((HiddenField)gvErrorMsgs.Rows[i].Cells[0].FindControl("checkedList")).Value;
                if(strValue!=""){
                    Guid id = new Guid(strValue);
                    mainctrl.deleteError(id);
                }
            }
            load_data();
        }

        protected void gvErrorMsgs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid errId;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                errId=((Error)(e.Row.DataItem)).errorId;
                CheckBox chk = new CheckBox();
                chk.InputAttributes.Add("onclick","javascript:updateCheckList(this)");
                chk.InputAttributes.Add("value", errId.ToString());
                e.Row.Cells[0].Controls.Add(chk);
            }

            
        }
    }
}