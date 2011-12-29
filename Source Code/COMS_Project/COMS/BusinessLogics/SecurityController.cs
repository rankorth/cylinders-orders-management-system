using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;
using System.Collections;

namespace BusinessLogics
{
    public enum SecurityConst
    {
        LOGIN_STATUS_OK = 0,
        LOGIN_STATUS_NO_USERNAME = 1,
        LOGIN_STATUS_WRONG_PASS = 2,
    }
    class SecurityController
    {
        private COMSEntities dbContext = new COMSEntities();
        

        public List<Access_Right> login(String username, String password)
        {
            List<Access_Right> rightList = null;

            //TODO:check username & password
            Employee dbEmpl = dbContext.Employees.Where(e => e.username.Equals(username)).FirstOrDefault();
            if (dbEmpl == null)
            {
                throw new Exception("" + SecurityConst.LOGIN_STATUS_NO_USERNAME);
            }
            else if (dbEmpl.password.Equals(password))
            {
                rightList = GetEmployee_AccessRights(dbEmpl);
            }
            else
            {
                throw new Exception("" + SecurityConst.LOGIN_STATUS_WRONG_PASS);
            }
            return rightList;
        }

        public List<Role> GetRoles(Employee emp)
        {
            List<Role> roles=new List<Role>();

            foreach (Emp_Role_ref rf in emp.Emp_Role_ref)
            {
                roles.Add(rf.Role);
            }
            return roles;
        }

        private List<Access_Right> GetAccessRights(Role role)//(Employee empl)
        {

            List<Access_Right> access =new List<Access_Right>();

            foreach(Role_Right_ref rf in role.Role_Right_ref)
            {
                access.Add(rf.Access_Right);
            }
            return access;
        }

        public List<Access_Right> GetEmployee_AccessRights(Employee employee)
        {
            List<Role> roles= GetRoles(employee);

            List<Access_Right> Access=new List<Access_Right>();

            foreach(Role r in roles)
            {
                Access.AddRange(GetAccessRights(r));
            }
            return Access;
        }

        public void logOut()
        {
            //TODO: destroy session
        }
    }

    
}
