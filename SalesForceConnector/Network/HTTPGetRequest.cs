using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Reflection;
using Common;

namespace SalesForceConnector.Network
{
    /// <summary>
    /// HTTP client uses GET to make JSON request. Thee action method return the JSON string.
    /// </summary>
    public class HTTPGetRequest
    {
        private Connector sfConnector;
        private string _url;
        private int numOfRetries = 0;
        public HTTPGetRequest(string url)
        {
            this.sfConnector = Connector.Instance;
            this._url = url;
            this.numOfRetries = 0;
        }
        public NetResponse Execute()
        {
            NetResponse NR = new NetResponse();
            NR.HasError = false;

            try
            {
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(_url);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                // If required by the server, set the credentials.
                request.Method = "GET";
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Headers.Add("Authorization", "OAuth " + sfConnector.GetSecurityToken());
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        NR.JSON = responseFromServer;
                    }
                }
            }
            catch (WebException wex)
            {
                NR.HasError = true;
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            NR.ErrorMessage = error;
                            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(error));
                            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<ErrorResponse>));
                            List<ErrorResponse> errResponses = (List<ErrorResponse>)ser.ReadObject(ms);
                            if (errResponses != null)
                            {
                                NR.ErrorResponses = errResponses;
                                if (error.ToUpper().Contains("INVALID_SESSION_ID"))
                                {
                                    NR.HasAuthenticationError = true;
                                }
                            }
                        }
                    }
                }
            }

            return NR;
        }
    }
}
