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
    enum SecurityConst
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
            SecurityConst returnStatus = SecurityConst.LOGIN_STATUS_NO_USERNAME;
            List<Access_Right> rightList = null;

            //TODO:check username & password
            Employee dbEmpl = dbContext.Employees.Where(e => e.username.Equals(username)).FirstOrDefault();
            if (dbEmpl.password.Equals(password))
            {
                returnStatus = SecurityConst.LOGIN_STATUS_OK;
               // rightList = GetRoles(dbEmpl);
            }
            else
            {
                returnStatus = SecurityConst.LOGIN_STATUS_WRONG_PASS;
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


        //    empl.Emp_Role_ref.Rol
        //    //get all AccessRights under Roles assigned to Employee record
        //    IQueryable<Role> roleList = dbContext.Emp_Role_ref.Where(er => er.employeeId.Equals(empl.employeeId)).Join(dbContext.Roles, er => er.roleId, r => r.roleId, (er, r) => r);

        //    List<Access_Right> rightList = new List<Access_Right>();
        //    foreach (Role role in roleList) {
        //        IQueryable<Access_Right> dbRightList = dbContext.Role_Right_ref.Where(rr => rr.roleId.Equals(role.roleId)).Join(dbContext.Access_Right, ar => ar.rightId, rr => rr.rightsId, (rr, ar) => ar);
        //        if (dbRightList != null) {
        //            //TODO: add Access_Right list to big list
        //        }
        //    }
        //    return rightList;
        //}

        public void logOut()
        {
            //TODO: destroy session
        }
    }

    
}
