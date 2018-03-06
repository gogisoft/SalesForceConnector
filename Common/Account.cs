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
    [DataContract]
    public class Account : sObject<Account>
    {
        [DataMember(EmitDefaultValue = false)]
        public bool IsDeleted { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object MasterRecordId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Type { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string RecordTypeId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object ParentId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingAddress { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingStreet { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingCity { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingState { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingPostalCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingCountry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingLongitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingLatitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BillingGeocodeAccuracy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingAddress { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingStreet { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingCity { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingState { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingPostalCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingCountry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingLongitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingLatitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ShippingGeocodeAccuracy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Phone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Fax { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Website { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Industry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object AnnualRevenue { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object NumberOfEmployees { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Ownership { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object TickerSymbol { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string OwnerId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CreatedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CreatedById { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastModifiedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastModifiedById { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string SystemModstamp { get; set; }

        public Account()
            : base() { }

        public Account(string json)
            : base(json)
        {

        }
    }
}
