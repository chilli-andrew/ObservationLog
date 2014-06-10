using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.Windows.Extensions;
using Rusty.ObservationLog.Windows.ViewModels;

namespace Rusty.ObservationLog.Windows
{
    public partial class ObservationsReport : Form
    {
        private ObservationContext _db = new ObservationContext();
        public ObservationsReport()
        {
            InitializeComponent();
        }

        private BindingList<ObservationReportRowViewModel> GetObservationsReport(DateTime fromDate, DateTime toDate)
        {
            var report = from o in _db.Observations
                         where o.ObservationDate >= fromDate && o.ObservationDate < toDate
                         orderby o.ObservationDate descending 
            select new ObservationReportRowViewModel
            {
                UserName = o.User.UserName,
                ObservationText = o.ObservationText,
                ObservationDate = o.ObservationDate
            };
            return new BindingList<ObservationReportRowViewModel>(report.ToList());
        }

        private void ObservationsReport_Activated(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Today.StartOfWeek(DayOfWeek.Monday);
            dtTo.Value = DateTime.Today;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            gvObservations.AutoGenerateColumns = false;
            var from = dtFrom.Value;
            var to = dtTo.Value.AddDays(1);
            var report = GetObservationsReport(from, to);
            var source = new BindingSource(report, null);
            gvObservations.DataSource = source;
            lblRowsCount.Text = string.Format("{0} Rows Returned", gvObservations.RowCount);
        }

        private void btnToCsv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
        }


        protected override void Dispose(bool disposing)
        {
            if (_db != null) _db.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
