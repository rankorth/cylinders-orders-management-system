using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

namespace BusinessLogics
{
    class CustomerController
    {
        private COMSEntities dbContext = new COMSEntities();

        public IQueryable<Customer> getAllCustomers()
        {
            return dbContext.Customers;
        }
    }
}
