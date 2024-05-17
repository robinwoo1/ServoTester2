using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServoTester2
{
  public partial class FormMain : Form
  {
      // private readonly byte[] _requestPacket = { 0x01, 0x04, 0x01, 0x00, 0x00, 0x01, 0x30, 0x36 };
      public const int _LengthLow = 2;
      public const int _LengthHigh = 3;
      private List<byte> _requestPacket;
      public byte[] SendDataPacket = new byte[100];

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
      private int time_tick;
      public List<byte> SendByte {get; set;} = new List<byte>();
      public struct CmdAck_
      {
        public byte Command;
        public ushort PtrCnt;
        public ushort StartAddress;
        public CmdAck_(byte Command_, ushort PtrCnt_, ushort StartAddress_)
        {
          this.Command = Command_;
          this.PtrCnt = PtrCnt_;
          this.StartAddress = StartAddress_;
        }
      }
      CmdAck_ CmdAck = new CmdAck_( 0, 0, 0);

      public void MakeAndSendData(byte Command, ushort StartAddress, short Data)
      {
        ushort PtrCnt = 0;
        ushort calc_crc = 0;
        if (Command == 4)
        {
          if (StartAddress == 1)
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            Port.Write(SendDataPacket, 0, PtrCnt);
          }
        }
        else if (Command == 6)
        {
          // if (StartAddress == 1)
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            Port.Write(SendDataPacket, 0, PtrCnt);
          }
        }
      }
    private void MakePacket(byte Command, ushort StartAddress, short Data)
    {
      ushort data, A1, A2, A3;
      ushort u16PtrCnt = 0;
      ushort Revision = 0;
      byte   TryNum = 0;
      float  ftemp;
      
      SendDataPacket[u16PtrCnt++] = (byte)0x5A;              // Start low            0
      SendDataPacket[u16PtrCnt++] = (byte)0xA5;              // Start high           1
      SendDataPacket[u16PtrCnt++] = (byte)0;//(Length>>0);   // Length low           2
      SendDataPacket[u16PtrCnt++] = (byte)0;//(Length>>8);   // Length high          3
      SendDataPacket[u16PtrCnt++] = Command;                    // Function code        4
      SendDataPacket[u16PtrCnt++] = (byte)(Revision >> 0);     // revision low         5
      SendDataPacket[u16PtrCnt++] = (byte)(Revision >> 8);     // revision high        6
      SendDataPacket[u16PtrCnt++] = TryNum;                     // TryNum               7
      SendDataPacket[u16PtrCnt++] = (byte)(StartAddress >> 0); // Start Address low    8
      SendDataPacket[u16PtrCnt++] = (byte)(StartAddress >> 8); // Start Address high   9

      if (Command == 4) // parameter
      {
        if (StartAddress == 1)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
        }
      }
      else if (Command == 6) // parameter
      {
        // if (StartAddress == 1)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
        }
      }
      
      ushort Length = (ushort)(u16PtrCnt - 4);
      SendDataPacket[_LengthLow] = (byte)(Length >> 0);	  // Length low
      SendDataPacket[_LengthHigh] = (byte)(Length >> 8);	  // Length high

      CmdAck.Command = Command;
      CmdAck.PtrCnt = u16PtrCnt;
      CmdAck.StartAddress = StartAddress;
    }
    ushort GetCRC(byte[] data, int Length)
    {
      int i, j;
      ushort CRCFull = 0xFFFF;
      byte CRCLSB;
      for (i = 0; i < Length - 2; i++)
      {
        CRCFull = (ushort)(CRCFull ^ data[i]);

        for (j = 0; j < 8; j++)
        {
          CRCLSB = (byte)(CRCFull & 0x0001);
          CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

          if (CRCLSB == 1)
            CRCFull = (ushort)(CRCFull ^ 0xA001);
        }
      }

      return CRCFull;
    }

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
        MakeAndSendData(6, 1, 1);
      }
      else
      {
        MakeAndSendData(6, 1, 0);
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
          // packet.AddRange(GetPacket(addr, Convert.ToInt32(((ComboBox)control).SelectedIndex)));
          MakeAndSendData(6, addr, Convert.ToInt16(((ComboBox)control).SelectedIndex));
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
          // packet.AddRange(GetPacket(addr, Convert.ToInt32(((NumericUpDown)control).Value)));
          MakeAndSendData(6, addr, Convert.ToInt16(((NumericUpDown)control).Value));
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
      
      time_tick++;
      tbAckMessage.Text = time_tick.ToString();
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
          {
            // request
            // Port.Write(_requestPacket, 0, _requestPacket.Length);
            MakeAndSendData(4, 1, 0);
          }
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