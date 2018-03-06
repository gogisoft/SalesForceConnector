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
    /// <summary>
    /// Class responsible for executing complex NoSQL queries in Salesforce.
    /// </summary>
    [DataContract]
    public class QueryResult<T>
    {
        /// <summary>
        /// Property holds total numbers of records available.
        /// </summary>
        [DataMember]
        public Int32 totalSize { get; set; }
        /// <summary>
        /// Property to indicate when all records have been retrieved.
        /// </summary>
        [DataMember]
        public Boolean done { get; set; }
        /// <summary>
        /// Property holds url used to retreived next group of records.
        /// </summary>
        [DataMember]
        public String nextRecordsUrl { get; set; }
        /// <summary>
        /// Property holds collection of all objects retreived.
        /// </summary>
        [DataMember]
        public List<T> records { get; set; }
        /// <summary>
        /// Method to hydrate object from specified json string.
        /// </summary>
        /// <param name="json"></param>
        public void HydrateFromJSon(string json)
        {
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(QueryResult<T>));
            QueryResult<T> result = (QueryResult<T>)ser.ReadObject(ms);
            if (result.records == null)
            {
                result.records = new List<T>();
            }
            foreach (PropertyInfo property in typeof(QueryResult<T>).GetProperties())
            {
                property.SetValue(this, property.GetValue(result, null), null);
            }

        }
    }
}
