using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace KraiLauncher.View.UserControls.Buttons
{
    public partial class CardButton : UserControl, INotifyPropertyChanged
    {
        private string imageSource;
        private string primaryText;
        private string secondaryText;
        public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(CardButton));

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public string ImageSource {
            get => imageSource;
            set {
                imageSource = value;
                OnPropertyChanged();
            }
        }
        
        public string PrimaryText {
            get => primaryText;
            set {
                primaryText = value;
                OnPropertyChanged();
            }
        }
        public string SecondaryText {
            get => secondaryText;
            set
            {
                secondaryText = value;
                OnPropertyChanged();
            }
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CardButton()
        {
            InitializeComponent();
        }
    }
}
