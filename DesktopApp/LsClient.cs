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
    [DataMember(Name = "access_token")]
    public string Token;
    [DataMember(Name = "expires_in")]
    public int Expires;
    [DataMember(Name = "token_type")]
    public string Type;
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
  [DataContract]
  public struct LsMqttTopic {
    [DataMember(Name = "command_in")]
    public string CmdIn;
    [DataMember(Name = "command_out")]
    public string CmdOut;
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
    [DataMember(Name = "mqtt_topics")]
    public LsMqttTopic Topic;
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

      b = Email == lsj.Email && Password == lsj.Password && Uuid == lsj.Uuid && Name == lsj.Name && Broker == lsj.Broker && MacAdr == lsj.MacAdr;
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

  public delegate void ErrDelegte(string msg);
  public delegate void LogDelegte(string log, int c = 0);
  public delegate void MqttDelegate();

  //public static partial class DeskApp {
  //  internal static DelegateString _send { get; set; }
  //  internal static DelegateString _trace { get; set; }
  //}

  public class LsClient {
    private WebClient _client = new WebClient();
    private X509Certificate2 _certWX = null;
    private MqttClient _mqtt = null;
    private string _uuid, _board, _mac;
    private string _cmdIn;
    private string[] _cmdOut;
    private byte[] _cmdQos;
    private ushort _msgId = 0;
    private bool _msgPoll = false;

    public string Broker { get; private set; }

    public List<LsProductItem> Products = new List<LsProductItem>();
    public Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

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
    public bool Login(string mail, string pass, string uuid) {
      return WebApi(mail, pass, uuid);
    }
    public bool WorxApiV1(string mail, string pass, string uuid) {
      NameValueCollection nvc = new NameValueCollection();
      string str;
      string api = ConfigurationManager.AppSettings["ApiWorx"];
      string tok = ConfigurationManager.AppSettings["TokWorx"];
      byte[] buf;

      //ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;

      nvc.Add("email", mail);
      nvc.Add("password", pass);
      nvc.Add("type", "app");
      nvc.Add("platform", "android");
      nvc.Add("uuid", uuid);

      try {
        #region User auth
        _client.Headers["X-Auth-Token"] = tok;
        buf = _client.UploadValues(api + "users/auth", nvc);
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("User auth: {0}", str);
        Log(string.Format("User auth: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(WorxUser));
          WorxUser wu = (WorxUser)dcjs.ReadObject(ms);

          Log(string.Format("User token '{0}'", wu.ApiToken));
          Broker = wu.MqttEndpoint;
          _client.Headers["X-Auth-Token"] = wu.ApiToken;
          ms.Close();
        }
        #endregion

        #region Product items
        buf = _client.DownloadData(api + "product-items");
        str = Encoding.UTF8.GetString(buf);
        Log(string.Format("Product items: {0}", str), 1);
        Debug.WriteLine("Product items: {0}", str);
        str = string.Empty;
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<LsProductItem>));
          Products = (List<LsProductItem>)dcjs.ReadObject(ms);

          ms.Close();
        }
        #endregion

        #region Status
        foreach( LsProductItem pi in Products ) {
          buf = _client.DownloadData(api + "product-items/" + pi.SerialNo + "/status");
          str = Encoding.UTF8.GetString(buf);
          Log(string.Format("Status {0}: {1}", pi.Name, str), 1);
          Debug.WriteLine("Status {0}: {1}", pi.Name, str);
        }
        #endregion

        #region Certificate
        buf = _client.DownloadData(api + "users/certificate");
        str = Encoding.UTF8.GetString(buf);
        Log(string.Format("AWS Certificate: {0}", str), 1);
        Debug.WriteLine("AWS Certificate: {0}", str);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsCertificate));
          LsCertificate lsc = (LsCertificate)dcjs.ReadObject(ms);

          ms.Close();
          str = lsc.Pkcs12.Replace("\\/", "/");
          buf = Convert.FromBase64String(str);
          File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AWS.p12"), buf);
          _certWX = new X509Certificate2(buf);
          string mac = Products.Count > 0 ? Products[0].MacAdr.Substring(5) : "000000";
          int xx = int.Parse(mac, System.Globalization.NumberStyles.HexNumber) ^ 0xE1588A;

          Log(string.Format("AWS certificate done ({0})", xx), 2);
          //buf = _certWX.Export(X509ContentType.Cert);
          //File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WX.p12"), buf);
        }
        #endregion
      } catch( Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      buf = null;
      return true;
    }
    public bool WebApi(string mail, string pass, string uuid) {
      NameValueCollection nvc = new NameValueCollection();
      string str;
      string api = ConfigurationManager.AppSettings["WebApi"];
      string sec = ConfigurationManager.AppSettings["CliSec"];
      byte[] buf;

      #region Anmeldung
      nvc.Add("username", mail);
      nvc.Add("password", pass);
      nvc.Add("grant_type", "password");
      nvc.Add("client_id", "1");
      nvc.Add("client_secret", sec);
      nvc.Add("scope", "*");
      try {
        buf = _client.UploadValues(api + "oauth/token", nvc);
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Oauth token: {0}", str);
        Log(string.Format("Oauth token: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(LsOAuth));
          LsOAuth lsoa = (LsOAuth)dcjs.ReadObject(ms);

          _client.Headers["Authorization"] = string.Format("{0} {1}", lsoa.Type, lsoa.Token);
          ms.Close();
        }
      } catch( Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }
      #endregion

      try {
        #region Benutzer
        buf = _client.DownloadData(api + "users/me");
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

        #region Certificate
        buf = _client.DownloadData(api + "users/certificate");
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

        #region Product items
        buf = _client.DownloadData(api + "product-items");
        str = Encoding.UTF8.GetString(buf);
        Debug.WriteLine("Product items: {0}", str);
        Log(string.Format("Product items: {0}", str), 1);
        using( MemoryStream ms = new MemoryStream(buf) ) {
          DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<LsProductItem>));
          Products = (List<LsProductItem>)dcjs.ReadObject(ms);

          ms.Close();
        }
        #endregion

        #region Status
        buf = null;
        foreach( LsProductItem pi in Products ) {
          buf = _client.DownloadData(api + "product-items/" + pi.SerialNo + "/status");
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
      } catch( Exception ex ) {
        Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      buf = null;
      return !string.IsNullOrEmpty(Broker) && _certWX != null && Products.Count > 0;
    }
    public bool LoadAWS() {
      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AWS" + ArgCfg() + ".p12");

      if( File.Exists(path) ) {
        try {
          _certWX = new X509Certificate2(path);
          return true;
        } catch( Exception ex ) {
          Log(ex.ToString());
        }
      }
      return false;
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

    public bool Start(string broker, string uuid, string board, string mac, bool first = true) {
      Broker = broker; _uuid = "android-" + uuid; _board = board; _mac = mac;
      Log(string.Format("Broker: '{0}'", broker));
      Log(string.Format("Topic: '{0}/{1}'", board, mac));
      _cmdIn = string.Format("{0}/{1}/commandIn", board, mac);
      _cmdOut = new string[] { string.Format("{0}/{1}/commandOut", board, mac) };
      _cmdQos = new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE }; // | MqttMsgBase.QOS_LEVEL_GRANTED_FAILURE 

      try {
        _mqtt = new MqttClient(broker, 8883, true, null, _certWX, MqttSslProtocols.TLSv1_2);
      } catch( Exception ex ) {
        if( first ) Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      try {
        _mqtt.MqttMsgSubscribed += MqttMsgSubscribed;
        _mqtt.MqttMsgPublished += MqttMsgPublished;
        _mqtt.MqttMsgPublishReceived += MqttMsgPublishReceived;
        _mqtt.ConnectionClosed += ConnectionClosed;

        byte code = _mqtt.Connect(_uuid);
        Log(string.Format("Connect '{0} ({1})'", code, _mqtt.IsConnected));

        _mqtt.Subscribe(_cmdOut, _cmdQos);
        Log(string.Format("Subscribe init"));

        _msgId = _mqtt.Publish(_cmdIn, Encoding.ASCII.GetBytes("{}"));
        _msgPoll = true;
        Log(string.Format("Publish send '{0}'", _msgId));
      } catch( Exception ex ) {
        if( first ) Err(ex.Message);
        Log(ex.ToString(), 9);
        return false;
      }

      return true;
    }

    public void Exit() {
      if( _mqtt != null && _mqtt.IsConnected ) {
        _mqtt.ConnectionClosed -= ConnectionClosed;
        _mqtt.MqttMsgPublishReceived -= MqttMsgPublishReceived;
        _mqtt.MqttMsgPublished -= MqttMsgPublished;
        _mqtt.MqttMsgSubscribed -= MqttMsgSubscribed;
        _mqtt.Unsubscribe(_cmdOut);
        try { _mqtt.Disconnect(); } catch { }
        _mqtt = null;
      }
    }

    public bool Connected { get { return _mqtt != null && _mqtt.IsConnected; } }
    public bool Polling { get { return _msgPoll && _mqtt != null && _mqtt.IsConnected; } }
    public void Poll() {
      _msgId = _mqtt.Publish(_cmdIn, Encoding.UTF8.GetBytes("{}"));
      _msgPoll = true;
    }
    public void Publish(string s) {
      _msgId = _mqtt.Publish(_cmdIn, Encoding.UTF8.GetBytes(s));
    }
    private void MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e) {
      Log(string.Format("Subscribe done '{0}'", e.MessageId));
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
      Log("Mqtt connection closed", 9);
      for( int i = 0; i < 10; i++ ) {
        System.Threading.Thread.Sleep(10000);
        if( _mqtt.IsConnected ) { Log("Mqtt is connected"); break; }
        else if( Start(Broker, _uuid, _board, _mac, false) ) { Log("Mqtt reconnected"); break; }
        else Log(string.Format("Mqtt reconnect {0} failed", i), 1);
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
