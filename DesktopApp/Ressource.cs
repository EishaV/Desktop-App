using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace DesktopApp {
    //public void Serialize(string filename, Dictionary<TKey, TValue> dictionary) {
    //  using( var writer = new StreamWriter(filename) ) {
    //    _serializer.Serialize(writer, dictionary.Select(p => new Item() { Key = p.Key, Value = p.Value }).ToArray());
    //  }
    //}

  public class Ressource {
    [XmlType(TypeName = "string")]
    public class Item {
      [XmlAttribute("name")]
      public string Key;
      [XmlText]
      public string Value;
    }

    static SortedDictionary<string, string> _res = null;

    static Ressource() {
      string lng = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
      string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "strings." + lng + ".xml");
      XmlSerializer xs = new XmlSerializer(typeof(Item[]), new XmlRootAttribute("resources"));
      Item[] tmp;

      //using( FileStream stream = new FileStream(fn, FileMode.Open) )
      //using( XmlReader reader = XmlReader.Create(stream) ) {
      //  _res = ((Item[])xs.Deserialize(reader)).ToDictionary(p => p.Name, p => p.Value);
      //}

      if( !File.Exists(fn) ) fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "strings.de.xml");
      try {
        using( FileStream fs = new FileStream(fn, FileMode.Open) ) tmp = (xs.Deserialize(fs) as Item[]);
        _res = new SortedDictionary<string, string>(tmp.ToDictionary(item => item.Key, item => item.Value));
        tmp = null;
      } catch( Exception ex ) {
        Debug.WriteLine(ex.ToString());
      }
    }

    public static string Get(string name) { return _res != null && _res.ContainsKey(name) ? _res[name] : name; }
  }
}
