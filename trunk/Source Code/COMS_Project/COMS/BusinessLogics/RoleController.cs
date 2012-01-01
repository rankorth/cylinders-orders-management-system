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
    }
}
