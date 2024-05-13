using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServoTester2
{
    public partial class FormMain : Form
    {
        private readonly byte[] _requestPacket = { 0x01, 0x04, 0x01, 0x00, 0x00, 0x01, 0x30, 0x36 };
        
        /// <summary>
        ///     Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private SerialPort Port { get; } = new SerialPort();
        private List<byte> Receive { get; } = new List<byte>();
        private List<byte> Analyze { get; } = new List<byte>();
        private bool MotorState { get; set; }
        // private int MotorState;
        private int CalibStepState;// { CALIB_SUCCESS, CALIB_FAIL, CALIB_USERSTOP }
        private int CalibResultState;// { get; set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // refresh port
            btRefresh.PerformClick();
            // select baudrate
            tbBaudrate.SelectedIndex = 0;

            // set event
            Port.DataReceived += PortOnDataReceived;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            // refresh
            PortRefresh();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            // check port
            switch (Port.IsOpen)
            {
                case false when btOpen.Text == @"Open":
                    // get port and baudrate
                    var port = tbPorts.Text;
                    var baudrate = Convert.ToInt32(tbBaudrate.Text);
                    // check port
                    if (string.IsNullOrWhiteSpace(port))
                        break;
                    // try catch
                    try
                    {
                        // set port
                        Port.PortName = port;
                        Port.BaudRate = baudrate;
                        Port.Encoding = Encoding.GetEncoding(28591);
                        // open
                        Port.Open();
                        // start timer
                        workTimer.Start();
                        // change button text
                        btOpen.Text = @"Close";
                    }
                    catch (Exception ex)
                    {
                        // debug
                        Debug.WriteLine(ex.Message);
                        // error
                        MessageBox.Show($@"{port}에 연결 할 수 없습니다.");
                    }

                    break;
                case true when btOpen.Text == @"Close":
                    // try catch
                    try
                    {
                        // stop timer
                        workTimer.Stop();
                        // close
                        Port.Close();
                        // change button text
                        btOpen.Text = @"Open";
                    }
                    catch (Exception ex)
                    {
                        // debug
                        Debug.WriteLine(ex.Message);
                        // error
                        MessageBox.Show(@"연결을 닫을 수 없습니다.");
                    }

                    break;
            }
        }

        private void btMotor_Click(object sender, EventArgs e)
        {
            var list = new List<byte>();
            // check sender
            if (sender == btRun)
            {
                // add data
                list.Add(0x01);
                list.Add(0x06);
                list.Add(0x00);
                list.Add(0x01);
                list.Add(0x00);
                list.Add(0x01);
                // get crc
                var crc = GetCrc(list);
                // add crc
                list.AddRange(crc);
            }
            else
            {
                // add data
                list.Add(0x01);
                list.Add(0x06);
                list.Add(0x00);
                list.Add(0x01);
                list.Add(0x00);
                list.Add(0x00);
                // get crc
                var crc = GetCrc(list);
                // add crc
                list.AddRange(crc);
            }

            // check port is open
            if (Port.IsOpen && list.Count > 0)
                // write packet
                Port.Write(list.ToArray(), 0, list.Count);
        }

        private void tbSet_ValueChanged(object sender, EventArgs e)
        {
            Control control = null;
            // check sender
            if (sender is ComboBox box)
                control = box;
            // set control
            else if (sender is NumericUpDown down) 
                control = down;

            // check control
            if (control == null)
                return;
            // packet
            var packet = new List<byte>();
            // get addr
            var addr = Convert.ToUInt16(control.Tag);
            // check tag
            switch (addr)
            {
                case 2:
                case 5:
                    // add range
                    packet.AddRange(GetPacket(addr, Convert.ToInt32(((ComboBox)control).SelectedIndex)));
                    break;
                case 3:
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    // add range
                    packet.AddRange(GetPacket(addr, Convert.ToInt32(((NumericUpDown)control).Value)));
                    break;
            }
            // check port is open
            if (Port.IsOpen && packet.Count > 0)
                // write packet
                Port.Write(packet.ToArray(), 0, packet.Count);
            
            // debug
            foreach (var b in packet)
            {
                Debug.Write($@"{b:X2} ");
            }
            Debug.WriteLine(string.Empty);
        }

        private void PortRefresh()
        {
            // clear
            tbPorts.Items.Clear();
            // get port list
            var ports = SerialPort.GetPortNames().OrderBy(x => x);
            // check ports
            foreach (var port in ports)
                // add port
                tbPorts.Items.Add(port);
            // check item count
            if (tbPorts.Items.Count > 0)
                // select first
                tbPorts.SelectedIndex = 0;
        }

        private void PortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // enter monitor
            if (!Monitor.TryEnter(Receive, 1000))
                return;
            // try finally
            try
            {
                // get data
                var data = Port.Encoding.GetBytes(Port.ReadExisting());
                // add receive data
                Receive.AddRange(data);
            }
            finally
            {
                // exit monitor
                Monitor.Exit(Receive);
            }
        }

        private void workTimer_Tick(object sender, EventArgs e)
        {
            // check motor state
            switch (MotorState)
            {
                // change off
                // case false when !tbOff.Checked:
                case false when !tbOff.Checked:
                    tbOff.Checked = true;
                    // tbOn.Checked = false;
                    break;
                // change on
                // case true when !tbOn.Checked:
                case true when !tbOn.Checked:
                    // tbOff.Checked = false;
                    tbOn.Checked = true;
                    break;
            }
            // check Calibration Step state
            switch (CalibStepState)
            {
                // none
                case 0 when !tbNone.Checked:
                    tbNone.Checked = true;
                    break;
                // hold
                case 1 when !tbHold.Checked:
                    tbHold.Checked = true;
                    break;
                // forward
                case 2 when !tbForward.Checked:
                    tbForward.Checked = true;
                    break;
                // backward
                case 3 when !tbBackward.Checked:
                    tbBackward.Checked = true;
                    break;
                // finish
                case 4 when !tbFinish.Checked:
                    tbFinish.Checked = true;
                    break;
            }
            // check Calibration Result state
            switch (CalibResultState)
            {
                // success
                case 0 when !tbCalibSuccess.Checked:
                    tbCalibSuccess.Checked = true;
                    break;
                // fail
                case 1 when !tbCalibFail.Checked:
                    tbCalibFail.Checked = true;
                    break;
                // user stop
                case 2 when !tbCalibUserStop.Checked:
                    tbCalibUserStop.Checked = true;
                    break;
            }
            // check is open
            if (Port.IsOpen)
            {
                // try catch
                try
                {
                    // check state
                    if (tbState.Checked)
                        // request
                        Port.Write(_requestPacket, 0, _requestPacket.Length);
                }
                catch (Exception ex)
                {
                    // debug
                    Debug.WriteLine(ex.Message);
                }
            }

            // enter monitor
            if (!Monitor.TryEnter(Receive, 50))
                return;
            // try finally
            try
            {
                // check receive buffer
                if (Receive.Count > 0)
                {
                    // add analyze buffer
                    Analyze.AddRange(Receive);
                    // clear receive buffer
                    Receive.Clear();
                }
            }
            finally
            {
                // exit monitor
                Monitor.Exit(Receive);
            }

            // get time
            var time = DateTime.Now;
            // check analyze buffer
            while (Analyze.Count > 0)
            {
                // get laps
                var laps = DateTime.Now - time;
                // check timeout
                if (laps.TotalMilliseconds > 1000)
                    // clear analyze buffer
                    Analyze.Clear();
                // check header length
                // if (Analyze.Count < 3)
                if (Analyze.Count < 4)
                    break;
                // get length
                var length = (Analyze[3] << 8) | Analyze[2];
                // check analyze count
                if (Analyze.Count < length + 6)
                    break;
                // get command
                // var cmd = Analyze[1];
                var cmd = Analyze[4];
                // check command
                switch (cmd)
                {
                    case 0x04:
                        // get value
                        var address = (Analyze[9] << 8) | Analyze[8];
                        // MotorState = ((Analyze[3] << 8) | Analyze[4]) != 0;
                        if (address == 1)
                          MotorState = ((Analyze[11] << 8) | Analyze[10]) != 0;
                        CalibStepState = ((Analyze[11] << 8) | Analyze[10]);
                        CalibResultState = ((Analyze[11] << 8) | Analyze[10]);
                        break;
                    case 0x06:
                        break;
                }
                // clear analyze buffer
                Analyze.Clear();
            }
        }

        private static IEnumerable<byte> GetCrc(IEnumerable<byte> packet)
        {
            var crc = new byte[] { 0xFF, 0xFF };
            ushort crcFull = 0xFFFF;
            // check total packet
            foreach (var data in packet)
            {
                // XOR 1 byte
                crcFull = (ushort)(crcFull ^ data);
                // cyclic redundancy check
                for (var j = 0; j < 8; j++)
                {
                    // get LSB
                    var lsb = (ushort)(crcFull & 0x0001);
                    // check AND
                    crcFull = (ushort)((crcFull >> 1) & 0x7FFF);
                    // check LSB
                    if (lsb == 0x01)
                        // XOR
                        crcFull = (ushort)(crcFull ^ 0xA001);
                }
            }

            // set CRC
            crc[1] = (byte)((crcFull >> 8) & 0xFF);
            crc[0] = (byte)(crcFull & 0xFF);

            return crc;
        }

        private static IEnumerable<byte> GetPacket(ushort addr, int value)
        {
            var list = new List<byte>();
            // add data
            list.Add(0x01);
            list.Add(0x06);
            list.Add((byte)((addr >> 8) & 0xFF));
            list.Add((byte)(addr & 0xFF));
            list.Add((byte)((value >> 8) & 0xFF));
            list.Add((byte)(value & 0xFF));
            // get crc
            var crc = GetCrc(list);
            // add crc
            list.AddRange(crc);
            // return
            return list;
        }
    }
}