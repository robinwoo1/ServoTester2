using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServoTester2
{
  public partial class FormMain : Form
  {
      // private readonly byte[] _requestPacket = { 0x01, 0x04, 0x01, 0x00, 0x00, 0x01, 0x30, 0x36 };
      public const ushort SERIAL_BUF_SIZE = 128*8;
      public const ushort COMMAND_LIST_NUM = 1000;
      public const int _LengthLow = 2;
      public const int _LengthHigh = 3;
      private List<byte> _requestPacket;
      public byte[] SendDataPacket = new byte[128 * 8];

      /// <summary>
      ///     Constructor
      /// </summary>
      public FormMain()
      {
          InitializeComponent();
      }

      private SerialPort Port { get; } = new SerialPort();
      // private List<byte> Receive { get; set;} = new List<byte>();
      // private List<byte> Analyze { get; } = new List<byte>();
      private bool MotorState { get; set; }
      // private int MotorState;
      private int CalibStepState;// { CALIB_SUCCESS, CALIB_FAIL, CALIB_USERSTOP }
      private int CalibResultState;// { get; set; }
      private int time_tick;
      private int timer_working = 0;
      private int port_working = 0;
      public byte[] ComReadBuffer = new byte[128 * 8];
      public int ComReadIndex = 0;
      public ushort Command_Index_Pc;
      public ushort[,] Command_List_Pc = new ushort[COMMAND_LIST_NUM, 3];
      public List<byte> SendByte {get; set;} = new List<byte>();
      public struct _para_member
      {
        public ushort u16MC_ZERO_DUMMY;
        public ushort u16MC_TCAM_ACTM;                  //1
        public float f32MC_FASTEN_TORQUE;                 //2
        public float f32MC_TORQUE_MIN_MAX;                //3
        public ushort u16MC_TARGET_ANGLE;               //4
        public ushort u16MC_FASTEN_MIN_ANGLE;           //5
        public ushort u16MC_FASTEN_MAX_ANGLE;           //6
        public float f32MC_SNUG_TORQUE;                   //7
        public ushort u16MC_FASTEN_SPEED;               //8
        public ushort u16MC_FREE_FASTEN_ANGLE;          //9
        public ushort u16MC_FREE_FASTEN_SPEED;          //10
        public ushort u16MC_SOFT_START;                 //11
        public ushort u16MC_FASTEN_SEATTING_POINT_RATE; //12
        public ushort u16MC_FASTEN_TQ_RISING_TIME;      //13
        public ushort u16MC_RAMP_UP_SPEED;              //14
        public ushort u16MC_TORQUE_COMPENSATION;        //15
        public ushort u16MC_TORQUE_OFFSET;              //16
        public ushort u16MC_MAX_PULSE_COUNT;            //17
      // } para_Val_basic;
      // typedef struct
      // {
        public ushort u16MC_ADVANCED_MODE;              //0
        public float f32MC_ADVANCED_PARA1;                //1
        public float f32MC_ADVANCED_PARA2;                //2
        public float f32MC_ADVANCED_PARA3;                //3
        public float f32MC_ADVANCED_PARA4;                //4
        public float f32MC_ADVANCED_PARA5;                //5
        public float f32MC_ADVANCED_PARA6;                //6
        public float f32MC_ADVANCED_PARA7;                //7
        public float f32MC_ADVANCED_PARA8;                //8
        public float f32MC_ADVANCED_PARA9;                //9
        public float f32MC_ADVANCED_PARA10;               //10
        public float f32MC_ADVANCED_PARA11;               //11
        public float f32MC_ADVANCED_PARA12;               //12
        public float f32MC_ADVANCED_PARA13;               //13
        public float f32MC_ADVANCED_PARA14;               //14
        public float f32MC_ADVANCED_PARA15;               //15
        public float f32MC_ADVANCED_PARA16;               //16
        public float f32MC_ADVANCED_PARA17;               //17
        public float f32MC_ADVANCED_PARA18;               //18
        public float f32MC_ADVANCED_PARA19;               //19
        public ushort u16MC_FREE_REVERSE_ROTATION_SPEED;//1
        public float f32MC_FREE_REVERSE_ROTATION_ANGLE;   //2
        public ushort u16MC_REVERS_ANGLE_SETTING_SPEED; //3
        public ushort u16MC_REVERS_ANGLE_SETTING_ANGLE; //4
        public ushort u16MC_REVERS_ANGLE_SETTING_FW_REV;//5
      // } para_Val_advanced;
      // typedef struct
      // {
        public ushort u16MC_DRIVER_MODEL;               //0
        public ushort u16MC_UNIT;                       //1
        public ushort u16MC_ACC_DEC_TIME;               //2
        public ushort u16MC_FASTEN_TORQUE_MAINTAIN_TIME;//3
        public ushort u16MC_USE_MAXTQ_FOR_LOOSENING;    //4
        public ushort u16MC_LOOSENING_SPEED;            //5
        public float f32MC_TOTAL_FASTENING_TIME;          //6
        public float f32MC_TOTAL_LOOSENING_TIME;          //7
        public float f32MC_INIT_LOOSENING_TIME_LIMIT;     //8
        public ushort u16MC_SCREW_TYPE;                 //9
        public float f32MC_JUDGE_FASTEN_MIN_TURNS;        //10
        public ushort u16MC_FASTENING_STOP_ALARM;       //11
        public ushort u16MC_TORQUE_COMPENSATION_MAIN;   //12
        public ushort u16MC_CROWFOOT_ENABLE;            //13
        public float f32MC_CROWFOOT_RATIO;                //14
        public ushort u16MC_CROWFOOT_EFFICIENCY;        //15
        public float f32MC_CROWFOOT_REVERSE_TORQUE;       //16
        public ushort u16MC_CROWFOOT_REVERSE_SPEED;     //17
      // } para_Val_etc;
        public ushort u16MC_VERSION;
      }
      public struct _para
      {
        public _para_member val;
        public _para_member dft;
        public _para_member min;
        public _para_member max;
      }
      _para Mc_Para;
      public struct _dr_model
      {
        // MODEL
        public ushort    u16Driver_id;
        public ushort    u16Driver_vendor_id;
        public ushort    u16Controller_vendor_id;      // controller model no. 1:26, 2:32
        public ushort    u16Motor_id;          // used motor no.       1:26, 2:32
        // TORQUE / SPEED
        public float     f32Tq_min_Nm;         // default Nm
        public float     f32Tq_max_Nm;         // default Nm
        public uint      u32Speed_min;
        public uint      u32Speed_max;
        // SETING
        public float     f32Gear_ratio;
        public float     f32Angle_head_ratio;
        // RESERVED
        // public byte      reserved2[32];
        public _dr_model(ushort u16Driver_id_)
        {
          this.u16Driver_id = u16Driver_id_;
          this.u16Driver_vendor_id = 2;
          this.u16Controller_vendor_id = 1;      // controller model no. 1:26, 2:32
          this.u16Motor_id = 2;          // used motor no.       1:26, 2:32
          // TORQUE / SPEED
          this.f32Tq_min_Nm = 15;         // default Nm
          this.f32Tq_max_Nm = 80;         // default Nm
          this.u32Speed_min = 50;
          this.u32Speed_max = 475;
          // SETING
          this.f32Gear_ratio = 48.8163261f;
          this.f32Angle_head_ratio = 1.54545498f;
        }
      }
      _dr_model Info_DrvModel_para = new _dr_model(0);
      public struct _DriverInfoStruct
      {
        public ushort  u16Type;                      // 1 
        public ushort  u16Version;                   // 2
        public ushort   u8Factory_Gear_efficiency;    // 3
        public ushort   u8User_Gear_efficiency;       // 4
        public ushort  u16Serial_low;                // 5
        public ushort  u16Serial_high;               // 6
        public ushort  u16MaintenanceCount_low;      // 7
        public ushort  u16MaintenanceCount_high;     // 8
        public ushort  u16WarningMaintenanceCount;   // 9
        public ushort  u16TorqueOffset;              // 10
        public ushort  u16LED_Band;                  // 11
        public ushort  u16Temperature;               // 12
        public ushort  u16Initial_Angle;             // 13
        public ushort  u16Error;                     // 14
        public _DriverInfoStruct(ushort u16Type_)
        {
          this.u16Type = u16Type_;
          this.u16Version = 0;
          this.u8Factory_Gear_efficiency = 0;
          this.u8User_Gear_efficiency = 0;
          this.u16Serial_low = 0;
          this.u16Serial_high = 0;
          this.u16MaintenanceCount_low = 0;
          this.u16MaintenanceCount_high = 0;
          this.u16WarningMaintenanceCount = 0;
          this.u16TorqueOffset = 0;
          this.u16LED_Band = 0;
          this.u16Temperature = 0;
          this.u16Initial_Angle = 0;
          this.u16Error = 0;
        }
      }
      _DriverInfoStruct DriverInfo = new _DriverInfoStruct(0);
      _DriverInfoStruct outDriverInfo = new _DriverInfoStruct(0);
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
      public struct RecvBuf_
      {
        public ushort head;
        public ushort tail;
        public byte[] data;
        public RecvBuf_(int num)
        {
          this.head = 0;
          this.tail = 0;
          this.data = new byte[num];
        }
      }
      RecvBuf_ RecvBuf = new RecvBuf_(SERIAL_BUF_SIZE);
      public int rbuf_put(byte[] rbuf, ushort rsize)
      {
        ushort nhead;
        ushort datatocopy;
        ushort curPos = RecvBuf.head; // Update the last position before copying new data

        if (curPos + rsize > SERIAL_BUF_SIZE)
        {
          datatocopy = (ushort)(SERIAL_BUF_SIZE - curPos); // find out how much space is left in the main buffer
          if(RecvBuf.tail > RecvBuf.head){
            return 0;
          }
          else if((RecvBuf.tail < RecvBuf.head) && (RecvBuf.tail <= (rsize-datatocopy))){
            return 0;
          }
          // memcpy((uint8_t *)rb->data+curPos, rbuf, datatocopy); // copy data in that remaining space
          Array.Copy(rbuf, 0, RecvBuf.data, curPos, datatocopy); // copy data in that remaining space
          curPos = 0; // point to the start of the buffer
          // memcpy((uint8_t *)rb->data, (uint8_t *)rbuf+datatocopy, (rsize-datatocopy)); // copy the remaining data
          Array.Copy(rbuf, datatocopy, RecvBuf.data, curPos, rsize-datatocopy); // copy the remaining data
          RecvBuf.head = (ushort)(rsize-datatocopy); // update the position
        }
        else
        {
          nhead = (ushort)(RecvBuf.head + rsize);
          if((RecvBuf.tail > RecvBuf.head) && (RecvBuf.tail <= nhead)){
            return 0;
          }
          // rbuf.CopyTo(RecvBuf.data, curPos);
          Array.Copy(rbuf, 0, RecvBuf.data, curPos, rbuf.Count());
          RecvBuf.head = (ushort)((rsize+curPos) & (SERIAL_BUF_SIZE-1));
        }
        
        return 1;
      }
      public byte rb_get(byte[] err)
      {
        byte d;
        ushort ntail = (ushort)((RecvBuf.tail + 1) & (SERIAL_BUF_SIZE - 1));
        if (RecvBuf.head == RecvBuf.tail)
        {
          err[0] = 1;
          return 0;
        }
        d = RecvBuf.data[RecvBuf.tail];
        RecvBuf.tail = ntail;
        return d;
      }

      public void SendPacket(byte[] Packet, ushort Cnt)
      {
        try
        {
          if (Port.IsOpen && Cnt > 0)
          Port.Write(Packet, 0, Cnt);
        }
        finally
        {

        }
      }
      public void MakeAndSendData(byte Command, ushort StartAddress, short Data)
      {
        ushort PtrCnt = 0;
        ushort calc_crc = 0;
        
        if (Command == 2)
        {
          // if (StartAddress == 1)
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            // Port.Write(SendDataPacket, 0, PtrCnt);
            SendPacket(SendDataPacket, PtrCnt);
          }
        }
        else if (Command == 7)
        {
          if (StartAddress == 1)//download driver info
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          // else if (StartAddress == 2)//upload driver info
          else if (StartAddress == 3)//Speaker & Output
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          else if (StartAddress == 4)//LED band & output
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          // else if (StartAddress == 5)//
          // else if (StartAddress == 6)//
          // else if (StartAddress == 7)//
          else if (StartAddress == 8)//reset Maintenance count
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          // else if (StartAddress == 9)//
          else if (StartAddress == 10)//Check torque Offset
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          else if (StartAddress == 11)//Save torque Offset
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          else if (StartAddress == 12)//Start Initail Angle
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, PtrCnt);
          }
          // else if (StartAddress == 13)//receive Initial Angle result
        }
        else if (Command == 104)
        {
          // if (StartAddress == 1)
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            // Port.Write(SendDataPacket, 0, PtrCnt);
            SendPacket(SendDataPacket, PtrCnt);
          }
        }
        else if (Command == 106)
        {
          // if (StartAddress == 1)
          {
            MakePacket(Command, StartAddress, Data);
            PtrCnt = CmdAck.PtrCnt;
            calc_crc = GetCRC(SendDataPacket, PtrCnt + 2);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[PtrCnt++] = (byte)(calc_crc >> 8);
            // Port.Write(SendDataPacket, 0, PtrCnt);
            SendPacket(SendDataPacket, PtrCnt);
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

      if (Command == 104) // parameter
      {
        // if (StartAddress == 1)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
        }
      }
      else if (Command == 106) // parameter
      {
        // if (StartAddress == 1)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
        }
      }
      else if (Command == 7) // parameter
      {
        if (StartAddress == 1)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(outDriverInfo.u16TorqueOffset >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(DriverInfo.u16TorqueOffset >> 8);
        }
        if (StartAddress == 13)
        {
          SendDataPacket[u16PtrCnt++] = (byte)(DriverInfo.u16TorqueOffset >> 0);
          SendDataPacket[u16PtrCnt++] = (byte)(DriverInfo.u16TorqueOffset >> 8);
        }
        else
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

      parameterInit();
      
      // set event
      // Port.DataReceived += PortOnDataReceived;
      Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
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
            ComReadIndex = 0;
            RecvBuf.tail = 0;
            RecvBuf.head = 0;
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
            // close
            while (port_working > 0){}
            Port.Close();
            // stop timer
            while (timer_working > 0){}
            workTimer.Stop();
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
      // var list = new List<byte>();
      // check sender
      if (sender == btRun)
      {
        MakeAndSendData(106, 1, 1);
      }
      else
      {
        MakeAndSendData(106, 1, 0);
      }

      // // check port is open
      // if (Port.IsOpen && list.Count > 0)
      //   // write packet
      //   Port.Write(list.ToArray(), 0, list.Count);
    }
    private void btTqOffset_Click(object sender, EventArgs e)
    {
      if (!Port.IsOpen)
        return;
      
      // switch(sender)
      // {
      //   case btTqOffsetStart:
      //     MakeAndSendData(7, 13, 1);
      //     break;
      //   case btTqOffsetStop:
      //     MakeAndSendData(7, 13, 0);
      //     break;
      //   case btTqOffsetSet:
      //     MakeAndSendData(7, 9, 0);
      //     break;
      // }
      if (sender == btTqOffsetCheck)
      {
        MakeAndSendData(7, 10, 0);
        btTqOffsetSave.Enabled = true;
      }
      else if (sender == btTqOffsetSave)
      {
        MakeAndSendData(7, 11, 0);
      }
    }
    private void btAlarmReset_Click(object sender, EventArgs e)
    {
      if (!Port.IsOpen)
        return;
      MakeAndSendData(2, 6, 0);
    }
    private void btCalibrationCommand_Click(object sender, EventArgs e)
    {
      if (!Port.IsOpen)
        return;
      if (sender == btCalibStart)
      {
        MakeAndSendData(7, 11, 1);
      }
      else
      {
        MakeAndSendData(7, 11, 0);
      }
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
          MakeAndSendData(106, addr, Convert.ToInt16(((ComboBox)control).SelectedIndex));
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
          MakeAndSendData(106, addr, Convert.ToInt16(((NumericUpDown)control).Value));
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

    // private void PortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      port_working = 1;
      try
      {
        if (Port.IsOpen)
          this.Invoke(new EventHandler(MySerialReceived));//메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
      }
      finally
      {

      }
      // // enter monitor
      // if (!Monitor.TryEnter(Receive, 1000))
      //   return;
      // // try finally
      // try
      // {
      //   // get data
      //   var data = Port.Encoding.GetBytes(Port.ReadExisting());
      //   // byte[] data = Port.Encoding.GetBytes(Port.ReadExisting());
      //   // add receive data
      //   // Receive.AddRange(data);
      //   rbuf_put(data, (ushort)(data.Count()));
      //   // Receive.Add(data);
      // }
      // finally
      // {
      //   // // exit monitor
      //   // Monitor.Exit(Receive);
      // }
      port_working = 0;
    }

    private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
    {
      try
      {
        // int ReceiveData = Port.ReadByte();  //시리얼 버터에 수신된 데이타를 ReceiveData 읽어오기
        byte[] data = Port.Encoding.GetBytes(Port.ReadExisting());
        rbuf_put(data, (ushort)(data.Count()));

        ProcessPcMcReceivedCommData();
      }
      finally
      {

      }
      // richTextBox_received.Text = richTextBox_received.Text + string.Format("{0:X2}", ReceiveData);  //int 형식을 string형식으로 변환하여 출력
    }
    private void workTimer_Tick(object sender, EventArgs e)
    {
      timer_working = 1;
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
        case 2 when !tbCalibSuccess.Checked:
          tbCalibSuccess.Checked = true;
          break;
        // fail
        case 1 when !tbCalibFail.Checked:
          tbCalibFail.Checked = true;
          break;
        // user stop
        case 0 when !tbCalibUserStop.Checked:
          tbCalibUserStop.Checked = true;
          break;
      }
      // // check is open
      // if (Port.IsOpen)
      // {
      //   // try catch
      //   try
      //   {
      //     // check state
      //     if (tbState.Checked)
      //     {
      //       // request
      //       // Port.Write(_requestPacket, 0, _requestPacket.Length);
      //       MakeAndSendData(104, 1, 0);
      //     }
      //   }
      //   catch (Exception ex)
      //   {
      //     // debug
      //     Debug.WriteLine(ex.Message);
      //   }
      // }

      // // enter monitor
      // if (!Monitor.TryEnter(Receive, 50))
      //   return;
      // // try finally
      // try
      // {
      //   // check receive buffer
      //   if (Receive.Count > 0)
      //   {
      //     // add analyze buffer
      //     Analyze.AddRange(Receive);
      //     // clear receive buffer
      //     Receive.Clear();
      //   }
      // }
      // finally
      // {
      //   // exit monitor
      //   Monitor.Exit(Receive);
      // }

      // // get time
      // var time = DateTime.Now;
      // ProcessPcMcReceivedCommData();
      // Analyze.Clear();
      timer_working = 0;
    }
    public void ProcessPcMcReceivedCommData()
    {
      ushort cnt = 0;
      if (RecvBuf.head < RecvBuf.tail)
        cnt = (ushort)(RecvBuf.data.Length - RecvBuf.tail + RecvBuf.head);
      else
        cnt = (ushort)(RecvBuf.head - RecvBuf.tail);

      // check analyze buffer
      // while (Analyze.Count > 0)
      // for (int i = 0; i < Analyze.Count; i++)
      for (int i = 0; i < cnt; i++)
      {
        // // get laps
        // var laps = DateTime.Now - time;
        // // check timeout
        // if (laps.TotalMilliseconds > 1000)
        //   // clear analyze buffer
        //   Analyze.Clear();
        byte[] err = new byte[2];
        byte data = rb_get(err);

        // if (err[0] == 1)
        //   break;

        ComReadBuffer[ComReadIndex++] = data;
        // ComReadBuffer[ComReadIndex++] = Analyze[i];
        // check header length
        if ((ComReadBuffer[0] == 0x5A) && (ComReadBuffer[1] == 0xA5) && (ComReadIndex >= 4))
        {
          // get length
          var data_length = (ComReadBuffer[3] << 8) | ComReadBuffer[2];
          // check analyze count
          if (ComReadIndex == (data_length + 6))
          {
            byte check_Command = ComReadBuffer[4];
            byte Command = (byte)(check_Command & 0x7f);
            byte Try_num = ComReadBuffer[7];
            ushort StartAddress = (ushort)((ComReadBuffer[9]<<8) | (ushort)ComReadBuffer[8]);
            ushort received_crc = (ushort)(ComReadBuffer[ComReadIndex - 2] & 0xff);
            received_crc |= (ushort)(ComReadBuffer[ComReadIndex - 1] << 8);
            ushort calc_crc = GetCRC(ComReadBuffer, ComReadIndex);
            ComReadIndex = 0;
            if (calc_crc == received_crc)
            {
              if (Command != 3)
              {
                Command_List_Pc[Command_Index_Pc, 0] = Command;
                Command_List_Pc[Command_Index_Pc, 1] = StartAddress;
                Command_List_Pc[Command_Index_Pc, 2] = 0;
                Command_Index_Pc++;
                if (Command_Index_Pc >= COMMAND_LIST_NUM)
                  Command_Index_Pc = 0;
              }
              // check command
              switch (Command)
              {
                case 2:
                  break;
                case 3:// Pc <- Mc, Cyclic
                  ushort TqSensorValue = (ushort)((ComReadBuffer[13] << 8) | ComReadBuffer[12]);
                  tbTqSensorValue.Text = TqSensorValue.ToString();
                  ushort TqOffsetValue = (ushort)((ComReadBuffer[15] << 8) | ComReadBuffer[14]);
                  DriverInfo.u16TorqueOffset = TqOffsetValue;
                  tbTqOffsetValue.Text = TqOffsetValue.ToString();
                  ushort Error = (ushort)((ComReadBuffer[29] << 8) | ComReadBuffer[28]);
                  tbError.Text = Error.ToString();
                  uint MaintCnt = (uint)((ComReadBuffer[51] << 24) | (ComReadBuffer[50] << 16) | (ComReadBuffer[49] << 8) | ComReadBuffer[48]);
                  tbMaintCnt.Text = MaintCnt.ToString();
                  MotorState = ((ComReadBuffer[27] << 8) | ComReadBuffer[26]) != 0;
                  break;
                case 7:
                  if (StartAddress == 101)// Pc <- Mc
                  {
                    int CalibStepState1 = (int)((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    if (CalibStepState1 == 0)
                      CalibStepState = 0;
                    else if (CalibStepState1 == 1)
                      CalibStepState = 1;
                    else if (CalibStepState1 == 2 || CalibStepState1 == 3)
                      CalibStepState = 2;
                    else if (CalibStepState1 == 4 || CalibStepState1 == 5)
                      CalibStepState = 3;
                    else
                      CalibStepState = 4;
                    AckSend(Command, Try_num, StartAddress, 0);       // return Ack OK
                  }
                  else if (StartAddress == 12)// Pc <- Mc
                  {
                    CalibResultState = (int)((ComReadBuffer[11] << 11) | ComReadBuffer[10]);
                    AckSend(Command, Try_num, StartAddress, 0);       // return Ack OK
                  }
                  // else if (StartAddress == 13)// Pc -> Mc
                  
                  break;
                case 104:
                  // get value
                  // MotorState = ((ComReadBuffer[3] << 8) | ComReadBuffer[4]) != 0;
                  if (StartAddress == 1)// Pc -> Mc
                  {

                  }
                  else if (StartAddress == 2)// Pc <- Mc
                  {
                    MotorState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]) != 0;
                    // CalibStepState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    // CalibResultState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                  }
                  break;
                case 106:
                  break;
                default:
                  break;
              }
            }
            else
            {
              // AckSend(Command, Try_num, StartAddress, 2);       // return check CRC error
            }
          }
        }
        else if (((ComReadIndex > 0) && (ComReadBuffer[0] != 0x5A))  // check packet error
            || ((ComReadIndex > 1) && (ComReadBuffer[1] != 0xA5)))  // check packet error
        {
          ComReadIndex = 0;// no return Ack
        }
      }
    }
    
    // send ack code
    private void AckSend(byte command, byte Try_num, ushort StartAddress, byte code)
    {
      ushort u16PtrCnt = 0, calc_crc;
      byte[] DataPacket = new byte[20];

      DataPacket[u16PtrCnt++] = 0x5A;    // Start low
      DataPacket[u16PtrCnt++] = 0xA5;		// Start high
      DataPacket[u16PtrCnt++] = 0;			  // Length low
      DataPacket[u16PtrCnt++] = 0;		    // Length high
      if (code != 0)
        DataPacket[u16PtrCnt++] = (byte)(0x80 | command);		  // Function code
      else
        DataPacket[u16PtrCnt++] = command;		  // Function code
      DataPacket[u16PtrCnt++] = 0;		    // revision low, 1byte
      DataPacket[u16PtrCnt++] = 0;		    // revision high, 1byte
      DataPacket[u16PtrCnt++] = Try_num; // u8LcdMcComReadBuffer[7];		  // Try num.
      DataPacket[u16PtrCnt++] = (byte)(StartAddress);  	// Start Address low
      DataPacket[u16PtrCnt++] = (byte)(StartAddress>>8);	  // Start Address high
      DataPacket[u16PtrCnt++] = code;		// return ack code
      DataPacket[u16PtrCnt++] = 0;		    // 
      DataPacket[u16PtrCnt++] = 0;		    // reserved
      DataPacket[u16PtrCnt++] = 0;		    // reserved

      ushort Length = (ushort)(u16PtrCnt - 4);
      DataPacket[_LengthLow] = (byte)(Length);	  // Length low
      DataPacket[_LengthHigh] = (byte)(Length>>8);	  // Length high
      
      calc_crc = GetCRC(DataPacket, u16PtrCnt+2);
      DataPacket[u16PtrCnt++] = (byte)(calc_crc & 0xff);
      DataPacket[u16PtrCnt++] = (byte)((calc_crc >> 8) & 0xff);

      // SerialPuts_Pc((uint16_t)u16PtrCnt, (uint8_t*)DataPacket);
      SendPacket(DataPacket, u16PtrCnt);
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
    private void parameterInit()
    {
      Mc_Para.dft.u16MC_ZERO_DUMMY=0;                 Mc_Para.min.u16MC_ZERO_DUMMY=0;                 Mc_Para.max.u16MC_ZERO_DUMMY=1;                 //dummy
      Mc_Para.dft.u16MC_TCAM_ACTM=0;                  Mc_Para.min.u16MC_TCAM_ACTM=0;                  Mc_Para.max.u16MC_TCAM_ACTM=1;                  //SET[01] :i select torque/angle
      Mc_Para.dft.f32MC_FASTEN_TORQUE=50;             Mc_Para.min.f32MC_FASTEN_TORQUE=30;             Mc_Para.max.f32MC_FASTEN_TORQUE=500;            //SET[02] :f toque [Nm*100]
      Mc_Para.dft.f32MC_TORQUE_MIN_MAX=1000;          Mc_Para.min.f32MC_TORQUE_MIN_MAX=0;             Mc_Para.max.f32MC_TORQUE_MIN_MAX=10000;         //SET[03] : %  (Actually use value when initializing para)
      Mc_Para.dft.u16MC_TARGET_ANGLE=0;               Mc_Para.min.u16MC_TARGET_ANGLE=0;               Mc_Para.max.u16MC_TARGET_ANGLE=20000;           //SET[04] : degree
      Mc_Para.dft.u16MC_FASTEN_MIN_ANGLE=0;           Mc_Para.min.u16MC_FASTEN_MIN_ANGLE=0;           Mc_Para.max.u16MC_FASTEN_MIN_ANGLE=20000;       //SET[05] : 
      Mc_Para.dft.u16MC_FASTEN_MAX_ANGLE=0;           Mc_Para.min.u16MC_FASTEN_MAX_ANGLE=0;           Mc_Para.max.u16MC_FASTEN_MAX_ANGLE=20000;       //SET[06] : 
      Mc_Para.dft.f32MC_SNUG_TORQUE=0;                Mc_Para.min.f32MC_SNUG_TORQUE=0;                Mc_Para.max.f32MC_SNUG_TORQUE=100;              //SET[07] : %
      Mc_Para.dft.u16MC_FASTEN_SPEED=300;             Mc_Para.min.u16MC_FASTEN_SPEED=100;             Mc_Para.max.u16MC_FASTEN_SPEED=2000;            //SET[08] : speed[RPM]
      Mc_Para.dft.u16MC_FREE_FASTEN_ANGLE=0;          Mc_Para.min.u16MC_FREE_FASTEN_ANGLE=0;          Mc_Para.max.u16MC_FREE_FASTEN_ANGLE=20000;      //SET[09] : degree
      Mc_Para.dft.u16MC_FREE_FASTEN_SPEED=0;          Mc_Para.min.u16MC_FREE_FASTEN_SPEED=0;          Mc_Para.max.u16MC_FREE_FASTEN_SPEED=1000;       //SET[10] : 
      Mc_Para.dft.u16MC_SOFT_START=100;               Mc_Para.min.u16MC_SOFT_START=0;                 Mc_Para.max.u16MC_SOFT_START=300;               //SET[11] : 
      Mc_Para.dft.u16MC_FASTEN_SEATTING_POINT_RATE=40;Mc_Para.min.u16MC_FASTEN_SEATTING_POINT_RATE=10;Mc_Para.max.u16MC_FASTEN_SEATTING_POINT_RATE=95;//SET[12] : %
      Mc_Para.dft.u16MC_FASTEN_TQ_RISING_TIME=50;     Mc_Para.min.u16MC_FASTEN_TQ_RISING_TIME=50;     Mc_Para.max.u16MC_FASTEN_TQ_RISING_TIME=200;    //SET[13] : ms
      Mc_Para.dft.u16MC_RAMP_UP_SPEED=0;              Mc_Para.min.u16MC_RAMP_UP_SPEED=0;              Mc_Para.max.u16MC_RAMP_UP_SPEED=1;              //SET[14] : speed[RPM]
      Mc_Para.dft.u16MC_TORQUE_COMPENSATION=0;        Mc_Para.min.u16MC_TORQUE_COMPENSATION=0;        Mc_Para.max.u16MC_TORQUE_COMPENSATION=1;        //SET[15] : 
      Mc_Para.dft.u16MC_TORQUE_OFFSET=0;              Mc_Para.min.u16MC_TORQUE_OFFSET=0;              Mc_Para.max.u16MC_TORQUE_OFFSET=20000;          //SET[16] : 
      Mc_Para.dft.u16MC_MAX_PULSE_COUNT=0;            Mc_Para.min.u16MC_MAX_PULSE_COUNT=0;            Mc_Para.max.u16MC_MAX_PULSE_COUNT=20000;        //SET[17] : 
      
      Mc_Para.dft.u16MC_ADVANCED_MODE=0;              Mc_Para.min.u16MC_ADVANCED_MODE=0;              Mc_Para.max.u16MC_ADVANCED_MODE=10;                   //SET[0] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA1=0;             Mc_Para.min.f32MC_ADVANCED_PARA1=0;             Mc_Para.max.f32MC_ADVANCED_PARA1=0xffff;              //SET[1] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA2=0;             Mc_Para.min.f32MC_ADVANCED_PARA2=0;             Mc_Para.max.f32MC_ADVANCED_PARA2=0xffff;              //SET[2] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA3=0;             Mc_Para.min.f32MC_ADVANCED_PARA3=0;             Mc_Para.max.f32MC_ADVANCED_PARA3=0xffff;              //SET[3] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA4=0;             Mc_Para.min.f32MC_ADVANCED_PARA4=0;             Mc_Para.max.f32MC_ADVANCED_PARA4=0xffff;              //SET[4] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA5=0;             Mc_Para.min.f32MC_ADVANCED_PARA5=0;             Mc_Para.max.f32MC_ADVANCED_PARA5=0xffff;              //SET[5] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA6=0;             Mc_Para.min.f32MC_ADVANCED_PARA6=0;             Mc_Para.max.f32MC_ADVANCED_PARA6=0xffff;              //SET[6] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA7=0;             Mc_Para.min.f32MC_ADVANCED_PARA7=0;             Mc_Para.max.f32MC_ADVANCED_PARA7=0xffff;              //SET[7] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA8=0;             Mc_Para.min.f32MC_ADVANCED_PARA8=0;             Mc_Para.max.f32MC_ADVANCED_PARA8=0xffff;              //SET[8] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA9=0;             Mc_Para.min.f32MC_ADVANCED_PARA9=0;             Mc_Para.max.f32MC_ADVANCED_PARA9=0xffff;              //SET[9] :  
      Mc_Para.dft.f32MC_ADVANCED_PARA10=0;            Mc_Para.min.f32MC_ADVANCED_PARA10=0;            Mc_Para.max.f32MC_ADVANCED_PARA10=0xffff;             //SET[10] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA11=0;            Mc_Para.min.f32MC_ADVANCED_PARA11=0;            Mc_Para.max.f32MC_ADVANCED_PARA11=0xffff;             //SET[11] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA12=0;            Mc_Para.min.f32MC_ADVANCED_PARA12=0;            Mc_Para.max.f32MC_ADVANCED_PARA12=0xffff;             //SET[12] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA13=0;            Mc_Para.min.f32MC_ADVANCED_PARA13=0;            Mc_Para.max.f32MC_ADVANCED_PARA13=0xffff;             //SET[13] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA14=0;            Mc_Para.min.f32MC_ADVANCED_PARA14=0;            Mc_Para.max.f32MC_ADVANCED_PARA14=0xffff;             //SET[14] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA15=0;            Mc_Para.min.f32MC_ADVANCED_PARA15=0;            Mc_Para.max.f32MC_ADVANCED_PARA15=0xffff;             //SET[15] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA16=0;            Mc_Para.min.f32MC_ADVANCED_PARA16=0;            Mc_Para.max.f32MC_ADVANCED_PARA16=0xffff;             //SET[16] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA17=0;            Mc_Para.min.f32MC_ADVANCED_PARA17=0;            Mc_Para.max.f32MC_ADVANCED_PARA17=0xffff;             //SET[17] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA18=0;            Mc_Para.min.f32MC_ADVANCED_PARA18=0;            Mc_Para.max.f32MC_ADVANCED_PARA18=0xffff;             //SET[18] : 
      Mc_Para.dft.f32MC_ADVANCED_PARA19=0;            Mc_Para.min.f32MC_ADVANCED_PARA19=0;            Mc_Para.max.f32MC_ADVANCED_PARA19=0xffff;             //SET[19] : 
      Mc_Para.dft.u16MC_FREE_REVERSE_ROTATION_SPEED=0;Mc_Para.min.u16MC_FREE_REVERSE_ROTATION_SPEED=0;Mc_Para.max.u16MC_FREE_REVERSE_ROTATION_SPEED=1000;   //SET[1] :  
      Mc_Para.dft.f32MC_FREE_REVERSE_ROTATION_ANGLE=0;Mc_Para.min.f32MC_FREE_REVERSE_ROTATION_ANGLE=0;Mc_Para.max.f32MC_FREE_REVERSE_ROTATION_ANGLE=200;    //SET[2] :  
      Mc_Para.dft.u16MC_REVERS_ANGLE_SETTING_SPEED=0; Mc_Para.min.u16MC_REVERS_ANGLE_SETTING_SPEED=0; Mc_Para.max.u16MC_REVERS_ANGLE_SETTING_SPEED=1000;    //SET[3] :  
      Mc_Para.dft.u16MC_REVERS_ANGLE_SETTING_ANGLE=0; Mc_Para.min.u16MC_REVERS_ANGLE_SETTING_ANGLE=0; Mc_Para.max.u16MC_REVERS_ANGLE_SETTING_ANGLE=30000;   //SET[4] :  
      Mc_Para.dft.u16MC_REVERS_ANGLE_SETTING_FW_REV=0;Mc_Para.min.u16MC_REVERS_ANGLE_SETTING_FW_REV=0;Mc_Para.max.u16MC_REVERS_ANGLE_SETTING_FW_REV=1;      //SET[5] :  
      
      Mc_Para.dft.u16MC_DRIVER_MODEL=2;               Mc_Para.min.u16MC_DRIVER_MODEL=1;               Mc_Para.max.u16MC_DRIVER_MODEL=99;                //SET[0] :  
      Mc_Para.dft.u16MC_UNIT=2;                       Mc_Para.min.u16MC_UNIT=0;                       Mc_Para.max.u16MC_UNIT=6;                         //SET[1] :  
      Mc_Para.dft.u16MC_ACC_DEC_TIME=100;             Mc_Para.min.u16MC_ACC_DEC_TIME=10;              Mc_Para.max.u16MC_ACC_DEC_TIME=1000;              //SET[2] :  
      Mc_Para.dft.u16MC_FASTEN_TORQUE_MAINTAIN_TIME=2;Mc_Para.min.u16MC_FASTEN_TORQUE_MAINTAIN_TIME=1;Mc_Para.max.u16MC_FASTEN_TORQUE_MAINTAIN_TIME=20; //SET[3] :  
      Mc_Para.dft.u16MC_USE_MAXTQ_FOR_LOOSENING=0;    Mc_Para.min.u16MC_USE_MAXTQ_FOR_LOOSENING=0;    Mc_Para.max.u16MC_USE_MAXTQ_FOR_LOOSENING=1;      //SET[4] :  
      Mc_Para.dft.u16MC_LOOSENING_SPEED=500;          Mc_Para.min.u16MC_LOOSENING_SPEED=100;          Mc_Para.max.u16MC_LOOSENING_SPEED=1000;           //SET[5] :  
      Mc_Para.dft.f32MC_TOTAL_FASTENING_TIME=100;     Mc_Para.min.f32MC_TOTAL_FASTENING_TIME=0;       Mc_Para.max.f32MC_TOTAL_FASTENING_TIME=600;       //SET[6] :  
      Mc_Para.dft.f32MC_TOTAL_LOOSENING_TIME=100;     Mc_Para.min.f32MC_TOTAL_LOOSENING_TIME=0;       Mc_Para.max.f32MC_TOTAL_LOOSENING_TIME=600;       //SET[7] :  
      Mc_Para.dft.f32MC_INIT_LOOSENING_TIME_LIMIT=2;  Mc_Para.min.f32MC_INIT_LOOSENING_TIME_LIMIT=1;  Mc_Para.max.f32MC_INIT_LOOSENING_TIME_LIMIT=5;    //SET[8] :  
      Mc_Para.dft.u16MC_SCREW_TYPE=0;                 Mc_Para.min.u16MC_SCREW_TYPE=0;                 Mc_Para.max.u16MC_SCREW_TYPE=0x7fff;              //SET[9] :  
      Mc_Para.dft.f32MC_JUDGE_FASTEN_MIN_TURNS=0;     Mc_Para.min.f32MC_JUDGE_FASTEN_MIN_TURNS=0;     Mc_Para.max.f32MC_JUDGE_FASTEN_MIN_TURNS=50;      //SET[10] : 
      Mc_Para.dft.u16MC_FASTENING_STOP_ALARM=0;       Mc_Para.min.u16MC_FASTENING_STOP_ALARM=0;       Mc_Para.max.u16MC_FASTENING_STOP_ALARM=1;         //SET[11] : 
      Mc_Para.dft.u16MC_TORQUE_COMPENSATION_MAIN=100; Mc_Para.min.u16MC_TORQUE_COMPENSATION_MAIN=90;  Mc_Para.max.u16MC_TORQUE_COMPENSATION_MAIN=110;   //SET[12] : 
      Mc_Para.dft.u16MC_CROWFOOT_ENABLE=0;            Mc_Para.min.u16MC_CROWFOOT_ENABLE=0;            Mc_Para.max.u16MC_CROWFOOT_ENABLE=1;              //SET[13] : 
      Mc_Para.dft.f32MC_CROWFOOT_RATIO=1000;          Mc_Para.min.f32MC_CROWFOOT_RATIO=0;             Mc_Para.max.f32MC_CROWFOOT_RATIO=65000;           //SET[14] : 
      Mc_Para.dft.u16MC_CROWFOOT_EFFICIENCY=100;      Mc_Para.min.u16MC_CROWFOOT_EFFICIENCY=0;        Mc_Para.max.u16MC_CROWFOOT_EFFICIENCY=300;        //SET[15] : 
      Mc_Para.dft.f32MC_CROWFOOT_REVERSE_TORQUE=0;    Mc_Para.min.f32MC_CROWFOOT_REVERSE_TORQUE=0;    Mc_Para.max.f32MC_CROWFOOT_REVERSE_TORQUE=500;    //SET[16] : 
      Mc_Para.dft.u16MC_CROWFOOT_REVERSE_SPEED=50;    Mc_Para.min.u16MC_CROWFOOT_REVERSE_SPEED=0;     Mc_Para.max.u16MC_CROWFOOT_REVERSE_SPEED=100;     //SET[17] : 

      Mc_Para.val.u16MC_ZERO_DUMMY = 0;     //0
      Mc_Para.val.u16MC_TCAM_ACTM = 1;      //1
      Mc_Para.val.f32MC_FASTEN_TORQUE = 10; //2
      Mc_Para.val.f32MC_TORQUE_MIN_MAX = 0; //3
      Mc_Para.val.u16MC_TARGET_ANGLE = 720;   //4
      Mc_Para.val.u16MC_FASTEN_MIN_ANGLE = 0; //5
      Mc_Para.val.u16MC_FASTEN_MAX_ANGLE = 0; //6
      Mc_Para.val.f32MC_SNUG_TORQUE = 0;      //7
      Mc_Para.val.u16MC_FASTEN_SPEED = 50;     //8
      Mc_Para.val.u16MC_FREE_FASTEN_ANGLE = 0;  //9
      Mc_Para.val.u16MC_FREE_FASTEN_SPEED = 0;  //10
      Mc_Para.val.u16MC_SOFT_START = 300;         //11
      Mc_Para.val.u16MC_FASTEN_SEATTING_POINT_RATE = 70; //12
      Mc_Para.val.u16MC_FASTEN_TQ_RISING_TIME = 50;      //13
      Mc_Para.val.u16MC_RAMP_UP_SPEED = 100;              //14
      Mc_Para.val.u16MC_TORQUE_COMPENSATION = 100;        //15
      Mc_Para.val.u16MC_TORQUE_OFFSET = 10;              //16
      Mc_Para.val.u16MC_MAX_PULSE_COUNT = 100;            //17

      Mc_Para.val.u16MC_ADVANCED_MODE = 0;              //0
      Mc_Para.val.f32MC_ADVANCED_PARA1 = 0;             //1
      Mc_Para.val.f32MC_ADVANCED_PARA2 = 0;             //2
      Mc_Para.val.f32MC_ADVANCED_PARA3 = 0;             //3
      Mc_Para.val.f32MC_ADVANCED_PARA4 = 0;             //4
      Mc_Para.val.f32MC_ADVANCED_PARA5 = 0;             //5
      Mc_Para.val.f32MC_ADVANCED_PARA6 = 0;             //6
      Mc_Para.val.f32MC_ADVANCED_PARA7 = 0;             //7
      Mc_Para.val.f32MC_ADVANCED_PARA8 = 0;             //8
      Mc_Para.val.f32MC_ADVANCED_PARA9 = 0;             //9
      Mc_Para.val.f32MC_ADVANCED_PARA10 = 0;             //10
      Mc_Para.val.f32MC_ADVANCED_PARA11 = 0;             //11
      Mc_Para.val.f32MC_ADVANCED_PARA12 = 0;             //12
      Mc_Para.val.f32MC_ADVANCED_PARA13 = 0;             //13
      Mc_Para.val.f32MC_ADVANCED_PARA14 = 0;             //14
      Mc_Para.val.f32MC_ADVANCED_PARA15 = 0;             //15
      Mc_Para.val.f32MC_ADVANCED_PARA16 = 0;             //16
      Mc_Para.val.f32MC_ADVANCED_PARA17 = 0;             //17
      Mc_Para.val.f32MC_ADVANCED_PARA18 = 0;             //18
      Mc_Para.val.f32MC_ADVANCED_PARA19 = 0;             //19
      Mc_Para.val.u16MC_FREE_REVERSE_ROTATION_SPEED = 0;             //1
      Mc_Para.val.f32MC_FREE_REVERSE_ROTATION_ANGLE = 0;             //2
      Mc_Para.val.u16MC_REVERS_ANGLE_SETTING_SPEED = 0;             //3
      Mc_Para.val.u16MC_REVERS_ANGLE_SETTING_ANGLE = 0;             //4
      Mc_Para.val.u16MC_REVERS_ANGLE_SETTING_FW_REV = 0;             //5

      Mc_Para.val.u16MC_DRIVER_MODEL = 1;                 //0
      Mc_Para.val.u16MC_UNIT = 2;                         //1
      Mc_Para.val.u16MC_ACC_DEC_TIME = 500;                 //2
      Mc_Para.val.u16MC_FASTEN_TORQUE_MAINTAIN_TIME = 0;  //3
      Mc_Para.val.u16MC_USE_MAXTQ_FOR_LOOSENING = 0;      //4
      Mc_Para.val.u16MC_LOOSENING_SPEED = 700;              //5
      Mc_Para.val.f32MC_TOTAL_FASTENING_TIME = 10;         //6
      Mc_Para.val.f32MC_TOTAL_LOOSENING_TIME = 10;         //7
      Mc_Para.val.f32MC_INIT_LOOSENING_TIME_LIMIT = 0.2f;    //8
      Mc_Para.val.u16MC_SCREW_TYPE = 0;                   //9
      Mc_Para.val.f32MC_JUDGE_FASTEN_MIN_TURNS = 0;       //10
      Mc_Para.val.u16MC_FASTENING_STOP_ALARM = 0;         //11
      Mc_Para.val.u16MC_TORQUE_COMPENSATION_MAIN = 100;     //12
      Mc_Para.val.u16MC_CROWFOOT_ENABLE = 0;              //13
      Mc_Para.val.f32MC_CROWFOOT_RATIO = 10;               //14
      Mc_Para.val.u16MC_CROWFOOT_EFFICIENCY = 100;          //15
      Mc_Para.val.f32MC_CROWFOOT_REVERSE_TORQUE = 50;      //16
      Mc_Para.val.u16MC_CROWFOOT_REVERSE_SPEED = 0;       //17
    }
  }
}