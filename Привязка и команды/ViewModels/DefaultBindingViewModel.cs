using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class DefaultBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string defaultInput = "Текст с режимом привязки по умолчанию";

        [ObservableProperty]
        private string defaultNote = "Сообщение из визуальной модели";

        [ObservableProperty]
        private int commandCount;

        [RelayCommand]
        private void ResetDefault()
        {
            defaultInput = "Сброшено через команду";
            defaultNote = "Кнопка использует ICommand";
            commandCount++;
            OnPropertyChanged("DefaultInput");
            OnPropertyChanged("DefaultNote");
            OnPropertyChanged("CommandCount");
        }
    }
}
