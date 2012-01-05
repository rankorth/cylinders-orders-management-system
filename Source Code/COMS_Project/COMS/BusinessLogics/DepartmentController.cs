using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{

    public class DepartmentController
    {
        private COMSEntities dbContext = new COMSEntities();

        public String retrieveDepartmentName(Guid departmentID)
        {
            Department department = dbContext.Departments.Where(s => s.departmentId.Equals(departmentID)).SingleOrDefault();
            if (null != department)
            {
                return department.name;
            }
            return "";
        }

        public IQueryable <Department> retrieveDepartments()
        {
            return dbContext.Departments.Where(s => s.isactive==true);
        }
    }
}
