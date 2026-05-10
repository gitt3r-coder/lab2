using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class DefaultBindingViewModel : ViewModelBase
    {
        private string defaultInput = "Текст с режимом привязки по умолчанию";
        private string defaultNote = "Сообщение из визуальной модели";
        private int commandCount;

        public DefaultBindingViewModel()
        {
            ResetDefaultCommand = new RelayCommand(_ =>
            {
                DefaultInput = "Сброшено через команду";
                DefaultNote = "Кнопка использует ICommand";
                CommandCount++;
            });
        }

        public ICommand ResetDefaultCommand { get; }

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

        public int CommandCount
        {
            get => commandCount;
            set => SetProperty(ref commandCount, value);
        }
    }
}
