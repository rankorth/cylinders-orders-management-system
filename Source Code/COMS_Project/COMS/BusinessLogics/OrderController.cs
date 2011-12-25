using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;

using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    public class OrderController
    {
        COMSEntities context = new COMSEntities();

        public void insert(Order order)
        {
            try
            {
                //add order record into databse
                context.Orders.AddObject(order);

                //make changes perminent 
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while placing new order", ex);
            }
        }

        public void update()
        {
        }

        public void delete()
        {
        }
    }
}
