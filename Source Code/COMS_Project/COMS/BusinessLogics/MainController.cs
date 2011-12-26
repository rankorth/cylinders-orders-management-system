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

            //try
            //{
            //    switch (loginStatus)
            //    {
            //        case SecurityController.LOGIN_STATUS_OK:
            //            //TODO: forward to main page
            //            break;
            //        case SecurityController.LOGIN_STATUS_NO_USERNAME:
            //        case SecurityController.LOGIN_STATUS_WRONG_PASS:
            //        default:
            //            //TODO: go back to login page with error msg
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //TODO: go back to login page with error msg
            //}
            //return loginStatus;
        }

        public void logOut()
        {
            securityCtrl.logOut();
        }

        public IQueryable<Workflow> exportQueue()
        {
            return workflowCtrl.GetAllWorkflow();
        }

 //       public IQueryable<Cylinder> exportCylinderQueue(Guid workflowId)
 //       {
 //           return viewQueue(workflowId);
 //       }

 //       public IQueryable<Cylinder> viewQueue(Guid workflowId)
 //       {
 //           return workflowCtrl.viewCurrentQueue(workflowId);
 //       }

        public void createSalesOrder(Order order)
        {
            orderCtrl.createSalesOrder(order);
        }

        public Order viewSalesOrder(String order_code) //renamed from updateSalesOrder
        {
            return orderCtrl.retrieveSalesOrder(order_code);
        }

        public void updateSalesOrder(Order order) //renamed from updateParticularSalesOrder
        {
            orderCtrl.updateSalesOrder(order);
        }

        public void deleteSpecificOder(Guid orderId)
        {
            orderCtrl.deleteSpecificOrder(orderId);
        }

        public IQueryable<Workflow> getAllWorkflow()
        {
            return workflowCtrl.GetAllWorkflow();
        }

        public IQueryable<Error> retrieveAllErrors()
        {
            return errorCtrl.retrieveAllErrors();
        }

 //       public void sendCylinderToStep(Guid cylinderId, Guid nextStepId, Error error)
 //       {
 //           cylinderCtrl.changeCylinderStep(cylinderId, nextStepId, error);
 //       }


        //- Export Cylinder Queues
        //- Manage Sales Order - coded
        //- Login
        //- Logout
        //- View Sales Order - coded
        //- View Workflow Queues
        //- Send Cylinder To A Particular Step

        public void createError(Error error)
        {
            try
            {
                if(null!=error)
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
                if(null!=id && null!=name)
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
                if(null!=id)
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
                if(null!=name)
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

        //public void create(String ordercode)
        //{
        //    try
        //    {
        //        if(null!=ordercode)
        //            cylinderCtrl.create(ordercode);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Sorry, there is an error occured while creating the cylinders", ex);
        //    }
        //}

        public void changeCylinderPriority(Guid cylinder_id, int priority)
        {
            try
            {
                if (null != cylinder_id && priority>=0)
                    cylinderCtrl.changeCylinderPriority(cylinder_id, priority);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating the cylinders", ex);
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
                if (null != order_code)
                    cylinderCtrl.create(order_code, workflowID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating the cylinders", ex);
            }
        }

        public void stopCylinderProd(Guid cylinderID)
        {
            try
            {
                if (null != cylinderID)
                    cylinderCtrl.stopProduction(cylinderID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while changing the status of cylinder" + cylinderID, ex);
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
    }
}
