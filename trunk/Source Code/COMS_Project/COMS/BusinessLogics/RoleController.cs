using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class RoleController
    {
        COMSEntities context = new COMSEntities();

        public IQueryable<Role> GetRoles()
        {
            return context.Roles.Where(r => true).OrderBy(r=>r.name);
        }

        public Role GetRoles(Guid RoleID)
        {
            return context.Roles.Where(r => r.roleId.Equals(RoleID)).SingleOrDefault();
        }
        public List<Access_Right> GetAccessRights(Role role)
        {
            if (role == null)
            {
                return null;
            }
            IEnumerable<Role_Right_ref> role_rights= role.Role_Right_ref.Where(r => true);
            List<Access_Right> accesses = new List<Access_Right>();

            foreach (Role_Right_ref rrref in role_rights)
            {
                Access_Right tmp_acc= context.Access_Right.Where(ar => ar.rightsId.Equals(rrref.rightId)).SingleOrDefault();
                if (tmp_acc != null)
                {
                    accesses.Add(tmp_acc);
                }
            }

            return accesses;
        }

        public IQueryable<Access_Right> GetAllAccessRights()
        {
            return context.Access_Right.Where(ar => true).OrderBy(ar=>ar.name);
        }

        public void RemoveAllRights(Role role)
        {
            List<Role_Right_ref> deletelist = new List<Role_Right_ref>();
            foreach (Role_Right_ref rf in role.Role_Right_ref)
            {
                deletelist.Add(rf);
            }
            foreach (Role_Right_ref rf in deletelist)
            {
                context.Role_Right_ref.DeleteObject(rf);
            }

          SaveUpdateChanges();
        }
        public void AddRightToRole(Role role, Guid AccessRightID,string created_by)
        {
            Role_Right_ref access = new Role_Right_ref();
            
            access.Id = Guid.NewGuid();
            access.rightId = AccessRightID;
            access.created_by = created_by;
            access.created_date = DateTime.Now;
            role.Role_Right_ref.Add(access);

            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }
        public void SaveRole(Role role)
        {
            role.roleId = Guid.NewGuid();
            role.created_date = DateTime.Now;

            context.Roles.AddObject(role);
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public void SaveUpdateChanges()
        {
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public List<PendingRoleAssignment> GetAllPendingAssignedRoles()
        {
            IQueryable<Emp_Role_ref> pending_assign_roles = context.Emp_Role_ref.Where(erf => erf.isapproved == false);
            List<PendingRoleAssignment> results = new List<PendingRoleAssignment>();

            foreach (Emp_Role_ref erf in pending_assign_roles)
            {
                PendingRoleAssignment pending_role_assignment = new PendingRoleAssignment();
                pending_role_assignment.Emp_Role_ref_ID     = erf.Id;
                pending_role_assignment.Employee_Name       = erf.Employee.username;
                pending_role_assignment.Role_Name           = erf.Role.name;

                results.Add(pending_role_assignment);
            }
            return results;
        }

        public void Reject_Assign_Roles(List<Guid> selected_emp_role_refs)
        {
            foreach (Guid id in selected_emp_role_refs)
            {
                Emp_Role_ref emp_role_ref = context.Emp_Role_ref.Where(err => err.Id.Equals(id)).SingleOrDefault();
                if (emp_role_ref != null)
                {
                    context.DeleteObject(emp_role_ref);
                }
            }
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        public void Approve_Assign_Roles(List<Guid> selected_emp_role_refs)
        {
            foreach (Guid id in selected_emp_role_refs)
            {
                Emp_Role_ref emp_role_ref = context.Emp_Role_ref.Where(err => err.Id.Equals(id)).SingleOrDefault();
                if (emp_role_ref != null)
                {
                    emp_role_ref.isapproved = true;
                }
            }
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }


        
    }
    public class PendingRoleAssignment
    {
        public Guid Emp_Role_ref_ID {get;set;}
        public string Employee_Name {get;set;}
        public string Role_Name {get;set;}
    }
}
