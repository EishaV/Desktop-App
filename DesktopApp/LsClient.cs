#define PLUGIN

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading;

#if PLUGIN
using CSScriptLibrary;
#endif

using MqttJson;

namespace DesktopApp
{
  #region Structs
  /*
  User auth {"id":000,"name":"...","email":"...","created_at":"...","updated_at":"...","city":null,"address":null,"zipcode":null,
              "country_id":276,"phone":null,"birth_date":null,"sex":null,"newsletter_subscription":null,"user_type":"customer",
              "api_token":"...","token_expiration":"...", "mqtt_client_id":"android-..."}
  */
  [DataContract]
  public struct WorxUser {
    [DataMember(Name = "name")]
    public string Name;
    [DataMember(Name = "email")]
    public string Email;
    [DataMember(Name = "api_token")]
    public string ApiToken;
    [DataMember(Name = "mqtt_client_id")]
    public string MqttClientId;
    [DataMember(Name = "mqtt_endpoint")]
    public string MqttEndpoint;
  }
  [DataContract]
  public struct LsOAuth {
    [DataMember(Name = "token_type")]
    public string Type;
    [DataMember(Name = "expires_in")]
    public int Expires;
    [DataMember(Name = "access_token")]
    public string Access;
    [DataMember(Name = "refresh_token")]
    public string Refresh;
  }
  [DataContract]
  public struct LsUserMe {
    [DataMember(Name = "mqtt_endpoint")] public string Endpoint;
  }
  [DataContract]
  public struct LsCertificate {
    [DataMember(Name = "pkcs12")]
    public string Pkcs12;
  }

  /*  Product items: [{
   *  "id":12061,"uuid":"96c52ef5-4410-4002-9d84-34c5b8bbcb6d","product_id":22,"user_id":1020,
   *  "serial_number":"30173502161229020238","mac_address":"F0FE6B207964","name":"Gustav","locked":false,
   *  "firmware_version":3.45,"firmware_auto_upgrade":false,"push_notifications":true,"sim":null,
   *  "push_notifications_level":"warning","test":false,"iot_registered":true,"mqtt_registered":true,
   *  "pin_code":null,"registered_at":"2017-03-27 00:00:00","online":true,"app_settings":null,"accessories":null,
   *  "features":{"chassis":"s_2017","display_type":"led","input_type":"keyboard_led","lock":true,
   *              "mqtt":true,"multi_zone":true,"multi_zone_percentage":true,"multi_zone_zones":4,
   *              "rain_delay":true,"unrestricted_mowing_time":true,"wifi_pairing":"smartlink"},
   *  "pending_radio_link_validation":null,
   *  "mqtt_endpoint":"iot.eu-west-1.worxlandroid.com",
   *  "mqtt_topics":{"command_in":"DB510\/F0FE6B207964\/commandIn","command_out":"DB510\/F0FE6B207964\/commandOut"},
   *  "warranty_registered":true,"purchased_at":"2017-03-24 00:00:00","warranty_expires_at":"2020-03-24 00:00:00",
   *  "setup_location":{"latitude":50.5130831,"longitude":12.4183362},
   *  "city":{"id":2954602,"country_id":276,"name":"Auerbach","latitude":50.51667,"longitude":12.4,"created_at":"2018-02-15 22:21:33","updated_at":"2018-02-15 22:21:33"},
   *  "time_zone":"Europe\/Berlin","lawn_size":550,"lawn_perimeter":null,
   *  "auto_schedule_settings":{"boost":0,"exclusion_scheduler":{"days":[{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false},{"slots":[],"exclude_day":false}],"exclude_nights":true},
   *                            "grass_type":null,"irrigation":null,"nutrition":null,"soil_type":null},
   *  "auto_schedule":false,
   *  "distance_covered":2813588,"mower_work_time":180560,
   *  "blade_work_time":165998,"blade_work_time_reset":null,"blade_work_time_reset_at":null,
   *  "battery_charge_cycles":13912,"battery_charge_cycles_reset":null,"battery_charge_cycles_reset_at":null,
   *  "messages_in":1484,"messages_out":164756,"raw_messages_in":4616,"raw_messages_out":164756,
   *  "created_at":"2017-03-13 19:27:22","updated_at":"2022-08-11 16:02:27"},
   *  ,"last_status":{"timestamp":"2022-10-04 18:02:21","payload": ...
   *  ]
  */
  [DataContract]
  public struct LsMqttTopic {
    [DataMember(Name = "command_in")]
    public string CmdIn;
    [DataMember(Name = "command_out")]
    public string CmdOut;
  }
  [DataContract]
  public struct LsLastStatus {
    [DataMember(Name = "timestamp")]
    public string TimeStamp;
    [DataMember(Name = "payload")]
    public LsMqtt PayLoad;
  }
  [DataContract]
  public struct LsProductItem {
    [DataMember(Name = "serial_number")]
    public string SerialNo;
    [DataMember(Name = "mac_address")]
    public string MacAdr;
    [DataMember(Name = "name")]
    public string Name;
    [DataMember(Name = "firmware_auto_upgrade")]
    public bool AutoUpgd;
    [DataMember(Name = "mqtt_endpoint")]
    public string Endpoint;
    [DataMember(Name = "mqtt_topics")]
    public LsMqttTopic Topic;
    [DataMember(Name = "last_status")]
    public LsLastStatus Last;
  }
  [DataContract]
  public struct LsMqtt {
    [DataMember(Name = "cfg")]
    public Config Cfg;
    [DataMember(Name = "dat")]
    public Data Dat;
  }

  [DataContract]
  public struct LsJson {
    [DataMember(Name = "api")]      public string Api;
    [DataMember(Name = "email")]    public string Email;
    [DataMember(Name = "pass")]     public string Password;
    [DataMember(Name = "uuid")]     public string Uuid;
    [DataMember(Name = "name")]     public string Name;
    [DataMember(Name = "broker")]   public string Broker;
    [DataMember(Name = "mac")]      public string MacAdr;
    [DataMember(Name = "board")]    public string Board;
    [DataMember(Name = "blade")]    public int Blade;
    [DataMember(Name = "top")]      public bool Top;
    [DataMember(Name = "x")]        public int X;
    [DataMember(Name = "y")]        public int Y;
    [DataMember(Name = "w")]        public int W;
    [DataMember(Name = "h")]        public int H;
    [DataMember(Name = "plugins")]  public List<string> Plugins;

    public bool Equals(LsJson lsj) {
      bool b;

      b = Api == lsj.Api && Email == lsj.Email && Password == lsj.Password && Uuid == lsj.Uuid;
      b = b && Name == lsj.Name && Broker == lsj.Broker && MacAdr == lsj.MacAdr;
      b = b && Top == lsj.Top && X == lsj.X && Y == lsj.Y && W == lsj.W && H == lsj.H && Blade == lsj.Blade;
      if( b && Plugins != null && lsj.Plugins != null ) {
        b = Plugins.Count == lsj.Plugins.Count;
        for( int i = 0; b && i < Plugins.Count; i++ ) b = b && Plugins[i] == lsj.Plugins[i];
      }
      return b;
    }
  }

  [DataContract] public struct LsEstimatedTime {
    [DataMember(Name = "beg")] public float Beg;
    [DataMember(Name = "end")] public float End;
    [DataMember(Name = "vpm")] public float VoltPerMin;
  }

  [DataContract] public struct LsEstimatedTimes {
    [DataMember(Name = "home_0")] public LsEstimatedTime HomeOff;
    [DataMember(Name = "home_1")] public LsEstimatedTime HomeOn;
    [DataMember(Name = "mowing")] public LsEstimatedTime Mowing;
  }
  #endregion


  #region Activity-Log
  /*
  {
    "_id":"5d65fcd8241fa136e0551d1f",
    "timestamp":"2019-08-28 04:02:31",
    "product_item_id":12061,
    "payload":{
      "cfg":{"dt":"28/08/2019","tm":"06:02:23","mzv":[0,0,0,0,0,0,0,0,0,0],"mz":[0,0,0,0]},
      "dat":{"le":0,"ls":0,"fw":3.51,"lz":0,"lk":0,"bt":{"c":0,"m":1}}
    }
  }
  */
  [DataContract]
  public struct ActivityConfig {
    [DataMember(Name = "dt")] public string Date;
    [DataMember(Name = "tm")] public string Time;
    [DataMember(Name = "mz")] public int[] MultiZones; // [0-3] start point in meters
    [DataMember(Name = "mzv")] public int[] MultiZonePercs; // [0-9] ring list of start indizes
  }
  [DataContract]
  public struct ActivityBattery {
    [DataMember(Name = "c")] public ChargeCoge Charging;
    [DataMember(Name = "m")] public int Maintenance;
  }
  [DataContract]
  public struct ActivityData {
    [DataMember(Name = "le")] public ErrorCode LastError;
    [DataMember(Name = "ls")] public StatusCode LastState;
    [DataMember(Name = "fw")] public double Firmware;
    [DataMember(Name = "lz")] public int LastZone;
    [DataMember(Name = "lk")] public int Lock;
    [DataMember(Name = "bt")] public ActivityBattery Battery;
  }
  [DataContract]
  public struct ActivityPayload {
    [DataMember(Name = "cfg")] public ActivityConfig Cfg;
    [DataMember(Name = "dat")] public ActivityData Dat;
  }
  [DataContract]
  public struct Activity {
    [DataMember(Name = "_id")] public string ActId;
    [DataMember(Name = "timestamp")] public string Stamp;
    [DataMember(Name = "product_item_id")] public string MowId;
    [DataMember(Name = "payload")] public ActivityPayload Payload;
  }
  #endregion

  public delegate void ErrDelegte(string msg);
  public delegate void LogDelegte(string log, int c = 0);
  public delegate void MqttDelegate();

  //public static partial class DeskApp {
  //  internal static DelegateString _send { get; set; }
  //  internal static DelegateString _trace { get; set; }
  //}

  public class LsClient {
    public enum States { None, Connected, Subscribed, Exit, Unsubscribed, Disconnected };

    private WebClient _client = new WebClient();
    private string _tokRef = null;
    private DateTime _tokDT;
    private int _tokExp = 3600;
    private X509Certificate2 _certWX = null;
    private MqttClient _mqtt = null;
    private string _api, _uuid, _board, _mac;
    private string _cmdIn;
    private string[] _cmdOut;
    private byte[] _cmdQos;
    private ushort _msgId = 0;
    private bool _msgPoll = false;

    public string Broker { get; private set; }

    public List<LsProductItem> Products = new List<LsProductItem>();
    public Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

    public States State = States.None;

    public ErrDelegte Err;
    public LogDelegte Log;
    public MqttDelegate Recv;
    public string Json;
    public LsMqtt Data;

    private string ArgCfg() {
      string[] args = Environment.GetCommandLineArgs();

      if( args.Length > 1 ) return "." + args[1];
      else return string.Empty;
    }
    public bool Login(string api, string mail, string pass, string uuid) {
      return WebApi(api, mail, pass, uuid);
    }
    public bool WebApi(string api, string mail, string pass, string uuid) {
      NameValueCollection nvc = new NameValueCollection();
      string str, url_lgn, url_api;
      byte[] buf;

      _api = api;
      url_lgn = ConfigurationManager.AppSettings[$"{_api}_Login"];
      url_api = ConfigurationManager.AppSettings[$"{_api}_WebApi"];
      #region Anmeldung
      nvc.Add("username", mail);
      nvc.Add("password", pass);
      nvc.Add("grant_type", "password");
      nvc.Add("client_id", ConfigurationManager.AppSettings[$"{_api}_CliId"]);
      //nvc.Add("client_secret", sec);
      nvc.Add("scope", "*");
      try {
        buf = _client.UploadValues(url_lgn + "oauth/token", nvc);
        //buf = _client.UploadValues(_api + "oauth/token", nvc);
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Oauth token: {0}", str);
        Log(string.Format("Oauth token: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsOAuth));
          LsOAuth lsoa = (LsOAuth)dcjs.ReadObject(ms);

          _client.Headers["Authorization"] = string.Format("{0} {1}", lsoa.Type, lsoa.Access);
          _tokRef = lsoa.Refresh;
          _tokExp = lsoa.Expires;
          _tokDT = DateTime.Now;
          ms.Close();
        }
      } catch( Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }
      #endregion

      try {
        /*
        #region Benutzer
        buf = _client.DownloadData(_api + "users/me");
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("User info: {0}", str);
        Log(string.Format("User info: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsUserMe));
          LsUserMe ku = (LsUserMe)dcjs.ReadObject(ms);

          Broker = ku.Endpoint;
          ms.Close();
        }
        #endregion
        */

        #region Product items
        buf = _client.DownloadData(url_api + "product-items?status=1");
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Product items: {0}", str);
        Log(string.Format("Product items: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<LsProductItem>));
          Products = (List<LsProductItem>)dcjs.ReadObject(ms);

          ms.Close();
        }
        #endregion

        /*
        #region Status
        buf = null;
        foreach( LsProductItem pi in Products ) {
          buf = _client.DownloadData(_api + "product-items/" + pi.SerialNo + "/status");
          str = Encoding.UTF8.GetString(buf);
          Debug.WriteLine("Status {0}: {1}", pi.Name, str);
          Log(string.Format("Status {0}: {1}", pi.Name, str), 1);
        }
        if( buf != null ) {
          MemoryStream ms = new MemoryStream(buf);
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsMqtt));
          LsMqtt jm = (LsMqtt)dcjs.ReadObject(ms);

          Json = str;
          Data = jm;
          //_msgPoll = false;
          ms.Close();
          Recv();
        }
        #endregion
        */

        if( api == "SM" ) return Products.Count > 0;
        #region Certificate
        buf = _client.DownloadData(url_api + "users/certificate");
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Certificate: {0}", str);
        Log(string.Format("Certificate: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsCertificate));
          LsCertificate lsc = (LsCertificate)dcjs.ReadObject(ms);

          ms.Close();
          if( !string.IsNullOrEmpty(lsc.Pkcs12) ) {
            str = lsc.Pkcs12.Replace("\\/", "/");
            buf = Convert.FromBase64String(str);
            File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AWS" + ArgCfg() + ".p12"), buf);
            _certWX = new X509Certificate2(buf);
          }

          //string mac = Products.Count > 0 ? Products[0].MacAdr.Substring(5) : "000000";
          //int xx = int.Parse(mac, System.Globalization.NumberStyles.HexNumber) ^ 0xE1588A;
          //Log(string.Format("AWS certificate done ({0})", xx), 2);
          //buf = _certWX.Export(X509ContentType.Cert);
          //File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WX.p12"), buf);
        }
        #endregion
      } catch(Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      buf = null;
      return _certWX != null && Products.Count > 0;
    }
    public bool LoadAWS() {
      string name = "AWS" + ArgCfg() + ".p12";
      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);

      if( File.Exists(path) ) {
        try {
          _certWX = new X509Certificate2(path);
          Log(string.Format("AwsFile: {0}", name));
          return true;
        } catch( Exception ex ) {
          Log(ex.ToString());
        }
      }
      return false;
    }

    private bool RefreshToken() {
      NameValueCollection nvc = new NameValueCollection();
      string str;
      byte[] buf;

      str = ConfigurationManager.AppSettings[$"{_api}_Login"];
      nvc.Add("grant_type", "refresh_token");
      nvc.Add("scope", "*");
      nvc.Add("client_id", ConfigurationManager.AppSettings[$"{_api}_CliId"]);
      nvc.Add("refresh_token", _tokRef);
      try {
        buf = _client.UploadValues(str + "oauth/token", nvc);
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Oauth token: {0}", str);
        //Log(string.Format("Oauth token: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsOAuth));
          LsOAuth lsoa = (LsOAuth)dcjs.ReadObject(ms);

          _client.Headers["Authorization"] = string.Format("{0} {1}", lsoa.Type, lsoa.Access);
          _tokRef = lsoa.Refresh;
          _tokExp = lsoa.Expires;
          _tokDT = DateTime.Now;
          ms.Close();
        }
      } catch( Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }
      return true;
    }

    public List<Activity> GetActivities(string name) {
      string str;
      List<Activity> ls = new List<Activity>();

      str = ConfigurationManager.AppSettings[$"{_api}_WebApi"];
      if( (_tokDT - DateTime.Now).TotalSeconds > _tokExp ) {
        if( !RefreshToken() ) {
          Log("Could not refresh token", 9);
          return ls;
        }
      }
      foreach( LsProductItem pi in Products ) {
        if( pi.Name == name ) {
          byte[] buf = _client.DownloadData(str + "product-items/" + pi.SerialNo + "/activity-log");

          if( buf != null ) {
            MemoryStream ms = new MemoryStream(buf);
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Activity>));
            
            ls = dcjs.ReadObject(ms) as List<Activity>;
            foreach( Activity a in ls ) {
              ActivityPayload p = a.Payload;

              Log(string.Format("{0}: {1} - {2} - {3} - {4}", a.Stamp, p.Dat.LastError, p.Dat.LastState, p.Dat.Battery.Charging, p.Dat.Battery.Maintenance));
            }
            ms.Close();
          }
        }
      }
      return ls;
    }
    //public void AutoUpgrde(string serial, bool b) {
    //  string url = ConfigurationManager.AppSettings["ApiBaseUrl"] +  "product-items/" + serial, str;

    //  _client.Headers[HttpRequestHeader.ContentType] = "application/json";
    //  //str = client.UploadString(str, "PUT", "{\"name\":\"Egon\"}");
    //  str = "{\"firmware_auto_upgrade\":" + (b ? "true" : "false") + "}";
    //  str = _client.UploadString(url, "PUT", str);
    //  Log(string.Format("Auto upgd: {0}", str), 1);
    //  Debug.WriteLine("Auto upgd: {0}", str);
    //}

    public bool Start(string broker, string uuid, string board, string mac) {
      Broker = broker; _uuid = "android-" + uuid; _board = board; _mac = mac;
      Log(string.Format("Broker: '{0}'", broker));
      Log(string.Format("Topic: '{0}/{1}'", board, mac));
      _cmdIn = string.Format("{0}/{1}/commandIn", board, mac);
      _cmdOut = new string[] { string.Format("{0}/{1}/commandOut", board, mac) };
      _cmdQos = new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE }; // | MqttMsgBase.QOS_LEVEL_GRANTED_FAILURE
      return Start(true);
    }

    public bool Start(bool first) {
      if( _mqtt != null ) {
        _mqtt.MqttMsgSubscribed -= MqttMsgSubscribed;
        _mqtt.MqttMsgUnsubscribed -= MqttMsgUnsubscribed;
        _mqtt.MqttMsgPublishReceived -= MqttMsgPublishReceived;
        _mqtt.MqttMsgPublished -= MqttMsgPublished;
        _mqtt.ConnectionClosed -= ConnectionClosed;
        _mqtt = null;
      }

      try {
        _mqtt = new MqttClient(Broker, 8883, true, null, _certWX, MqttSslProtocols.TLSv1_2);
      } catch( Exception ex ) {
        if( first ) Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      try {
        _mqtt.MqttMsgSubscribed += MqttMsgSubscribed;
        _mqtt.MqttMsgUnsubscribed += MqttMsgUnsubscribed;
        _mqtt.MqttMsgPublished += MqttMsgPublished;
        _mqtt.MqttMsgPublishReceived += MqttMsgPublishReceived;
        _mqtt.ConnectionClosed += ConnectionClosed;

        byte code = _mqtt.Connect(_uuid);
        Log(string.Format("Connect '{0} ({1})'", code, _mqtt.IsConnected));
        State = States.Connected;

        _mqtt.Subscribe(_cmdOut, _cmdQos);
        Log(string.Format("Subscribe init"));

        //_msgId = _mqtt.Publish(_cmdIn, Encoding.ASCII.GetBytes("{}"));
        //_msgPoll = true;
        //Log(string.Format("Publish send '{0}'", _msgId));
      } catch( Exception ex ) {
        if( first ) Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      return true;
    }

    public void Exit() {
      if( _mqtt != null && _mqtt.IsConnected ) {
        int wait = 20;

        //_mqtt.MqttMsgPublishReceived -= MqttMsgPublishReceived;
        //_mqtt.MqttMsgPublished -= MqttMsgPublished;
        _mqtt.Unsubscribe(_cmdOut);
        while( State != States.Unsubscribed && wait-- > 0 ) Thread.Sleep(100);
        if( wait == 0 ) {
          Log("Timeout unsubscribe", 9);
          State = States.Unsubscribed;
        }
        //_mqtt.MqttMsgSubscribed -= MqttMsgSubscribed;
        //_mqtt.MqttMsgUnsubscribed -= MqttMsgUnsubscribed;
        //_mqtt.ConnectionClosed -= ConnectionClosed;
        try { _mqtt.Disconnect(); }
        catch( Exception ex) { Log(ex.ToString(), 9); }
        //_mqtt = null;
      }
    }

    public bool Connected { get { return _mqtt != null && _mqtt.IsConnected; } }
    public bool Polling { get { return _msgPoll && _mqtt != null && _mqtt.IsConnected; } }
    public void Poll() {
      string cfg;

      cfg = "{" + (Data.Cfg.Id != null ? $"\"id\":{Data.Cfg.Id}" : "") + "}";
      _msgId = _mqtt.Publish(_cmdIn, Encoding.UTF8.GetBytes(cfg));
      _msgPoll = true;
    }
    public void Publish(string s) {
      _msgId = _mqtt.Publish(_cmdIn, Encoding.UTF8.GetBytes(s));
    }
    public void PublishWithId(string s) {
      string cfg;

      cfg = "{" + (Data.Cfg.Id != null ? $"\"id\":{Data.Cfg.Id}," : "") + s + "}";
      _msgId = _mqtt.Publish(_cmdIn, Encoding.UTF8.GetBytes(cfg));
    }
    private void MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e) {
      Log(string.Format("Subscribe done '{0}'", e.MessageId));
      State = States.Subscribed;
      Poll();
    }
    private void MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e) {
      State = States.Unsubscribed;
      Log(string.Format("Unsubscribe done '{0}'", e.MessageId));
    }
    private void MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e) {
      Log(string.Format("Published done '{0}' ({1})", e.MessageId, e.IsPublished));
    }
    private void MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
      Json = Encoding.UTF8.GetString(e.Message);

      Debug.WriteLine(Json);
      try {
        MemoryStream ms = new MemoryStream(e.Message);
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsMqtt));
        LsMqtt jm = (LsMqtt)dcjs.ReadObject(ms);

        Data = jm;
        _msgPoll = false;
        ms.Close();
        Recv();
      } catch( Exception ex ) {
        string s;

        Log(ex.Message);
        s = Encoding.UTF8.GetString(e.Message);
        Log(s);
      }
    }
    private void ConnectionClosed(object sender, EventArgs e) {
      if( State == States.Unsubscribed ) {
        State = States.Disconnected;
        Log("Disconnect");
      } else {
        int num = int.Parse(ConfigurationManager.AppSettings["AutoReconnect"]);

        Log("Mqtt connection closed", 9);
        for( int i = 0; i < num; i++ ) {
          System.Threading.Thread.Sleep(10000);
          if( _mqtt.IsConnected ) { Log("Mqtt is connected"); break; } else if( Start(false) ) { Log("Mqtt reconnected"); break; } else Log(string.Format("Mqtt reconnect {0} failed", i), 1);
        }
      }
    }

#if PLUGIN
    private void LogPlugin(string log) { Log(log); }
    public void LoadPlugins(string dir) {
      Plugins.Clear();
      DeskApp._send = Publish;
      DeskApp._trace = LogPlugin;

      foreach( string script in Directory.GetFiles(dir, "*.cs") ) {
        using( StreamReader sr = new StreamReader(script) ) {
          try {
            string scriptCode = sr.ReadToEnd();
            string name = Path.GetFileNameWithoutExtension(script);
            AsmHelper helper = new AsmHelper(CSScript.LoadCode(scriptCode, null, false));
            IPlugin plugin = helper.CreateObject(name) as IPlugin;

            Plugins.Add(name, plugin);
          } catch( Exception ex ) {
            //MessageBox.Show(ex.ToString(), "Load Plugin " + script, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Log(ex.ToString());
          }
          sr.Close();
        }
      }
    }
#endif
  }
}
