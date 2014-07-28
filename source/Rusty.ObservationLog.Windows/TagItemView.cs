using System.Drawing;
using System.Windows.Forms;
using Rusty.ObservationLog.Domain;
using Rusty.ObservationLog.WinForms.ViewModels;

namespace Rusty.ObservationLog.WinForms
{
    public partial class TagItemView : UserControl
    {

        private readonly TagItemViewModel _viewModel;
        private readonly ModelBinder<TagItemViewModel> _modelBinder = new ModelBinder<TagItemViewModel>();

        public TagItemView() : this(new TagItemViewModel())
        {

        }

        public TagItemView(TagItemViewModel viewModel)
        {            
            InitializeComponent();
            Size = new Size(80, 20);
            _viewModel = viewModel;
            SetupBindings();
        }

        private void SetupBindings()
        {
            _modelBinder.ViewModel = _viewModel;
            _modelBinder.Bind(model => model.Tag, () =>
            {
                lblTag.Text = _viewModel.Tag.TagText;
                btnRemove.Left = this.lblTag.Width + 5;
                this.Size = new Size(this.lblTag.Width + 20, this.Height);
            });

            btnRemove.Click += (sender, args) => _viewModel.RemoveTag();
        }


        public Tag Tag
        {
            get { return _viewModel.Tag; }
            set
            {
                _viewModel.Tag = value;
            }
        }
    }
}
