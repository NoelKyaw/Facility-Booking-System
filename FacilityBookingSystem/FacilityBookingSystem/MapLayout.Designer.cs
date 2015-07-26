namespace FacilityBookingSystem
{
    partial class MapLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapLayout));
            this.Layout_PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Layout_PictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Layout_PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layout_PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Layout_PictureBox1
            // 
            this.Layout_PictureBox1.Image = global::FacilityBookingSystem.Properties.Resources.TT_UTW;
            this.Layout_PictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.Layout_PictureBox1.Name = "Layout_PictureBox1";
            this.Layout_PictureBox1.Size = new System.Drawing.Size(596, 403);
            this.Layout_PictureBox1.TabIndex = 0;
            this.Layout_PictureBox1.TabStop = false;
            // 
            // Layout_PictureBox2
            // 
            this.Layout_PictureBox2.Image = global::FacilityBookingSystem.Properties.Resources.TT_UTW;
            this.Layout_PictureBox2.Location = new System.Drawing.Point(-2, 402);
            this.Layout_PictureBox2.Name = "Layout_PictureBox2";
            this.Layout_PictureBox2.Size = new System.Drawing.Size(596, 407);
            this.Layout_PictureBox2.TabIndex = 1;
            this.Layout_PictureBox2.TabStop = false;
            // 
            // MapLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 808);
            this.Controls.Add(this.Layout_PictureBox2);
            this.Controls.Add(this.Layout_PictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapLayout";
            this.Text = "MapLayout";
            ((System.ComponentModel.ISupportInitialize)(this.Layout_PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layout_PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Layout_PictureBox1;
        private System.Windows.Forms.PictureBox Layout_PictureBox2;
    }
}