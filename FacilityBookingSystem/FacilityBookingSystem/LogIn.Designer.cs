namespace FacilityBookingSystem
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.UserID_TextBox = new System.Windows.Forms.TextBox();
            this.UserPassword_TextBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.LogInProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Logo_PictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserID_TextBox
            // 
            this.UserID_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserID_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID_TextBox.Location = new System.Drawing.Point(104, 169);
            this.UserID_TextBox.Name = "UserID_TextBox";
            this.UserID_TextBox.Size = new System.Drawing.Size(197, 30);
            this.UserID_TextBox.TabIndex = 2;
            this.UserID_TextBox.GotFocus += new System.EventHandler(this.CheckIfNeedToClearIDTips);
            this.UserID_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Log_In_System);
            this.UserID_TextBox.LostFocus += new System.EventHandler(this.CheckIfNeedToShowUserIDTips);
            // 
            // UserPassword_TextBox
            // 
            this.UserPassword_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserPassword_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPassword_TextBox.Location = new System.Drawing.Point(104, 198);
            this.UserPassword_TextBox.Name = "UserPassword_TextBox";
            this.UserPassword_TextBox.Size = new System.Drawing.Size(197, 30);
            this.UserPassword_TextBox.TabIndex = 3;
            this.UserPassword_TextBox.GotFocus += new System.EventHandler(this.CheckIfNeedToClearPasswordTips);
            this.UserPassword_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Log_In_System);
            this.UserPassword_TextBox.LostFocus += new System.EventHandler(this.CheckIfNeedToShowUserPasswordTips);
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.SystemColors.Control;
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LogInButton.Location = new System.Drawing.Point(104, 239);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(197, 29);
            this.LogInButton.TabIndex = 1;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // LogInProgressBar
            // 
            this.LogInProgressBar.Enabled = false;
            this.LogInProgressBar.Location = new System.Drawing.Point(0, 145);
            this.LogInProgressBar.MarqueeAnimationSpeed = 15;
            this.LogInProgressBar.Name = "LogInProgressBar";
            this.LogInProgressBar.Size = new System.Drawing.Size(414, 10);
            this.LogInProgressBar.Step = 5;
            this.LogInProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LogInProgressBar.TabIndex = 4;
            this.LogInProgressBar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::FacilityBookingSystem.Properties.Resources.LogIn_BackGround;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Logo_PictureBox);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 159);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(50, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facility Booking System";
            // 
            // Logo_PictureBox
            // 
            this.Logo_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.Logo_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Logo_PictureBox.Image")));
            this.Logo_PictureBox.Location = new System.Drawing.Point(125, 18);
            this.Logo_PictureBox.Name = "Logo_PictureBox";
            this.Logo_PictureBox.Size = new System.Drawing.Size(144, 69);
            this.Logo_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_PictureBox.TabIndex = 1;
            this.Logo_PictureBox.TabStop = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(414, 277);
            this.Controls.Add(this.LogInProgressBar);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.UserPassword_TextBox);
            this.Controls.Add(this.UserID_TextBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 315);
            this.MinimumSize = new System.Drawing.Size(430, 315);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox UserID_TextBox;
        private System.Windows.Forms.TextBox UserPassword_TextBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.ProgressBar LogInProgressBar;
        private System.Windows.Forms.PictureBox Logo_PictureBox;
        private System.Windows.Forms.Label label1;
    }
}

