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
    public partial class ReceiptReport : Form
    {
        int id;

        public int ID { get; set; }
        public ReceiptReport(int a)
        {
            InitializeComponent();
            id = a;
        }
        public ReceiptReport()
        {
            InitializeComponent();
        }

        private void ReceiptReport_Load(object sender, EventArgs e)
        {
            string stringFormula;

            BookingSystemDataSet ds = new BookingSystemDataSet();
            BookingSystemDataSetTableAdapters.TransactionsTableAdapter ta = new BookingSystemDataSetTableAdapters.TransactionsTableAdapter();
            ta.Fill(ds.Transactions);

            stringFormula = "{Transactions.ID}=" + id.ToString();
            crystalReportViewer1.SelectionFormula = stringFormula;

            Receipt crpt = new Receipt();
            crpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = crpt;
            }
    }
}
