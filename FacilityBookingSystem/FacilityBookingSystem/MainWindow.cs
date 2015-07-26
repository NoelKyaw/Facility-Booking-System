using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FacilityBookingSystem.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace FacilityBookingSystem
{
    public partial class MainWindow : Form
    {
        private bool CustomerID_Input { get; set; }

        private bool Badminton_Updated { get; set; }

        private bool Tennis_Updated { get; set; }

        private bool TableTennis_Updated { get; set; }

        private bool SquashCourt_Updated { get; set; }

        private bool Location_Exchange { get; set; }
        private bool CourtNo_Exchange { get; set; }

        private System.Windows.Forms.Timer System_Timer { get; set; }

        private List<ListBox> Badminton_ListBox_List { get; set; }
        private List<Label> Badminton_Label_List { get; set; }

        private List<ListBox> Tennis_ListBox_List { get; set; }
        private List<Label> Tennis_Label_List { get; set; }

        private List<ListBox> TableTennis_ListBox_List { get; set; }
        private List<Label> TableTennis_Label_List { get; set; }

        private List<ListBox> SquashCourt_ListBox_List { get; set; }
        private List<Label> SquashCourt_Label_List { get; set; }

        private Dictionary<int, List<int>> SelectedItems_Dict { get; set; }
        private int Current_SelectedCount { get; set; }
        private string Current_SelectedCategory { get; set; }

        private ComboBox Current_SeletedLocation { get; set; }
        private ComboBox Current_SelectedCourtNo { get; set; }

        private string[,] rssData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Badminton_ListBox_List = new List<ListBox>();
            Badminton_Label_List = new List<Label>();
            Tennis_ListBox_List = new List<ListBox>();
            Tennis_Label_List = new List<Label>();
            TableTennis_ListBox_List = new List<ListBox>();
            TableTennis_Label_List = new List<Label>();
            SquashCourt_ListBox_List = new List<ListBox>();
            SquashCourt_Label_List = new List<Label>();
            SelectedItems_Dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < DataCache.System_Days_Beyond; i++)
                SelectedItems_Dict.Add(i, new List<int>());
            Current_SelectedCount = 0;

            #region Badminton Controls
            //Badminton_Updated = false;
            Badminton_ListBox_List.Add(Bad_DayOne_ListBox);
            Badminton_ListBox_List.Add(Bad_DayTwo_ListBox);
            Badminton_ListBox_List.Add(Bad_DayThree_ListBox);
            Badminton_ListBox_List.Add(Bad_DayFour_ListBox);
            Badminton_ListBox_List.Add(Bad_DayFive_ListBox);
            Badminton_ListBox_List.Add(Bad_DaySix_ListBox);
            Badminton_ListBox_List.Add(Bad_DaySeven_ListBox);

            Badminton_Label_List.Add(Badminton_Day1_Label);
            Badminton_Label_List.Add(Badminton_Day2_Label);
            Badminton_Label_List.Add(Badminton_Day3_Label);
            Badminton_Label_List.Add(Badminton_Day4_Label);
            Badminton_Label_List.Add(Badminton_Day5_Label);
            Badminton_Label_List.Add(Badminton_Day6_Label);
            Badminton_Label_List.Add(Badminton_Day7_Label);
            #endregion

            #region Tennis Controls
            //Tennis_Updated = false;
            Tennis_ListBox_List.Add(Tennis_DayOne_ListBox);
            Tennis_ListBox_List.Add(Tennis_DayTwo_ListBox);
            Tennis_ListBox_List.Add(Tennis_DayThree_ListBox);
            Tennis_ListBox_List.Add(Tennis_DayFour_ListBox);
            Tennis_ListBox_List.Add(Tennis_DayFive_ListBox);
            Tennis_ListBox_List.Add(Tennis_DaySix_ListBox);
            Tennis_ListBox_List.Add(Tennis_DaySeven_ListBox);

            Tennis_Label_List.Add(Tennis_DayOne_Label);
            Tennis_Label_List.Add(Tennis_DayTwo_Label);
            Tennis_Label_List.Add(Tennis_DayThree_Label);
            Tennis_Label_List.Add(Tennis_DayFour_Label);
            Tennis_Label_List.Add(Tennis_DayFive_Label);
            Tennis_Label_List.Add(Tennis_DaySix_Label);
            Tennis_Label_List.Add(Tennis_DaySeven_Label);
            #endregion

            #region Table Tennis Controls
            //TableTennis_Updated = false;
            TableTennis_ListBox_List.Add(Table_DayOne_ListBox);
            TableTennis_ListBox_List.Add(Table_DayTwo_ListBox);
            TableTennis_ListBox_List.Add(Table_DayThree_ListBox);
            TableTennis_ListBox_List.Add(Table_DayFour_ListBox);
            TableTennis_ListBox_List.Add(Table_DayFive_ListBox);
            TableTennis_ListBox_List.Add(Table_DaySix_ListBox);
            TableTennis_ListBox_List.Add(Table_DaySeven_ListBox);

            TableTennis_Label_List.Add(Table_DayOne_Label);
            TableTennis_Label_List.Add(Table_DayTwo_Label);
            TableTennis_Label_List.Add(Table_DayThree_Label);
            TableTennis_Label_List.Add(Table_DayFour_Label);
            TableTennis_Label_List.Add(Table_DayFive_Label);
            TableTennis_Label_List.Add(Table_DaySix_Label);
            TableTennis_Label_List.Add(Table_DaySeven_Label);
            #endregion

            #region Squash Court Controls
            //SquashCourt_Updated = false;
            SquashCourt_ListBox_List.Add(SQ_DayOne_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DayTwo_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DayThree_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DayFour_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DayFive_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DaySix_ListBox);
            SquashCourt_ListBox_List.Add(SQ_DaySeven_ListBox);

            SquashCourt_Label_List.Add(SQ_DayOne_Label);
            SquashCourt_Label_List.Add(SQ_DayTwo_Label);
            SquashCourt_Label_List.Add(SQ_DayThree_Label);
            SquashCourt_Label_List.Add(SQ_DayFour_Label);
            SquashCourt_Label_List.Add(SQ_DayFive_Label);
            SquashCourt_Label_List.Add(SQ_DaySix_Label);
            SquashCourt_Label_List.Add(SQ_DaySeven_Label);
            #endregion

            this.CustomerID_Input = false;
            this.System_Timer = new System.Windows.Forms.Timer();
            this.System_Timer.Enabled = false;
            this.System_Timer.Interval = 1000;
            this.System_Timer.Tick += new EventHandler(UpdateTime);
            this.System_Timer.Start();
            UpdateTime(null, null);

            DateTime _str = DateTime.Now;
            Month_Label.Text = _str.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_str.Month) + " " + _str.Year;
            MainWindow_StatusBar.Text = "Window Loaded.";

            this.Location_Exchange = true;
            this.CourtNo_Exchange = true;
            this.Book_Button.Enabled = false;
            DataCache.System_MainWindow = this;
        }

        public string Get_CustomerID()
        {
            return this.Search_Number_TextBox.Text;
        }

        public void Show_TransactionsHistory(List<Transaction> _list)
        {
            if (_list.Count != 0)
                foreach (Transaction i in _list)
                {
                    DateTime _day = (DateTime)i.BookDate;
                    this.Customer_TranHistory_ListBox.Items.Add("BooDate:" + _day.Day + "/" + _day.Month + "/" + _day.Year + "-Facility:" + i.FacilityID + "-TimeSlot:" + i.TimeSlot);
                }
        }

        public ComboBox Get_LocationComboBox(string category)
        {
            switch (category)
            {
                case "BA":
                    return Badminton_Location_ComboBox;
                case "TE":
                    return Tennis_Location_ComboBox;
                case "TA":
                    return TableTennis_Location_ComboBox;
                case "SQ":
                    return SQ_Location_ComboBox;
                default: return null;
            }
        }

        public ComboBox Get_CourtNoComboBox(string category)
        {
            switch (category)
            {
                case "BA":
                    return Badminton_CourtNo_ComboBox;
                case "TE":
                    return Tennis_CourtNo_ComboBox;
                case "TA":
                    return TableTennis_CourtNo_ComboBox;
                case "SQ":
                    return SQ_CourtNo_ComboBox;
                default: return null;
            }
        }

        #region RSS Additional Function in Overview Panel
        private void m1_Load()
        {
            rssData = getRssData("http://www.skysports.com/rss/0,20514,12993,00.xml");

            for (int i = 0; i < rssData.GetLength(0); i++)
            {
                if (rssData[i, 0] != null)
                {
                    //this.rssListView.Items.Add(rssData[i, 0]);
                    this.rssListBox.Items.Add(rssData[i, 0]);
                }

            }
        }

        private string[,] getRssData(String channel)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);

            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            string[,] tempRssData = new string[100, 3];

            for (int i = 0; i < rssItems.Count; i++)
            {
                System.Xml.XmlNode rssNode;

                rssNode = rssItems.Item(i).SelectSingleNode("title");
                if (rssNode != null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("description");

                if (rssNode != null)
                {
                    tempRssData[i, 1] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 1] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("link");

                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }
            }

            return tempRssData;
        }

        private void rssListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rssData[rssListBox.SelectedIndex, 1] != null)
                DescriptionBox.Text = rssData[rssListBox.SelectedIndex, 1];
            if (rssData[rssListBox.SelectedIndex, 2] != null)
                linkLabel.Text = "GoTo: " + rssData[rssListBox.SelectedIndex, 0];
        }
        #endregion

        private void UpdateTime(object sender, EventArgs e)
        {
            DateTime str = DateTime.Now;
            Clock_Label.Text = str.Hour.ToString().PadLeft(2, '0') + ":" + str.Minute.ToString().PadLeft(2, '0') + ":" + str.Second.ToString().PadLeft(2, '0');
        }

        //Get customer detail information
        //Occurs when user input correct format of Staff/Student ID number
        private void CheckClientInfo(object sender, EventArgs e)
        {
            if (Search_Number_TextBox.Text.Length == 9)
            {
                if (DataCache.System_Controller.Excute_SqlCommand("Select * from customers where ID = @ID", Search_Number_TextBox.Text))
                {
                    this.CustomerID_Input = true;
                    Name_Label.Text = DataCache.System_Controller.dataset.Tables[0].Rows[0][1].ToString();
                    Department_Label.Text = DataCache.System_Controller.dataset.Tables[0].Rows[0][2].ToString();
                    Address_Label.Text = DataCache.System_Controller.dataset.Tables[0].Rows[0][3].ToString();
                    Phone_Label.Text = DataCache.System_Controller.dataset.Tables[0].Rows[0][5].ToString();
                    Email_Label.Text = DataCache.System_Controller.dataset.Tables[0].Rows[0][6].ToString();

                    this.Customer_TranHistory_ListBox.Items.Clear();
                    DataCache.System_Controller.Get_CustomerTransactionsHistory(Search_Number_TextBox.Text.ToUpper());
                    Create_New_Button.Text = "Update";
                }
                else ClearCustomerDetails();
            }
            else ClearCustomerDetails();
        }

        private void ClearCustomerDetails()
        {
            this.CustomerID_Input = false;
            this.Create_New_Button.Text = "New";
            Name_Label.Text = null;
            Department_Label.Text = null;
            Address_Label.Text = null;
            Phone_Label.Text = null;
            Email_Label.Text = null;
        }

        private void CheckIfNeedToShowSearchTips(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Search_Number_TextBox.Text))
            {
                Search_Number_TextBox.Text = "Staff/Student ID";
                Search_Number_TextBox.ForeColor = Color.LightGray;
            }
        }

        private void CheckIfNeedToClearSearchTips(object sender, EventArgs e)
        {
            if (Search_Number_TextBox.Text == "Staff/Student ID")
            {
                Search_Number_TextBox.Text = null;
                Search_Number_TextBox.ForeColor = Color.Black;
            }
        }

        //GetDetails for any tab of Maind_Tabcontrol
        //Occurs when user change the tabs.
        private void GetInformationDetails(object sender, EventArgs e)
        {
            var i = sender as TabControl;
            switch (i.SelectedIndex)
            {
                case 0: if (this.CustomerID_Input) { this.Customer_TranHistory_ListBox.Items.Clear(); DataCache.System_Controller.Get_CustomerTransactionsHistory(Search_Number_TextBox.Text.ToUpper()); } Book_Button.Enabled = false; break;
                case 1: Facilities_ShowInfo("BA", null, 0); this.Badminton_Updated = true; Book_Button.Enabled = true; Current_SelectedCategory = "BA"; Clear_SelectedDict(); this.Current_SeletedLocation = this.Badminton_Location_ComboBox; this.Current_SelectedCourtNo = this.Badminton_CourtNo_ComboBox; break;
                case 2: Facilities_ShowInfo("TE", null, 0); this.Tennis_Updated = true; Book_Button.Enabled = true; Current_SelectedCategory = "TE"; Clear_SelectedDict(); this.Current_SeletedLocation = this.Tennis_Location_ComboBox; this.Current_SelectedCourtNo = this.Tennis_CourtNo_ComboBox; break;
                case 3: Facilities_ShowInfo("TA", null, 0); this.TableTennis_Updated = true; Book_Button.Enabled = true; Current_SelectedCategory = "TA"; Clear_SelectedDict(); this.Current_SeletedLocation = this.TableTennis_Location_ComboBox; this.Current_SelectedCourtNo = this.TableTennis_CourtNo_ComboBox; break;
                case 4: Facilities_ShowInfo("SQ", null, 0); this.SquashCourt_Updated = true; Book_Button.Enabled = true; Current_SelectedCategory = "SQ"; Clear_SelectedDict(); this.Current_SeletedLocation = this.SQ_Location_ComboBox; this.Current_SelectedCourtNo = this.SQ_CourtNo_ComboBox; break;
                case 5: Book_Button.Enabled = false; break;
            }
        }
        
        //Facilities Detail Information
        #region Search General Details for different facilities & Display
        //Search details of different facilities
        //Transfer _ID to show different facilities
        //BA = Badminton TE = Tennis TA = Table Tennis SQ = Squash Court
        private void Facilities_ShowInfo(string category, string location, int courtno)
        {
            List<ListBox> _listbox = new List<ListBox>();

            switch (category)
            {
                case "BA": _listbox = this.Badminton_ListBox_List; break;
                case "TE": _listbox = this.Tennis_ListBox_List; break;
                case "TA": _listbox = this.TableTennis_ListBox_List; break;
                case "SQ": _listbox = this.SquashCourt_ListBox_List; break;
            }

            foreach (ListBox i in _listbox)
                i.Items.Clear();

            if(location == null && courtno == 0)
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(category);
            if(location == null && courtno != 0)
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(category, location);
            if(location != null && courtno == 0)
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(category, courtno);
        }

        //Display details in ListBoxs
        public void Display_BookDate_Summary(string category, int count, int Day, int period)
        {
            ListBox _listbox = new ListBox();

            switch (category)
            {
                case "BA":
                    _listbox = Badminton_ListBox_List[Day];
                    Badminton_Label_List[Day].Text = DateTime.Now.AddDays(Day).Day.ToString() + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.AddDays(Day).Month);
                    break;
                case "TE":
                    _listbox = Tennis_ListBox_List[Day];
                    Tennis_Label_List[Day].Text = DateTime.Now.AddDays(Day).Day.ToString() + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.AddDays(Day).Month);
                    break;
                case "TA":
                    _listbox = TableTennis_ListBox_List[Day];
                    TableTennis_Label_List[Day].Text = DateTime.Now.AddDays(Day).Day.ToString() + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.AddDays(Day).Month);
                    break;
                case "SQ":
                    _listbox = SquashCourt_ListBox_List[Day];
                    SquashCourt_Label_List[Day].Text = DateTime.Now.AddDays(Day).Day.ToString() + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.AddDays(Day).Month);
                    break;
            }

            _listbox.Items.Add(" " + period.ToString().PadLeft(2, '0') + ":00" + " (" + count + ")");
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox _listbox = sender as ListBox;
            string text = _listbox.Items[e.Index].ToString();
            Regex reg_1 = new Regex(@"\(0\)");
            Regex reg_2 = new Regex(@"\*");

            e.DrawBackground();
            Graphics g = e.Graphics;
            SolidBrush _brush;
            if (reg_1.Match(text).Success)
            {
                _brush = new SolidBrush(Color.Red);
            }
            else if (reg_2.Match(text).Success)
            {
                _brush = new SolidBrush(Color.AliceBlue);
            }
            else _brush = new SolidBrush(Color.GreenYellow);
            g.FillRectangle(_brush, e.Bounds);
            Font f = new System.Drawing.Font("Arial", 20);
            g.DrawString(text, f, new SolidBrush(Color.BlueViolet), _listbox.GetItemRectangle(e.Index).Location, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        #endregion

        #region Select Data & Display
        private void UpdateSelectedIndex(object sender, EventArgs e)
        {
            ListBox _listbox = sender as ListBox;
            List<ListBox> _list = new List<ListBox>();
            int day = 0;
            if (_listbox.Name.IndexOf("Bad") >= 0)
            {
                _list = Badminton_ListBox_List;
            }
            else if (_listbox.Name.IndexOf("Tennis") >= 0)
            {
                _list = Tennis_ListBox_List;
            }
            else if (_listbox.Name.IndexOf("Table") >= 0)
            {
                _list = TableTennis_ListBox_List;
            }
            else if (_listbox.Name.IndexOf("SQ") >= 0)
            {
                _list = SquashCourt_ListBox_List;
            }

            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Name == _listbox.Name)
                {
                    day = i;
                    break;
                }
            }

            if (this.SelectedItems_Dict[day].Where(i => i == _listbox.SelectedIndex).Count() != 0)
            {
                this.SelectedItems_Dict[day].Remove(_listbox.SelectedIndex);
                this.Current_SelectedCount--;
                Display_SelectedItem(_listbox, e);
            }
            else
            {
                if (_listbox.SelectedItem.ToString().IndexOf("(0)") < 0)
                {
                    this.SelectedItems_Dict[day].Add(_listbox.SelectedIndex);
                    this.Current_SelectedCount++;
                    Display_SelectedItem(_listbox, e);
                }
            }
        }

        private void Display_SelectedItem(ListBox _listbox, EventArgs e)
        {
            List<string> _list = _listbox.Items.Cast<string>().ToList();
            string _str = _list[_listbox.SelectedIndex].Substring(0, 1);
            if (_str == "*")
            {
                _str = _list[_listbox.SelectedIndex].Substring(1, _list[_listbox.SelectedIndex].Length - 1);
                _list[_listbox.SelectedIndex] = " " + _str;
            }
            else
            {
                _str = _list[_listbox.SelectedIndex].Substring(1, _list[_listbox.SelectedIndex].Length - 1);
                _list[_listbox.SelectedIndex] = "*" + _str;
            }
            _listbox.Items.Clear();

            foreach (var i in _list)
                _listbox.Items.Add(i);
        }

        #endregion

        #region Booking Selected Items
        private void Book_SelectedItem(object sender, EventArgs e)
        {
            if (this.CustomerID_Input && this.Current_SelectedCount > 0)
            {
                if (DataCache.System_Controller.Book_SelectedItems(
                    this.Current_SelectedCategory,
                    SelectedItems_Dict,
                    Search_Number_TextBox.Text.ToUpper(),
                    this.Current_SeletedLocation.SelectedIndex.ToString(),
                    this.Current_SelectedCourtNo.SelectedIndex.ToString()
                    )
                )
                {
                    Clear_SelectedDict();
                    this.Current_SelectedCount = 0;

                    Facilities_ShowInfo(Current_SelectedCategory, null, 0);
                    MainWindow_StatusBar.Text = "Book Successfully.";
                    MainWindow_StatusBar.ForeColor = Color.Yellow;
                    MainWindow_StatusBar.BackColor = Color.Green;
                }
            }
            else
            {
                if (!this.CustomerID_Input)
                    MessageBox.Show("Input customer ID first.");
                else MessageBox.Show("Please select any item first.");
            }
        }
        #endregion

        private void Clear_SelectedDict()
        {
            foreach (var i in SelectedItems_Dict.Keys)
            {
                SelectedItems_Dict[i].Clear();
            }
        }

        #region Cancel Transaction of Customers
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            
            if (this.CustomerID_Input && this.Customer_TranHistory_ListBox.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Are you confirm to cancel this transaction?", "Cancel Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DataCache.System_Controller.Cancel_CustomerBooking(Search_Number_TextBox.Text, this.Customer_TranHistory_ListBox.SelectedItem.ToString()))
                    {
                        this.Customer_TranHistory_ListBox.Items.Clear();
                        DataCache.System_Controller.Get_CustomerTransactionsHistory(Search_Number_TextBox.Text.ToUpper());
                        MainWindow_StatusBar.Text = "Cancel Successfully.";
                        MainWindow_StatusBar.ForeColor = Color.Yellow;
                        MainWindow_StatusBar.BackColor = Color.Green;
                    }
                    else
                    {
                        MainWindow_StatusBar.Text = "Cancel Unsuccessfully.";
                        MainWindow_StatusBar.ForeColor = Color.Yellow;
                        MainWindow_StatusBar.BackColor = Color.Red;
                    }
                }
            }
            else MessageBox.Show("Input customer ID first.");
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "Update")
            {
                if (this.CustomerID_Input)
                {
                    Customers CustomerForm = new Customers(sender);
                    CustomerForm.ShowDialog();
                }
                else MessageBox.Show("Input customer ID first.");
            }
            else
            {
                Customers CustomerForm = new Customers(sender);
                CustomerForm.ShowDialog();
            }
        }

        #region Classify Badminton
        private void Classify_Badminton_Location(ComboBox sender)
        {
                foreach (ListBox i in Badminton_ListBox_List)
                    i.Items.Clear();
                Clear_SelectedDict();

                if (sender.SelectedIndex != 0)
                {
                    Current_SeletedLocation = sender;
                    DataCache.System_Controller.Get_DetailsScheduleWithConditions("BA", sender.SelectedIndex.ToString());
                }
                else
                    DataCache.System_Controller.Get_DetailsScheduleWithConditions("BA");
      
        }

        private void Classify_Badminton_CourtNo(ComboBox sender)
        {

                foreach (ListBox i in Badminton_ListBox_List)
                    i.Items.Clear();
                Clear_SelectedDict();

                if (sender.SelectedIndex != 0)
                {
                    this.Current_SelectedCourtNo = sender;
                    DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex);
                }
                else
                    DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);

        }

        private void Badminton_Search_Click(object sender, EventArgs e)
        {
            if (this.Badminton_Location_ComboBox.SelectedIndex != 0)
            {
                this.Badminton_CourtNo_ComboBox.SelectedIndex = 0;
                Classify_Badminton_Location(this.Badminton_Location_ComboBox);
            }
            else if (this.Badminton_CourtNo_ComboBox.SelectedIndex != 0)
            {
                Classify_Badminton_CourtNo(this.Badminton_CourtNo_ComboBox);
            }
            else
            Facilities_ShowInfo(this.Current_SelectedCategory, null, 0);
        }
        #endregion

        #region Classify Tennis
        private void Tennis_Search_Button_Click(object sender, EventArgs e)
        {
            if (this.Tennis_Location_ComboBox.SelectedIndex != 0)
            {
                this.Tennis_CourtNo_ComboBox.SelectedIndex = 0;
                Classify_Tennis_Location(this.Tennis_Location_ComboBox);
            }
            else if (this.Tennis_CourtNo_ComboBox.SelectedIndex != 0)
            {
                Classify_Tennis_CourtNo(this.Tennis_CourtNo_ComboBox);
            }
            else
                Facilities_ShowInfo(this.Current_SelectedCategory, null, 0);
        }

        private void Classify_Tennis_Location(ComboBox sender)
        {
            foreach (ListBox i in Tennis_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();

            if (sender.SelectedIndex != 0)
            {
                Current_SeletedLocation = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex.ToString());
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);

        }

        private void Classify_Tennis_CourtNo(ComboBox sender)
        {

            foreach (ListBox i in Tennis_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();

            if (sender.SelectedIndex != 0)
            {
                this.Current_SelectedCourtNo = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex);
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);

        }
        #endregion

        #region Classify TableTennis
        private void TableTennis_Search_Button_Click(object sender, EventArgs e)
        {
            if (this.TableTennis_Location_ComboBox.SelectedIndex != 0)
            {
                this.Tennis_CourtNo_ComboBox.SelectedIndex = 0;
                Classify_TableTennis_Location(this.TableTennis_Location_ComboBox);
            }
            else if (this.TableTennis_CourtNo_ComboBox.SelectedIndex != 0)
            {
                Classify_TableTennis_CourtNo(this.TableTennis_CourtNo_ComboBox);
            }
            else
                Facilities_ShowInfo(this.Current_SelectedCategory, null, 0);
        }

        private void Classify_TableTennis_Location(ComboBox sender)
        {
            foreach (ListBox i in TableTennis_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();

            if (sender.SelectedIndex != 0)
            {
                Current_SeletedLocation = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex.ToString());
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);

        }

        private void Classify_TableTennis_CourtNo(ComboBox sender)
        {

            foreach (ListBox i in TableTennis_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();
            this.CourtNo_Exchange = true;

            if (sender.SelectedIndex != 0)
            {
                this.Current_SelectedCourtNo = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex);
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);
        }
        #endregion

        #region Classify Squash Court
        private void SquashCourt_Search_Button_Click(object sender, EventArgs e)
        {
            if (this.SQ_Location_ComboBox.SelectedIndex != 0)
            {
                this.SQ_CourtNo_ComboBox.SelectedIndex = 0;
                Classify_SquashCourt_Location(this.SQ_Location_ComboBox);
            }
            else if (this.SQ_CourtNo_ComboBox.SelectedIndex != 0)
            {
                Classify_SquashCourt_CourtNo(this.SQ_CourtNo_ComboBox);
            }
            else
                Facilities_ShowInfo(this.Current_SelectedCategory, null, 0);
        }

        private void Classify_SquashCourt_Location(ComboBox sender)
        {
            foreach (ListBox i in SquashCourt_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();

            if (sender.SelectedIndex != 0)
            {
                Current_SeletedLocation = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex.ToString());
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);

        }

        private void Classify_SquashCourt_CourtNo(ComboBox sender)
        {

            foreach (ListBox i in SquashCourt_ListBox_List)
                i.Items.Clear();
            Clear_SelectedDict();
            this.CourtNo_Exchange = true;

            if (sender.SelectedIndex != 0)
            {
                this.Current_SelectedCourtNo = sender;
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory, sender.SelectedIndex);
            }
            else
                DataCache.System_Controller.Get_DetailsScheduleWithConditions(this.Current_SelectedCategory);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MapLayout lay = new MapLayout("BA");
            lay.ShowDialog(DataCache.System_MainWindow);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MapLayout lay = new MapLayout("TE");
            lay.ShowDialog(DataCache.System_MainWindow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MapLayout lay = new MapLayout("TA");
            lay.ShowDialog(DataCache.System_MainWindow);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MapLayout lay = new MapLayout("SQ");
            lay.ShowDialog(DataCache.System_MainWindow);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            m1_Load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                int id = Convert.ToInt32(txtSearch.Text);
                ReceiptReport a = new ReceiptReport(id);
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Input transaction ID first.");
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerReport r = new CustomerReport();
            r.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            TranscationsReport t = new TranscationsReport();
            t.ShowDialog();
        }

        private void btnCusTran_Click(object sender, EventArgs e)
        {
            CrossTabReport c = new CrossTabReport();
            c.ShowDialog();
        }
    }
}
