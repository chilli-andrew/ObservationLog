using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.WinForms.Extensions;

namespace Rusty.ObservationLog.WinForms.ViewModels
{
    public class ObservationReportViewModel: ViewModelBase<ObservationReportViewModel>, IDisposable
    {
        private readonly IObservationContext _db;
        private DateTime _fromDate;
        private DateTime _toDate;
        private string _formattedRowCount;

        public ObservationReportViewModel(): this(new ObservationContext())
        {
        }

        public ObservationReportViewModel(IObservationContext db)
        {
            _db = db;
        }

        public DateTime FromDate
        {
            get
            {
                if (_fromDate == default(DateTime)) _fromDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday);

                return _fromDate;
            }
            set
            {
                _fromDate = value;
                NotifyPropertyChanged(o => o.FromDate);
            }
        }

        public DateTime ToDate
        {
            get
            {
                if (_toDate == default(DateTime)) _toDate = DateTime.Today;
                return _toDate;
            }
            set
            {
                _toDate = value;
                NotifyPropertyChanged(o => o.ToDate);
            }
        }

        public BindingList<ObservationReportRowViewModel> GetObservationsReport()
        {
            var report = from o in _db.Observations
                         where o.ObservationDate >= this.FromDate && o.ObservationDate <= this.ToDate
                         orderby o.ObservationDate descending
                         select new ObservationReportRowViewModel
                         {
                             UserName = o.User.UserName,
                             ObservationText = o.ObservationText,
                             ObservationDate = o.ObservationDate
                         };
            FormattedRowCount = GetFormattedRowCount(report.Count());
            return new BindingList<ObservationReportRowViewModel>(report.ToList());
        }

        private string GetFormattedRowCount(int count)
        {
            return string.Format("{0} Rows Returned", count);
        }

        public string FormattedRowCount
        {
            get { return _formattedRowCount; }
            private set
            {
                _formattedRowCount = value;
                NotifyPropertyChanged(model => model.FormattedRowCount);
            }
        }

        public void SaveAsCsv(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            var report = GetObservationsReport();
            var csv = CreateCsv(report);

            File.WriteAllText(fileName, csv);
        }

        private string CreateCsv(IEnumerable<ObservationReportRowViewModel> report)
        {
            var csvRows = report.Select(
                model =>
                    string.Format("{0},{1},{2}", model.UserName, model.ObservationDate.ToString("F"),
                        model.ObservationText));

            var csv = new StringBuilder();
            csv.Append("User Name,Observation Date, Observation");
            csv.Append(Environment.NewLine);
            csv.Append(string.Join(Environment.NewLine, csvRows));
            return csv.ToString();
        }

        public void Dispose()
        {
            if (_db != null) _db.Dispose();
        }
    }
}