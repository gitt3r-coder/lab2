using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class OneWayBindingsViewModel : ViewModelBase
    {
        private int progress = 40;
        private string oneWayText = "Источник изменяется только командой";
        private string sourceFromTarget = "Введите текст в поле OneWayToSource";
        private string updateOnPropertyChanged = "Меняется сразу";
        private string updateOnLostFocus = "Меняется после потери фокуса";
        private string updateExplicit = "Меняется после команды";

        public OneWayBindingsViewModel()
        {
            IncreaseProgressCommand = new RelayCommand(_ =>
            {
                Progress = Math.Min(100, Progress + 10);
                OneWayText = $"Прогресс увеличен до {Progress}%";
            });

            DecreaseProgressCommand = new RelayCommand(_ =>
            {
                Progress = Math.Max(0, Progress - 10);
                OneWayText = $"Прогресс уменьшен до {Progress}%";
            });

            ApplyExplicitBindingCommand = new RelayCommand(parameter =>
            {
                var textBox = parameter as TextBox;
                BindingExpression expression = textBox?.GetBindingExpression(TextBox.TextProperty);
                expression?.UpdateSource();
            });
        }

        public ICommand IncreaseProgressCommand { get; }
        public ICommand DecreaseProgressCommand { get; }
        public ICommand ApplyExplicitBindingCommand { get; }

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
    }
}
