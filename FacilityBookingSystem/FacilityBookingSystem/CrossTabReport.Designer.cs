namespace FacilityBookingSystem
{
    partial class CrossTabReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossTabReport));
            this.CrossTabReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrossTabReportViewer
            // 
            this.CrossTabReportViewer.ActiveViewIndex = -1;
            this.CrossTabReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrossTabReportViewer.CachedPageNumberPerDoc = 10;
            this.CrossTabReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrossTabReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrossTabReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CrossTabReportViewer.Name = "CrossTabReportViewer";
            this.CrossTabReportViewer.Size = new System.Drawing.Size(1350, 730);
            this.CrossTabReportViewer.TabIndex = 0;
            this.CrossTabReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CrossTabReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.CrossTabReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrossTabReport";
            this.Text = "CrossTabReport";
            this.Load += new System.EventHandler(this.CrossTabReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrossTabReportViewer;
    }
}