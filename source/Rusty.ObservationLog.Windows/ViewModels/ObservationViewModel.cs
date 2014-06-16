using Rusty.ObservationLog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusty.ObservationLog.Windows.ViewModels
{
    public class ObservationViewModel : ViewModelBase<ObservationViewModel>
    {
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


    }
}
