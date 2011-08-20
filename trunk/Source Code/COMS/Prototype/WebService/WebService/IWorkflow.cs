using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WebService
{
    [ServiceContract]
    public interface IWorkflow
    {
        [OperationContract]
        void createStep(string StepName);
        [OperationContract]
        void createWorkflow(string WorkflowName);
        [OperationContract]
        string[] getWorkFlows();
        [OperationContract]
        string[] getSteps();
        [OperationContract]
        void insertStep(string WorkflowName,string StepName);
    }

   
}
