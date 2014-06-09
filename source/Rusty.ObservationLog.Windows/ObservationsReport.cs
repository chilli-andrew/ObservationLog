using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rusty.ObservationLog.Db;
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

        private void ObservationsReport_Load(object sender, EventArgs e)
        {
            gvObservations.AutoGenerateColumns = false;
            var report = GetObservationsReport();
            var source = new BindingSource(report, null);
            gvObservations.DataSource = source;
        }

        private BindingList<ObservationReportRowViewModel> GetObservationsReport()
        {
            var report = from o in _db.Observations
                         orderby o.ObservationDate descending 
            select new ObservationReportRowViewModel
            {
                UserName = o.User.UserName,
                ObservationText = o.ObservationText,
                ObservationDate = o.ObservationDate
            };
            return new BindingList<ObservationReportRowViewModel>(report.ToList());
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
