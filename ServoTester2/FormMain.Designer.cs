
namespace ServoTester2
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox7;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label29;
            this.btRefresh = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.tbBaudrate = new System.Windows.Forms.ComboBox();
            this.tbPorts = new System.Windows.Forms.ComboBox();
            this.tbSpeedFFgain = new System.Windows.Forms.NumericUpDown();
            this.tbSpeedIgain = new System.Windows.Forms.NumericUpDown();
            this.tbSpeedPgain = new System.Windows.Forms.NumericUpDown();
            this.tbTorqueFFgain = new System.Windows.Forms.NumericUpDown();
            this.tbTorqueIgain = new System.Windows.Forms.NumericUpDown();
            this.tbTorquePgain = new System.Windows.Forms.NumericUpDown();
            this.tbDelayTime = new System.Windows.Forms.NumericUpDown();
            this.tbStopSlopTime = new System.Windows.Forms.NumericUpDown();
            this.tbContinuousTime = new System.Windows.Forms.NumericUpDown();
            this.tbStartSlopTime = new System.Windows.Forms.NumericUpDown();
            this.tbMovingMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.tbMovingMaxTorque = new System.Windows.Forms.NumericUpDown();
            this.tbMoveState = new System.Windows.Forms.ComboBox();
            this.tbSpeedCmd = new System.Windows.Forms.NumericUpDown();
            this.tbTorqueCmd = new System.Windows.Forms.NumericUpDown();
            this.tbMode = new System.Windows.Forms.ComboBox();
            this.tbState = new System.Windows.Forms.CheckBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.tbOn = new System.Windows.Forms.RadioButton();
            this.tbOff = new System.Windows.Forms.RadioButton();
            this.tbCalibUserStop = new System.Windows.Forms.RadioButton();
            this.tbCalibFail = new System.Windows.Forms.RadioButton();
            this.tbCalibSuccess = new System.Windows.Forms.RadioButton();
            this.tbFinish = new System.Windows.Forms.RadioButton();
            this.tbBackward = new System.Windows.Forms.RadioButton();
            this.tbForward = new System.Windows.Forms.RadioButton();
            this.tbHold = new System.Windows.Forms.RadioButton();
            this.tbNone = new System.Windows.Forms.RadioButton();
            this.tbTqOffsetValue = new System.Windows.Forms.TextBox();
            this.tbTqSensorValue = new System.Windows.Forms.TextBox();
            this.btTqOffsetSave = new System.Windows.Forms.Button();
            this.btTqOffsetCheck = new System.Windows.Forms.Button();
            this.workTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btCalibStart = new System.Windows.Forms.Button();
            this.btCalibStop = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbAckMessage = new System.Windows.Forms.TextBox();
            this.btAlarmReset = new System.Windows.Forms.Button();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbMaintCnt = new System.Windows.Forms.TextBox();
            this.btMcInit = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbLoosenAngle = new System.Windows.Forms.TextBox();
            this.btFastenLoosen = new System.Windows.Forms.Button();
            this.btStartStopFL = new System.Windows.Forms.Button();
            this.tbEnc = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbStopAutocustom = new System.Windows.Forms.RadioButton();
            this.rbStartAutocustom = new System.Windows.Forms.RadioButton();
            this.btStartStopAutocustom = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rbHardAutocustom = new System.Windows.Forms.RadioButton();
            this.btSoftHardAutocustom = new System.Windows.Forms.Button();
            this.rbSoftAutocustom = new System.Windows.Forms.RadioButton();
            this.tbFreeAngle = new System.Windows.Forms.TextBox();
            this.tbFreeSpeed = new System.Windows.Forms.TextBox();
            this.tbSeatingPoint = new System.Windows.Forms.TextBox();
            this.tbTargetSpeed = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btStartOrigin = new System.Windows.Forms.Button();
            this.btSaveOrigin = new System.Windows.Forms.Button();
            this.btResetMc = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label15 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox7 = new System.Windows.Forms.GroupBox();
            label23 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedFFgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedIgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedPgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueFFgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueIgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorquePgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStopSlopTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContinuousTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStartSlopTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMovingMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMovingMaxTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueCmd)).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.btRefresh);
            groupBox1.Controls.Add(this.btOpen);
            groupBox1.Controls.Add(this.tbBaudrate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(this.tbPorts);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(232, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection setting";
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(148, 19);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(79, 23);
            this.btRefresh.TabIndex = 5;
            this.btRefresh.Text = "Port refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(148, 51);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(79, 23);
            this.btOpen.TabIndex = 4;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // tbBaudrate
            // 
            this.tbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbBaudrate.FormattingEnabled = true;
            this.tbBaudrate.ItemHeight = 12;
            this.tbBaudrate.Items.AddRange(new object[] {
            "921600",
            "460800",
            "230400",
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
            this.tbBaudrate.Location = new System.Drawing.Point(61, 53);
            this.tbBaudrate.Name = "tbBaudrate";
            this.tbBaudrate.Size = new System.Drawing.Size(82, 20);
            this.tbBaudrate.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 12);
            label2.TabIndex = 2;
            label2.Text = "Baudrate";
            // 
            // tbPorts
            // 
            this.tbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbPorts.FormattingEnabled = true;
            this.tbPorts.Location = new System.Drawing.Point(61, 21);
            this.tbPorts.Name = "tbPorts";
            this.tbPorts.Size = new System.Drawing.Size(82, 20);
            this.tbPorts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 12);
            label1.TabIndex = 0;
            label1.Text = "Port";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.tbSpeedFFgain);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(this.tbSpeedIgain);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(this.tbSpeedPgain);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(this.tbTorqueFFgain);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(this.tbTorqueIgain);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(this.tbTorquePgain);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(this.tbDelayTime);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(this.tbStopSlopTime);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(this.tbContinuousTime);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(this.tbStartSlopTime);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(this.tbMovingMaxSpeed);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(this.tbMovingMaxTorque);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(this.tbMoveState);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(this.tbSpeedCmd);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(this.tbTorqueCmd);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(this.tbMode);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(this.tbState);
            groupBox2.Controls.Add(this.btRun);
            groupBox2.Controls.Add(this.btStop);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(this.tbOn);
            groupBox2.Controls.Add(this.tbOff);
            groupBox2.Location = new System.Drawing.Point(12, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(560, 281);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Servo motor";
            // 
            // tbSpeedFFgain
            // 
            this.tbSpeedFFgain.Location = new System.Drawing.Point(408, 239);
            this.tbSpeedFFgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbSpeedFFgain.Name = "tbSpeedFFgain";
            this.tbSpeedFFgain.Size = new System.Drawing.Size(89, 21);
            this.tbSpeedFFgain.TabIndex = 40;
            this.tbSpeedFFgain.Tag = "17";
            this.tbSpeedFFgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(285, 241);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(87, 12);
            label15.TabIndex = 39;
            label15.Text = "Speed FF gain";
            // 
            // tbSpeedIgain
            // 
            this.tbSpeedIgain.Location = new System.Drawing.Point(408, 212);
            this.tbSpeedIgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbSpeedIgain.Name = "tbSpeedIgain";
            this.tbSpeedIgain.Size = new System.Drawing.Size(89, 21);
            this.tbSpeedIgain.TabIndex = 38;
            this.tbSpeedIgain.Tag = "16";
            this.tbSpeedIgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(285, 214);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(76, 12);
            label19.TabIndex = 37;
            label19.Text = "Speed I gain";
            // 
            // tbSpeedPgain
            // 
            this.tbSpeedPgain.Location = new System.Drawing.Point(408, 185);
            this.tbSpeedPgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbSpeedPgain.Name = "tbSpeedPgain";
            this.tbSpeedPgain.Size = new System.Drawing.Size(89, 21);
            this.tbSpeedPgain.TabIndex = 36;
            this.tbSpeedPgain.Tag = "15";
            this.tbSpeedPgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(285, 187);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(81, 12);
            label20.TabIndex = 35;
            label20.Text = "Speed P gain";
            // 
            // tbTorqueFFgain
            // 
            this.tbTorqueFFgain.Location = new System.Drawing.Point(408, 158);
            this.tbTorqueFFgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbTorqueFFgain.Name = "tbTorqueFFgain";
            this.tbTorqueFFgain.Size = new System.Drawing.Size(89, 21);
            this.tbTorqueFFgain.TabIndex = 34;
            this.tbTorqueFFgain.Tag = "14";
            this.tbTorqueFFgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(285, 160);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(91, 12);
            label16.TabIndex = 33;
            label16.Text = "Torque FF gain";
            // 
            // tbTorqueIgain
            // 
            this.tbTorqueIgain.Location = new System.Drawing.Point(408, 131);
            this.tbTorqueIgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbTorqueIgain.Name = "tbTorqueIgain";
            this.tbTorqueIgain.Size = new System.Drawing.Size(89, 21);
            this.tbTorqueIgain.TabIndex = 32;
            this.tbTorqueIgain.Tag = "13";
            this.tbTorqueIgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(285, 133);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(80, 12);
            label17.TabIndex = 31;
            label17.Text = "Torque I gain";
            // 
            // tbTorquePgain
            // 
            this.tbTorquePgain.Location = new System.Drawing.Point(408, 104);
            this.tbTorquePgain.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbTorquePgain.Name = "tbTorquePgain";
            this.tbTorquePgain.Size = new System.Drawing.Size(89, 21);
            this.tbTorquePgain.TabIndex = 30;
            this.tbTorquePgain.Tag = "12";
            this.tbTorquePgain.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(285, 106);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(85, 12);
            label18.TabIndex = 29;
            label18.Text = "Torque P gain";
            // 
            // tbDelayTime
            // 
            this.tbDelayTime.Location = new System.Drawing.Point(135, 252);
            this.tbDelayTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbDelayTime.Name = "tbDelayTime";
            this.tbDelayTime.Size = new System.Drawing.Size(89, 21);
            this.tbDelayTime.TabIndex = 28;
            this.tbDelayTime.Tag = "11";
            this.tbDelayTime.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(12, 254);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(65, 12);
            label13.TabIndex = 27;
            label13.Text = "Delay time";
            // 
            // tbStopSlopTime
            // 
            this.tbStopSlopTime.Location = new System.Drawing.Point(135, 225);
            this.tbStopSlopTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbStopSlopTime.Name = "tbStopSlopTime";
            this.tbStopSlopTime.Size = new System.Drawing.Size(89, 21);
            this.tbStopSlopTime.TabIndex = 26;
            this.tbStopSlopTime.Tag = "10";
            this.tbStopSlopTime.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(12, 227);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(86, 12);
            label14.TabIndex = 25;
            label14.Text = "Stop slop time";
            // 
            // tbContinuousTime
            // 
            this.tbContinuousTime.Location = new System.Drawing.Point(135, 198);
            this.tbContinuousTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbContinuousTime.Name = "tbContinuousTime";
            this.tbContinuousTime.Size = new System.Drawing.Size(89, 21);
            this.tbContinuousTime.TabIndex = 24;
            this.tbContinuousTime.Tag = "9";
            this.tbContinuousTime.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(12, 200);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(97, 12);
            label12.TabIndex = 23;
            label12.Text = "Continuous time";
            // 
            // tbStartSlopTime
            // 
            this.tbStartSlopTime.Location = new System.Drawing.Point(135, 171);
            this.tbStartSlopTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbStartSlopTime.Name = "tbStartSlopTime";
            this.tbStartSlopTime.Size = new System.Drawing.Size(89, 21);
            this.tbStartSlopTime.TabIndex = 22;
            this.tbStartSlopTime.Tag = "8";
            this.tbStartSlopTime.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(12, 173);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(86, 12);
            label11.TabIndex = 21;
            label11.Text = "Start slop time";
            // 
            // tbMovingMaxSpeed
            // 
            this.tbMovingMaxSpeed.Location = new System.Drawing.Point(135, 144);
            this.tbMovingMaxSpeed.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.tbMovingMaxSpeed.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.tbMovingMaxSpeed.Name = "tbMovingMaxSpeed";
            this.tbMovingMaxSpeed.Size = new System.Drawing.Size(89, 21);
            this.tbMovingMaxSpeed.TabIndex = 20;
            this.tbMovingMaxSpeed.Tag = "7";
            this.tbMovingMaxSpeed.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 146);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(114, 12);
            label10.TabIndex = 19;
            label10.Text = "Moving max speed";
            // 
            // tbMovingMaxTorque
            // 
            this.tbMovingMaxTorque.Location = new System.Drawing.Point(135, 117);
            this.tbMovingMaxTorque.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.tbMovingMaxTorque.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.tbMovingMaxTorque.Name = "tbMovingMaxTorque";
            this.tbMovingMaxTorque.Size = new System.Drawing.Size(89, 21);
            this.tbMovingMaxTorque.TabIndex = 18;
            this.tbMovingMaxTorque.Tag = "6";
            this.tbMovingMaxTorque.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(12, 119);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(114, 12);
            label9.TabIndex = 17;
            label9.Text = "Moving max torque";
            // 
            // tbMoveState
            // 
            this.tbMoveState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbMoveState.FormattingEnabled = true;
            this.tbMoveState.Items.AddRange(new object[] {
            "Stop moving",
            "Start to move",
            "Start to move  repeatedly"});
            this.tbMoveState.Location = new System.Drawing.Point(135, 91);
            this.tbMoveState.Name = "tbMoveState";
            this.tbMoveState.Size = new System.Drawing.Size(89, 20);
            this.tbMoveState.TabIndex = 16;
            this.tbMoveState.Tag = "5";
            this.tbMoveState.SelectedValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(12, 94);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(67, 12);
            label8.TabIndex = 15;
            label8.Text = "Move state";
            // 
            // tbSpeedCmd
            // 
            this.tbSpeedCmd.Location = new System.Drawing.Point(457, 67);
            this.tbSpeedCmd.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.tbSpeedCmd.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.tbSpeedCmd.Name = "tbSpeedCmd";
            this.tbSpeedCmd.Size = new System.Drawing.Size(89, 21);
            this.tbSpeedCmd.TabIndex = 14;
            this.tbSpeedCmd.Tag = "4";
            this.tbSpeedCmd.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(343, 69);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(102, 12);
            label7.TabIndex = 13;
            label7.Text = "Speed command";
            // 
            // tbTorqueCmd
            // 
            this.tbTorqueCmd.Location = new System.Drawing.Point(457, 40);
            this.tbTorqueCmd.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.tbTorqueCmd.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.tbTorqueCmd.Name = "tbTorqueCmd";
            this.tbTorqueCmd.Size = new System.Drawing.Size(89, 21);
            this.tbTorqueCmd.TabIndex = 12;
            this.tbTorqueCmd.Tag = "3";
            this.tbTorqueCmd.ValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(343, 42);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(106, 12);
            label6.TabIndex = 11;
            label6.Text = "Torque command";
            // 
            // tbMode
            // 
            this.tbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbMode.FormattingEnabled = true;
            this.tbMode.Items.AddRange(new object[] {
            "Torque",
            "Speed"});
            this.tbMode.Location = new System.Drawing.Point(457, 14);
            this.tbMode.Name = "tbMode";
            this.tbMode.Size = new System.Drawing.Size(89, 20);
            this.tbMode.TabIndex = 10;
            this.tbMode.Tag = "2";
            this.tbMode.SelectedValueChanged += new System.EventHandler(this.tbSet_ValueChanged);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(345, 17);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 12);
            label5.TabIndex = 9;
            label5.Text = "모드 변경";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 63);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 12);
            label4.TabIndex = 8;
            label4.Text = "구동 상태 변경";
            // 
            // tbState
            // 
            this.tbState.AutoSize = true;
            this.tbState.Enabled = false;
            this.tbState.Location = new System.Drawing.Point(228, 23);
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(70, 16);
            this.tbState.TabIndex = 7;
            this.tbState.Text = "Request";
            this.tbState.UseVisualStyleBackColor = true;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(211, 59);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(94, 18);
            this.btRun.TabIndex = 6;
            this.btRun.Text = "RUN";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btMotor_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(111, 59);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(94, 18);
            this.btStop.TabIndex = 5;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btMotor_Click);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 26);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 12);
            label3.TabIndex = 3;
            label3.Text = "구동 상태";
            // 
            // tbOn
            // 
            this.tbOn.AutoSize = true;
            this.tbOn.Cursor = System.Windows.Forms.Cursors.No;
            this.tbOn.Location = new System.Drawing.Point(136, 24);
            this.tbOn.Name = "tbOn";
            this.tbOn.Size = new System.Drawing.Size(41, 16);
            this.tbOn.TabIndex = 1;
            this.tbOn.Text = "ON";
            this.tbOn.UseVisualStyleBackColor = true;
            // 
            // tbOff
            // 
            this.tbOff.AutoSize = true;
            this.tbOff.Checked = true;
            this.tbOff.Cursor = System.Windows.Forms.Cursors.No;
            this.tbOff.Location = new System.Drawing.Point(84, 24);
            this.tbOff.Name = "tbOff";
            this.tbOff.Size = new System.Drawing.Size(46, 16);
            this.tbOff.TabIndex = 0;
            this.tbOff.TabStop = true;
            this.tbOff.Text = "OFF";
            this.tbOff.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.tbCalibUserStop);
            groupBox3.Controls.Add(this.tbCalibFail);
            groupBox3.Controls.Add(this.tbCalibSuccess);
            groupBox3.Location = new System.Drawing.Point(12, 603);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(256, 45);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Initial Angle Result";
            // 
            // tbCalibUserStop
            // 
            this.tbCalibUserStop.AutoSize = true;
            this.tbCalibUserStop.Cursor = System.Windows.Forms.Cursors.No;
            this.tbCalibUserStop.Location = new System.Drawing.Point(159, 20);
            this.tbCalibUserStop.Name = "tbCalibUserStop";
            this.tbCalibUserStop.Size = new System.Drawing.Size(73, 16);
            this.tbCalibUserStop.TabIndex = 48;
            this.tbCalibUserStop.Text = "Userstop";
            this.tbCalibUserStop.UseVisualStyleBackColor = true;
            // 
            // tbCalibFail
            // 
            this.tbCalibFail.AutoSize = true;
            this.tbCalibFail.Cursor = System.Windows.Forms.Cursors.No;
            this.tbCalibFail.Location = new System.Drawing.Point(103, 20);
            this.tbCalibFail.Name = "tbCalibFail";
            this.tbCalibFail.Size = new System.Drawing.Size(43, 16);
            this.tbCalibFail.TabIndex = 47;
            this.tbCalibFail.Text = "Fail";
            this.tbCalibFail.UseVisualStyleBackColor = true;
            // 
            // tbCalibSuccess
            // 
            this.tbCalibSuccess.AutoSize = true;
            this.tbCalibSuccess.Checked = true;
            this.tbCalibSuccess.Cursor = System.Windows.Forms.Cursors.No;
            this.tbCalibSuccess.Location = new System.Drawing.Point(15, 20);
            this.tbCalibSuccess.Name = "tbCalibSuccess";
            this.tbCalibSuccess.Size = new System.Drawing.Size(73, 16);
            this.tbCalibSuccess.TabIndex = 46;
            this.tbCalibSuccess.TabStop = true;
            this.tbCalibSuccess.Text = "Success";
            this.tbCalibSuccess.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.tbFinish);
            groupBox4.Controls.Add(this.tbBackward);
            groupBox4.Controls.Add(this.tbForward);
            groupBox4.Controls.Add(this.tbHold);
            groupBox4.Controls.Add(this.tbNone);
            groupBox4.Location = new System.Drawing.Point(12, 550);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(347, 47);
            groupBox4.TabIndex = 49;
            groupBox4.TabStop = false;
            groupBox4.Text = "Initial Angle Step";
            // 
            // tbFinish
            // 
            this.tbFinish.AutoSize = true;
            this.tbFinish.Cursor = System.Windows.Forms.Cursors.No;
            this.tbFinish.Location = new System.Drawing.Point(286, 23);
            this.tbFinish.Name = "tbFinish";
            this.tbFinish.Size = new System.Drawing.Size(57, 16);
            this.tbFinish.TabIndex = 45;
            this.tbFinish.Text = "Finish";
            this.tbFinish.UseVisualStyleBackColor = true;
            // 
            // tbBackward
            // 
            this.tbBackward.AutoSize = true;
            this.tbBackward.Cursor = System.Windows.Forms.Cursors.No;
            this.tbBackward.Location = new System.Drawing.Point(205, 23);
            this.tbBackward.Name = "tbBackward";
            this.tbBackward.Size = new System.Drawing.Size(79, 16);
            this.tbBackward.TabIndex = 44;
            this.tbBackward.Text = "Backward";
            this.tbBackward.UseVisualStyleBackColor = true;
            // 
            // tbForward
            // 
            this.tbForward.AutoSize = true;
            this.tbForward.Cursor = System.Windows.Forms.Cursors.No;
            this.tbForward.Location = new System.Drawing.Point(129, 23);
            this.tbForward.Name = "tbForward";
            this.tbForward.Size = new System.Drawing.Size(69, 16);
            this.tbForward.TabIndex = 43;
            this.tbForward.Text = "Forward";
            this.tbForward.UseVisualStyleBackColor = true;
            // 
            // tbHold
            // 
            this.tbHold.AutoSize = true;
            this.tbHold.Cursor = System.Windows.Forms.Cursors.No;
            this.tbHold.Location = new System.Drawing.Point(75, 23);
            this.tbHold.Name = "tbHold";
            this.tbHold.Size = new System.Drawing.Size(48, 16);
            this.tbHold.TabIndex = 42;
            this.tbHold.Text = "Hold";
            this.tbHold.UseVisualStyleBackColor = true;
            // 
            // tbNone
            // 
            this.tbNone.AutoSize = true;
            this.tbNone.Checked = true;
            this.tbNone.Cursor = System.Windows.Forms.Cursors.No;
            this.tbNone.Location = new System.Drawing.Point(16, 23);
            this.tbNone.Name = "tbNone";
            this.tbNone.Size = new System.Drawing.Size(53, 16);
            this.tbNone.TabIndex = 41;
            this.tbNone.TabStop = true;
            this.tbNone.Text = "None";
            this.tbNone.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(this.tbTqOffsetValue);
            groupBox7.Controls.Add(label23);
            groupBox7.Controls.Add(label21);
            groupBox7.Controls.Add(this.tbTqSensorValue);
            groupBox7.Controls.Add(this.btTqOffsetSave);
            groupBox7.Controls.Add(this.btTqOffsetCheck);
            groupBox7.Location = new System.Drawing.Point(249, 12);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(195, 83);
            groupBox7.TabIndex = 6;
            groupBox7.TabStop = false;
            groupBox7.Text = "Torque offset setting";
            // 
            // tbTqOffsetValue
            // 
            this.tbTqOffsetValue.Enabled = false;
            this.tbTqOffsetValue.Location = new System.Drawing.Point(91, 59);
            this.tbTqOffsetValue.Name = "tbTqOffsetValue";
            this.tbTqOffsetValue.Size = new System.Drawing.Size(100, 21);
            this.tbTqOffsetValue.TabIndex = 9;
            this.tbTqOffsetValue.Text = "0";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(6, 63);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(75, 12);
            label23.TabIndex = 8;
            label23.Text = "Offset value:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(6, 40);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(82, 12);
            label21.TabIndex = 6;
            label21.Text = "sensor value:";
            // 
            // tbTqSensorValue
            // 
            this.tbTqSensorValue.Enabled = false;
            this.tbTqSensorValue.Location = new System.Drawing.Point(91, 35);
            this.tbTqSensorValue.Name = "tbTqSensorValue";
            this.tbTqSensorValue.Size = new System.Drawing.Size(100, 21);
            this.tbTqSensorValue.TabIndex = 7;
            this.tbTqSensorValue.Text = "0";
            // 
            // btTqOffsetSave
            // 
            this.btTqOffsetSave.Enabled = false;
            this.btTqOffsetSave.Location = new System.Drawing.Point(102, 16);
            this.btTqOffsetSave.Name = "btTqOffsetSave";
            this.btTqOffsetSave.Size = new System.Drawing.Size(89, 18);
            this.btTqOffsetSave.TabIndex = 6;
            this.btTqOffsetSave.Text = "Save Offset";
            this.btTqOffsetSave.UseVisualStyleBackColor = true;
            this.btTqOffsetSave.Click += new System.EventHandler(this.btTqOffset_Click);
            // 
            // btTqOffsetCheck
            // 
            this.btTqOffsetCheck.Location = new System.Drawing.Point(5, 16);
            this.btTqOffsetCheck.Name = "btTqOffsetCheck";
            this.btTqOffsetCheck.Size = new System.Drawing.Size(94, 18);
            this.btTqOffsetCheck.TabIndex = 5;
            this.btTqOffsetCheck.Text = "Check Offset";
            this.btTqOffsetCheck.UseVisualStyleBackColor = true;
            this.btTqOffsetCheck.Click += new System.EventHandler(this.btTqOffset_Click);
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(12, 101);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(75, 12);
            label22.TabIndex = 8;
            label22.Text = "Error Status:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(259, 101);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(63, 12);
            label24.TabIndex = 52;
            label24.Text = "Maint Cnt:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(436, 103);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(56, 12);
            label25.TabIndex = 55;
            label25.Text = "Encoder:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(6, 95);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(80, 12);
            label26.TabIndex = 41;
            label26.Text = "TartgetSpeed";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(6, 118);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(75, 12);
            label27.TabIndex = 49;
            label27.Text = "SeatingPoint";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(6, 141);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(66, 12);
            label28.TabIndex = 51;
            label28.Text = "FreeSpeed";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(6, 164);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(62, 12);
            label29.TabIndex = 53;
            label29.Text = "FreeAngle";
            // 
            // workTimer
            // 
            this.workTimer.Tick += new System.EventHandler(this.workTimer_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btCalibStart);
            this.groupBox5.Controls.Add(this.btCalibStop);
            this.groupBox5.Location = new System.Drawing.Point(12, 499);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 44);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Initial Angle Start/Stop";
            // 
            // btCalibStart
            // 
            this.btCalibStart.Location = new System.Drawing.Point(127, 15);
            this.btCalibStart.Name = "btCalibStart";
            this.btCalibStart.Size = new System.Drawing.Size(94, 23);
            this.btCalibStart.TabIndex = 7;
            this.btCalibStart.Text = "START";
            this.btCalibStart.UseVisualStyleBackColor = true;
            this.btCalibStart.Click += new System.EventHandler(this.btCalibrationCommand_Click);
            // 
            // btCalibStop
            // 
            this.btCalibStop.Location = new System.Drawing.Point(17, 15);
            this.btCalibStop.Name = "btCalibStop";
            this.btCalibStop.Size = new System.Drawing.Size(94, 23);
            this.btCalibStop.TabIndex = 6;
            this.btCalibStop.Text = "STOP";
            this.btCalibStop.UseVisualStyleBackColor = true;
            this.btCalibStop.Click += new System.EventHandler(this.btCalibrationCommand_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbAckMessage);
            this.groupBox6.Location = new System.Drawing.Point(450, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(130, 41);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ack message";
            // 
            // tbAckMessage
            // 
            this.tbAckMessage.Enabled = false;
            this.tbAckMessage.Location = new System.Drawing.Point(15, 14);
            this.tbAckMessage.Name = "tbAckMessage";
            this.tbAckMessage.Size = new System.Drawing.Size(100, 21);
            this.tbAckMessage.TabIndex = 0;
            this.tbAckMessage.Text = "0";
            // 
            // btAlarmReset
            // 
            this.btAlarmReset.Location = new System.Drawing.Point(143, 96);
            this.btAlarmReset.Name = "btAlarmReset";
            this.btAlarmReset.Size = new System.Drawing.Size(87, 21);
            this.btAlarmReset.TabIndex = 41;
            this.btAlarmReset.Text = "Alarm Reset";
            this.btAlarmReset.UseVisualStyleBackColor = true;
            this.btAlarmReset.Click += new System.EventHandler(this.btAlarmReset_Click);
            // 
            // tbError
            // 
            this.tbError.Enabled = false;
            this.tbError.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbError.Location = new System.Drawing.Point(88, 96);
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(44, 21);
            this.tbError.TabIndex = 8;
            this.tbError.Text = "0";
            // 
            // tbMaintCnt
            // 
            this.tbMaintCnt.Enabled = false;
            this.tbMaintCnt.Location = new System.Drawing.Point(323, 96);
            this.tbMaintCnt.Name = "tbMaintCnt";
            this.tbMaintCnt.Size = new System.Drawing.Size(100, 21);
            this.tbMaintCnt.TabIndex = 53;
            this.tbMaintCnt.Text = "0";
            // 
            // btMcInit
            // 
            this.btMcInit.Location = new System.Drawing.Point(454, 76);
            this.btMcInit.Name = "btMcInit";
            this.btMcInit.Size = new System.Drawing.Size(94, 20);
            this.btMcInit.TabIndex = 54;
            this.btMcInit.Text = "Init MC - No";
            this.btMcInit.UseVisualStyleBackColor = true;
            this.btMcInit.Click += new System.EventHandler(this.btMcInit_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbLoosenAngle);
            this.groupBox8.Controls.Add(this.btFastenLoosen);
            this.groupBox8.Controls.Add(this.btStartStopFL);
            this.groupBox8.Location = new System.Drawing.Point(450, 405);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(134, 59);
            this.groupBox8.TabIndex = 51;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Fasten/Loosen";
            // 
            // tbLoosenAngle
            // 
            this.tbLoosenAngle.Enabled = false;
            this.tbLoosenAngle.Location = new System.Drawing.Point(73, 34);
            this.tbLoosenAngle.Name = "tbLoosenAngle";
            this.tbLoosenAngle.Size = new System.Drawing.Size(53, 21);
            this.tbLoosenAngle.TabIndex = 1;
            this.tbLoosenAngle.Text = "0";
            // 
            // btFastenLoosen
            // 
            this.btFastenLoosen.Location = new System.Drawing.Point(5, 33);
            this.btFastenLoosen.Name = "btFastenLoosen";
            this.btFastenLoosen.Size = new System.Drawing.Size(64, 19);
            this.btFastenLoosen.TabIndex = 7;
            this.btFastenLoosen.Text = "Loosen";
            this.btFastenLoosen.UseVisualStyleBackColor = true;
            this.btFastenLoosen.Click += new System.EventHandler(this.btFastenLoosen_Click);
            // 
            // btStartStopFL
            // 
            this.btStartStopFL.Location = new System.Drawing.Point(5, 16);
            this.btStartStopFL.Name = "btStartStopFL";
            this.btStartStopFL.Size = new System.Drawing.Size(64, 18);
            this.btStartStopFL.TabIndex = 6;
            this.btStartStopFL.Text = "StartFL";
            this.btStartStopFL.UseVisualStyleBackColor = true;
            this.btStartStopFL.Click += new System.EventHandler(this.btStartStopFL_Click);
            // 
            // tbEnc
            // 
            this.tbEnc.Enabled = false;
            this.tbEnc.Location = new System.Drawing.Point(492, 100);
            this.tbEnc.Name = "tbEnc";
            this.tbEnc.Size = new System.Drawing.Size(62, 21);
            this.tbEnc.TabIndex = 56;
            this.tbEnc.Text = "0";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox11);
            this.groupBox9.Controls.Add(label29);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.tbFreeAngle);
            this.groupBox9.Controls.Add(label28);
            this.groupBox9.Controls.Add(this.tbFreeSpeed);
            this.groupBox9.Controls.Add(label27);
            this.groupBox9.Controls.Add(this.tbSeatingPoint);
            this.groupBox9.Controls.Add(label26);
            this.groupBox9.Controls.Add(this.tbTargetSpeed);
            this.groupBox9.Location = new System.Drawing.Point(422, 470);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(161, 188);
            this.groupBox9.TabIndex = 51;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Auto-customize";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rbStopAutocustom);
            this.groupBox11.Controls.Add(this.rbStartAutocustom);
            this.groupBox11.Controls.Add(this.btStartStopAutocustom);
            this.groupBox11.Location = new System.Drawing.Point(7, 52);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(149, 36);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Start/Stop";
            // 
            // rbStopAutocustom
            // 
            this.rbStopAutocustom.AutoSize = true;
            this.rbStopAutocustom.Checked = true;
            this.rbStopAutocustom.Cursor = System.Windows.Forms.Cursors.No;
            this.rbStopAutocustom.Location = new System.Drawing.Point(51, 15);
            this.rbStopAutocustom.Name = "rbStopAutocustom";
            this.rbStopAutocustom.Size = new System.Drawing.Size(48, 16);
            this.rbStopAutocustom.TabIndex = 55;
            this.rbStopAutocustom.TabStop = true;
            this.rbStopAutocustom.Text = "Stop";
            this.rbStopAutocustom.UseVisualStyleBackColor = true;
            // 
            // rbStartAutocustom
            // 
            this.rbStartAutocustom.AutoSize = true;
            this.rbStartAutocustom.Cursor = System.Windows.Forms.Cursors.No;
            this.rbStartAutocustom.Location = new System.Drawing.Point(99, 15);
            this.rbStartAutocustom.Name = "rbStartAutocustom";
            this.rbStartAutocustom.Size = new System.Drawing.Size(48, 16);
            this.rbStartAutocustom.TabIndex = 54;
            this.rbStartAutocustom.Text = "Start";
            this.rbStartAutocustom.UseVisualStyleBackColor = true;
            // 
            // btStartStopAutocustom
            // 
            this.btStartStopAutocustom.Location = new System.Drawing.Point(6, 13);
            this.btStartStopAutocustom.Name = "btStartStopAutocustom";
            this.btStartStopAutocustom.Size = new System.Drawing.Size(39, 19);
            this.btStartStopAutocustom.TabIndex = 7;
            this.btStartStopAutocustom.Text = "Start";
            this.btStartStopAutocustom.UseVisualStyleBackColor = true;
            this.btStartStopAutocustom.Click += new System.EventHandler(this.btStartStopAutocustom_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rbHardAutocustom);
            this.groupBox10.Controls.Add(this.btSoftHardAutocustom);
            this.groupBox10.Controls.Add(this.rbSoftAutocustom);
            this.groupBox10.Location = new System.Drawing.Point(7, 13);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(149, 36);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Soft/Hard";
            // 
            // rbHardAutocustom
            // 
            this.rbHardAutocustom.AutoSize = true;
            this.rbHardAutocustom.Cursor = System.Windows.Forms.Cursors.No;
            this.rbHardAutocustom.Location = new System.Drawing.Point(98, 16);
            this.rbHardAutocustom.Name = "rbHardAutocustom";
            this.rbHardAutocustom.Size = new System.Drawing.Size(49, 16);
            this.rbHardAutocustom.TabIndex = 47;
            this.rbHardAutocustom.Text = "Hard";
            this.rbHardAutocustom.UseVisualStyleBackColor = true;
            // 
            // btSoftHardAutocustom
            // 
            this.btSoftHardAutocustom.Location = new System.Drawing.Point(6, 14);
            this.btSoftHardAutocustom.Name = "btSoftHardAutocustom";
            this.btSoftHardAutocustom.Size = new System.Drawing.Size(39, 19);
            this.btSoftHardAutocustom.TabIndex = 8;
            this.btSoftHardAutocustom.Text = "Hard";
            this.btSoftHardAutocustom.UseVisualStyleBackColor = true;
            this.btSoftHardAutocustom.Click += new System.EventHandler(this.btSoftHardAutocustom_Click);
            // 
            // rbSoftAutocustom
            // 
            this.rbSoftAutocustom.AutoSize = true;
            this.rbSoftAutocustom.Checked = true;
            this.rbSoftAutocustom.Cursor = System.Windows.Forms.Cursors.No;
            this.rbSoftAutocustom.Location = new System.Drawing.Point(51, 16);
            this.rbSoftAutocustom.Name = "rbSoftAutocustom";
            this.rbSoftAutocustom.Size = new System.Drawing.Size(44, 16);
            this.rbSoftAutocustom.TabIndex = 46;
            this.rbSoftAutocustom.TabStop = true;
            this.rbSoftAutocustom.Text = "Soft";
            this.rbSoftAutocustom.UseVisualStyleBackColor = true;
            // 
            // tbFreeAngle
            // 
            this.tbFreeAngle.Enabled = false;
            this.tbFreeAngle.Location = new System.Drawing.Point(90, 160);
            this.tbFreeAngle.Name = "tbFreeAngle";
            this.tbFreeAngle.Size = new System.Drawing.Size(66, 21);
            this.tbFreeAngle.TabIndex = 52;
            this.tbFreeAngle.Text = "0";
            // 
            // tbFreeSpeed
            // 
            this.tbFreeSpeed.Enabled = false;
            this.tbFreeSpeed.Location = new System.Drawing.Point(90, 137);
            this.tbFreeSpeed.Name = "tbFreeSpeed";
            this.tbFreeSpeed.Size = new System.Drawing.Size(66, 21);
            this.tbFreeSpeed.TabIndex = 50;
            this.tbFreeSpeed.Text = "0";
            // 
            // tbSeatingPoint
            // 
            this.tbSeatingPoint.Enabled = false;
            this.tbSeatingPoint.Location = new System.Drawing.Point(90, 114);
            this.tbSeatingPoint.Name = "tbSeatingPoint";
            this.tbSeatingPoint.Size = new System.Drawing.Size(66, 21);
            this.tbSeatingPoint.TabIndex = 48;
            this.tbSeatingPoint.Text = "0";
            // 
            // tbTargetSpeed
            // 
            this.tbTargetSpeed.Enabled = false;
            this.tbTargetSpeed.Location = new System.Drawing.Point(90, 91);
            this.tbTargetSpeed.Name = "tbTargetSpeed";
            this.tbTargetSpeed.Size = new System.Drawing.Size(66, 21);
            this.tbTargetSpeed.TabIndex = 1;
            this.tbTargetSpeed.Text = "0";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btStartOrigin);
            this.groupBox12.Controls.Add(this.btSaveOrigin);
            this.groupBox12.Location = new System.Drawing.Point(305, 405);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(134, 59);
            this.groupBox12.TabIndex = 52;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Origin";
            // 
            // btStartOrigin
            // 
            this.btStartOrigin.Location = new System.Drawing.Point(5, 34);
            this.btStartOrigin.Name = "btStartOrigin";
            this.btStartOrigin.Size = new System.Drawing.Size(74, 19);
            this.btStartOrigin.TabIndex = 7;
            this.btStartOrigin.Text = "StartOrigin";
            this.btStartOrigin.UseVisualStyleBackColor = true;
            this.btStartOrigin.Click += new System.EventHandler(this.btStartOrigin_Click);
            // 
            // btSaveOrigin
            // 
            this.btSaveOrigin.Location = new System.Drawing.Point(5, 16);
            this.btSaveOrigin.Name = "btSaveOrigin";
            this.btSaveOrigin.Size = new System.Drawing.Size(74, 18);
            this.btSaveOrigin.TabIndex = 6;
            this.btSaveOrigin.Text = "SaveOrigin";
            this.btSaveOrigin.UseVisualStyleBackColor = true;
            this.btSaveOrigin.Click += new System.EventHandler(this.btSaveOrigin_Click);
            // 
            // btResetMc
            // 
            this.btResetMc.Location = new System.Drawing.Point(454, 54);
            this.btResetMc.Name = "btResetMc";
            this.btResetMc.Size = new System.Drawing.Size(94, 20);
            this.btResetMc.TabIndex = 57;
            this.btResetMc.Text = "Reset MC";
            this.btResetMc.UseVisualStyleBackColor = true;
            this.btResetMc.Click += new System.EventHandler(this.btResetMC_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 660);
            this.Controls.Add(this.btResetMc);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(label25);
            this.Controls.Add(this.tbEnc);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btMcInit);
            this.Controls.Add(label24);
            this.Controls.Add(this.tbMaintCnt);
            this.Controls.Add(this.btAlarmReset);
            this.Controls.Add(label22);
            this.Controls.Add(groupBox7);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(groupBox4);
            this.Controls.Add(groupBox3);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Servo motor controller v1.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedFFgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedIgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedPgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueFFgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueIgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorquePgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStopSlopTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContinuousTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStartSlopTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMovingMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMovingMaxTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTorqueCmd)).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tbBaudrate;
        private System.Windows.Forms.ComboBox tbPorts;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Timer workTimer;
        private System.Windows.Forms.RadioButton tbOn;
        private System.Windows.Forms.RadioButton tbOff;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.CheckBox tbState;
        private System.Windows.Forms.ComboBox tbMode;
        private System.Windows.Forms.NumericUpDown tbTorqueCmd;
        private System.Windows.Forms.NumericUpDown tbMovingMaxTorque;
        private System.Windows.Forms.ComboBox tbMoveState;
        private System.Windows.Forms.NumericUpDown tbSpeedCmd;
        private System.Windows.Forms.NumericUpDown tbMovingMaxSpeed;
        private System.Windows.Forms.NumericUpDown tbDelayTime;
        private System.Windows.Forms.NumericUpDown tbStopSlopTime;
        private System.Windows.Forms.NumericUpDown tbContinuousTime;
        private System.Windows.Forms.NumericUpDown tbStartSlopTime;
        private System.Windows.Forms.NumericUpDown tbSpeedFFgain;
        private System.Windows.Forms.NumericUpDown tbSpeedIgain;
        private System.Windows.Forms.NumericUpDown tbSpeedPgain;
        private System.Windows.Forms.NumericUpDown tbTorqueFFgain;
        private System.Windows.Forms.NumericUpDown tbTorqueIgain;
        private System.Windows.Forms.NumericUpDown tbTorquePgain;
        private System.Windows.Forms.RadioButton tbCalibUserStop;
        private System.Windows.Forms.RadioButton tbCalibFail;
        private System.Windows.Forms.RadioButton tbCalibSuccess;
        private System.Windows.Forms.RadioButton tbFinish;
        private System.Windows.Forms.RadioButton tbBackward;
        private System.Windows.Forms.RadioButton tbForward;
        private System.Windows.Forms.RadioButton tbHold;
        private System.Windows.Forms.RadioButton tbNone;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btCalibStart;
        private System.Windows.Forms.Button btCalibStop;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbAckMessage;
        private System.Windows.Forms.Button btTqOffsetCheck;
        private System.Windows.Forms.Button btTqOffsetSave;
        private System.Windows.Forms.TextBox tbTqSensorValue;
        private System.Windows.Forms.Button btAlarmReset;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.TextBox tbTqOffsetValue;
        private System.Windows.Forms.TextBox tbMaintCnt;
        private System.Windows.Forms.Button btMcInit;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btFastenLoosen;
        private System.Windows.Forms.Button btStartStopFL;
        private System.Windows.Forms.TextBox tbLoosenAngle;
        private System.Windows.Forms.TextBox tbEnc;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbFreeAngle;
        private System.Windows.Forms.TextBox tbFreeSpeed;
        private System.Windows.Forms.TextBox tbSeatingPoint;
        private System.Windows.Forms.TextBox tbTargetSpeed;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rbHardAutocustom;
        private System.Windows.Forms.Button btSoftHardAutocustom;
        private System.Windows.Forms.RadioButton rbSoftAutocustom;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton rbStopAutocustom;
        private System.Windows.Forms.RadioButton rbStartAutocustom;
        private System.Windows.Forms.Button btStartStopAutocustom;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btStartOrigin;
        private System.Windows.Forms.Button btSaveOrigin;
        private System.Windows.Forms.Button btResetMc;
    }
}

