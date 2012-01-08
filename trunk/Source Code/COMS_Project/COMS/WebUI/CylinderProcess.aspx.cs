using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogics;
using COMSdbEntity;

namespace WebUI
{
    public partial class CylinderProcess : System.Web.UI.Page
    {
        
        private string pagesession = Common.Utility.UpdateCylinderState;
        CylinderController  CylCtrl = new CylinderController();
        UpdateCylinderController UpdateCylCtrl = new UpdateCylinderController();
        CylinderProcessData PageData = new CylinderProcessData();

        protected void Page_Load(object sender, EventArgs e)
        {
            Prepare_Menu();
            
            if (Session[pagesession] == null)
            {
                CleanupInput();
                ChangeStep(step.scan_cylinder_start);

                Session[pagesession] = PageData;
                show_action_panel();
            }
            else
            {
                PageData = (CylinderProcessData)Session[pagesession];
            }
           
        }

        private void show_action_panel()
        {


            int cur_step =(int) PageData.PageStep;

            HideAllActPanels();
            
            switch (cur_step)
            {
                case 0: pnlCylinderBarCode.Visible = true;
                    break;
                case 1: pnlPnlActionButtons.Visible = true;
                    break;
                case 2: pnlSelectSteps.Visible = true;
                    break;
                case 3: pnlCylinderCodeEnd.Visible = true;
                    break;
                case 4: pnlEmployeeBarCode.Visible = true;
                    break;
                case 5: pnlErrorReason.Visible = true;
                    break;
            }
        }

        private void HideAllActPanels()
        {
            pnlCylinderBarCode.Visible = false;
            pnlCylinderCodeEnd.Visible = false;
            pnlEmployeeBarCode.Visible = false;
            pnlErrorReason.Visible = false;
            pnlPnlActionButtons.Visible = false;
            pnlSelectSteps.Visible = false;
        }
        private void Prepare_Menu()
        {
            Common.BasePage bp = new Common.BasePage();
            Panel menupanel = (Panel)this.Master.FindControl("module_panel");
            LinkButton LogoutBtn = (LinkButton)this.Master.FindControl("lnkLogout");
            LogoutBtn.Visible = false;

            menupanel.Controls.Clear();
            menupanel.Controls.Add(new LinkButton());
        }

        protected void txtCylinderCodeToEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtCylinderCodeToEnd.Text.Trim().Length > 0)
            {
                if (txtCylinderCodeToEnd.Text.Trim().Equals(PageData.CylinderBarcode))
                {
                    ChangeStep(step.scan_employee_code);
                }
            }
            show_action_panel();
        }

        protected void txtScanCylinderCode_TextChanged(object sender, EventArgs e)
        {
            string CylinderBarCode = txtScanCylinderCode.Text.Trim();

            ChangeStep(step.scan_cylinder_start);

            if (!string.IsNullOrEmpty(CylinderBarCode))
            {
                if (CylCtrl.isValidCylinder(CylinderBarCode))
                {
                    PageData.CylinderBarcode=CylinderBarCode;
                    ChangeStep(step.select_actions);
                }
            }
            show_action_panel();
        }

        protected void ActionCommand(object sender, EventArgs e)
        {
            string command_name = ((Button)sender).Text.Trim();
            if (command_name.Equals("Proceed"))
            {
                Proceed();
            }
            else if (command_name.Equals("Reject"))
            {
                Reject();
            }
            else if (command_name.Equals("Cancel"))
            {
                Cancel();
            }
        }

        private void Proceed()
        {
            WorkflowController workflowCtrl = new WorkflowController();
            IQueryable<Step> NextAvailableSteps =  workflowCtrl.GetNextSteps(PageData.CylinderBarcode);
            
            drpReasons.DataSource = NextAvailableSteps;
            drpReasons.DataTextField  = "name";
            drpReasons.DataValueField = "stepId";
            drpReasons.DataBind();

            ChangeStep(step.select_step);
            show_action_panel();
        }

        private void Reject()
        {
            ChangeStep(step.error_reason);
            show_action_panel();

            
        }

        private void Cancel()
        {
            CleanupInput();
            ChangeStep(step.scan_cylinder_start);
            show_action_panel();
        }



        protected void btnStepOK_Click(object sender, EventArgs e)
        {
            if (drpReasons.SelectedItem != null)
            {
                WorkflowController WorkflowCtrl = new WorkflowController();
                Step SelectedStep = WorkflowCtrl.getStep(new Guid( drpReasons.SelectedValue.ToString()));
                PageData.SelectedStep = SelectedStep;
                Session[pagesession]=PageData;

                UpdateCylCtrl.StartCylinderWork(PageData.CylinderBarcode, PageData.SelectedStep.stepId, DateTime.Now);

                ChangeStep(step.scan_cylinder_toend);
            }
            
            show_action_panel();
        }

        protected void txtEmployeeBarCode_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeBarCode.Text.Trim().Length > 0)
            {
                EmployeeController employee = new EmployeeController();
                Employee CurrentWorker =  employee.retrieveEmployeeInfo(txtEmployeeBarCode.Text.Trim());
                if(CurrentWorker!=null)
                {
                    PageData.EmployeeBarcode = CurrentWorker.barcode;
                    CleanupInput();
                    ChangeStep(step.scan_cylinder_start);
                }
            }
            show_action_panel();

        }

        private void CleanupInput()
        {
            tCylinderBarcode.Text = string.Empty;
            tDesc.Text = string.Empty;
            tInstruct.Text = string.Empty;
            tNote.Text = string.Empty;
            tStep.Text = string.Empty;

            txtCylinderCodeToEnd.Text = string.Empty;
            txtEmployeeBarCode.Text = string.Empty;
            txtScanCylinderCode.Text = string.Empty;

            PageData = new CylinderProcessData();
            Session.Clear();

        }

        public void ChangeStep(step StepToChange)
        {
            PageData.PageStep = StepToChange;
            Session[pagesession] = PageData;
        }

        protected void btnSubmitErrorOK_Click(object sender, EventArgs e)
        {
            Error errorReason = new COMSdbEntity.Error();
            errorReason.name = drpReasons.SelectedValue;
            UpdateCylCtrl.RepoartCylinderWithError(PageData.CylinderBarcode, PageData.EmployeeBarcode,
                                                    errorReason, string.Empty);
            ChangeStep(step.scan_cylinder_start);
            show_action_panel();
        }
    }


    class CylinderProcessData
    {
        public string  CylinderBarcode;
        public Step SelectedStep;
        public string EmployeeBarcode;
        public step PageStep;
    }

}