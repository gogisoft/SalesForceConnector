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
using System.Dynamic;

namespace Common
{
    /// <summary>
    /// Dynamic class responsible for creating JSON strings form dynamic fields for Upsert operations in SalesForce
    /// </summary>
    public class DynamicUpsert : DynamicObject
    {
        public string Id { get; set; }

        Dictionary<string, object> properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.ContainsKey(binder.Name))
            {
                result = properties[binder.Name];
                return true;
            }
            else
            {
                result = "Invalid Property!";
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties[binder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = properties[binder.Name];
            result = method(args[0].ToString(), args[1].ToString());
            return true;
        }

        /// <summary>
        /// JSON string created by the DynamicUpsert class.
        /// </summary>
        /// <returns></returns>
        public string GetJSon()
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, object>), new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true });
            ser.WriteObject(ms, properties);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
