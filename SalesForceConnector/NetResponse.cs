using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using Common;

namespace SalesForceConnector
{
    public class NetResponse
    {
        /// <summary>
        /// Property indicates SalesForce returned an error
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// Property indicates that SalesForce responded with an authentication error.
        /// </summary>
        public bool HasAuthenticationError { get; set; }
        /// <summary>
        /// Error message returned from SalesForce
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// RAW JSON string returned from SalesForce
        /// </summary>
        public string JSON { get; set; }
        /// <summary>
        /// Object with error information
        /// </summary>
        public List<ErrorResponse> ErrorResponses { get; set; }
        /// <summary>
        /// Reference to object containing OAuth information
        /// </summary>
        public OAuthResponse OAuthResponse { get; set; }
    }
}
