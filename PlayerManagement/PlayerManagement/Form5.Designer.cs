namespace PlayerManagement
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CrystalReport62 = new PlayerManagement.Report.CrystalReport6();
            this.CrystalReport61 = new PlayerManagement.Report.CrystalReport6();
            this.CrystalReport81 = new PlayerManagement.Report.CrystalReport8();
            this.CrystalReport82 = new PlayerManagement.Report.CrystalReport8();
            this.CrystalReport83 = new PlayerManagement.Report.CrystalReport8();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport85 = new PlayerManagement.Report.CrystalReport8();
            this.CrystalReport84 = new PlayerManagement.Report.CrystalReport8();
            this.CrystalReport63 = new PlayerManagement.Report.CrystalReport6();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport63;
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);

        }

        #endregion
        private Report.CrystalReport6 CrystalReport61;
        private Report.CrystalReport6 CrystalReport62;
        private Report.CrystalReport8 CrystalReport81;
        private Report.CrystalReport8 CrystalReport82;
        private Report.CrystalReport8 CrystalReport83;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Report.CrystalReport8 CrystalReport84;
        private Report.CrystalReport8 CrystalReport85;
        private Report.CrystalReport6 CrystalReport63;
    }
}