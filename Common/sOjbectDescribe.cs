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
    /// Class represent data field structure of sObjects.
    /// This will also include picklist items and some mapping value.
    /// </summary>
    [DataContract]
    public class sOjbectDescribe
    {
        [DataMember]
        public bool activateable { get; set; }
        [DataMember]
        public ChildRelationShip[] childRelationships { get; set; }
        [DataMember]
        public Field[] fields { get; set; }

        public string keyPrefix { get; set; }
        public string label { get; set; }
        public string labelPlural { get; set; }
        public bool layoutable { get; set; }
        public object listviewable { get; set; }
        public object lookupLayoutable { get; set; }
        public bool mergeable { get; set; }
        public string name { get; set; }
        public bool queryable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public RecordTypeInfos[] recordTypeInfos { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public URLs urls { get; set; }

        public sOjbectDescribe(string json)
        {
            HydrateFromJSon(json);
        }
        private void HydrateFromJSon(string json)
        {
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            var details = ser.ReadObject(ms);
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                property.SetValue(this, property.GetValue(details, null), null);
            }
        }
    }

    [DataContract]
    public class Field
    {
        [DataMember(EmitDefaultValue = false)]
        public bool autoNumber { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int byteLength { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool calculated { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object calculatedFormula { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool caseSensitive { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object controllerName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool createable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool custom { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object defaultValue { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object defaultValueFormula { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool defaultedOnCreate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool dependentPicklist { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool deprecatedAndHidden { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int digits { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool externalId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool filterable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool groupable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool htmlFormatted { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool idLookup { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string inlineHelpText { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int length { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool nameField { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool namePointing { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool nillable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public PickListValues[] picklistValues { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int precision { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object[] referenceTo { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object relationshipName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object relationshipOrder { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool restrictedPicklist { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int scale { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string soapType { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool sortable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool unique { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool updateable { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool writeRequiresMasterRead { get; set; }
    }

    [DataContract]
    public class ChildRelationShip
    {
        [DataMember(EmitDefaultValue = false)]
        public bool cascadeDelete { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string childSObject { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool deprecatedAndHidden { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string field { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string relationshipName { get; set; }
    }

    [DataContract]
    public class PickListValues
    {
        [DataMember(EmitDefaultValue = false)]
        public bool active { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool defaultValue { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object validFor { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string value { get; set; }

    }
    [DataContract]
    public class RecordTypeInfos
    {
        [DataMember(EmitDefaultValue = false)]
        public bool available { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool defaultRecordTypeMapping { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string recordTypeId { get; set; }
    }
    [DataContract]
    public class ReferenceTo
    {

    }
    [DataContract]
    public class URLs
    {
        [DataMember(EmitDefaultValue = false)]
        public string rowTemplate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string uiDetailTemplate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string uiEditTemplate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string describe { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string uiNewRecord { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string sobject { get; set; }
    }
}
