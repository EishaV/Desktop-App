﻿namespace DesktopApp
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.tpPlan = new System.Windows.Forms.TabPage();
      this.tlPlan = new System.Windows.Forms.TableLayoutPanel();
      this.tlScPerc = new System.Windows.Forms.TableLayoutPanel();
      this.tbCfgScPerc = new System.Windows.Forms.TrackBar();
      this.pbCfgScCorrM3 = new System.Windows.Forms.Button();
      this.pbCfgScCorrP3 = new System.Windows.Forms.Button();
      this.pbCfgScCorrMP = new System.Windows.Forms.Button();
      this.pbCfgScCorrP5 = new System.Windows.Forms.Button();
      this.pbCfgScCorrM5 = new System.Windows.Forms.Button();
      this.dgPlan = new System.Windows.Forms.DataGridView();
      this.chScDow = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.chScCut = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chScBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.chScMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.chScEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lCfgScPerc = new System.Windows.Forms.Label();
      this.lCfgRainDelay = new System.Windows.Forms.Label();
      this.tlCfgScMode = new System.Windows.Forms.TableLayoutPanel();
      this.lCfgSc = new System.Windows.Forms.Label();
      this.txCfgScMode = new System.Windows.Forms.Label();
      this.pbPlanCopy = new System.Windows.Forms.Button();
      this.tlCgRainDelay = new System.Windows.Forms.TableLayoutPanel();
      this.udCfgRainDelay = new System.Windows.Forms.NumericUpDown();
      this.txCfgRainDelay = new System.Windows.Forms.Label();
      this.tlScCmd = new System.Windows.Forms.TableLayoutPanel();
      this.pbPlanSave = new System.Windows.Forms.Button();
      this.tpState = new System.Windows.Forms.TabPage();
      this.tlDat = new System.Windows.Forms.TableLayoutPanel();
      this.tlDatPic = new System.Windows.Forms.TableLayoutPanel();
      this.txDatFW = new System.Windows.Forms.Label();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.lDatFW = new System.Windows.Forms.Label();
      this.picWiFi = new System.Windows.Forms.PictureBox();
      this.txDatRsi = new System.Windows.Forms.Label();
      this.lDatSP = new System.Windows.Forms.Label();
      this.txDatSP = new System.Windows.Forms.Label();
      this.tlName = new System.Windows.Forms.TableLayoutPanel();
      this.txDF = new System.Windows.Forms.Label();
      this.txUS = new System.Windows.Forms.Label();
      this.txName = new System.Windows.Forms.Label();
      this.txRL = new System.Windows.Forms.Label();
      this.tx4G = new System.Windows.Forms.Label();
      this.pDatAccu = new System.Windows.Forms.Panel();
      this.txDatAccu = new System.Windows.Forms.Label();
      this.txDatDT = new System.Windows.Forms.Label();
      this.tlDatTri = new System.Windows.Forms.TableLayoutPanel();
      this.picPitch = new System.Windows.Forms.PictureBox();
      this.picRoll = new System.Windows.Forms.PictureBox();
      this.picYaw = new System.Windows.Forms.PictureBox();
      this.txDatDmp0 = new System.Windows.Forms.Label();
      this.txDatDmp1 = new System.Windows.Forms.Label();
      this.txDatDmp2 = new System.Windows.Forms.Label();
      this.txDatStB = new System.Windows.Forms.Label();
      this.txDatStD = new System.Windows.Forms.Label();
      this.txDatStW = new System.Windows.Forms.Label();
      this.tlDatErrorState = new System.Windows.Forms.TableLayoutPanel();
      this.txError = new System.Windows.Forms.Label();
      this.txStatus = new System.Windows.Forms.Label();
      this.pDatWork = new System.Windows.Forms.Panel();
      this.txDatWork = new System.Windows.Forms.Label();
      this.tlDatCmd = new System.Windows.Forms.TableLayoutPanel();
      this.pbStart = new System.Windows.Forms.Button();
      this.pbPoll = new System.Windows.Forms.Button();
      this.pbHome = new System.Windows.Forms.Button();
      this.pbStop = new System.Windows.Forms.Button();
      this.tpUsr = new System.Windows.Forms.TabPage();
      this.tlpUsrSet = new System.Windows.Forms.TableLayoutPanel();
      this.txUsrMail = new System.Windows.Forms.Label();
      this.edUsrMail = new System.Windows.Forms.TextBox();
      this.txUsrPass = new System.Windows.Forms.Label();
      this.edUsrPass = new System.Windows.Forms.TextBox();
      this.txUsrName = new System.Windows.Forms.Label();
      this.edUsrName = new System.Windows.Forms.TextBox();
      this.txUsrUuid = new System.Windows.Forms.Label();
      this.edUsrUuid = new System.Windows.Forms.TextBox();
      this.cbOnTop = new System.Windows.Forms.CheckBox();
      this.txUsrBroker = new System.Windows.Forms.Label();
      this.edUsrBroker = new System.Windows.Forms.TextBox();
      this.txUsrMac = new System.Windows.Forms.Label();
      this.edUsrMac = new System.Windows.Forms.TextBox();
      this.txUsrBoard = new System.Windows.Forms.Label();
      this.edUsrBoard = new System.Windows.Forms.TextBox();
      this.txUsrApi = new System.Windows.Forms.Label();
      this.cbUsrApi = new System.Windows.Forms.ComboBox();
      this.tlpUsrBtn = new System.Windows.Forms.TableLayoutPanel();
      this.pbLogin = new System.Windows.Forms.Button();
      this.pbTest = new System.Windows.Forms.Button();
      this.pbDisconnect = new System.Windows.Forms.Button();
      this.pbConnect = new System.Windows.Forms.Button();
      this.tcMain = new System.Windows.Forms.TabControl();
      this.tpZone = new System.Windows.Forms.TabPage();
      this.tlZone = new System.Windows.Forms.TableLayoutPanel();
      this.dgZone = new System.Windows.Forms.DataGridView();
      this.chMzStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.chMz0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMz9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.chMzPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.txZoneDist = new System.Windows.Forms.Label();
      this.tlZoneBtn = new System.Windows.Forms.TableLayoutPanel();
      this.pbZoneSave = new System.Windows.Forms.Button();
      this.pbZoneStart = new System.Windows.Forms.Button();
      this.tpAct = new System.Windows.Forms.TabPage();
      this.tlpAct = new System.Windows.Forms.TableLayoutPanel();
      this.pbActCsv = new System.Windows.Forms.Button();
      this.lvActLog = new System.Windows.Forms.ListView();
      this.chActStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chActState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chActError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chActCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chActMiss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.pbActLog = new System.Windows.Forms.Button();
      this.lActHint = new System.Windows.Forms.Label();
      this.tpPlugin = new System.Windows.Forms.TabPage();
      this.spPlugin = new System.Windows.Forms.SplitContainer();
      this.lvPlugin = new System.Windows.Forms.ListView();
      this.chPluginScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chPluginDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.pgPlugin = new System.Windows.Forms.PropertyGrid();
      this.tlPluginBtn = new System.Windows.Forms.TableLayoutPanel();
      this.pbPluginDoit = new System.Windows.Forms.Button();
      this.tpMqtt = new System.Windows.Forms.TabPage();
      this.txMqtt = new System.Windows.Forms.TextBox();
      this.tpTrace = new System.Windows.Forms.TabPage();
      this.rtLog = new System.Windows.Forms.RichTextBox();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.tpPlan.SuspendLayout();
      this.tlPlan.SuspendLayout();
      this.tlScPerc.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbCfgScPerc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgPlan)).BeginInit();
      this.tlCfgScMode.SuspendLayout();
      this.tlCgRainDelay.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.udCfgRainDelay)).BeginInit();
      this.tlScCmd.SuspendLayout();
      this.tpState.SuspendLayout();
      this.tlDat.SuspendLayout();
      this.tlDatPic.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picWiFi)).BeginInit();
      this.tlName.SuspendLayout();
      this.pDatAccu.SuspendLayout();
      this.tlDatTri.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picPitch)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picRoll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picYaw)).BeginInit();
      this.tlDatErrorState.SuspendLayout();
      this.pDatWork.SuspendLayout();
      this.tlDatCmd.SuspendLayout();
      this.tpUsr.SuspendLayout();
      this.tlpUsrSet.SuspendLayout();
      this.tlpUsrBtn.SuspendLayout();
      this.tcMain.SuspendLayout();
      this.tpZone.SuspendLayout();
      this.tlZone.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgZone)).BeginInit();
      this.tlZoneBtn.SuspendLayout();
      this.tpAct.SuspendLayout();
      this.tlpAct.SuspendLayout();
      this.tpPlugin.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spPlugin)).BeginInit();
      this.spPlugin.Panel1.SuspendLayout();
      this.spPlugin.Panel2.SuspendLayout();
      this.spPlugin.SuspendLayout();
      this.tlPluginBtn.SuspendLayout();
      this.tpMqtt.SuspendLayout();
      this.tpTrace.SuspendLayout();
      this.SuspendLayout();
      // 
      // tpPlan
      // 
      this.tpPlan.Controls.Add(this.tlPlan);
      this.tpPlan.Controls.Add(this.tlScCmd);
      this.tpPlan.Location = new System.Drawing.Point(4, 29);
      this.tpPlan.Name = "tpPlan";
      this.tpPlan.Size = new System.Drawing.Size(406, 378);
      this.tpPlan.TabIndex = 5;
      this.tpPlan.Text = "Planer";
      this.tpPlan.UseVisualStyleBackColor = true;
      // 
      // tlPlan
      // 
      this.tlPlan.ColumnCount = 2;
      this.tlPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlPlan.Controls.Add(this.tlScPerc, 1, 1);
      this.tlPlan.Controls.Add(this.dgPlan, 1, 0);
      this.tlPlan.Controls.Add(this.lCfgScPerc, 0, 1);
      this.tlPlan.Controls.Add(this.lCfgRainDelay, 0, 2);
      this.tlPlan.Controls.Add(this.tlCfgScMode, 0, 0);
      this.tlPlan.Controls.Add(this.tlCgRainDelay, 1, 2);
      this.tlPlan.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlPlan.Enabled = false;
      this.tlPlan.Location = new System.Drawing.Point(0, 0);
      this.tlPlan.Margin = new System.Windows.Forms.Padding(0);
      this.tlPlan.Name = "tlPlan";
      this.tlPlan.RowCount = 4;
      this.tlPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
      this.tlPlan.Size = new System.Drawing.Size(406, 348);
      this.tlPlan.TabIndex = 2;
      // 
      // tlScPerc
      // 
      this.tlScPerc.ColumnCount = 9;
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tlScPerc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScPerc.Controls.Add(this.tbCfgScPerc, 0, 0);
      this.tlScPerc.Controls.Add(this.pbCfgScCorrM3, 2, 1);
      this.tlScPerc.Controls.Add(this.pbCfgScCorrP3, 6, 1);
      this.tlScPerc.Controls.Add(this.pbCfgScCorrMP, 4, 1);
      this.tlScPerc.Controls.Add(this.pbCfgScCorrP5, 8, 1);
      this.tlScPerc.Controls.Add(this.pbCfgScCorrM5, 0, 1);
      this.tlScPerc.Dock = System.Windows.Forms.DockStyle.Top;
      this.tlScPerc.Location = new System.Drawing.Point(103, 271);
      this.tlScPerc.Name = "tlScPerc";
      this.tlScPerc.RowCount = 2;
      this.tlScPerc.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlScPerc.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlScPerc.Size = new System.Drawing.Size(300, 40);
      this.tlScPerc.TabIndex = 3;
      // 
      // tbCfgScPerc
      // 
      this.tbCfgScPerc.AutoSize = false;
      this.tbCfgScPerc.BackColor = System.Drawing.SystemColors.Control;
      this.tlScPerc.SetColumnSpan(this.tbCfgScPerc, 9);
      this.tbCfgScPerc.Dock = System.Windows.Forms.DockStyle.Top;
      this.tbCfgScPerc.LargeChange = 10;
      this.tbCfgScPerc.Location = new System.Drawing.Point(0, 0);
      this.tbCfgScPerc.Margin = new System.Windows.Forms.Padding(0);
      this.tbCfgScPerc.Maximum = 100;
      this.tbCfgScPerc.Minimum = -100;
      this.tbCfgScPerc.Name = "tbCfgScPerc";
      this.tbCfgScPerc.Size = new System.Drawing.Size(300, 25);
      this.tbCfgScPerc.TabIndex = 4;
      this.tbCfgScPerc.TickStyle = System.Windows.Forms.TickStyle.None;
      this.toolTip.SetToolTip(this.tbCfgScPerc, "??%");
      this.tbCfgScPerc.ValueChanged += new System.EventHandler(this.tbSchedulePerc_ValueChanged);
      // 
      // pbCfgScCorrM3
      // 
      this.pbCfgScCorrM3.AutoSize = true;
      this.pbCfgScCorrM3.Font = new System.Drawing.Font("Verdana", 1F);
      this.pbCfgScCorrM3.ForeColor = System.Drawing.Color.Transparent;
      this.pbCfgScCorrM3.Location = new System.Drawing.Point(70, 25);
      this.pbCfgScCorrM3.Margin = new System.Windows.Forms.Padding(0);
      this.pbCfgScCorrM3.Name = "pbCfgScCorrM3";
      this.pbCfgScCorrM3.Size = new System.Drawing.Size(20, 12);
      this.pbCfgScCorrM3.TabIndex = 12;
      this.pbCfgScCorrM3.Text = "-50";
      this.toolTip.SetToolTip(this.pbCfgScCorrM3, "-50%");
      this.pbCfgScCorrM3.Click += new System.EventHandler(this.pbCfgScCorrMP_Click);
      // 
      // pbCfgScCorrP3
      // 
      this.pbCfgScCorrP3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pbCfgScCorrP3.AutoSize = true;
      this.pbCfgScCorrP3.Font = new System.Drawing.Font("Verdana", 1F);
      this.pbCfgScCorrP3.ForeColor = System.Drawing.Color.Transparent;
      this.pbCfgScCorrP3.Location = new System.Drawing.Point(210, 25);
      this.pbCfgScCorrP3.Margin = new System.Windows.Forms.Padding(0);
      this.pbCfgScCorrP3.Name = "pbCfgScCorrP3";
      this.pbCfgScCorrP3.Size = new System.Drawing.Size(20, 12);
      this.pbCfgScCorrP3.TabIndex = 14;
      this.pbCfgScCorrP3.Text = "50";
      this.toolTip.SetToolTip(this.pbCfgScCorrP3, "+50%");
      this.pbCfgScCorrP3.Click += new System.EventHandler(this.pbCfgScCorrMP_Click);
      // 
      // pbCfgScCorrMP
      // 
      this.pbCfgScCorrMP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pbCfgScCorrMP.AutoSize = true;
      this.pbCfgScCorrMP.Font = new System.Drawing.Font("Verdana", 1F);
      this.pbCfgScCorrMP.ForeColor = System.Drawing.Color.Transparent;
      this.pbCfgScCorrMP.Location = new System.Drawing.Point(140, 25);
      this.pbCfgScCorrMP.Margin = new System.Windows.Forms.Padding(0);
      this.pbCfgScCorrMP.Name = "pbCfgScCorrMP";
      this.pbCfgScCorrMP.Size = new System.Drawing.Size(20, 12);
      this.pbCfgScCorrMP.TabIndex = 10;
      this.pbCfgScCorrMP.Text = "0";
      this.toolTip.SetToolTip(this.pbCfgScCorrMP, "0%");
      this.pbCfgScCorrMP.Click += new System.EventHandler(this.pbCfgScCorrMP_Click);
      // 
      // pbCfgScCorrP5
      // 
      this.pbCfgScCorrP5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pbCfgScCorrP5.AutoSize = true;
      this.pbCfgScCorrP5.Font = new System.Drawing.Font("Verdana", 1F);
      this.pbCfgScCorrP5.ForeColor = System.Drawing.Color.Transparent;
      this.pbCfgScCorrP5.Location = new System.Drawing.Point(280, 25);
      this.pbCfgScCorrP5.Margin = new System.Windows.Forms.Padding(0);
      this.pbCfgScCorrP5.Name = "pbCfgScCorrP5";
      this.pbCfgScCorrP5.Size = new System.Drawing.Size(20, 12);
      this.pbCfgScCorrP5.TabIndex = 8;
      this.pbCfgScCorrP5.Text = "+100";
      this.toolTip.SetToolTip(this.pbCfgScCorrP5, "+100%");
      this.pbCfgScCorrP5.Click += new System.EventHandler(this.pbCfgScCorrMP_Click);
      // 
      // pbCfgScCorrM5
      // 
      this.pbCfgScCorrM5.AutoSize = true;
      this.pbCfgScCorrM5.Font = new System.Drawing.Font("Verdana", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.pbCfgScCorrM5.ForeColor = System.Drawing.Color.Transparent;
      this.pbCfgScCorrM5.Location = new System.Drawing.Point(0, 25);
      this.pbCfgScCorrM5.Margin = new System.Windows.Forms.Padding(0);
      this.pbCfgScCorrM5.Name = "pbCfgScCorrM5";
      this.pbCfgScCorrM5.Size = new System.Drawing.Size(20, 12);
      this.pbCfgScCorrM5.TabIndex = 7;
      this.pbCfgScCorrM5.Text = "-100";
      this.pbCfgScCorrM5.Click += new System.EventHandler(this.pbCfgScCorrMP_Click);
      // 
      // dgPlan
      // 
      this.dgPlan.AllowUserToAddRows = false;
      this.dgPlan.AllowUserToDeleteRows = false;
      this.dgPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgPlan.ColumnHeadersHeight = 34;
      this.dgPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chScDow,
            this.chScCut,
            this.chScBeg,
            this.chScMin,
            this.chScEnd});
      this.dgPlan.Location = new System.Drawing.Point(103, 3);
      this.dgPlan.MultiSelect = false;
      this.dgPlan.Name = "dgPlan";
      this.dgPlan.RowHeadersWidth = 46;
      this.dgPlan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgPlan.Size = new System.Drawing.Size(300, 262);
      this.dgPlan.TabIndex = 1;
      this.dgPlan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgSchedulePlan_CellFormatting);
      this.dgPlan.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgSchedulePlan_CellValidating);
      this.dgPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSchedulePlan_CellValueChanged);
      this.dgPlan.SelectionChanged += new System.EventHandler(this.dgSchedulePlan_SelectionChanged);
      // 
      // chScDow
      // 
      this.chScDow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chScDow.Frozen = true;
      this.chScDow.HeaderText = "Tag";
      this.chScDow.MinimumWidth = 8;
      this.chScDow.Name = "chScDow";
      this.chScDow.ReadOnly = true;
      this.chScDow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.chScDow.Width = 44;
      // 
      // chScCut
      // 
      this.chScCut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.chScCut.HeaderText = "Kante";
      this.chScCut.MinimumWidth = 8;
      this.chScCut.Name = "chScCut";
      this.chScCut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chScCut.Width = 65;
      // 
      // chScBeg
      // 
      this.chScBeg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle1.Format = "t";
      dataGridViewCellStyle1.NullValue = null;
      this.chScBeg.DefaultCellStyle = dataGridViewCellStyle1;
      this.chScBeg.HeaderText = "Start";
      this.chScBeg.MinimumWidth = 8;
      this.chScBeg.Name = "chScBeg";
      this.chScBeg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.chScBeg.Width = 58;
      // 
      // chScMin
      // 
      this.chScMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle2.Format = "#0";
      this.chScMin.DefaultCellStyle = dataGridViewCellStyle2;
      this.chScMin.HeaderText = "Dauer";
      this.chScMin.MinimumWidth = 8;
      this.chScMin.Name = "chScMin";
      this.chScMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.chScMin.Width = 66;
      // 
      // chScEnd
      // 
      this.chScEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle3.Format = "T";
      dataGridViewCellStyle3.NullValue = null;
      this.chScEnd.DefaultCellStyle = dataGridViewCellStyle3;
      this.chScEnd.HeaderText = "Ende";
      this.chScEnd.MinimumWidth = 8;
      this.chScEnd.Name = "chScEnd";
      this.chScEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // lCfgScPerc
      // 
      this.lCfgScPerc.AutoSize = true;
      this.lCfgScPerc.Dock = System.Windows.Forms.DockStyle.Right;
      this.lCfgScPerc.Location = new System.Drawing.Point(8, 274);
      this.lCfgScPerc.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.lCfgScPerc.Name = "lCfgScPerc";
      this.lCfgScPerc.Size = new System.Drawing.Size(89, 40);
      this.lCfgScPerc.TabIndex = 5;
      this.lCfgScPerc.Text = "Korrektur";
      // 
      // lCfgRainDelay
      // 
      this.lCfgRainDelay.AutoSize = true;
      this.lCfgRainDelay.Location = new System.Drawing.Point(3, 320);
      this.lCfgRainDelay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.lCfgRainDelay.Name = "lCfgRainDelay";
      this.lCfgRainDelay.Size = new System.Drawing.Size(94, 20);
      this.lCfgRainDelay.TabIndex = 7;
      this.lCfgRainDelay.Text = "Regenzeit";
      this.lCfgRainDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tlCfgScMode
      // 
      this.tlCfgScMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tlCfgScMode.AutoSize = true;
      this.tlCfgScMode.ColumnCount = 2;
      this.tlCfgScMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlCfgScMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlCfgScMode.Controls.Add(this.lCfgSc, 0, 0);
      this.tlCfgScMode.Controls.Add(this.txCfgScMode, 1, 0);
      this.tlCfgScMode.Controls.Add(this.pbPlanCopy, 0, 1);
      this.tlCfgScMode.Location = new System.Drawing.Point(0, 0);
      this.tlCfgScMode.Margin = new System.Windows.Forms.Padding(0);
      this.tlCfgScMode.Name = "tlCfgScMode";
      this.tlCfgScMode.RowCount = 2;
      this.tlCfgScMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
      this.tlCfgScMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlCfgScMode.Size = new System.Drawing.Size(100, 268);
      this.tlCfgScMode.TabIndex = 12;
      // 
      // lCfgSc
      // 
      this.lCfgSc.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lCfgSc.AutoSize = true;
      this.lCfgSc.Location = new System.Drawing.Point(3, 7);
      this.lCfgSc.Name = "lCfgSc";
      this.lCfgSc.Size = new System.Drawing.Size(64, 20);
      this.lCfgSc.TabIndex = 9;
      this.lCfgSc.Text = "Modus";
      this.lCfgSc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txCfgScMode
      // 
      this.txCfgScMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txCfgScMode.AutoSize = true;
      this.txCfgScMode.Location = new System.Drawing.Point(73, 7);
      this.txCfgScMode.Name = "txCfgScMode";
      this.txCfgScMode.Size = new System.Drawing.Size(18, 20);
      this.txCfgScMode.TabIndex = 10;
      this.txCfgScMode.Text = "?";
      // 
      // pbPlanCopy
      // 
      this.pbPlanCopy.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tlCfgScMode.SetColumnSpan(this.pbPlanCopy, 2);
      this.pbPlanCopy.Image = global::DesktopApp.AppRes.right16;
      this.pbPlanCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.pbPlanCopy.Location = new System.Drawing.Point(25, 37);
      this.pbPlanCopy.Name = "pbPlanCopy";
      this.pbPlanCopy.Size = new System.Drawing.Size(50, 23);
      this.pbPlanCopy.TabIndex = 11;
      this.pbPlanCopy.Text = "vv";
      this.pbPlanCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbPlanCopy.UseVisualStyleBackColor = true;
      this.pbPlanCopy.Click += new System.EventHandler(this.pbPlanCopy_Click);
      // 
      // tlCgRainDelay
      // 
      this.tlCgRainDelay.AutoSize = true;
      this.tlCgRainDelay.ColumnCount = 2;
      this.tlCgRainDelay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlCgRainDelay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlCgRainDelay.Controls.Add(this.udCfgRainDelay, 0, 0);
      this.tlCgRainDelay.Controls.Add(this.txCfgRainDelay, 1, 0);
      this.tlCgRainDelay.Location = new System.Drawing.Point(100, 314);
      this.tlCgRainDelay.Margin = new System.Windows.Forms.Padding(0);
      this.tlCgRainDelay.Name = "tlCgRainDelay";
      this.tlCgRainDelay.RowCount = 1;
      this.tlCgRainDelay.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlCgRainDelay.Size = new System.Drawing.Size(140, 34);
      this.tlCgRainDelay.TabIndex = 13;
      // 
      // udCfgRainDelay
      // 
      this.udCfgRainDelay.Location = new System.Drawing.Point(3, 3);
      this.udCfgRainDelay.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
      this.udCfgRainDelay.Name = "udCfgRainDelay";
      this.udCfgRainDelay.Size = new System.Drawing.Size(70, 28);
      this.udCfgRainDelay.TabIndex = 8;
      // 
      // txCfgRainDelay
      // 
      this.txCfgRainDelay.AutoSize = true;
      this.txCfgRainDelay.Location = new System.Drawing.Point(79, 6);
      this.txCfgRainDelay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.txCfgRainDelay.Name = "txCfgRainDelay";
      this.txCfgRainDelay.Size = new System.Drawing.Size(58, 20);
      this.txCfgRainDelay.TabIndex = 9;
      this.txCfgRainDelay.Text = "[min]";
      // 
      // tlScCmd
      // 
      this.tlScCmd.ColumnCount = 3;
      this.tlScCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlScCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlScCmd.Controls.Add(this.pbPlanSave, 2, 0);
      this.tlScCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tlScCmd.Location = new System.Drawing.Point(0, 348);
      this.tlScCmd.Margin = new System.Windows.Forms.Padding(0);
      this.tlScCmd.Name = "tlScCmd";
      this.tlScCmd.RowCount = 1;
      this.tlScCmd.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlScCmd.Size = new System.Drawing.Size(406, 30);
      this.tlScCmd.TabIndex = 3;
      // 
      // pbPlanSave
      // 
      this.pbPlanSave.Location = new System.Drawing.Point(323, 3);
      this.pbPlanSave.Name = "pbPlanSave";
      this.pbPlanSave.Size = new System.Drawing.Size(80, 24);
      this.pbPlanSave.TabIndex = 6;
      this.pbPlanSave.Text = "&Sichern...";
      this.pbPlanSave.UseVisualStyleBackColor = true;
      this.pbPlanSave.Click += new System.EventHandler(this.pbScSave_Click);
      // 
      // tpState
      // 
      this.tpState.Controls.Add(this.tlDat);
      this.tpState.Controls.Add(this.tlDatCmd);
      this.tpState.Location = new System.Drawing.Point(4, 29);
      this.tpState.Name = "tpState";
      this.tpState.Size = new System.Drawing.Size(406, 378);
      this.tpState.TabIndex = 4;
      this.tpState.Text = "Status";
      // 
      // tlDat
      // 
      this.tlDat.BackColor = System.Drawing.Color.DimGray;
      this.tlDat.ColumnCount = 1;
      this.tlDat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlDat.Controls.Add(this.tlDatPic, 0, 1);
      this.tlDat.Controls.Add(this.pDatAccu, 0, 3);
      this.tlDat.Controls.Add(this.txDatDT, 0, 6);
      this.tlDat.Controls.Add(this.tlDatTri, 0, 5);
      this.tlDat.Controls.Add(this.tlDatErrorState, 0, 0);
      this.tlDat.Controls.Add(this.pDatWork, 0, 2);
      this.tlDat.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlDat.Location = new System.Drawing.Point(0, 0);
      this.tlDat.Margin = new System.Windows.Forms.Padding(0);
      this.tlDat.Name = "tlDat";
      this.tlDat.RowCount = 8;
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
      this.tlDat.Size = new System.Drawing.Size(406, 348);
      this.tlDat.TabIndex = 2;
      // 
      // tlDatPic
      // 
      this.tlDatPic.ColumnCount = 3;
      this.tlDatPic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlDatPic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatPic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatPic.Controls.Add(this.txDatFW, 2, 3);
      this.tlDatPic.Controls.Add(this.pictureBox, 0, 0);
      this.tlDatPic.Controls.Add(this.lDatFW, 1, 3);
      this.tlDatPic.Controls.Add(this.picWiFi, 1, 0);
      this.tlDatPic.Controls.Add(this.txDatRsi, 1, 1);
      this.tlDatPic.Controls.Add(this.lDatSP, 1, 2);
      this.tlDatPic.Controls.Add(this.txDatSP, 2, 2);
      this.tlDatPic.Controls.Add(this.tlName, 0, 3);
      this.tlDatPic.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlDatPic.Location = new System.Drawing.Point(3, 32);
      this.tlDatPic.Name = "tlDatPic";
      this.tlDatPic.RowCount = 4;
      this.tlDatPic.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatPic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlDatPic.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatPic.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatPic.Size = new System.Drawing.Size(400, 147);
      this.tlDatPic.TabIndex = 10;
      // 
      // txDatFW
      // 
      this.txDatFW.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.txDatFW.AutoSize = true;
      this.txDatFW.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatFW.Location = new System.Drawing.Point(327, 127);
      this.txDatFW.Name = "txDatFW";
      this.txDatFW.Size = new System.Drawing.Size(70, 20);
      this.txDatFW.TabIndex = 4;
      this.txDatFW.Text = "0.00b0";
      this.txDatFW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip.SetToolTip(this.txDatFW, "Firmware Version");
      // 
      // pictureBox
      // 
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
      this.pictureBox.Location = new System.Drawing.Point(12, 10);
      this.pictureBox.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
      this.pictureBox.Name = "pictureBox";
      this.tlDatPic.SetRowSpan(this.pictureBox, 3);
      this.pictureBox.Size = new System.Drawing.Size(191, 107);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      // 
      // lDatFW
      // 
      this.lDatFW.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lDatFW.AutoSize = true;
      this.lDatFW.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.lDatFW.Location = new System.Drawing.Point(218, 127);
      this.lDatFW.Name = "lDatFW";
      this.lDatFW.Size = new System.Drawing.Size(89, 20);
      this.lDatFW.TabIndex = 4;
      this.lDatFW.Text = "Firmware";
      this.lDatFW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // picWiFi
      // 
      this.picWiFi.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.picWiFi.BackColor = System.Drawing.Color.Transparent;
      this.tlDatPic.SetColumnSpan(this.picWiFi, 2);
      this.picWiFi.Location = new System.Drawing.Point(282, 10);
      this.picWiFi.Margin = new System.Windows.Forms.Padding(2, 10, 2, 2);
      this.picWiFi.Name = "picWiFi";
      this.picWiFi.Size = new System.Drawing.Size(50, 35);
      this.picWiFi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.picWiFi.TabIndex = 2;
      this.picWiFi.TabStop = false;
      // 
      // txDatRsi
      // 
      this.txDatRsi.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txDatRsi.AutoSize = true;
      this.tlDatPic.SetColumnSpan(this.txDatRsi, 2);
      this.txDatRsi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatRsi.Location = new System.Drawing.Point(288, 47);
      this.txDatRsi.Name = "txDatRsi";
      this.txDatRsi.Size = new System.Drawing.Size(39, 20);
      this.txDatRsi.TabIndex = 3;
      this.txDatRsi.Text = "-00";
      this.txDatRsi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.toolTip.SetToolTip(this.txDatRsi, "Receive Signal Strength Indicator");
      // 
      // lDatSP
      // 
      this.lDatSP.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lDatSP.AutoSize = true;
      this.lDatSP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.lDatSP.Location = new System.Drawing.Point(218, 107);
      this.lDatSP.Name = "lDatSP";
      this.lDatSP.Size = new System.Drawing.Size(103, 20);
      this.lDatSP.TabIndex = 4;
      this.lDatSP.Text = "Zone [Idx]";
      this.lDatSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txDatSP
      // 
      this.txDatSP.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.txDatSP.AutoSize = true;
      this.txDatSP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatSP.Location = new System.Drawing.Point(344, 107);
      this.txDatSP.Name = "txDatSP";
      this.txDatSP.Size = new System.Drawing.Size(53, 20);
      this.txDatSP.TabIndex = 4;
      this.txDatSP.Text = "0 [0]";
      this.txDatSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip.SetToolTip(this.txDatSP, "Start Point");
      // 
      // tlName
      // 
      this.tlName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tlName.ColumnCount = 5;
      this.tlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlName.Controls.Add(this.txDF, 0, 0);
      this.tlName.Controls.Add(this.txUS, 0, 0);
      this.tlName.Controls.Add(this.txName, 0, 0);
      this.tlName.Controls.Add(this.txRL, 2, 0);
      this.tlName.Controls.Add(this.tx4G, 1, 0);
      this.tlName.Location = new System.Drawing.Point(3, 127);
      this.tlName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.tlName.Name = "tlName";
      this.tlName.RowCount = 1;
      this.tlName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlName.Size = new System.Drawing.Size(209, 20);
      this.tlName.TabIndex = 5;
      // 
      // txDF
      // 
      this.txDF.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDF.ForeColor = System.Drawing.Color.White;
      this.txDF.Location = new System.Drawing.Point(95, 3);
      this.txDF.Name = "txDF";
      this.txDF.Size = new System.Drawing.Size(32, 13);
      this.txDF.TabIndex = 3;
      this.txDF.Text = "OLM";
      this.txDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.txDF.Visible = false;
      // 
      // txUS
      // 
      this.txUS.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txUS.ForeColor = System.Drawing.Color.White;
      this.txUS.Location = new System.Drawing.Point(57, 3);
      this.txUS.Name = "txUS";
      this.txUS.Size = new System.Drawing.Size(32, 13);
      this.txUS.TabIndex = 2;
      this.txUS.Text = "ACS";
      this.txUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.txUS.Visible = false;
      // 
      // txName
      // 
      this.txName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.txName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txName.ForeColor = System.Drawing.Color.Yellow;
      this.txName.Location = new System.Drawing.Point(3, 2);
      this.txName.Name = "txName";
      this.txName.Size = new System.Drawing.Size(48, 15);
      this.txName.TabIndex = 0;
      this.txName.Text = "Name";
      this.txName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txRL
      // 
      this.txRL.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txRL.ForeColor = System.Drawing.Color.White;
      this.txRL.Location = new System.Drawing.Point(174, 3);
      this.txRL.Name = "txRL";
      this.txRL.Size = new System.Drawing.Size(32, 13);
      this.txRL.TabIndex = 1;
      this.txRL.Text = "RL";
      this.txRL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.txRL.Visible = false;
      // 
      // tx4G
      // 
      this.tx4G.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.tx4G.ForeColor = System.Drawing.Color.White;
      this.tx4G.Location = new System.Drawing.Point(133, 3);
      this.tx4G.Name = "tx4G";
      this.tx4G.Size = new System.Drawing.Size(35, 13);
      this.tx4G.TabIndex = 1;
      this.tx4G.Text = "FML";
      this.tx4G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.tx4G.Visible = false;
      // 
      // pDatAccu
      // 
      this.pDatAccu.AutoSize = true;
      this.pDatAccu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pDatAccu.BackgroundImage")));
      this.pDatAccu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pDatAccu.Controls.Add(this.txDatAccu);
      this.pDatAccu.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pDatAccu.Location = new System.Drawing.Point(12, 210);
      this.pDatAccu.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
      this.pDatAccu.Name = "pDatAccu";
      this.pDatAccu.Size = new System.Drawing.Size(382, 19);
      this.pDatAccu.TabIndex = 5;
      // 
      // txDatAccu
      // 
      this.txDatAccu.BackColor = System.Drawing.Color.Transparent;
      this.txDatAccu.Dock = System.Windows.Forms.DockStyle.Top;
      this.txDatAccu.Location = new System.Drawing.Point(0, 0);
      this.txDatAccu.Name = "txDatAccu";
      this.txDatAccu.Size = new System.Drawing.Size(382, 19);
      this.txDatAccu.TabIndex = 0;
      this.txDatAccu.Text = "Accumulator 00.0V 00° 000%";
      this.txDatAccu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txDatDT
      // 
      this.txDatDT.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatDT.AutoSize = true;
      this.txDatDT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatDT.Location = new System.Drawing.Point(136, 318);
      this.txDatDT.Name = "txDatDT";
      this.txDatDT.Size = new System.Drawing.Size(134, 20);
      this.txDatDT.TabIndex = 6;
      this.txDatDT.Text = "Last Update: ?";
      this.txDatDT.DoubleClick += new System.EventHandler(this.txDatDT_DoubleClick);
      // 
      // tlDatTri
      // 
      this.tlDatTri.ColumnCount = 3;
      this.tlDatTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlDatTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlDatTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tlDatTri.Controls.Add(this.picPitch, 0, 0);
      this.tlDatTri.Controls.Add(this.picRoll, 1, 0);
      this.tlDatTri.Controls.Add(this.picYaw, 2, 0);
      this.tlDatTri.Controls.Add(this.txDatDmp0, 0, 1);
      this.tlDatTri.Controls.Add(this.txDatDmp1, 1, 1);
      this.tlDatTri.Controls.Add(this.txDatDmp2, 2, 1);
      this.tlDatTri.Controls.Add(this.txDatStB, 0, 3);
      this.tlDatTri.Controls.Add(this.txDatStD, 1, 3);
      this.tlDatTri.Controls.Add(this.txDatStW, 2, 3);
      this.tlDatTri.Dock = System.Windows.Forms.DockStyle.Top;
      this.tlDatTri.Location = new System.Drawing.Point(3, 235);
      this.tlDatTri.Name = "tlDatTri";
      this.tlDatTri.RowCount = 4;
      this.tlDatTri.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatTri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlDatTri.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatTri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlDatTri.Size = new System.Drawing.Size(400, 80);
      this.tlDatTri.TabIndex = 7;
      // 
      // picPitch
      // 
      this.picPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.picPitch.Image = ((System.Drawing.Image)(resources.GetObject("picPitch.Image")));
      this.picPitch.Location = new System.Drawing.Point(26, 0);
      this.picPitch.Margin = new System.Windows.Forms.Padding(0);
      this.picPitch.Name = "picPitch";
      this.picPitch.Size = new System.Drawing.Size(80, 25);
      this.picPitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.picPitch.TabIndex = 0;
      this.picPitch.TabStop = false;
      // 
      // picRoll
      // 
      this.picRoll.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.picRoll.Image = ((System.Drawing.Image)(resources.GetObject("picRoll.Image")));
      this.picRoll.Location = new System.Drawing.Point(159, 0);
      this.picRoll.Margin = new System.Windows.Forms.Padding(0);
      this.picRoll.Name = "picRoll";
      this.picRoll.Size = new System.Drawing.Size(80, 25);
      this.picRoll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.picRoll.TabIndex = 1;
      this.picRoll.TabStop = false;
      // 
      // picYaw
      // 
      this.picYaw.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.picYaw.Image = ((System.Drawing.Image)(resources.GetObject("picYaw.Image")));
      this.picYaw.Location = new System.Drawing.Point(293, 0);
      this.picYaw.Margin = new System.Windows.Forms.Padding(0);
      this.picYaw.Name = "picYaw";
      this.picYaw.Size = new System.Drawing.Size(80, 25);
      this.picYaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.picYaw.TabIndex = 2;
      this.picYaw.TabStop = false;
      // 
      // txDatDmp0
      // 
      this.txDatDmp0.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatDmp0.AutoSize = true;
      this.txDatDmp0.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatDmp0.Location = new System.Drawing.Point(15, 28);
      this.txDatDmp0.Name = "txDatDmp0";
      this.txDatDmp0.Size = new System.Drawing.Size(102, 20);
      this.txDatDmp0.TabIndex = 3;
      this.txDatDmp0.Text = "Pitch: 0.0°";
      // 
      // txDatDmp1
      // 
      this.txDatDmp1.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatDmp1.AutoSize = true;
      this.txDatDmp1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatDmp1.Location = new System.Drawing.Point(153, 28);
      this.txDatDmp1.Name = "txDatDmp1";
      this.txDatDmp1.Size = new System.Drawing.Size(92, 20);
      this.txDatDmp1.TabIndex = 4;
      this.txDatDmp1.Text = "Roll: 0.0°";
      // 
      // txDatDmp2
      // 
      this.txDatDmp2.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatDmp2.AutoSize = true;
      this.txDatDmp2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatDmp2.Location = new System.Drawing.Point(275, 28);
      this.txDatDmp2.Name = "txDatDmp2";
      this.txDatDmp2.Size = new System.Drawing.Size(115, 20);
      this.txDatDmp2.TabIndex = 5;
      this.txDatDmp2.Text = "Yaw: 000.0°";
      // 
      // txDatStB
      // 
      this.txDatStB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.txDatStB.AutoSize = true;
      this.txDatStB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatStB.Image = ((System.Drawing.Image)(resources.GetObject("txDatStB.Image")));
      this.txDatStB.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.txDatStB.Location = new System.Drawing.Point(8, 52);
      this.txDatStB.Name = "txDatStB";
      this.txDatStB.Size = new System.Drawing.Size(117, 28);
      this.txDatStB.TabIndex = 6;
      this.txDatStB.Text = "Blade: 0d.00h:00m";
      this.txDatStB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip.SetToolTip(this.txDatStB, "Mähzeit");
      this.txDatStB.DoubleClick += new System.EventHandler(this.txDatStB_DoubleClick);
      // 
      // txDatStD
      // 
      this.txDatStD.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatStD.AutoSize = true;
      this.txDatStD.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatStD.Location = new System.Drawing.Point(150, 52);
      this.txDatStD.Name = "txDatStD";
      this.txDatStD.Size = new System.Drawing.Size(98, 28);
      this.txDatStD.TabIndex = 8;
      this.txDatStD.Text = "Dist: 000.000m";
      this.toolTip.SetToolTip(this.txDatStD, "Gesamtstrecke");
      // 
      // txDatStW
      // 
      this.txDatStW.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.txDatStW.AutoSize = true;
      this.txDatStW.BackColor = System.Drawing.Color.DimGray;
      this.txDatStW.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDatStW.Location = new System.Drawing.Point(274, 52);
      this.txDatStW.Name = "txDatStW";
      this.txDatStW.Size = new System.Drawing.Size(117, 28);
      this.txDatStW.TabIndex = 9;
      this.txDatStW.Text = "Work 0d.00h:00m";
      this.toolTip.SetToolTip(this.txDatStW, "Arbeitszeit");
      // 
      // tlDatErrorState
      // 
      this.tlDatErrorState.AutoSize = true;
      this.tlDatErrorState.ColumnCount = 4;
      this.tlDatErrorState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlDatErrorState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatErrorState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatErrorState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlDatErrorState.Controls.Add(this.txError, 1, 0);
      this.tlDatErrorState.Controls.Add(this.txStatus, 2, 0);
      this.tlDatErrorState.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlDatErrorState.Location = new System.Drawing.Point(0, 0);
      this.tlDatErrorState.Margin = new System.Windows.Forms.Padding(0);
      this.tlDatErrorState.Name = "tlDatErrorState";
      this.tlDatErrorState.RowCount = 1;
      this.tlDatErrorState.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatErrorState.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tlDatErrorState.Size = new System.Drawing.Size(406, 29);
      this.tlDatErrorState.TabIndex = 9;
      // 
      // txError
      // 
      this.txError.AutoSize = true;
      this.txError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txError.ForeColor = System.Drawing.Color.White;
      this.txError.Location = new System.Drawing.Point(148, 0);
      this.txError.Name = "txError";
      this.txError.Size = new System.Drawing.Size(52, 29);
      this.txError.TabIndex = 12;
      this.txError.Text = "???";
      this.txError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txStatus
      // 
      this.txStatus.AutoSize = true;
      this.txStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txStatus.ForeColor = System.Drawing.Color.White;
      this.txStatus.Location = new System.Drawing.Point(206, 0);
      this.txStatus.Name = "txStatus";
      this.txStatus.Size = new System.Drawing.Size(52, 29);
      this.txStatus.TabIndex = 11;
      this.txStatus.Text = "???";
      this.txStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pDatWork
      // 
      this.pDatWork.AutoSize = true;
      this.pDatWork.BackColor = System.Drawing.Color.Transparent;
      this.pDatWork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pDatWork.BackgroundImage")));
      this.pDatWork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pDatWork.Controls.Add(this.txDatWork);
      this.pDatWork.Dock = System.Windows.Forms.DockStyle.Top;
      this.pDatWork.Location = new System.Drawing.Point(12, 185);
      this.pDatWork.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
      this.pDatWork.Name = "pDatWork";
      this.pDatWork.Size = new System.Drawing.Size(382, 19);
      this.pDatWork.TabIndex = 11;
      // 
      // txDatWork
      // 
      this.txDatWork.BackColor = System.Drawing.Color.Transparent;
      this.txDatWork.Dock = System.Windows.Forms.DockStyle.Top;
      this.txDatWork.Location = new System.Drawing.Point(0, 0);
      this.txDatWork.Name = "txDatWork";
      this.txDatWork.Size = new System.Drawing.Size(382, 19);
      this.txDatWork.TabIndex = 1;
      this.txDatWork.Text = "Worktime 00:00-00:00 000%";
      this.txDatWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tlDatCmd
      // 
      this.tlDatCmd.ColumnCount = 7;
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlDatCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlDatCmd.Controls.Add(this.pbStart, 1, 0);
      this.tlDatCmd.Controls.Add(this.pbPoll, 6, 0);
      this.tlDatCmd.Controls.Add(this.pbHome, 3, 0);
      this.tlDatCmd.Controls.Add(this.pbStop, 2, 0);
      this.tlDatCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tlDatCmd.Location = new System.Drawing.Point(0, 348);
      this.tlDatCmd.Margin = new System.Windows.Forms.Padding(0);
      this.tlDatCmd.Name = "tlDatCmd";
      this.tlDatCmd.RowCount = 1;
      this.tlDatCmd.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlDatCmd.Size = new System.Drawing.Size(406, 30);
      this.tlDatCmd.TabIndex = 1;
      // 
      // pbStart
      // 
      this.pbStart.Enabled = false;
      this.pbStart.Image = global::DesktopApp.AppRes.play16;
      this.pbStart.Location = new System.Drawing.Point(25, 3);
      this.pbStart.Name = "pbStart";
      this.pbStart.Size = new System.Drawing.Size(80, 24);
      this.pbStart.TabIndex = 1;
      this.pbStart.Text = "&Start";
      this.pbStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbStart.UseVisualStyleBackColor = true;
      this.pbStart.Click += new System.EventHandler(this.pbStart_Click);
      // 
      // pbPoll
      // 
      this.pbPoll.Enabled = false;
      this.pbPoll.Image = global::DesktopApp.AppRes.refresh16;
      this.pbPoll.Location = new System.Drawing.Point(323, 3);
      this.pbPoll.Name = "pbPoll";
      this.pbPoll.Size = new System.Drawing.Size(80, 24);
      this.pbPoll.TabIndex = 0;
      this.pbPoll.Text = "&Poll";
      this.pbPoll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbPoll.UseVisualStyleBackColor = true;
      this.pbPoll.Click += new System.EventHandler(this.pbDatPoll_Click);
      // 
      // pbHome
      // 
      this.pbHome.Enabled = false;
      this.pbHome.Image = global::DesktopApp.AppRes.home16;
      this.pbHome.Location = new System.Drawing.Point(197, 3);
      this.pbHome.Name = "pbHome";
      this.pbHome.Size = new System.Drawing.Size(80, 24);
      this.pbHome.TabIndex = 3;
      this.pbHome.Text = "&Home";
      this.pbHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbHome.UseVisualStyleBackColor = true;
      this.pbHome.Click += new System.EventHandler(this.pbHome_Click);
      // 
      // pbStop
      // 
      this.pbStop.Enabled = false;
      this.pbStop.Image = global::DesktopApp.AppRes.stop16;
      this.pbStop.Location = new System.Drawing.Point(111, 3);
      this.pbStop.Name = "pbStop";
      this.pbStop.Size = new System.Drawing.Size(80, 24);
      this.pbStop.TabIndex = 2;
      this.pbStop.Text = "S&top";
      this.pbStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbStop.UseVisualStyleBackColor = true;
      this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
      // 
      // tpUsr
      // 
      this.tpUsr.Controls.Add(this.tlpUsrSet);
      this.tpUsr.Controls.Add(this.tlpUsrBtn);
      this.tpUsr.Location = new System.Drawing.Point(4, 29);
      this.tpUsr.Name = "tpUsr";
      this.tpUsr.Size = new System.Drawing.Size(406, 378);
      this.tpUsr.TabIndex = 0;
      this.tpUsr.Text = "Nutzer";
      this.tpUsr.UseVisualStyleBackColor = true;
      // 
      // tlpUsrSet
      // 
      this.tlpUsrSet.ColumnCount = 3;
      this.tlpUsrSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpUsrSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpUsrSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpUsrSet.Controls.Add(this.txUsrMail, 0, 2);
      this.tlpUsrSet.Controls.Add(this.edUsrMail, 1, 2);
      this.tlpUsrSet.Controls.Add(this.txUsrPass, 0, 3);
      this.tlpUsrSet.Controls.Add(this.edUsrPass, 1, 3);
      this.tlpUsrSet.Controls.Add(this.txUsrName, 0, 4);
      this.tlpUsrSet.Controls.Add(this.edUsrName, 1, 4);
      this.tlpUsrSet.Controls.Add(this.txUsrUuid, 0, 0);
      this.tlpUsrSet.Controls.Add(this.edUsrUuid, 1, 0);
      this.tlpUsrSet.Controls.Add(this.cbOnTop, 1, 8);
      this.tlpUsrSet.Controls.Add(this.txUsrBroker, 0, 5);
      this.tlpUsrSet.Controls.Add(this.edUsrBroker, 1, 5);
      this.tlpUsrSet.Controls.Add(this.txUsrMac, 0, 7);
      this.tlpUsrSet.Controls.Add(this.edUsrMac, 1, 7);
      this.tlpUsrSet.Controls.Add(this.txUsrBoard, 0, 6);
      this.tlpUsrSet.Controls.Add(this.edUsrBoard, 1, 6);
      this.tlpUsrSet.Controls.Add(this.txUsrApi, 0, 1);
      this.tlpUsrSet.Controls.Add(this.cbUsrApi, 1, 1);
      this.tlpUsrSet.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpUsrSet.Location = new System.Drawing.Point(0, 0);
      this.tlpUsrSet.Margin = new System.Windows.Forms.Padding(0);
      this.tlpUsrSet.Name = "tlpUsrSet";
      this.tlpUsrSet.RowCount = 12;
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpUsrSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpUsrSet.Size = new System.Drawing.Size(406, 348);
      this.tlpUsrSet.TabIndex = 0;
      // 
      // txUsrMail
      // 
      this.txUsrMail.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrMail.AutoSize = true;
      this.txUsrMail.Location = new System.Drawing.Point(3, 75);
      this.txUsrMail.Name = "txUsrMail";
      this.txUsrMail.Size = new System.Drawing.Size(57, 20);
      this.txUsrMail.TabIndex = 1;
      this.txUsrMail.Text = "&Email";
      this.txUsrMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrMail
      // 
      this.edUsrMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.tlpUsrSet.SetColumnSpan(this.edUsrMail, 2);
      this.edUsrMail.Location = new System.Drawing.Point(99, 71);
      this.edUsrMail.Name = "edUsrMail";
      this.edUsrMail.Size = new System.Drawing.Size(304, 28);
      this.edUsrMail.TabIndex = 2;
      this.toolTip.SetToolTip(this.edUsrMail, "Siehe Email: Worx Landroid account created");
      this.edUsrMail.TextChanged += new System.EventHandler(this.edUsrMail_TextChanged);
      // 
      // txUsrPass
      // 
      this.txUsrPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrPass.AutoSize = true;
      this.txUsrPass.Location = new System.Drawing.Point(3, 109);
      this.txUsrPass.Name = "txUsrPass";
      this.txUsrPass.Size = new System.Drawing.Size(90, 20);
      this.txUsrPass.TabIndex = 3;
      this.txUsrPass.Text = "&Kennwort";
      this.txUsrPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrPass
      // 
      this.edUsrPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.edUsrPass.Location = new System.Drawing.Point(99, 105);
      this.edUsrPass.Name = "edUsrPass";
      this.edUsrPass.PasswordChar = '*';
      this.edUsrPass.Size = new System.Drawing.Size(149, 28);
      this.edUsrPass.TabIndex = 4;
      this.toolTip.SetToolTip(this.edUsrPass, "Siehe Email: Worx Landroid account created");
      this.edUsrPass.TextChanged += new System.EventHandler(this.edUsrPass_TextChanged);
      // 
      // txUsrName
      // 
      this.txUsrName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrName.AutoSize = true;
      this.txUsrName.Location = new System.Drawing.Point(3, 143);
      this.txUsrName.Name = "txUsrName";
      this.txUsrName.Size = new System.Drawing.Size(59, 20);
      this.txUsrName.TabIndex = 9;
      this.txUsrName.Text = "&Name";
      this.txUsrName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrName
      // 
      this.edUsrName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edUsrName.Location = new System.Drawing.Point(99, 139);
      this.edUsrName.Name = "edUsrName";
      this.edUsrName.Size = new System.Drawing.Size(149, 28);
      this.edUsrName.TabIndex = 10;
      this.toolTip.SetToolTip(this.edUsrName, "Falls Du mehrere Landroiden hast und wechseln willst mach es leer.");
      // 
      // txUsrUuid
      // 
      this.txUsrUuid.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrUuid.AutoSize = true;
      this.txUsrUuid.Location = new System.Drawing.Point(3, 7);
      this.txUsrUuid.Name = "txUsrUuid";
      this.txUsrUuid.Size = new System.Drawing.Size(48, 20);
      this.txUsrUuid.TabIndex = 13;
      this.txUsrUuid.Text = "Uuid";
      this.txUsrUuid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrUuid
      // 
      this.edUsrUuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.tlpUsrSet.SetColumnSpan(this.edUsrUuid, 2);
      this.edUsrUuid.Location = new System.Drawing.Point(99, 3);
      this.edUsrUuid.Name = "edUsrUuid";
      this.edUsrUuid.ReadOnly = true;
      this.edUsrUuid.Size = new System.Drawing.Size(304, 28);
      this.edUsrUuid.TabIndex = 14;
      this.toolTip.SetToolTip(this.edUsrUuid, "Aus der Email: Worx Landroid account created");
      // 
      // cbOnTop
      // 
      this.cbOnTop.AutoSize = true;
      this.cbOnTop.Location = new System.Drawing.Point(99, 275);
      this.cbOnTop.Name = "cbOnTop";
      this.cbOnTop.Size = new System.Drawing.Size(149, 24);
      this.cbOnTop.TabIndex = 12;
      this.cbOnTop.Text = "Fenster im &Vordergrund";
      this.cbOnTop.UseVisualStyleBackColor = true;
      this.cbOnTop.CheckedChanged += new System.EventHandler(this.cbOnTop_CheckedChanged);
      // 
      // txUsrBroker
      // 
      this.txUsrBroker.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrBroker.AutoSize = true;
      this.txUsrBroker.Location = new System.Drawing.Point(3, 177);
      this.txUsrBroker.Name = "txUsrBroker";
      this.txUsrBroker.Size = new System.Drawing.Size(65, 20);
      this.txUsrBroker.TabIndex = 9;
      this.txUsrBroker.Text = "Broker";
      this.txUsrBroker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrBroker
      // 
      this.edUsrBroker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.tlpUsrSet.SetColumnSpan(this.edUsrBroker, 2);
      this.edUsrBroker.Location = new System.Drawing.Point(99, 173);
      this.edUsrBroker.Name = "edUsrBroker";
      this.edUsrBroker.ReadOnly = true;
      this.edUsrBroker.Size = new System.Drawing.Size(304, 28);
      this.edUsrBroker.TabIndex = 15;
      // 
      // txUsrMac
      // 
      this.txUsrMac.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrMac.AutoSize = true;
      this.txUsrMac.Location = new System.Drawing.Point(3, 245);
      this.txUsrMac.Name = "txUsrMac";
      this.txUsrMac.Size = new System.Drawing.Size(47, 20);
      this.txUsrMac.TabIndex = 9;
      this.txUsrMac.Text = "MAC";
      this.txUsrMac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrMac
      // 
      this.edUsrMac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.edUsrMac.Location = new System.Drawing.Point(99, 241);
      this.edUsrMac.Name = "edUsrMac";
      this.edUsrMac.ReadOnly = true;
      this.edUsrMac.Size = new System.Drawing.Size(149, 28);
      this.edUsrMac.TabIndex = 15;
      // 
      // txUsrBoard
      // 
      this.txUsrBoard.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrBoard.AutoSize = true;
      this.txUsrBoard.Location = new System.Drawing.Point(3, 211);
      this.txUsrBoard.Name = "txUsrBoard";
      this.txUsrBoard.Size = new System.Drawing.Size(59, 20);
      this.txUsrBoard.TabIndex = 9;
      this.txUsrBoard.Text = "Board";
      this.txUsrBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edUsrBoard
      // 
      this.edUsrBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.edUsrBoard.Location = new System.Drawing.Point(99, 207);
      this.edUsrBoard.Name = "edUsrBoard";
      this.edUsrBoard.ReadOnly = true;
      this.edUsrBoard.Size = new System.Drawing.Size(149, 28);
      this.edUsrBoard.TabIndex = 15;
      // 
      // txUsrApi
      // 
      this.txUsrApi.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.txUsrApi.AutoSize = true;
      this.txUsrApi.Location = new System.Drawing.Point(3, 41);
      this.txUsrApi.Name = "txUsrApi";
      this.txUsrApi.Size = new System.Drawing.Size(39, 20);
      this.txUsrApi.TabIndex = 16;
      this.txUsrApi.Text = "&API";
      this.txUsrApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cbUsrApi
      // 
      this.cbUsrApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.cbUsrApi.FormattingEnabled = true;
      this.cbUsrApi.Items.AddRange(new object[] {
            "WR - Worx Landroid",
            "KR - Kress Mission",
            "LX - Landxcape"});
      this.cbUsrApi.Location = new System.Drawing.Point(99, 37);
      this.cbUsrApi.Name = "cbUsrApi";
      this.cbUsrApi.Size = new System.Drawing.Size(149, 28);
      this.cbUsrApi.TabIndex = 17;
      this.cbUsrApi.SelectedIndexChanged += new System.EventHandler(this.cbUsrApi_SelectedIndexChanged);
      // 
      // tlpUsrBtn
      // 
      this.tlpUsrBtn.AutoSize = true;
      this.tlpUsrBtn.ColumnCount = 5;
      this.tlpUsrBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpUsrBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpUsrBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpUsrBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpUsrBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpUsrBtn.Controls.Add(this.pbLogin, 1, 0);
      this.tlpUsrBtn.Controls.Add(this.pbTest, 0, 0);
      this.tlpUsrBtn.Controls.Add(this.pbDisconnect, 4, 0);
      this.tlpUsrBtn.Controls.Add(this.pbConnect, 3, 0);
      this.tlpUsrBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tlpUsrBtn.Location = new System.Drawing.Point(0, 348);
      this.tlpUsrBtn.Margin = new System.Windows.Forms.Padding(0);
      this.tlpUsrBtn.Name = "tlpUsrBtn";
      this.tlpUsrBtn.RowCount = 1;
      this.tlpUsrBtn.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpUsrBtn.Size = new System.Drawing.Size(406, 30);
      this.tlpUsrBtn.TabIndex = 1;
      // 
      // pbLogin
      // 
      this.pbLogin.Enabled = false;
      this.pbLogin.Location = new System.Drawing.Point(131, 3);
      this.pbLogin.Name = "pbLogin";
      this.pbLogin.Size = new System.Drawing.Size(80, 24);
      this.pbLogin.TabIndex = 1;
      this.pbLogin.Text = "A&nmelden";
      this.pbLogin.UseVisualStyleBackColor = true;
      this.pbLogin.Click += new System.EventHandler(this.pbUsrLogin_Click);
      // 
      // pbTest
      // 
      this.pbTest.Enabled = false;
      this.pbTest.Location = new System.Drawing.Point(3, 3);
      this.pbTest.Name = "pbTest";
      this.pbTest.Size = new System.Drawing.Size(60, 24);
      this.pbTest.TabIndex = 0;
      this.pbTest.Text = "Test";
      this.pbTest.UseVisualStyleBackColor = true;
      this.pbTest.Visible = false;
      this.pbTest.Click += new System.EventHandler(this.pbTest_Click);
      // 
      // pbDisconnect
      // 
      this.pbDisconnect.Enabled = false;
      this.pbDisconnect.Location = new System.Drawing.Point(323, 3);
      this.pbDisconnect.Name = "pbDisconnect";
      this.pbDisconnect.Size = new System.Drawing.Size(80, 24);
      this.pbDisconnect.TabIndex = 2;
      this.pbDisconnect.Text = "&Trennen";
      this.pbDisconnect.UseVisualStyleBackColor = true;
      this.pbDisconnect.Click += new System.EventHandler(this.pbDisconnect_Click);
      // 
      // pbConnect
      // 
      this.pbConnect.Enabled = false;
      this.pbConnect.Location = new System.Drawing.Point(237, 3);
      this.pbConnect.Name = "pbConnect";
      this.pbConnect.Size = new System.Drawing.Size(80, 24);
      this.pbConnect.TabIndex = 3;
      this.pbConnect.Text = "&Verbinden";
      this.pbConnect.UseVisualStyleBackColor = true;
      this.pbConnect.Click += new System.EventHandler(this.pbConnect_Click);
      // 
      // tcMain
      // 
      this.tcMain.Controls.Add(this.tpUsr);
      this.tcMain.Controls.Add(this.tpState);
      this.tcMain.Controls.Add(this.tpPlan);
      this.tcMain.Controls.Add(this.tpZone);
      this.tcMain.Controls.Add(this.tpAct);
      this.tcMain.Controls.Add(this.tpPlugin);
      this.tcMain.Controls.Add(this.tpMqtt);
      this.tcMain.Controls.Add(this.tpTrace);
      this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcMain.Location = new System.Drawing.Point(0, 0);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new System.Drawing.Size(414, 411);
      this.tcMain.TabIndex = 0;
      this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
      // 
      // tpZone
      // 
      this.tpZone.Controls.Add(this.tlZone);
      this.tpZone.Controls.Add(this.tlZoneBtn);
      this.tpZone.Location = new System.Drawing.Point(4, 29);
      this.tpZone.Name = "tpZone";
      this.tpZone.Size = new System.Drawing.Size(406, 378);
      this.tpZone.TabIndex = 9;
      this.tpZone.Text = "Zonen";
      this.tpZone.UseVisualStyleBackColor = true;
      // 
      // tlZone
      // 
      this.tlZone.ColumnCount = 1;
      this.tlZone.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlZone.Controls.Add(this.dgZone, 0, 0);
      this.tlZone.Controls.Add(this.txZoneDist, 0, 1);
      this.tlZone.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlZone.Location = new System.Drawing.Point(0, 0);
      this.tlZone.Margin = new System.Windows.Forms.Padding(0);
      this.tlZone.Name = "tlZone";
      this.tlZone.RowCount = 2;
      this.tlZone.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlZone.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlZone.Size = new System.Drawing.Size(406, 348);
      this.tlZone.TabIndex = 14;
      // 
      // dgZone
      // 
      this.dgZone.AllowUserToAddRows = false;
      this.dgZone.AllowUserToDeleteRows = false;
      this.dgZone.ColumnHeadersHeight = 34;
      this.dgZone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chMzStart,
            this.chMz0,
            this.chMz1,
            this.chMz2,
            this.chMz3,
            this.chMz4,
            this.chMz5,
            this.chMz6,
            this.chMz7,
            this.chMz8,
            this.chMz9,
            this.chMzPerc});
      this.dgZone.Dock = System.Windows.Forms.DockStyle.Top;
      this.dgZone.Location = new System.Drawing.Point(3, 3);
      this.dgZone.MultiSelect = false;
      this.dgZone.Name = "dgZone";
      this.dgZone.RowHeadersWidth = 46;
      this.dgZone.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.dgZone.Size = new System.Drawing.Size(400, 80);
      this.dgZone.TabIndex = 12;
      this.dgZone.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMultiZone_CellContentClick);
      this.dgZone.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMultiZone_CellValueChanged);
      // 
      // chMzStart
      // 
      this.chMzStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.chMzStart.HeaderText = "Start [m]";
      this.chMzStart.MinimumWidth = 8;
      this.chMzStart.Name = "chMzStart";
      this.chMzStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.chMzStart.Width = 97;
      // 
      // chMz0
      // 
      this.chMz0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz0.HeaderText = "0";
      this.chMz0.MinimumWidth = 8;
      this.chMz0.Name = "chMz0";
      this.chMz0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz0.Width = 26;
      // 
      // chMz1
      // 
      this.chMz1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz1.HeaderText = "1";
      this.chMz1.MinimumWidth = 8;
      this.chMz1.Name = "chMz1";
      this.chMz1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz1.Width = 26;
      // 
      // chMz2
      // 
      this.chMz2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz2.HeaderText = "2";
      this.chMz2.MinimumWidth = 8;
      this.chMz2.Name = "chMz2";
      this.chMz2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz2.Width = 26;
      // 
      // chMz3
      // 
      this.chMz3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz3.HeaderText = "3";
      this.chMz3.MinimumWidth = 8;
      this.chMz3.Name = "chMz3";
      this.chMz3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz3.Width = 26;
      // 
      // chMz4
      // 
      this.chMz4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz4.HeaderText = "4";
      this.chMz4.MinimumWidth = 8;
      this.chMz4.Name = "chMz4";
      this.chMz4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz4.Width = 26;
      // 
      // chMz5
      // 
      this.chMz5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz5.HeaderText = "5";
      this.chMz5.MinimumWidth = 8;
      this.chMz5.Name = "chMz5";
      this.chMz5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz5.Width = 26;
      // 
      // chMz6
      // 
      this.chMz6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz6.HeaderText = "6";
      this.chMz6.MinimumWidth = 8;
      this.chMz6.Name = "chMz6";
      this.chMz6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz6.Width = 26;
      // 
      // chMz7
      // 
      this.chMz7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz7.HeaderText = "7";
      this.chMz7.MinimumWidth = 8;
      this.chMz7.Name = "chMz7";
      this.chMz7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz7.Width = 26;
      // 
      // chMz8
      // 
      this.chMz8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz8.HeaderText = "8";
      this.chMz8.MinimumWidth = 8;
      this.chMz8.Name = "chMz8";
      this.chMz8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz8.Width = 26;
      // 
      // chMz9
      // 
      this.chMz9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.chMz9.HeaderText = "9";
      this.chMz9.MinimumWidth = 8;
      this.chMz9.Name = "chMz9";
      this.chMz9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.chMz9.Width = 26;
      // 
      // chMzPerc
      // 
      this.chMzPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.chMzPerc.HeaderText = "Anteil";
      this.chMzPerc.MinimumWidth = 8;
      this.chMzPerc.Name = "chMzPerc";
      this.chMzPerc.ReadOnly = true;
      this.chMzPerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // txZoneDist
      // 
      this.txZoneDist.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txZoneDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txZoneDist.Location = new System.Drawing.Point(3, 86);
      this.txZoneDist.Name = "txZoneDist";
      this.txZoneDist.Size = new System.Drawing.Size(400, 262);
      this.txZoneDist.TabIndex = 13;
      this.txZoneDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tlZoneBtn
      // 
      this.tlZoneBtn.ColumnCount = 4;
      this.tlZoneBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlZoneBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlZoneBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlZoneBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlZoneBtn.Controls.Add(this.pbZoneSave, 3, 0);
      this.tlZoneBtn.Controls.Add(this.pbZoneStart, 1, 0);
      this.tlZoneBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tlZoneBtn.Location = new System.Drawing.Point(0, 348);
      this.tlZoneBtn.Margin = new System.Windows.Forms.Padding(0);
      this.tlZoneBtn.Name = "tlZoneBtn";
      this.tlZoneBtn.RowCount = 1;
      this.tlZoneBtn.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlZoneBtn.Size = new System.Drawing.Size(406, 30);
      this.tlZoneBtn.TabIndex = 13;
      // 
      // pbZoneSave
      // 
      this.pbZoneSave.Location = new System.Drawing.Point(323, 3);
      this.pbZoneSave.Name = "pbZoneSave";
      this.pbZoneSave.Size = new System.Drawing.Size(80, 24);
      this.pbZoneSave.TabIndex = 6;
      this.pbZoneSave.Text = "&Sichern...";
      this.pbZoneSave.UseVisualStyleBackColor = true;
      this.pbZoneSave.Click += new System.EventHandler(this.pbMzSave_Click);
      // 
      // pbZoneStart
      // 
      this.pbZoneStart.Location = new System.Drawing.Point(217, 3);
      this.pbZoneStart.Name = "pbZoneStart";
      this.pbZoneStart.Size = new System.Drawing.Size(80, 24);
      this.pbZoneStart.TabIndex = 7;
      this.pbZoneStart.Text = "&Rundfahrt";
      this.pbZoneStart.UseVisualStyleBackColor = true;
      this.pbZoneStart.Click += new System.EventHandler(this.pbMzStart_Click);
      // 
      // tpAct
      // 
      this.tpAct.Controls.Add(this.tlpAct);
      this.tpAct.Location = new System.Drawing.Point(4, 29);
      this.tpAct.Name = "tpAct";
      this.tpAct.Size = new System.Drawing.Size(406, 378);
      this.tpAct.TabIndex = 10;
      this.tpAct.Text = "ActLog";
      this.tpAct.UseVisualStyleBackColor = true;
      // 
      // tlpAct
      // 
      this.tlpAct.ColumnCount = 3;
      this.tlpAct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpAct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpAct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlpAct.Controls.Add(this.pbActCsv, 0, 1);
      this.tlpAct.Controls.Add(this.lvActLog, 0, 0);
      this.tlpAct.Controls.Add(this.pbActLog, 1, 1);
      this.tlpAct.Controls.Add(this.lActHint, 0, 1);
      this.tlpAct.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpAct.Location = new System.Drawing.Point(0, 0);
      this.tlpAct.Margin = new System.Windows.Forms.Padding(0);
      this.tlpAct.Name = "tlpAct";
      this.tlpAct.RowCount = 2;
      this.tlpAct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpAct.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpAct.Size = new System.Drawing.Size(406, 378);
      this.tlpAct.TabIndex = 0;
      // 
      // pbActCsv
      // 
      this.pbActCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.pbActCsv.Enabled = false;
      this.pbActCsv.Location = new System.Drawing.Point(197, 351);
      this.pbActCsv.Name = "pbActCsv";
      this.pbActCsv.Size = new System.Drawing.Size(80, 24);
      this.pbActCsv.TabIndex = 3;
      this.pbActCsv.Text = "&CSV ...";
      this.pbActCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbActCsv.UseVisualStyleBackColor = true;
      this.pbActCsv.Click += new System.EventHandler(this.pbActCsv_Click);
      // 
      // lvActLog
      // 
      this.lvActLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvActLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chActStamp,
            this.chActState,
            this.chActError,
            this.chActCharge,
            this.chActMiss});
      this.tlpAct.SetColumnSpan(this.lvActLog, 3);
      this.lvActLog.FullRowSelect = true;
      this.lvActLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvActLog.HideSelection = false;
      this.lvActLog.Location = new System.Drawing.Point(0, 0);
      this.lvActLog.Margin = new System.Windows.Forms.Padding(0);
      this.lvActLog.Name = "lvActLog";
      this.lvActLog.ShowItemToolTips = true;
      this.lvActLog.Size = new System.Drawing.Size(406, 348);
      this.lvActLog.TabIndex = 0;
      this.lvActLog.UseCompatibleStateImageBehavior = false;
      this.lvActLog.View = System.Windows.Forms.View.Details;
      // 
      // chActStamp
      // 
      this.chActStamp.Text = "Date Time";
      this.chActStamp.Width = 120;
      // 
      // chActState
      // 
      this.chActState.Text = "State";
      this.chActState.Width = 120;
      // 
      // chActError
      // 
      this.chActError.Text = "Error";
      this.chActError.Width = 80;
      // 
      // chActCharge
      // 
      this.chActCharge.Text = "C";
      this.chActCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chActCharge.Width = 25;
      // 
      // chActMiss
      // 
      this.chActMiss.Text = "M";
      this.chActMiss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chActMiss.Width = 25;
      // 
      // pbActLog
      // 
      this.pbActLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.pbActLog.Enabled = false;
      this.pbActLog.Image = global::DesktopApp.AppRes.refresh16;
      this.pbActLog.Location = new System.Drawing.Point(283, 351);
      this.pbActLog.Name = "pbActLog";
      this.pbActLog.Size = new System.Drawing.Size(120, 24);
      this.pbActLog.TabIndex = 1;
      this.pbActLog.Text = "&Poll";
      this.pbActLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.pbActLog.UseVisualStyleBackColor = true;
      this.pbActLog.Click += new System.EventHandler(this.pbActLog_Click);
      // 
      // lActHint
      // 
      this.lActHint.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lActHint.AutoSize = true;
      this.lActHint.Location = new System.Drawing.Point(3, 353);
      this.lActHint.Name = "lActHint";
      this.lActHint.Size = new System.Drawing.Size(183, 20);
      this.lActHint.TabIndex = 2;
      this.lActHint.Text = "Login erforderlich ...";
      // 
      // tpPlugin
      // 
      this.tpPlugin.Controls.Add(this.spPlugin);
      this.tpPlugin.Controls.Add(this.tlPluginBtn);
      this.tpPlugin.Location = new System.Drawing.Point(4, 29);
      this.tpPlugin.Name = "tpPlugin";
      this.tpPlugin.Size = new System.Drawing.Size(406, 378);
      this.tpPlugin.TabIndex = 6;
      this.tpPlugin.Text = "Plugin";
      this.tpPlugin.UseVisualStyleBackColor = true;
      // 
      // spPlugin
      // 
      this.spPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spPlugin.Location = new System.Drawing.Point(0, 0);
      this.spPlugin.Margin = new System.Windows.Forms.Padding(0);
      this.spPlugin.Name = "spPlugin";
      this.spPlugin.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // spPlugin.Panel1
      // 
      this.spPlugin.Panel1.Controls.Add(this.lvPlugin);
      // 
      // spPlugin.Panel2
      // 
      this.spPlugin.Panel2.Controls.Add(this.pgPlugin);
      this.spPlugin.Size = new System.Drawing.Size(406, 348);
      this.spPlugin.SplitterDistance = 164;
      this.spPlugin.TabIndex = 4;
      // 
      // lvPlugin
      // 
      this.lvPlugin.CheckBoxes = true;
      this.lvPlugin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPluginScript,
            this.chPluginDesc});
      this.lvPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvPlugin.FullRowSelect = true;
      this.lvPlugin.HideSelection = false;
      this.lvPlugin.Location = new System.Drawing.Point(0, 0);
      this.lvPlugin.Margin = new System.Windows.Forms.Padding(2);
      this.lvPlugin.MultiSelect = false;
      this.lvPlugin.Name = "lvPlugin";
      this.lvPlugin.Size = new System.Drawing.Size(406, 164);
      this.lvPlugin.TabIndex = 0;
      this.lvPlugin.UseCompatibleStateImageBehavior = false;
      this.lvPlugin.View = System.Windows.Forms.View.Details;
      this.lvPlugin.SelectedIndexChanged += new System.EventHandler(this.lvPlugin_SelectedIndexChanged);
      // 
      // chPluginScript
      // 
      this.chPluginScript.Text = "Script";
      this.chPluginScript.Width = 130;
      // 
      // chPluginDesc
      // 
      this.chPluginDesc.Text = "Beschreibung";
      this.chPluginDesc.Width = 280;
      // 
      // pgPlugin
      // 
      this.pgPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgPlugin.LineColor = System.Drawing.SystemColors.ControlDark;
      this.pgPlugin.Location = new System.Drawing.Point(0, 0);
      this.pgPlugin.Margin = new System.Windows.Forms.Padding(2);
      this.pgPlugin.Name = "pgPlugin";
      this.pgPlugin.PropertySort = System.Windows.Forms.PropertySort.NoSort;
      this.pgPlugin.Size = new System.Drawing.Size(406, 180);
      this.pgPlugin.TabIndex = 3;
      this.pgPlugin.ToolbarVisible = false;
      // 
      // tlPluginBtn
      // 
      this.tlPluginBtn.ColumnCount = 2;
      this.tlPluginBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlPluginBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tlPluginBtn.Controls.Add(this.pbPluginDoit, 1, 0);
      this.tlPluginBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tlPluginBtn.Location = new System.Drawing.Point(0, 348);
      this.tlPluginBtn.Margin = new System.Windows.Forms.Padding(0);
      this.tlPluginBtn.Name = "tlPluginBtn";
      this.tlPluginBtn.RowCount = 1;
      this.tlPluginBtn.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlPluginBtn.Size = new System.Drawing.Size(406, 30);
      this.tlPluginBtn.TabIndex = 5;
      // 
      // pbPluginDoit
      // 
      this.pbPluginDoit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.pbPluginDoit.Location = new System.Drawing.Point(323, 3);
      this.pbPluginDoit.Name = "pbPluginDoit";
      this.pbPluginDoit.Size = new System.Drawing.Size(80, 24);
      this.pbPluginDoit.TabIndex = 2;
      this.pbPluginDoit.Text = "DoIt";
      this.pbPluginDoit.UseVisualStyleBackColor = true;
      this.pbPluginDoit.Click += new System.EventHandler(this.pbPluginTest_Click);
      // 
      // tpMqtt
      // 
      this.tpMqtt.Controls.Add(this.txMqtt);
      this.tpMqtt.Location = new System.Drawing.Point(4, 29);
      this.tpMqtt.Name = "tpMqtt";
      this.tpMqtt.Size = new System.Drawing.Size(406, 378);
      this.tpMqtt.TabIndex = 7;
      this.tpMqtt.Text = "Mqtt";
      this.tpMqtt.UseVisualStyleBackColor = true;
      // 
      // txMqtt
      // 
      this.txMqtt.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txMqtt.Location = new System.Drawing.Point(0, 0);
      this.txMqtt.Multiline = true;
      this.txMqtt.Name = "txMqtt";
      this.txMqtt.ReadOnly = true;
      this.txMqtt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txMqtt.Size = new System.Drawing.Size(406, 378);
      this.txMqtt.TabIndex = 0;
      // 
      // tpTrace
      // 
      this.tpTrace.Controls.Add(this.rtLog);
      this.tpTrace.Location = new System.Drawing.Point(4, 29);
      this.tpTrace.Name = "tpTrace";
      this.tpTrace.Size = new System.Drawing.Size(406, 378);
      this.tpTrace.TabIndex = 8;
      this.tpTrace.Text = "Trace";
      this.tpTrace.UseVisualStyleBackColor = true;
      // 
      // rtLog
      // 
      this.rtLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtLog.Location = new System.Drawing.Point(0, 0);
      this.rtLog.Margin = new System.Windows.Forms.Padding(2);
      this.rtLog.Name = "rtLog";
      this.rtLog.ReadOnly = true;
      this.rtLog.Size = new System.Drawing.Size(406, 378);
      this.rtLog.TabIndex = 2;
      this.rtLog.Text = "";
      this.rtLog.WordWrap = false;
      // 
      // timer
      // 
      this.timer.Interval = 3000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(414, 411);
      this.Controls.Add(this.tcMain);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "FormMain";
      this.Text = "Landroid/Mission DeskApp";
      this.tpPlan.ResumeLayout(false);
      this.tlPlan.ResumeLayout(false);
      this.tlPlan.PerformLayout();
      this.tlScPerc.ResumeLayout(false);
      this.tlScPerc.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbCfgScPerc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgPlan)).EndInit();
      this.tlCfgScMode.ResumeLayout(false);
      this.tlCfgScMode.PerformLayout();
      this.tlCgRainDelay.ResumeLayout(false);
      this.tlCgRainDelay.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.udCfgRainDelay)).EndInit();
      this.tlScCmd.ResumeLayout(false);
      this.tpState.ResumeLayout(false);
      this.tlDat.ResumeLayout(false);
      this.tlDat.PerformLayout();
      this.tlDatPic.ResumeLayout(false);
      this.tlDatPic.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picWiFi)).EndInit();
      this.tlName.ResumeLayout(false);
      this.pDatAccu.ResumeLayout(false);
      this.tlDatTri.ResumeLayout(false);
      this.tlDatTri.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picPitch)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picRoll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picYaw)).EndInit();
      this.tlDatErrorState.ResumeLayout(false);
      this.tlDatErrorState.PerformLayout();
      this.pDatWork.ResumeLayout(false);
      this.tlDatCmd.ResumeLayout(false);
      this.tpUsr.ResumeLayout(false);
      this.tpUsr.PerformLayout();
      this.tlpUsrSet.ResumeLayout(false);
      this.tlpUsrSet.PerformLayout();
      this.tlpUsrBtn.ResumeLayout(false);
      this.tcMain.ResumeLayout(false);
      this.tpZone.ResumeLayout(false);
      this.tlZone.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgZone)).EndInit();
      this.tlZoneBtn.ResumeLayout(false);
      this.tpAct.ResumeLayout(false);
      this.tlpAct.ResumeLayout(false);
      this.tlpAct.PerformLayout();
      this.tpPlugin.ResumeLayout(false);
      this.spPlugin.Panel1.ResumeLayout(false);
      this.spPlugin.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.spPlugin)).EndInit();
      this.spPlugin.ResumeLayout(false);
      this.tlPluginBtn.ResumeLayout(false);
      this.tpMqtt.ResumeLayout(false);
      this.tpMqtt.PerformLayout();
      this.tpTrace.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.TabPage tpPlan;
    private System.Windows.Forms.TableLayoutPanel tlPlan;
    private System.Windows.Forms.DataGridView dgPlan;
    private System.Windows.Forms.Label lCfgScPerc;
    private System.Windows.Forms.TabPage tpState;
    private System.Windows.Forms.TableLayoutPanel tlDatCmd;
    private System.Windows.Forms.Button pbStart;
    private System.Windows.Forms.Button pbHome;
    private System.Windows.Forms.Button pbPoll;
    private System.Windows.Forms.Button pbStop;
    private System.Windows.Forms.TabPage tpUsr;
    private System.Windows.Forms.TableLayoutPanel tlpUsrBtn;
    private System.Windows.Forms.Button pbLogin;
    private System.Windows.Forms.Button pbDisconnect;
    private System.Windows.Forms.Button pbTest;
    private System.Windows.Forms.TableLayoutPanel tlpUsrSet;
    private System.Windows.Forms.Label txUsrMail;
    private System.Windows.Forms.TextBox edUsrMail;
    private System.Windows.Forms.Label txUsrPass;
    private System.Windows.Forms.TextBox edUsrPass;
    private System.Windows.Forms.Label txUsrName;
    private System.Windows.Forms.TextBox edUsrName;
    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpPlugin;
    private System.Windows.Forms.PropertyGrid pgPlugin;
    private System.Windows.Forms.Button pbPluginDoit;
    private System.Windows.Forms.ListView lvPlugin;
    private System.Windows.Forms.ColumnHeader chPluginScript;
    private System.Windows.Forms.ColumnHeader chPluginDesc;
    private System.Windows.Forms.TabPage tpMqtt;
    private System.Windows.Forms.TableLayoutPanel tlScPerc;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Button pbPlanSave;
    private System.Windows.Forms.Label lCfgRainDelay;
    private System.Windows.Forms.NumericUpDown udCfgRainDelay;
    private System.Windows.Forms.Label lCfgSc;
    private System.Windows.Forms.TableLayoutPanel tlCfgScMode;
    private System.Windows.Forms.Label txCfgScMode;
    private System.Windows.Forms.TableLayoutPanel tlCgRainDelay;
    private System.Windows.Forms.Label txCfgRainDelay;
    private System.Windows.Forms.TableLayoutPanel tlDat;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Panel pDatAccu;
    private System.Windows.Forms.Label txDatAccu;
    private System.Windows.Forms.Label txDatDT;
    private System.Windows.Forms.PictureBox picWiFi;
    private System.Windows.Forms.Label txDatRsi;
    private System.Windows.Forms.Label txUsrUuid;
    private System.Windows.Forms.TextBox edUsrUuid;
    private System.Windows.Forms.Button pbCfgScCorrMP;
    private System.Windows.Forms.Button pbCfgScCorrM3;
    private System.Windows.Forms.Button pbCfgScCorrP3;
    private System.Windows.Forms.TableLayoutPanel tlDatErrorState;
    private System.Windows.Forms.Label txError;
    private System.Windows.Forms.Label txStatus;
    private System.Windows.Forms.Button pbConnect;
    private System.Windows.Forms.TextBox edUsrBroker;
    private System.Windows.Forms.TableLayoutPanel tlDatPic;
    private System.Windows.Forms.Panel pDatWork;
    private System.Windows.Forms.Label txDatWork;
    private System.Windows.Forms.SplitContainer spPlugin;
    private System.Windows.Forms.TableLayoutPanel tlPluginBtn;
    private System.Windows.Forms.TabPage tpTrace;
    private System.Windows.Forms.RichTextBox rtLog;
    private System.Windows.Forms.TableLayoutPanel tlScCmd;
    private System.Windows.Forms.TabPage tpZone;
    private System.Windows.Forms.DataGridView dgZone;
    private System.Windows.Forms.TableLayoutPanel tlZone;
    private System.Windows.Forms.TableLayoutPanel tlZoneBtn;
    private System.Windows.Forms.Button pbZoneSave;
    private System.Windows.Forms.Button pbZoneStart;
    private System.Windows.Forms.Label txZoneDist;
    private System.Windows.Forms.DataGridViewTextBoxColumn chMzStart;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz0;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz2;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz3;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz4;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz5;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz6;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz7;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz8;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chMz9;
    private System.Windows.Forms.DataGridViewTextBoxColumn chMzPerc;
    private System.Windows.Forms.TextBox txMqtt;
    private System.Windows.Forms.Label txDatFW;
    private System.Windows.Forms.TableLayoutPanel tlDatTri;
    private System.Windows.Forms.PictureBox picPitch;
    private System.Windows.Forms.PictureBox picRoll;
    private System.Windows.Forms.PictureBox picYaw;
    private System.Windows.Forms.Label txDatDmp0;
    private System.Windows.Forms.Label txDatDmp1;
    private System.Windows.Forms.Label txDatDmp2;
    private System.Windows.Forms.Label txDatStB;
    private System.Windows.Forms.Label txDatStD;
    private System.Windows.Forms.Label txDatStW;
    private System.Windows.Forms.CheckBox cbOnTop;
    private System.Windows.Forms.DataGridViewTextBoxColumn chScDow;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chScCut;
    private System.Windows.Forms.DataGridViewTextBoxColumn chScBeg;
    private System.Windows.Forms.DataGridViewTextBoxColumn chScMin;
    private System.Windows.Forms.DataGridViewTextBoxColumn chScEnd;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Label txUsrBroker;
    private System.Windows.Forms.Label txUsrMac;
    private System.Windows.Forms.TextBox edUsrMac;
    private System.Windows.Forms.Label lDatFW;
    private System.Windows.Forms.Label lDatSP;
    private System.Windows.Forms.Label txDatSP;
    private System.Windows.Forms.Label txUsrBoard;
    private System.Windows.Forms.TextBox edUsrBoard;
    private System.Windows.Forms.TabPage tpAct;
    private System.Windows.Forms.TableLayoutPanel tlpAct;
    private System.Windows.Forms.ListView lvActLog;
    private System.Windows.Forms.ColumnHeader chActStamp;
    private System.Windows.Forms.ColumnHeader chActState;
    private System.Windows.Forms.ColumnHeader chActError;
    private System.Windows.Forms.ColumnHeader chActCharge;
    private System.Windows.Forms.ColumnHeader chActMiss;
    private System.Windows.Forms.Button pbActLog;
    private System.Windows.Forms.Label lActHint;
    private System.Windows.Forms.TableLayoutPanel tlName;
    private System.Windows.Forms.Label txName;
    private System.Windows.Forms.Label tx4G;
    private System.Windows.Forms.Label txRL;
    private System.Windows.Forms.Label txDF;
    private System.Windows.Forms.Label txUS;
    private System.Windows.Forms.TrackBar tbCfgScPerc;
    private System.Windows.Forms.Button pbCfgScCorrP5;
    private System.Windows.Forms.Button pbCfgScCorrM5;
    private System.Windows.Forms.Button pbPlanCopy;
    private System.Windows.Forms.Label txUsrApi;
    private System.Windows.Forms.ComboBox cbUsrApi;
    private System.Windows.Forms.Button pbActCsv;
  }
}

