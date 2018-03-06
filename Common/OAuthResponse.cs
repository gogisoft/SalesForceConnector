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
    public class OAuthResponse
    {
        #region Upsert response object properties
        /// <summary>
        /// Id of object created after insert.
        /// </summary>
        [DataMember]
        public String id { get; set; }
        /// <summary>
        /// Property indicating status of upsert attempt.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String success { get; set; }
        /// <summary>
        /// Property indicating errors returned from upsert attempt.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string[] errors { get; set; }
        #endregion

        #region OAuth reponse properties
        [DataMember]
        public String access_token { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String refresh_token { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String issued_at { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String token_type { get; set; }
        #endregion

        public OAuthResponse(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                HydrateFromJSon(json);
            }
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
