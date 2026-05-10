using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class TwoWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string userName = "Алексей";

        [ObservableProperty]
        private int rating = 65;

        [ObservableProperty]
        private bool notificationsEnabled = true;

        [ObservableProperty]
        private string selectedTheme = "Светлая";

        [ObservableProperty]
        private string saveMessage = "Измените поля и нажмите сохранить";

        public ObservableCollection<string> ThemeOptions { get; } =
            new ObservableCollection<string> { "Светлая", "Контрастная", "Спокойная" };

        [RelayCommand]
        private void SaveTwoWay()
        {
            saveMessage = $"Сохранено: {userName}, рейтинг {rating}";
            OnPropertyChanged("SaveMessage");
        }
    }
}
