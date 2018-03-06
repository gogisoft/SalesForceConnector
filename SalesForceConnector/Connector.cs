using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Xml;
using Common;
using SalesForceConnector.Interface;

namespace SalesForceConnector
{
    /// <summary>
    /// This class is mainly concerned with optimizing performance by minimizing the number of real calls to the SalesForce REST services.
    /// The purpose of this class is seperation of work by managing ISubject implementations.
    /// </summary>
    public class Connector : ConnectorBase
    {
        #region Properties
        private static ProxySubject Proxy;
        private static RealSubject RS;
        private static Connector _Instance;
        private String _SFUrl;
        private ISubject Subject;
        #endregion

        #region REST URLs
        /// <summary>
        /// REST URL top domain
        /// </summary>
        public string RESTDomainURL
        {
            get
            {
                if (String.IsNullOrEmpty(_SFUrl) == true)
                {
                    _SFUrl = ConnectorConfig.Instance.URL;
                    if (_SFUrl.Substring(_SFUrl.Length - 1) != "/")
                    {
                        _SFUrl = _SFUrl + "/";
                    }
                }
                return _SFUrl;
            }
        }
        /// <summary>
        /// REST URL to SalesForce querys with trailing slash (services/data/v20.0/query/)
        /// </summary>
        public string QueryURL
        {
            get
            {
                String url = RESTDomainURL + "services/data/v20.0/query/";
                return url;
            }
        }
        /// <summary>
        /// REST URL to SalesForce objects with trailing slash (services/data/v20.0/sobjects/)
        /// </summary>
        public string ObjectsURL
        {
            get
            {
                String url = RESTDomainURL + "services/data/v20.0/sobjects/";
                return url;
            }
        }
        /// <summary>
        /// REST URL to SalesForce authentication with trailing slash (services/oauth2/)
        /// </summary>
        public string OAuthURL
        {
            get
            {
                String url = RESTDomainURL + "services/oauth2/";
                return url;
            }
        }
        #endregion

        #region Static methods
        private void Initialize()
        {
            //Initialize the proxy subject
            Proxy = new ProxySubject();
            Proxy.QueryURL = _Instance.QueryURL;
            Proxy.ObjectsURL = _Instance.ObjectsURL;
            Proxy.RESTDomainURL = _Instance.RESTDomainURL;
            Proxy.LoadGlobals();
            //Initialize the real subject
            RS = new RealSubject();
            RS.QueryURL = _Instance.QueryURL;
            RS.ObjectsURL = _Instance.ObjectsURL;
            RS.RESTDomainURL = _Instance.RESTDomainURL;
            RS.LoadGlobals();
            //Initialize StaticObjects
            Instance.GetStaticObjects().OAuthURL = _Instance.OAuthURL;
            Instance.GetStaticObjects().ObjectsURL = _Instance.ObjectsURL;

        }
        public static Connector Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Connector();
                    _Instance.Initialize();
                }
                return _Instance;
            }
        }
        #endregion

        #region Helper Methods
        public string GetSecurityToken()
        {
            return GetStaticObjects().SecurityToken;
        }
        public List<Field> GetContactFields()
        {
            return GetStaticObjects().ContactFields;
        }
        public List<Field> GetAccountFields()
        {
            return GetStaticObjects().AccountFields;
        }
        #endregion

        #region Account
        /// <summary>
        /// Method will upsert specified Account.
        /// </summary>
        /// <param name="a">Account</param>
        /// <returns>NetResponse</returns>
        public NetResponse SaveAccount(Account a)
        {
            Subject = RS;
            NetResponse NR = Subject.SaveAccount(a);
            if (NR.OAuthResponse.success.ToLower() == "true")
            {
                Proxy.RefreshAccounts();
            }
            return NR;
        }
        public List<Account> GetAccounts()
        {
            Subject = Proxy;
            NetResponse NR = Subject.GetAccounts();
            if (!string.IsNullOrEmpty(NR.JSON))
            {
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(NR.JSON));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Account>));
                var details = ser.ReadObject(ms) as List<Account>;
                return details;
            }
            else
            {
                Subject = RS;
                NR = Subject.GetAccounts();
                QueryResult<Account> qResult = new QueryResult<Account>();
                qResult.HydrateFromJSon(NR.JSON);
                return qResult.records;
            }
        }
        public Account GetAccount(string id)
        {
            Subject = Proxy;
            NetResponse NR = Subject.GetAccount(id);
            if (string.IsNullOrEmpty(NR.JSON))
            {
                Subject = RS;
                NR = Subject.GetAccount(id);
            }
            Account result = new Account(NR.JSON);
            if (!string.IsNullOrEmpty(result.Id))
                return result;
            else
                return null;
        }
        public Account GetAccountByName(string name)
        {
            Subject = Proxy;
            NetResponse NR = Subject.GetAccountByName(name);
            QueryResult<Account> qResult = new QueryResult<Account>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
            {
                return qResult.records.First();
            }
            return null;
        }
        #endregion

        #region Contact
        public NetResponse SaveContact(Contact c)
        {
            Subject = RS;
            return Subject.SaveContact(c);
        }
        /// <summary>
        /// Method will upsert specified Contact Role with specified Account information.
        /// </summary>
        /// <param name="c">Contact</param>
        /// <param name="a">Account</param>
        /// <returnsNetResponsereturns>
        public NetResponse SaveContactRole(Contact c, Account a)
        {
            ContactRole role = new ContactRole();
            Subject = RS;
            NetResponse NR = Subject.SaveContactRole(role);
            return NR;
        }
        public Contact GetContact(string contactid)
        {
            Subject = RS;
            NetResponse NR = Subject.GetContact(contactid);
            Contact result = new Contact(NR.JSON);
            if (!string.IsNullOrEmpty(result.Id))
                return result;
            else
                return null;
        }
        public Contact GetContactByEmail(string email)
        {
            Subject = RS;
            NetResponse NR = Subject.GetContactByEmail(email);
            QueryResult<Contact> qResult = new QueryResult<Contact>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
            {
                return qResult.records.First();
            }
            return null;
        }
        public NetResponse GetContactDescribe()
        {
            Subject = RS;
            return Subject.GetContactDescribe();
        }
        /// <summary>
        /// Method validates contact email and password by returning the salesforce id. Null string is return if validation fails.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string ValidateContact(string email, string password)
        {
            Subject = RS;
            NetResponse NR = Subject.ValidateContact(email, password);
            QueryResult<Contact> qResult = new QueryResult<Contact>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count() > 0)
            {
                return qResult.records[0].Id;
            }
            return string.Empty;
        }
        public List<ContactRole> GetContactRoles(string contactid)
        {
            Subject = RS;
            NetResponse NR = Subject.GetContactRoles(contactid);
            QueryResult<ContactRole> qResult = new QueryResult<ContactRole>();
            qResult.HydrateFromJSon(NR.JSON);
            return qResult.records;
        }
        public List<Contact> GetContacts()
        {
            Subject = RS;
            NetResponse NR = Subject.GetContacts();
            QueryResult<Contact> qResult = new QueryResult<Contact>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
                return qResult.records;
            else
                return null;
        }
        #endregion

        #region Case
        /// <summary>
        /// Method will upsert specified Case.
        /// </summary>
        /// <param name="sObject">Case</param>
        /// <returns>NetResponse</returns>
        public NetResponse SaveCase(Case c)
        {
            Subject = RS;
            NetResponse NR = Subject.SaveCase(c);
            return NR;
        }
        public Case GetCase(string Id)
        {
            Subject = RS;
            NetResponse NR = Subject.GetCase(Id);
            Case result = new Case(NR.JSON);
            if (!string.IsNullOrEmpty(result.Id))
                return result;
            else
                return null;
        }
        public List<Case> GetCasesByAccount(string acctId)
        {
            Subject = RS;
            NetResponse NR = Subject.GetCasesByAccount(acctId);
            QueryResult<Case> qResult = new QueryResult<Case>();
            qResult.HydrateFromJSon(NR.JSON);
            return qResult.records;
        }
        public List<Case> GetCasesByContact(string contactId)
        {
            Subject = RS;
            NetResponse NR = Subject.GetCasesByContact(contactId);
            QueryResult<Case> qResult = new QueryResult<Case>();
            qResult.HydrateFromJSon(NR.JSON);
            return qResult.records;
        }
        public List<Case> GetCases()
        {
            Subject = RS;
            NetResponse NR = Subject.GetCases();
            QueryResult<Case> qResult = new QueryResult<Case>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
                return qResult.records;
            else
                return null;
        }
        #endregion

        #region User
        public User GetUser(string username)
        {
            Subject = RS;
            NetResponse NR = Subject.GetUser(username);
            QueryResult<User> qResult = new QueryResult<User>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
                return qResult.records.FirstOrDefault();
            else
                return null;
        }
        public List<User> GetUsers()
        {
            Subject = RS;
            NetResponse NR = Subject.GetUsers();
            QueryResult<User> qResult = new QueryResult<User>();
            qResult.HydrateFromJSon(NR.JSON);
            if (qResult.records.Count > 0)
                return qResult.records;
            else
                return null;
        }
        #endregion


    }
    /// <summary>
    /// Class responsible for storing persitant data.
    /// </summary>
    public class ConnectorBase
    {
        private StaticObjects StaticObjectsInstance;
        protected StaticObjects GetStaticObjects()
        {
            if (StaticObjectsInstance == null)
            {
                StaticObjectsInstance = new StaticObjects();
            }
            return StaticObjectsInstance;
        }
    }
}
