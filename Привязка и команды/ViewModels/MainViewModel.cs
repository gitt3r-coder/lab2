using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string defaultInput = "Текст с режимом привязки по умолчанию";
        private string defaultNote = "Сообщение из визуальной модели";
        private string userName = "Алексей";
        private int rating = 65;
        private bool notificationsEnabled = true;
        private string selectedTheme = "Светлая";
        private string sessionCode = "LR2-001";
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");
        private int progress = 40;
        private string oneWayText = "Источник изменяется только командой";
        private string sourceFromTarget = "Введите текст в поле OneWayToSource";
        private string updateOnPropertyChanged = "Меняется сразу";
        private string updateOnLostFocus = "Меняется после потери фокуса";
        private string updateExplicit = "Меняется после команды";
        private int triggerLevel = 45;
        private bool isDangerMode;
        private string selectedTriggerItem = "Обычный";
        private int commandCount;

        public MainViewModel()
        {
            ThemeOptions = new ObservableCollection<string> { "Светлая", "Контрастная", "Спокойная" };
            TriggerItems = new ObservableCollection<string> { "Обычный", "Важный", "Критический" };

            ResetDefaultCommand = new RelayCommand(_ =>
            {
                DefaultInput = "Сброшено через команду";
                DefaultNote = "Кнопка использует ICommand";
                CommandCount++;
            });

            SaveTwoWayCommand = new RelayCommand(_ =>
            {
                DefaultNote = $"Сохранено: {UserName}, рейтинг {Rating}";
                CommandCount++;
            });

            GenerateSessionCodeCommand = new RelayCommand(_ =>
            {
                SessionCode = "LR2-" + DateTime.Now.ToString("HHmmss");
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                CommandCount++;
            });

            IncreaseProgressCommand = new RelayCommand(_ =>
            {
                Progress = Math.Min(100, Progress + 10);
                OneWayText = $"Прогресс увеличен до {Progress}%";
                CommandCount++;
            });

            DecreaseProgressCommand = new RelayCommand(_ =>
            {
                Progress = Math.Max(0, Progress - 10);
                OneWayText = $"Прогресс уменьшен до {Progress}%";
                CommandCount++;
            });

            ApplyExplicitBindingCommand = new RelayCommand(parameter =>
            {
                var textBox = parameter as TextBox;
                BindingExpression expression = textBox?.GetBindingExpression(TextBox.TextProperty);
                expression?.UpdateSource();
                CommandCount++;
            });

            ToggleDangerCommand = new RelayCommand(_ =>
            {
                IsDangerMode = !IsDangerMode;
                CommandCount++;
            });
        }

        public ObservableCollection<string> ThemeOptions { get; }
        public ObservableCollection<string> TriggerItems { get; }

        public ICommand ResetDefaultCommand { get; }
        public ICommand SaveTwoWayCommand { get; }
        public ICommand GenerateSessionCodeCommand { get; }
        public ICommand IncreaseProgressCommand { get; }
        public ICommand DecreaseProgressCommand { get; }
        public ICommand ApplyExplicitBindingCommand { get; }
        public ICommand ToggleDangerCommand { get; }

        public string DefaultInput
        {
            get => defaultInput;
            set => SetProperty(ref defaultInput, value);
        }

        public string DefaultNote
        {
            get => defaultNote;
            set => SetProperty(ref defaultNote, value);
        }

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

        public string SessionCode
        {
            get => sessionCode;
            set => SetProperty(ref sessionCode, value);
        }

        public string CurrentTime
        {
            get => currentTime;
            set => SetProperty(ref currentTime, value);
        }

        public int Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }

        public string OneWayText
        {
            get => oneWayText;
            set => SetProperty(ref oneWayText, value);
        }

        public string SourceFromTarget
        {
            get => sourceFromTarget;
            set => SetProperty(ref sourceFromTarget, value);
        }

        public string UpdateOnPropertyChanged
        {
            get => updateOnPropertyChanged;
            set => SetProperty(ref updateOnPropertyChanged, value);
        }

        public string UpdateOnLostFocus
        {
            get => updateOnLostFocus;
            set => SetProperty(ref updateOnLostFocus, value);
        }

        public string UpdateExplicit
        {
            get => updateExplicit;
            set => SetProperty(ref updateExplicit, value);
        }

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

        public int CommandCount
        {
            get => commandCount;
            set => SetProperty(ref commandCount, value);
        }
    }
}
