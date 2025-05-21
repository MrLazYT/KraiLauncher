using KraiLauncher.Core;
using KraiLauncher.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraiLauncher.Services
{
    public interface INavigationService
    {
        Core.ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : Core.ViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        public Core.ViewModel _currentView;
        private readonly Func<Type, Core.ViewModel> _viewModelFactory;

        public Core.ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, Core.ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            NavigateTo<GameViewModel>();
        }

        public void NavigateTo<TViewModel>() where TViewModel : Core.ViewModel
        {
            Core.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
