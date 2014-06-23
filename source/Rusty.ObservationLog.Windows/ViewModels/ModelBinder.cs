using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Rusty.ObservationLog.Windows.ViewModels
{
    public class ModelBinder <TModel> where TModel : ViewModelBase<TModel>
    {
        private readonly List<BindingAction> _registeredBindingActions = new List<BindingAction>();
        private TModel _viewModel;

        public TModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
            }
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var propertyName = propertyChangedEventArgs.PropertyName;
            ExecuteActionsFor(propertyName);
        }

        public void ExecuteActionsFor(string propertyName)
        {
            var actions = _registeredBindingActions.Where(ba => ba.PropertyName == propertyName);
            foreach (var bindingAction in actions)
            {
                ExecuteAction(bindingAction.ActionToExecute);
            }
        }

        private void ExecuteAction(Action actionToExecute)
        {
            actionToExecute.Invoke();
        }

        public void Bind<TResult>(Expression<Func<TModel, TResult>> property, Action action)
        {
            var propertyName = ReflectionHelpers.GetPropertyName(property);
            var bindingAction = new BindingAction
            {
                PropertyName = propertyName,
                ActionToExecute = action
            };
            _registeredBindingActions.Add(bindingAction);
        }

        private class BindingAction
        {
            public string PropertyName { get; set; }
            public Action ActionToExecute { get; set; }
        }
    }
}
