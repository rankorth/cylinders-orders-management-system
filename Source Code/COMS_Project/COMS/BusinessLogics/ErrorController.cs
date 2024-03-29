﻿using System;
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
                throw new Exception("Sorry, there is an error occured while creating a new error code ", ex);
            }
        }

        public void updateError(Guid id, String name)
        {
            try
            {
                Error error = dbContext.Errors.Where(s => s.errorId.Equals(id)).SingleOrDefault();
                if (null != error && null != dbContext)
                {
                    error.name = name;
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while updating error code ", ex);
            }
        }

        public void deleteError(Guid id)
        {
            try
            {
                if (null != id && null != dbContext)
                {
                    Error err = dbContext.Errors.Where(s => s.errorId.Equals(id)).SingleOrDefault();
                    dbContext.DeleteObject(err);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while removing error code ", ex);
            }
        }

        public void deleteError(String name)
        {
            try
            {
                if (null != name && null != dbContext)
                {
                    Error err = dbContext.Errors.Where(s => s.name.Equals(name)).SingleOrDefault();
                    dbContext.DeleteObject(err);
                    dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while removing error code ", ex);
            }
        }

        public Error retrieveError(Guid errorID)
        {
            try
            {
                if (null != dbContext && null != errorID)
                    return dbContext.Errors.Where(s => s.errorId.Equals(errorID)).SingleOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                //related to any errors, there may be only database error
                //always create a meaningful error exception to catch and show up on UI.
                throw new Exception("Sorry, there is an error occured while retrieving the error code " + errorID + " information from the database. ", ex);
            }
        }

        public IQueryable<Error> retrieveAllErrors()
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
                throw new Exception("Sorry, there is an error occured while retrieving the error codes from the database. ", ex);
            }
        }
    }
}
