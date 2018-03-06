using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// This class holds common select statements for standard objects.
    /// </summary>
    public class QueryStrings
    {
        #region Account
        /// <summary>
        /// Select all from Account
        /// </summary>
        public const string Accounts_Select = @"SELECT+Id, Name,AccountNumber,Type,
ShippingStreet,ShippingState,ShippingPostalCode,ShippingCountry,ShippingCity,
BillingStreet,BillingState,BillingPostalCode,BillingCountry,BillingCity+From+Account";
        #endregion

        #region Contact
        /// <summary>
        /// Select all from Contact
        /// </summary>
        public const string Contacts_Select = @"SELECT+Id,Title, Salutation, ReportsToId, RecordTypeId, 
Phone,  OwnerId,   OtherStreet, OtherState, OtherPostalCode, OtherPhone,
OtherCountry, OtherCity, Name, MobilePhone, MasterRecordId, MailingStreet, MailingState, MailingPostalCode, 
MailingCountry, MailingCity,  LeadSource, LastName, LastCUUpdateDate, LastCURequestDate,
IsDeleted, HomePhone, HasOptedOutOfEmail, FirstName, Fax, EmailBouncedReason,EmailBouncedDate, Email, Description, Department, 
CreatedDate, CreatedById, Birthdate, AssistantPhone, AssistantName,AccountId+FROM+Contact";
        /// <summary>
        /// Select all from ContactRole__c
        /// </summary>
        public const string ContactRoles_Select = @"SELECT+Id,Name+From+ContactRole__c";
        #endregion

        #region Case
        /// <summary>
        /// Select all from Case
        /// </summary>
        public const string Cases_Select = @"SELECT+Id,Type,SuppliedPhone,SuppliedName,SuppliedEmail,SuppliedCompany,Subject,Status,Reason,Priority,ParentId,OwnerId,Origin,
                On_Hold_Reason__c,IsEscalated,IsDeleted,IsClosed,HasSelfServiceComments,HasCommentsUnreadByOwner,Description,ContactId,ClosedDate,
                AccountId+FROM+Case";
        #endregion

        #region User
        /// <summary>
        /// Select all from User
        /// *Has active flag (IsActive)
        /// </summary>
        public const string Users_Select = @"Select+Id,AboutMe,IsActive,ReceivesAdminInfoEmails,ForecastEnabled,
MobilePhone,DigestFrequency,CompanyName,Department,
Division,Email,EmailEncodingKey,EmployeeNumber,Extension,Fax,
ReceivesInfoEmails,LanguageLocaleKey,LocaleSidKey,Name,CommunityNickname,Phone,
PortalRole,FederationIdentifier,IsPortalSelfRegistered,
TimeZoneSidKey,Title,Username+From+User";
        #endregion

    }
}
