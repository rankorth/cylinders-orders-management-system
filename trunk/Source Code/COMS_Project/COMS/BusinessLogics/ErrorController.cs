using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class ErrorController
    {
        private COMSEntities dbContext = new COMSEntities();
        public void createError(Error error)
        {
            try
            {
                if (null != error && null != dbContext)
                {
                    error.errorId = Guid.NewGuid(); //generate new guid as primary key.
                    dbContext.Errors.AddObject(error);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while creating a new error code");
            }
        }

        public void updateError(Error error)
        {
            try
            {
                if (null != error && null != dbContext)
                {
                    IQueryable<Error> errors = dbContext.Errors.Where(s => s.errorId.Equals(error.errorId));
                    if (null != errors)
                    {
                        foreach (Error s in errors)
                        {
                            if (null != s)
                                s.name = error.name;
                        }
                    }
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while updating error code");
            }
        }

        public void deleteError(Guid errorID)
        {
            try
            {
                if (null != errorID && null != dbContext)
                {
                    IQueryable<Error> errors = dbContext.Errors.Where(er => er.errorId.Equals(errorID) || er.errorId.Equals(errorID));
                    if (null != errors)
                    {
                        foreach (Error er in errors)
                        { dbContext.DeleteObject(er); }
                    }
                }
            }
            catch
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while removing error code");
            }
        }

        public IQueryable<Error> getError(Guid errorID)
        {
            try
            {
                if (null != dbContext && null != errorID)
                    return dbContext.Errors.Where(s => s.errorId.Equals(errorID));
                else
                    return null;
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the error code " + errorID + " information from the database.");
            }
        }

        public IQueryable<Error> getAllErrors()
        {
            try
            {
                if (null != dbContext)
                {
                    if (null != dbContext.Errors)
                        return dbContext.Errors;
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
                throw new Exception("Sorry, there is an error occured while retrieving the error codes from the database.");
            }
        }
    }
}
