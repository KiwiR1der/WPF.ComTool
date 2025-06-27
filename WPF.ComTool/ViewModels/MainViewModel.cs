using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPF.ComTool.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        [ObservableProperty]
        private SerialConfigViewModel _serialConfig;

        [ObservableProperty]
        private SerialSessionViewModel _currentSession;

        public MainViewModel()
        {
            SerialConfig = new SerialConfigViewModel();
            CurrentSession = new SerialSessionViewModel();
            if (SerialConfig.Port.Count() > 0)
            {
                CurrentSession.Port = SerialConfig.Port[0];
            }
        }

        [RelayCommand]
        private void OpenPort() => CurrentSession.Open();

        [RelayCommand]
        private void ClosePort() => CurrentSession.Close();

        [RelayCommand]
        private void Send() => CurrentSession.Send();

        [RelayCommand]
        private void ClearDataSend() => CurrentSession.ClearDataSend();

        [RelayCommand]
        private void ClearDataReceived() => CurrentSession.ClearDataReceived();

        [RelayCommand]
        private void ClearSendCount() => CurrentSession.ClearSendCount();

        [RelayCommand]
        private void ClearReceiveCount() => CurrentSession.ClearReceiveCount();
    }
}
