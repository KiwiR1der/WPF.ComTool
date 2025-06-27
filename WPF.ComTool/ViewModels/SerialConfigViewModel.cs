using CommunityToolkit.Mvvm.ComponentModel;
using WPF.ComTool.Enums;

namespace WPF.ComTool.ViewModels
{
    public partial class SerialConfigViewModel : ViewModelBase
    {
        //[ObservableProperty]
        //private Array _port;

        [ObservableProperty]
        private string[] _port;

        [ObservableProperty]
        private List<int> _baudRate;

        [ObservableProperty]
        private Array _parityBit;

        [ObservableProperty]
        private Array _stopBit;

        [ObservableProperty]
        private List<int> _dataBit;

        public SerialConfigViewModel()
        {
            //Port = Enum.GetValues(typeof(Port));

            Port = System.IO.Ports.SerialPort.GetPortNames();

            BaudRate = new List<int> { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200 };
            ParityBit = Enum.GetValues(typeof(ParityBit));
            StopBit = Enum.GetValues(typeof(StopBit));
            DataBit = new List<int> { 6, 7, 8 };
        }
    }
}
