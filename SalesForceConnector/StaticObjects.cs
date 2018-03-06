using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Common;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using SalesForceConnector.Network;

namespace SalesForceConnector
{
    public class StaticObjects
    {
        public string ObjectsURL { get; set; }
        public string OAuthURL { get; set; }

        private string _SecurityToken = String.Empty;
        private string _RefreshToken = String.Empty;
        private List<Account> _Accounts = new List<Account>();
        private List<Field> _ContactFields = new List<Field>();
        private List<Field> _AccountFields = new List<Field>();
        private DateTime SessionStart;

        public string SecurityToken
        {
            get
            {
                double sessionDuration = (DateTime.Now - SessionStart).TotalHours;
                if (_SecurityToken == string.Empty)
                {
                    _SecurityToken = GetAuthToken();
                }
                else if (sessionDuration >= 5)
                {
                    RevokeToken(_SecurityToken);
                    _SecurityToken = GetAuthToken();
                }

                return _SecurityToken;
            }
        }
        public void ClearSecurityToken()
        {
            _SecurityToken = string.Empty;
        }

        public List<Field> ContactFields
        {
            get
            {
                if (_ContactFields.Count == 0)
                {
                    Field[] fields = GetContactFields();
                    if (fields != null)
                    {
                        _ContactFields.AddRange(fields);
                    }
                }
                return _ContactFields;
            }
        }
        public void ClearContactFields()
        {
            _ContactFields.Clear();
        }

        public List<Field> AccountFields
        {
            get
            {
                if (_AccountFields.Count == 0)
                {
                    Field[] fields = GetAccountFields();
                    if (fields != null)
                    {
                        _AccountFields.AddRange(fields);
                    }
                }
                return _AccountFields;
            }
        }

        private Field[] GetContactFields()
        {
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + "Contact/describe");
            NetResponse NR = client.Execute();
            if (NR.HasError == false)
            {
                sOjbectDescribe details = new sOjbectDescribe(NR.JSON);
                return details.fields;
            }
            return null;
        }
        private Field[] GetAccountFields()
        {
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + "Account/describe");
            NetResponse NR = client.Execute();
            if (NR.HasError == false)
            {
                sOjbectDescribe details = new sOjbectDescribe(NR.JSON);
                return details.fields;
            }
            return null;
        }

        private void RefreshToken()
        {
            SessionStart = DateTime.Now;
            string token = _SecurityToken;
            string clientid = ConnectorConfig.Instance.ClientID;
            string clientsecret = ConnectorConfig.Instance.ClientSecret;

            try
            {
                WebClient client = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                byte[] response =
                client.UploadValues(OAuthURL + "token", "POST",
                    new NameValueCollection() {
                        { "grant_type", "refresh_token" },
                        { "client_id", clientid},
                        { "client_secret", clientsecret },
                        { "refresh_token", token }
                });
                token = System.Text.Encoding.UTF8.GetString(response);
            }
            catch (WebException wex)
            {

                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                        }
                    }
                }
            }
            OAuthResponse oResponse = new OAuthResponse(token);
            _SecurityToken = oResponse.access_token;
            //revoke the old one.
            RevokeToken(token);

        }
        private void RevokeToken(string token)
        {
            SessionStart = DateTime.Now;
            string clientid = ConnectorConfig.Instance.ClientID;
            string clientsecret = ConnectorConfig.Instance.ClientSecret;

            try
            {
                WebClient client = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                byte[] response =
                client.UploadValues(OAuthURL + "revoke", "POST",
                    new NameValueCollection() {
                        { "token", token }
                });
                token = System.Text.Encoding.UTF8.GetString(response);
            }
            catch (WebException wex)
            {

                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// SalesForce REST API authentication token needed for each REST call.
        /// </summary>
        /// <returns></returns>
        private string GetAuthToken()
        {

            SessionStart = DateTime.Now;
            string token = string.Empty;
            string securitytoken = ConnectorConfig.Instance.SecurityToken;
            string clientid = ConnectorConfig.Instance.ClientID;
            string clientsecret = ConnectorConfig.Instance.ClientSecret;
            string username = ConnectorConfig.Instance.UserName;
            string password = ConnectorConfig.Instance.Password;

            try
            {
                WebClient client = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                byte[] response =
                client.UploadValues(OAuthURL + "token", "POST",
                    new NameValueCollection() {
                        { "grant_type", "password" },
                        { "client_id", clientid},
                        { "client_secret", clientsecret },
                        { "username", username },
                        { "password", password + securitytoken }
                });
                token = System.Text.Encoding.UTF8.GetString(response);
            }
            catch (WebException wex)
            {

                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                        }
                    }
                }
            }
            OAuthResponse oResponse = new OAuthResponse(token);
            _RefreshToken = oResponse.refresh_token;
            return oResponse.access_token;
        }
        public void CancelToken()
        {
            RevokeToken(_SecurityToken);
            _SecurityToken = string.Empty;
        }
    }
}
