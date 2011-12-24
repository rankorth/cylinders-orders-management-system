using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.EntityClient;
using System.Data.Entity;

using COMSdbEntity;

using BusinessLogics;

namespace Example
{
    public partial class Form2 : Form
    {
        private int value = 100;
        private Guid updateId;
        private String updateName;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();

            try
            {
                //insert Error
                Error errorcode = new Error();
                errorcode.name = "Error"+ value;
                value++;

                //add order record into database
                ec.createError(errorcode);

                //Acknowledge successful insertion process
                MessageBox.Show("Data Inserted into Error table");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while inserting \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        private void btnInsertNull_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();

            try
            {
                //insert Error
                Error errorcode = null;

                //add order record into database
                ec.createError(errorcode);

                //Acknowledge successful insertion process
                MessageBox.Show("Managed to catch the error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting \n - Managed to catch the error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Search sample
            ErrorController ec = new ErrorController();
            try
            {
                ec.updateError(updateId, updateName+" - Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating \n" + ex.Message + " - " + ex.InnerException.Message);
            }
            //Acknowledge successful update process
            MessageBox.Show("Data has been updated in Error table");
        }

        private void btnUndoUpdate_Click(object sender, EventArgs e)
        {
            //Search sample
            ErrorController ec = new ErrorController();
            try
            {
                ec.updateError(updateId, updateName.Substring(0,8));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating \n" + ex.Message + " - " + ex.InnerException.Message);
            }
            //Acknowledge successful update process
            MessageBox.Show("Data has been updated in Error table");

        }

        private void btnUpdateNull_Click(object sender, EventArgs e)
        {
            //Search sample
            ErrorController ec = new ErrorController();
            try
            {
                ec.updateError(updateId, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error while updating \n - Managed to catch the error");
            }

        }

        private void btnDeleteNA_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();

            try
            {
                ec.deleteError(new Guid("00000000000000000000000000"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting \n- Managed to catch the error");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();

            try
            {
                for (int i = 100; i <= value-1; i++)
                {
                    ec.deleteError("Error" + i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting \n" + ex.Message);
            }
            value = 100;

            //Acknowledge successful delete process
            MessageBox.Show("Data has been deleted in Error table");

        }

        private void Form2_Load(object sender, EventArgs e)
        {}

        private void retrieve_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();
            IQueryable<Error> errors = ec.retrieveAllErrors();
            String data="";
             foreach(Error er in errors)
             {
                 data = data + er.name+"\n";
                 updateId = er.errorId;
                 updateName = er.name;
             }
             MessageBox.Show(data);
             data = null;
        }

        private void retrieveOne_Click(object sender, EventArgs e)
        {
            ErrorController ec = new ErrorController();
            Error error = ec.retrieveError(updateId);
            String data = "";
            if (null != error)
            {
                data = data + error.name;
            }
            MessageBox.Show(data);
            data = null;
        }

    }
}
