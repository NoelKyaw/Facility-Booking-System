using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FacilityBookingSystem.Data;
using System.Data;
using System.Windows.Forms;

namespace FacilityBookingSystem.Controller
{
    public class Controller
    {
        public SqlConnection sqlconnection { get; set; }
        public SqlCommand sqlcommand { get; set; }

        public SqlDataAdapter sqladapter { get; set; }
        public DataSet dataset { get; set; }

        public Controller()
        {
            this.sqlconnection = new SqlConnection("Data Source = (local); Initial Catalog = BookingSystem; Integrated Security = SSPI");
        }

        public bool Excute_SqlCommand(string _cmd, string _value)
        {

            this.sqlcommand = new SqlCommand(_cmd, this.sqlconnection);
            this.sqlcommand.Parameters.Add("@ID", SqlDbType.VarChar);
            this.sqlcommand.Parameters["@ID"].Value = _value;
            this.sqladapter = new SqlDataAdapter(this.sqlcommand);
            this.dataset = new DataSet();

            this.sqlconnection.Open();
            this.sqladapter.Fill(dataset, "Customers");
            this.sqlconnection.Close();

            if (dataset.Tables[0].Rows.Count == 0) return false;
            else return true;
        }

        public bool Excute_SqlCommand(string _cmd)
        {
            return true;
        }

        public bool Book_SelectedItems(string category, Dictionary<int, List<int>> dict, string Customer_ID, string location, string courtid)
        {
            for (int i = 0; i < dict.Keys.Count; i++)
            {
                if (dict[i].Count() != 0)
                {
                    for (int n = 0; n < dict[i].Count; n++)
                    {
                        using (var context = new BookingSystemEntities())
                        {
                            List<Facility> _list = new List<Facility>();
                            DateTime _day = DateTime.Now.AddDays(i);

                            var linq = from x in context.Facilities
                                       where x.BookDate.Day == _day.Day
                                       where x.BookDate.Month == _day.Month
                                       where x.BookDate.Year == _day.Year
                                       where x.ID.IndexOf(category) >= 0
                                       select x;

                            _list = linq.ToList();
                            Facility facility = new Facility();
                            if (location == "0" && courtid == "0")
                            {
                                facility = _list.Where(u => u[dict[i][n]] == DataCache.Null_String).First();
                                facility[dict[i][n]] = Customer_ID;
                                //MessageBox.Show("day:" + i + "index:" + dict[i][n]);
                                context.SaveChanges();
                            }
                            else if (location != "0" && courtid == "0")
                            {
                                string str = null;
                                switch (location)
                                {
                                    case "1": str = "CAM"; break;
                                    case "2": str = "UTW"; break;
                                }
                                facility = _list.Where(u => u[dict[i][n]] == DataCache.Null_String && u.Location == str).First();
                                facility[dict[i][n]] = Customer_ID;
                                //MessageBox.Show("day:" + i + "index:" + dict[i][n]);
                                context.SaveChanges();
                            }
                            else if (location == "0" && courtid != "0")
                            {
                                string _id = category + (Convert.ToInt32(courtid) - 1).ToString();
                                facility = _list.Where(u => u[dict[i][n]] == DataCache.Null_String && u.ID.IndexOf(_id) >= 0).First();
                                facility[dict[i][n]] = Customer_ID;
                                //MessageBox.Show("day:" + i + "index:" + dict[i][n]);
                                context.SaveChanges();
                            }

                            var q = from x in context.Transactions
                                    select x;

                            Transaction transaction = new Transaction();

                            if (q.ToList().Count == 0) transaction.ID = 0;
                            else transaction.ID = q.ToList().Last().ID + 1;
                            transaction.FacilityID = facility.ID;
                            transaction.CustomerID = context.Customers.Where(e => e.ID == Customer_ID).First().ID;
                            transaction.BookDate = DateTime.Now;
                            transaction.TimeSlot = (dict[i][n] + 9) + ":00";
                            transaction.Status = "Confirm";

                            context.Transactions.Add(transaction);
                            context.SaveChanges();
                        }
                    }
                }
            }
            return true;
        }

        public void Get_CustomerTransactionsHistory(string Customer_ID)
        {
            BookingSystemEntities context = new BookingSystemEntities();

            var linq = from x in context.Transactions
                       where x.CustomerID == Customer_ID
                       select x;

            List<Transaction> _list = linq.Where(i => i.Status == "Confirm").ToList();
            DataCache.System_MainWindow.Show_TransactionsHistory(_list);
        }

        public bool Cancel_CustomerBooking(string _customerid, string transactioninfo)
        {
            string[] str = transactioninfo.Split('-');
            string[] bookdate = str[0].Split('/');
            bookdate[0] = (bookdate[0].Split(':'))[1];
            string _day = bookdate[0];
            string _month = bookdate[1];
            string _year = bookdate[2];
            str[1] = str[1].Substring(9, str[1].Length - 9);
            string _facilityid = str[1];
            string[] _str = str[2].Split(':');
            string timeslot = _str[1] + ":" + _str[2];

            BookingSystemEntities context = new BookingSystemEntities();
            Transaction tran = (from x in context.Transactions
                                where x.CustomerID == _customerid
                                where ((DateTime)x.BookDate).Day.ToString() == _day && ((DateTime)x.BookDate).Month.ToString() == _month && ((DateTime)x.BookDate).Year.ToString() == _year
                                where x.FacilityID == _facilityid
                                where x.TimeSlot == timeslot
                                select x).FirstOrDefault();



            Facility facility = (from x in context.Facilities
                                 where x.ID == _facilityid
                                 select x).First();

            timeslot = timeslot.Substring(0, 2);
            int index = Convert.ToInt32(timeslot);
            if (facility[index - 9] == _customerid.ToUpper())
            {
                facility[index - 9] = DataCache.Null_String;
                tran.Status = "Cancel";
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public void Get_DetailsScheduleWithConditions(string category)
        {
            BookingSystemEntities context = new BookingSystemEntities();
            DateTime _currenttime = DateTime.Now;

            //Get how many court remained in the future 7 days
            for (int i = 0; i < DataCache.System_Days_Beyond; i++)
            {
                //AddDays means to add an offset of today's DateTime
                DateTime _target_day_time = (DateTime.Now).AddDays(i);

                var linq = from x in context.Facilities
                           where x.BookDate.Day == _target_day_time.Day
                           where x.BookDate.Month == _target_day_time.Month
                           where x.BookDate.Year == _target_day_time.Year
                           where x.ID.IndexOf(category) >= 0
                           select x;

                List<Facility> _facilitylist = new List<Facility>();
                _facilitylist = linq.ToList();


                int count = 0;
                //Divide list into 12 time slots
                for (int n = 0; n < DataCache.System_TimeSlots_Count; n++)
                {
                    if (i == 0)
                    {
                        DateTime _day_time = DateTime.Now;
                        if (_day_time.Hour > n + 6)
                        {
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }
                        else
                        {
                            count = _facilitylist.Count;

                            //Get how many courts remained per time slot
                            for (int j = 0; j < _facilitylist.Count; j++)
                            {
                                if (_facilitylist[j][n] != DataCache.Null_String)
                                {
                                    count--;
                                }
                            }
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }

                    }
                    else
                    {
                        count = _facilitylist.Count;

                        //Get how many courts remained per time slot
                        for (int j = 0; j < _facilitylist.Count; j++)
                        {
                            if (_facilitylist[j][n] != DataCache.Null_String)
                            {
                                count--;
                            }
                        }
                        DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                    }
                }
            }

            Get_Category_ForComboBox(category);
        }

        public void Get_DetailsScheduleWithConditions(string category, string index)
        {
            BookingSystemEntities context = new BookingSystemEntities();
            DateTime _currenttime = DateTime.Now;

            string location = "CAM";
            switch (index)
            {
                case "1": location = "CAM"; break;
                case "2": location = "UTW"; break;
            }
            //Get how many court remained in the future 7 days
            for (int i = 0; i < DataCache.System_Days_Beyond; i++)
            {
                //AddDays means to add an offset of today's DateTime
                DateTime _target_day_time = (DateTime.Now).AddDays(i);

                var linq = from x in context.Facilities
                           where x.BookDate.Day == _target_day_time.Day
                           where x.BookDate.Month == _target_day_time.Month
                           where x.BookDate.Year == _target_day_time.Year
                           where x.ID.IndexOf(category) >= 0
                           select x;

                List<Facility> _facilitylist = new List<Facility>();
                _facilitylist = linq.Where(e => e.Location == location).ToList();


                int count = 0;
                //Divide list into 12 time slots
                for (int n = 0; n < DataCache.System_TimeSlots_Count; n++)
                {
                    if (i == 0)
                    {
                        DateTime _day_time = DateTime.Now;
                        if (_day_time.Hour > n + 6)
                        {
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }
                        else
                        {
                            count = _facilitylist.Count;

                            //Get how many courts remained per time slot
                            for (int j = 0; j < _facilitylist.Count; j++)
                            {
                                if (_facilitylist[j][n] != DataCache.Null_String)
                                {
                                    count--;
                                }
                            }
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }

                    }
                    else
                    {
                        count = _facilitylist.Count;

                        //Get how many courts remained per time slot
                        for (int j = 0; j < _facilitylist.Count; j++)
                        {
                            if (_facilitylist[j][n] != DataCache.Null_String)
                            {
                                count--;
                            }
                        }
                        DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                    }
                }
            }
        }

        public void Get_DetailsScheduleWithConditions(string category, int index)
        {
            BookingSystemEntities context = new BookingSystemEntities();
            DateTime _currenttime = DateTime.Now;
            index--;
            //Get how many court remained in the future 7 days
            for (int i = 0; i < DataCache.System_Days_Beyond; i++)
            {
                //AddDays means to add an offset of today's DateTime
                DateTime _target_day_time = (DateTime.Now).AddDays(i);

                var linq = from x in context.Facilities
                           where x.BookDate.Day == _target_day_time.Day
                           where x.BookDate.Month == _target_day_time.Month
                           where x.BookDate.Year == _target_day_time.Year
                           where x.ID.IndexOf(category+index) >= 0
                           select x;

                List<Facility> _facilitylist = new List<Facility>();
                _facilitylist = linq.Where(e => e.ID.IndexOf(category+index) >= 0).ToList();


                int count = 0;
                //Divide list into 12 time slots
                for (int n = 0; n < DataCache.System_TimeSlots_Count; n++)
                {
                    if (i == 0)
                    {
                        DateTime _day_time = DateTime.Now;
                        if (_day_time.Hour > n + 6)
                        {
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }
                        else
                        {
                            count = _facilitylist.Count;

                            //Get how many courts remained per time slot
                            for (int j = 0; j < _facilitylist.Count; j++)
                            {
                                if (_facilitylist[j][n] != DataCache.Null_String)
                                {
                                    count--;
                                }
                            }
                            DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                        }

                    }
                    else
                    {
                        count = _facilitylist.Count;

                        //Get how many courts remained per time slot
                        for (int j = 0; j < _facilitylist.Count; j++)
                        {
                            if (_facilitylist[j][n] != DataCache.Null_String)
                            {
                                count--;
                            }
                        }
                        DataCache.System_MainWindow.Display_BookDate_Summary(category, count, i, n + 9);
                    }
                }
            }
        }

        public void Get_Category_ForComboBox(string category)
        {
            BookingSystemEntities context = new BookingSystemEntities();
            var q = from x in context.Facilities
                    select x;

            //Count distinct Court Location
            List<string> list = new List<string>();
            list.Add("None");
            list.Add("CAM");
            list.Add("UTW");
            DataCache.System_MainWindow.Get_LocationComboBox(category).DataSource = list;

            //Count distinct Court No.
            List<string> _list = new List<string>();
            _list.Add("None");
            for(int i = 0; i <= 8; i ++)
            {
                _list.Add(category + i);
            }

            DataCache.System_MainWindow.Get_CourtNoComboBox(category).DataSource = _list;
        }
    }
}
