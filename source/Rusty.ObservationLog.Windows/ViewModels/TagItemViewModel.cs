using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.WinForms.ViewModels
{
    public class TagItemViewModel : ViewModelBase<TagItemViewModel>
    {
        private Tag _tag;
        private ObservationViewModel _parentViewModel;

        public Tag Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                NotifyPropertyChanged(model => model.Tag);
            }
        }

        public ObservationViewModel ParentViewModel
        {
            get { return _parentViewModel; }
            set
            {
                _parentViewModel = value;
                NotifyPropertyChanged(model => model.ParentViewModel);
            }
        }

        public void RemoveTag()
        {
            if (this.ParentViewModel != null)
            {
                ParentViewModel.RemoveTag(this.Tag);
            }
        }
    }
}