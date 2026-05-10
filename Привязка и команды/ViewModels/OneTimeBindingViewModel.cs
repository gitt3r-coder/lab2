using System;
using System.Windows.Input;
using Привязка_и_команды.Infrastructure;

namespace Привязка_и_команды.ViewModels
{
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private string sessionCode = "LR2-001";
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");

        public OneTimeBindingViewModel()
        {
            GenerateSessionCodeCommand = new RelayCommand(_ =>
            {
                SessionCode = "LR2-" + DateTime.Now.ToString("HHmmss");
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            });
        }

        public ICommand GenerateSessionCodeCommand { get; }

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
    }
}
