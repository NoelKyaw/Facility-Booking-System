using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacilityBookingSystem.Controller;
using System.Windows.Forms;

namespace FacilityBookingSystem.Data
{
    public class DataCache
    {
        public static Controller.LogIn_Controller System_LogIn_Controller { get; set; }
        public static Controller.Controller System_Controller { get; set; }

        public const int System_Days_Beyond = 7;

        public const int System_TimeSlots_Count = 12;

        public const string Null_String = "000000000";

        public static MainWindow System_MainWindow { get; set; }

    }
}
