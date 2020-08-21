using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using MqttJson;

namespace DesktopApp {
  partial class FormMain : Form {
    private LsClient _lsc = new LsClient();
    List<DateTime> _calls = new List<DateTime>();
    private LsEstimatedTimes _vpm;
    
    private LsJson _settings;
    private string _cfgname = "";
    private string CfgFile { get { return Path.Combine(Application.StartupPath, string.Format("Config{0}.json", _cfgname)); } }
    private string VpmFile { get { return Path.Combine(Application.StartupPath, "EstimatedTimes.json"); } }
    private DateTime _lastWrite = DateTime.Now;
    private int _bladeLast = 0;
    private bool _cmdInOut = false;

    enum OS { Unknown, Windows, Linux, Darwin };
    OS _os = OS.Unknown;
    private NotifyIcon notifyIcon = null;

    /// <summary>Serialize object <paramref name="obj" /> to json string</summary>
    /// <param name="obj">Object to serialize</param>
    /// <returns>Returns the json string represantation</returns>
    private string GetJson(object obj) {
      string str = null;

      if( obj != null ) {
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(obj.GetType());

        using( MemoryStream ms = new MemoryStream() ) {
          dcjs.WriteObject(ms, obj);
          str = Encoding.UTF8.GetString(ms.ToArray());
        }
      }
      return str;
    }

    #region FormMain
    public FormMain() {
      string api = ConfigurationManager.AppSettings["WebApi"], oem;
      string[] args = Environment.GetCommandLineArgs();

      InitializeComponent();

      _cmdInOut = bool.Parse(ConfigurationManager.AppSettings["CommandInOut"]);

      if( args.Length > 1 ) _cfgname = "." + args[1];
      _os = Path.DirectorySeparatorChar == '\\' ? OS.Windows : _os = OS.Linux;
      try {
        notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);

        notifyIcon.Icon = this.Icon;
        if( api.Contains("worx") ) oem = "Landroid";
        else if( api.Contains("kress") ) oem = "Mission";
        else if( api.Contains("landxcape") ) oem = "Landxcape";
        else oem = "NoName";
        notifyIcon.Text = string.Format("{0} DeskApp", oem);
        notifyIcon.Visible = true;
        notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
      } catch {
        notifyIcon = null;
        _os = OS.Darwin;
      }

      this.Text = string.Format( "{0} DeskApp - V{1}", api.Contains("kress") ? "Mission" : "Landroid", Application.ProductVersion);
      if( DesignMode ) return;

      _lsc.Err = Err;
      _lsc.Log = Log;
      _lsc.Recv = Recv;
      _lsc.Data.Cfg.Language = "..";
      _lsc.Data.Cfg.Date = "07/11/1975";
      _lsc.Data.Cfg.Time = "00:00:00";
      _lsc.Data.Cfg.SerialNo = "123";
      _lsc.Data.Dat.Orient = new float[3];
      _lsc.Data.Dat.MacAdr = "ABC";

      //rtDat.SelectionTabs = new int[] { 150 };
#if DEBUG
      pbTest.Enabled = pbTest.Visible = true;
      pbConnect.Enabled = true;
#endif
      pbStart.Enabled = pbStop.Enabled = pbHome.Enabled = pbPoll.Enabled = false;

      _lsc.Data.Cfg.Schedule.Mode = 1;
      _lsc.Data.Cfg.Schedule.Days = new List<List<object>>();
      _lsc.Data.Cfg.Schedule.DDays = new List<List<object>>();
      for( int idx = 0; idx < 14; idx++ ) {
        dgSchedulePlan.Rows.Add();
        if( idx % 2 == 0 ) {
          _lsc.Data.Cfg.Schedule.Days.Add(new List<object> { "00:00", 0, 0 });
          dgSchedulePlan.Rows[idx].Cells[chScDow.Index].Value = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName((DayOfWeek)(idx / 2));
        } else {
          _lsc.Data.Cfg.Schedule.DDays.Add(new List<object> { "00:00", 0, 0 });
          dgSchedulePlan.Rows[idx].Visible = false;
        }
      }
      dgSchedulePlan.Height = dgSchedulePlan.ColumnHeadersHeight + 7*dgSchedulePlan.Rows[0].Height + 2*SystemInformation.BorderSize.Height;
      pbPlanSave.Enabled = false;

      for( int idx = 0; idx < 4; idx++ ) dgMultiZone.Rows.Add();
      _lsc.Data.Cfg.MultiZones = new int[] { 0, 0, 0, 0 };
      _lsc.Data.Cfg.MultiZonePercs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      dgMultiZone.Height = dgMultiZone.ColumnHeadersHeight + 4*dgMultiZone.Rows[0].Height + 2*SystemInformation.BorderSize.Height;
      pbZoneSave.Enabled = pbZoneStart.Enabled = false;
    }
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      tpUsr.Text   = Ressource.Get("da_user");
      txUsrMail.Text = Ressource.Get("da_user_email");
      txUsrPass.Text = Ressource.Get("da_user_pass");
      txUsrName.Text = Ressource.Get("da_user_name");
      cbOnTop.Text = Ressource.Get("da_user_top");
      pbLogin.Text = Ressource.Get("da_user_login");
      pbConnect.Text = Ressource.Get("da_user_con");
      pbDisconnect.Text = Ressource.Get("da_user_dis");

      tpState.Text = Ressource.Get("da_state");
      toolTip.SetToolTip(txDatStB, Ressource.Get("da_state_blade_info"));
      toolTip.SetToolTip(txDatStD, Ressource.Get("da_state_dist_info"));
      toolTip.SetToolTip(txDatStW, Ressource.Get("da_state_work_info"));
      pbStart.Text = Ressource.Get("da_state_start");
      pbHome.Text = Ressource.Get("da_state_home");
      pbStop.Text = Ressource.Get("da_state_stop");
      pbPoll.Text = Ressource.Get("da_state_poll");

      tpPlan.Text  = Ressource.Get("da_plan");
      lCfgSc.Text = Ressource.Get("da_plan_mode");
      dgSchedulePlan.CellValueChanged -= dgSchedulePlan_CellValueChanged;
      chScDow.HeaderText = Ressource.Get("da_plan_dow");
      chScCut.HeaderText = Ressource.Get("da_plan_cut");
      chScBeg.HeaderText = Ressource.Get("da_plan_beg");
      chScMin.HeaderText = Ressource.Get("da_plan_min");
      chScEnd.HeaderText = Ressource.Get("da_plan_end");
      dgSchedulePlan.CellValueChanged += dgSchedulePlan_CellValueChanged;
      lCfgSc.Text = Ressource.Get("da_plan_mode");
      lCfgScPerc.Text = Ressource.Get("da_plan_perc");
      lCfgRainDelay.Text = Ressource.Get("da_plan_rain");
      pbPlanSave.Text = Ressource.Get("da_plan_save");

      tpZone.Text  = Ressource.Get("da_zone");
      dgMultiZone.CellValueChanged -= dgMultiZone_CellValueChanged;
      chMzStart.HeaderText = Ressource.Get("da_zone_start");
      chMzPerc.HeaderText = Ressource.Get("da_zone_perc");
      dgMultiZone.CellValueChanged += dgMultiZone_CellValueChanged;
      pbZoneStart.Text = Ressource.Get("da_zone_train");
      pbZoneSave.Text = Ressource.Get("da_zone_save");

      tpAct.Text  = Ressource.Get("da_act");
      chActStamp.Text = Ressource.Get("da_act_stamp");
      chActState.Text = Ressource.Get("da_act_state");
      chActError.Text = Ressource.Get("da_act_error");
      lActHint.Text =  Ressource.Get("da_act_hint");
      pbActLog.Text = Ressource.Get("da_act_poll");

      tpPlugin.Text  = Ressource.Get("da_plug");
      chPluginScript.Text = Ressource.Get("da_plug_code");
      chPluginDesc.Text = Ressource.Get("da_plug_desc");

      if( File.Exists(CfgFile) ) {
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsJson));
        FileStream fs = new FileStream(CfgFile, FileMode.Open);

        try {
          _settings = (LsJson)dcjs.ReadObject(fs);

          edUsrUuid.Text = _settings.Uuid;
          edUsrMail.Text = _settings.Email;
          edUsrPass.Text = _settings.Password;
          edUsrName.Text = _settings.Name;
          edUsrBroker.Text = _settings.Broker;
          edUsrBoard.Text = _settings.Board;
          edUsrMac.Text = _settings.MacAdr;
          cbOnTop.Checked = _settings.Top;
          _bladeLast = _settings.Blade;

          Point p = new Point(_settings.X, _settings.Y);
          if( SystemInformation.VirtualScreen.Contains(p) ) Location = p;
          Size s = new Size(_settings.W, _settings.H);
          if( s.Width > 300 && s.Height > 300 ) Size = s;
        } catch( Exception ex ) { rtLog.AppendText(string.Format("Exception Config.json: '{0}'\r\n", ex.ToString())); }
        fs.Close();
      }
      if( string.IsNullOrEmpty(edUsrUuid.Text) ) edUsrUuid.Text = System.Guid.NewGuid().ToString();

      if( File.Exists(VpmFile) ) {
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsEstimatedTimes));
        FileStream fs = new FileStream(VpmFile, FileMode.Open);

        try {
          _vpm = (LsEstimatedTimes)dcjs.ReadObject(fs);
        } catch( Exception ex ) { rtLog.AppendText(string.Format("Exception EstimatedTimes.json: '{0}'\r\n", ex.ToString())); }
        fs.Close();
      }

      LoadPlugins();

      if( _lsc.LoadAWS() && !string.IsNullOrEmpty(edUsrBroker.Text) && !string.IsNullOrEmpty(edUsrBoard.Text) && !string.IsNullOrEmpty(edUsrMac.Text) ) {
        pbConnect_Click(this, new EventArgs());
      }
    }
    protected override void OnFormClosing(FormClosingEventArgs e) {
      base.OnFormClosing(e);

      if( e.CloseReason == CloseReason.UserClosing ) {
        LsJson lsj;

        lsj.Uuid = edUsrUuid.Text;
        lsj.Email = edUsrMail.Text;
        lsj.Password = edUsrPass.Text;
        lsj.Name = edUsrName.Text;
        lsj.Broker = edUsrBroker.Text;
        lsj.Board = edUsrBoard.Text;
        lsj.MacAdr = edUsrMac.Text;
        lsj.Top = cbOnTop.Checked;
        lsj.Plugins = new List<string>();
        lsj.X = Location.X;
        lsj.Y = Location.Y;
        lsj.W = Width;
        lsj.H = Height;
        lsj.Blade = _bladeLast;
        foreach( ListViewItem lvi in lvPlugin.Items ) if( lvi.Checked ) lsj.Plugins.Add(lvi.Text);
        if( !_settings.Equals(lsj) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsJson));
          FileStream fs = new FileStream(Path.Combine(Application.StartupPath, CfgFile), FileMode.Create);

          dcjs.WriteObject(fs, lsj);
          fs.Close();
        }
      }
    }
    protected override void OnClosed(EventArgs e) {
      _lsc.Exit();
      if( notifyIcon != null ) notifyIcon.Visible = false;

      base.OnClosed(e);
    }
    protected override void OnResize(EventArgs e) {
      base.OnResize(e);
      if( notifyIcon != null ) {
        if( WindowState == FormWindowState.Minimized ) {
          ShowInTaskbar = false;
          Hide();
        }
      }
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      switch( keyData ) {
        case Keys.F2:
          this.Refresh();
          toolTip.SetToolTip(tcMain, "F2 FormMain.Refresh");
        break;
        case Keys.F3:
          tcMain.Refresh();
          toolTip.SetToolTip(tcMain, "F3 TabControl.Refresh");
        break;
        case Keys.F4:
          tcMain.SelectedTab.Refresh();
          toolTip.SetToolTip(tcMain, "F4 TabPage.Refresh");
        break;
        case Keys.F5:
          foreach( Control c in tcMain.SelectedTab.Controls ) c.Refresh();
          toolTip.SetToolTip(tcMain, "F5 TabPage.Controls.Refresh");
        break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    private void notifyIcon_DoubleClick(object sender, EventArgs e) {
      //notifyIcon.Visible = false;
      ShowInTaskbar = true;
      Show();
      WindowState = FormWindowState.Normal;
    }
    #endregion

    private void tcMain_SelectedIndexChanged(object sender, EventArgs e) {
      if( tcMain.SelectedTab == tpState ) RefreshState();
      if( tcMain.SelectedTab == tpPlan ) {
        tpPlan.Tag = _lsc.Data.Cfg;
        RefreshPlan();
      }
      if( tcMain.SelectedTab == tpZone ) {
        tpZone.Tag = _lsc.Data.Cfg;
        RefreshZone();
      }
      if( tcMain.SelectedTab == tpMqtt ) txMqtt.Text = txMqtt.Tag as string;

      //if( _os == OS.Darwin ) foreach(Control c in tcMain.SelectedTab.Controls) c.Refresh();
    }

    #region FirstPage
    private void pbTest_Click(object sender, EventArgs e) {
    }
    private void pbUsrLogin_Click(object sender, EventArgs e) {
      if( !_lsc.Login(edUsrMail.Text, edUsrPass.Text, edUsrUuid.Text) ) return;

      edUsrBroker.Text = _lsc.Broker;
      if( _lsc.Products.Count > 0 ) {
        LsProductItem lspi = new LsProductItem();

        try {
          lspi = _lsc.Products.Find(pi => pi.Name == edUsrName.Text);
        } catch {
        }
        if( string.IsNullOrEmpty(lspi.Name) ) {
          lspi = _lsc.Products[0];
          if( _lsc.Products.Count > 1 ) {
            FormChoice fc = new FormChoice(_lsc.Products);

            if( fc.ShowDialog() == DialogResult.OK && fc.SelectedIndex != -1 ) lspi = _lsc.Products[fc.SelectedIndex];
          }
        }
        edUsrName.Text = lspi.Name;
        edUsrBoard.Text = lspi.Topic.CmdIn.Substring(0, lspi.Topic.CmdIn.IndexOf('/'));
        edUsrMac.Text = lspi.MacAdr;
      }

      if( !string.IsNullOrEmpty(edUsrBroker.Text) && !string.IsNullOrEmpty(edUsrBoard.Text) && !string.IsNullOrEmpty(edUsrMac.Text) ) {
        pbLogin.Enabled = false;
        if( !_lsc.Connected ) pbConnect.Enabled = true;
        pbActLog.Enabled = true; lActHint.Text = null;
      }
    }
    private void pbConnect_Click(object sender, EventArgs e) {
      string png ;

      if( !_lsc.Start(edUsrBroker.Text, edUsrUuid.Text, edUsrBoard.Text, edUsrMac.Text) ) return;
      pbConnect.Enabled = false;
      pbDisconnect.Enabled = true;

      /*
      Image i = pictureBox.Image;
      Graphics g = Graphics.FromImage(i);
      Rectangle r = new Rectangle(120, 220, 280, 64);
      Font f = new Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      StringFormat sf = new StringFormat(StringFormat.GenericTypographic);

      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;
      g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
      //g.DrawRectangle(Pens.White, r);
      g.DrawString(edUsrName.Text, f, Brushes.Yellow, r, sf);
      pictureBox.Image = i;
      */

      txName.Text = edUsrName.Text;
      png = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, edUsrName.Text + ".png");
      if( File.Exists(png) ) {
        Image img = Image.FromFile(png);

        pictureBox.Image = img;
      }
      tcMain.SelectedTab = tpState;
    }
    private void pbDisconnect_Click(object sender, EventArgs e) {
      _lsc.Exit();

      pbConnect.Enabled = true;
      pbDisconnect.Enabled = false;
      tlPlan.Enabled = false;
    }

    private void cbOnTop_CheckedChanged(object sender, EventArgs e) {
      TopMost = cbOnTop.Checked;
    }
    #endregion

    #region Status
    private void pStatusAccu_Paint(object sender, PaintEventArgs e) {
      int x = 10 + (int)((pDatAccu.Width - 20) * _lsc.Data.Dat.Battery.Perc / 100.0F);

      e.Graphics.DrawImage(AppRes.marker_blue, x - AppRes.marker_blue.Width/2, 1);
      if( _lsc.Data.Dat.Battery.Charging == ChargeCoge.CHARGING ) e.Graphics.DrawImage(AppRes.bt_charging, pDatAccu.Width-40, 2);
    }
    private void txDatStB_DoubleClick(object sender, EventArgs e) {
      _bladeLast = _lsc.Data.Dat.Statistic.Blade;
      RefreshBlade();
    }
    private void txDatDT_DoubleClick(object sender, EventArgs e) {
      DateTime dt = DateTime.Now;
      string d = dt.ToString("dd/MM/yyyy"), t = dt.ToString("HH:mm:ss");

      _lsc.Publish("{\"tm\":\"" + t + "\",\"dt\":\"" + dt + "\"}");
    }
    private void pbStart_Click(object sender, EventArgs e) {
      _lsc.Publish("{\"cmd\":1}");
    }
    private void pbStop_Click(object sender, EventArgs e) {
      string txt = Ressource.Get("da_warn_stop");

      if( MessageBox.Show(txt, "Stop Landroid S", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK )
        _lsc.Publish("{\"cmd\":2}");
    }
    private void pbHome_Click(object sender, EventArgs e) {
      _lsc.Publish("{\"cmd\":3}"); // Home
    }
    private void pbDatPoll_Click(object sender, EventArgs e) {
      _lsc.Poll();
      pbPoll.Enabled = false;
      //rtLog.AppendText(string.Format("Mqtt publish dat '{0}'\r\n", msgId));
    }
    private string FormatTime(int t) { return TimeSpan.FromMinutes(t).ToString(@"d\d\ h\h\ m\m");  }
    private void RefreshBlade() {
      toolTip.SetToolTip(txDatStB, string.Format("{0} {1}", Ressource.Get("da_state_blade_info"), FormatTime(_lsc.Data.Dat.Statistic.Blade - _bladeLast)));
    }
    void RefreshState() {
      if( string.IsNullOrEmpty(_lsc.Json) ) return;

      Config c = _lsc.Data.Cfg;
      Data d = _lsc.Data.Dat;
      Battery b = d.Battery;
      Statistic s = d.Statistic;
      string dts = string.Format("{0} {1}", c.Date, c.Time); // parsable DateTime string
      DateTime dt = DateTime.ParseExact(dts, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

      try {
        Color fc;

        txError.Text = GetError(d);
        if( d.LastError == ErrorCode.RAINING ) {
          txError.ForeColor = Color.Aqua;
          if( d.Rain != null && d.Rain.State == 0 ) {
            txError.Text += string.Format(" {0} min", d.Rain.Counter);
          }
        } else txError.ForeColor = Color.Red;
        txStatus.Text = GetState(d, out fc);
        txStatus.ForeColor = fc;
      } catch(Exception ex) {
        Log("State " + ex, 9);
      }

      try {
        if(Math.Abs(d.RecvSignal) < 50) picWiFi.Image = AppRes.rssi_0;
        else if(Math.Abs(d.RecvSignal) < 60) picWiFi.Image = AppRes.rssi_1;
        else if(Math.Abs(d.RecvSignal) < 70) picWiFi.Image = AppRes.rssi_2;
        else picWiFi.Image = AppRes.rssi_3;
        txDatRsi.Text = string.Format("{0}", d.RecvSignal);
      } catch(Exception ex) {
        Log("WiFi " + ex, 9);
      }

      try {
        lDatSP.Visible = txDatSP.Visible = c.MultiZones[0] > 0;
        if( txDatSP.Visible ) txDatSP.Text = string.Format("{0}", c.MultiZonePercs[d.LastZone]+1);
      } catch(Exception ex) {
        Log("SP " + ex, 9);
      }

      try {
        txDatFW.Text = d.Firmware.ToString(CultureInfo.InvariantCulture);
      } catch(Exception ex) {
        Log("FW " + ex, 9);
      }

      try {
        if( d.ModulesD != null ) {
          if( d.ModulesD.US != null ) {
            txUS.Visible = true;
            txUS.ForeColor = d.ModulesD.US.State == "ok" ? Color.LawnGreen : Color.Orange;
          }
          if( d.ModulesD.DF != null ) {
            txDF.Visible = true;
            txDF.ForeColor = d.ModulesD.DF.State == "ok" ? Color.LawnGreen : Color.Orange;
          }
          if( d.ModulesD.G4 != null ) {
            tx4G.Visible = true;
            tx4G.ForeColor = d.ModulesD.G4.State == "ok" ? Color.LawnGreen : Color.Orange;
          }
          if( d.ModulesD.RL != null ) {
            txRL.Visible = true;
            txRL.ForeColor = d.ModulesD.RL.State == "ok" ? Color.LawnGreen : Color.Orange;
          }
        } else {
          txUS.Visible = txDF.Visible = tx4G.Visible = txRL.Visible = false;
        }
      } catch( Exception ex ) {
        Log("Modules " + ex, 9);
      }

      try {
        int idx = (int)dt.DayOfWeek;
        TimeSpan beg = TimeSpan.ParseExact(c.Schedule.Days[idx][0].ToString(), @"hh\:mm", CultureInfo.InvariantCulture);
        int min = (int)c.Schedule.Days[idx][1];
        int dur = min + min * c.Schedule.Perc / 100;
        TimeSpan end = beg + TimeSpan.FromMinutes(dur);
        TimeSpan cur = TimeSpan.ParseExact(c.Time, @"hh\:mm\:ss", CultureInfo.InvariantCulture);
        int perc;

        if( c.Schedule.DDays != null ) {
          TimeSpan beg2 = TimeSpan.ParseExact(c.Schedule.DDays[idx][0].ToString(), @"hh\:mm", CultureInfo.InvariantCulture);
          int min2 = (int)c.Schedule.Days[idx][1];

          if( (beg2.Hours != 0 || beg2.Minutes != 0) && min2 > 0 ) {
            end = beg2 + TimeSpan.FromMinutes(min2);
            dur = (int)(end - beg).TotalMinutes; // no perc
          }
        }
        if(cur < beg) perc = 0;
        else if(cur > end) perc = 100;
        else perc = (int)(cur - beg).TotalMinutes * 100 / dur;
        txDatWork.Text = string.Format(@"{0}: {1:hh\:mm}-{2:hh\:mm} {3}%", Ressource.Get("da_state_daywork"), beg, end, perc);
      } catch(Exception ex) {
        Log("Work " + ex, 9);
      }

      try {
        float min = 0.0F;

        txDatAccu.Text = string.Format("{0}: {1}% {2}V {3}°", Ressource.Get("da_state_accu"), b.Perc, b.Volt, b.Temp);
        if( d.LastState == StatusCode.HOME ) {
          if( b.Charging == ChargeCoge.CHARGED && b.Volt <= _vpm.HomeOff.Beg && b.Volt >= _vpm.HomeOff.End )
            min = (b.Volt - _vpm.HomeOff.End) / _vpm.HomeOff.VoltPerMin;
          if( b.Charging == ChargeCoge.CHARGING && b.Volt <= _vpm.HomeOn.End && b.Volt >= _vpm.HomeOn.Beg )
            min = (_vpm.HomeOn.End - b.Volt) / _vpm.HomeOn.VoltPerMin;
        }
        if( d.LastState == StatusCode.GRASS_CUTTING && b.Volt <= _vpm.Mowing.Beg && b.Volt >= _vpm.Mowing.End )
          min = (b.Volt - _vpm.Mowing.End) / _vpm.Mowing.VoltPerMin;
        if( min > 0.0F ) txDatAccu.Text += " ~ " + TimeSpan.FromMinutes(min).ToString(@"h\:mm");
        pDatAccu.Invalidate();
      } catch(Exception ex) {
        Log("Accu " + ex, 9);
      }

      try {
        txDatDmp0.Text = string.Format("{0}: {1}°", Ressource.Get("da_state_pitch"), d.Orient[0]);
        txDatDmp1.Text = string.Format("{0}: {1}°", Ressource.Get("da_state_roll"), d.Orient[1]);
        txDatDmp2.Text = string.Format("{0}: {1}°", Ressource.Get("da_state_yaw"), d.Orient[2]);
        txDatStB.Text = string.Format("{0}: {1}", Ressource.Get("da_state_blade"), FormatTime(s.Blade));
        txDatStD.Text = string.Format("{0}: {1:n0}m", Ressource.Get("da_state_dist"), s.Distance);
        txDatStW.Text = string.Format("{0}: {1}", Ressource.Get("da_state_work"), FormatTime(s.WorkTime));
        RefreshBlade();
      } catch(Exception ex) {
        Log("PRYS " + ex, 9);
      }

      txDatDT.Text = string.Format("{0}: {1}", Ressource.Get("da_state_last"), dt); //? _msgId

      if( _lsc.Connected ) {
        pbPoll.Enabled = true;
        pbStart.Enabled = d.LastState == StatusCode.HOME || d.LastState == StatusCode.PAUSE;
        pbHome.Enabled = d.LastState == StatusCode.GRASS_CUTTING || d.LastState == StatusCode.PAUSE;
        pbStop.Enabled = !(d.LastState == StatusCode.HOME || d.LastState == StatusCode.IDLE || d.LastState == StatusCode.PAUSE);
        pbZoneStart.Enabled = d.LastState == StatusCode.HOME;
      }
    }
    #endregion

    #region Plan
    private void RefreshPlan() {
      if( tpPlan.Tag is Config ) {
        Config cfg = (Config)tpPlan.Tag;

        //if( cfg.Schedule.Mode == 1 ) {
          Schedule sc = cfg.Schedule;

          dgSchedulePlan.CellValueChanged -= dgSchedulePlan_CellValueChanged;
          txCfgScMode.Text = string.Format("({0})", sc.Mode);
          if( sc.Days != null ) {
            for( int idx = 0; idx < 7; idx++ ) {
              dgSchedulePlan.Rows[2*idx].Cells[chScCut.Index].Value = (int)sc.Days[idx][2] == 1;
              dgSchedulePlan.Rows[2*idx].Cells[chScBeg.Index].Value = sc.Days[idx][0];
              dgSchedulePlan.Rows[2*idx].Cells[chScMin.Index].Value = (int)sc.Days[idx][1];
            }
          }
          if( sc.DDays != null ) { // DoubleScheduler
            for( int idx = 0; idx < 7; idx++ ) {
              dgSchedulePlan.Rows[2*idx+1].Visible = true;
              dgSchedulePlan.Rows[2*idx+1].Cells[chScCut.Index].Value = (int)sc.DDays[idx][2] == 1;
              dgSchedulePlan.Rows[2*idx+1].Cells[chScBeg.Index].Value = sc.DDays[idx][0];
              dgSchedulePlan.Rows[2*idx+1].Cells[chScMin.Index].Value = (int)sc.DDays[idx][1];
            }
          }
          try {
            tbCfgScPerc.Value = sc.Perc;
          } catch {
            tbCfgScPerc.Value = sc.Perc > 0 ? 100 : -100;
          }
          RefreshCfgScEnd();
          dgSchedulePlan.CellValueChanged += dgSchedulePlan_CellValueChanged;
        //}

        udCfgRainDelay.Value = cfg.RainDelay;
      }
    }
    private void RefreshCfgScEnd() {
      toolTip.SetToolTip(tbCfgScPerc, string.Format("{0}%", tbCfgScPerc.Value));

      foreach( DataGridViewRow row in dgSchedulePlan.Rows ) {
        if( row.Visible ) {
          TimeSpan beg = TimeSpan.ParseExact(row.Cells[chScBeg.Index].Value.ToString(), "hh\\:mm", CultureInfo.InvariantCulture);
          int dur = int.Parse(row.Cells[chScMin.Name].Value.ToString());
          TimeSpan end = beg + TimeSpan.FromMinutes(dur + dur * tbCfgScPerc.Value/100.0);

          dgSchedulePlan.CellValueChanged -= dgSchedulePlan_CellValueChanged;
          row.Cells[chScEnd.Name].Value = end.ToString("hh\\:mm");
          dgSchedulePlan.CellValueChanged += dgSchedulePlan_CellValueChanged;
        }
      }
      chScEnd.ReadOnly = tbCfgScPerc.Value != 0;
    }

    private void dgSchedulePlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
      dgSchedulePlan.Rows[e.RowIndex].ErrorText = null;
      if( e.ColumnIndex == chScBeg.Index ) {
        TimeSpan ts;

        if( !TimeSpan.TryParseExact(e.FormattedValue.ToString(), "hh\\:mm", CultureInfo.InvariantCulture, out ts) ) {
          dgSchedulePlan.Rows[e.RowIndex].ErrorText = Ressource.Get("da_error_beg");
          e.Cancel = true;
        }
      } else if( e.ColumnIndex == chScMin.Index ) {
        int m;

        if( !(int.TryParse(e.FormattedValue.ToString(), out m) && 0 <= m && m < 24*60) ) {
          dgSchedulePlan.Rows[e.RowIndex].ErrorText = Ressource.Get("da_error_min");
          e.Cancel = true;
        }
      } else if( e.ColumnIndex == chScEnd.Index ) {
        TimeSpan ts;

        if( !TimeSpan.TryParseExact(e.FormattedValue.ToString(), "hh\\:mm", CultureInfo.InvariantCulture, out ts) ) {
          dgSchedulePlan.Rows[e.RowIndex].ErrorText = Ressource.Get("da_error_end");
          e.Cancel = true;
        }
      }
    }
    private void dgSchedulePlan_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if( !IsHandleCreated ) return;
      dgSchedulePlan.CellValueChanged -= dgSchedulePlan_CellValueChanged;
      if( -1 < e.ColumnIndex && e.ColumnIndex < chScEnd.Index ) RefreshCfgScEnd();
      else if( tbCfgScPerc.Value == 0 && e.ColumnIndex == chScEnd.Index ) {
        DataGridViewRow row = dgSchedulePlan.Rows[e.RowIndex];
        TimeSpan beg = TimeSpan.ParseExact(row.Cells[chScBeg.Index].Value.ToString(), "hh\\:mm", CultureInfo.InvariantCulture);
        TimeSpan end = TimeSpan.ParseExact(row.Cells[chScEnd.Index].Value.ToString(), "hh\\:mm", CultureInfo.InvariantCulture);

        row.Cells[chScMin.Index].Value = end.TotalMinutes - beg.TotalMinutes;
      }
      dgSchedulePlan.CellValueChanged += dgSchedulePlan_CellValueChanged;
    }
    private void dgSchedulePlan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if( e.ColumnIndex == chScEnd.Index ) e.CellStyle.ForeColor = chScEnd.ReadOnly ? SystemColors.GrayText : dgSchedulePlan.DefaultCellStyle.ForeColor;
    }

    private void tbSchedulePerc_ValueChanged(object sender, EventArgs e) {
      if( !IsHandleCreated ) return;

      RefreshCfgScEnd(); // don't change TrackBar.Value
      dgSchedulePlan.Update();
    }
    private void pbCfgScCorrMP_Click(object sender, EventArgs e) {
      Button pb = sender as Button;

      tbCfgScPerc.Value = int.Parse(pb.Text);
    }

    public struct CfgSc {
      [DataMember]
      public Schedule sc;
      [DataMember]
      public int rd;
    }

    private void pbScSave_Click(object sender, EventArgs e) {
      Config cfg = (Config)tpPlan.Tag;
      CfgSc cfgOld, cfgNew;
      string strOld, strNew, strSet = "{";

      cfgOld.sc = cfg.Schedule;
      cfgOld.rd = cfg.RainDelay;

      cfgNew.sc.Mode = int.Parse(txCfgScMode.Text.Substring(1, 1));
      cfgOld.sc.Party = cfgNew.sc.Party = null;
      cfgOld.sc.Ots = cfgNew.sc.Ots = null;
      cfgNew.sc.Days = new List<List<object>>(7);
      for( int idx = 0; idx < 7; idx++ ) {
        DataGridViewRow row = dgSchedulePlan.Rows[2*idx];

        cfgNew.sc.Days.Add(new List<object>());
        cfgNew.sc.Days[idx].Add(row.Cells[chScBeg.Index].Value);
        cfgNew.sc.Days[idx].Add(int.Parse(row.Cells[chScMin.Index].Value.ToString()));
        cfgNew.sc.Days[idx].Add((bool)row.Cells[chScCut.Index].Value ? 1 : 0);
      }
      if( cfgOld.sc.DDays != null ) { // DoubleScheduler
        cfgNew.sc.DDays = new List<List<object>>(7);
        for( int idx = 0; idx < 7; idx++ ) {
          DataGridViewRow row = dgSchedulePlan.Rows[2*idx+1];

          cfgNew.sc.DDays.Add(new List<object>());
          cfgNew.sc.DDays[idx].Add(row.Cells[chScBeg.Index].Value);
          cfgNew.sc.DDays[idx].Add(int.Parse(row.Cells[chScMin.Index].Value.ToString()));
          cfgNew.sc.DDays[idx].Add((bool)row.Cells[chScCut.Index].Value ? 1 : 0);
        }
      } else cfgNew.sc.DDays = null;
      cfgNew.sc.Perc = tbCfgScPerc.Value;

      strOld = GetJson(cfgOld.sc);
      strNew = GetJson(cfgNew.sc);
      if( string.Compare(strOld, strNew) != 0 ) strSet += "\"sc\":" + strNew + ",";

      cfgNew.rd = (int)udCfgRainDelay.Value;
      if( cfgOld.rd != cfgNew.rd ) strSet += string.Format("\"rd\":{0},", cfgNew.rd);

      if( strSet.Length > 2 ) strSet = strSet.Substring(0, strSet.Length-1);
      strSet += "}";

      if( strSet == "{}" || MessageBox.Show(strSet, "Publish", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No ) return;

      if( _lsc.Connected ) {
        _lsc.Publish(strSet); //, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        pbPlanSave.Enabled = false;
      }
    }
    #endregion

    #region Zone
    private void RefreshZone() {
      pbZoneStart.Enabled = _lsc.Data.Dat.LastState == StatusCode.HOME;

      if( tpZone.Tag is Config ) {
        Config cfg = (Config)tpZone.Tag;

        dgMultiZone.CellValueChanged -= dgMultiZone_CellValueChanged;
        for( int idx = 0; idx < cfg.MultiZones.Length; idx++ ) {
          dgMultiZone.Rows[idx].Cells[chMzStart.Name].Value = cfg.MultiZones[idx];
          for( int j = 0; j < 10; j++ ) {
            dgMultiZone.Rows[idx].Cells[j + 1].Value = cfg.MultiZonePercs[j] == idx;
          }
        }
        RefreshCfgMzPerc();
        dgMultiZone.CellValueChanged += dgMultiZone_CellValueChanged;
      }
    }
    private void RefreshCfgMzPerc() {
      for( int r = 0; r < 4; r++ ) {
        int perc = 0;

        for( int c = 0; c < 10; c++ ) perc += (bool)dgMultiZone.Rows[r].Cells[c + 1].Value ? 1 : 0;
        dgMultiZone.Rows[r].Cells[chMzPerc.Name].Value = perc * 10;
      }
    }

    private void dgMultiZone_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
      if( e.ColumnIndex == chMzStart.Index ) {
        int m;

        if( int.TryParse(e.FormattedValue.ToString(), out m) && 0 <= m && m < 1000 ) {
          dgMultiZone.Rows[e.RowIndex].ErrorText = null;
        } else {
          dgMultiZone.Rows[e.RowIndex].ErrorText = Ressource.Get("da_error_start");
          e.Cancel = true;
        }
      }
    }
    private void dgMultiZone_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if( chMz0.Index <= e.ColumnIndex && e.ColumnIndex <= chMz9.Index ) {
        dgMultiZone.CommitEdit(DataGridViewDataErrorContexts.Commit); // immediately commit checkox 
      }
    }
    private void dgMultiZone_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if( !IsHandleCreated ) return;

      dgMultiZone.CellValueChanged -= dgMultiZone_CellValueChanged;
      if( chMz0.Index <= e.ColumnIndex && e.ColumnIndex <= chMz9.Index &&
          (bool)dgMultiZone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ) {
        for( int i = 0; i < dgMultiZone.RowCount; i++ ) {
          if( i != e.RowIndex ) dgMultiZone.Rows[i].Cells[e.ColumnIndex].Value = false;
        }
        RefreshCfgMzPerc();
      }
      dgMultiZone.CellValueChanged += dgMultiZone_CellValueChanged;
    }
    private void pbMzStart_Click(object sender, EventArgs e) {
      txZoneDist.Tag = _lsc.Data.Dat.Statistic.Distance;
      _lsc.Publish("{\"cmd\":4}");
    }
    public struct CfgMz {
      [DataMember]
      public int[] mz;
      [DataMember]
      public int[] mzv;
    }
    private void pbMzSave_Click(object sender, EventArgs e) {
      Config cfg = (Config)tpZone.Tag;
      CfgMz cfgOld, cfgNew;
      string strOld, strNew, strSet = "{";

      cfgOld.mz = cfg.MultiZones;
      cfgOld.mzv = cfg.MultiZonePercs;

      cfgNew.mz = new int[4];
      for( int idx = 0; idx < 4; idx++ ) cfgNew.mz[idx] = int.Parse(dgMultiZone.Rows[idx].Cells[chMzStart.Name].Value.ToString());
      cfgNew.mzv = new int[10];
      for( int r = 0; r < 4; r++ ) {
        for( int c = 0; c < 10; c++ ) {
          if( (bool)dgMultiZone.Rows[r].Cells[chMz0.Index + c].Value ) cfgNew.mzv[c] = r;
        }
      }

      strOld = GetJson(cfgOld.mz); strNew = GetJson(cfgNew.mz);
      if( string.Compare(strOld, strNew) != 0 ) strSet += "\"mz\":" + strNew + ",";
      strOld = GetJson(cfgOld.mzv); strNew = GetJson(cfgNew.mzv);
      if( string.Compare(strOld, strNew) != 0 ) strSet += "\"mzv\":" + strNew + ",";

      if( strSet.Length > 2 ) strSet = strSet.Substring(0, strSet.Length-1);
      strSet += "}";

      if( /*strSet == "{}" ||*/ MessageBox.Show(strSet, "Publish", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No ) return;

      if( _lsc.Connected ) {
        _lsc.Publish(strSet); //, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        pbZoneSave.Enabled = false;
      }
    }
    #endregion

    #region Plugin
    private void LoadPlugins() {
      _lsc.LoadPlugins(AppDomain.CurrentDomain.BaseDirectory);

      lvPlugin.Items.Clear();
      foreach( KeyValuePair<string, IPlugin> pair in _lsc.Plugins ) {
        string name = pair.Key;
        IPlugin plugin = pair.Value;
        ListViewItem lvi = new ListViewItem(name);

        if( _settings.Plugins != null && _settings.Plugins.Contains(name) ) lvi.Checked = true;
        lvi.SubItems.Add(plugin.Desc);
        lvi.Tag = plugin;
        lvPlugin.Items.Add(lvi);
      }
      chPluginScript.Width = -1;
      chPluginDesc.Width = -2;
    }
    private void lvPlugin_SelectedIndexChanged(object sender, EventArgs e) {
      if( lvPlugin.SelectedItems.Count == 1 ) {
        IPlugin plugin = lvPlugin.SelectedItems[0].Tag as IPlugin;
        pgPlugin.SelectedObject = plugin.Options;
      }
    }
    private void pbPluginTest_Click(object sender, EventArgs e) {
      ListViewItem lvi = lvPlugin.FocusedItem;

      if( lvi != null && lvi.Tag is IPlugin ) {
        IPlugin plugin = lvi.Tag as IPlugin;
        PluginData pd;

        pd.Name = string.IsNullOrEmpty(edUsrName.Text) ? "noname" : edUsrName.Text;
        pd.Config = _lsc.Data.Cfg;
        pd.Data = _lsc.Data.Dat;

        plugin.Doit(pd);
        pgPlugin.SelectedObject = plugin.Options;
      }
    }
    #endregion

    private void Err(String s) {
      MessageBox.Show(this, s, "Landroid-S", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    private void Log(String s, int c = 0) {
      if( InvokeRequired ) Invoke(new LogDelegte(LogInvoke), s, c);
      else LogInvoke(s, c);
    }
    private void LogInvoke(String s, int c = 0) {
      switch( c ) {
        case 1: rtLog.SelectionColor = Color.Maroon; break;
        case 2: rtLog.SelectionColor = Color.Gray; break;
        case 9: rtLog.SelectionColor = Color.Red; break;
      }
      rtLog.AppendText(s + "\r\n");
      rtLog.SelectionColor = Color.Black;
      Console.WriteLine(s);
    }

    private void Recv() {
      Invoke(new MqttDelegate(RecvInvoke));
    }

    private string GetError(Data d) {
      switch( d.LastError ) {
        case ErrorCode.NONE: return string.Empty;
        //case ErrorCode.BATTERY_CHARGE_ERROR: return "Akku Ladefehler";      // ??
        case ErrorCode.BATTERY_LOW: return Ressource.Get("home_mower_error_battery_low"); //"Akkustand niedrig"
        case ErrorCode.HOME_FIND_TIMEOUT: return Ressource.Get("home_mower_error_home_find_timeout"); // "Heimfahrt abgebrochen"
        case ErrorCode.LIFTED: return Ressource.Get("home_mower_error_lifted"); // "Mäher angehoben"
        case ErrorCode.LOCK: return Ressource.Get("home_mower_error_lock"); //"Mäher gesperrt"
        case ErrorCode.MOTOR_BLADE_FAULT: return Ressource.Get("home_mower_error_blade_motor_fault"); //"Mähwerk blockiert"
        case ErrorCode.MOTOR_WHEELS_FAULT: return Ressource.Get("home_mower_error_wheel_motor_fault"); //"Hinterrad blockiert"
        case ErrorCode.OUTSIDE_WIRE: return Ressource.Get("home_mower_error_outside_wire"); //"Mäher ausgebrochen"
        case ErrorCode.RAINING: return Ressource.Get("home_mower_rain_delay"); //"Regenverzögerung"
        case ErrorCode.REVERSE_WIRE: return Ressource.Get("home_mower_error_reverse_wire"); //"Grenzdraht vertauscht"
        case ErrorCode.TRAPPED: return Ressource.Get("home_mower_trapped"); //"Mäher gefangen"
        case ErrorCode.TRAPPED_TIMEOUT_FAULT: return Ressource.Get("home_mower_error_trapped_timeout_fault"); //"Gefangen - Timeout"
        case ErrorCode.UPSIDE_DOWN: return Ressource.Get("home_mower_error_upside_down"); //"Mäher umgedreht"
        case ErrorCode.WIRE_MISSING: return Ressource.Get("home_mower_error_wire_missing"); //"Grenzdraht fehlt"
        default: return d.LastError.ToString();
      }
    }
    private string GetState(Data d) {
      Color fc;

      return GetState(d, out fc);
    }
    private string GetState(Data d, out Color c) {
      switch( d.LastState ) {
        case StatusCode.GRASS_CUTTING: c = Color.Lime; return Ressource.Get("home_mower_mowing"); // "Mähe Gras"
        case StatusCode.HOME:
          if( d.Battery.Charging == ChargeCoge.CHARGING ) { c = Color.LawnGreen; return Ressource.Get("home_mower_charging"); } // "Daheim (ladend)"
          else { c = Color.White; return Ressource.Get("home_mower_home"); } // "Daheim"
        case StatusCode.IDLE: c = Color.Pink; return Ressource.Get("home_mower_manual_stop"); // "Stehe (dumm) rum"
        case StatusCode.PAUSE: c = Color.Aqua; return Ressource.Get("home_mower_pause");

        case StatusCode.START_SEQUENCE: // "Starte Sequenz"
        case StatusCode.LEAVE_HOUSE: c = Color.Yellow; return Ressource.Get("home_mower_leaving_home"); // "Verlasse Heim"

        case StatusCode.FOLLOW_WIRE: //" Folge Draht"
        case StatusCode.SEARCHING_WIRE: // "Suche Draht"
        case StatusCode.SEARCHING_HOME: c = Color.Yellow; return Ressource.Get("home_mower_going_home"); // "Suche Heim";

        case StatusCode.WIRE_GOING_HOME: c = Color.Yellow; return Ressource.Get("home_mower_wire_follow_going_home");
        case StatusCode.WIRE_AREA_SEARCH: c = Color.Yellow; return Ressource.Get("home_mower_wire_follow_area_search");
        case StatusCode.WIRE_AREA_TRAINING: c = Color.Yellow; return Ressource.Get("home_mower_wire_follow_area_training");
        case StatusCode.WIRE_BORDER_CUT: c = Color.Yellow; return Ressource.Get("home_mower_wire_follow_border_cut");

        case StatusCode.LIFT_RECOVERY: // "Fehlerbehebung angehoben";
        case StatusCode.TRAPPED_RECOVERY: // "Fehlerbehebung Mähwerk"
        case StatusCode.BLADE_BLOCKED_RECOVERY: c = Color.Orange; return Ressource.Get("home_mower_trapped"); // "Fehlerbehebung gefangen"
        default: c = Color.Red; return d.LastState.ToString();
      }
    }

    private void RecvInvoke() {
      string json = _lsc.Json;
      Config c = _lsc.Data.Cfg;
      Data d = _lsc.Data.Dat;
      Battery b = d.Battery;
      Statistic s = d.Statistic;

      if( notifyIcon != null ) {
        string text = string.Format("{0}: {1}V {2}\r\n", edUsrName.Text, b.Volt, c.Time);
        if( d.LastError != ErrorCode.NONE ) text += "!!! " + GetError(d);
        else text += GetState(d);
        notifyIcon.Text = text.Length < 64 ? text : text.Substring(0, 60) + "...";
      }

      if( tcMain.SelectedTab == tpState ) RefreshState();

      tlPlan.Enabled = true;
      if( tcMain.SelectedTab == tpPlan ) {
        if( pbPlanSave.Enabled == false ) {
          tpPlan.Tag = _lsc.Data.Cfg;
          RefreshPlan();
          pbPlanSave.Enabled = true;
        }
      } else {
        tpPlan.Tag = null;
        pbPlanSave.Enabled = true;
      }

      tlZone.Enabled = true;
      if( tcMain.SelectedTab == tpZone ) {
        pbZoneStart.Enabled = d.LastState == StatusCode.HOME;
        if( pbZoneSave.Enabled == false ) {
          tpZone.Tag = _lsc.Data.Cfg;
          RefreshZone();
          pbZoneSave.Enabled = true;
        }
        //if( txZoneDist.Tag is int ) {
        //  int dist = s.Distance - (int)txZoneDist.Tag;

        //  txZoneDist.Text = string.Format("{0} {1}m", d.LastState, dist);
        //  if( dgMultiZone.SelectedRows.Count == 1 ) {
        //    int zone = Convert.ToInt32(dgMultiZone.SelectedRows[0].Cells[0].Value);

        //    if( zone <= dist ) {
        //      _lsc.Publish("{\"cmd\":1}");
        //      txZoneDist.Tag = null;
        //    }
        //  }
        //}
      } else {
        tpZone.Tag = null;
        pbZoneSave.Enabled = true;
      }

      //json = json.Substring(1, json.Length-2);
      json = Regex.Replace(json, "(\"(?:cfg|dat)\")", "\r\n  $1");
      json = Regex.Replace(json, "(\"(?:tm|sc|cmd|mz|rd|sn|modules)\")", "\r\n    $1");
      json = Regex.Replace(json, "\"(mac|fw|bt|dmp|st|ls|rsi|rain|moules)\"", "\r\n    \"$1\"");
      json = Regex.Replace(json, "(\\[|\\],)\\[", "$1\r\n      [");
      json = Regex.Replace(json, "\\}\\}", "}\r\n}");
      txMqtt.Tag = json;
      if( tcMain.SelectedTab == tpMqtt ) txMqtt.Text = json;

      if( _cmdInOut ) {
        try {
          File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CmdOut.json"), json);
          if( !timer.Enabled ) timer.Start();
        } catch( Exception ex ) {
          rtLog.AppendText(string.Format("Exception CmdOut: '{0}'\r\n", ex.ToString()));
        }
      }

      // allow only 10 request in 30 seconds 
      _calls.RemoveAll(dt => dt < DateTime.Now - TimeSpan.FromSeconds(30));
      if( _calls.Count < 10 ) foreach( ListViewItem lvi in lvPlugin.Items ) {
        if( lvi.Checked && lvi.Tag is IPlugin ) {
          try {
            IPlugin plugin = lvi.Tag as IPlugin;
            PluginData pd;

            pd.Name = edUsrName.Text;
            pd.Config = _lsc.Data.Cfg;
            pd.Data = _lsc.Data.Dat;

            plugin.Todo(pd);
            if( tcMain.SelectedTab == tpPlugin && lvPlugin.FocusedItem.Tag == plugin ) pgPlugin.SelectedObject = plugin.Options;

              //string req = plugin.Todo(pd);
              //if( !string.IsNullOrEmpty(req) ) {
              //  _lsc.Publish(req);
              //  pbPoll.Enabled = false;
              //}
            } catch( Exception ex ) {
            rtLog.AppendText(string.Format("Exception {0}.Todo: '{1}'\r\n", lvi.Text, ex.ToString()));
          }
        }
      }
    }

    private void timer_Tick(object sender, EventArgs e) {
      string s, fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CmdIn.json");
      FileInfo fi = new FileInfo(fn);

      if( fi.Exists && fi.LastWriteTime > _lastWrite ) {
        try {
          _calls.RemoveAll(dt => dt < DateTime.Now - TimeSpan.FromSeconds(30));
          if( _calls.Count < 10 ) {
            s = File.ReadAllText(fn);
            _lsc.Publish(s);
          }
          _lastWrite = fi.LastWriteTime;
          //fi.Delete();
        } catch( Exception ex ) {
          rtLog.AppendText(string.Format("Exception CmdIn: '{0}'\r\n", ex.ToString()));
        }
      }

      //if( txZoneDist.Tag is int && _lsc.Data.Dat.LastState == StatusCode.APP_WIRE_FOLLOW_AREA_TRAINING && !_lsc.Polling ) {
      //  _lsc.Poll();
      //}
    }

    private void pbActLog_Click(object sender, EventArgs e) {
      lvActLog.Items.Clear();
      foreach( Activity a in _lsc.GetActivities(edUsrName.Text)) {
        ListViewItem li = new ListViewItem();

        li.Text = a.Payload.Cfg.Date + " " + a.Payload.Cfg.Time;
        li.SubItems.Add(a.Payload.Dat.LastState.ToString());
        li.SubItems.Add(a.Payload.Dat.LastError.ToString());
        li.SubItems.Add(a.Payload.Dat.Battery.Charging == ChargeCoge.CHARGING ? "+" : "-");
        li.SubItems.Add(a.Payload.Dat.Battery.Miss.ToString());
        li.ToolTipText = a.Stamp;
        lvActLog.Items.Add(li);
      }
      chActStamp.Width = -1;
      chActState.Width = -1;
      chActError.Width = -1;
    }
  }
}
