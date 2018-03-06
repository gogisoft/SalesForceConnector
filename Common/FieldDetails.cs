using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    [DataContract]
    public class FieldDetails
    {
        [DataMember]
        public bool activateable { get; set; }
        [DataMember]
        public ChildRelationShip[] childRelationships { get; set; }
        [DataMember]
        public Field[] fields { get; set; }

        public string keyPrefix { get; set; }
        public string label { get; set; }
        public string labelPlural { get; set; }
        public bool layoutable { get; set; }
        public object listviewable { get; set; }
        public object lookupLayoutable { get; set; }
        public bool mergeable { get; set; }
        public string name { get; set; }
        public bool queryable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public RecordTypeInfos[] recordTypeInfos { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public URLs urls { get; set; }

        public string GetJSon()
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            ser.WriteObject(ms, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        private void HydrateFromJSon(string json)
        {
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            var details = ser.ReadObject(ms);
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                property.SetValue(this, property.GetValue(details, null), null);
            }
        }
    }
}
