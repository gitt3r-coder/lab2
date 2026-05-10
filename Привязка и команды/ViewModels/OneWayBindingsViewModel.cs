using System;
using System.Windows.Controls;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class OneWayBindingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private int progress = 40;

        [ObservableProperty]
        private string oneWayText = "Источник изменяется только командой";

        [ObservableProperty]
        private string sourceFromTarget = "Введите текст в поле OneWayToSource";

        [ObservableProperty]
        private string updateOnPropertyChanged = "Меняется сразу";

        [ObservableProperty]
        private string updateOnLostFocus = "Меняется после потери фокуса";

        [ObservableProperty]
        private string updateExplicit = "Меняется после команды";

        [RelayCommand]
        private void IncreaseProgress()
        {
            progress = Math.Min(100, progress + 10);
            oneWayText = $"Прогресс увеличен до {progress}%";
            OnPropertyChanged("Progress");
            OnPropertyChanged("OneWayText");
        }

        [RelayCommand]
        private void DecreaseProgress()
        {
            progress = Math.Max(0, progress - 10);
            oneWayText = $"Прогресс уменьшен до {progress}%";
            OnPropertyChanged("Progress");
            OnPropertyChanged("OneWayText");
        }

        [RelayCommand]
        private void ApplyExplicitBinding(object parameter)
        {
            var textBox = parameter as TextBox;
            BindingExpression expression = textBox?.GetBindingExpression(TextBox.TextProperty);
            expression?.UpdateSource();
        }
    }
}
