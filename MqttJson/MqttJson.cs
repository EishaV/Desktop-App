using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace MqttJson{
  #region Enums
  public enum ErrorCode : int {
    UNK = -1,
    NONE = 0,
    TRAPPED = 1,
    LIFTED = 2,
    WIRE_MISSING = 3,
    OUTSIDE_WIRE = 4,
    RAINING = 5,
    //L_MSG_CLOSE_DOOR_TO_CUT_GRASS = 6,
    //L_MSG_CLOSE_DOOR_GO_HOME = 7,
    MOTOR_BLADE_FAULT = 8,
    MOTOR_WHEELS_FAULT = 9,
    TRAPPED_TIMEOUT_FAULT = 10,
    UPSIDE_DOWN = 11,
    BATTERY_LOW = 12,
    REVERSE_WIRE = 13,
    BATTERY_CHARGE_ERROR = 14,
    HOME_FIND_TIMEOUT = 15,
    LOCK = 16, //? 1
    BATTERY_OVERTEMP = 17
  }
  public enum StatusCode : int {
    UNK = -1,
    IDLE = 0,
    HOME = 1,
    START_SEQUENCE = 2,
    LEAVE_HOUSE = 3,
    FOLLOW_WIRE = 4,
    SEARCHING_HOME = 5,
    SEARCHING_WIRE = 6,
    GRASS_CUTTING = 7,
    LIFT_RECOVERY = 8,
    TRAPPED_RECOVERY = 9,
    BLADE_BLOCKED_RECOVERY = 10,
    DEBUG = 11,
    REMOTE_CONTROL = 12,
    WIRE_GOING_HOME = 30,
    WIRE_AREA_TRAINING = 31,
    WIRE_BORDER_CUT = 32,
    WIRE_AREA_SEARCH = 33,
    PAUSE = 34
  }
  public enum ChargeCoge : int {
    CHARGED = 0,
    CHARGING = 1,
    ERROR_CHARGING = 2
  }
  public enum Command : int {
    NONE = 0,
    START = 1,
    STOP = 2,
    HOME_REQ = 3,
    ZONE_SEARCH_REQ = 4,
    LOCK = 5,
    UNLOCK = 6,
    RESET_LOG = 7
  }
  #endregion

  #region Structs MqttJson
  /*
  {
    "cfg":{ "lg":"it",
            "tm":"14:13:57",
            "dt":"30/07/2017",
            "sc":{"m":1,"p":0,"d":[["15:30",330,0],["15:30",330,1],["15:30",330,0],["15:30",330,1],["15:30",330,0],["15:30",330,1],["15:30",330,0]]},
            "cmd":0,
            "mz":[0,0,0,0],
            "mzv":[0,0,0,0,0,0,0,0,0,0],
            "rd":120,
            "sn":"..."},
    "dat":{ "mac":"F0FE6B...",
            "fw":2.69,
            "bt":{"t":31.7,"v":19.53,"p":82,"nr":910,"c":0},
            "dmp":[3.3,-3.2,328.8],
            "st":{"b":20010,"d":315068,"wt":21307},
            "ls":1,
            "le":0,
            "lz":0,
            "rsi":-74,
            "lk":0}
  }
  */
  [DataContract] public struct Schedule {
    [DataMember(Name = "m")]    public int Mode;
    [DataMember(Name = "p")]    public int Perc; // override from -100% to +100%, 0% is normal
    [DataMember(Name = "d")]    public List<List<object>> Days;
  }

  [DataContract] public struct Config {
    [DataMember(Name = "lg")]   public string Language; // always it :-(
    [DataMember(Name = "tm")]   public string Time;
    [DataMember(Name = "dt")]   public string Date;
    [DataMember(Name = "sc")]   public Schedule Schedule;
    [DataMember(Name = "cmd")]  public Command Cmd;
    [DataMember(Name = "mz")]   public int[] MultiZones; // [0-3] start point in meters
    [DataMember(Name = "mzv")]  public int[] MultiZonePercs; // [0-9] ring list of start indizes
    [DataMember(Name = "rd")]   public int RainDelay;
    [DataMember(Name = "sn")]   public string SerialNo;
  }

  [DataContract] public struct Battery {
    [DataMember(Name = "t")]    public float Temp;
    [DataMember(Name = "v")]    public float Volt;
    [DataMember(Name = "p")]    public float Perc;
    [DataMember(Name = "nr")]   public int Cycle;
    [DataMember(Name = "c")]    public ChargeCoge Charging;
  }

  [DataContract] public struct Statistic {
    [DataMember(Name = "b")]    public int Blade; // total runtime with blade on in minutes
    [DataMember(Name = "d")]    public int Distance; // total distance in meters
    [DataMember(Name = "wt")]   public int WorkTime; // total worktim in minutes
  }

  [DataContract] public struct Data {
    [DataMember(Name = "mac")]  public string MacAdr;
    [DataMember(Name = "fw")]   public double Firmware;
    [DataMember(Name = "bt")]   public Battery Battery;
    [DataMember(Name = "dmp")]  public float[] Orient; // 0-pitch, 1-roll, 2-yaw
    [DataMember(Name = "st")]   public Statistic Statistic;
    [DataMember(Name = "ls")]   public StatusCode LastState;
    [DataMember(Name = "le")]   public ErrorCode LastError;
    [DataMember(Name = "lz")]   public int LastZone;
    [DataMember(Name = "rsi")]  public int RecvSignal;
    [DataMember(Name = "lk")]   public int Lock;
  }
  #endregion

  #region Plugin
  public struct PluginData {
    public string Name;
    public Config Config;
    public Data Data;
  }

  public delegate void DelegateString(string msg);

  public static class DeskApp {
    public static DelegateString _send { get; set; }
    public static DelegateString _trace { get; set; }

    public static void Send(string mqtt) { _send?.Invoke(mqtt); }
    public static void Trace(string text) { _trace?.Invoke(text); }

    public static T GetJson<T>(string name) where T : class, new() {
      if( File.Exists(name) ) {
        try {
          using( FileStream fs = new FileStream(name, FileMode.Open) ) {
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(T));

            return dcjs.ReadObject(fs) as T;
          }
        } catch {
          return new T();
        }
      }
      return new T();
    }

    public static void PutJson<T>(string name, T json) where T : class {
      DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(T));
      FileStream fs = new FileStream(name, FileMode.Create);

      dcjs.WriteObject(fs, json);
      fs.Close();
    }
  }

  public interface IPlugin {
    object Options { get; }
    string Desc { get; }
    bool Doit(PluginData pd);
    bool Todo(PluginData pd);
  }
  #endregion
}
