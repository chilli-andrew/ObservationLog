using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusty.ObservationLog.Windows.ViewModels
{
    public class ObservationViewModel : ViewModelBase<ObservationViewModel>, IDisposable
    {
        private IObservationContext _db;
        public ObservationViewModel() : this(new ObservationContext())
        {
        }

        public ObservationViewModel(IObservationContext observationContext)
        {
            _db = observationContext;
        }

        private string _windowsUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set { 
                _currentUser =  value;
                NotifyPropertyChanged<User>(o => o.CurrentUser);
            }
        }

        private string _observationText;
        public string ObservationText
        {
            get { return _observationText; }
            set { 
                _observationText = value;
                NotifyPropertyChanged<string>(o => o.ObservationText);
            }
        }

        private DateTime _observationDate;
        public DateTime ObservationDate
        {
            get { return _observationDate; }
            set { 
                _observationDate = value;
                NotifyPropertyChanged<DateTime>(o => o.ObservationDate);
            }
        }

        public void Load()
        {
            ResetObservationText();
            this.CurrentUser = GetCurrentUser();
        }

        public void Save()
        {
            var observation = new Domain.Observation
            {
                ObservationText = this.ObservationText,
                ObservationDate = this.ObservationDate,
                User = this.CurrentUser

            };
            _db.Observations.Add(observation);
            _db.SaveChanges();
            ResetObservationText();
        }

        private void ResetObservationText()
        {
            this.ObservationText = "";
        }

        private Domain.User GetCurrentUser()
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
    }
}
