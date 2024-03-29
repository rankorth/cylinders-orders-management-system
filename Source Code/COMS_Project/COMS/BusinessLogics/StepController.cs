﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;

namespace BusinessLogics
{
    class StepController
    {
        private COMSEntities dbContext = new COMSEntities();

        public IQueryable<Step> retrieveStepsForWorkflow(Guid workflowID) {
            return dbContext.Steps.Where(s => s.workflowId.Equals(workflowID));
        }
    }
}
