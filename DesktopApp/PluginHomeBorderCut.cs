using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;

using MqttJson;

public class PluginHomeBorderCut : IPlugin {
  public enum HbcState { None , Leave, Wait, Pause }

  [DataContract]
  public class HbcOptions { // Options for PropertyGrid on Plugin tab
    [DataMember]
    [DescriptionAttribute("Time to wait on wire before cut")]
    public int TimeOnWire { get; set; }
  }

  const string HbcJson = "HomeBorderCut.json"; // file name for options

  private HbcOptions _op = new HbcOptions(); // options
  private HbcState _state = HbcState.None;

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
      DeskApp.Send("{\"cmd\":1}");
      DeskApp.Trace("HBC: Training");
      _state = HbcState.Leave;
    } else return false;
    return true;
  }

  bool IPlugin.Todo(PluginData pd) {
    Data d = pd.Data;

    DeskApp.Trace(string.Format("HBC: State {0}", pd.Data.LastState));
    if( _state != HbcState.None ) {
      if( _state == HbcState.Leave && (d.LastState == StatusCode.HOME || d.LastState == StatusCode.LEAVE_HOUSE) ) {
        DeskApp.Trace("HBC: Leave ignore " + d.LastState);
      } else if( _state == HbcState.Leave && d.LastState == StatusCode.APP_WIRE_FOLLOW_AREA_TRAINING ) {
        if( _op.TimeOnWire > 0 ) {
          new Timer(timer_Callback, null, _op.TimeOnWire * 1000, Timeout.Infinite);
          _state = HbcState.Wait;
          DeskApp.Trace("HBC: Wire -> Timer");
        } else {
          _state = HbcState.Pause;
          DeskApp.Send("{\"cmd\":2}"); // Stop
          DeskApp.Trace("HBC: Wire -> Pause");
        }
      } else if( _state == HbcState.Pause && d.LastState == StatusCode.PAUSE ) {
        _state = HbcState.None;
        DeskApp.Send("{\"cmd\":3}"); // Home
        DeskApp.Trace("HBC: Pause -> Home");
      } else {
        _state = HbcState.None; // somthing wrong?
        DeskApp.Trace("HBC: aborted " + d.LastState);
        return false;
      }
    }
    return true;
  }

  void timer_Callback(object state) {
    DeskApp.Send("{\"cmd\":2}");
    DeskApp.Trace("HBC: Timer -> Pause");
    _state = HbcState.Pause;
  }
}
