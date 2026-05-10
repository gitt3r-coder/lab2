using System.Collections.ObjectModel;
using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private string userName = "Алексей";
        private int rating = 65;
        private bool notificationsEnabled = true;
        private string selectedTheme = "Светлая";
        private string saveMessage = "Измените поля и нажмите сохранить";

        public TwoWayBindingViewModel()
        {
            ThemeOptions = new ObservableCollection<string> { "Светлая", "Контрастная", "Спокойная" };
            SaveTwoWayCommand = new RelayCommand(_ =>
            {
                SaveMessage = $"Сохранено: {UserName}, рейтинг {Rating}";
            });
        }

        public ObservableCollection<string> ThemeOptions { get; }
        public ICommand SaveTwoWayCommand { get; }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public int Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public bool NotificationsEnabled
        {
            get => notificationsEnabled;
            set => SetProperty(ref notificationsEnabled, value);
        }

        public string SelectedTheme
        {
            get => selectedTheme;
            set => SetProperty(ref selectedTheme, value);
        }

        public string SaveMessage
        {
            get => saveMessage;
            set => SetProperty(ref saveMessage, value);
        }
    }
}
