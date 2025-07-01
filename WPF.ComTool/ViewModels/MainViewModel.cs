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

        private string _repoLink;
        private string _cnblogLink;

        public MainViewModel()
        {
            SerialConfig = new SerialConfigViewModel();
            CurrentSession = new SerialSessionViewModel();
            if (SerialConfig.Port.Count() > 0)
            {
                CurrentSession.Port = SerialConfig.Port[0];
            }
            _repoLink = "https://github.com/cr0vL3Y/WPF.ComTool";
            _cnblogLink = "https://www.cnblogs.com/PixelKiwi";
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

        [RelayCommand]
        private void OpenRepoLink()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = _repoLink,
                UseShellExecute = true
            });
        }

        [RelayCommand]
        private void OpenBlogLink()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = _cnblogLink,
                UseShellExecute = true
            });
        }
    }
}
