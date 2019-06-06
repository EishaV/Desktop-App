using System;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

using MqttJson;

public class MowOutsideArea : IPlugin {
  [DataContract]
  public class PbOptions { // Options for PropertyGrid on Plugin tab
    [DataMember]
    [DescriptionAttribute("Time for border cut")]
    public int BorderCut { get; set; }
  }

  const string PbJson = "MowOutsideArea.json"; // file name for options
  private PbOptions _op = new PbOptions(); // options
  private SendDelegte _sd = null;
  private Timer _timer = new Timer();
  private StatusCode _ls = StatusCode.UNK;

  public MowOutsideArea() { // try to read options from file
    if( File.Exists(PbJson) ) {
      try {
        using( FileStream fs = new FileStream(PbJson, FileMode.Open) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(PbOptions));

          _op = dcjs.ReadObject(fs) as PbOptions;
        }
      } finally {
        _op = new PbOptions();
      }
    }
  }
  ~MowOutsideArea() { // write non empty options to file
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
  SendDelegte IPlugin.Send {
    set { _sd = value; }
  }

  bool IPlugin.Test(PluginData pd) {
    if( pd.Data.LastState == StatusCode.IDLE ) {
      if( _op.BorderCut == 0 ) _sd("{\"cmd\":1}");
      else {
        _timer.Interval = _op.BorderCut * 60 * 1000;
        _sd("{\"cmd\":4}");
      }
      return true;
    } else return false;
  }
  string IPlugin.Todo(PluginData pd) {
    if( pd.Data.LastState != _ls ) {
      switch( pd.Data.LastState ) {
        case StatusCode.FOLLOW_WIRE: _timer.Start(); break;
        case StatusCode.PAUSE:
          if( _timer.Enabled ) { _timer.Stop(); _sd("{\"cmd\":1}"); }
        break;
        case StatusCode.SEARCHING_HOME: _sd("{\"cmd\":2}"); break;
      }
      _ls = pd.Data.LastState;
    }
    return string.Empty; // no json data for Landroid
  }

  void timer_Tick() {
    _sd("{\"cmd\":2}");
  }
}
