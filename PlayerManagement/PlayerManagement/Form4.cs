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
using PlayerManagement.DAL;
namespace PlayerManagement
{
    //All details view
    public partial class Form4 : Form
    {
        public Form4()
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
                CrystalReport4 cr2 = new CrystalReport4();
                cr2.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cr2;
                con.Close();
                crystalReportViewer1.Refresh();
                con.Close();

            }

        }
    }
}
