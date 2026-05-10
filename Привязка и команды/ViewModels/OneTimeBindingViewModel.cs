using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sessionCode = "LR2-001";

        [ObservableProperty]
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");

        [RelayCommand]
        private void GenerateSessionCode()
        {
            sessionCode = "LR2-" + DateTime.Now.ToString("HHmmss");
            currentTime = DateTime.Now.ToString("HH:mm:ss");
            OnPropertyChanged("SessionCode");
            OnPropertyChanged("CurrentTime");
        }
    }
}
