using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class EmployeeController
    {
        private COMSEntities dbContext = new COMSEntities();
        public IQueryable<Employee> retrieveEmployeeInfo()
        {
            try
            {
                if (null != dbContext)
                {
                    if (null != dbContext.Employees)
                        return dbContext.Employees;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the employee information from the database.", ex);
            }
        }

        //Tin (8-Jan-2012) added to retrieve by barcode
        public Employee retrieveEmployeeByBarcode(string Barcode)
        {
            return dbContext.Employees.Where(e => e.barcode.Equals(Barcode)).SingleOrDefault();
        }

        public Employee retrieveEmployeeInfo(Guid employeeID)
        {
            try
            {
                if (null != dbContext && null!=employeeID)
                    return dbContext.Employees.Where(s => s.employeeId.Equals(employeeID)).SingleOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the employee information from the database.", ex);
            }
        }

        public Employee retrieveEmployeeInfo(String staff_code)
        {
            try
            {
                if (null != dbContext && null != staff_code && !staff_code.Trim().Equals(""))
                    return dbContext.Employees.Where(s => s.staff_code.Equals(staff_code)).SingleOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the employee information from the database.", ex);
            }
        }

        public void createEmployee(Employee emp)
        {
            try
            {
                if (null != dbContext && null != emp)
                {
                    //emp.employeeId = Guid.NewGuid(); //generate new guid as primary key.
                    dbContext.Employees.AddObject(emp);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating the employee entry in the database.", ex);
            }
        }

        public void deleteEmployee(Guid employeeID)
        {
            try
            {
                if (null != dbContext && null != employeeID)
                {
                    Employee emp = dbContext.Employees.Where(s => s.employeeId.Equals(employeeID)).SingleOrDefault();
                    dbContext.DeleteObject(emp);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while deleting the employee entry in the database.", ex);
            }
        }

        public void updateEmployee(Employee emp)
        {
            try
            {
                if (null != emp)
                {
                    Employee updateEmp = dbContext.Employees.Where(s => s.employeeId.Equals(emp.employeeId)).SingleOrDefault();
                    if (null != updateEmp && null != dbContext)
                    {
                        updateEmp.barcode = emp.barcode;
                        updateEmp.Department = emp.Department;
                        updateEmp.departmentId = emp.departmentId;
                        updateEmp.given_name = emp.given_name;
                        updateEmp.isactive = emp.isactive;
                        updateEmp.password = emp.password;
                        updateEmp.position = emp.position;
                        updateEmp.staff_code = emp.staff_code;
                        updateEmp.surname = emp.surname;
                        updateEmp.username = emp.username;

                        dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while updating employee information ", ex);
            }
        }
    }
}
