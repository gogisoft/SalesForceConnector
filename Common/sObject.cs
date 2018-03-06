using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;

namespace Common
{
    [DataContract]
    public class sObject<T>
    {
        [DataMember]
        public Attributes attributes { get; set; }

        [DataMember]
        public string Id { get; set; }

        public sObject() { }

        public sObject(string json)
        {
            HydrateFromJSon(json);
        }
        public string GetJSon()
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        private void HydrateFromJSon(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                var details = ser.ReadObject(ms);
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    property.SetValue(this, property.GetValue(details, null), null);
                }
            }
        }
    }
}
