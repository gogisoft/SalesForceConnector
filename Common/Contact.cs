using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    /// <summary>
    /// Class represents SalesForce Contact object
    /// </summary>
    [DataContract]
    public class Contact : sObject<Contact>
    {

        #region Standard Properties
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String LeadSource { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MailingCity { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MailingPostalCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MailingState { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MailingStreet { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object AcceptedEventRelations { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public string Account { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object AccountContactRoles { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object ActivityHistories { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object Assets { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public String AssistantName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String AssistantPhone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Attachments { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public string Birthdate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object CampaignMembers { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object CaseContactRoles { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object Cases { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object CombinedAttachments { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object ContractContactRoles { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object ContractsSigned { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object CreatedBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object CreatedById { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public readonly string CreatedDate = DateTime.UtcNow.ToString("o");
        [DataMember(EmitDefaultValue = false)]
        public object DeclinedEventRelations { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Department { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Email { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string EmailBouncedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String EmailBouncedReason { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object EmailStatuses { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object EventRelations { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object Events { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public String Fax { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Boolean HasOptedOutOfEmail { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Histories { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String HomePhone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Boolean InActive__c { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Boolean Invoices_Orders__c { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Boolean IsDeleted { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Boolean IsEmailBounced { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Jigsaw { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String JigsawContactId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastActivityDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastCURequestDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastCUUpdateDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastViewedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object MailingAddress { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MailingCountry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Double MailingLatitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Double MailingLongitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object MasterRecord { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object MasterRecordId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String MobilePhone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Notes { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object NotesAndAttachments { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object OpenActivities { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Opportunities { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object OpportunityContactRoles { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object OtherAddress { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherCity { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherCountry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Double OtherLatitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Double OtherLongitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherPhone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherPostalCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherState { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String OtherStreet { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Owner { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object OwnerId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Phone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String PhotoUrl { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Product_Orders__r { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public String Profile_Number__c { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Quotes { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public object RecordType { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object RecordTypeId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object ReportsTo { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object ReportsToId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Salutation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String Title { get; set; }
        #endregion

        public Contact()
            : base() { }
        public Contact(string json)
            : base(json)
        {

        }

    }
}
