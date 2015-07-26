using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacilityBookingSystem.Data;

namespace FacilityBookingSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataCache.System_LogIn_Controller = new Controller.LogIn_Controller();
            DataCache.System_Controller = new Controller.Controller();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form Login = new LogIn();
            Login.ShowDialog(); 
            if(Login.DialogResult == DialogResult.OK)
                Application.Run(new MainWindow());
        }
    }
}
