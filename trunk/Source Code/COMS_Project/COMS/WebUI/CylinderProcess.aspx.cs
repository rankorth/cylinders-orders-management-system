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
                
            }
            else
            {
                PageData = (CylinderProcessData)Session[pagesession];
            }
            show_action_panel();

            if (!IsPostBack)
            {
                Load_ErrorReasons();
                Load_Steps();
            }

            ShowInfo();
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
            ErrorMessage.Text = "";
            if (txtCylinderCodeToEnd.Text.Trim().Length > 0)
            {
                if (txtCylinderCodeToEnd.Text.Trim().Equals(PageData.CylinderBarcode))
                {
                    ChangeStep(step.scan_employee_code);
                }
                else
                {
                    ErrorMessage.Text = "This is not the cylinder which the process started.<br /> Please scan correct cylinder.";
                }
            }
            show_action_panel();
        }

        private void Load_Steps()
        {
            lstSteps.DataSource = (new WorkflowController()).GetNextSteps(PageData.CylinderBarcode);
            lstSteps.DataTextField = "name";
            lstSteps.DataValueField = "stepId";
            lstSteps.DataBind();
        }
        protected void txtScanCylinderCode_TextChanged(object sender, EventArgs e)
        {
            string CylinderBarCode = txtScanCylinderCode.Text.Trim();

            ChangeStep(step.scan_cylinder_start);
            ErrorMessage.Text = "";
            if (!string.IsNullOrEmpty(CylinderBarCode))
            {
                if (CylCtrl.isValidCylinder(CylinderBarCode))
                {
                    PageData.CylinderBarcode = CylinderBarCode;
                    ChangeStep(step.select_actions);

                }
                else
                {
                   ErrorMessage.Text ="Cylinder is not found.";
                }
            }
            else
            {
                CleanupInput();
                ErrorMessage.Text = "Invalid Cylinder Barcode.";
            }
            show_action_panel();

            ShowInfo();
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
            Load_Steps();

            ChangeStep(step.select_step);
            show_action_panel();
        }

        private void Load_ErrorReasons()
        {
            ErrorController ErrorCtrl  =new ErrorController();
            IQueryable<Error> errors = ErrorCtrl.retrieveAllErrors();
            drpReasons.DataSource = errors;
            drpReasons.DataTextField = "name";
            drpReasons.DataValueField = "errorId";
            drpReasons.DataBind();

            drpDamageReason.DataSource = errors;
            drpDamageReason.DataTextField = "name";
            drpDamageReason.DataValueField = "errorId";
            drpDamageReason.DataBind();
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
            ErrorMessage.Text = "";
            if (lstSteps.SelectedItem != null)
            {
                
                WorkflowController WorkflowCtrl = new WorkflowController();
                Step SelectedStep = WorkflowCtrl.getStep(new Guid(lstSteps.SelectedValue.ToString()));
                PageData.SelectedStep = SelectedStep;
                Session[pagesession]=PageData;

                if (PageData.SelectedStep != null)
                {
                    UpdateCylCtrl.StartCylinderWork(PageData.CylinderBarcode, PageData.SelectedStep.stepId, DateTime.Now);
                    ChangeStep(step.scan_cylinder_toend);
                }
                else
                {
                    ErrorMessage.Text = "This step is not found. Please contact Administrator.";
                }

            }else
            {
                ErrorMessage.Text = "Please Select a step to proceed.";
            }
            
            show_action_panel();
            ShowInfo();
        }

        protected void txtEmployeeBarCode_TextChanged(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            if (txtEmployeeBarCode.Text.Trim().Length > 0)
            {
                EmployeeController employee = new EmployeeController();
                Employee CurrentWorker =  employee.retrieveEmployeeByBarcode(txtEmployeeBarCode.Text.Trim());
                if (CurrentWorker != null)
                {
                    if (drpWorkStatus.SelectedItem.Value.Equals("Complete"))
                    {
                        PageData.EmployeeBarcode = CurrentWorker.barcode;
                        UpdateCylCtrl.FinishCylinderWork(PageData.CylinderBarcode, CurrentWorker.barcode, PageData.SelectedStep.stepId, DateTime.Now);
                        
                    }
                    else
                    {
                        try
                        {
                            Error errorReason = new COMSdbEntity.Error();
                            errorReason.errorId = new Guid(drpDamageReason.SelectedItem.Value);
                            errorReason.name = drpDamageReason.SelectedItem.Text;

                            PageData.EmployeeBarcode = CurrentWorker.barcode;
                            UpdateCylCtrl.FinishCylinderWorkWithError(PageData.CylinderBarcode, CurrentWorker.barcode, PageData.SelectedStep.stepId, DateTime.Now, errorReason);
                        }
                        catch
                        {
                            Common.Utility.ShowMessage("There has been error while reporting of this damage. Please contact System Administrator", this.Page);
                        }
                    }
                    CleanupInput();
                    ChangeStep(step.scan_cylinder_start);
                    ErrorMessage.Text = "The process has finish. Scan for another Cylinder.";
                }
                else
                {
                    ErrorMessage.Text = "Employee Code not found. Contact Administrator or Department head.";
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
            txtEmployeeBarCodeToReport.Text = string.Empty;

            PageData = new CylinderProcessData();
            PageData.PageStep = step.scan_cylinder_start;
            Session[pagesession] = PageData;

        }

        public void ChangeStep(step StepToChange)
        {
            PageData.PageStep = StepToChange;
            Session[pagesession] = PageData;

            if (StepToChange == step.scan_cylinder_start)
            {
                txtScanCylinderCode.Focus();
            }
            else if (StepToChange == step.select_actions)
            {
            }
            else if (StepToChange == step.select_step)
            {
            }
            else if (StepToChange == step.error_reason)
            {
            }
            else if (StepToChange == step.scan_cylinder_toend)
            {
                txtCylinderCodeToEnd.Focus();
            }
            else if (StepToChange == step.scan_employee_code)
            {
            }
        }

        protected void txtEmployeeBarCodeToReport_TextChanged(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            string employeeBarcode = txtEmployeeBarCodeToReport.Text.Trim();
            Employee emp = (new EmployeeController()).retrieveEmployeeByBarcode(employeeBarcode);
            if (emp != null)
            {

                PageData.EmployeeBarcode = emp.barcode;

                Error errorReason = new COMSdbEntity.Error();
                errorReason.errorId = new Guid(drpReasons.SelectedItem.Value);
                errorReason.name = drpReasons.SelectedItem.Text;

                UpdateCylCtrl.RepoartCylinderWithError(PageData.CylinderBarcode, PageData.EmployeeBarcode,
                                                        errorReason, errorReason.name);
                CleanupInput();
                ChangeStep(step.scan_cylinder_start);
            }
            else
            {
                ErrorMessage.Text = "Employee Code not found. Please contact Administrator or Department Head.";
            }
            show_action_panel();
        }

        private void ShowInfo()
        {
            tCylinderBarcode.Text = PageData.CylinderBarcode;
            if (PageData.SelectedStep != null)
            {
                tDesc.Text = PageData.SelectedStep.description;
                tInstruct.Text = PageData.SelectedStep.instruction;
                tNote.Text = PageData.SelectedStep.note;
                tStep.Text = PageData.SelectedStep.name;
            }
        }

        protected void btnCancelProcess_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            Cancel();

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