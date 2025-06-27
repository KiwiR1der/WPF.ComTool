using CommunityToolkit.Mvvm.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Windows;
using WPF.ComTool.Enums;

namespace WPF.ComTool.ViewModels
{
    public partial class SerialSessionViewModel : ViewModelBase
    {
        private SerialPort _serialPort = new SerialPort();

        [ObservableProperty]
        private string _port = string.Empty;
        [ObservableProperty]
        private int _baudRate = 115200;
        [ObservableProperty]
        private ParityBit _parityBit = ParityBit.None;
        [ObservableProperty]
        private StopBit _stopBit = StopBit.One;
        [ObservableProperty]
        private int _dataBit = 8;

        [ObservableProperty]
        private bool isOpen = false;

        [ObservableProperty]
        private string dataReceived = string.Empty;
        [ObservableProperty]
        private string dataSend = string.Empty;
        [ObservableProperty]
        private bool receiveFormatHex = true;
        [ObservableProperty]
        private bool sendFormatHex = true;
        [ObservableProperty]
        private int sendCount = 0;
        [ObservableProperty]
        private int receiveCount = 0;

        /// <summary>
        /// 清空接收数据
        /// </summary>
        public void ClearDataReceived() => DataReceived = string.Empty;

        /// <summary>
        /// 清空发送数据
        /// </summary>
        public void ClearDataSend() => DataSend = string.Empty;

        /// <summary>
        /// 清空发送计数
        /// </summary>
        public void ClearSendCount() => SendCount = 0;

        /// <summary>
        /// 清空接收计数
        /// </summary>
        public void ClearReceiveCount() => ReceiveCount = 0;

        public bool Open()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                return Close();
            }

            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = Port.ToString();
                _serialPort.BaudRate = BaudRate;
                _serialPort.Parity = ComParameterHelper.GetParity(ParityBit.ToString());
                _serialPort.StopBits = ComParameterHelper.getStopBits(StopBit.ToString());
                _serialPort.DataBits = DataBit;
                _serialPort.RtsEnable = true;   // 开启硬件流控制RTS
                _serialPort.DataReceived += _serialPort_DataReceived;
                _serialPort.Open();

                if (_serialPort.IsOpen)
                {
                    return IsOpen = true;
                }
                else
                {
                    return IsOpen = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return IsOpen = false;
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int length = _serialPort.BytesToRead;
            byte[] readBuffer = new byte[length];
            _serialPort.Read(readBuffer, 0, readBuffer.Length);
            _serialPort.ReadExisting();  // 清除缓冲区中的数据

            ReceiveCount += _serialPort.ReceivedBytesThreshold;

            if (ReceiveFormatHex)
            {
                DataReceived += ByteHelper.ByteToString(readBuffer, true);
            }
            else
            {
                DataReceived += Encoding.Default.GetString(readBuffer);
                //DataReceived = Encoding.UTF8.GetString(readBuffer);
            }
        }

        public bool Close()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    return IsOpen = _serialPort.IsOpen;
                }
                else
                {
                    return IsOpen = _serialPort.IsOpen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return IsOpen = false;
            }
        }

        public void Send()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    if (SendFormatHex)
                    {
                        byte[] bytes = ByteHelper.StringToHexByte(DataSend);
                        _serialPort.Write(bytes, 0, bytes.Length);
                        SendCount = bytes.Length;
                    }
                    else
                    {
                        _serialPort.Write(DataSend);
                        SendCount = DataSend.Length;
                    }
                }
                // 信使
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
