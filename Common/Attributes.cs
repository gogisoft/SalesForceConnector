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
    public class Attributes
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string url { get; set; }

    }
}
