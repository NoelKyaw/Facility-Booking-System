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
    public partial class CrossTabReport : Form
    {
        public CrossTabReport()
        {
            InitializeComponent();
        }

        private void CrossTabReport_Load(object sender, EventArgs e)
        {
            BookingSystemDataSet ds = new BookingSystemDataSet();
            BookingSystemDataSetTableAdapters.CustomerTransactionsTableAdapter ta = new BookingSystemDataSetTableAdapters.CustomerTransactionsTableAdapter();
            CrossTabCustTran cr = new CrossTabCustTran();
            ta.Fill(ds.CustomerTransactions);
            cr.SetDataSource(ds);
            CrossTabReportViewer.ReportSource = cr;
        }
    }
}
