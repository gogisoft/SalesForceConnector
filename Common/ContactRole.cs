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
    public class ContactRole : sObject<ContactRole>
    {
        #region Standard Properties
        [DataMember]
        public String Name { get; set; }
        #endregion

        public ContactRole()
            : base() { }
        public ContactRole(string json)
            : base(json)
        {

        }

    }
}
