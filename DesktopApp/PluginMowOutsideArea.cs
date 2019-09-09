using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using MqttJson;

public class PluginMowOutsideArea : IPlugin {
  public enum MoaState { None , Mon }
  [DataContract]
  public class MoaOptions { // Options for PropertyGrid on Plugin tab
    [DataMember]
    [DescriptionAttribute("Time for mowing area")]
    public int TimeInArea { get; set; }
    [DataMember]
    [Description("State of mow outside area"), ReadOnly(true)]
    public MoaState StateOfMoa { get; set; }
    public MoaOptions() {
      TimeInArea = 0; // mow until accu empty
      StateOfMoa = MoaState.None;
    }
  }

  const string MoaJson = "MowOutsideArea.json"; // file name for options
  private MoaOptions _op;
  private Timer _tm;

  public PluginMowOutsideArea() { // try to read options from file
    _op = DeskApp.GetJson<MoaOptions>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MoaJson));
  }
  ~PluginMowOutsideArea() { // write non empty options to file
    DeskApp.PutJson<MoaOptions>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MoaJson), _op);
  }

  string IPlugin.Desc {
    get { return "Monitor mowing of an outside island"; }
  }
  object IPlugin.Options {
    get { return _op; }
  }
  bool IPlugin.Doit(PluginData pd) {
    DeskApp.Trace("MOA: None -> Mon");
    _op.StateOfMoa = MoaState.Mon; // begin monitoring
		if( _op.TimeInArea > 0 ) {
			_tm = new Timer(timer_Callback, null, _op.TimeInArea * 1000, Timeout.Infinite);
			DeskApp.Trace(string.Format("MOA: Start Timer {0}", _op.TimeInArea));
		}
    return true;
  }
  bool IPlugin.Todo(PluginData pd) {
    StatusCode ls = pd.Data.LastState;
    DeskApp.Trace(string.Format("MOA: State {0}", ls));
    if( _op.StateOfMoa == MoaState.Mon && ls == StatusCode.WIRE_GOING_HOME ) {
			DeskApp.Send("{\"cmd\":2}"); // Pause
			_op.StateOfMoa = MoaState.None;
			DeskApp.Trace("MOA: Monitor -> End");
			// hier noch eine Meldung?
    }
    return true;
  }

  void timer_Callback(object state) {
		DeskApp.Send("{\"cmd\":2}"); // Pause
		_op.StateOfMoa = MoaState.None;
		DeskApp.Trace("MOA: Timer -> End");
    _tm = null;
  }
}