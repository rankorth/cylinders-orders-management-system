using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Workflow" in code, svc and config file together.
    public class Workflow : IWorkflow
    {
        public void createStep(string StepName)
        {

            SqlConnection con = GetDBCon();
            SqlCommand cmd = new SqlCommand("insert into Steps (name) Values ('"+StepName+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            
        }
        public void createWorkflow(string WorkflowName)
        {
            SqlConnection con = GetDBCon();
            SqlCommand cmd = new SqlCommand("insert into Workflow (name) Values ('" + WorkflowName + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public string[] getWorkFlows()
        {
            SqlConnection con = GetDBCon();
            SqlCommand cmd = new SqlCommand("select name from Workflow", con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<string> DataCol = new List<string>();

            while (dr.Read())
            {
                DataCol.Add(dr[0].ToString());
            }
            return DataCol.ToArray();
        }
        public string[] getSteps()
        {
            SqlConnection con = GetDBCon();
            SqlCommand cmd = new SqlCommand("select name from Steps", con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<string> DataCol = new List<string>();

            while (dr.Read())
            {
                DataCol.Add(dr[0].ToString());
            }
            return DataCol.ToArray();
        }
        public void insertStep(string WorkflowName,string StepName)
        {
            SqlConnection con = GetDBCon();
            SqlCommand cmd = new SqlCommand("InsertStep", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@WorkflowName", SqlDbType.NVarChar)).Value = WorkflowName;
            cmd.Parameters.Add(new SqlParameter("@StepName", SqlDbType.NVarChar)).Value = StepName;
            cmd.ExecuteScalar();

            con.Close();
            cmd.Dispose();
        }

        public SqlConnection GetDBCon()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMOS;Integrated Security=True");
            con.Open();
            return con;
        }
        
    }
}

