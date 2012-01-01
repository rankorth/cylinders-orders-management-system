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
        private SecurityController securityCtrl = new SecurityController();
        private WorkflowController workflowCtrl = new WorkflowController();
        private StepController stepCtrl = new StepController();
        private CylinderController cylinderCtrl = new CylinderController();
        private SalesOrderController orderCtrl = new SalesOrderController();
        private ErrorController errorCtrl = new ErrorController();
        private EmployeeController employeeCtrl = new EmployeeController();

        public List<Access_Right> login(String username, String password)
        {
            return securityCtrl.login(username, password);
            //TODO: web UI page to save access right list into Session by Session[""] = list;
        }

        public void logOut()
        {
            securityCtrl.logOut();
        }

        public IQueryable<Workflow> exportQueue()
        {
            return workflowCtrl.GetAllWorkflow();
        }

        public List<Order> exportCylinderQueue(Guid workflowId)
        {
            return viewQueue(workflowId);
        }

        public List<Order> viewQueue(Guid workflowId)
        {
            return workflowCtrl.viewCurrentQueue(workflowId);
        }

        public void createSalesOrder(Order order)
        {
            orderCtrl.createSalesOrder(order);
        }

        public Order getSalesOrder(String order_code) //renamed from updateSalesOrder
        {
            return orderCtrl.retrieveSalesOrder(order_code);
        }

        public void updateSalesOrder(Order order) //renamed from updateParticularSalesOrder
        {
            orderCtrl.updateSalesOrder(order);
        }

        public void deleteSpecificOder(Order order)
        {
            orderCtrl.deleteSpecificOrder(order);
        }

        public IQueryable<Workflow> getAllWorkflow()
        {
            return workflowCtrl.GetAllWorkflow();
        }

        public IQueryable<Error> retrieveAllErrors()
        {
            return errorCtrl.retrieveAllErrors();
        }

        public IQueryable<Step> startSendCylinderToStep()
        {
            return workflowCtrl.getAllSteps();
        }

        public void sendCylinderToStep(Guid cylinderId, Guid nextStepId, Error error) //renamed from confirm()
        {
            cylinderCtrl.changeCylinderStep(cylinderId, nextStepId, error);
        }

        public IQueryable<Workflow> startSendCylinderToWorkflow()
        {
            return workflowCtrl.GetAllWorkflow();
        }

        public void sendCylinderToWorkflow(Guid cylinderId, Guid nextWorkflowId, Error error)
        {
            cylinderCtrl.changeCylinderWorkflow(cylinderId, nextWorkflowId, error);
        }

        public void createError(Error error)
        {
            try
            {
                if (null != error)
                    errorCtrl.createError(error);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating a new error code ", ex);
            }
        }

        public void updateError(Guid id, String name)
        {
            try
            {
                if (null != id && null != name)
                    errorCtrl.updateError(id, name);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while updating error code ", ex);
            }
        }

        public void deleteError(Guid id)
        {
            try
            {
                if (null != id)
                    errorCtrl.deleteError(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while removing error code ", ex);
            }
        }

        public void deleteError(String name)
        {
            try
            {
                if (null != name)
                    errorCtrl.deleteError(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while removing error code ", ex);
            }
        }

        public Error retrieveError(Guid errorID)
        {
            try
            {
                if (null != errorID)
                    return errorCtrl.retrieveError(errorID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the error code " + errorID + " information from the database. ", ex);
            }
        }

        public IQueryable<Cylinder> viewCylinderInfo()
        {
            try
            {
                return cylinderCtrl.retrieveCylinderList();
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the cylinders", ex);

            }
        }

        public void startCylinderProd(Guid workflowID, String order_code)
        {
            try
            {
                if (null != order_code && !order_code.Equals("") && null!=workflowID)
                    cylinderCtrl.create(order_code, workflowID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while starting the cylinder production", ex);
            }
        }

        public void stopCylinderProd(Order order)
        {
            try
            {
                if (null != order)
                {
                    orderCtrl.deleteSpecificOrder(order);
                    cylinderCtrl.stopProduction(order);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while stopping the cylinder production", ex);
            }
        }

        public Employee retrieveEmployee(Guid employeeID)
        {
            try
            {
                if (null != employeeID)
                    return employeeCtrl.retrieveEmployeeInfo(employeeID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the employee information ", ex);
            }
        }
		
		public String getNextOrderBarCode()
        {
            return orderCtrl.getNextOrderBarCode();
        }


        //- Export Cylinder Queues
        //- Manage Sales Order - coded-tested
        //- Login - coded-tested
        //- Logout
        //- View Sales Order - coded-tested
        //- View Workflow Queues - coded-tested
        //- Send Cylinder To A Particular Step
        //- Send Cylinder To A Workflow
    }
}
