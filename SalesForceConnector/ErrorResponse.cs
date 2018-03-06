using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;

namespace SalesForceConnector
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string message { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string errorCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<string> fields { get; set; }
        public ErrorResponse() { }
    }
}
