using KraiLauncher.Core;
using KraiLauncher.Services;

namespace KraiLauncher.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        public INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToGameCommand { get; set; }
        public RelayCommand NavigateToProfileCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToGameCommand = new RelayCommand(o => { Navigation.NavigateTo<GameViewModel>(); }, canExecute: o => true);
            NavigateToProfileCommand = new RelayCommand(o => { Navigation.NavigateTo<ProfileViewModel>(); }, canExecute: o => true);
        }
    }
}
