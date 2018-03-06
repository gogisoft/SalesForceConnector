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
    public class HTTPPatchRequest
    {
        private string _url;
        private string _json;
        public HTTPPatchRequest(string url, string json)
        {
            this._url = url;
            this._json = json;
        }
        public NetResponse Execute()
        {
            NetResponse NR = new NetResponse();
            try
            {
                NR.HasError = false;
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(_json);
                // Send the data to Salesforce
                var request = (HttpWebRequest)(HttpWebRequest.Create(_url));
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false;
                request.Method = "PATCH";
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = bytes.Length;

                // Attach the access token and JSON to the request to Salesforce.
                request.Headers.Add("Authorization: OAuth " + Connector.Instance.GetSecurityToken());
                using (var requestWriter = new StreamWriter(request.GetRequestStream()))
                {
                    requestWriter.Write(_json);
                    requestWriter.Flush();
                    requestWriter.Close();
                }

                // Send the object to Salesforce
                var response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var data = reader.ReadToEnd();
                    OAuthResponse oRes = new OAuthResponse(data);
                    NR.JSON = data;
                    NR.OAuthResponse = oRes;
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
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NR.HasError = true;
                NR.ErrorMessage = ex.Message;
            }
            return NR;
        }
    }
}
