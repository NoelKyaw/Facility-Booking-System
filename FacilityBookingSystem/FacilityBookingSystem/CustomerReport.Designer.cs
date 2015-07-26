namespace FacilityBookingSystem
{
    partial class CustomerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerReport));
            this.CustomersR1 = new FacilityBookingSystem.CustomersR();
            this.CustomerReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CustomerReportViewer
            // 
            this.CustomerReportViewer.ActiveViewIndex = -1;
            this.CustomerReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomerReportViewer.CachedPageNumberPerDoc = 10;
            this.CustomerReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomerReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CustomerReportViewer.Name = "CustomerReportViewer";
            this.CustomerReportViewer.Size = new System.Drawing.Size(1350, 730);
            this.CustomerReportViewer.TabIndex = 0;
            this.CustomerReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.CustomerReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerReport";
            this.Text = "CustomerReport";
            this.Load += new System.EventHandler(this.CustomerReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        //private CrystalDecisions.Windows.Forms.CrystalReportViewer CustomersView;
        private CustomersR CustomersR1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CustomerReportViewer;
    }
}