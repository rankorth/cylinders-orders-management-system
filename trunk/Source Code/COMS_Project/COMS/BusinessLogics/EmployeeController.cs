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
                throw new Exception("Sorry, there is an error occured while retrieving the employee information from the database.");
            }
        }
    }
}
