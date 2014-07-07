using System;
using System.Drawing;
using System.Windows.Forms;
using Rusty.ObservationLog.Windows.ViewModels;

namespace Rusty.ObservationLog.Windows
{


    public partial class Observation : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();
        private readonly ObservationViewModel _viewModel = new ObservationViewModel();
        private readonly ModelBinder<ObservationViewModel> _modelBinder = new ModelBinder<ObservationViewModel>();
 
        public Observation()
        {
            InitializeComponent();
            RegisterHotKey();
            SetupBindings();
        }

        private void SetupBindings()
        {
            _modelBinder.ViewModel = _viewModel;
            _modelBinder.Bind(model => model.CurrentUser, () => lblCurrentUser.Text = _viewModel.CurrentUser.UserName);
        }

        private void Observation_Activated(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            txtObservation.Focus();
            _viewModel.Load();            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _viewModel.ObservationText = txtObservation.Text;
            _viewModel.ObservationDate = DateTime.Now;
            _viewModel.Save();
            this.txtObservation.Text = "";
            this.Close();
        }

        private void RegisterHotKey()
        {
            // register the event that is fired after the key press.
            _hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            _hook.RegisterHotKey(
                Windows.ModifierKeys.Control | Windows.ModifierKeys.Shift,
                Keys.F12);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            Activate();
            if (Visible != true)
            {
                ShowDialog();
            }
            BringToFront();
            TopMost = true;
            Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
