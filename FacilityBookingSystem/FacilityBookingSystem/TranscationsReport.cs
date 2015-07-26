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
    public partial class TranscationsReport : Form
    {
        public TranscationsReport()
        {
            InitializeComponent();
        }

        private void TranscationsReport_Load(object sender, EventArgs e)
        {
            BookingSystemDataSet ds = new BookingSystemDataSet();
            BookingSystemDataSetTableAdapters.TransactionsTableAdapter ta = new BookingSystemDataSetTableAdapters.TransactionsTableAdapter();
            TranscationR cr = new TranscationR();
            ta.Fill(ds.Transactions);
            cr.SetDataSource(ds);
            TranscationView.ReportSource = cr;
        }
    }
}
