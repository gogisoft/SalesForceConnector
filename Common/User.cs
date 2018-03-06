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
    public class User : sObject<User>
    {
        #region Standard Properties
        [DataMember(EmitDefaultValue = false)]
        public string Username { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string UserType { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string UserRoleId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesTaskRemindersCheckboxDefault { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowWorkPhoneToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowTitleToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowTitleToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowStreetAddressToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowStateToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowStateToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowProfilePicToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowPostalCodeToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowMobilePhoneToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowManagerToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowFaxToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowEmailToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowCountryToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowCountryToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string UserPreferencesShowCityToGuestUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesShowCityToExternalUsers { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesReminderSoundOff { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesPathAssistantCollapsed { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string UserPreferencesLightningExperiencePreferred { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesHideSecondChatterOnboardingSplash { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesHideS1BrowserUI { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesHideChatterOnboardingSplash { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesHideCSNGetChatterMobileTask { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesHideCSNDesktopTask { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesEventRemindersCheckboxDefault { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesDisableAllFeedsEmail { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesContentNoEmail { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesContentEmailAsAndWhen { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesApexPagesDeveloperMode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPreferencesActivityRemindersPopup { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsSupportUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsSFContentUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsOfflineUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsMobileUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsMarketingUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsKnowledgeUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsInteractionUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsChatterAnswersUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsCallCenterAutoLogin { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? UserPermissionsAvantgoUser { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string TimeZoneSidKey { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Suffix { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Street { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string StayInTouchSubject { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string StayInTouchSignature { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string StayInTouchNote { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string State { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string SmallPhotoUrl { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Signature { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string SenderName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string SenderEmail { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public float? Sales_Goal__c { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? ReceivesInfoEmails { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? ReceivesAdminInfoEmails { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ProfileId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string PostalCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string PortalRole { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Phone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string OfflineTrialExpirationDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string OfflinePdaTrialExpirationDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string MobilePhone { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string MiddleName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ManagerId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double? Longitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LocaleSidKey { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double? Latitude { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastViewedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastReferencedDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastPasswordChangeDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LastLoginDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string LanguageLocaleKey { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? IsPortalSelfRegistered { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? IsPortalEnabled { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? IsActive { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string FullPhotoUrl { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? ForecastEnabled { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string FederationIdentifier { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Fax { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Extension { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string EmployeeNumber { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? EmailPreferencesStayInTouchReminder { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? EmailPreferencesAutoBccStayInTouch { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool? EmailPreferencesAutoBcc { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string EmailEncodingKey { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Division { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string DigestFrequency { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Department { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string DelegatedApproverId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string DefaultGroupNotificationFrequency { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Country { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ContactId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CompanyName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CommunityNickname { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string City { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CallCenterId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string BadgeText { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Alias { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string AccountId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string AboutMe { get; set; }
        #endregion

        public User()
            : base() { }


        public User(string json)
            : base(json)
        {

        }
    }
}
