using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceConnector.Interface
{
    /// <summary>
    /// Abstraction responsible for defining REST calls to SalesForce. 
    /// All methods defined in this interface MUST return the type NetResponse!
    /// </summary>
    public interface ISubject
    {
        #region Public Methods
        void LoadGlobals();
        /// <summary>
        /// Weak type method to Upsert specified object with dynamically created parameters.
        /// </summary>
        /// <param name="upsertObject"></param>
        /// <param name="objectName"></param>
        /// <returns></returns>
        NetResponse SaveObject(DynamicUpsert upsertObject, string objectName);
        #endregion

        #region Account
        NetResponse SaveAccount(Account sObject);
        NetResponse GetAccounts();
        NetResponse GetAccount(string id);
        NetResponse GetAccountByName(string name);
        #endregion

        #region Contact
        NetResponse SaveContact(Contact sObject);
        NetResponse GetContact(string id);
        NetResponse GetContactByEmail(string email);
        NetResponse GetContactDescribe();
        NetResponse ValidateContact(string email, string password);
        NetResponse SaveContactRole(ContactRole sObject);
        NetResponse GetContactRoles(string contactid);
        NetResponse GetContacts();
        #endregion

        #region Case
        NetResponse SaveCase(Case sObject);
        NetResponse GetCase(string Id);
        NetResponse GetCasesByAccount(string acctId);
        NetResponse GetCasesByContact(string contactId);
        NetResponse GetCases();
        #endregion

        #region User
        NetResponse GetUser(string username);
        NetResponse GetUsers();
        #endregion

    }
}
