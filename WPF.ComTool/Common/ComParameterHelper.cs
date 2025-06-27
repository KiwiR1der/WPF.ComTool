using System.IO.Ports;

namespace WPF.ComTool.ViewModels
{
    public class ComParameterHelper
    {
        public static Parity GetParity(string emp)
        {
            Parity parity;
            switch (emp)
            {
                case "None":
                    parity = Parity.None;
                    break;
                case "Odd":
                    parity = Parity.Odd;
                    break;
                case "Even":
                    parity = Parity.Even;
                    break;
                default:
                    parity = Parity.None;
                    break;
            }
            return parity;
        }

        public static StopBits getStopBits(string emp)
        {
            StopBits stopBits;
            switch (emp)
            {
                case "One":
                    stopBits = StopBits.One;
                    break;
                case "Two":
                    stopBits = StopBits.Two;
                    break;
                case "OnePointFive":
                    stopBits = StopBits.OnePointFive;
                    break;
                default:
                    stopBits = StopBits.None;
                    break;
            }
            return stopBits;
        }


    }
}
