using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using FacilityBookingSystem.Data;

namespace FacilityBookingSystem
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            CheckIfNeedToShowUserIDTips(null, null);
            CheckIfNeedToShowUserPasswordTips(null, null);
        }

        private void CheckIfNeedToShowUserIDTips(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID_TextBox.Text))
            {
                UserID_TextBox.Text = "User ID";
                UserID_TextBox.ForeColor = Color.LightGray;
            }
        }

        private void CheckIfNeedToClearIDTips(object sender, EventArgs e)
        {
            if (UserID_TextBox.Text == "User ID")
            {
                UserID_TextBox.Text = null;
                UserID_TextBox.ForeColor = Color.Black;
            }
        }

        private void CheckIfNeedToShowUserPasswordTips(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserPassword_TextBox.Text))
            {
                UserPassword_TextBox.Text = "Password";
                UserPassword_TextBox.ForeColor = Color.LightGray;
                UserPassword_TextBox.PasswordChar = '\0';
            }
        }

        private void CheckIfNeedToClearPasswordTips(object sender, EventArgs e)
        {
            if (UserPassword_TextBox.Text == "Password")
            {
                UserPassword_TextBox.Text = null;
                UserPassword_TextBox.ForeColor = Color.Black;
                UserPassword_TextBox.PasswordChar = '*' ;
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (UserID_TextBox.Text != "User ID"  && UserPassword_TextBox.Text != "Password")
            {
                this.LogInProgressBar.Visible = true;

                if (DataCache.System_LogIn_Controller.Log_In_System(UserPassword_TextBox.Text, UserPassword_TextBox.Text))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.LogInProgressBar.Visible = false;
                    MessageBox.Show("User ID or Password is incorrect.");
                }
            }
            else
            {
                MessageBox.Show("User ID & Password");
            }
        }

        private void Log_In_System(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LogInButton_Click(null, null);
            }
        }
    }
}
