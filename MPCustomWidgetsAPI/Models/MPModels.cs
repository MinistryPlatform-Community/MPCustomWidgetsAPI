using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MicroServices.Attributes;
using Newtonsoft.Json;

namespace Microservices.Models
{
    [MPTable("Account_Types")]
    public class AccountTypeModel
    {
        [Required]
        [Key]
        public int Account_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Account_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Accounting_Companies")]
    public class AccountingCompanyModel
    {
        [Required]
        [Key]
        public int Accounting_Company_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Company_Name { get; set; }
        public int? Company_Contact_ID { get; set; }
        public int? Default_Congregation { get; set; }
        [Required]
        public bool Show_Online { get; set; }
        public int? Online_Sort_Order { get; set; }
        public int? Pledge_Campaign_ID { get; set; }
        public int? Alternate_Pledge_Campaign { get; set; }
        [Required]
        public bool List_Non_Cash_Gifts { get; set; }
        [MaxLength(500)]
        public string? Statement_Footer { get; set; }
        public string? Statement_Letter { get; set; }
        public DateTime? Statement_Cutoff_Date { get; set; }
        public int? Statement_Cutoff_Automation_ID { get; set; }
        public int? Standard_Statement { get; set; }
        [Required]
        public bool Formal_Salutation { get; set; }
        [Required]
        public int Archive_Day_of_Year { get; set; }
        [Required]
        public int Rows_Per_Page { get; set; }
        [Required]
        public int Summary_Columns { get; set; }
        [MaxLength(10)]
        public string? Immediate_Destination_ID { get; set; }
        [MaxLength(10)]
        public string? Immediate_Origin_ID { get; set; }
        [MaxLength(23)]
        public string? Immediate_Destination_Name { get; set; }
        [MaxLength(23)]
        public string? Immediate_Origin_Name { get; set; }
        [MaxLength(9)]
        public string? Immediate_Routing_Number { get; set; }
        [MaxLength(9)]
        public string? Receiving_DFI_ID { get; set; }
        [Required]
        public bool Current_Settings { get; set; }
    }
    [MPTable("Activity_Log")]
    public class ActivityLogModel
    {
        [Required]
        [Key]
        public int Activity_Log_ID { get; set; }
        [Required]
        public DateTime Activity_Date { get; set; }
        [Required]
        [MaxLength(75)]
        public string Activity_Type { get; set; }
        [Required]
        [MaxLength(75)]
        public string Record_Name { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        public int? Household_ID { get; set; }
        [Required]
        public int Page_ID { get; set; }
        [Required]
        public int Record_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Table_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Page_Name { get; set; }
        public int? Congregation_ID { get; set; }
        public int? Ministry_ID { get; set; }
    }
    [MPTable("Activity_Log_Staging")]
    public class ActivityLogStagingModel
    {
        [Required]
        [Key]
        public int Activity_Log_Staging_ID { get; set; }
        [Required]
        public int Page_ID { get; set; }
        [Required]
        public int Last_PK { get; set; }
        [Required]
        public DateTime Last_Date { get; set; }
    }
    [MPTable("Addresses")]
    public class AddressModel
    {
        [Required]
        [Key]
        public int Address_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Address_Line_1 { get; set; }
        [MaxLength(75)]
        public string? Address_Line_2 { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        [JsonProperty(PropertyName = "State/Region")]
        public string? State_Region { get; set; }
        [MaxLength(15)]
        public string? Postal_Code { get; set; }
        [MaxLength(255)]
        public string? Foreign_Country { get; set; }
        [MaxLength(25)]
        public string? Country_Code { get; set; }
        [MaxLength(10)]
        public string? Carrier_Route { get; set; }
        [MaxLength(10)]
        public string? Lot_Number { get; set; }
        [MaxLength(3)]
        public string? Delivery_Point_Code { get; set; }
        public string? Delivery_Point_Check_Digit { get; set; }
        [MaxLength(15)]
        public string? Latitude { get; set; }
        [MaxLength(15)]
        public string? Longitude { get; set; }
        [MaxLength(15)]
        public string? Altitude { get; set; }
        [MaxLength(50)]
        public string? Time_Zone { get; set; }
        [MaxLength(50)]
        public string? Bar_Code { get; set; }
        [MaxLength(50)]
        public string? Area_Code { get; set; }
        public DateTime? Last_Validation_Attempt { get; set; }
        [MaxLength(50)]
        public string? County { get; set; }
        public bool? Validated { get; set; }
        [Required]
        public bool Do_Not_Validate { get; set; }
        public DateTime? Last_GeoCode_Attempt { get; set; }
        [MaxLength(100)]
        public string? Country { get; set; }
    }
    [MPTable("Attribute_Types")]
    public class AttributeTypeModel
    {
        [Required]
        [Key]
        public int Attribute_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Attribute_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public bool Available_Online { get; set; }
        public int? Online_Sort_Order { get; set; }
    }
    [MPTable("Attributes")]
    public class AttributeModel
    {
        [Required]
        [Key]
        public int Attribute_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Attribute_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Attribute_Type_ID { get; set; }
        [MaxLength(50)]
        public string? Icon { get; set; }
    }
    [MPTable("Audience_Audience_Filters")]
    public class AudienceAudienceFilterModel
    {
        [Required]
        [Key]
        public int Audience_Audience_Filter_ID { get; set; }
        [Required]
        public int Audience_ID { get; set; }
        [Required]
        public int Filter_ID { get; set; }
        [Required]
        public int Operator_ID { get; set; }
        [MaxLength(64)]
        public string? Filter_Parameter { get; set; }
    }
    [MPTable("Audience_Filters")]
    public class AudienceFilterModel
    {
        [Required]
        [Key]
        public int Filter_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Filter_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Criteria { get; set; }
        [Required]
        [MaxLength(256)]
        public string Contact_ID_Field { get; set; }
        [Required]
        public string Table_Name { get; set; }
    }
    [MPTable("Audience_Members")]
    public class AudienceMemberModel
    {
        [Required]
        [Key]
        public int Audience_Member_ID { get; set; }
        [Required]
        public int Audience_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public bool Forced_Filter { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime Last_Update_Date { get; set; }
    }
    [MPTable("Audience_Members_Staging")]
    public class AudienceMembersStagingModel
    {
        [Required]
        [Key]
        public int Contact_Id { get; set; }
        [Required]
        public bool Forced_Filter { get; set; }
    }
    [MPTable("Audience_Operators")]
    public class AudienceOperatorModel
    {
        [Required]
        [Key]
        public int Operator_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Operator { get; set; }
    }
    [MPTable("Audiences")]
    public class AudienceModel
    {
        [Required]
        [Key]
        public int Audience_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Audience_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Processing_Order { get; set; }
        [Required]
        public bool Active { get; set; }
        public DateTime? Last_Update_Date { get; set; }
        [MaxLength(256)]
        public string? Last_Update_Status { get; set; }
        public DateTime? Next_Update_Date { get; set; }
    }
    [MPTable("Background_Check_Statuses")]
    public class BackgroundCheckStatusModel
    {
        [Required]
        [Key]
        public int Background_Check_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Background_Check_Status { get; set; }
    }
    [MPTable("Background_Check_Types")]
    public class BackgroundCheckTypeModel
    {
        [Required]
        [Key]
        public int Background_Check_Type_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Background_Check_Type { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Service_Code { get; set; }
        [MaxLength(50)]
        public string? Package_Service_Code { get; set; }
        [Required]
        public bool Collect_DL { get; set; }
        [MaxLength(50)]
        public string? Service_Code_Delayed { get; set; }
        [Required]
        public bool Collect_State { get; set; }
        [Required]
        public bool Collect_Jurisdiction { get; set; }
        [Required]
        public bool Collect_Ethnicity { get; set; }
        [Required]
        public bool Default_Package { get; set; }
        [Required]
        public bool Detect_County { get; set; }
        [Required]
        public bool Drug_Test { get; set; }
        [Required]
        public bool Is_Background_Check { get; set; }
        [Required]
        public bool Credit_Check { get; set; }
        public int? Months_Till_Expires { get; set; }
        public int? Expiring_Soon_Days { get; set; }
        [Required]
        public bool Type_Needs_Review { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }
    [MPTable("Background_Checks")]
    public class BackgroundCheckModel
    {
        [Required]
        [Key]
        public int Background_Check_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        public int? Requesting_Ministry { get; set; }
        public DateTime? Background_Check_Submitted { get; set; }
        public DateTime? Background_Check_Returned { get; set; }
        public bool? All_Clear { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        public bool? Theft { get; set; }
        public bool? Drugs { get; set; }
        public bool? Sexual { get; set; }
        public bool? DUI { get; set; }
        public bool? Battery { get; set; }
        public bool? Traffic { get; set; }
        public bool? Other { get; set; }
        [Required]
        public DateTime Background_Check_Started { get; set; }
        [MaxLength(50)]
        public string? Reference_Number { get; set; }
        public string? Report_Url { get; set; }
        public int? Background_Check_Type_ID { get; set; }
        [Required]
        public string Background_Check_GUID { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Middle_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        [MaxLength(50)]
        public string? Maiden_Name { get; set; }
        public DateTime? Date_Of_Birth { get; set; }
        [MaxLength(50)]
        public string? Gender { get; set; }
        [MaxLength(50)]
        public string? Race { get; set; }
        [MaxLength(128)]
        public string? Address_Line_1 { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? State { get; set; }
        [MaxLength(50)]
        public string? Postal_Code { get; set; }
        [MaxLength(128)]
        public string? Digital_Signature { get; set; }
        [MaxLength(50)]
        public string? DL_Number { get; set; }
        [MaxLength(128)]
        public string? Jurisdiction { get; set; }
        [MaxLength(50)]
        public string? DL_State { get; set; }
        public DateTime? Background_Check_Expires { get; set; }
        public int? Background_Check_Status_ID { get; set; }
        public DateTime? Status_Date { get; set; }
        [MaxLength(16)]
        public string? IP_Address { get; set; }
    }
    [MPTable("Banks")]
    public class BankModel
    {
        [Required]
        [Key]
        public int Bank_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Bank_Name { get; set; }
        public int? Accounting_Company_ID { get; set; }
        public int? Address_ID { get; set; }
        [MaxLength(25)]
        public string? Account_Number { get; set; }
        [MaxLength(25)]
        public string? Accounting_Company { get; set; }
    }
    [MPTable("Batch_Entry_Types")]
    public class BatchEntryTypeModel
    {
        [Required]
        [Key]
        public int Batch_Entry_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Batch_Entry_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Batch_Types")]
    public class BatchTypeModel
    {
        [Required]
        [Key]
        public int Batch_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Batch_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Batches")]
    public class BatcheModel
    {
        [Required]
        [Key]
        public int Batch_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Batch_Name { get; set; }
        [Required]
        public DateTime Setup_Date { get; set; }
        [Required]
        public decimal Batch_Total { get; set; }
        [Required]
        public int Item_Count { get; set; }
        [Required]
        public int Batch_Entry_Type_ID { get; set; }
        public int? Batch_Type_ID { get; set; }
        public int? Default_Program { get; set; }
        public int? Source_Event { get; set; }
        public int? Deposit_ID { get; set; }
        public DateTime? Finalize_Date { get; set; }
        public int? Congregation_ID { get; set; }
        public int? _Import_Counter { get; set; }
        [MaxLength(50)]
        public string? _Source_File { get; set; }
        public int? Default_Payment_Type { get; set; }
        [MaxLength(25)]
        public string? Currency { get; set; }
        public int? Operator_User { get; set; }
        [MaxLength(64)]
        public string? Default_Program_ID_List { get; set; }
    }
    [MPTable("Books")]
    public class BookModel
    {
        [Required]
        [Key]
        public int Book_ID { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(15)]
        public string? ISBN { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? Start_Date { get; set; }
    }
    [MPTable("Buildings")]
    public class BuildingModel
    {
        [Required]
        [Key]
        public int Building_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Building_Name { get; set; }
        [Required]
        public int Location_ID { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public DateTime? Next_Inspection_Date { get; set; }
        public int? Building_Coordinator { get; set; }
        public DateTime? Date_Acquired { get; set; }
        public DateTime? Date_Constructed { get; set; }
        public DateTime? Date_Retired { get; set; }
    }
    [MPTable("Campaign_Goals")]
    public class CampaignGoalModel
    {
        [Required]
        [Key]
        public int Campaign_Goal_ID { get; set; }
        [Required]
        public int Campaign_ID { get; set; }
        [Required]
        public int Congregation_ID { get; set; }
        [Required]
        public decimal Goal_Amount { get; set; }
    }
    [MPTable("Care_Case_Types")]
    public class CareCaseTypeModel
    {
        [Required]
        [Key]
        public int Care_Case_Type_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Care_Case_Type { get; set; }
        [MaxLength(512)]
        public string? Description { get; set; }
    }
    [MPTable("Care_Cases")]
    public class CareCasModel
    {
        [Required]
        [Key]
        public int Care_Case_ID { get; set; }
        [MaxLength(128)]
        public string? Title { get; set; }
        [MaxLength(512)]
        public string? Description { get; set; }
        [Required]
        public int Household_ID { get; set; }
        public int? Contact_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public int Care_Case_Type_ID { get; set; }
        public int? Location_ID { get; set; }
        public int? Case_Manager { get; set; }
        [Required]
        public bool Share_With_Group_Leaders { get; set; }
        public int? Program_ID { get; set; }
    }
    [MPTable("Care_Outcomes")]
    public class CareOutcomeModel
    {
        [Required]
        [Key]
        public int Care_Outcome_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Care_Outcome { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Care_Types")]
    public class CareTypeModel
    {
        [Required]
        [Key]
        public int Care_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Care_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? User_ID { get; set; }
    }
    [MPTable("Certification_Types")]
    public class CertificationTypeModel
    {
        [Required]
        [Key]
        public int Certification_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Certification_Type { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
        [Required]
        public int Months_Till_Expires { get; set; }
        public int? Expiring_Soon_Days { get; set; }
        [MaxLength(75)]
        public string? Vendor_ID { get; set; }
    }
    [MPTable("Chart_Colors")]
    public class ChartColorModel
    {
        [Required]
        [Key]
        public int Chart_Color_ID { get; set; }
        [Required]
        public string Chart_Color { get; set; }
    }
    [MPTable("Checkin_Search_Results_Types")]
    public class CheckinSearchResultsTypeModel
    {
        [Required]
        [Key]
        public int Checkin_Search_Results_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Search_Result_Type { get; set; }
    }
    [MPTable("Church_Associations")]
    public class ChurchAssociationModel
    {
        [Required]
        [Key]
        public int Church_Association_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Association_Name { get; set; }
        [MaxLength(128)]
        public string? Alt_Name { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public int? Address_ID { get; set; }
        public string? Website { get; set; }
        public int? Year_Established { get; set; }
        public DateTime? End_Date { get; set; }
        public DateTime? Review_Date { get; set; }
    }
    [MPTable("Congregations")]
    public class CongregationModel
    {
        [Required]
        [Key]
        public int Congregation_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Congregation_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public int Accounting_Company_ID { get; set; }
        [Required]
        public bool Available_Online { get; set; }
        public int? Location_ID { get; set; }
        [Required]
        public string Time_Zone { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Pastor { get; set; }
        public int? Online_Sort_Order { get; set; }
        public string? Front_Desk_SMS_Phone { get; set; }
        public int? Plan_A_Visit_Template { get; set; }
        public int? Plan_A_Visit_User { get; set; }
        [MaxLength(500)]
        public string? Giving_URL { get; set; }
        [MaxLength(500)]
        public string? Logo_URL { get; set; }
        [Required]
        public bool Coming_Soon { get; set; }
        [MaxLength(500)]
        public string? Giving_Image_URL { get; set; }
        public string? JWT_Signing_Key { get; set; }
        [MaxLength(25)]
        public string? Certifications_Provider { get; set; }
        public string? Certifications_API_Key { get; set; }
        [MaxLength(100)]
        public string? Certifications_API_Address { get; set; }
        [MaxLength(50)]
        public string? Certification_Callback_Username { get; set; }
        public string? Certification_Callback_Password { get; set; }
        [MaxLength(25)]
        public string? Background_Check_Provider { get; set; }
        [MaxLength(50)]
        public string? Background_Check_Username { get; set; }
        public string? Background_Check_Password { get; set; }
        [MaxLength(50)]
        public string? Background_Check_Callback_Username { get; set; }
        public string? Background_Check_Callback_Password { get; set; }
        public string? Event_Registration_Handoff_URL { get; set; }
        [MaxLength(50)]
        public string? Vanco_Tenant { get; set; }
        [MaxLength(50)]
        public string? Vanco_Giving_PCCT { get; set; }
        [MaxLength(50)]
        public string? Vanco_Signing_Key { get; set; }
        [MaxLength(16)]
        public string? Organization_Code { get; set; }
        public int? Sacrament_Place_ID { get; set; }
    }
    [MPTable("Contact_Attributes")]
    public class ContactAttributeModel
    {
        [Required]
        [Key]
        public int Contact_Attribute_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Attribute_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
    }
    [MPTable("Contact_Households")]
    public class ContactHouseholdModel
    {
        [Required]
        [Key]
        public int Contact_Household_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Household_ID { get; set; }
        [Required]
        public int Household_Position_ID { get; set; }
        public int? Household_Type_ID { get; set; }
        [Required]
        public bool Primary_Family { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
        public DateTime? End_Date { get; set; }
    }
    [MPTable("Contact_Identifier_Log")]
    public class ContactIdentifierLogModel
    {
        [Required]
        [Key]
        public int Contact_Identifier_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Source_System_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Source_Type_Name { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Identifier_Value { get; set; }
        [Required]
        public DateTime _Date_Inserted { get; set; }
    }
    [MPTable("Contact_Log")]
    public class ContactLogModel
    {
        [Required]
        [Key]
        public int Contact_Log_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public DateTime Contact_Date { get; set; }
        public int? Contact_Log_Type_ID { get; set; }
        [Required]
        public int Made_By { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Notes { get; set; }
        public int? Planned_Contact_ID { get; set; }
        public bool? Contact_Successful { get; set; }
        public int? Original_Contact_Log_Entry { get; set; }
        public int? Feedback_Entry_ID { get; set; }
    }
    [MPTable("Contact_Log_Types")]
    public class ContactLogTypeModel
    {
        [Required]
        [Key]
        public int Contact_Log_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Contact_Log_Type { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
    [MPTable("Contact_Relationships")]
    public class ContactRelationshipModel
    {
        [Required]
        [Key]
        public int Contact_Relationship_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Relationship_ID { get; set; }
        [Required]
        public int Related_Contact_ID { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [MaxLength(255)]
        public string? Notes { get; set; }
        public int? _Triggered_By { get; set; }
    }
    [MPTable("Contact_Staging")]
    public class ContactStagingModel
    {
        [Required]
        [Key]
        public int Contact_Staging_ID { get; set; }
        [Required]
        public bool Ignore { get; set; }
        public bool? Imported { get; set; }
        public bool? Finalized { get; set; }
        [Required]
        [MaxLength(75)]
        public string Display_Name { get; set; }
        public int? Existing_Contact_Record { get; set; }
        [MaxLength(50)]
        public string? External_ID { get; set; }
        public int? ExternalFamilyID { get; set; }
        [Required]
        public bool Company { get; set; }
        [MaxLength(50)]
        public string? Company_Name { get; set; }
        public int? Prefix_ID { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Middle_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        public int? Suffix_ID { get; set; }
        [MaxLength(50)]
        public string? Nickname { get; set; }
        public DateTime? Date_of_Birth { get; set; }
        public int? Gender_ID { get; set; }
        public int? Marital_Status_ID { get; set; }
        [Required]
        public int Contact_Status_ID { get; set; }
        public int? Existing_Household_Record { get; set; }
        public int? Household_Position_ID { get; set; }
        public int? Existing_Participant_Record { get; set; }
        public DateTime? Participant_Start_Date { get; set; }
        public int? Participant_Type_ID { get; set; }
        [MaxLength(1000)]
        public string? Participant_Notes { get; set; }
        public int? Existing_Donor_Record { get; set; }
        [MaxLength(254)]
        public string? Email_Address { get; set; }
        [Required]
        public bool Bulk_Email_Opt_Out { get; set; }
        public string? Mobile_Phone { get; set; }
        public string? Company_Phone { get; set; }
        public string? Pager_Phone { get; set; }
        public string? Fax_Phone { get; set; }
        public int? Existing_User_Account { get; set; }
        public string? Web_Page { get; set; }
        public DateTime? Anniversary_Date { get; set; }
        public int? HS_Graduation_Year { get; set; }
        public string? Home_Phone { get; set; }
        public int? Congregation_ID { get; set; }
        public int? Existing_Address_Record { get; set; }
        [MaxLength(75)]
        public string? Address_Line_1 { get; set; }
        [MaxLength(75)]
        public string? Address_Line_2 { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        [JsonProperty(PropertyName = "State/Region")]
        public string? State_Region { get; set; }
        [MaxLength(15)]
        public string? Postal_Code { get; set; }
        [MaxLength(50)]
        public string? Foreign_Country { get; set; }
        [MaxLength(50)]
        public string? ID_Card { get; set; }
        public DateTime? Date_of_Death { get; set; }
        public DateTime? _Contact_Setup_Date { get; set; }
    }
    [MPTable("Contact_Statuses")]
    public class ContactStatusModel
    {
        [Required]
        [Key]
        public int Contact_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Contact_Status { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Contacts")]
    public class ContactModel
    {
        [Required]
        [Key]
        public int Contact_ID { get; set; }
        [Required]
        public bool Company { get; set; }
        [MaxLength(50)]
        public string? Company_Name { get; set; }
        [Required]
        [MaxLength(125)]
        public string Display_Name { get; set; }
        public int? Prefix_ID { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Middle_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        public int? Suffix_ID { get; set; }
        [MaxLength(50)]
        public string? Nickname { get; set; }
        public DateTime? Date_of_Birth { get; set; }
        public int? Gender_ID { get; set; }
        public int? Marital_Status_ID { get; set; }
        [Required]
        public int Contact_Status_ID { get; set; }
        public int? Household_ID { get; set; }
        public int? Household_Position_ID { get; set; }
        public DateTime? Anniversary_Date { get; set; }
        public DateTime? Date_of_Death { get; set; }
        public int? Participant_Record { get; set; }
        public int? Donor_Record { get; set; }
        public string? Email_Address { get; set; }
        public string? Mobile_Phone { get; set; }
        public string? Company_Phone { get; set; }
        public string? Pager_Phone { get; set; }
        public string? Fax_Phone { get; set; }
        [MaxLength(50)]
        public string? Facebook_Account { get; set; }
        [MaxLength(50)]
        public string? Twitter_Account { get; set; }
        public string? Web_Page { get; set; }
        public int? Industry_ID { get; set; }
        public int? Occupation_ID { get; set; }
        [MaxLength(75)]
        public string? Current_School { get; set; }
        public int? HS_Graduation_Year { get; set; }
        [Required]
        public bool Bulk_Email_Opt_Out { get; set; }
        [Required]
        public bool Email_Unlisted { get; set; }
        [Required]
        public bool Do_Not_Text { get; set; }
        [Required]
        public bool Mobile_Phone_Unlisted { get; set; }
        [Required]
        public bool Remove_From_Directory { get; set; }
        public int? User_Account { get; set; }
        [MaxLength(50)]
        public string? ID_Card { get; set; }
        [Required]
        public string Contact_GUID { get; set; }
        [Required]
        public DateTime _Contact_Setup_Date { get; set; }
        [Required]
        public bool Email_Verified { get; set; }
        [Required]
        public bool Mobile_Phone_Verified { get; set; }
        [MaxLength(50)]
        public string? Maiden_Name { get; set; }
    }
    [MPTable("Continents")]
    public class ContinentModel
    {
        [Required]
        [Key]
        public int Continent_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Continent { get; set; }
    }
    [MPTable("Contribution_Statement_Donors")]
    public class ContributionStatementDonorModel
    {
        [Required]
        [Key]
        public int Statement_Donor_ID { get; set; }
        [Required]
        public int Statement_ID { get; set; }
        [Required]
        public int Donor_ID { get; set; }
    }
    [MPTable("Contribution_Statements")]
    public class ContributionStatementModel
    {
        [Required]
        [Key]
        public int Statement_ID { get; set; }
        [Required]
        public int Accounting_Company_ID { get; set; }
        [Required]
        public int Statement_Year { get; set; }
        [Required]
        public int Household_ID { get; set; }
        [Required]
        public int Statement_Type_ID { get; set; }
        public int? Contact_Record { get; set; }
        public int? Spouse_Record { get; set; }
        [MaxLength(254)]
        public string? Salutation { get; set; }
        [Required]
        public bool Archived { get; set; }
        public int? Archived_Campaign { get; set; }
        public int? Alternate_Archived_Campaign { get; set; }
        [Required]
        public DateTime Last_Change_By_Routine { get; set; }
        public DateTime? Last_Statement_File { get; set; }
    }
    [MPTable("Countries")]
    public class CountryModel
    {
        [Required]
        [Key]
        public int Country_ID { get; set; }
        [MaxLength(255)]
        public string? Country { get; set; }
        public int? Continent_ID { get; set; }
        [MaxLength(2)]
        public string? Country_Code { get; set; }
        [MaxLength(2)]
        public string? Code2 { get; set; }
        [MaxLength(3)]
        public string? Code3 { get; set; }
        [MaxLength(32)]
        public string? Calling_Code { get; set; }
    }
    [MPTable("Currencies")]
    public class CurrencyModel
    {
        [Required]
        [Key]
        public int Currency_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Currency_Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Currency_Abbrev { get; set; }
        [Required]
        public bool Allow_Online { get; set; }
    }
    [MPTable("Date_Accuracies")]
    public class DateAccuracyModel
    {
        [Required]
        [Key]
        public int Date_Accuracy_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Date_Accuracy { get; set; }
    }
    [MPTable("Deposits")]
    public class DepositModel
    {
        [Required]
        [Key]
        public int Deposit_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Deposit_Name { get; set; }
        [Required]
        public decimal Deposit_Total { get; set; }
        [Required]
        public DateTime Deposit_Date { get; set; }
        [Required]
        [MaxLength(30)]
        public string Account_Number { get; set; }
        [Required]
        public int Batch_Count { get; set; }
        [Required]
        public bool Exported { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        public int? Congregation_ID { get; set; }
    }
    [MPTable("Donation_Distributions")]
    public class DonationDistributionModel
    {
        [Required]
        [Key]
        public int Donation_Distribution_ID { get; set; }
        [Required]
        public int Donation_ID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Program_ID { get; set; }
        public int? Pledge_ID { get; set; }
        public int? Target_Event { get; set; }
        public int? Soft_Credit_Donor { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
        [MaxLength(254)]
        public string? Statement_Description { get; set; }
        public int? Donation_Source_ID { get; set; }
        [MaxLength(16)]
        public string? _Vendor_Pledge_Code { get; set; }
        public int? Projected_Gift_Frequency { get; set; }
    }
    [MPTable("Donation_Frequencies")]
    public class DonationFrequencyModel
    {
        [Required]
        [Key]
        public int Donation_Frequency_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Donation_Frequency { get; set; }
        [Required]
        public int Evaluation_Days { get; set; }
        [Required]
        public int Evaluation_Order { get; set; }
        [Required]
        public int Minimum_Donations { get; set; }
        [Required]
        public int Evaluation_Delay { get; set; }
    }
    [MPTable("Donation_Levels")]
    public class DonationLevelModel
    {
        [Required]
        [Key]
        public int Donation_Level_ID { get; set; }
        [MaxLength(50)]
        public string? Donation_Level { get; set; }
        [Required]
        public int Evaluation_Days { get; set; }
        [Required]
        public int Evaluation_Order { get; set; }
        [Required]
        public decimal Minimum_Donations { get; set; }
        [Required]
        public int Evaluation_Delay { get; set; }
    }
    [MPTable("Donation_Sources")]
    public class DonationSourceModel
    {
        [Required]
        [Key]
        public int Donation_Source_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Donation_Source { get; set; }
        [MaxLength(24)]
        public string? Code { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public int? Campaign_ID { get; set; }
        [Required]
        public bool Active { get; set; }
    }
    [MPTable("Donations")]
    public class DonationModel
    {
        [Required]
        [Key]
        public int Donation_ID { get; set; }
        [Required]
        public int Donor_ID { get; set; }
        [Required]
        public decimal Donation_Amount { get; set; }
        [Required]
        public DateTime Donation_Date { get; set; }
        [Required]
        public int Payment_Type_ID { get; set; }
        [MaxLength(15)]
        public string? Item_Number { get; set; }
        public int? Batch_ID { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        public int? Donor_Account_ID { get; set; }
        [Required]
        public bool Anonymous { get; set; }
        [MaxLength(50)]
        public string? Transaction_Code { get; set; }
        [MaxLength(50)]
        public string? Subscription_Code { get; set; }
        [MaxLength(500)]
        public string? Gateway_Response { get; set; }
        public bool? Processed { get; set; }
        [MaxLength(25)]
        public string? Currency { get; set; }
        [Required]
        public bool Receipted { get; set; }
        [MaxLength(25)]
        public string? Invoice_Number { get; set; }
        public int? Receipt_Number { get; set; }
        [MaxLength(100)]
        public string? Original_MICR { get; set; }
        public int? Position { get; set; }
        [MaxLength(1000)]
        public string? OCR_Data { get; set; }
        public string? Third_Party_Note { get; set; }
        public int? Statement_ID { get; set; }
        public DateTime? _Last_Statement_Review { get; set; }
    }
    [MPTable("Donor_Accounts")]
    public class DonorAccountModel
    {
        [Required]
        [Key]
        public int Donor_Account_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Institution_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Account_Number { get; set; }
        [MaxLength(50)]
        public string? Routing_Number { get; set; }
        [Required]
        public int Donor_ID { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Non-Assignable")]
        public bool Non_Assignable { get; set; }
        [Required]
        public int Account_Type_ID { get; set; }
        [Required]
        public bool Closed { get; set; }
        public int? Bank_ID { get; set; }
    }
    [MPTable("Donors")]
    public class DonorModel
    {
        [Required]
        [Key]
        public int Donor_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Statement_Frequency_ID { get; set; }
        [Required]
        public int Statement_Type_ID { get; set; }
        [Required]
        public int Statement_Method_ID { get; set; }
        public int? Envelope_No { get; set; }
        [Required]
        public bool Cancel_Envelopes { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        public int? Always_Soft_Credit { get; set; }
        public int? Always_Pledge_Credit { get; set; }
        [Required]
        public DateTime Setup_Date { get; set; }
        public bool? First_Contact_Made { get; set; }
        public DateTime? _First_Donation_Date { get; set; }
        public DateTime? _Last_Donation_Date { get; set; }
        public int? Donation_Frequency_ID { get; set; }
        public int? Donation_Level_ID { get; set; }
        [MaxLength(16)]
        public string? Donor_Code { get; set; }
    }
    [MPTable("dp_API_Clients")]
    public class dpAPIClientModel
    {
        [Required]
        [Key]
        public int API_Client_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Display_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Client_ID { get; set; }
        public string? Client_Secret { get; set; }
        public int? Client_User_ID { get; set; }
        [Required]
        public int Authentication_Flow_ID { get; set; }
        [MaxLength(4000)]
        public string? Redirect_URIs { get; set; }
        [MaxLength(4000)]
        public string? Post_Logout_Redirect_URIs { get; set; }
        [Required]
        public int Access_Token_Lifetime { get; set; }
        [Required]
        public int Identity_Token_Lifetime { get; set; }
        [Required]
        public int Refresh_Token_Lifetime { get; set; }
        [Required]
        public int Authorization_Code_Lifetime { get; set; }
        [Required]
        public bool Is_Enabled { get; set; }
        public string? Encryption_Key { get; set; }
    }
    [MPTable("dp_Application_Labels")]
    public class dpApplicationLabelModel
    {
        [Required]
        [Key]
        public int Application_Label_ID { get; set; }
        [Required]
        public int API_Client_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Label_Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string English { get; set; }
        [MaxLength(255)]
        public string? Spanish { get; set; }
        [MaxLength(255)]
        public string? Chinese { get; set; }
        [MaxLength(255)]
        public string? Portuguese { get; set; }
    }
    [MPTable("dp_Authentication_Log")]
    public class dpAuthenticationLogModel
    {
        [Required]
        [Key]
        public int Authentication_ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string User_Name { get; set; }
        [Required]
        [MaxLength(75)]
        public string Server_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string IP_Address { get; set; }
        [Required]
        public DateTime Date_Time { get; set; }
        public int? User_ID { get; set; }
        [MaxLength(2048)]
        public string? Referrer { get; set; }
        [Required]
        public bool Keep_Signed_In { get; set; }
    }
    [MPTable("dp_Bookmarks")]
    public class dpBookmarkModel
    {
        [Required]
        [Key]
        public int Bookmark_ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? URL { get; set; }
        [Required]
        public int ViewOrder { get; set; }
    }
    [MPTable("dp_Communication_Messages")]
    public class dpCommunicationMessageModel
    {
        [Required]
        [Key]
        public int Communication_Message_ID { get; set; }
        [Required]
        public int Communication_ID { get; set; }
        [Required]
        public int Action_Status_ID { get; set; }
        [Required]
        public DateTime Action_Status_Time { get; set; }
        [MaxLength(1024)]
        public string? Action_Text { get; set; }
        public int? Contact_ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string From { get; set; }
        [Required]
        [MaxLength(256)]
        public string To { get; set; }
        [MaxLength(256)]
        public string? Reply_To { get; set; }
        [MaxLength(256)]
        public string? Subject { get; set; }
        public string? Body { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
    [MPTable("dp_Communication_Publications")]
    public class dpCommunicationPublicationModel
    {
        [Required]
        [Key]
        public int Communication_Publication_ID { get; set; }
        [Required]
        public int Communication_ID { get; set; }
        [Required]
        public int Publication_ID { get; set; }
    }
    [MPTable("dp_Communication_Snippets")]
    public class dpCommunicationSnippetModel
    {
        [Required]
        [Key]
        public int Communication_Snippet_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public int? Pertains_To { get; set; }
    }
    [MPTable("dp_Communication_Templates")]
    public class dpCommunicationTemplateModel
    {
        [Required]
        [Key]
        public int Communication_Template_ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Template_Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Subject_Text { get; set; }
        [Required]
        public string Body_Html { get; set; }
        public string? Body_Data { get; set; }
        public int? Pertains_To_Page_ID { get; set; }
        public int? Template_User { get; set; }
        public int? Template_User_Group { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int From_Contact { get; set; }
        [Required]
        public int Reply_to_Contact { get; set; }
        [Required]
        public int Communication_Type_ID { get; set; }
    }
    [MPTable("dp_Communication_Types")]
    public class dpCommunicationTypeModel
    {
        [Required]
        [Key]
        public int Communication_Type_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Communication_Type { get; set; }
    }
    [MPTable("dp_Communications")]
    public class dpCommunicationModel
    {
        [Required]
        [Key]
        public int Communication_ID { get; set; }
        [Required]
        public int Author_User_ID { get; set; }
        [Required]
        public int Communication_Type_ID { get; set; }
        public int? Communication_Status_ID { get; set; }
        public int? Selection_ID { get; set; }
        [Required]
        public bool Send_To_Parents { get; set; }
        [Required]
        [MaxLength(256)]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public int? Pertains_To_Page_ID { get; set; }
        public int? _Sent_From_Task { get; set; }
        public int? To_Contact { get; set; }
        public int? From_SMS_Number { get; set; }
        [Required]
        public int From_Contact { get; set; }
        [Required]
        public int Reply_to_Contact { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public string? Time_Zone { get; set; }
        public string? Locale { get; set; }
        [Required]
        public bool Bulk_Email { get; set; }
        [Required]
        public bool Template { get; set; }
        [Required]
        public bool Active { get; set; }
        public DateTime? Expire_Date { get; set; }
        public int? Template_User { get; set; }
        public int? Template_User_Group { get; set; }
    }
    [MPTable("dp_Configuration_Lists")]
    public class dpConfigurationListModel
    {
        [Required]
        [Key]
        public int Configuration_List_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Application_Code { get; set; }
        [Required]
        [MaxLength(128)]
        public string List_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Key_Name { get; set; }
        [MaxLength(4000)]
        public string? Value { get; set; }
        [Required]
        [MaxLength(250)]
        public string _Warning { get; set; }
    }
    [MPTable("dp_Configuration_Settings")]
    public class dpConfigurationSettingModel
    {
        [Required]
        [Key]
        public int Configuration_Setting_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Application_Code { get; set; }
        [Required]
        [MaxLength(128)]
        public string Key_Name { get; set; }
        [MaxLength(4000)]
        public string? Value { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [MaxLength(250)]
        public string? _Warning { get; set; }
        public int? Primary_Key_Page_ID { get; set; }
    }
    [MPTable("dp_Contact_Publications")]
    public class dpContactPublicationModel
    {
        [Required]
        [Key]
        public int Contact_Publication_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Publication_ID { get; set; }
        [Required]
        public bool Unsubscribed { get; set; }
        [MaxLength(255)]
        public string? _Synced_List_Name { get; set; }
        [MaxLength(50)]
        public string? External_List_ID { get; set; }
    }
    [MPTable("dp_Export_Log")]
    public class dpExportLogModel
    {
        [Required]
        [Key]
        public int Export_ID { get; set; }
        [Required]
        public DateTime Date_Time { get; set; }
        [MaxLength(256)]
        public string? User_Name { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public string Table_Name { get; set; }
        [MaxLength(255)]
        public string? View_Title { get; set; }
        [Required]
        public int Record_Count { get; set; }
    }
    [MPTable("dp_Field_Format_Types")]
    public class dpFieldFormatTypeModel
    {
        [Required]
        [Key]
        public int Field_Format_Type_ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
    [MPTable("dp_Identity_Providers")]
    public class dpIdentityProviderModel
    {
        [Required]
        [Key]
        public int Identity_Provider_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Display_Name { get; set; }
        [Required]
        public int Identity_Provider_Type_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Client_ID { get; set; }
        public string? Client_Secret { get; set; }
        [MaxLength(128)]
        public string? Metadata_Address { get; set; }
        [Required]
        public bool Is_Public { get; set; }
        [Required]
        public string Identity_Provider_Unique_ID { get; set; }
        [MaxLength(4000)]
        public string? Settings { get; set; }
    }
    [MPTable("dp_Impersonate_Contacts")]
    public class dpImpersonateContactModel
    {
        [Required]
        [Key]
        public int Impersonate_Contact_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [MaxLength(255)]
        public string? Notes { get; set; }
    }
    [MPTable("dp_Inbound_SMS")]
    public class dpInboundSMSModel
    {
        [Required]
        [Key]
        public int Inbound_SMS_ID { get; set; }
        [Required]
        public DateTime Event_Time { get; set; }
        [Required]
        [MaxLength(64)]
        public string Message_ID { get; set; }
        [Required]
        [MaxLength(13)]
        public string Message_From { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Message_To { get; set; }
        [MaxLength(2048)]
        public string? Message_Text { get; set; }
        public int? Contact_ID { get; set; }
        public int? Last_Message_ID { get; set; }
    }
    [MPTable("dp_Notification_Page_Records")]
    public class dpNotificationPageRecordModel
    {
        [Required]
        [Key]
        public int Notification_Record_ID { get; set; }
        [Required]
        public int Notification_ID { get; set; }
        [Required]
        public int Page_ID { get; set; }
        [Required]
        public int Record_ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Record_Description { get; set; }
    }
    [MPTable("dp_Notification_Page_Views")]
    public class dpNotificationPageViewModel
    {
        [Required]
        [Key]
        public int Notification_Page_View_ID { get; set; }
        [Required]
        public int Notification_ID { get; set; }
        [Required]
        public int Page_View_ID { get; set; }
    }
    [MPTable("dp_Notification_Selections")]
    public class dpNotificationSelectionModel
    {
        [Required]
        [Key]
        public int Notification_Selection_ID { get; set; }
        [Required]
        public int Notification_ID { get; set; }
        [Required]
        public int Selection_ID { get; set; }
    }
    [MPTable("dp_Notification_Sub_Page_Views")]
    public class dpNotificationSubPageViewModel
    {
        [Required]
        [Key]
        public int Notification_Sub_Page_View_ID { get; set; }
        [Required]
        public int Notification_ID { get; set; }
        [Required]
        public int Sub_Page_View_ID { get; set; }
        [Required]
        public int Parent_Record_ID { get; set; }
    }
    [MPTable("dp_Notifications")]
    public class dpNotificationModel
    {
        [Required]
        [Key]
        public int Notification_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Recurrence_Name { get; set; }
        public DateTime? Last_Execution { get; set; }
        public DateTime? Next_Execution { get; set; }
        [Required]
        public string Notification_Type { get; set; }
        public int? Template_ID { get; set; }
        public int? User_Group_ID { get; set; }
        [Required]
        public bool Suppress_Empty_Results { get; set; }
        [Required]
        public string Time_Zone { get; set; }
        [Required]
        public string Locale { get; set; }
        [MaxLength(256)]
        public string? Subject { get; set; }
    }
    [MPTable("dp_Page_Views")]
    public class dpPageViewModel
    {
        [Required]
        [Key]
        public int Page_View_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string View_Title { get; set; }
        [Required]
        public int Page_ID { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [MaxLength(4000)]
        public string? Field_List { get; set; }
        [Required]
        [MaxLength(4000)]
        public string View_Clause { get; set; }
        [MaxLength(255)]
        public string? Order_By { get; set; }
        public int? User_ID { get; set; }
        public int? User_Group_ID { get; set; }
    }
    [MPTable("dp_Process_Steps")]
    public class dpProcessStepModel
    {
        [Required]
        [Key]
        public int Process_Step_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Step_Name { get; set; }
        [MaxLength(500)]
        public string? Instructions { get; set; }
        [Required]
        public int Process_Step_Type_ID { get; set; }
        [Required]
        public bool Escalation_Only { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public int Process_ID { get; set; }
        public int? Specific_User { get; set; }
        [Required]
        public bool Supervisor_User { get; set; }
        [MaxLength(1000)]
        public string? Lookup_User_Field { get; set; }
        public int? Escalate_to_Step { get; set; }
        public int? Task_Deadline { get; set; }
        public int? Email_Template { get; set; }
        public int? To_Specific_Contact { get; set; }
        [MaxLength(1000)]
        public string? Email_To_Contact_Field { get; set; }
        [MaxLength(1000)]
        public string? SQL_Statement { get; set; }
        public int? Webhook_ID { get; set; }
        public int? Text_Template { get; set; }
        [MaxLength(1000)]
        public string? Text_To_Contact_Field { get; set; }
        public int? Specific_User_Group_ID { get; set; }
        public int? Completion_Rule_ID { get; set; }
    }
    [MPTable("dp_Process_Submissions")]
    public class dpProcessSubmissionModel
    {
        [Required]
        [Key]
        public int Process_Submission_ID { get; set; }
        [Required]
        public int Submitted_By { get; set; }
        [Required]
        public DateTime Date_Submitted { get; set; }
        [Required]
        public int Process_ID { get; set; }
        [Required]
        public int Process_Submission_Status_ID { get; set; }
        [Required]
        public int _Record_ID { get; set; }
    }
    [MPTable("dp_Processes")]
    public class dpProcessModel
    {
        [Required]
        [Key]
        public int Process_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Process_Name { get; set; }
        [Required]
        public int Process_Manager { get; set; }
        [Required]
        public bool Active { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(500)]
        public string? On_Submit { get; set; }
        [MaxLength(500)]
        public string? On_Complete { get; set; }
        [MaxLength(255)]
        public string? Trigger_Fields { get; set; }
        [MaxLength(4000)]
        public string? Dependent_Condition { get; set; }
        [Required]
        public bool Trigger_On_Create { get; set; }
        [Required]
        public bool Trigger_On_Update { get; set; }
        [Required]
        public string Table_Name { get; set; }
    }
    [MPTable("dp_Publications")]
    public class dpPublicationModel
    {
        [Required]
        [Key]
        public int Publication_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public int? Congregation_ID { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Moderator { get; set; }
        public bool? Available_Online { get; set; }
        public int? Online_Sort_Order { get; set; }
        [MaxLength(50)]
        public string? MailChimp_List { get; set; }
        public DateTime? Last_Sync_Date { get; set; }
        [Required]
        public bool Sync_Nightly { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public bool On_Connection_Card { get; set; }
    }
    [MPTable("dp_Record_Insights")]
    public class dpRecordInsightModel
    {
        [Required]
        [Key]
        public int Record_Insight_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public int Page_ID { get; set; }
        public int? Sub_Page_View_ID { get; set; }
        [Required]
        public string Template { get; set; }
        [Required]
        public int View_Order { get; set; }
        [Required]
        public bool Active { get; set; }
    }
    [MPTable("dp_Record_Security")]
    public class dpRecordSecurityModel
    {
        [Required]
        [Key]
        public int Record_Security_ID { get; set; }
        [Required]
        public bool Restricted { get; set; }
        [Required]
        public int Record_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Table_Name { get; set; }
    }
    [MPTable("dp_Role_Reports")]
    public class dpRoleReportModel
    {
        [Required]
        [Key]
        public int Role_Report_ID { get; set; }
        [Required]
        public int Role_ID { get; set; }
        [Required]
        public int Report_ID { get; set; }
    }
    [MPTable("dp_Roles")]
    public class dpRoleModel
    {
        [Required]
        [Key]
        public int Role_ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Role_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Mass_Email_Quota { get; set; }
        public int? Mass_Text_Quota { get; set; }
        public int? Role_Type_ID { get; set; }
    }
    [MPTable("dp_SMS_Numbers")]
    public class dpSMSNumberModel
    {
        [Required]
        [Key]
        public int SMS_Number_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Number_Title { get; set; }
        public string? SMS_Number { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Default { get; set; }
        public int? User_Group_ID { get; set; }
    }
    [MPTable("dp_Sub_Page_Views")]
    public class dpSubPageViewModel
    {
        [Required]
        [Key]
        public int Sub_Page_View_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string View_Title { get; set; }
        [Required]
        public int Sub_Page_ID { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [MaxLength(4000)]
        public string? Field_List { get; set; }
        [Required]
        [MaxLength(4000)]
        public string View_Clause { get; set; }
        [MaxLength(255)]
        public string? Order_By { get; set; }
        public int? User_ID { get; set; }
        [Required]
        public bool Messaging_View { get; set; }
    }
    [MPTable("dp_Tasks")]
    public class dpTaskModel
    {
        [Required]
        [Key]
        public int Task_ID { get; set; }
        [MaxLength(75)]
        public string? Title { get; set; }
        [Required]
        public int Author_User_ID { get; set; }
        public int? Assigned_User_ID { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public bool Completed { get; set; }
        public string? Description { get; set; }
        public int? _Record_ID { get; set; }
        public int? _Process_Submission_ID { get; set; }
        public int? _Process_Step_ID { get; set; }
        [Required]
        public bool _Rejected { get; set; }
        [Required]
        public bool _Escalated { get; set; }
        [MaxLength(256)]
        public string? _Record_Description { get; set; }
        [MaxLength(50)]
        public string? _Table_Name { get; set; }
        [Required]
        public bool _Hidden { get; set; }
        public int? Assigned_User_Group_ID { get; set; }
        public int? Completion_Rule_ID { get; set; }
    }
    [MPTable("dp_User_Charts")]
    public class dpUserChartModel
    {
        [Required]
        [Key]
        public int User_Chart_ID { get; set; }
        [Required]
        public int Chart_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Chart_Type_ID { get; set; }
        [Required]
        public int Position { get; set; }
    }
    [MPTable("dp_User_Global_Filters")]
    public class dpUserGlobalFilterModel
    {
        [Required]
        [Key]
        public int dp_User_Global_Filter_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public string Global_Filter_ID { get; set; }
    }
    [MPTable("dp_User_Groups")]
    public class dpUserGroupModel
    {
        [Required]
        [Key]
        public int User_Group_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string User_Group_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Moderator { get; set; }
    }
    [MPTable("dp_User_Preferences")]
    public class dpUserPreferenceModel
    {
        [Required]
        [Key]
        public int User_Preference_ID { get; set; }
        public int? User_ID { get; set; }
        [Required]
        [MaxLength(64)]
        public string Key { get; set; }
        public string? Value { get; set; }
        public int? Page_ID { get; set; }
        public int? Sub_Page_ID { get; set; }
        public int? Page_View_ID { get; set; }
        public int? Sub_Page_View_ID { get; set; }
    }
    [MPTable("dp_User_Roles")]
    public class dpUserRoleModel
    {
        [Required]
        [Key]
        public int User_Role_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Role_ID { get; set; }
    }
    [MPTable("dp_User_User_Groups")]
    public class dpUserUserGroupModel
    {
        [Required]
        [Key]
        public int User_User_Group_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int User_Group_ID { get; set; }
    }
    [MPTable("dp_Users")]
    public class dpUserModel
    {
        [Required]
        [Key]
        public int User_ID { get; set; }
        [Required]
        [MaxLength(254)]
        public string User_Name { get; set; }
        [MaxLength(254)]
        public string? User_Email { get; set; }
        [MaxLength(75)]
        public string? Display_Name { get; set; }
        [Required]
        public bool Admin { get; set; }
        [Required]
        public bool Publications_Manager { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        public int? Supervisor { get; set; }
        [Required]
        public string User_GUID { get; set; }
        [Required]
        public bool Can_Impersonate { get; set; }
        public bool? In_Recovery { get; set; }
        public string? Time_Zone { get; set; }
        public string? Locale { get; set; }
        [MaxLength(32)]
        public string? Theme { get; set; }
        [Required]
        public bool Setup_Admin { get; set; }
        [Required]
        public bool Read_Permitted { get; set; }
        [Required]
        public bool Create_Permitted { get; set; }
        [Required]
        public bool Update_Permitted { get; set; }
        [Required]
        public bool Delete_Permitted { get; set; }
        [Required]
        public int Login_Attempts { get; set; }
        public bool? MFA_Required { get; set; }
    }
    [MPTable("dp_View_Keys")]
    public class dpViewKeyModel
    {
        [Required]
        [Key]
        public int View_Key_ID { get; set; }
        [Required]
        public string View_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Field_Name { get; set; }
        [Required]
        public string Foreign_Table_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Foreign_Field_Name { get; set; }
    }
    [MPTable("dp_Webhook_Invocations")]
    public class dpWebhookInvocationModel
    {
        [Required]
        [Key]
        public int Webhook_Invocation_ID { get; set; }
        [Required]
        public int Webhook_ID { get; set; }
        [Required]
        public int Record_ID { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        [Required]
        public int Status_ID { get; set; }
        [Required]
        public string Retries_Left { get; set; }
        public string? Uri { get; set; }
        [MaxLength(4000)]
        public string? Body { get; set; }
        [MaxLength(4000)]
        public string? Headers { get; set; }
        public string? Response { get; set; }
        public int? Task_ID { get; set; }
    }
    [MPTable("dp_Webhooks")]
    public class dpWebhookModel
    {
        [Required]
        [Key]
        public int Webhook_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Display_Name { get; set; }
        [MaxLength(1024)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(10)]
        public string Http_Method { get; set; }
        public string? Uri_Template { get; set; }
        [MaxLength(4000)]
        public string? Body_Template { get; set; }
        [MaxLength(4000)]
        public string? Headers_Template { get; set; }
        [MaxLength(255)]
        public string? Trigger_Fields { get; set; }
        [MaxLength(4000)]
        public string? Dependent_Condition { get; set; }
        [Required]
        public bool Trigger_On_Create { get; set; }
        [Required]
        public bool Trigger_On_Update { get; set; }
        [Required]
        public bool Trigger_On_Delete { get; set; }
        [Required]
        public string Max_Retries { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Table_Name { get; set; }
        [Required]
        public bool Trigger_On_File_Change { get; set; }
    }
    [MPTable("Equipment")]
    public class EquipmentModel
    {
        [Required]
        [Key]
        public int Equipment_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Equipment_Name { get; set; }
        [Required]
        public DateTime Date_Acquired { get; set; }
        public int? Equipment_Type_ID { get; set; }
        [Required]
        public int Room_ID { get; set; }
        [MaxLength(50)]
        public string? Model_Name { get; set; }
        [MaxLength(50)]
        public string? Serial_Number { get; set; }
        [MaxLength(50)]
        public string? Inventory_Number { get; set; }
        [Required]
        public bool Bookable { get; set; }
        [Required]
        public bool Separately_Insured { get; set; }
        public decimal? Purchase_Price { get; set; }
        public DateTime? Date_Retired { get; set; }
        public int? Equipment_Coordinator { get; set; }
        [Required]
        public bool Auto_Approve { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    [MPTable("Equipment_Types")]
    public class EquipmentTypeModel
    {
        [Required]
        [Key]
        public int Equipment_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Equipment_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Event_Equipment")]
    public class EventEquipmentModel
    {
        [Required]
        [Key]
        public int Event_Equipment_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Equipment_ID { get; set; }
        public int? Room_ID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [MaxLength(75)]
        public string? Desired_Placement_or_Location { get; set; }
        public bool? _Approved { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
    }
    [MPTable("Event_Groups")]
    public class EventGroupModel
    {
        [Required]
        [Key]
        public int Event_Group_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        public int? Room_ID { get; set; }
        public bool? Closed { get; set; }
        public int? Curriculum_ID { get; set; }
    }
    [MPTable("Event_Metrics")]
    public class EventMetricModel
    {
        [Required]
        [Key]
        public int Event_Metric_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Metric_ID { get; set; }
        [Required]
        public decimal Numerical_Value { get; set; }
        public int? Group_ID { get; set; }
    }
    [MPTable("Event_Participants")]
    public class EventParticipantModel
    {
        [Required]
        [Key]
        public int Event_Participant_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [Required]
        public int Participation_Status_ID { get; set; }
        public DateTime? Time_In { get; set; }
        public DateTime? Time_Confirmed { get; set; }
        public DateTime? Time_Out { get; set; }
        [MaxLength(4000)]
        public string? Notes { get; set; }
        public int? Group_Participant_ID { get; set; }
        [MaxLength(50)]
        [JsonProperty(PropertyName = "Check-in_Station")]
        public string? Check_in_Station { get; set; }
        public DateTime? _Setup_Date { get; set; }
        public int? Group_ID { get; set; }
        public int? Room_ID { get; set; }
        public bool? Call_Parents { get; set; }
        public int? Group_Role_ID { get; set; }
        public int? Response_ID { get; set; }
        [Required]
        public bool Registrant_Message_Sent { get; set; }
        [Required]
        public bool Attendee_Message_Sent { get; set; }
        [Required]
        public bool Attending_Online { get; set; }
        public int? RSVP_Status_ID { get; set; }
    }
    [MPTable("Event_Rooms")]
    public class EventRoomModel
    {
        [Required]
        [Key]
        public int Event_Room_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Room_ID { get; set; }
        public int? Group_ID { get; set; }
        public bool? Default_Group_Room { get; set; }
        [Required]
        public int Balance_Priority { get; set; }
        [Required]
        public bool Closed { get; set; }
        [Required]
        public bool Auto_Close_At_Capacity { get; set; }
        public int? Room_Layout_ID { get; set; }
        public int? Chairs { get; set; }
        public int? Tables { get; set; }
        public string? Notes { get; set; }
        public bool? _Approved { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        public int? Checkin_Capacity { get; set; }
    }
    [MPTable("Event_Services")]
    public class EventServiceModel
    {
        [Required]
        [Key]
        public int Event_Service_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public int Service_ID { get; set; }
        public int? Quantity { get; set; }
        [MaxLength(50)]
        public string? Location_For_Service { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        public bool? _Approved { get; set; }
    }
    [MPTable("Event_Types")]
    public class EventTypeModel
    {
        [Required]
        [Key]
        public int Event_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Event_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(25)]
        public string? Color { get; set; }
        [Required]
        public bool Show_On_MPMobile { get; set; }
        [Required]
        public bool Omit_From_Engagement_Attendance { get; set; }
        [Required]
        public bool Auto_Close_Registrations { get; set; }
    }
    [MPTable("Events")]
    public class EventModel
    {
        [Required]
        [Key]
        public int Event_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Event_Title { get; set; }
        [Required]
        public int Event_Type_ID { get; set; }
        [Required]
        public int Congregation_ID { get; set; }
        public int? Location_ID { get; set; }
        [MaxLength(4000)]
        public string? Meeting_Instructions { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Required]
        public int Program_ID { get; set; }
        [Required]
        public int Primary_Contact { get; set; }
        public int? Participants_Expected { get; set; }
        [Required]
        public int Minutes_for_Setup { get; set; }
        [Required]
        public DateTime Event_Start_Date { get; set; }
        [Required]
        public DateTime Event_End_Date { get; set; }
        [Required]
        public int Minutes_for_Cleanup { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        public bool? _Approved { get; set; }
        [Required]
        public int Visibility_Level_ID { get; set; }
        [Required]
        public bool Featured_On_Calendar { get; set; }
        public int? Online_Registration_Product { get; set; }
        public int? Registration_Form { get; set; }
        public DateTime? Registration_Start { get; set; }
        public DateTime? Registration_End { get; set; }
        [Required]
        public bool Registration_Active { get; set; }
        [Required]
        public bool Register_Into_Series { get; set; }
        public string? External_Registration_URL { get; set; }
        public bool? _Web_Approved { get; set; }
        [Required]
        public bool Force_Login { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Allow_Check-in")]
        public bool Allow_Check_in { get; set; }
        [Required]
        public bool Ignore_Program_Groups { get; set; }
        [Required]
        public bool Prohibit_Guests { get; set; }
        [Required]
        public int Search_Results { get; set; }
        [JsonProperty(PropertyName = "Early_Check-in_Period")]
        public int? Early_Check_in_Period { get; set; }
        [JsonProperty(PropertyName = "Late_Check-in_Period")]
        public int? Late_Check_in_Period { get; set; }
        public int? Registrant_Message { get; set; }
        public int? Days_Out_to_Remind { get; set; }
        public int? Optional_Reminder_Message { get; set; }
        public int? Attendee_Message { get; set; }
        [Required]
        public bool Send_To_Heads { get; set; }
        public int? Parent_Event_ID { get; set; }
        public int? Priority_ID { get; set; }
        [Required]
        public bool On_Connection_Card { get; set; }
        [Required]
        public bool On_Donation_Batch_Tool { get; set; }
        [MaxLength(15)]
        public string? Project_Code { get; set; }
        [MaxLength(2083)]
        public string? Online_Meeting_Link { get; set; }
        [MaxLength(1000)]
        public string? Read_More_URL { get; set; }
        [Required]
        public bool Allow_Self_Checkin { get; set; }
        [Required]
        public bool Minor_Registration { get; set; }
        [Required]
        public bool Allow_Email { get; set; }
        [Required]
        public bool Show_Building_Room_Info { get; set; }
    }
    [MPTable("Feedback_Entries")]
    public class FeedbackEntryModel
    {
        [Required]
        [Key]
        public int Feedback_Entry_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Entry_Title { get; set; }
        [Required]
        public int Feedback_Type_ID { get; set; }
        public int? Program_ID { get; set; }
        [Required]
        public DateTime Date_Submitted { get; set; }
        [Required]
        public int Visibility_Level_ID { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Required]
        public bool Ongoing_Need { get; set; }
        public int? Assigned_To { get; set; }
        public int? Care_Outcome_ID { get; set; }
        public DateTime? Outcome_Date { get; set; }
        [Required]
        public bool Approved { get; set; }
        public int? Care_Case_ID { get; set; }
    }
    [MPTable("Feedback_Types")]
    public class FeedbackTypeModel
    {
        [Required]
        [Key]
        public int Feedback_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Feedback_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Follow_Up_Action_Types")]
    public class FollowUpActionTypeModel
    {
        [Required]
        [Key]
        public int Action_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Action_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Form_Field_Types")]
    public class FormFieldTypeModel
    {
        [Required]
        [Key]
        public int Form_Field_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Field_Type { get; set; }
    }
    [MPTable("Form_Fields")]
    public class FormFieldModel
    {
        [Required]
        [Key]
        public int Form_Field_ID { get; set; }
        [Required]
        public int Field_Order { get; set; }
        [Required]
        [MaxLength(128)]
        public string Field_Label { get; set; }
        [Required]
        public int Field_Type_ID { get; set; }
        [MaxLength(4000)]
        public string? Field_Values { get; set; }
        [Required]
        public bool Required { get; set; }
        [Required]
        public int Form_ID { get; set; }
        [Required]
        public bool Placement_Required { get; set; }
        public string? Alternate_Label { get; set; }
        [Required]
        public bool Is_Hidden { get; set; }
        public int? Depends_On { get; set; }
        [MaxLength(255)]
        public string? Depends_On_Value { get; set; }
    }
    [MPTable("Form_Response_Answers")]
    public class FormResponseAnswerModel
    {
        [Required]
        [Key]
        public int Form_Response_Answer_ID { get; set; }
        [Required]
        public int Form_Field_ID { get; set; }
        public string? Response { get; set; }
        [Required]
        public int Form_Response_ID { get; set; }
        public int? Event_Participant_ID { get; set; }
        public int? Pledge_ID { get; set; }
        public int? Opportunity_Response { get; set; }
        public bool? Placed { get; set; }
    }
    [MPTable("Form_Responses")]
    public class FormResponsModel
    {
        [Required]
        [Key]
        public int Form_Response_ID { get; set; }
        [Required]
        public int Form_ID { get; set; }
        [Required]
        public DateTime Response_Date { get; set; }
        [MaxLength(45)]
        public string? IP_Address { get; set; }
        public int? Contact_ID { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        public string? Email_Address { get; set; }
        [MaxLength(50)]
        public string? Phone_Number { get; set; }
        [MaxLength(75)]
        public string? Address_Line_1 { get; set; }
        [MaxLength(75)]
        public string? Address_Line_2 { get; set; }
        [MaxLength(50)]
        public string? Address_City { get; set; }
        [MaxLength(50)]
        public string? Address_State { get; set; }
        [MaxLength(25)]
        public string? Address_Zip { get; set; }
        public int? Event_ID { get; set; }
        public int? Pledge_Campaign_ID { get; set; }
        public int? Opportunity_ID { get; set; }
        public int? Opportunity_Response { get; set; }
        public int? Congregation_ID { get; set; }
        [Required]
        public bool Notification_Sent { get; set; }
        public DateTime? Expires { get; set; }
    }
    [MPTable("Forms")]
    public class FormModel
    {
        [Required]
        [Key]
        public int Form_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Form_Title { get; set; }
        public int? Congregation_ID { get; set; }
        public string? Instructions { get; set; }
        [Required]
        public bool Get_Contact_Info { get; set; }
        [Required]
        public bool Get_Address_Info { get; set; }
        [Required]
        public string Form_GUID { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Complete_Message { get; set; }
        public int? Primary_Contact { get; set; }
        [Required]
        public bool Notify { get; set; }
        public int? Response_Message { get; set; }
        public int? Months_Till_Expires { get; set; }
        public int? Expiring_Soon_Days { get; set; }
        [Required]
        public bool Force_Login { get; set; }
    }
    [MPTable("Genders")]
    public class GenderModel
    {
        [Required]
        [Key]
        public int Gender_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Gender { get; set; }
    }
    [MPTable("Group_Activities")]
    public class GroupActivityModel
    {
        [Required]
        [Key]
        public int Group_Activity_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Activity { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Attributes")]
    public class GroupAttributeModel
    {
        [Required]
        [Key]
        public int Group_Attribute_ID { get; set; }
        [Required]
        public int Attribute_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [MaxLength(255)]
        public string? Notes { get; set; }
    }
    [MPTable("Group_Ended_Reasons")]
    public class GroupEndedReasonModel
    {
        [Required]
        [Key]
        public int Group_Ended_Reason_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Ended_Reason { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Focuses")]
    public class GroupFocusModel
    {
        [Required]
        [Key]
        public int Group_Focus_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Focus { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Inquiries")]
    public class GroupInquiryModel
    {
        [Required]
        [Key]
        public int Group_Inquiry_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        public int? Contact_ID { get; set; }
        [Required]
        public DateTime Inquiry_Date { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        public string? Phone { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }
        [MaxLength(1000)]
        public string? Comments { get; set; }
        public bool? Placed { get; set; }
        public bool? _From_Group_Finder { get; set; }
    }
    [MPTable("Group_Participants")]
    public class GroupParticipantModel
    {
        [Required]
        [Key]
        public int Group_Participant_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [Required]
        public int Group_Role_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public bool Employee_Role { get; set; }
        public int? Hours_Per_Week { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        [Required]
        public bool Need_Book { get; set; }
        [Required]
        public bool Email_Opt_Out { get; set; }
        [Required]
        public bool Share_With_Group { get; set; }
        [Required]
        public bool Auto_Promote { get; set; }
        public DateTime? _First_Attendance { get; set; }
        public DateTime? _Second_Attendance { get; set; }
        public DateTime? _Third_Attendance { get; set; }
        public DateTime? _Last_Attendance { get; set; }
        [Required]
        public bool Show_Email { get; set; }
        [Required]
        public bool Show_Phone { get; set; }
        [Required]
        public bool Show_Last_Name { get; set; }
        [Required]
        public bool Show_Photo { get; set; }
        [Required]
        public bool _Show_Birthday { get; set; }
        [Required]
        public bool _Show_Email { get; set; }
        [Required]
        public bool _Show_Home_Phone { get; set; }
        [Required]
        public bool _Show_Mobile_Phone { get; set; }
        [Required]
        public bool _Show_Address { get; set; }
        [Required]
        public bool _Show_Photo { get; set; }
    }
    [MPTable("Group_Role_Directions")]
    public class GroupRoleDirectionModel
    {
        [Required]
        [Key]
        public int Group_Role_Direction_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Role_Direction { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Role_Intensities")]
    public class GroupRoleIntensityModel
    {
        [Required]
        [Key]
        public int Group_Role_Intensity_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Role_Intensity { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Role_Types")]
    public class GroupRoleTypeModel
    {
        [Required]
        [Key]
        public int Group_Role_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Role_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Group_Roles")]
    public class GroupRoleModel
    {
        [Required]
        [Key]
        public int Group_Role_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Role_Title { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Group_Role_Type_ID { get; set; }
        [Required]
        public int Group_Role_Direction_ID { get; set; }
        [Required]
        public int Group_Role_Intensity_ID { get; set; }
        public int? Ministry_ID { get; set; }
        [Required]
        public bool Background_Check_Required { get; set; }
        public bool? Omit_From_Portal { get; set; }
        [Required]
        public bool Manages_Volunteers { get; set; }
    }
    [MPTable("Group_Rooms")]
    public class GroupRoomModel
    {
        [Required]
        [Key]
        public int Group_Room_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        [Required]
        public int Room_ID { get; set; }
        [Required]
        public bool Default_Room { get; set; }
        [Required]
        public bool Discontinued { get; set; }
    }
    [MPTable("Group_Types")]
    public class GroupTypeModel
    {
        [Required]
        [Key]
        public int Group_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Group_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Default_Role { get; set; }
        [Required]
        public bool Activity_Log_Start_Date { get; set; }
        [Required]
        public bool Show_On_Group_Finder { get; set; }
        [Required]
        public bool Show_On_MPMobile { get; set; }
        [Required]
        public bool Omit_From_Engagement_Group_Life { get; set; }
        [Required]
        public bool Volunteer_Group { get; set; }
    }
    [MPTable("Groups")]
    public class GroupModel
    {
        [Required]
        [Key]
        public int Group_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Group_Name { get; set; }
        [Required]
        public int Group_Type_ID { get; set; }
        [Required]
        public int Ministry_ID { get; set; }
        [Required]
        public int Congregation_ID { get; set; }
        [Required]
        public int Primary_Contact { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Target_Size { get; set; }
        public int? Parent_Group { get; set; }
        public int? Priority_ID { get; set; }
        public int? Offsite_Meeting_Address { get; set; }
        [Required]
        public bool Group_Is_Full { get; set; }
        [Required]
        public bool Available_Online { get; set; }
        [Required]
        public bool Meets_Online { get; set; }
        public int? Life_Stage_ID { get; set; }
        public int? Group_Focus_ID { get; set; }
        public DateTime? Meeting_Time { get; set; }
        public int? Meeting_Day_ID { get; set; }
        public int? Meeting_Frequency_ID { get; set; }
        public int? Meeting_Duration_ID { get; set; }
        public int? Required_Book { get; set; }
        public int? Descended_From { get; set; }
        public int? Reason_Ended { get; set; }
        public DateTime? _Last_Attendance_Posted { get; set; }
        public DateTime? _Last_Group_Member_Changed { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Secure_Check-in")]
        public bool Secure_Check_in { get; set; }
        [Required]
        public bool Suppress_Nametag { get; set; }
        [Required]
        public bool Suppress_Care_Note { get; set; }
        [Required]
        public bool On_Classroom_Manager { get; set; }
        public int? Promote_to_Group { get; set; }
        public int? Age_in_Months_to_Promote { get; set; }
        [Required]
        public bool Promote_Weekly { get; set; }
        public DateTime? Promotion_Date { get; set; }
        [Required]
        public bool Promote_Participants_Only { get; set; }
        [Required]
        public bool Send_Attendance_Notification { get; set; }
        [Required]
        public bool Send_Service_Notification { get; set; }
        [Required]
        public bool Enable_Discussion { get; set; }
        public int? SMS_Number { get; set; }
        public int? Default_Meeting_Room { get; set; }
        [Required]
        public bool Create_Next_Meeting { get; set; }
        public DateTime? Next_Scheduled_Meeting { get; set; }
        public bool? Available_On_App { get; set; }
    }
    [MPTable("Household_Care_Log")]
    public class HouseholdCareLogModel
    {
        [Required]
        [Key]
        public int Household_Care_ID { get; set; }
        [Required]
        public int Household_ID { get; set; }
        [Required]
        public int Care_Type_ID { get; set; }
        [Required]
        public int Care_Outcome_ID { get; set; }
        public DateTime? Date_Provided { get; set; }
        [Required]
        public int Provided_By { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
        public decimal? Care_Amount { get; set; }
        public int? Paid_To { get; set; }
        public int? Care_Case_ID { get; set; }
        [Required]
        public bool PRIVATE { get; set; }
        public int? Contact_ID { get; set; }
        [Required]
        public bool Completed { get; set; }
        public DateTime? Action_Date { get; set; }
    }
    [MPTable("Household_Identifier_Log")]
    public class HouseholdIdentifierLogModel
    {
        [Required]
        [Key]
        public int Household_Identifier_ID { get; set; }
        [Required]
        public int Household_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Source_System_Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Source_Type_Name { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Identifier_Value { get; set; }
        [Required]
        public DateTime _Date_Inserted { get; set; }
    }
    [MPTable("Household_Positions")]
    public class HouseholdPositionModel
    {
        [Required]
        [Key]
        public int Household_Position_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Household_Position { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Household_Sources")]
    public class HouseholdSourceModel
    {
        [Required]
        [Key]
        public int Household_Source_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Household_Source { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Household_Types")]
    public class HouseholdTypeModel
    {
        [Required]
        [Key]
        public int Household_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Household_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Households")]
    public class HouseholdModel
    {
        [Required]
        [Key]
        public int Household_ID { get; set; }
        [Required]
        [MaxLength(75)]
        public string Household_Name { get; set; }
        public int? Address_ID { get; set; }
        public string? Home_Phone { get; set; }
        public int? Congregation_ID { get; set; }
        public int? Care_Person { get; set; }
        public int? Household_Source_ID { get; set; }
        public int? Family_Call_Number { get; set; }
        [Required]
        public bool Home_Phone_Unlisted { get; set; }
        [Required]
        public bool Home_Address_Unlisted { get; set; }
        [Required]
        public bool Bulk_Mail_Opt_Out { get; set; }
        public DateTime? _First_Donation { get; set; }
        public DateTime? _Last_Donation { get; set; }
        public DateTime? _Last_Activity { get; set; }
        public int? Alternate_Mailing_Address { get; set; }
        public DateTime? Season_Start { get; set; }
        public DateTime? Season_End { get; set; }
        [Required]
        public bool Repeats_Annually { get; set; }
        public decimal? Driving_Distance { get; set; }
        public decimal? Driving_Time { get; set; }
    }
    [MPTable("Import_Destinations")]
    public class ImportDestinationModel
    {
        [Required]
        [Key]
        public int Import_Destination_ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Table_Name { get; set; }
    }
    [MPTable("Import_Templates")]
    public class ImportTemplateModel
    {
        [Required]
        [Key]
        public int Import_Template_ID { get; set; }
        [Required]
        public int Import_Destination_ID { get; set; }
        public int? Congregation_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Import_Template_Name { get; set; }
        [Required]
        public string _Template { get; set; }
    }
    [MPTable("Industries")]
    public class IndustryModel
    {
        [Required]
        [Key]
        public int Industry_ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Industry_Title { get; set; }
    }
    [MPTable("Invoice_Detail")]
    public class InvoiceDetailModel
    {
        [Required]
        [Key]
        public int Invoice_Detail_ID { get; set; }
        [Required]
        public int Invoice_ID { get; set; }
        [Required]
        public int Recipient_Contact_ID { get; set; }
        public int? Event_Participant_ID { get; set; }
        [Required]
        public int Item_Quantity { get; set; }
        [Required]
        public decimal Line_Total { get; set; }
        [Required]
        public int Product_ID { get; set; }
        public int? Product_Option_Price_ID { get; set; }
        [MaxLength(500)]
        public string? Item_Note { get; set; }
        [MaxLength(75)]
        public string? Recipient_Name { get; set; }
        [MaxLength(500)]
        public string? Recipient_Address { get; set; }
        public string? Recipient_Email { get; set; }
        public string? Recipient_Phone { get; set; }
        [Required]
        public bool Deposit_Requested { get; set; }
    }
    [MPTable("Invoice_Sources")]
    public class InvoiceSourceModel
    {
        [Required]
        [Key]
        public int Invoice_Source_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Invoice_Source { get; set; }
    }
    [MPTable("Invoice_Statuses")]
    public class InvoiceStatusModel
    {
        [Required]
        [Key]
        public int Invoice_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Invoice_Status { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Invoices")]
    public class InvoiceModel
    {
        [Required]
        [Key]
        public int Invoice_ID { get; set; }
        [Required]
        public int Purchaser_Contact_ID { get; set; }
        [Required]
        public int Invoice_Status_ID { get; set; }
        [Required]
        public decimal Invoice_Total { get; set; }
        [Required]
        public DateTime Invoice_Date { get; set; }
        [MaxLength(4000)]
        public string? Notes { get; set; }
        [MaxLength(25)]
        public string? Currency { get; set; }
        public int? Congregation_ID { get; set; }
        [Required]
        public string Invoice_GUID { get; set; }
        public int? Invoice_Source { get; set; }
        [MaxLength(255)]
        public string? Cancel_Reason { get; set; }
    }
    [MPTable("Item_Priorities")]
    public class ItemPriorityModel
    {
        [Required]
        [Key]
        public int Item_Priority_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Priority { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Item_Statuses")]
    public class ItemStatusModel
    {
        [Required]
        [Key]
        public int Item_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Journeys")]
    public class JourneyModel
    {
        [Required]
        [Key]
        public int Journey_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Journey_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Leadership_Team { get; set; }
        public bool? Gamify { get; set; }
        public bool? Active { get; set; }
        [MaxLength(400)]
        public string? Badge { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [MaxLength(150)]
        public string? Finish_Message { get; set; }
    }
    [MPTable("Letters")]
    public class LetterModel
    {
        [Required]
        [Key]
        public int Letter_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Letter_Title { get; set; }
        public int? Page_ID { get; set; }
        public string? Letter_Opening { get; set; }
        public string? Letter_Body { get; set; }
        public string? Letter_From { get; set; }
        [Required]
        public bool Active { get; set; }
        public int? Congregation_ID { get; set; }
    }
    [MPTable("Life_Stages")]
    public class LifeStageModel
    {
        [Required]
        [Key]
        public int Life_Stage_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Life_Stage { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Location_Types")]
    public class LocationTypeModel
    {
        [Required]
        [Key]
        public int Location_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Location_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Locations")]
    public class LocationModel
    {
        [Required]
        [Key]
        public int Location_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Location_Name { get; set; }
        public int? Congregation_ID { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Location_Type_ID { get; set; }
        [Required]
        public int Address_ID { get; set; }
        public DateTime? Move_In_Date { get; set; }
        public DateTime? Move_Out_Date { get; set; }
        public string? Phone { get; set; }
    }
    [MPTable("Maintenance_Requests")]
    public class MaintenanceRequestModel
    {
        [Required]
        [Key]
        public int Maintenance_Request_ID { get; set; }
        [Required]
        public int Submitted_For { get; set; }
        [Required]
        public DateTime Request_Date { get; set; }
        [Required]
        [MaxLength(50)]
        public string Request_Title { get; set; }
        [MaxLength(4000)]
        public string? Description { get; set; }
        [MaxLength(4000)]
        public string? Notes { get; set; }
        public bool? _Completed { get; set; }
    }
    [MPTable("Mapping_Values")]
    public class MappingValueModel
    {
        [Required]
        [Key]
        public int Mapping_Value_ID { get; set; }
        public int? MP_FK { get; set; }
        [Required]
        public int Other_FK { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sub_Type { get; set; }
    }
    [MPTable("Marital_Statuses")]
    public class MaritalStatusModel
    {
        [Required]
        [Key]
        public int Marital_Status_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Marital_Status { get; set; }
    }
    [MPTable("Meeting_Days")]
    public class MeetingDayModel
    {
        [Required]
        [Key]
        public int Meeting_Day_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Meeting_Day { get; set; }
    }
    [MPTable("Meeting_Durations")]
    public class MeetingDurationModel
    {
        [Required]
        [Key]
        public int Meeting_Duration_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Meeting_Duration { get; set; }
        [Required]
        public int Meeting_Duration_Minutes { get; set; }
    }
    [MPTable("Meeting_Frequencies")]
    public class MeetingFrequencyModel
    {
        [Required]
        [Key]
        public int Meeting_Frequency_ID { get; set; }
        [MaxLength(50)]
        public string? Meeting_Frequency { get; set; }
    }
    [MPTable("Member_Statuses")]
    public class MemberStatusModel
    {
        [Required]
        [Key]
        public int Member_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Member_Status { get; set; }
        [Required]
        public bool Can_Access_Directory { get; set; }
        [Required]
        public bool Show_In_Directory { get; set; }
    }
    [MPTable("Metrics")]
    public class MetricModel
    {
        [Required]
        [Key]
        public int Metric_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Metric_Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
    [MPTable("Milestones")]
    public class MilestoneModel
    {
        [Required]
        [Key]
        public int Milestone_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Milestone_Title { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Journey_ID { get; set; }
        public int? Next_Milestone { get; set; }
        [MaxLength(2000)]
        public string? Follow_Up_Notes { get; set; }
        [Required]
        public bool Add_to_Event_Metrics { get; set; }
        public string? Letter_Body { get; set; }
        public string? Letter_From { get; set; }
        public int? Sort_Order { get; set; }
        [Required]
        public bool Discontinued { get; set; }
        [Required]
        public bool On_Connection_Card { get; set; }
        [MaxLength(50)]
        public string? Icon { get; set; }
        public bool? Gamify { get; set; }
        [MaxLength(70)]
        public string? Call_To_Action_Button_Text { get; set; }
        [MaxLength(70)]
        public string? Call_To_Action { get; set; }
        [MaxLength(2000)]
        public string? Scripture_on_Certificate { get; set; }
        [Required]
        public bool Show_on_Certificate { get; set; }
        [MaxLength(50)]
        public string? Certificate_Person_Label { get; set; }
    }
    [MPTable("Ministries")]
    public class MinistryModel
    {
        [Required]
        [Key]
        public int Ministry_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ministry_Name { get; set; }
        [MaxLength(50)]
        public string? Nickname { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public int Primary_Contact { get; set; }
        public int? Parent_Ministry { get; set; }
        [Required]
        public bool Available_Online { get; set; }
        public int? Priority_ID { get; set; }
        public int? Leadership_Team { get; set; }
    }
    [MPTable("MobileApp_Menu_Items")]
    public class MobileAppMenuItemModel
    {
        [Required]
        [Key]
        public int MobileApp_Menu_Item_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Menu_Item { get; set; }
        [MaxLength(50)]
        public string? Icon { get; set; }
        [Required]
        [MaxLength(512)]
        public string Launch_URL { get; set; }
        [Required]
        public bool Send_Authentication { get; set; }
        [Required]
        public int Sort_Order { get; set; }
        public int? Role_ID { get; set; }
    }
    [MPTable("mp_vw_Current_Program_Participants")]
    public class mpvwCurrentProgramParticipantModel
    {
        [Required]
        public int Participant_ID { get; set; }
        [Required]
        public int Program_ID { get; set; }
        [Required]
        public int Ministry_ID { get; set; }
        public int? Program_Roles { get; set; }
        [Required]
        [MaxLength(11)]
        public string Current_Involvement { get; set; }
        public int? Leader_Roles { get; set; }
        public int? Servant_Roles { get; set; }
        public int? Participant_Roles { get; set; }
    }
    [MPTable("mp_vw_Last_Known_Activity")]
    public class mpvwLastKnownActivityModel
    {
        [Required]
        public int Participant_ID { get; set; }
        public DateTime? Last_Known_Activity { get; set; }
    }
    [MPTable("mp_vw_possible_leaders")]
    public class mpvwpossibleleaderModel
    {
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
    }
    [MPTable("mp_vw_Primary_HH")]
    public class mpvwPrimaryHHModel
    {
        [Required]
        public int Household_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Household_Position_ID { get; set; }
    }
    [MPTable("Need_Campaigns")]
    public class NeedCampaignModel
    {
        [Required]
        [Key]
        public int Need_Campaign_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Campaign_Title { get; set; }
        [Required]
        public string Campaign_Guid { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public bool Is_Default { get; set; }
        [Required]
        public int Expected_Days_to_Complete { get; set; }
        [Required]
        public bool Allow_Other_Need_Types { get; set; }
    }
    [MPTable("Need_Providers")]
    public class NeedProviderModel
    {
        [Required]
        [Key]
        public int Need_Provider_ID { get; set; }
        [Required]
        public int Contact_ID { get; set; }
    }
    [MPTable("Need_Type_Providers")]
    public class NeedTypeProviderModel
    {
        [Required]
        [Key]
        public int Need_Type_Provider_ID { get; set; }
        public int? Need_Type_ID { get; set; }
        [MaxLength(255)]
        public string? Other_Need { get; set; }
        [Required]
        public int Need_Provider_ID { get; set; }
        public bool? Approved { get; set; }
    }
    [MPTable("Need_Types")]
    public class NeedTypeModel
    {
        [Required]
        [Key]
        public int Need_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Need_Type { get; set; }
        [Required]
        public int Need_Campaign_ID { get; set; }
    }
    [MPTable("Needs")]
    public class NeedModel
    {
        [Required]
        [Key]
        public int Need_ID { get; set; }
        [Required]
        public int Requester_Contact { get; set; }
        [MaxLength(15)]
        public string? Postal_Code { get; set; }
        [Required]
        public int Need_Campaign_ID { get; set; }
        public int? Need_Type_ID { get; set; }
        [MaxLength(255)]
        public string? Other_Need { get; set; }
        public DateTime? Target_Date { get; set; }
        [Required]
        public bool Complete { get; set; }
        public int? Need_Provider_ID { get; set; }
        public DateTime? Date_Assigned { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        [Required]
        public string Need_Guid { get; set; }
        public int? Care_Case_ID { get; set; }
    }
    [MPTable("Occupations")]
    public class OccupationModel
    {
        [Required]
        [Key]
        public int Occupation_ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Occupation_Title { get; set; }
    }
    [MPTable("Opportunities")]
    public class OpportunityModel
    {
        [Required]
        [Key]
        public int Opportunity_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Opportunity_Title { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Required]
        public int Group_Role_ID { get; set; }
        [Required]
        public int Program_ID { get; set; }
        [Required]
        public int Visibility_Level_ID { get; set; }
        [Required]
        public int Contact_Person { get; set; }
        [Required]
        public DateTime Publish_Date { get; set; }
        public DateTime? Opportunity_Date { get; set; }
        public int? Duration_in_Hours { get; set; }
        public int? Add_to_Group { get; set; }
        public int? Add_to_Event { get; set; }
        public int? Required_Gender { get; set; }
        public string? Minimum_Age { get; set; }
        public int? Minimum_Needed { get; set; }
        public int? Maximum_Needed { get; set; }
        public string? Letter_Body { get; set; }
        public string? Letter_From { get; set; }
        [Required]
        public bool On_Connection_Card { get; set; }
        public DateTime? Shift_Start { get; set; }
        public DateTime? Shift_End { get; set; }
        public int? Custom_Form { get; set; }
        public int? Response_Message { get; set; }
        [Required]
        public bool Close_Responses { get; set; }
        public DateTime? Date_To_Remind { get; set; }
        public int? Optional_Reminder_Message { get; set; }
        public bool? Send_To_Heads { get; set; }
    }
    [MPTable("Opportunity_Attributes")]
    public class OpportunityAttributeModel
    {
        [Required]
        [Key]
        public int Opportunity_Attribute_ID { get; set; }
        [Required]
        public int Attribute_ID { get; set; }
        [Required]
        public int Opportunity_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [MaxLength(255)]
        public string? Notes { get; set; }
    }
    [MPTable("Participant_Certifications")]
    public class ParticipantCertificationModel
    {
        [Required]
        [Key]
        public int Participant_Certification_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [Required]
        public int Certification_Type_ID { get; set; }
        [Required]
        public DateTime Certification_Submitted { get; set; }
        public DateTime? Certification_Completed { get; set; }
        public bool? Passed { get; set; }
        public DateTime? Certification_Expires { get; set; }
        [Required]
        public string Certification_GUID { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
    [MPTable("Participant_Engagement")]
    public class ParticipantEngagementModel
    {
        [Required]
        [Key]
        public int Participant_Engagement_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Engagement_Level { get; set; }
        [MaxLength(500)]
        public string? Engagement_Level_Rules { get; set; }
    }
    [MPTable("Participant_Milestones")]
    public class ParticipantMilestoneModel
    {
        [Required]
        [Key]
        public int Participant_Milestone_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [Required]
        public int Milestone_ID { get; set; }
        [Required]
        public int Program_ID { get; set; }
        public DateTime? Date_Accomplished { get; set; }
        public int? Event_ID { get; set; }
        public int? Witness { get; set; }
        [Required]
        public bool At_Prior_Church { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
        [Required]
        public bool Followed_Up { get; set; }
        [Required]
        public bool Discontinue_Journey { get; set; }
        [MaxLength(150)]
        public string? Performed_By { get; set; }
        [MaxLength(255)]
        public string? Place { get; set; }
        [MaxLength(150)]
        public string? Sacramental_Name { get; set; }
        [Required]
        public bool Received { get; set; }
        public int? Registry_Volume { get; set; }
        public int? Registry_Page { get; set; }
        public int? Registry_Number { get; set; }
        [MaxLength(254)]
        public string? Witness_1 { get; set; }
        [MaxLength(254)]
        public string? Witness_2 { get; set; }
        [MaxLength(254)]
        public string? Person_1 { get; set; }
        [MaxLength(254)]
        public string? Person_2 { get; set; }
        [MaxLength(254)]
        public string? Mother_Name { get; set; }
        [MaxLength(254)]
        public string? Mother_Maiden_Name { get; set; }
        [MaxLength(254)]
        public string? Mother_Religion { get; set; }
        [MaxLength(254)]
        public string? Father_Name { get; set; }
        [MaxLength(254)]
        public string? Father_Religion { get; set; }
        [MaxLength(150)]
        public string? Spouse_Name { get; set; }
        [MaxLength(150)]
        public string? Spouse_Baptism { get; set; }
        [MaxLength(150)]
        public string? Spouse_Baptism_Church { get; set; }
        [MaxLength(150)]
        public string? Spouse_Baptism_Street { get; set; }
        [MaxLength(150)]
        public string? Spouse_Baptism_City { get; set; }
        [MaxLength(75)]
        public string? Spouse_Baptism_State { get; set; }
        [MaxLength(75)]
        public string? Spouse_Baptism_Zip { get; set; }
        [MaxLength(150)]
        public string? Spouse_Parent_1 { get; set; }
        [MaxLength(150)]
        public string? Spouse_Parent_2 { get; set; }
    }
    [MPTable("Participant_Types")]
    public class ParticipantTypeModel
    {
        [Required]
        [Key]
        public int Participant_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Participant_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public bool Can_Access_Directory { get; set; }
        [Required]
        public bool Show_In_Directory { get; set; }
        [Required]
        public bool Send_Birthday_Email { get; set; }
        [Required]
        public bool Auto_Inactivate { get; set; }
        public int? Days_Without_Activity { get; set; }
        public int? Set_Inactivated_To { get; set; }
        public bool? Publication_Unsubscribe { get; set; }
        [Required]
        public bool Auto_Reactivate { get; set; }
        public int? Days_Before_Reactivating { get; set; }
        public int? Active_Days_Past_30_Days { get; set; }
        public int? Set_Reactivated_To { get; set; }
        [Required]
        public bool Reactivate_with_Family { get; set; }
    }
    [MPTable("Participants")]
    public class ParticipantModel
    {
        [Required]
        [Key]
        public int Participant_ID { get; set; }
        [MaxLength(254)]
        public string? Red_Flag_Notes { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public int Participant_Type_ID { get; set; }
        public int? Member_Status_ID { get; set; }
        public int? Participant_Engagement_ID { get; set; }
        [Required]
        public DateTime Participant_Start_Date { get; set; }
        public DateTime? Participant_End_Date { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
        public DateTime? _First_Attendance_Ever { get; set; }
        public DateTime? _Second_Attendance_Ever { get; set; }
        public DateTime? _Third_Attendance_Ever { get; set; }
        public DateTime? _Last_Attendance_Ever { get; set; }
        [MaxLength(128)]
        public string? _Background_Check_Type { get; set; }
        [MaxLength(50)]
        public string? _Background_Check_Status { get; set; }
        public DateTime? _Background_Check_Date { get; set; }
        public int? Church_of_Record { get; set; }
        [MaxLength(75)]
        public string? Baptism_Parish_Name { get; set; }
        [MaxLength(254)]
        public string? Baptism_Parish_Address { get; set; }
        [MaxLength(254)]
        public string? Birth_Certificate_Address { get; set; }
        [MaxLength(254)]
        public string? Birth_Certificate_City { get; set; }
        [MaxLength(15)]
        public string? Birth_Certificate_State { get; set; }
    }
    [MPTable("Participation_Items")]
    public class ParticipationItemModel
    {
        [Required]
        [Key]
        public int Participation_Item_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Participation_Item { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Participation_Requirements")]
    public class ParticipationRequirementModel
    {
        [Required]
        [Key]
        public int Participation_Requirement_ID { get; set; }
        [Required]
        public int Group_Role_ID { get; set; }
        public int? Background_Check_Type_ID { get; set; }
        public int? Certification_Type_ID { get; set; }
        public int? Milestone_ID { get; set; }
        public int? Custom_Form_ID { get; set; }
        [Required]
        public bool Strictly_Enforced { get; set; }
        [MaxLength(75)]
        public string? Requirement_Name { get; set; }
    }
    [MPTable("Participation_Statuses")]
    public class ParticipationStatusModel
    {
        [Required]
        [Key]
        public int Participation_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Participation_Status { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Payment_Detail")]
    public class PaymentDetailModel
    {
        [Required]
        [Key]
        public int Payment_Detail_ID { get; set; }
        [Required]
        public int Payment_ID { get; set; }
        [Required]
        public decimal Payment_Amount { get; set; }
        [Required]
        public int Invoice_Detail_ID { get; set; }
    }
    [MPTable("Payment_Types")]
    public class PaymentTypeModel
    {
        [Required]
        [Key]
        public int Payment_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Payment_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public bool Omit_Amount_On_Statement { get; set; }
        [Required]
        public bool Is_Online { get; set; }
    }
    [MPTable("Payments")]
    public class PaymentModel
    {
        [Required]
        [Key]
        public int Payment_ID { get; set; }
        [Required]
        public decimal Payment_Total { get; set; }
        [Required]
        public int Contact_ID { get; set; }
        [Required]
        public DateTime Payment_Date { get; set; }
        [MaxLength(500)]
        public string? Gateway_Response { get; set; }
        [MaxLength(50)]
        public string? Transaction_Code { get; set; }
        [MaxLength(4000)]
        public string? Notes { get; set; }
        [MaxLength(25)]
        public string? Merchant_Batch { get; set; }
        public int? Payment_Type_ID { get; set; }
        [MaxLength(15)]
        public string? Item_Number { get; set; }
        public bool? Processed { get; set; }
        [MaxLength(25)]
        public string? Currency { get; set; }
        [MaxLength(25)]
        public string? Invoice_Number { get; set; }
        public int? Congregation_ID { get; set; }
        public int? Invoice_ID { get; set; }
    }
    [MPTable("Perspectives")]
    public class PerspectiveModel
    {
        [Required]
        [Key]
        public int Perspective_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Perspective { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Planned_Contacts")]
    public class PlannedContactModel
    {
        [Required]
        [Key]
        public int Planned_Contact_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Planned_Contact_Title { get; set; }
        [MaxLength(500)]
        public string? Instructions { get; set; }
        [Required]
        public int Manager { get; set; }
        [Required]
        public int Hours_Until_Past_Due { get; set; }
        [Required]
        public int Maximum_Attempts { get; set; }
        [Required]
        public bool Notify_On_Max_Attempts { get; set; }
        [Required]
        public bool Notify_On_Failure { get; set; }
        public int? Next_Planned_Contact { get; set; }
        public int? Next_Contact_By { get; set; }
        public int? Days_Until_Next_Contact { get; set; }
        public int? Call_Team { get; set; }
    }
    [MPTable("Pledge_Adjustment_Types")]
    public class PledgeAdjustmentTypeModel
    {
        [Required]
        [Key]
        public int Pledge_Adjustment_Type_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Pledge_Adjustment_Type { get; set; }
    }
    [MPTable("Pledge_Adjustments")]
    public class PledgeAdjustmentModel
    {
        [Required]
        [Key]
        public int Pledge_Adjustment_ID { get; set; }
        [Required]
        public int Pledge_ID { get; set; }
        [Required]
        public int Pledge_Adjustment_Type_ID { get; set; }
        [Required]
        public DateTime Adjustment_Date { get; set; }
        [Required]
        public decimal Adjustment_Amount { get; set; }
        [Required]
        public decimal Prior_Amount { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
    }
    [MPTable("Pledge_Campaign_Types")]
    public class PledgeCampaignTypeModel
    {
        [Required]
        [Key]
        public int Pledge_Campaign_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Campaign_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Pledge_Campaigns")]
    public class PledgeCampaignModel
    {
        [Required]
        [Key]
        public int Pledge_Campaign_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Campaign_Name { get; set; }
        [MaxLength(50)]
        public string? Nickname { get; set; }
        [Required]
        public int Pledge_Campaign_Type_ID { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public decimal Campaign_Goal { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Event_ID { get; set; }
        public int? Program_ID { get; set; }
        public DateTime? Registration_Start { get; set; }
        public DateTime? Registration_End { get; set; }
        public int? Maximum_Registrants { get; set; }
        public decimal? Registration_Deposit { get; set; }
        public decimal? Fundraising_Goal { get; set; }
        public int? Registration_Form { get; set; }
        [Required]
        public bool Allow_Online_Pledge { get; set; }
        [MaxLength(255)]
        public string? Online_Thank_You_Message { get; set; }
        [Required]
        public bool Pledge_Beyond_End_Date { get; set; }
        [Required]
        public bool Show_On_My_Pledges { get; set; }
        public int? Congregation_ID { get; set; }
        [Required]
        public bool Credit_Parishes { get; set; }
    }
    [MPTable("Pledge_Frequencies")]
    public class PledgeFrequencyModel
    {
        [Required]
        [Key]
        public int Pledge_Frequency_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Pledge_Frequency { get; set; }
    }
    [MPTable("Pledge_Statuses")]
    public class PledgeStatusModel
    {
        [Required]
        [Key]
        public int Pledge_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Pledge_Status { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Pledges")]
    public class PledgeModel
    {
        [Required]
        [Key]
        public int Pledge_ID { get; set; }
        [Required]
        public int Donor_ID { get; set; }
        [Required]
        public int Pledge_Campaign_ID { get; set; }
        [Required]
        public int Pledge_Status_ID { get; set; }
        [Required]
        public decimal Total_Pledge { get; set; }
        [Required]
        public int Installments_Planned { get; set; }
        [Required]
        public int Installments_Per_Year { get; set; }
        public decimal? _Installment_Amount { get; set; }
        [Required]
        public DateTime First_Installment_Date { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        [MaxLength(50)]
        public string? Beneficiary { get; set; }
        [Required]
        public bool Trip_Leader { get; set; }
        [MaxLength(25)]
        public string? Currency { get; set; }
        public int? Parish_Credited_ID { get; set; }
        [Required]
        public bool Parish_Credited_Unknown { get; set; }
        public int? _Gift_Frequency { get; set; }
        public int? Donation_Source_ID { get; set; }
        [Required]
        public bool Send_Pledge_Statement { get; set; }
        public DateTime? _Last_Installment_Date { get; set; }
    }
    [MPTable("Pocket_Platform_Devices")]
    public class PocketPlatformDeviceModel
    {
        [Required]
        [Key]
        public int Device_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Hardware_ID { get; set; }
        public int? User_ID { get; set; }
        [Required]
        public DateTime First_Seen { get; set; }
        [Required]
        public DateTime Last_Seen { get; set; }
        [MaxLength(50)]
        public string? Platform { get; set; }
    }
    [MPTable("Pocket_Platform_Migrations")]
    public class PocketPlatformMigrationModel
    {
        [Required]
        public int Migration_Version { get; set; }
    }
    [MPTable("Prefixes")]
    public class PrefixeModel
    {
        [Required]
        [Key]
        public int Prefix_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prefix { get; set; }
    }
    [MPTable("Print_Servers")]
    public class PrintServerModel
    {
        [Required]
        [Key]
        public int Print_Server_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Machine_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Priorities")]
    public class PriorityModel
    {
        [Required]
        [Key]
        public int Priority_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Priority_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Perspective_ID { get; set; }
        public int? Parent_Priority_ID { get; set; }
    }
    [MPTable("Procedures")]
    public class ProcedureModel
    {
        [Required]
        [Key]
        public int Procedure_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Procedure_Title { get; set; }
        public DateTime? Creation_Date { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int User_ID { get; set; }
        public int? Ministry_ID { get; set; }
        public int? Page_ID { get; set; }
        [MaxLength(1000)]
        public string? Purpose { get; set; }
        [MaxLength(1000)]
        public string? Approach { get; set; }
        public string? Step_by_Step { get; set; }
    }
    [MPTable("Product_Option_Groups")]
    public class ProductOptionGroupModel
    {
        [Required]
        [Key]
        public int Product_Option_Group_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option_Group_Name { get; set; }
        [Required]
        public int Product_ID { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public bool Mutually_Exclusive { get; set; }
        [Required]
        public bool Required { get; set; }
        [MaxLength(50)]
        public string? Note_Label { get; set; }
        public int? Online_Sort_Order { get; set; }
    }
    [MPTable("Product_Option_Prices")]
    public class ProductOptionPriceModel
    {
        [Required]
        [Key]
        public int Product_Option_Price_ID { get; set; }
        [Required]
        public int Product_Option_Group_ID { get; set; }
        [Required]
        public decimal Option_Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option_Title { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int Qty_Allowed { get; set; }
        public int? Add_to_Group { get; set; }
        public int? Sort_Order { get; set; }
        public int? Max_Qty { get; set; }
        public int? Days_Out_To_Hide { get; set; }
        [MaxLength(20)]
        public string? Promo_Code { get; set; }
        public int? Min_Qty { get; set; }
        [Required]
        public bool Attending_Online { get; set; }
    }
    [MPTable("Products")]
    public class ProductModel
    {
        [Required]
        [Key]
        public int Product_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Product_Name { get; set; }
        public int? Congregation_ID { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Base_Price { get; set; }
        public decimal? Deposit_Price { get; set; }
        [Required]
        public bool Active { get; set; }
        public int? Price_Currency { get; set; }
    }
    [MPTable("Program_Groups")]
    public class ProgramGroupModel
    {
        [Required]
        [Key]
        public int Program_Group_ID { get; set; }
        [Required]
        public int Program_ID { get; set; }
        [Required]
        public int Group_ID { get; set; }
        public int? Room_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
    }
    [MPTable("Program_Types")]
    public class ProgramTypeModel
    {
        [Required]
        [Key]
        public int Program_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Program_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Programs")]
    public class ProgramModel
    {
        [Required]
        [Key]
        public int Program_ID { get; set; }
        [Required]
        [MaxLength(130)]
        public string Program_Name { get; set; }
        [Required]
        public int Congregation_ID { get; set; }
        [Required]
        public int Ministry_ID { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Program_Type_ID { get; set; }
        public int? Leadership_Team { get; set; }
        [Required]
        public int Primary_Contact { get; set; }
        public int? Priority_ID { get; set; }
        [Required]
        public bool On_Connection_Card { get; set; }
        [Required]
        public bool Tax_Deductible_Donations { get; set; }
        [Required]
        [MaxLength(50)]
        public string Statement_Title { get; set; }
        [Required]
        public int Statement_Header_ID { get; set; }
        [Required]
        public bool Allow_Online_Giving { get; set; }
        public int? Online_Sort_Order { get; set; }
        public int? Pledge_Campaign_ID { get; set; }
        [MaxLength(25)]
        public string? Account_Number { get; set; }
        public int? Default_Target_Event { get; set; }
        [Required]
        public bool On_Donation_Batch_Tool { get; set; }
        [Required]
        public bool Available_Online { get; set; }
        [Required]
        public bool Omit_From_Engagement_Giving { get; set; }
        public int? SMS_Number { get; set; }
        [MaxLength(1000)]
        public string? OLG_Fund { get; set; }
        [MaxLength(1000)]
        public string? OLG_Sub_Fund { get; set; }
        [MaxLength(1000)]
        public string? Vision2_Program_ID { get; set; }
        [MaxLength(255)]
        public string? Vanco_Campaign_ID { get; set; }
    }
    [MPTable("Relationships")]
    public class RelationshipModel
    {
        [Required]
        [Key]
        public int Relationship_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Relationship_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Male_Label { get; set; }
        [MaxLength(50)]
        public string? Female_Label { get; set; }
        public int? Reciprocal_Relationship_ID { get; set; }
    }
    [MPTable("Request_Statuses")]
    public class RequestStatusModel
    {
        [Required]
        [Key]
        public int Request_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Request_Status { get; set; }
    }
    [MPTable("Response_Follow_Ups")]
    public class ResponseFollowUpModel
    {
        [Required]
        [Key]
        public int Response_Follow_Up_ID { get; set; }
        [Required]
        public int Response_ID { get; set; }
        [Required]
        public DateTime Follow_Up_Date { get; set; }
        [Required]
        public int Action_Type_ID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Notes { get; set; }
        public int? Made_By { get; set; }
    }
    [MPTable("Response_Results")]
    public class ResponseResultModel
    {
        [Required]
        [Key]
        public int Response_Result_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Response_Result { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Responses")]
    public class ResponsModel
    {
        [Required]
        [Key]
        public int Response_ID { get; set; }
        [Required]
        public DateTime Response_Date { get; set; }
        [Required]
        public int Opportunity_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [MaxLength(2000)]
        public string? Comments { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Response_Result_ID { get; set; }
        [Required]
        public bool Closed { get; set; }
        public int? Event_ID { get; set; }
        [Required]
        public bool Notification_Sent { get; set; }
    }
    [MPTable("Room_Layouts")]
    public class RoomLayoutModel
    {
        [Required]
        [Key]
        public int Room_Layout_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Layout_Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public int? Table_Count { get; set; }
        public int? Chair_Count { get; set; }
        public int? Setup_Minutes { get; set; }
        public int? Room_ID { get; set; }
    }
    [MPTable("Room_Usage_Types")]
    public class RoomUsageTypeModel
    {
        [Required]
        [Key]
        public int Room_Usage_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room_Usage_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Rooms")]
    public class RoomModel
    {
        [Required]
        [Key]
        public int Room_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room_Name { get; set; }
        [MaxLength(15)]
        public string? Room_Number { get; set; }
        [Required]
        public int Building_ID { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Maximum_Capacity { get; set; }
        public int? Default_Room_Layout { get; set; }
        public int? Room_Usage_Type_ID { get; set; }
        [Required]
        public bool Bookable { get; set; }
        public DateTime? Last_Remodel_Date { get; set; }
        public int? Parent_Room_ID { get; set; }
        [Required]
        public bool Auto_Approve { get; set; }
        public int? Print_Server_ID { get; set; }
        [MaxLength(128)]
        public string? Printer_Name { get; set; }
    }
    [MPTable("RSVP_Statuses")]
    public class RSVPStatusModel
    {
        [Required]
        [Key]
        public int RSVP_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string RSVP_Status { get; set; }
    }
    [MPTable("Sacrament_Places")]
    public class SacramentPlaceModel
    {
        [Required]
        [Key]
        public int Sacrament_Place_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Place_Name { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public int? Address_ID { get; set; }
        public int? Mailing_Address_ID { get; set; }
        public string? Phone { get; set; }
        public string? Alt_Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        [Required]
        public bool Closed { get; set; }
        public int? Church_Association_ID { get; set; }
    }
    [MPTable("Sacrament_Sponsors")]
    public class SacramentSponsorModel
    {
        [Required]
        [Key]
        public int Sacrament_Sponsor_ID { get; set; }
        [Required]
        public int Sacrament_ID { get; set; }
        public int? Sponsor_ID { get; set; }
        [MaxLength(50)]
        public string? Sponsor_Name { get; set; }
        public int? Print_Order { get; set; }
        public int? Sponsor_Type_ID { get; set; }
    }
    [MPTable("Sacrament_Types")]
    public class SacramentTypeModel
    {
        [Required]
        [Key]
        public int Sacrament_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sacrament_Type { get; set; }
        [Required]
        public bool Active { get; set; }
    }
    [MPTable("Sacraments")]
    public class SacramentModel
    {
        [Required]
        [Key]
        public int Sacrament_ID { get; set; }
        [Required]
        public int Sacrament_Type_ID { get; set; }
        [Required]
        public DateTime Date_Received { get; set; }
        [Required]
        public int Date_Received_Accuracy_ID { get; set; }
        [Required]
        public int Participant_ID { get; set; }
        [MaxLength(100)]
        public string? Participant_Name { get; set; }
        public int? Performed_By_ID { get; set; }
        [MaxLength(100)]
        public string? Performed_By_Name { get; set; }
        public int? Place_ID { get; set; }
        [MaxLength(128)]
        public string? Place_Name { get; set; }
        [MaxLength(10)]
        public string? Volume { get; set; }
        public int? Page { get; set; }
        public int? Entry { get; set; }
        [MaxLength(128)]
        public string? Place_of_Birth { get; set; }
        public int? Father_ID { get; set; }
        [MaxLength(100)]
        public string? Name_of_Father { get; set; }
        public int? Mother_ID { get; set; }
        [MaxLength(100)]
        public string? Name_of_Mother { get; set; }
        public bool? Profession_of_Faith { get; set; }
        public DateTime? Profession_of_Faith_Date { get; set; }
        public bool? Verified { get; set; }
        public bool? Notification_Received { get; set; }
        [MaxLength(128)]
        public string? Place_of_Burial { get; set; }
        public DateTime? Date_of_Burial { get; set; }
        public int? Spouse_ID { get; set; }
        [MaxLength(100)]
        public string? Spouse_Name { get; set; }
        public bool? Interfaith { get; set; }
        public bool? Annulment { get; set; }
        [MaxLength(15)]
        public string? Protocol_Number { get; set; }
        [MaxLength(100)]
        public string? Confirmation_Saint { get; set; }
        [MaxLength(2000)]
        public string? Notes { get; set; }
    }
    [MPTable("Schedule_Statuses")]
    public class ScheduleStatusModel
    {
        [Required]
        [Key]
        public int Schedule_Status_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Schedule_Status { get; set; }
    }
    [MPTable("Scheduled_Donations")]
    public class ScheduledDonationModel
    {
        [Required]
        [Key]
        public int Scheduled_Donation_ID { get; set; }
        [Required]
        public int Donor_ID { get; set; }
        [Required]
        public int Donor_Account_ID { get; set; }
        [Required]
        public string Day_of_Month { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        [Required]
        public int Program_ID { get; set; }
        public int? Target_Event { get; set; }
        public int? Pledge_ID { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
    [MPTable("Service_Types")]
    public class ServiceTypeModel
    {
        [Required]
        [Key]
        public int Service_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Service_Type { get; set; }
    }
    [MPTable("Servicing")]
    public class ServicingModel
    {
        [Required]
        [Key]
        public int Service_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Service_Name { get; set; }
        public int? Service_Type_ID { get; set; }
        [MaxLength(50)]
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? Team_Group_ID { get; set; }
        public int? Contact_ID { get; set; }
        [Required]
        public bool Standard_Service { get; set; }
        [Required]
        public bool Auto_Approve { get; set; }
        public int? Days_To_Remind { get; set; }
    }
    [MPTable("Sponsor_Types")]
    public class SponsorTypeModel
    {
        [Required]
        [Key]
        public int Sponsor_Type_ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Sponsor_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Statement_Cutoff_Automation")]
    public class StatementCutoffAutomationModel
    {
        [Required]
        [Key]
        public int Statement_Cutoff_Automation_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Automation_Type { get; set; }
        [MaxLength(500)]
        public string? Automation_Description { get; set; }
    }
    [MPTable("Statement_Frequencies")]
    public class StatementFrequencyModel
    {
        [Required]
        [Key]
        public int Statement_Frequency_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Statement_Frequency { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Statement_Headers")]
    public class StatementHeaderModel
    {
        [Required]
        [Key]
        public int Statement_Header_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Statement_Header { get; set; }
        [Required]
        public string Header_Sort { get; set; }
    }
    [MPTable("Statement_Methods")]
    public class StatementMethodModel
    {
        [Required]
        [Key]
        public int Statement_Method_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Statement_Method { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Statement_Types")]
    public class StatementTypeModel
    {
        [Required]
        [Key]
        public int Statement_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Statement_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Suffixes")]
    public class SuffixeModel
    {
        [Required]
        [Key]
        public int Suffix_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Suffix { get; set; }
    }
    [MPTable("Suggestion_Types")]
    public class SuggestionTypeModel
    {
        [Required]
        [Key]
        public int Suggestion_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Suggestion_Type { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Time_Off_Types")]
    public class TimeOffTypeModel
    {
        [Required]
        [Key]
        public int Time_Off_Type_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Time_Off_Type { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
    [MPTable("Visibility_Levels")]
    public class VisibilityLevelModel
    {
        [Required]
        [Key]
        public int Visibility_Level_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Visibility_Level { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
    [MPTable("Wifi_Device_Sessions")]
    public class WifiDeviceSessionModel
    {
        [Required]
        [Key]
        public int Wifi_Device_Session_ID { get; set; }
        [Required]
        public int Wifi_Device_ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Session_GUID { get; set; }
        [Required]
        public DateTime Session_Start { get; set; }
        public DateTime? Session_End { get; set; }
        [Required]
        [MaxLength(50)]
        public string Wifi_Space { get; set; }
        [Required]
        public int Duration_in_Minutes { get; set; }
        [MaxLength(50)]
        public string? Contact_ID_Value { get; set; }
    }
    [MPTable("Wifi_Devices")]
    public class WifiDeviceModel
    {
        [Required]
        [Key]
        public int Wifi_Device_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Hardware_Mac { get; set; }
        public int? Contact_ID { get; set; }
        [MaxLength(50)]
        public string? First_Name { get; set; }
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        public string? Email_Address { get; set; }
        public string? Mobile_Phone { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
    }
    [MPTable("Z_Event_Notifications")]
    public class ZEventNotificationModel
    {
        [Required]
        public int Event_ID { get; set; }
        public int? Registrant_Message { get; set; }
        public int? RM_Template { get; set; }
        public int? Optional_Reminder_Message { get; set; }
        public int? OR_Template { get; set; }
        public int? Attendee_Message { get; set; }
        public int? AM_Template { get; set; }
    }
    [MPTable("Z_Form_Notifications")]
    public class ZFormNotificationModel
    {
        [Required]
        public int Form_ID { get; set; }
        public int? Response_Message { get; set; }
        public int? RM_Template { get; set; }
    }
    [MPTable("Z_Opp_Notifications")]
    public class ZOppNotificationModel
    {
        [Required]
        public int Opportunity_ID { get; set; }
        public int? Response_Message { get; set; }
        public int? RM_Template { get; set; }
        public int? Optional_Reminder_Message { get; set; }
        public int? OR_Template { get; set; }
    }
}