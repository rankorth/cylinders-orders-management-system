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
        //private SecurityController securityCtrl = new SecurityController();
        //private WorkflowController workflowCtrl = new WorkflowController();
        //private StepController stepCtrl = new StepController();
        //private CylinderController cylinderCtrl = new CylinderController();
        //private SalesOrderController orderCtrl = new SalesOrderController();
        //private ErrorController errorCtrl = new ErrorController();
        //private EmployeeController employeeCtrl = new EmployeeController();
        //commented to prevent DB connection being held in each controller for long periods

        public List<Access_Right> login(String username, String password)
        {
            return (new SecurityController()).login(username, password);
            //TODO: web UI page to save access right list into Session by Session[""] = list;
        }

        public void logOut()
        {
            (new SecurityController()).logOut();
        }

        public IQueryable<Workflow> exportQueue()
        {
            return (new WorkflowController()).GetAllWorkflow();
        }

        public List<Order> exportCylinderQueue(Guid workflowId)
        {
            return viewQueue(workflowId);
        }

        public List<Order> viewQueue(Guid workflowId)
        {
            return (new WorkflowController()).viewCurrentQueue(workflowId);
        }

        public void createSalesOrder(Order order)
        {
            (new SalesOrderController()).createSalesOrder(order);
        }

        public Order getSalesOrder(String order_code) //renamed from updateSalesOrder
        {
            return (new SalesOrderController()).retrieveSalesOrder(order_code);
        }

        public void updateSalesOrder(Order order) //renamed from updateParticularSalesOrder
        {
            (new SalesOrderController()).updateSalesOrder(order);
        }

        public void deleteSpecificOrder(Order order)
        {
            (new SalesOrderController()).deleteSpecificOrder(order);
        }

        public IQueryable<Workflow> getAllWorkflow()
        {
            return (new WorkflowController()).GetAllWorkflow();
        }

        public IQueryable<Error> retrieveAllErrors()
        {
            return (new ErrorController()).retrieveAllErrors();
        }

        public IQueryable<Step> startSendCylinderToStep(Guid workflowId) //renamed from sendCylinderToStep()
        {
            return (new WorkflowController()).GetSteps(workflowId);
        }

        public void sendCylinderToStep(Cylinder cyl, Employee empl, Step thisStep, Error error, String remark) //renamed from confirm()
        {
            (new CylinderController()).changeCylinderStep(cyl, empl, thisStep, error, remark);
        }

        public IQueryable<Workflow> startSendCylinderToWorkflow()
        {
            return (new WorkflowController()).GetAllWorkflow();
        }

        public void sendCylinderToWorkflow(Cylinder cyl, Employee empl, Step thisStep, Error error, String remark)
        {
            (new CylinderController()).changeCylinderWorkflow(cyl, empl, thisStep, error, remark);
        }

        public void createError(Error error)
        {
            try
            {
                if (null != error)
                    (new ErrorController()).createError(error);
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
                    (new ErrorController()).updateError(id, name);
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
                    (new ErrorController()).deleteError(id);
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
                    (new ErrorController()).deleteError(name);
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
                    return (new ErrorController()).retrieveError(errorID);
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
                return (new CylinderController()).retrieveCylinderList();
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
                    (new CylinderController()).create(order_code, workflowID);
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
                    (new SalesOrderController()).deleteSpecificOrder(order);
                    (new CylinderController()).stopProduction(order);
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
                    return (new EmployeeController()).retrieveEmployeeInfo(employeeID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the employee information ", ex);
            }
        }

        public IQueryable<Employee> retrieveAllEmployees()
        {
            try
            {
                return employeeCtrl.retrieveEmployeeInfo();
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving employees information ", ex);
            }
        }
		
		public String getNextOrderBarCode()
        {
            return (new SalesOrderController()).getNextOrderBarCode();
        }


        //- Export Cylinder Queues
        //- Manage Sales Order - coded-tested
        //- Login - coded-tested
        //- Logout - coded
        //- View Sales Order - coded-tested
        //- View Workflow Queues - coded-tested
        //- Send Cylinder To A Particular Step - coded
        //- Send Cylinder To A Workflow - coded
    }
}
