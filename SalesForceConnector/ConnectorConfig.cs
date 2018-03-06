using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceConnector
{
    /// <summary>
    /// Singleton Connector configuration object
    /// </summary>
    public class ConnectorConfig
    {
        #region SalesForce Configuration Properties
        /// <summary>
        /// SalesForce user account login name for OAuth (Setup/User)
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// SalesForce user account password for OAuth (Setup/User)
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// SalesForce user account security token for OAuth (Setup/User)
        /// </summary>
        public string SecurityToken { get; set; }
        /// <summary>
        /// SalesForce application authentication token (Application Connect)
        /// </summary>
        public string ClientID { get; set; }
        /// <summary>
        /// SalesForce application authentication token (Application Connect)
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// OAuth type (Optional)
        /// </summary>
        public string GrantType { get; set; }
        /// <summary>
        /// SalesForce deployment url (https://c1.salesforce.com/ )
        /// </summary>
        public string URL { get; set; }
        #endregion

        private static ConnectorConfig _config = null;
        /// <summary>
        /// Singleton instance of this configuration class
        /// </summary>
        public static ConnectorConfig Instance
        {
            get
            {
                if (_config == null)
                    _config = new ConnectorConfig();
                return _config;
            }
        }

    }
}
