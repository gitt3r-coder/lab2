using System.Collections.ObjectModel;
using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class TriggersViewModel : ViewModelBase
    {
        private int triggerLevel = 45;
        private bool isDangerMode;
        private string selectedTriggerItem = "Обычный";

        public TriggersViewModel()
        {
            TriggerItems = new ObservableCollection<string> { "Обычный", "Важный", "Критический" };
            ToggleDangerCommand = new RelayCommand(_ =>
            {
                IsDangerMode = !IsDangerMode;
            });
        }

        public ObservableCollection<string> TriggerItems { get; }
        public ICommand ToggleDangerCommand { get; }

        public int TriggerLevel
        {
            get => triggerLevel;
            set => SetProperty(ref triggerLevel, value);
        }

        public bool IsDangerMode
        {
            get => isDangerMode;
            set => SetProperty(ref isDangerMode, value);
        }

        public string SelectedTriggerItem
        {
            get => selectedTriggerItem;
            set => SetProperty(ref selectedTriggerItem, value);
        }
    }
}
