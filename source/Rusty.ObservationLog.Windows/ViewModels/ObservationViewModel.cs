using System;
using System.Linq;
using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.WinForms.ViewModels
{
    public class ObservationViewModel : ViewModelBase<ObservationViewModel>, IDisposable
    {
        private readonly IObservationContext _db;
        private Domain.Observation _observation;

        public ObservationViewModel() : this(new ObservationContext())
        {
        }

        public ObservationViewModel(IObservationContext observationContext)
        {
            _db = observationContext;
        }

        private readonly string _windowsUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public User CurrentUser
        {
            get { return _observation.User; }
            set { 
                _observation.User =  value;
                NotifyPropertyChanged<User>(o => o.CurrentUser);
            }
        }

        public string ObservationText
        {
            get { return _observation.ObservationText; }
            set {
                _observation.ObservationText = value;
                NotifyPropertyChanged<string>(o => o.ObservationText);
            }
        }

        public DateTime ObservationDate
        {
            get { return _observation.ObservationDate; }
            set {
                _observation.ObservationDate = value;
                NotifyPropertyChanged<DateTime>(o => o.ObservationDate);
            }
        }

        public void Load()
        {
            CreateObservation();
        }

        private void CreateObservation()
        {
            _observation = new Domain.Observation();
            this.CurrentUser = GetCurrentUser();
        }

        public void Save()
        {

            _observation.ObservationText = this.ObservationText;
            _observation.ObservationDate = this.ObservationDate;
            _db.Observations.Add(_observation);
            _db.SaveChanges();
            CreateObservation();
        }

        private User GetCurrentUser()
        {
            var user = _db.Users.FirstOrDefault(u => u.WindowsLogon == _windowsUserName);
            if (user == null)
            {
                user = new User
                {
                    UserName = _windowsUserName,
                    WindowsLogon = _windowsUserName
                };
                _db.Users.Add(user);
            }
            return user;
        }

        public void Dispose()
        {
            if (_db != null) _db.Dispose();
        }

        private string _tag;

        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                NotifyPropertyChanged(model => model.Tag);
            }
        }

        public void AddTag()
        {
            if (string.IsNullOrEmpty(this.Tag)) return;
            var existingTag = _db.Tags.FirstOrDefault(tag => tag.TagText==this.Tag);
            if (existingTag != null)
            {
                _observation.Tags.Add(existingTag);
            }
            else
            {
                var newTag = new Tag {TagText = this.Tag};
                _observation.Tags.Add(newTag);
            }
                
        }
    }
}
