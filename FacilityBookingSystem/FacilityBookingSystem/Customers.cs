using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacilityBookingSystem.Data;

namespace FacilityBookingSystem
{
    public partial class Customers : Form
    {
        private Customer customer { get; set; }
        private bool NewOrNot { get; set; }
        public Customers(object sender)
        {
            InitializeComponent();

            this.CboDepartment.Items.Add("Business");
            this.CboDepartment.Items.Add("Computing");
            this.CboDepartment.Items.Add("Dentistry");
            this.CboDepartment.Items.Add("Enginnering");
            this.CboDepartment.Items.Add("Law");
            this.CboDepartment.Items.Add("Music");
            this.CboDepartment.Items.Add("Science");
            this.CboDepartment.Items.Add("Yale-NUS College");

            Button _button = sender as Button;
            if (_button.Text != "New")
            {
                this.NewOrNot = false;
                Customers_Load();
            }
            else
            {
                BookingSystemEntities context = new BookingSystemEntities();
                Customer customer = new Customer();

                var custQuery = from x in context.Customers
                                select x;

                customer = custQuery.ToList().Last();

                //string lastCustID = customer.PrimaryKey;
                Customer newcustomer = new Customer();
                newcustomer.ID = "A" + (Convert.ToInt32(customer.ID.Substring(1, customer.ID.Length - 1)) + 1).ToString().PadLeft(8, '0');

                txtCustomerID.Enabled = false;
                txtCustomerID.Text = newcustomer.ID;

                this.NewOrNot = true;
            }
        }

        private void Clear()
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtPostalCode.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            CboDepartment.SelectedIndex = -1;
            rtbAddress.Text = "";
        }

        public void Customers_Load()
        {
            BookingSystemEntities context = new BookingSystemEntities();

            string _id =  DataCache.System_MainWindow.Get_CustomerID();
            this.customer = (from x in context.Customers
                             where x.ID == _id
                             select x).FirstOrDefault();

            txtCustomerID.Enabled = false;
            txtCustomerID.Text = customer.ID;
            txtCustomerName.Text = customer.Name;
            CboDepartment.Text = customer.Department;
            rtbAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtPhoneNo.Text = customer.PhoneNumber;
            txtPostalCode.Text = customer.PostalCode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //create DBContext object

            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please fill the Customer Name."); 
            }
            else if (CboDepartment.Text == "")
            {
                MessageBox.Show( "Please select the Department.");
            }
            else if (rtbAddress.Text == "")
            {
                MessageBox.Show("Please fill the Address.");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please fill the Email.");
            }
            else if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Please fill the Phone number.");
            }
            else if (txtPostalCode.Text == "")
            {
                MessageBox.Show("Please fill the Postal Code");
            }
            else
            if (NewOrNot == true)
            {
                SaveNew();
                //tsStatus.Text = "Successfully Submited.";
                //tsStatus.ForeColor = System.Drawing.Color.Green;
                this.Close();
            }
            else if (NewOrNot == false)
            {
                UpdateCustomer();
                tsStatus.Text = "Successfully Updated.";
                tsStatus.ForeColor = System.Drawing.Color.Green;
                this.Close();
            }
        }

        private Customer SaveNew()
        {
            BookingSystemEntities context = new BookingSystemEntities();
            Customer customer = new Customer();

            customer.ID = txtCustomerID.Text;
            customer.Name = txtCustomerName.Text;
            customer.Department = CboDepartment.Text;
            customer.Address = rtbAddress.Text;
            customer.Email = txtEmail.Text;
            customer.PhoneNumber = txtPhoneNo.Text;
            customer.PostalCode = txtPostalCode.Text;

            //BookingSystemEntities context = new BookingSystemEntities();
            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        }

        private void UpdateCustomer()
        {
            BookingSystemEntities context = new BookingSystemEntities();

            //var updateQuery = from x in context.Customers
            //                where x.ID  == txtCustomerID.Text
            //                select x;

            // Execute the query, and change the column values 
            // you want to change. 

            customer.ID = txtCustomerID.Text;
            customer.Name = txtCustomerName.Text;
            customer.Department = CboDepartment.Text;
            customer.Address = rtbAddress.Text;
            customer.Email = txtEmail.Text;
            customer.PhoneNumber = txtPhoneNo.Text;
            customer.PostalCode = txtPostalCode.Text;

            context.SaveChanges();
            this.customer = null;
            // Insert any additional changes to column values.
        }
    }
}
