using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Common;
using SalesForceConnector.Network;

namespace SalesForceConnector.Interface
{
    /// <summary>
    /// Live implementation of ISubject
    /// The methods make live calls to SalesForce REST services.
    /// All methods MUST return NetResponse!
    /// </summary>
    public class RealSubject : ISubject
    {
        public string ObjectsURL { get; set; }
        public string QueryURL { get; set; }
        public string RESTDomainURL { get; set; }
        public RealSubject()
        {
        }

        #region Public Methods
        public void LoadGlobals()
        {
        }
        public NetResponse SaveObject(DynamicUpsert upsertObject, string objectName)
        {
            if (string.IsNullOrEmpty(upsertObject.Id))
            {
                //New record
                HTTPPostRequest client = new HTTPPostRequest(ObjectsURL + "" + objectName + "/", upsertObject.GetJSon());
                return client.Execute();
            }
            else
            {
                //Update existing record
                string Id = upsertObject.Id;
                upsertObject.Id = null;
                HTTPPatchRequest client = new HTTPPatchRequest(ObjectsURL + "" + objectName + "/" + Id + "/", upsertObject.GetJSon());
                return client.Execute();
            }
        }
        #endregion

        #region Helper Methods

        #endregion

        #region Account
        public NetResponse SaveAccount(Account sObject)
        {
            string objectName = "Account";
            if (string.IsNullOrEmpty(sObject.Id))
            {
                //New record
                HTTPPostRequest client = new HTTPPostRequest(ObjectsURL + "" + objectName + "/", sObject.GetJSon());
                return client.Execute();
            }
            else
            {
                //Update existing record
                string Id = sObject.Id;
                sObject.Id = null;
                HTTPPatchRequest client = new HTTPPatchRequest(ObjectsURL + "" + objectName + "/" + Id + "/", sObject.GetJSon());
                return client.Execute();
            }
        }
        public NetResponse GetAccounts()
        {
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + "?q=" + QueryStrings.Accounts_Select + "+WHERE+InActive__c=false");
            NetResponse NR = client.Execute();
            return NR;
        }
        public NetResponse GetAccount(string id)
        {
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + "Account/" + id);
            NetResponse NR = client.Execute();
            return NR;
        }
        public NetResponse GetAccountByName(string name)
        {
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + "?q=" + QueryStrings.Accounts_Select + "+Where+Name='" + name + "'+And+InActive__c=false");
            NetResponse NR = client.Execute();
            return NR;
        }
        #endregion

        #region Contact
        public NetResponse SaveContact(Contact sObject)
        {
            string objectName = "Contact";
            if (string.IsNullOrEmpty(sObject.Id))
            {
                //New record
                HTTPPostRequest client = new HTTPPostRequest(ObjectsURL + "" + objectName + "/", sObject.GetJSon());
                return client.Execute();
            }
            else
            {
                //Update existing record
                string Id = sObject.Id;
                sObject.Id = null;
                HTTPPatchRequest client = new HTTPPatchRequest(ObjectsURL + "" + objectName + "/" + Id + "/", sObject.GetJSon());
                return client.Execute();
            }
        }
        public NetResponse SaveContactRole(ContactRole sObject)
        {
            string objectName = "ContactRole__c";
            if (string.IsNullOrEmpty(sObject.Id))
            {
                //New record
                HTTPPostRequest client = new HTTPPostRequest(ObjectsURL + "" + objectName + "/", sObject.GetJSon());
                return client.Execute();
            }
            else
            {
                //Update existing record
                string Id = sObject.Id;
                sObject.Id = null;
                HTTPPatchRequest client = new HTTPPatchRequest(ObjectsURL + "" + objectName + "/" + Id + "/", sObject.GetJSon());
                return client.Execute();
            }
        }
        public NetResponse GetContact(string id)
        {
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + "Contact/" + id);
            NetResponse NR = client.Execute();
            return NR;
        }
        public NetResponse GetContactByEmail(string email)
        {
            string query = "?q=" + QueryStrings.Contacts_Select + "+Where+Email='" + email + "'+And+InActive__c=false";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            NetResponse NR = client.Execute();
            return NR;
        }
        public NetResponse GetContactDescribe()
        {
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + "Contact/describe");
            return client.Execute();
        }
        public NetResponse ValidateContact(string email, string password)
        {
            string query = "?q=SELECT+Id,Name+from+Contact+WHERE+Email='" + email + "'+AND+Password__c='" + password + "'+LIMIT 1";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        public NetResponse GetContactRoles(string contactid)
        {
            string query = "?q=" + QueryStrings.ContactRoles_Select + "+WHERE+Contact__c='" + contactid + "'";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        public NetResponse GetContacts()
        {
            string query = @"?q=" + QueryStrings.Contacts_Select;
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        #endregion

        #region Case
        public NetResponse SaveCase(Case sObject)
        {
            string objectName = "Case";
            if (string.IsNullOrEmpty(sObject.Id))
            {
                //New record
                HTTPPostRequest client = new HTTPPostRequest(ObjectsURL + "" + objectName + "/", sObject.GetJSon());
                return client.Execute();
            }
            else
            {
                //Update existing record
                string Id = sObject.Id;
                sObject.Id = null;
                HTTPPatchRequest client = new HTTPPatchRequest(ObjectsURL + "" + objectName + "/" + Id + "/", sObject.GetJSon());
                return client.Execute();
            }
        }
        public NetResponse GetCase(string Id)
        {
            string query = "Case/" + Id;
            HTTPGetRequest client = new HTTPGetRequest(ObjectsURL + query);
            return client.Execute();
        }
        public NetResponse GetCasesByAccount(string acctId)
        {
            string query = "?q=" + QueryStrings.Cases_Select + "+WHERE+AccountId='" + acctId + "'";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        public NetResponse GetCasesByContact(string contactId)
        {
            string query = "?q=" + QueryStrings.Cases_Select + "+WHERE+Universal_Contact__c='" + contactId + "'";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        public NetResponse GetCases()
        {
            string query = @"?q=" + QueryStrings.Cases_Select;
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        #endregion

        #region User
        public NetResponse GetUser(string username)
        {
            string query = @"?q=" + QueryStrings.Users_Select + "+WHERE+Username+LIKE+'%" + username + "%'";
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        public NetResponse GetUsers()
        {
            string query = @"?q=" + QueryStrings.Users_Select;
            HTTPGetRequest client = new HTTPGetRequest(QueryURL + query);
            return client.Execute();
        }
        #endregion

    }
}
