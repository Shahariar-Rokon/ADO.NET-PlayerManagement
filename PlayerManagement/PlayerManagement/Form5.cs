using PlayerManagement.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerManagement
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH)) 
            {
                con.Open();
                string q = "select * from Team";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "Team");
                CrystalReport6 cr7 = new CrystalReport6();
                cr7.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cr7;
                con.Close();
                crystalReportViewer1.Refresh();
                con.Close();
            }

        }
    }
}
