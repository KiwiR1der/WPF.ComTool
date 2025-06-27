namespace WPF.ComTool.Enums
{
    /// <summary>
    /// 端口号
    /// </summary>
    public enum Port
    {
        COM1,
        COM2,
        COM3,
        COM4,
        COM5,
        COM6,
        COM7,
        COM8,
        COM9,
        COM10,
        COM11,
        COM12,
        COM13,
        COM14,
        COM15,
        COM16
    }

    /// <summary>
    /// 校验位
    /// </summary>
    public enum ParityBit
    {
        None = 0,
        Odd = 1,
        Even = 2,
        Mark = 3,
        Space = 4
    }

    /// <summary>
    /// 停止位
    /// </summary>
    public enum StopBit
    {
        One = 1,
        OnePointFive = 3,
        Two = 2,
    }
}
