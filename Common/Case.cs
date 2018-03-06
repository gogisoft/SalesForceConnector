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
    public class Case : sObject<Case>
    {
        #region Standard Fields
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public string AccountId { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public String OwnerId { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public String Status { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public String Priority { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public String Subject { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        [DataMember]
        public String Type { get; set; }

        #endregion

        public Case()
            : base() { }
        public Case(string json)
            : base(json)
        {

        }

    }
}
