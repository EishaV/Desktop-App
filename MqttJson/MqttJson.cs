﻿using System;
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
    CLOSE_DOOR_TO_CUT_GRASS = 6,
    CLOSE_DOOR_GO_HOME = 7,
    MOTOR_BLADE_FAULT = 8,
    MOTOR_WHEELS_FAULT = 9,
    TRAPPED_TIMEOUT_FAULT = 10,
    UPSIDE_DOWN = 11,
    BATTERY_LOW = 12,
    REVERSE_WIRE = 13,
    BATTERY_CHARGE_ERROR = 14,
    HOME_FIND_TIMEOUT = 15,
    LOCK = 16,
    BATTERY_OVERTEMP = 17,
    DUMMY_MODEL = 18,
    BATTERY_TRUNK_OPEN_TIMEOUT = 19,
    ERR_WIRE_SYNC = 20,
    NUM = 21
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
    OFF_LIMITS_ESCAPE = 13,
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
    RESET_LOG = 7,
    PAUSE_OVER_WIRE,
    SAFE_HOMING
  }
  #endregion

  #region MqttJson
  /*
  {
    "cfg":{
      "id":1,
      "lg":"it",
      "tm":"14:13:57", "dt":"30/07/2017",
      "sc":{"m":1,"p":0,
      "d":[["15:30",330,0],["15:30",330,1],["15:30",330,0],["15:30",330,1],["15:30",330,0],["15:30",330,1],["15:30",330,0]]},
      "cmd":0,
      "mz":[0,0,0,0], "mzv":[0,0,0,0,0,0,0,0,0,0],
      "rd":120,
      "sn":"..."},
      "al":{"lvl":0,"t":60},
      "t":-13,
      "modules":{"DF":{"cut":1,"fh":1}
    },
    "dat":{
      "mac":"F0FE6B...",
      "fw":2.69,
      "bt":{"t":31.7,"v":19.53,"p":82,"nr":910,"c":0},
      "dmp":[3.3,-3.2,328.8],
      "st":{"b":20010,"d":315068,"wt":21307},
      "ls":1,
      "le":0,
      "lz":0,
      "rsi":-74,
      "lk":0
    }
  }
  */
  [DataContract]
  public class OneTimeScheduler {
    [DataMember(Name = "bc")]   public int BorderCut; // cmommand for border cut
    [DataMember(Name = "wtm")]  public int WorkTime; // working time in minutes
  }

  [DataContract] public struct Schedule {
    [DataMember(Name = "m")]                                public int Mode;
    [DataMember(Name = "distm", EmitDefaultValue = false)]  public int? Party;
    [DataMember(Name = "ots", EmitDefaultValue = false)]    public OneTimeScheduler Ots;
    [DataMember(Name = "p")]                                public int Perc; // override from -100% to +100%, 0% is normal
    [DataMember(Name = "d")]                                public List<List<object>> Days;
    [DataMember(Name = "dd", EmitDefaultValue = false)]     public List<List<object>> DDays;
  }

  [DataContract]
  public class ModuleConfig {
    [DataMember(Name = "enabled")] public int Enabled; // config of module
  }

  [DataContract]
  public class ModuleConfigDF { // config of module OLM
    [DataMember(Name = "cut")] public int Cutting;
    [DataMember(Name = "fh")]  public int FastHome;
  }

  [DataContract]  public class ModuleConfigs {
    [DataMember(Name = "US")] public ModuleConfig US; // config of module ACS
    [DataMember(Name = "4G")] public ModuleConfig G4; // config of module FML
    [DataMember(Name = "DF")] public ModuleConfigDF DF; // config of module OML
  }

  [DataContract]
  public class AutoLock {
    [DataMember(Name = "lvl")] public int Level;
    [DataMember(Name = "t")] public int Time;
  }

  [DataContract] public struct Config {
    [DataMember(Name = "id",EmitDefaultValue = false)] public int? Id;
    [DataMember(Name = "lg")]      public string Language; // always it :-(
    [DataMember(Name = "tm")]      public string Time;
    [DataMember(Name = "dt")]      public string Date;
    [DataMember(Name = "sc")]      public Schedule Schedule;
    [DataMember(Name = "cmd")]     public Command Cmd;
    [DataMember(Name = "mz")]      public int[] MultiZones; // [0-3] start point in meters
    [DataMember(Name = "mzv")]     public int[] MultiZonePercs; // [0-9] ring list of start indizes
    [DataMember(Name = "rd")]      public int RainDelay;
    [DataMember(Name = "sn")]      public string SerialNo;
    [DataMember(Name = "al",EmitDefaultValue = false)] public AutoLock AutoLock;
    [DataMember(Name = "tq",EmitDefaultValue = false)] public int? Torque;
    [DataMember(Name = "modules",EmitDefaultValue = false)] public ModuleConfigs ModulesC;
  }

  [DataContract] public struct Battery {
    [DataMember(Name = "t")]    public float Temp;
    [DataMember(Name = "v")]    public float Volt;
    [DataMember(Name = "p")]    public float Perc;
    [DataMember(Name = "nr")]   public int Cycle;
    [DataMember(Name = "c")]    public ChargeCoge Charging;
    [DataMember(Name = "m")]    public int Maintenance;
  }

  [DataContract] public struct Statistic {
    [DataMember(Name = "b")]    public int Blade; // total runtime with blade on in minutes
    [DataMember(Name = "d")]    public int Distance; // total distance in meters
    [DataMember(Name = "wt")]   public int WorkTime; // total worktim in minutes
    [DataMember(Name = "bl")]   public int BladeLast; // blade time since last reset
  }

  [DataContract]  public class Rain {
    [DataMember(Name = "s")]    public int State; // state of sensor
    [DataMember(Name = "cnt")]  public int Counter; // delay counter
  }

  [DataContract]  public class ModuleState {
    [DataMember(Name = "stat")] public string State; // state of module
  }

  [DataContract] public class ModuleStates {
    [DataMember(Name = "US")] public ModuleState US; // state of module ACS
    [DataMember(Name = "DF")] public ModuleState DF; // state of module OLM
    [DataMember(Name = "RL")] public ModuleState RL; // state of module RLM
    [DataMember(Name = "4G")] public ModuleState G4; // state of module FML
  }

  [DataContract] public struct Data {
    [DataMember(Name = "mac")]      public string MacAdr;
    [DataMember(Name = "fw")]       public double Firmware;
    [DataMember(Name = "fwb", EmitDefaultValue = false)] public int? Beta;
    [DataMember(Name = "bt")]       public Battery Battery;
    [DataMember(Name = "dmp")]      public float[] Orient; // 0-pitch, 1-roll, 2-yaw
    [DataMember(Name = "st")]       public Statistic Statistic;
    [DataMember(Name = "ls")]       public StatusCode LastState;
    [DataMember(Name = "le")]       public ErrorCode LastError;
    [DataMember(Name = "lz")]       public int LastZone;
    [DataMember(Name = "rsi")]      public int RecvSignal;
    [DataMember(Name = "lk")]       public int Lock;
    [DataMember(Name = "act", EmitDefaultValue = false)]      public int? Act;
    [DataMember(Name = "tr", EmitDefaultValue = false)]       public int? Tr;
    [DataMember(Name = "conn", EmitDefaultValue = false)]     public string Conn;
    [DataMember(Name = "rain", EmitDefaultValue = false)]     public Rain Rain;
    [DataMember(Name = "modules", EmitDefaultValue = false)]  public ModuleStates ModulesD;
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
