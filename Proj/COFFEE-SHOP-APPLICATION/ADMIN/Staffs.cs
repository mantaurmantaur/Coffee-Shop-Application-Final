using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    public partial class Staffs : Form
    {
        public Staffs()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            staff.addStaffs(
                fntbx.Text,
                lntbx.Text,
                postbx.Text,
                statustbx.Text,
                emailtbx.Text
            );
        }

        private void Staffs_Load(object sender, EventArgs e)
        {
            var myConn = generalClass.GetConnection();

            if(generalClass.Position == "Manager")
            {
                credenbtn.Enabled = false;
                var da = new OleDbDataAdapter("SELECT * FROM Staffs WHERE Position <> 'Administrator'", myConn);
                var ds = new DataSet();
                myConn.Open();
                da.Fill(ds, "Staffs");
                staffdataview.DataSource = ds.Tables["Staffs"];
                myConn.Close();

            }
            else
            {
                var da = new OleDbDataAdapter("SELECT *FROM Staffs", myConn);
                var ds = new DataSet();
                myConn.Open();
                da.Fill(ds, "Staffs");
                staffdataview.DataSource = ds.Tables["Staffs"];
            }
                
            myConn.Close();
        }

        private void credenbtn_Click(object sender, EventArgs e)
        {
            var myConn = generalClass.GetConnection();
            var da = new OleDbDataAdapter("SELECT *FROM StaffCredentials", myConn);
            var ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffCredentials");

            generalClass.HashColumnInDataTable(ds.Tables["StaffCredentials"], "Password");
            staffdataview.DataSource = ds.Tables["StaffCredentials"];
            myConn.Close();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Staffs_Load(sender, e);
        }

        private void staffdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0) return;


            DataGridViewRow row = staffdataview.Rows[indexRow];
            fntbx.Text = row.Cells[1].Value?.ToString();
            lntbx.Text = row.Cells[2].Value?.ToString();
            postbx.Text = row.Cells[3].Value?.ToString();
            statustbx.Text = row.Cells[4].Value?.ToString();
            staffdataview.Text = row.Cells[0].Value?.ToString();
            emailtbx.Text = row.Cells[5].Value?.ToString();
            idtbx.Text = row.Cells[0].Value.ToString();

        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            Staffs_Load(sender, e);
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int staffId;
            if (int.TryParse(idtbx.Text, out staffId))
            {
                // You can now use staffId as an int
                staff.updateStaffs(fntbx.Text, lntbx.Text, postbx.Text, statustbx.Text, emailtbx.Text, staffId);
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Staff ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deletbtn_Click(object sender, EventArgs e)
        {
            int staffId;
            if (int.TryParse(idtbx.Text, out staffId))
            {
                staff.deleteStaff(staffId);
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Staff ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
