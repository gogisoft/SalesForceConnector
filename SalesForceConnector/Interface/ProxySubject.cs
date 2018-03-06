using Common;
using SalesForceConnector.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesForceConnector.Interface
{
    /// <summary>
    /// Static implementation of ISubject
    /// This implementation is responsible for storing as much imformation as possible to reduce the number of live REST calls.
    /// All methods MUST return NetResponse!
    /// </summary>
    public class ProxySubject : ISubject
    {
        public string ObjectsURL { get; set; }
        public string QueryURL { get; set; }
        public string RESTDomainURL { get; set; }
        private List<Account> _Accounts = new List<Account>();
        public ProxySubject()
        {
        }

        #region Public Methods
        public void LoadGlobals()
        {
            if (_Accounts.Count == 0)
            {
                GetAllAccounts();
            }
        }
        public NetResponse SaveObject(DynamicUpsert upsertObject, string objectName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Helper Methods
        private void GetAllAccounts()
        {
            (new Thread(() =>
            {

                HTTPGetRequest client = new HTTPGetRequest(QueryURL + @"?q=" + QueryStrings.Accounts_Select + "+WHERE+InActive__c=false");
                NetResponse NR = client.Execute();
                if (NR.HasError == false)
                {
                    QueryResult<Account> qResult = new QueryResult<Account>();
                    qResult.HydrateFromJSon(NR.JSON);
                    List<Account> accounts = new List<Account>();
                    accounts.AddRange(qResult.records);
                    while (qResult.done == false)
                    {
                        client = new HTTPGetRequest(RESTDomainURL + qResult.nextRecordsUrl);
                        NR = client.Execute();
                        qResult = new QueryResult<Account>();
                        qResult.HydrateFromJSon(NR.JSON);
                        accounts.AddRange(qResult.records);
                    }
                    qResult.records.Clear();
                    qResult.records.AddRange(accounts);
                    _Accounts.AddRange(qResult.records.OrderBy(p => p.Name).ToList());
                }
            })).Start();
        }
        public void RefreshAccounts()
        {
            _Accounts.Clear();
            GetAllAccounts();
        }
        public void AddAccount(Account a)
        {
            _Accounts.Add(a);
        }
        #endregion

        #region Account
        public NetResponse SaveAccount(Account a)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetAccounts()
        {
            if (_Accounts.Count > 0)
            {
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Account>));
                ser.WriteObject(ms, _Accounts);
                string json = Encoding.UTF8.GetString(ms.ToArray());
                return new NetResponse() { JSON = json };
            }
            else
                return new NetResponse() { HasError = true, ErrorMessage = "No accounts found." };
        }
        public NetResponse GetAccount(string id)
        {
            Account result = _Accounts.Where(p => p.Id == id).FirstOrDefault();
            if (result != null)
            {
                return new NetResponse() { JSON = result.GetJSon() };
            }
            return new NetResponse() { HasError = true, ErrorMessage = "Account not found" };
        }
        public NetResponse GetAccountByName(string name)
        {
            Account result = _Accounts.Where(p => p.Name == name).FirstOrDefault();
            if (result != null)
            {
                return new NetResponse() { JSON = result.GetJSon() };
            }
            return new NetResponse() { HasError = true, ErrorMessage = "Account not found" };
        }
        #endregion

        #region Contact
        public NetResponse SaveContact(Contact c)
        {
            throw new NotImplementedException();
        }
        public NetResponse SaveContactRole(ContactRole role)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContact(string id)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContactByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContactDescribe()
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContactUniSec(Contact c)
        {
            throw new NotImplementedException();
        }
        public NetResponse ValidateContact(string email, string password)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContactRoles(string contactid)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetContacts()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Case
        public NetResponse SaveCase(Case c)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetCase(string Id)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetCasesByAccount(string acctId)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetCasesByContact(string contactId)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetCases()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User
        public NetResponse GetUser(string username)
        {
            throw new NotImplementedException();
        }
        public NetResponse GetUsers()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
