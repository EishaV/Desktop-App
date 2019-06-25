using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;

using MqttJson;

public class PluginHomeBorderCut : IPlugin {
  public enum HbcState { None, Leave, Wait, Pause }

  [DataContract]
  public class HbcOptions { // Options for PropertyGrid on Plugin tab
    [DataMember]
    [Description("Time from Leave before Pause and Home (Default 3s)")]
    public int TimeToWire { get; set; }
    [DataMember]
    [Description("State of border cut"), ReadOnly(true)]
    public HbcState StateOfBcut { get; set; }

    public HbcOptions() {
      TimeToWire = 3;
      StateOfBcut = HbcState.None;
    }
  }

  const string HbcJson = "HomeBorderCut.json"; // file name for options

  private HbcOptions _op = new HbcOptions(); // options
  private Timer _tm; // = new Timer(timer_Callback);

  public PluginHomeBorderCut() { // read options from file
    _op = DeskApp.GetJson<HbcOptions>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HbcJson));
  }
  ~PluginHomeBorderCut() { // write options to file
    DeskApp.PutJson<HbcOptions>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HbcJson), _op);
  }

  string IPlugin.Desc { get { return "Cut border from home (charging station)"; } }
  object IPlugin.Options { get { return _op; } }

  bool IPlugin.Doit(PluginData pd) {
    if( pd.Data.LastState == StatusCode.HOME ) {
      DeskApp.Send("{\"cmd\":4}");
      DeskApp.Trace("HBC: Training");
      _op.StateOfBcut = HbcState.Leave;
    } else return false;
    return true;
  }

  bool IPlugin.Todo(PluginData pd) {
    Data d = pd.Data;

    if( _op.StateOfBcut != HbcState.None ) {
      DeskApp.Trace(string.Format("HBC: State {0}", pd.Data.LastState));
      if( d.LastState == StatusCode.HOME || d.LastState == StatusCode.LEAVE_HOUSE ) {
        if( _op.StateOfBcut == HbcState.Leave ) {
          _tm = new Timer(timer_Callback, null, _op.TimeToWire * 1000, Timeout.Infinite);
          _op.StateOfBcut = HbcState.Wait;
          DeskApp.Trace("HBC: Leave -> Timer");
        } else {
          DeskApp.Trace("HBC: Leave ignore " + d.LastState);
        }
      //} else if( _op.StateOfBcut == HbcState.Leave && d.LastState == StatusCode.APP_WIRE_FOLLOW_AREA_TRAINING ) {
      //  if( _op.TimeOnWire > 0 ) {
      //    _tm = new Timer(timer_Callback, null, _op.TimeOnWire * 1000, Timeout.Infinite);
      //    _op.StateOfBcut = HbcState.Wait;
      //    DeskApp.Trace("HBC: Wire -> Timer");
      //  } else {
      //    _op.StateOfBcut = HbcState.Pause;
      //    DeskApp.Send("{\"cmd\":2}"); // Stop
      //    DeskApp.Trace("HBC: Wire -> Pause");
      //  }
      } else if( _op.StateOfBcut == HbcState.Pause && d.LastState == StatusCode.PAUSE ) {
        DeskApp.Send("{\"cmd\":3}"); // Home
        _op.StateOfBcut = HbcState.None;
        DeskApp.Trace("HBC: Pause -> Home");
      } else {
        _op.StateOfBcut = HbcState.None; // somthing wrong?
        DeskApp.Trace("HBC: aborted " + d.LastState);
        return false;
      }
    }
    return true;
  }

  void timer_Callback(object state) {
    DeskApp.Send("{\"cmd\":2}");
    _op.StateOfBcut = HbcState.Pause;
    DeskApp.Trace("HBC: Timer -> Pause");
    _tm = null;
  }
}
