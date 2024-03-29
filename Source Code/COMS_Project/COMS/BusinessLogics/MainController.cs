﻿using System;
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

        //Tin (10-Jan-2012) make changes to return Employee object as login session
        public Employee login(String username, String password)
        {
            return (new SecurityController()).login(username, password);
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

        public void createSalesOrder(Order order, Employee empl)
        {
            (new SalesOrderController()).createSalesOrder(order, empl);
        }

        public Order getSalesOrder(Guid orderId)
        {
            return (new SalesOrderController()).retrieveSalesOrder(orderId);
        }

        public Order getSalesOrderByCode(String order_code) //renamed from updateSalesOrder
        {
            return (new SalesOrderController()).retrieveSalesOrder(order_code);
        }

        public IQueryable<Order> getSalesOrders(String searchKey, String searchType)
        {
            return (new SalesOrderController()).getSalesOrders(searchKey, searchType);
        }

        public void updateSalesOrder(Order order, Employee empl) //renamed from updateParticularSalesOrder
        {
            (new SalesOrderController()).updateSalesOrder(order, empl);
        }

        public void deleteSpecificOrder(Guid orderId, Employee empl)
        {
            (new SalesOrderController()).deleteSpecificOrder(orderId, empl);
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
            (new CylinderController()).changeCylinderStep(cyl, empl, thisStep, error, remark,DateTime.Now,DateTime.Now,0,CylinderConst.STATUS_COMPLETED,false);
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

        public Cylinder viewCylinderInfo(Guid cylinderID)
        {
            return (new CylinderController()).viewCylinderInfo(cylinderID);
        }

        public void startCylinderProd(Guid orderId, Employee empl)
        {
            try
            {
                if (null != orderId) {
                    Workflow MechToProdWF = (new WorkflowController()).GetWorkflow(DeptConst.DEPT_MECHANICAL, DeptConst.DEPT_PROD);
                    (new CylinderController()).create(orderId, MechToProdWF, empl);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while starting the cylinder production", ex);
            }
        }

        public void stopCylinderProd(Guid orderId, Employee empl)
        {
            try
            {
                if (null != orderId)
                {
                    (new CylinderController()).stopProduction(orderId, empl);
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

        public Employee retrieveEmployee(String staff_code)
        {
            try
            {
                if (null != staff_code && !staff_code.Trim().Equals(""))
                    return (new EmployeeController()).retrieveEmployeeInfo(staff_code);
                else
                {
                    return null;
                }
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
                return (new EmployeeController()).retrieveEmployeeInfo();
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving employees information ", ex);
            }
        }

        public void createEmployee(Employee emp)
        {
            try
            {
                (new EmployeeController()).createEmployee(emp);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while inserting employee information ", ex);
            }
        }

        public void updateEmployee(Employee emp)
        {
            try
            {
                (new EmployeeController()).updateEmployee(emp);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while updating employee information ", ex);
            }
        }

        public void deleteEmployee(Guid employeeID)
        {
            try
            {
                (new EmployeeController()).deleteEmployee(employeeID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while deleting employee information ", ex);
            }
        }

        public String retrieveDepartmentName(Guid departmentID)
        {
            try
            {
                return (new DepartmentController()).retrieveDepartmentName(departmentID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving department name information ", ex);
            }
        }

        public IQueryable<Department> retrieveDepartments()
        {
            try
            {
                return (new DepartmentController()).retrieveDepartments();
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving department information ", ex);
            }
        }

        public IQueryable<Emp_Role_ref> retrieveEmployeeRoles(Guid employeeID)
        {
            try
            { 
                return(new RoleController()).GetEmployeeRoles(employeeID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving employee roles information ", ex);
            }
        }

        public List<Access_Right> retrieveAccessRights(Role role)
        {
            try
            {
                return (new RoleController()).GetAccessRights(role);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving employee roles information ", ex);
            }
        }

        public IQueryable<Customer> getAllCustomers()
        {
            return (new CustomerController()).getAllCustomers();
        }

        public IQueryable<Role> getRoles()
        {
            return (new RoleController()).GetRoles();
        }
	
        public void assignNewRole(Guid employeeID, List<Guid> rolesID, String username, DateTime today)
        {
            (new RoleController()).assign_Roles(employeeID, rolesID, username, today);
        }

        public void updateRole(Guid employeeID, List<Guid> rolesID, String username, DateTime today)
        {
            (new RoleController()).update_Assign_Roles(employeeID, rolesID, username, today);
        }

        public List<Cylinder> getAllCylinders(String order_code)
        {
            return (new SalesOrderController()).getAllCylinders(order_code);
        }

		public String getNextOrderBarCode()
        {
            return (new SalesOrderController()).getNextOrderBarCode();
        }

        public IQueryable<Order_Log> getOrderLogs(Guid orderId)
        {
            return (new SalesOrderController()).getOrderLogs(orderId);
        }

        public IQueryable<Cylinder_Log> getCylinderLogs(Guid cylinderId)
        {
            return (new CylinderController()).getCylinderLogs(cylinderId);
        }

        //- Export Cylinder Queues - coded-tested
        //- Manage Sales Order - coded-tested
        //- Login - coded-tested
        //- Logout - coded
        //- View Sales Order - coded-tested
        //- View Workflow Queues - coded-tested
        //- Send Cylinder To A Particular Step - coded
        //- Send Cylinder To A Workflow - coded
    }
}
