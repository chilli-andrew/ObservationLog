using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Domain.Observation Observation
        {
            get { return _observation; }
            private set { 
                _observation =  value;
                NotifyPropertyChanged(o => o.Observation);
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
            ReloadAllTags();
        }

        private void CreateObservation()
        {
            this.Observation = new Domain.Observation();
            Observation.Tags = new Collection<Tag>();
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

        private List<Tag> _allTags;

        public List<Tag> AllTags
        {
            get { return _allTags; }
            set
            {
                _allTags = value;
                NotifyPropertyChanged(model => model.AllTags);
            }
        }


        private bool _canAddTags;
        public bool CanAddTags
        {
            get { return _canAddTags; }
            set
            {
                _canAddTags = value;
                NotifyPropertyChanged(model => model.CanAddTags);
            }
        }

        public void AddTag()
        {
            if (string.IsNullOrEmpty(this.Tag)) return;
            if (!ExceedsMaxTagsAllowed()) return;
            var existingTag = _db.Tags.FirstOrDefault(tag => tag.TagText==this.Tag);
            if (existingTag != null)
            {
                _observation.Tags.Add(existingTag);
            }
            else
            {
                var newTag = new Tag {TagText = this.Tag};
                _db.Tags.Add(newTag);
                _db.SaveChanges();
                var insertedTag = _db.Tags.FirstOrDefault(tag => tag.TagText==this.Tag);
                _observation.Tags.Add(insertedTag);
            }

            ReloadAllTags();
            NotifyPropertyChanged(o => o.Observation);

        }

        private bool ExceedsMaxTagsAllowed()
        {
            var count = _observation.Tags.Count;
            if (count < 4)
            {
                CanAddTags = true;
                return true;
            }
            CanAddTags = false;
            return false;
        }

        public void RemoveTag(Tag tag)
        {
            _observation.Tags.Remove(tag);
            NotifyPropertyChanged(o => o.Observation);
        }


        private void ReloadAllTags()
        {
            this.AllTags = _db.Tags.ToList();
        }

    }
}
