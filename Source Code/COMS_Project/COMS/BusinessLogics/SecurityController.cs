﻿using System;
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
    public class SecurityController
    {
        private COMSEntities dbContext = new COMSEntities();
        
        //Tin (10-Jan-2012)
        public Employee login(String username, String password)
        {
            //after login, we need user object to store as session.
            //Tin (10-Jan-2012)
            Employee EmpObj =null;
            try
            {
                EmpObj = dbContext.Employees.Where(e => e.username.Trim().Equals(username.Trim()) && e.password.Equals(password)).SingleOrDefault();
            }
            catch
            {
                // Do Nothing, we will throw null object as no login found.
            }
            /*
             *  List<Access_Right> rightList = null;
            Employee dbEmpl = dbContext.Employees.Where(e => e.username.Equals(username)).SingleOrDefault();
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
            }*/
            return EmpObj;
        }

        public List<Role> GetRoles(Employee emp)
        {
            List<Role> roles=new List<Role>();
            //Tin (14-Jan-2012)
            if (emp.Emp_Role_ref != null)
            {
                foreach (Emp_Role_ref rf in emp.Emp_Role_ref)
                {
                    if (rf.isapproved == true)
                    {
                        roles.Add(rf.Role);
                    }
                }
            }
            return roles;
        }

        private List<Access_Right> GetAccessRights(Role role)//(Employee empl)
        {

            List<Access_Right> access =new List<Access_Right>();
            //Tin 13-Jan-2012
            if (role.Role_Right_ref != null)
            {
                foreach (Role_Right_ref rf in role.Role_Right_ref)
                {
                    access.Add(rf.Access_Right);
                }
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
            //Tin (10-Jan-2012)
            // We will do in Web UI level project to destroy session.
        }
    }

    
}
