using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class CylinderController
    {
        private COMSEntities dbContext = new COMSEntities();
		public void changeCylinderPriority(Cylinder cylinder)
        {
            try
            {
                if (null != cylinder && null != dbContext)
                {
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinder.cylinderId));
                    if (null != cylinders)
                    {
                        foreach (Cylinder s in cylinders)
                        {
                            if (null != s)
                                s.priority = cylinder.priority;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while updating the cylinder " + cylinder.cylinderId + "'s priority "+ex.Message);
            }
        }

        public IQueryable<Cylinder> retrieveCylinderList()
        {
            try
            {
                if (null != dbContext)
                {
                    if (null != dbContext.Cylinders)
                        return dbContext.Cylinders;
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the cylinder list from the database. " + ex.Message);
            }
            return null;
        }

        public void startProduction(String cylinderID)
        {
            try
            {
                if(null!= cylinderID && null!=dbContext){
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinderID));
                    if(null!=cylinders){
                        foreach (Cylinder s in cylinders)
                        {
                            if (null != s)
                                s.status = 1; //1 means start 
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while starting production for the cylinder: " + cylinderID +" "+ex.Message);
            }
        }

        public void stopProduction(String cylinderID)
        {
            try
            {
                if(null!= cylinderID && null!=dbContext){
                    IQueryable<Cylinder> cylinders = dbContext.Cylinders.Where(s => s.cylinderId.Equals(cylinderID));
                    if(null!=cylinders){
                        foreach (Cylinder s in cylinders)
                        {
                            if(null!=s)
                                s.status = 0; //0 means stop 
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while stopping production for the cylinder: " + cylinderID + " " + ex.Message);
            }
        }
		
        public IQueryable<Cylinder> retrieveCylinderList(IQueryable<Step> stepList)
        {
            //TODO: retrieve all cylinders under the steps in the stepList
            foreach (Step step in stepList)
            {
                IQueryable<Cylinder> cylinderList = dbContext.Cylinders.Where(c => c.Cylinder_Log.stepId.Equals(step.stepId));

            }
            //return dbContext.Steps.Where(s => s.workflowId.Equals(workflowID));
        }

        public void changeCylinderStep(cylinderId, nextStepId, error) {

        }
    }
}
