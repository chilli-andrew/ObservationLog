using System;
using System.IO;
using System.Windows.Forms;
using Rusty.ObservationLog.WinForms.ViewModels;

namespace Rusty.ObservationLog.WinForms
{
    public partial class ObservationsReport : Form
    {
        private ObservationReportViewModel _viewModel = new ObservationReportViewModel();
        private readonly ModelBinder<ObservationReportViewModel> _modelBinder = new ModelBinder<ObservationReportViewModel>();

        public ObservationsReport()
        {
            InitializeComponent();
            SetupBindings();
        }

        private void SetupBindings()
        {
            _modelBinder.ViewModel = _viewModel;
            _modelBinder.Bind(model => model.FromDate, () => dtFrom.Value = _viewModel.FromDate);
            _modelBinder.Bind(model => model.ToDate, () => dtTo.Value = _viewModel.ToDate);
            _modelBinder.Bind(model => model.FormattedRowCount, () => lblRowsCount.Text = _viewModel.FormattedRowCount);
            dtFrom.CloseUp += (sender, args) => _viewModel.FromDate = dtFrom.Value;
            dtTo.CloseUp += (sender, args) => _viewModel.ToDate = dtTo.Value;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            gvObservations.AutoGenerateColumns = false;
            var source = new BindingSource(_viewModel.GetObservationsReport(), null);
            gvObservations.DataSource = source;
        }

        private void btnToCsv_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DefaultExt = "csv",
                AddExtension = true,
                Filter = "Comma Separated Values Files (*.csv)|*.csv*"
            };
            var dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel) return;

            var fileName = dialog.FileName;

            _viewModel.SaveAsCsv(fileName);

        }

        protected override void Dispose(bool disposing)
        {
            if (_viewModel != null) _viewModel.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
