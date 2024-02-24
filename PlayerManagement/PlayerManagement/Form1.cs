using PlayerManagement.DAL;
using PlayerManagement.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;




namespace PlayerManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillItem();
            ResetSalesMaster();
            ResetSalesItem();
            SetGridSalesMaster();
        }
        private void ResetSalesItem()
        {
            txtAmount.Text = "0";
            txtQty.Text = "0";
            txtUnitPrice.Text = "0";
            txtVat.Text = "0";
        }
        private void ResetSalesMaster()
        {
            lblSaleId.Text = "0";
            txtAddress.Text = "";
            txtCustomer.Text = "";
            txtPhone.Text = "";
            btnSubmit.Text = "ADD";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            dateTimePicker1.Text = "";
        }
        private void SetGridSalesMaster()
        {
            dgvSales.DataSource = null;
            dgvSales.DataSource = GetSalesMaster();
        }
        public List<TeamMasterVM> GetSalesMaster()
        {
            var listTeamMaster = new List<TeamMasterVM>();

            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT [TeamId],[TeamName],[TeamOrigin],[DOB],[Phone],[Address] FROM [TeamMaster] ORDER BY [TeamId]", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var ATeamMaster = new TeamMasterVM();
                        ATeamMaster.TeamId = dataReader.GetInt32(0);
                        ATeamMaster.TeamName = dataReader.GetString(1);
                        ATeamMaster.TeamOrigin=dataReader.GetString(2);
                        ATeamMaster.DOB=dataReader.GetDateTime(3);
                        ATeamMaster.Phone = dataReader.GetString(4);
                        ATeamMaster.Address = dataReader.GetString(5);
                        listTeamMaster.Add(ATeamMaster);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return listTeamMaster;
            }
        }
        public TeamMasterVM GetSalesMaster(int teamId)
        {
            var tTeamMaster = new TeamMasterVM();
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                   
                    SqlCommand cmd = new SqlCommand(@"SELECT [TeamId],[TeamName],[TeamOrigin],[DOB],[Phone],[Address] FROM [TeamMaster] WHERE [TeamId]=" + teamId, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        tTeamMaster.TeamId = dataReader.GetInt32(0);
                        tTeamMaster.TeamName = dataReader.GetString(1);
                        tTeamMaster.TeamOrigin=dataReader.GetString(2);
                        tTeamMaster.DOB= dataReader.GetDateTime(3);
                        tTeamMaster.Phone = dataReader.GetString(4);
                        tTeamMaster.Address = dataReader.GetString(5);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return tTeamMaster;
            }
        }
        public List<TeamVM> GetSalesItem(int teamMasterId)
        {
            var listTeam = new List<TeamVM>();
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT si.[TeamPlayerId]
                                                    ,si.[TeamMasterId]
                                                    ,si.[PlayerId]
                                                    ,si.[Salary]
                                                    ,si.[NumberOfPlayers]
                                                    ,si.[Tax]
                                                    ,si.[TotalAmount]
                                                    ,i.PlayerCategory
                                                    FROM [Team] si
                                                    LEFT JOIN [Player] i ON i.PlayerId=si.PlayerId
                                                    WHERE si.[TeamMasterId]=" + teamMasterId, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var pTeam = new TeamVM();
                        pTeam.TeamPlayerId = dataReader.GetInt32(0);
                        pTeam.TeamMasterId = dataReader.GetInt32(1);
                        pTeam.PlayerId = dataReader.GetInt32(2);
                        pTeam.Salary = dataReader.GetDecimal(3);
                        pTeam.NumberOfPlayers = dataReader.GetDecimal(4);
                        pTeam.Tax = dataReader.GetDecimal(5);
                        pTeam.TotalAmount = dataReader.GetDecimal(6);
                        pTeam.PlayerCategory = dataReader.GetString(7);
                        listTeam.Add(pTeam);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return listTeam;
            }
        }
        public List<PlayerVM> GetItem()
        {
            var listPlayer = new List<PlayerVM>();
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT PlayerId, PlayerCategory FROM Player ORDER BY PlayerCategory", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        PlayerVM aplayer = new PlayerVM();
                        aplayer.PlayerId = dataReader.GetInt32(0);
                        aplayer.PlayerCategory = dataReader.GetString(1);
                        listPlayer.Add(aplayer);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return listPlayer;
            }
        }
        public void FillItem()
        {
            try
            {
                cbItem.Items.Clear();
                cbItem.DataSource = GetItem();
                cbItem.ValueMember = "PlayerId";
                cbItem.DisplayMember = "PlayerCategory";
                cbItem.SelectedIndex = 0;
            }
            catch
            {
            }
            finally
            {
            }
        }
        public PlayerVM GetItemById(int id)
        {
            var bplayer = new PlayerVM();
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("SELECT PlayerId, PlayerCategory, Salary, Tax FROM Player WHERE PlayerId = " + id, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        bplayer.PlayerId = dataReader.GetInt32(0);
                        bplayer.PlayerCategory = dataReader.GetString(1);
                        bplayer.Salary = dataReader.GetDecimal(2);
                        bplayer.Tax = dataReader.GetDecimal(3);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return bplayer;
            }
        }
        private decimal CalculateAmount(decimal salary, decimal numberofpl, decimal tax)
        {
            decimal unitPriceVated = numberofpl + (salary * (tax / 100));
            return unitPriceVated * numberofpl;
        }
        public TeamMasterVM AddSalesMaster(TeamMasterVM model)
        {
           
            //SqlCommand cmd = null;
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    #region ADD
                 
                  SqlCommand  cmd = new SqlCommand("INSERT INTO TeamMaster (TeamName,TeamOrigin,DOB,Phone,Address) VALUES('" + model.TeamName + "','" + model.TeamOrigin + "','" + model.DOB + "','" + model.Phone + "','" + model.Address + "')", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                    #region Get Sales-Master-ID
                    
                    cmd = new SqlCommand("SELECT MAX(SaleId) FROM SalesMaster", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    model.TeamId = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    #endregion
                }
                catch
                {
                }
                finally
                {
                   
                }
                return model;
            }
        }
        public TeamMasterVM UpdateSalesMaster(TeamMasterVM model)
        {
         
            SqlCommand cmd = null;
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {

                    #region ADD
                   
                    cmd = new SqlCommand("UPDATE TeamMaster SET Address='" + model.Address + "',TeamName='" + model.TeamName + "',TeamOrigin='" + model.TeamOrigin + "',DOB='" + model.DOB + "',Phone='" + model.Phone + "' WHERE TeamId=" + model.TeamId, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                return model;
            }
        }
        public void RemoveSalesItem(int teamId)
        {

            SqlCommand cmd = null;
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    #region ADD
                  
                    cmd = new SqlCommand("DELETE Team WHERE [TeamMasterId]=" + teamId, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void RemoveSalesMaster(int teamId)
        {
        
            SqlCommand cmd = null;
            using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
            {
                try
                {
                    #region ADD
                    cmd = new SqlCommand("DELETE TeamMaster WHERE TeamId=" + teamId, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void AddSalesItem(List<TeamVM> team, int teamMasterId)
        {
            foreach (TeamVM item in team)
            {
                item.TeamMasterId = teamMasterId;
            
                SqlCommand cmd = null;
                using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
                {
                    try
                    {
                        #region ADD
                       
                        cmd = new SqlCommand(@"INSERT INTO [dbo].[Team]
                                               ([TeamMasterId]
                                               ,[PlayerId]
                                               ,[Salary]
                                               ,[NumberOfPlayers]
                                               ,[Tax]
                                               ,[TotalAmount])
                                            VALUES
                                               ('" + item.TeamMasterId + "'" +
                                                   ",'" + item.PlayerId + "'" +
                                                   ",'" + item.Salary + "'" +
                                                   ",'" + item.NumberOfPlayers + "'" +
                                                   ",'" + item.Tax + "'" +
                                                   ",'" + item.TotalAmount + "')", con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        #endregion
                    }
                    catch
                    {
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TeamVM oSIVM = new TeamVM();
            oSIVM.TotalAmount = Convert.ToDecimal(txtAmount.Text.Trim());
            oSIVM.Salary = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            oSIVM.NumberOfPlayers = Convert.ToDecimal(txtQty.Text.Trim());
            oSIVM.Tax = Convert.ToDecimal(txtVat.Text.Trim());
            if (oSIVM.Salary > 0)
            {
                var oItem = (PlayerVM)cbItem.SelectedItem;
                oSIVM.PlayerId = oItem.PlayerId;
                oSIVM.TeamPlayerId = (int)DateTime.UtcNow.Subtract(new DateTime(2020, 1, 1)).TotalSeconds;
                oSIVM.PlayerCategory = oItem.PlayerCategory.Trim();
                var listSI = dgvItem.DataSource == null ? new List<TeamVM>() : (List<TeamVM>)dgvItem.DataSource;
                listSI.Add(oSIVM);
                dgvItem.DataSource = null;
                dgvItem.DataSource = listSI;
                ResetSalesItem();
            }
            else
            {
                MessageBox.Show("Select a Player to sell.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetSalesMaster();
            dgvItem.DataSource = null;
            ResetSalesItem();
            GetSalesMaster();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            #region Sales Master
            var teamId = Convert.ToInt32(lblSaleId.Text.Trim());
            #region Set Sales-Master Data
            var aTeamMaster = new TeamMasterVM();
            aTeamMaster.TeamId = teamId;
            aTeamMaster.Address = txtAddress.Text.Trim();
            aTeamMaster.TeamName = txtCustomer.Text.Trim();
            aTeamMaster.Phone = txtPhone.Text.Trim(); 
            aTeamMaster.TeamOrigin = radioButton1.Checked == true ? "Local" : "Foreign";
            aTeamMaster.DOB = dateTimePicker1.Value;

            #endregion
            if (teamId > 0)
            {
                #region UPDATE
                aTeamMaster = UpdateSalesMaster(aTeamMaster);
                #endregion
            }
            else
            {
                #region ADD
                aTeamMaster = AddSalesMaster(aTeamMaster);
                #endregion
            }
            #endregion
            #region Sales Items
            RemoveSalesItem(aTeamMaster.TeamId);
            var listSI = dgvItem.DataSource == null ? new List<TeamVM>() : (List<TeamVM>)dgvItem.DataSource;
            AddSalesItem(listSI, aTeamMaster.TeamId);
            #endregion
            ResetSalesItem();
            dgvItem.DataSource = null;
            ResetSalesMaster();
            SetGridSalesMaster();
            MessageBox.Show("Saved successfully.", "Message");
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (PlayerVM)cbItem.SelectedItem;
            var oItem = GetItemById(item.PlayerId);
            if (oItem != null)
            {
                txtUnitPrice.Text = oItem.Salary.ToString();
                txtVat.Text = oItem.Tax.ToString();


                if (decimal.TryParse(txtQty.Text, out decimal qty))
                {
                    txtAmount.Text = CalculateAmount(Convert.ToDecimal(oItem.Salary), qty, Convert.ToDecimal(oItem.Tax)).ToString();
                }
                else
                {

                    txtAmount.Text = "Invalid quantity";
                }
            }
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal unitPrice, qty, vat;
            if (decimal.TryParse(txtQty.Text.Trim(), out unitPrice) &&
                 decimal.TryParse(txtUnitPrice.Text.Trim(), out qty) &&
                     decimal.TryParse(txtVat.Text.Trim(), out vat))
                    {
                        txtAmount.Text = CalculateAmount(Convert.ToDecimal(txtUnitPrice.Text.Trim()), Convert.ToDecimal(txtQty.Text.Trim()), Convert.ToDecimal(txtVat.Text.Trim())).ToString();

                    }
                    else
                    {
                txtUnitPrice.Clear();
                txtQty.Clear();
                txtVat.Clear();
                txtAmount.Clear();

                    }
            
        }
        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItem.Columns[e.ColumnIndex].Name == "btnRemove")
            {
                var TeamPlayerId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["TeamPlayerId"].Value);
                var listSalesItem = dgvItem.DataSource == null ? new List<TeamVM>() : (List<TeamVM>)dgvItem.DataSource;
                var oTeam = listSalesItem.Where(x => x.TeamPlayerId == TeamPlayerId).FirstOrDefault();
                if (oTeam != null)
                {
                    listSalesItem.Remove(oTeam);
                    dgvItem.DataSource = null;
                    dgvItem.DataSource = listSalesItem;
                }
            }
        }
        //private void DisplayDetails(string id)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
        //    {
               

        //        Form2 form2 = new Form2(id);
        //        form2.Show();

        //        con.Close();
        //    }
        //}


        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (dgvSales.Columns[e.ColumnIndex].Name == "btnReports")
            {
                var id = senderGrid.Rows[e.RowIndex].Cells["TeamId"].Value.ToString();
                Form2 form2 = new Form2(id);
                form2.Show();

            }
            else if (dgvSales.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure to delete?", "Confirm!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var TeamId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["TeamId"].Value);
                   
                    RemoveSalesItem(TeamId);
                    
                  
                    RemoveSalesMaster(TeamId);
                  
                    ResetSalesMaster();
                    dgvItem.DataSource = null;
                    ResetSalesItem();
                    GetSalesMaster();
                    MessageBox.Show("Deleted successfully.", "Message");
                }
            }
            else if (dgvSales.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var TeamId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["TeamId"].Value);
                lblSaleId.Text = TeamId.ToString();

                var oTM = GetSalesMaster(TeamId);
                if (oTM != null)
                {
                    txtAddress.Text = oTM.Address;
                    txtCustomer.Text = oTM.TeamName;
                    txtPhone.Text = oTM.Phone;
                    dateTimePicker1.Text = oTM.DOB.ToShortDateString();
                    radioButton1.Text = oTM.TeamOrigin;
                    radioButton2.Text = oTM.TeamOrigin;
                }


                var listT = GetSalesItem(TeamId);
                dgvItem.DataSource = null;
                dgvItem.DataSource = listT;

                btnSubmit.Text = "UPDATE";
            }
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
           Form3 cf = new Form3();
           cf.Show();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Form4 cf = new Form4();
            cf.Show();
        }


        //private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
        //    {
        //        con.Open();
        //        string q = "select * from TeamMaster;";
        //        SqlCommand cmd = new SqlCommand(q, con);
        //        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        adap.Fill(ds, "TeamMaster");
        //        CrystalReport2 cr1 = new CrystalReport2();
        //        cr1.SetDataSource(ds);
        //        crystalReportViewer1.ReportSource = cr1;
        //        con.Close();
        //        crystalReportViewer1.Refresh();
        //        con.Close();
        //    }
        //}

        //private void crystalReportViewer2_Load(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionHelper.PDBCH))
        //    {
        //        con.Open();
        //        string q = "select * from Team;";
        //        SqlCommand cmd = new SqlCommand(q, con);
        //        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        adap.Fill(ds, "Team");
        //        CrystalReport3 cr2 = new CrystalReport3();
        //        cr2.SetDataSource(ds);
        //        crystalReportViewer2.ReportSource = cr2;
        //        con.Close();
        //        crystalReportViewer1.Refresh();
        //        con.Close();
        //    }

    }
    }

