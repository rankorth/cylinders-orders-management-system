using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    class MainController
    {
        public void createError(Error error)
        {
            try
            {
                ErrorController ec = new ErrorController();
                ec.createError(error);
                ec = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while creating a new error code " + ex.Message);
            }
        }

        public void updateError(Guid id, String name)
        {
            try
            {
                ErrorController ec = new ErrorController();
                ec.updateError(id, name);
                ec = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while updating error code " + ex.Message);
            }
        }

        public void deleteError(Guid id)
        {
            try
            {
                ErrorController ec = new ErrorController();
                ec.deleteError(id);
                ec = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while removing error code " + ex.Message);
            }
        }

        public void deleteError(String name)
        {
            try
            {
                ErrorController ec = new ErrorController();
                ec.deleteError(name);
                ec = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while removing error code " + ex.Message);
            }
        }

        public Error retrieveError(Guid errorID)
        {
            try
            {
                ErrorController ec = new ErrorController();
                return ec.retrieveError(errorID);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the error code " + errorID + " information from the database. "+ ex.Message);
            }
        }

        public IQueryable<Error> retrieveAllErrors()
        {
            try
            {
                ErrorController ec = new ErrorController();
                return ec.retrieveAllErrors();
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, there is an error occured while retrieving the error codes from the database. " + ex.Message);
            }
        }
    }
}
