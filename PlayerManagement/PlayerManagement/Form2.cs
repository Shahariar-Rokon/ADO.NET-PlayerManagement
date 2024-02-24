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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace PlayerManagement
{
    public partial class Form2 : Form
    {
        //Single Master View
        private string _id;
        public Form2(string id)
        {
            InitializeComponent();
            _id=id; 
        }
      


        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                con.Open();
                string q = "select * from TeamMaster where TeamId=@teamid";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@teamid", _id);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "TeamMaster");
                CrystalReport3 cr3 = new CrystalReport3();
                cr3.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cr3;
                con.Close();
                crystalReportViewer1.Refresh();
                con.Close();
            }
        }
    }
}
