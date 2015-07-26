namespace FacilityBookingSystem
{
    partial class TranscationsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranscationsReport));
            this.TranscationView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TranscationR1 = new FacilityBookingSystem.TranscationR();
            this.SuspendLayout();
            // 
            // TranscationView
            // 
            this.TranscationView.ActiveViewIndex = 0;
            this.TranscationView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TranscationView.CachedPageNumberPerDoc = 10;
            this.TranscationView.Cursor = System.Windows.Forms.Cursors.Default;
            this.TranscationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranscationView.Location = new System.Drawing.Point(0, 0);
            this.TranscationView.Name = "TranscationView";
            this.TranscationView.ReportSource = this.TranscationR1;
            this.TranscationView.Size = new System.Drawing.Size(1350, 730);
            this.TranscationView.TabIndex = 0;
            this.TranscationView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // TranscationsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.TranscationView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TranscationsReport";
            this.Text = "TranscationsReport";
            this.Load += new System.EventHandler(this.TranscationsReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer TranscationView;
        private TranscationR TranscationR1;
    }
}