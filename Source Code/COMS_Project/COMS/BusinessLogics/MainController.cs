using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class MainController
    {
        private SecurityController securityCtrl;
        private WorkflowController workflowCtrl;
        private StepController stepCtrl;
        private CylinderController cylinderCtrl;
        private SalesOrderController orderCtrl;
        private ErrorController errorCtrl;

        public SecurityController getSecurityController()
        {
            if (securityCtrl == null) securityCtrl = new SecurityController();
            return securityCtrl;
        }
        public WorkflowController getWorkflowController()
        {
            if (workflowCtrl == null) workflowCtrl = new WorkflowController();
            return workflowCtrl;
        }
        public StepController getStepController()
        {
            if (stepCtrl == null) stepCtrl = new StepController();
            return stepCtrl;
        }
        public CylinderController getCylinderController()
        {
            if (cylinderCtrl == null) cylinderCtrl = new CylinderController();
            return cylinderCtrl;
        }
        public SalesOrderController getOrderController()
        {
            if (orderCtrl == null) orderCtrl = new SalesOrderController();
            return orderCtrl;
        }
        public ErrorController getErrorController()
        {
            if (errorCtrl == null) errorCtrl = new ErrorController();
            return errorCtrl;
        }

        public int login(String username, String password)
        {
            
            int loginStatus = getSecurityController().login(username, password);

            try
            {
                switch (loginStatus)
                {
                    case SecurityController.LOGIN_STATUS_OK:
                        //TODO: forward to main page
                        break;
                    case SecurityController.LOGIN_STATUS_NO_USERNAME:
                    case SecurityController.LOGIN_STATUS_WRONG_PASS:
                    default:
                        //TODO: go back to login page with error msg
                        break;
                }
            }
            catch (Exception ex)
            {
                //TODO: go back to login page with error msg
            }
            return loginStatus;
        }

        public void logOut()
        {
            getSecurityController().logOut();
        }

        public IQueryable<Workflow> exportQueue()
        {
            return getWorkflowController().GetAllWorkflow();
        }

        public IQueryable<Cylinder> exportCylinderQueue(Guid workflowID)
        {
            //TODO: retrieve a list of cylinders currently under this workflow
            IQueryable<Step> stepList = getStepController().retrieveStepsForWorkflow(workflowID);
            IQueryable<Cylinder> cylinderList = getCylinderController().receiveCylinderList(stepList);
            //TODO: export to Excel and send back
        }

        public void createSalesOrder(Order order)
        {
            getOrderController().createSalesOrder(order);
        }

        public Order viewSalesOrder(String order_code) //renamed from updateSalesOrder
        {
            return getOrderController().retrieveSalesOrder(order_code);
        }

        public void updateSalesOrder(Order order) //renamed from updateParticularSalesOrder
        {
            getOrderController().updateSalesOrder(order);
        }

        public void deleteSpecificOder(Guid orderId)
        {
            getOrderController().deleteSpecificOrder(orderId);
        }

        public void viewQueue(Guid workflowId)
        {
            getWorkflowController().viewCurrentQueue(workflowId);
        }

        public IQueryable<Workflow> getAllWorkflow()
        {
            return getWorkflowController().GetAllWorkflow();
        }

        public IQueryable<Error> retrieveAllErrors()
        {
            return getErrorController().retrieveAllErrors();
        }

        public void sendCylinderToStep(Guid cylinderId, Guid nextStepId, Error error)
        {
            getCylinderController().changeCylinderStep(cylinderId, nextStepId, error);
        }


        //- Export Cylinder Queues
        //- Manage Sales Order - coded
        //- Login
        //- Logout
        //- View Sales Order - coded
        //- View Workflow Queues
        //- Send Cylinder To A Particular Step
    }
}
