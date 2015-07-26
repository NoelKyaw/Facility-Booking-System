using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacilityBookingSystem
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            BookingSystemDataSet ds = new BookingSystemDataSet();
            BookingSystemDataSetTableAdapters.CustomersTableAdapter ta = new BookingSystemDataSetTableAdapters.CustomersTableAdapter();
            CustomersR cr = new CustomersR();
            ta.Fill(ds.Customers);
            cr.SetDataSource(ds);
            CustomerReportViewer.ReportSource = cr;
        }
    }
}
