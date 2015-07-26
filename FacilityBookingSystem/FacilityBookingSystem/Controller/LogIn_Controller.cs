using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FacilityBookingSystem.Controller
{
    public class LogIn_Controller
    {
        private SqlConnection LogIn_Sqlconnection { get; set; }
        private SqlCommand LogIn_Sqlcommand { get; set; }

        private IDataReader LogIn_DataReader { get; set; }

        public LogIn_Controller()
        {
            this.LogIn_Sqlconnection = new SqlConnection("Data Source = (local); Initial Catalog = BookingSystem; Integrated Security = SSPI");
        }

        public bool Log_In_System(string User_ID, string User_Password)
        {
            this.LogIn_Sqlconnection.Open();
            this.LogIn_Sqlcommand = new SqlCommand("Select password from [user] where userid = @ID", this.LogIn_Sqlconnection);
            this.LogIn_Sqlcommand.Parameters.Add("@ID", SqlDbType.NVarChar);
            this.LogIn_Sqlcommand.Parameters["@ID"].Value = User_ID;
            this.LogIn_DataReader = this.LogIn_Sqlcommand.ExecuteReader();

            try
            {
                this.LogIn_DataReader.Read();
                if (User_Password == (string)this.LogIn_DataReader[0])
                {
                    this.LogIn_Sqlconnection.Close();
                    return true;
                }
                else throw new Exception();
            }
            catch
            {
                this.LogIn_Sqlconnection.Close();
                return false;
            }
        }
    }
}
