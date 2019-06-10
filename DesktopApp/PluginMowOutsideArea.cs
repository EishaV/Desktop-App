using System;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

using MqttJson;

public class PluginMowOutsideArea : IPlugin {
  public enum PbState { None , GoB, CutB, EndB, MowA, EdA }

  [DataContract]
  public class PbOptions { // Options for PropertyGrid on Plugin tab
    [DataMember]
    [DescriptionAttribute("Time for border cut")]
    public int BorderCut { get; set; }
  }

  const string PbJson = "MowOutsideArea.json"; // file name for options
  private PbOptions _op = new PbOptions(); // options
  private DelegateString _send = null, _trace = null;
  private Timer _timer = new Timer();
  private StatusCode _ls = StatusCode.UNK;
  private PbState _state = PbState.None;

  public PluginMowOutsideArea() { // try to read options from file
    if( File.Exists(PbJson) ) {
      try {
        using( FileStream fs = new FileStream(PbJson, FileMode.Open) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(PbOptions));

          _op = dcjs.ReadObject(fs) as PbOptions;
        }
      } catch {
        _op = new PbOptions();
      }
    }
    _timer.Tick += new System.EventHandler(this.timer_Tick);
  }
  ~PluginMowOutsideArea() { // write non empty options to file
    DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(PbOptions));
    FileStream fs = new FileStream(PbJson, FileMode.Create); // Path.Combine(Application.StartupPath, ...

    dcjs.WriteObject(fs, _op);
    fs.Close();
  }

  string IPlugin.Desc {
    get { return "Mow first border and then area of an outside island"; }
  }
  object IPlugin.Options {
    get { return _op; }
  }
  DelegateString IPlugin.Send {
    set { _send = value; }
  }
  DelegateString IPlugin.Trace {
    set { _trace = value; }
  }

  bool IPlugin.Test(PluginData pd) {
    if( pd.Data.LastState == StatusCode.PAUSE ) {
      if( _op.BorderCut == 0 ) {
        _send("{\"cmd\":1}");
        _trace("MOA: Start mowing (no bc)");
        _state = PbState.MowA;
      } else {
        _send("{\"cmd\":3}");
        _trace("MOA: Start border cut");
        _state = PbState.GoB;
      }
      return true;
    } else return false;
  }
  string IPlugin.Todo(PluginData pd) {
    _trace(string.Format("MOA: State {0}", pd.Data.LastState));
    if( pd.Data.LastState != _ls ) {
      switch( pd.Data.LastState ) {
        case StatusCode.SEARCHING_HOME:
        case StatusCode.FOLLOW_WIRE:
        case StatusCode.APP_WIRE_FOLLOW_GOING_HOME:
          if( pd.Data.Battery.Volt > 18.0F ) {
            if( !_timer.Enabled ) {
              _timer.Interval = _op.BorderCut * 60 * 1000;
              _timer.Start();
              _trace(string.Format("MOA: Wait for {0} min", _op.BorderCut));
              _state = PbState.CutB;
            }
          } else {
            _send("{\"cmd\":2}");
            _trace("MOA: Stop mowing (on wire)");
            _state = PbState.EdA;
          }
          break;
        case StatusCode.PAUSE:
          if( _timer.Enabled ) {
            _timer.Stop();
            _send("{\"cmd\":1}");
            _trace("MOA: Start mowing (after bc)");
            _state = PbState.MowA;
          }
          break;
        //case StatusCode.SEARCHING_HOME:
        //  _send("{\"cmd\":2}");
        //  _trace("MOA: Stop mowing (search)");
        //  break;
      }
      _ls = pd.Data.LastState;
    }
    return string.Empty; // no json data for Landroid
  }

  void timer_Tick(object sender, EventArgs e) {
    _send("{\"cmd\":2}");
    _trace("MOA: Stop border cut");
    _state = PbState.EndB;
  }
}
