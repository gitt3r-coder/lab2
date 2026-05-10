namespace Привязка_и_команды.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            DefaultBinding = new DefaultBindingViewModel();
            TwoWayBinding = new TwoWayBindingViewModel();
            OneTimeBinding = new OneTimeBindingViewModel();
            OneWayBindings = new OneWayBindingsViewModel();
            Triggers = new TriggersViewModel();
        }

        public DefaultBindingViewModel DefaultBinding { get; }
        public TwoWayBindingViewModel TwoWayBinding { get; }
        public OneTimeBindingViewModel OneTimeBinding { get; }
        public OneWayBindingsViewModel OneWayBindings { get; }
        public TriggersViewModel Triggers { get; }
    }
}
