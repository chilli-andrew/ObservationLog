using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Rusty.ObservationLog.Domain;
using Rusty.ObservationLog.WinForms.ViewModels;

namespace Rusty.ObservationLog.WinForms
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
            SetupTagDropDownForAutoComplete();
            SetupBindings();            
            _viewModel.Load();            

        }

        private void SetupTagDropDownForAutoComplete()
        {
            cboTags.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTags.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void SetupBindings()
        {
            _modelBinder.ViewModel = _viewModel;
            _modelBinder.Bind(model => model.CurrentUser, () => lblCurrentUser.Text = _viewModel.CurrentUser.UserName);
            _modelBinder.Bind(model => model.AllTags, () =>
            {
                cboTags.DisplayMember = "TagText";
                cboTags.DataSource = AllTagsWithEmptyFirstTag();
            });

            _modelBinder.Bind(model => model.Observation, () =>
            {
                pnlTags.Controls.Clear();
                var observationTags = _viewModel.Observation.Tags;
                if (observationTags == null) return;
                foreach (var tag in observationTags)
                {
                    var tagItemView = CreateTagItemView(tag);
                    pnlTags.Controls.Add(tagItemView);
                }
                cboTags.SelectedIndex = 0;
            });

            _modelBinder.Bind(model => model.CanAddTags, () =>
            {
                if (!_viewModel.CanAddTags)
                {
                    MessageBox.Show("You cannot add more than 4 tags for an observation.", "Cannot add tag", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });

            _modelBinder.Bind(model => model.TagAlreadyAdded,() =>
            {
                if (_viewModel.TagAlreadyAdded)
                {
                    var tag = _viewModel.Tag;
                    cboTags.Text = "";
                    MessageBox.Show(string.Format("Tag: '{0}' has already been added.", tag));
                }
            });
            cboTags.TextChanged += (sender, args) => { _viewModel.Tag = cboTags.Text; };
        }

        private TagItemView CreateTagItemView(Tag tag)
        {
            var tagItemViewModel = new TagItemViewModel {ParentViewModel = _viewModel};
            var tagButton = new TagItemView(tagItemViewModel) {Tag = tag};
            return tagButton;
        }

        private List<Tag> AllTagsWithEmptyFirstTag()
        {
            var allTags = _viewModel.AllTags;
            allTags.Insert(0, new Tag());
            return allTags;
        }

        private void Observation_Activated(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            txtObservation.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFormAndClose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _viewModel.ObservationText = txtObservation.Text;
            _viewModel.ObservationDate = DateTime.Now;
            _viewModel.Save();
            ClearFormAndClose();
        }

        private void ClearFormAndClose()
        {
            this.txtObservation.Text = "";
            this.Close();
        }

        private void RegisterHotKey()
        {
            // register the event that is fired after the key press.
            _hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + shift + F12 combination as hot key.
            _hook.RegisterHotKey(
                WinForms.ModifierKeys.Control | WinForms.ModifierKeys.Shift,
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
                BringToFront();
                TopMost = true;
                Focus();
                txtObservation.Select();
                TabIndex = 0;
                ShowDialog();
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                ClearFormAndClose();
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

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            _viewModel.AddTag();
        }

        private void Observation_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                _viewModel.Load();
            }
        }

        private void cboTags_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _viewModel.AddTag();
            }
        }


    }
}
